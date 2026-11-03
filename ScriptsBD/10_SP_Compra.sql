USE GU_Tercero;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PagoCompra')
BEGIN
    CREATE TABLE PagoCompra (
        Id_PagoCompra INT IDENTITY(1,1) PRIMARY KEY,
        Id_Compra INT NOT NULL,
        Id_MetodoPago INT NOT NULL,
        Importe DECIMAL(12,2) NOT NULL,
        FOREIGN KEY (Id_Compra) REFERENCES Compra(Id_Compra),
        FOREIGN KEY (Id_MetodoPago) REFERENCES MetodoPago(Id_MetodoPago),
        CHECK (Importe > 0)
    );
END
GO

INSERT INTO PagoCompra (Id_Compra, Id_MetodoPago, Importe)
SELECT c.Id_Compra, c.Id_MetodoPago, c.Total
FROM Compra c
WHERE c.Total > 0
  AND NOT EXISTS (SELECT 1 FROM PagoCompra pc WHERE pc.Id_Compra = c.Id_Compra);
GO

IF COL_LENGTH('DetalleCompra', 'Id_Proveedor') IS NULL
BEGIN
    ALTER TABLE DetalleCompra ADD Id_Proveedor INT NULL;
    ALTER TABLE DetalleCompra ADD CONSTRAINT FK_DetalleCompra_Proveedor
        FOREIGN KEY (Id_Proveedor) REFERENCES Proveedor(Id_Proveedor);
END
GO

UPDATE d
SET d.Id_Proveedor = c.Id_Proveedor
FROM DetalleCompra d
INNER JOIN Compra c ON c.Id_Compra = d.Id_Compra
WHERE d.Id_Proveedor IS NULL;
GO

CREATE OR ALTER PROCEDURE sp_RegistrarCompra
    @Numero_Comprobante VARCHAR(50) = NULL,
    @Id_Proveedor INT,
    @Id_Usuario INT,
    @Id_MetodoPago INT,
    @Total DECIMAL(12,2),
    @Fecha_Compra DATETIME = NULL,
    @Id_CompraGenerado INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE Id_Proveedor = @Id_Proveedor AND Activo = 1)
    BEGIN
        RAISERROR('El proveedor seleccionado no existe o no está activo.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Id_MetodoPago = @Id_MetodoPago)
    BEGIN
        RAISERROR('El método de pago seleccionado no es válido.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
    BEGIN
        RAISERROR('El usuario que registra la compra no es válido.', 16, 1);
        RETURN;
    END

    IF @Fecha_Compra IS NULL
        SET @Fecha_Compra = GETDATE();

    INSERT INTO Compra (Numero_Comprobante, Id_Proveedor, Id_Usuario, Id_MetodoPago, Total, Fecha_Compra, Estado)
    VALUES (@Numero_Comprobante, @Id_Proveedor, @Id_Usuario, @Id_MetodoPago, @Total, @Fecha_Compra, 1);

    SET @Id_CompraGenerado = SCOPE_IDENTITY();

    IF @Numero_Comprobante IS NULL OR LTRIM(RTRIM(@Numero_Comprobante)) = ''
    BEGIN
        UPDATE Compra
        SET Numero_Comprobante = 'COM-' + RIGHT('00000000' + CAST(@Id_CompraGenerado AS NVARCHAR(8)), 8)
        WHERE Id_Compra = @Id_CompraGenerado;
    END
END
GO

CREATE OR ALTER PROCEDURE sp_RegistrarDetalleCompra
    @Id_Compra INT,
    @Id_Producto INT,
    @Precio_Costo_Unitario DECIMAL(12,2),
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Precio_Venta DECIMAL(12,2);
    DECLARE @Nombre NVARCHAR(50);

    SELECT @Precio_Venta = Precio_Venta, @Nombre = Nombre_Producto
    FROM Producto
    WHERE Id_Producto = @Id_Producto
      AND Activo = 1;

    IF @Precio_Venta IS NULL
    BEGIN
        RAISERROR('El producto no existe o está dado de baja.', 16, 1);
        RETURN;
    END

    IF @Precio_Costo_Unitario > @Precio_Venta
    BEGIN
        RAISERROR('El costo unitario de %s no puede ser mayor a su precio de venta.', 16, 1, @Nombre);
        RETURN;
    END

    DECLARE @Id_Proveedor INT = (
        SELECT TOP 1 pp.Id_Proveedor
        FROM ProductoProveedor pp
        INNER JOIN Proveedor pr ON pr.Id_Proveedor = pp.Id_Proveedor AND pr.Activo = 1
        WHERE pp.Id_Producto = @Id_Producto
          AND pp.Activo = 1
        ORDER BY pp.Id_ProductoProveedor DESC
    );

    IF @Id_Proveedor IS NULL
    BEGIN
        RAISERROR('El producto %s no tiene asignado un proveedor activo.', 16, 1, @Nombre);
        RETURN;
    END

    INSERT INTO DetalleCompra (Id_Compra, Id_Producto, Cantidad, Precio_Costo_Unitario, Id_Proveedor)
    VALUES (@Id_Compra, @Id_Producto, @Cantidad, @Precio_Costo_Unitario, @Id_Proveedor);

    UPDATE Producto
    SET Stock_Actual = Stock_Actual + @Cantidad,
        Precio_Costo = @Precio_Costo_Unitario
    WHERE Id_Producto = @Id_Producto;
END
GO

CREATE OR ALTER PROCEDURE sp_BuscarProductosCompra
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.Id_Producto,
        ISNULL(NULLIF(p.Codigo_Barras, ''), CONVERT(NVARCHAR(20), p.Id_Producto)) AS Codigo,
        p.Nombre_Producto AS Producto,
        p.Precio_Venta,
        p.Precio_Costo,
        pp.Id_Proveedor,
        pr.Razon_Social AS Proveedor,
        CAST(ISNULL(pr.Activo, 0) AS BIT) AS Proveedor_Activo
    FROM Producto p
    OUTER APPLY (
        SELECT TOP 1 x.Id_Proveedor
        FROM ProductoProveedor x
        WHERE x.Id_Producto = p.Id_Producto
          AND x.Activo = 1
        ORDER BY x.Id_ProductoProveedor DESC
    ) pp
    LEFT JOIN Proveedor pr ON pr.Id_Proveedor = pp.Id_Proveedor
    WHERE p.Activo = 1
    ORDER BY p.Nombre_Producto ASC;
END
GO

CREATE OR ALTER PROCEDURE sp_RegistrarPagoCompra
    @Id_Compra INT,
    @Id_MetodoPago INT,
    @Importe DECIMAL(12,2)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Id_MetodoPago = @Id_MetodoPago)
    BEGIN
        RAISERROR('El método de pago no es válido.', 16, 1);
        RETURN;
    END

    IF @Importe <= 0
    BEGIN
        RAISERROR('El importe de cada pago debe ser mayor a cero.', 16, 1);
        RETURN;
    END

    INSERT INTO PagoCompra (Id_Compra, Id_MetodoPago, Importe)
    VALUES (@Id_Compra, @Id_MetodoPago, @Importe);
END
GO
