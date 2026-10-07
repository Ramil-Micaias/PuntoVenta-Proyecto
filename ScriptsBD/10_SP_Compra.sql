USE GU_Tercero;
GO

-- ============================================================
-- MODULO: COMPRAS (CU04)
-- SPs requeridos por FormCompras / GestorCompras / CompraDAO
-- ============================================================

-- 1. SP PARA REGISTRAR LA CABECERA DE COMPRA
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

    -- Validar que el proveedor exista y esté activo
    IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE Id_Proveedor = @Id_Proveedor AND Activo = 1)
    BEGIN
        RAISERROR('El proveedor seleccionado no existe o no está activo.', 16, 1);
        RETURN;
    END

    -- Validar que se haya seleccionado un Método de Pago válido
    IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Id_MetodoPago = @Id_MetodoPago)
    BEGIN
        RAISERROR('El método de pago seleccionado no es válido.', 16, 1);
        RETURN;
    END

    -- Validar usuario
    IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
    BEGIN
        RAISERROR('El usuario que registra la compra no es válido.', 16, 1);
        RETURN;
    END

    -- Si no se envía fecha, toma la fecha/hora actual del sistema
    IF @Fecha_Compra IS NULL 
        SET @Fecha_Compra = GETDATE();

    -- Insertar Cabecera de Compra
    INSERT INTO Compra (Numero_Comprobante, Id_Proveedor, Id_Usuario, Id_MetodoPago, Total, Fecha_Compra, Estado)
    VALUES (@Numero_Comprobante, @Id_Proveedor, @Id_Usuario, @Id_MetodoPago, @Total, @Fecha_Compra, 1);

    -- Obtener el ID autonumérico generado
    SET @Id_CompraGenerado = SCOPE_IDENTITY();

    -- Si el comprobante vino vacío, le asignamos un código autonumérico estándar (Ej: COM-00000001)
    IF @Numero_Comprobante IS NULL OR LTRIM(RTRIM(@Numero_Comprobante)) = ''
    BEGIN
        UPDATE Compra
        SET Numero_Comprobante = 'COM-' + RIGHT('00000000' + CAST(@Id_CompraGenerado AS NVARCHAR(8)), 8)
        WHERE Id_Compra = @Id_CompraGenerado;
    END
END
GO


-- 2. SP PARA REGISTRAR CADA DETALLE Y ACTUALIZAR STOCK Y PRECIOS
CREATE OR ALTER PROCEDURE sp_RegistrarDetalleCompra
    @Id_Compra INT,
    @Id_Producto INT,
    @Precio_Costo_Unitario DECIMAL(12,2),
    @Cantidad INT,
    @Precio_Venta_Sugerido DECIMAL(12,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Insertar el ítem en la tabla DetalleCompra
    INSERT INTO DetalleCompra (Id_Compra, Id_Producto, Cantidad, Precio_Costo_Unitario)
    VALUES (@Id_Compra, @Id_Producto, @Cantidad, @Precio_Costo_Unitario);

    -- 2. Incrementar el stock del producto y actualizar su precio de costo (y venta si se indicó)
    UPDATE Producto 
    SET Stock_Actual = Stock_Actual + @Cantidad,
        Precio_Costo = @Precio_Costo_Unitario,
        Precio_Venta = ISNULL(@Precio_Venta_Sugerido, Precio_Venta)
    WHERE Id_Producto = @Id_Producto;
END
GO