USE GU_Tercero;
GO

-- =============================================
-- 1. SP: Obtener Proveedores Activos
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProveedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Proveedor,
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Fecha_Alta,
        Activo
    FROM Proveedor
    WHERE Activo = 1
    ORDER BY Razon_Social ASC;
END;
GO


-- =============================================
-- 2. SP: Obtener Todos los Proveedores (Incluye inactivos)
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerTodosProveedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Proveedor,
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Fecha_Alta,
        Activo
    FROM Proveedor
    ORDER BY Razon_Social ASC;
END;
GO


-- =============================================
-- 3. SP: Buscar Proveedores
--    Busca por Razón Social o CUIT
-- =============================================
CREATE OR ALTER PROCEDURE sp_BuscarProveedores
    @Filtro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Proveedor,
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Fecha_Alta,
        Activo
    FROM Proveedor
    WHERE Activo = 1
      AND (
          Razon_Social LIKE '%' + @Filtro + '%'
          OR CUIT LIKE '%' + @Filtro + '%'
      )
    ORDER BY Razon_Social ASC;
END;
GO


-- =============================================
-- 4. SP: Obtener Proveedor por Id
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProveedorPorId
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Proveedor,
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Fecha_Alta,
        Activo
    FROM Proveedor
    WHERE Id_Proveedor = @Id_Proveedor;
END;
GO


-- =============================================
-- 5. SP: Insertar Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_InsertarProveedor
    @Razon_Social NVARCHAR(100),
    @CUIT NVARCHAR(20) = NULL,
    @Telefono NVARCHAR(30) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Direccion NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que no exista otro proveedor activo con la misma Razon Social
    IF EXISTS (
        SELECT 1
        FROM Proveedor
        WHERE Razon_Social = @Razon_Social
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe un proveedor activo con esa Razón Social.', 1;
    END;

    -- Validar CUIT duplicado si se ingresó
    IF @CUIT IS NOT NULL AND LTRIM(RTRIM(@CUIT)) <> ''
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM Proveedor
            WHERE CUIT = @CUIT
              AND Activo = 1
        )
        BEGIN
            THROW 50000, 'Ya existe un proveedor activo con ese CUIT.', 1;
        END;
    END;

    INSERT INTO Proveedor (
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Fecha_Alta,
        Activo
    )
    VALUES (
        @Razon_Social,
        @CUIT,
        @Telefono,
        @Email,
        @Direccion,
        GETDATE(),
        1
    );
END;
GO


-- =============================================
-- 6. SP: Modificar Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_ModificarProveedor
    @Id_Proveedor INT,
    @Razon_Social NVARCHAR(100),
    @CUIT NVARCHAR(20) = NULL,
    @Telefono NVARCHAR(30) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Direccion NVARCHAR(150) = NULL,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que no exista otro proveedor activo con la misma Razon Social
    IF EXISTS (
        SELECT 1
        FROM Proveedor
        WHERE Razon_Social = @Razon_Social
          AND Id_Proveedor <> @Id_Proveedor
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe otro proveedor activo con esa Razón Social.', 1;
    END;

    -- Validar CUIT duplicado si se ingresó
    IF @CUIT IS NOT NULL AND LTRIM(RTRIM(@CUIT)) <> ''
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM Proveedor
            WHERE CUIT = @CUIT
              AND Id_Proveedor <> @Id_Proveedor
              AND Activo = 1
        )
        BEGIN
            THROW 50000, 'Ya existe otro proveedor activo con ese CUIT.', 1;
        END;
    END;

    UPDATE Proveedor
    SET 
        Razon_Social = @Razon_Social,
        CUIT = @CUIT,
        Telefono = @Telefono,
        Email = @Email,
        Direccion = @Direccion,
        Activo = @Activo
    WHERE Id_Proveedor = @Id_Proveedor;
END;
GO


-- =============================================
-- 7. SP: Inactivar Proveedor (Baja lógica)
-- =============================================
CREATE OR ALTER PROCEDURE sp_InactivarProveedor
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedor
    SET Activo = 0
    WHERE Id_Proveedor = @Id_Proveedor;
END;
GO


-- =============================================
-- 8. SP: Reactivar Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_ReactivarProveedor
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedor
    SET Activo = 1
    WHERE Id_Proveedor = @Id_Proveedor;
END;
GO


-- =============================================
-- 9. SP: Obtener Productos de un Proveedor
-- =============================================
CREATE OR ALTER PROCEDURE sp_ObtenerProductosPorProveedor
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id_Producto,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Venta,
        p.Stock_Actual,
        c.Nombre_Categoria,
        pp.Activo AS RelacionActiva
    FROM ProductoProveedor pp
    INNER JOIN Producto p 
        ON pp.Id_Producto = p.Id_Producto
    INNER JOIN CategoriaProducto c
        ON p.Id_Categoria = c.Id_Categoria
    WHERE pp.Id_Proveedor = @Id_Proveedor
      AND pp.Activo = 1
      AND p.Activo = 1
    ORDER BY p.Nombre_Producto ASC;
END;
GO
