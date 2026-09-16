USE GU_Tercero;
GO

-- =============================================
-- 1. SP: Obtener Productos
-- =============================================
IF OBJECT_ID('sp_ObtenerProductos', 'P') IS NOT NULL
    DROP PROCEDURE sp_ObtenerProductos;
GO

CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id_Producto,
        p.Id_Categoria,
        p.Id_Proveedor,
        p.Codigo_Barras,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Costo,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Es_Repuesto,
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria
    FROM Producto p
    INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1
    ORDER BY p.Nombre_Producto ASC;
END
GO

-- =============================================
-- 2. SP: Obtener Categorías
-- =============================================
IF OBJECT_ID('sp_ObtenerCategorias', 'P') IS NOT NULL
    DROP PROCEDURE sp_ObtenerCategorias;
GO

CREATE PROCEDURE sp_ObtenerCategorias
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Categoria,
        Nombre_Categoria
    FROM CategoriaProducto
    WHERE Activo = 1
    ORDER BY Nombre_Categoria ASC;
END
GO

-- =============================================
-- 3. SP: Buscar Productos (Por nombre o código de barras)
-- =============================================
IF OBJECT_ID('sp_BuscarProductos', 'P') IS NOT NULL
    DROP PROCEDURE sp_BuscarProductos;
GO

CREATE PROCEDURE sp_BuscarProductos
    @Filtro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id_Producto,
        p.Id_Categoria,
        p.Id_Proveedor,
        p.Codigo_Barras,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Costo,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Es_Repuesto,
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria
    FROM Producto p
    INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1 
      AND (p.Nombre_Producto LIKE '%' + @Filtro + '%' 
       OR p.Codigo_Barras LIKE '%' + @Filtro + '%')
    ORDER BY p.Nombre_Producto ASC;
END
GO

-- =============================================
-- 4. SP: Insertar Producto (Código de barras OBLIGATORIO)
-- =============================================
IF OBJECT_ID('sp_InsertarProducto', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertarProducto;
GO

CREATE PROCEDURE sp_InsertarProducto
    @Id_Categoria INT,
    @Id_Proveedor INT = NULL,
    @Codigo_Barras NVARCHAR(50), -- OBLIGATORIO (Se quitó el = NULL)
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Costo DECIMAL(12,2),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT = 0,
    @Stock_Minimo INT = 2,
    @Es_Repuesto BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación opcional: evitar códigos de barra duplicados
    IF EXISTS (SELECT 1 FROM Producto WHERE Codigo_Barras = @Codigo_Barras)
    BEGIN
        RAISERROR('El código de barras ya pertenece a otro producto activo o registrado.', 16, 1);
        RETURN;
    END

    INSERT INTO Producto (
        Id_Categoria,
        Id_Proveedor,
        Codigo_Barras,
        Nombre_Producto,
        Descripcion,
        Precio_Costo,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @Id_Categoria,
        @Id_Proveedor,
        @Codigo_Barras,
        @Nombre_Producto,
        @Descripcion,
        @Precio_Costo,
        @Precio_Venta,
        @Stock_Actual,
        @Stock_Minimo,
        @Es_Repuesto,
        1
    );
END
GO

-- =============================================
-- 5. SP: Modificar Producto (Código de barras OBLIGATORIO)
-- =============================================
IF OBJECT_ID('sp_ModificarProducto', 'P') IS NOT NULL
    DROP PROCEDURE sp_ModificarProducto;
GO

CREATE PROCEDURE sp_ModificarProducto
    @Id_Producto INT,
    @Id_Categoria INT,
    @Id_Proveedor INT = NULL,
    @Codigo_Barras NVARCHAR(50), -- OBLIGATORIO (Se quitó el = NULL)
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Costo DECIMAL(12,2),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT,
    @Stock_Minimo INT,
    @Es_Repuesto BIT,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que no se intente poner un código de barras de OTRO producto
    IF EXISTS (SELECT 1 FROM Producto WHERE Codigo_Barras = @Codigo_Barras AND Id_Producto <> @Id_Producto)
    BEGIN
        RAISERROR('El código de barras ya pertenece a otro producto registrado.', 16, 1);
        RETURN;
    END

    UPDATE Producto
    SET 
        Id_Categoria = @Id_Categoria,
        Id_Proveedor = @Id_Proveedor,
        Codigo_Barras = @Codigo_Barras,
        Nombre_Producto = @Nombre_Producto,
        Descripcion = @Descripcion,
        Precio_Costo = @Precio_Costo,
        Precio_Venta = @Precio_Venta,
        Stock_Actual = @Stock_Actual,
        Stock_Minimo = @Stock_Minimo,
        Es_Repuesto = @Es_Repuesto,
        Activo = @Activo
    WHERE Id_Producto = @Id_Producto;
END
GO

-- =============================================
-- 6. SP: Inactivar Producto (Baja lógica)
-- =============================================
IF OBJECT_ID('sp_InactivarProducto', 'P') IS NOT NULL
    DROP PROCEDURE sp_InactivarProducto;
GO

CREATE PROCEDURE sp_InactivarProducto
    @Id_Producto INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Producto
    SET Activo = 0
    WHERE Id_Producto = @Id_Producto;
END
GO