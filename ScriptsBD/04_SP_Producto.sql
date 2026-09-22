USE GU_Tercero;
GO

-- =============================================
-- 1. SP: Obtener Productos
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id_Producto,
        p.Id_Categoria,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Es_Repuesto,
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria
    FROM Producto p
    INNER JOIN CategoriaProducto c 
        ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1
    ORDER BY p.Nombre_Producto ASC;
END;
GO


-- =============================================
-- 2. SP: Obtener Categorías
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerCategorias
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Categoria,
        Nombre_Categoria
    FROM CategoriaProducto
    WHERE Activo = 1
    ORDER BY Nombre_Categoria ASC;
END;
GO


-- =============================================
-- 3. SP: Buscar Productos
--    Busca solamente por nombre
-- =============================================
CREATE OR ALTER PROCEDURE sp_BuscarProductos
    @Filtro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id_Producto,
        p.Id_Categoria,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Es_Repuesto,
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria
    FROM Producto p
    INNER JOIN CategoriaProducto c 
        ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1
      AND p.Nombre_Producto LIKE '%' + @Filtro + '%'
    ORDER BY p.Nombre_Producto ASC;
END;
GO


-- =============================================
-- 4. SP: Insertar Producto
-- =============================================
CREATE OR ALTER PROCEDURE sp_InsertarProducto
    @Id_Categoria INT,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT = 0,
    @Stock_Minimo INT = 2,
    @Es_Repuesto BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que no exista otro producto activo
    -- con el mismo nombre
    IF EXISTS (
        SELECT 1
        FROM Producto
        WHERE Nombre_Producto = @Nombre_Producto
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe un producto activo con ese nombre.', 1;
    END;

    INSERT INTO Producto (
        Id_Categoria,
        Nombre_Producto,
        Descripcion,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @Id_Categoria,
        @Nombre_Producto,
        @Descripcion,
        @Precio_Venta,
        @Stock_Actual,
        @Stock_Minimo,
        @Es_Repuesto,
        1
    );
END;
GO


-- =============================================
-- 5. SP: Modificar Producto
-- =============================================
CREATE OR ALTER PROCEDURE sp_ModificarProducto
    @Id_Producto INT,
    @Id_Categoria INT,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT,
    @Stock_Minimo INT,
    @Es_Repuesto BIT,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que no exista otro producto
    -- activo con el mismo nombre
    IF EXISTS (
        SELECT 1
        FROM Producto
        WHERE Nombre_Producto = @Nombre_Producto
          AND Id_Producto <> @Id_Producto
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe otro producto activo con ese nombre.', 1;
    END;

    UPDATE Producto
    SET 
        Id_Categoria = @Id_Categoria,
        Nombre_Producto = @Nombre_Producto,
        Descripcion = @Descripcion,
        Precio_Venta = @Precio_Venta,
        Stock_Actual = @Stock_Actual,
        Stock_Minimo = @Stock_Minimo,
        Es_Repuesto = @Es_Repuesto,
        Activo = @Activo
    WHERE Id_Producto = @Id_Producto;
END;
GO


-- =============================================
-- 6. SP: Inactivar Producto
--    Baja lógica
-- =============================================
CREATE OR ALTER PROCEDURE sp_InactivarProducto
    @Id_Producto INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Producto
    SET Activo = 0
    WHERE Id_Producto = @Id_Producto;
END;
GO


-- =============================================
-- 7. SP: Obtener Proveedores de un Producto
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProveedoresProducto
    @Id_Producto INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        pp.Id_ProductoProveedor,
        pp.Id_Producto,
        pp.Id_Proveedor,
        p.Razon_Social,
        p.CUIT,
        pp.Activo
    FROM ProductoProveedor pp
    INNER JOIN Proveedor p
        ON pp.Id_Proveedor = p.Id_Proveedor
    WHERE pp.Id_Producto = @Id_Producto
      AND pp.Activo = 1
      AND p.Activo = 1
    ORDER BY p.Razon_Social ASC;
END;
GO


-- =============================================
-- 8. SP: Obtener Proveedores Activos
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProveedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Proveedor,
        Razon_Social,
        CUIT
    FROM Proveedor
    WHERE Activo = 1
    ORDER BY Razon_Social ASC;
END;
GO


-- =============================================
-- 9. SP: Asociar Producto con Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_AsignarProveedorProducto
    @Id_Producto INT,
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar que el producto exista
    IF NOT EXISTS (
        SELECT 1
        FROM Producto
        WHERE Id_Producto = @Id_Producto
    )
    BEGIN
        THROW 50000, 'El producto no existe.', 1;
    END;

    -- Verificar que el proveedor exista
    IF NOT EXISTS (
        SELECT 1
        FROM Proveedor
        WHERE Id_Proveedor = @Id_Proveedor
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'El proveedor no existe o está inactivo.', 1;
    END;

    -- Si ya existe la relación pero estaba inactiva,
    -- se vuelve a activar.
    IF EXISTS (
        SELECT 1
        FROM ProductoProveedor
        WHERE Id_Producto = @Id_Producto
          AND Id_Proveedor = @Id_Proveedor
    )
    BEGIN
        UPDATE ProductoProveedor
        SET Activo = 1
        WHERE Id_Producto = @Id_Producto
          AND Id_Proveedor = @Id_Proveedor;

        RETURN;
    END;

    INSERT INTO ProductoProveedor (
        Id_Producto,
        Id_Proveedor,
        Activo
    )
    VALUES (
        @Id_Producto,
        @Id_Proveedor,
        1
    );
END;
GO


-- =============================================
-- 10. SP: Desasociar Producto de Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_DesasignarProveedorProducto
    @Id_Producto INT,
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductoProveedor
    SET Activo = 0
    WHERE Id_Producto = @Id_Producto
      AND Id_Proveedor = @Id_Proveedor;
END;
GO