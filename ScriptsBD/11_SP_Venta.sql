USE GU_Tercero;
GO

-- ============================================================
-- MODULO: VENTAS (CU01)
-- Migraciones de esquema necesarias + Stored Procedures requeridos
-- por FormVentas, ClienteDAO, MetodoPagoDAO y ProductoDAO (POS)
-- ============================================================

-- ------------------------------------------------------------
-- 1. MIGRACIONES DE ESQUEMA (Idempotentes)
-- ------------------------------------------------------------

-- Precio de costo: lo usa el sistema de inventario y compras
IF COL_LENGTH('Producto', 'Precio_Costo') IS NULL
    ALTER TABLE Producto ADD Precio_Costo DECIMAL(12,2) NULL;
GO

-- Código de barras o código interno: lo usa el buscador del POS
IF COL_LENGTH('Producto', 'Codigo_Barras') IS NULL
    ALTER TABLE Producto ADD Codigo_Barras NVARCHAR(50) NULL;
GO

-- Descuento aplicado a la venta en cabecera
IF COL_LENGTH('Venta', 'Descuento') IS NULL
    ALTER TABLE Venta ADD Descuento DECIMAL(12,2) NOT NULL DEFAULT 0;
GO


-- ------------------------------------------------------------
-- 2. REPARACIÓN DE ACENTOS (Idempotente)
-- ------------------------------------------------------------
CREATE OR ALTER FUNCTION dbo.fn_UnMojibake(@texto NVARCHAR(4000))
RETURNS NVARCHAR(4000)
AS
BEGIN
    IF @texto IS NULL
       OR (@texto NOT LIKE N'%' + NCHAR(195) + N'%'
           AND @texto NOT LIKE N'%' + NCHAR(194) + N'%')
        RETURN @texto;

    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(161), NCHAR(225));  -- á
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(169), NCHAR(233));  -- é
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(173), NCHAR(237));  -- í
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(179), NCHAR(243));  -- ó
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(186), NCHAR(250));  -- ú
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(188), NCHAR(252));  -- ü
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(177), NCHAR(241));  -- ñ
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(167), NCHAR(231));  -- ç
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(129), NCHAR(193));  -- Á
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(137), NCHAR(201));  -- É
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(141), NCHAR(205));  -- Í
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(147), NCHAR(211));  -- Ó
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(154), NCHAR(218));  -- Ú
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(156), NCHAR(220));  -- Ü
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(145), NCHAR(209));  -- Ñ
    SET @texto = REPLACE(@texto, NCHAR(194) + NCHAR(161), NCHAR(161));  -- ¡
    SET @texto = REPLACE(@texto, NCHAR(194) + NCHAR(191), NCHAR(191));  -- ¿
    SET @texto = REPLACE(@texto, NCHAR(194) + NCHAR(176), NCHAR(176));  -- °
    SET @texto = REPLACE(@texto, NCHAR(194) + NCHAR(186), NCHAR(186));  -- º
    SET @texto = REPLACE(@texto, NCHAR(195) + NCHAR(8220), NCHAR(243));  -- ó

    RETURN @texto;
END
GO

UPDATE MetodoPago
SET Nombre = dbo.fn_UnMojibake(Nombre)
WHERE Nombre LIKE N'%' + NCHAR(195) + N'%';
GO

UPDATE CategoriaProducto
SET Nombre_Categoria = dbo.fn_UnMojibake(Nombre_Categoria)
WHERE Nombre_Categoria LIKE N'%' + NCHAR(195) + N'%';
GO

UPDATE Producto
SET Nombre_Producto = dbo.fn_UnMojibake(Nombre_Producto),
    Descripcion = dbo.fn_UnMojibake(Descripcion)
WHERE ISNULL(Nombre_Producto, N'') LIKE N'%' + NCHAR(195) + N'%'
   OR ISNULL(Descripcion, N'') LIKE N'%' + NCHAR(195) + N'%';
GO

UPDATE Proveedor
SET Razon_Social = dbo.fn_UnMojibake(Razon_Social)
WHERE Razon_Social LIKE N'%' + NCHAR(195) + N'%';
GO


-- ------------------------------------------------------------
-- 3. SP: Métodos de pago
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerMetodosPago
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_MetodoPago,
        Nombre
    FROM MetodoPago
    ORDER BY Nombre ASC;
END
GO


-- ------------------------------------------------------------
-- 4. SP: Buscar clientes (para el campo Cliente del POS)
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_BuscarClientes
    @Filtro NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SET @Filtro = LTRIM(RTRIM(ISNULL(@Filtro, '')));

    SELECT TOP 50
        c.Id_Cliente,
        p.Apellido,
        p.Nombre,
        p.DNI,
        p.Apellido + ', ' + p.Nombre AS NombreCompleto
    FROM Cliente c
    INNER JOIN Persona p ON c.Id_Persona = p.Id_Persona
    WHERE c.Activo = 1
      AND p.Activo = 1
      AND (
            @Filtro = ''
         OR p.DNI LIKE '%' + @Filtro + '%'
         OR p.Nombre LIKE '%' + @Filtro + '%'
         OR p.Apellido LIKE '%' + @Filtro + '%'
      )
    ORDER BY p.Apellido ASC, p.Nombre ASC;
END
GO

-- Compatibilidad: sp_BuscarCliente (singular)
CREATE OR ALTER PROCEDURE sp_BuscarCliente
    @Filtro NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    EXEC sp_BuscarClientes @Filtro;
END
GO

-- Procedimiento de soporte: sp_mercadopago / sp_MercadoPago
-- Retorna la información del método de pago de Mercado Pago o lo registra si no existe
CREATE OR ALTER PROCEDURE sp_mercadopago
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Mercado Pago')
    BEGIN
        INSERT INTO MetodoPago (Nombre) VALUES ('Mercado Pago');
    END

    SELECT
        Id_MetodoPago,
        Nombre
    FROM MetodoPago
    WHERE Nombre = 'Mercado Pago';
END
GO

CREATE OR ALTER PROCEDURE sp_MercadoPago
AS
BEGIN
    SET NOCOUNT ON;
    EXEC sp_mercadopago;
END
GO


-- ------------------------------------------------------------
-- 5. SP: Buscar productos para el POS
--    Búsqueda por nombre, descripción o código, con categoría opcional
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_BuscarProductosPOS
    @Filtro NVARCHAR(100) = '',
    @Id_Categoria INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SET @Filtro = LTRIM(RTRIM(ISNULL(@Filtro, '')));

    SELECT
        p.Id_Producto,
        ISNULL(
            NULLIF(p.Codigo_Barras, ''),
            CONVERT(NVARCHAR(20), p.Id_Producto)
        ) AS Codigo,
        ISNULL(NULLIF(p.Nombre_Producto, ''), p.Descripcion) AS Producto,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Venta,
        p.Precio_Costo,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Id_Categoria,
        c.Nombre_Categoria AS NombreCategoria
    FROM Producto p
    INNER JOIN CategoriaProducto c
        ON c.Id_Categoria = p.Id_Categoria
    WHERE p.Activo = 1
      AND (@Id_Categoria IS NULL OR p.Id_Categoria = @Id_Categoria)
      AND (
            @Filtro = ''
         OR ISNULL(p.Nombre_Producto, '') LIKE '%' + @Filtro + '%'
         OR ISNULL(p.Descripcion, '') LIKE '%' + @Filtro + '%'
         OR ISNULL(p.Codigo_Barras, '') LIKE '%' + @Filtro + '%'
      )
    ORDER BY p.Nombre_Producto ASC;
END
GO


-- ------------------------------------------------------------
-- 6. SP: Registrar venta
--    Utilizado por VentaDAO (ejecuta con JSON en @Detalles)
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_RegistrarVenta
    @Numero_Factura NVARCHAR(20) = NULL,
    @Id_Cliente INT = NULL,
    @Id_Usuario INT,
    @Id_MetodoPago INT,
    @DescuentoPorcentaje DECIMAL(5,2) = 0,
    @Fecha DATETIME = NULL,
    @Detalles NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Valida método de pago
        IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Id_MetodoPago = @Id_MetodoPago)
        BEGIN
            RAISERROR('El método de pago seleccionado no es válido.', 16, 1);
        END

        -- Valida cliente (solo si vino informado)
        IF @Id_Cliente IS NOT NULL
           AND NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente AND Activo = 1)
        BEGIN
            RAISERROR('El cliente seleccionado no existe o está inactivo.', 16, 1);
        END

        -- Valida usuario vendedor
        IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
        BEGIN
            RAISERROR('El usuario vendedor no es válido. Inicie sesión nuevamente.', 16, 1);
        END

        -- Valida descuento (Resumen de Pago)
        IF @DescuentoPorcentaje IS NULL
           OR @DescuentoPorcentaje < 0
           OR @DescuentoPorcentaje > 100
        BEGIN
            RAISERROR('El descuento debe estar entre 0 y 100 por ciento.', 16, 1);
        END

        -- Deserializa el detalle
        DECLARE @Detalle TABLE (
            Id_Producto INT,
            Cantidad INT,
            Precio DECIMAL(12,2)
        );

        INSERT INTO @Detalle (Id_Producto, Cantidad, Precio)
        SELECT Id_Producto, Cantidad, Precio
        FROM OPENJSON(@Detalles)
        WITH (
            Id_Producto INT '$.Id_Producto',
            Cantidad INT '$.Cantidad',
            Precio DECIMAL(12,2) '$.Precio'
        );

        IF NOT EXISTS (SELECT 1 FROM @Detalle)
        BEGIN
            RAISERROR('La venta no tiene productos agregados.', 16, 1);
        END

        IF EXISTS (SELECT 1 FROM @Detalle WHERE Id_Producto IS NULL OR Cantidad <= 0 OR Precio < 0)
        BEGIN
            RAISERROR('El detalle de la venta contiene datos inválidos.', 16, 1);
        END

        -- Producto inexistente o inactivo
        IF EXISTS (
            SELECT 1
            FROM @Detalle d
            LEFT JOIN Producto p ON p.Id_Producto = d.Id_Producto AND p.Activo = 1
            WHERE p.Id_Producto IS NULL
        )
        BEGIN
            RAISERROR('Uno de los productos de la venta no existe o está inactivo.', 16, 1);
        END

        -- Validación de stock
        DECLARE @MensajeError NVARCHAR(300);

        IF EXISTS (
            SELECT 1
            FROM (
                SELECT Id_Producto, SUM(Cantidad) AS Requerido
                FROM @Detalle
                GROUP BY Id_Producto
            ) req
            INNER JOIN Producto p ON p.Id_Producto = req.Id_Producto
            WHERE p.Stock_Actual < req.Requerido
        )
        BEGIN
            SELECT TOP 1 @MensajeError =
                'Stock insuficiente para "' + ISNULL(NULLIF(p.Nombre_Producto, ''), p.Descripcion) + '". ' +
                'Stock disponible: ' + CAST(p.Stock_Actual AS NVARCHAR(10)) +
                ' unidades. Cantidad solicitada: ' + CAST(req.Requerido AS NVARCHAR(10)) + '.'
            FROM (
                SELECT Id_Producto, SUM(Cantidad) AS Requerido
                FROM @Detalle
                GROUP BY Id_Producto
            ) req
            INNER JOIN Producto p ON p.Id_Producto = req.Id_Producto
            WHERE p.Stock_Actual < req.Requerido
            ORDER BY p.Nombre_Producto;

            RAISERROR(@MensajeError, 16, 1);
        END

        -- Totales calculados por el sistema
        DECLARE @Subtotal DECIMAL(12,2);
        DECLARE @MontoDescuento DECIMAL(12,2);
        DECLARE @TotalNeto DECIMAL(12,2);

        SELECT @Subtotal = ISNULL(SUM(Cantidad * Precio), 0)
        FROM @Detalle;

        IF @Subtotal <= 0
        BEGIN
            RAISERROR('El total de la venta debe ser mayor a cero.', 16, 1);
        END

        SET @MontoDescuento = ROUND(@Subtotal * @DescuentoPorcentaje / 100, 2);
        SET @TotalNeto = @Subtotal - @MontoDescuento;

        IF @TotalNeto <= 0
        BEGIN
            RAISERROR('El descuento aplicado deja el total de la venta en cero.', 16, 1);
        END

        -- Cabecera de la venta
        DECLARE @IdVenta INT;
        DECLARE @FechaVenta DATETIME = ISNULL(@Fecha, GETDATE());

        INSERT INTO Venta (
            Numero_Factura,
            Id_Cliente,
            Id_Usuario_Vendedor,
            Id_MetodoPago,
            Total,
            Descuento,
            Fecha_Venta,
            Anulada
        )
        VALUES (
            @Numero_Factura,
            @Id_Cliente,
            @Id_Usuario,
            @Id_MetodoPago,
            @TotalNeto,
            @MontoDescuento,
            @FechaVenta,
            0
        );

        SET @IdVenta = SCOPE_IDENTITY();

        -- Comprobante interno automático si no se ingresó uno manual
        IF @Numero_Factura IS NULL OR LTRIM(RTRIM(@Numero_Factura)) = ''
        BEGIN
            UPDATE Venta
            SET Numero_Factura = 'VTA-' + RIGHT('00000000' + CAST(@IdVenta AS NVARCHAR(8)), 8)
            WHERE Id_Venta = @IdVenta;
        END

        -- Detalle
        INSERT INTO DetalleVenta (Id_Venta, Id_Producto, Cantidad, Precio_Unitario)
        SELECT @IdVenta, Id_Producto, Cantidad, Precio
        FROM @Detalle;

        -- Descuento de stock
        UPDATE p
        SET p.Stock_Actual = p.Stock_Actual - req.Requerido
        FROM Producto p
        INNER JOIN (
            SELECT Id_Producto, SUM(Cantidad) AS Requerido
            FROM @Detalle
            GROUP BY Id_Producto
        ) req ON p.Id_Producto = req.Id_Producto;

        COMMIT TRANSACTION;

        SELECT
            @IdVenta AS Id_Venta,
            (
                SELECT Numero_Factura
                FROM Venta
                WHERE Id_Venta = @IdVenta
            ) AS Numero_Comprobante,
            @Subtotal AS Subtotal,
            @MontoDescuento AS Descuento,
            @TotalNeto AS Total;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO