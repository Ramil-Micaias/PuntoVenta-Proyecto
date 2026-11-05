USE GU_Tercero;
GO

CREATE OR ALTER FUNCTION dbo.fn_ProveedorProducto(@Id_Producto INT)
RETURNS NVARCHAR(130)
AS
BEGIN
    DECLARE @IdProveedor INT = (
        SELECT TOP 1 Id_Proveedor
        FROM ProductoProveedor
        WHERE Id_Producto = @Id_Producto
          AND Activo = 1
        ORDER BY Id_ProductoProveedor DESC
    );

    IF @IdProveedor IS NULL
        SET @IdProveedor = (
            SELECT TOP 1 c.Id_Proveedor
            FROM DetalleCompra d
            INNER JOIN Compra c ON c.Id_Compra = d.Id_Compra
            WHERE d.Id_Producto = @Id_Producto
            ORDER BY c.Fecha_Compra DESC, c.Id_Compra DESC
        );

    IF @IdProveedor IS NULL
        RETURN 'Sin proveedor';

    RETURN (
        SELECT Razon_Social + CASE WHEN Activo = 0 THEN ' (dado de baja)' ELSE '' END
        FROM Proveedor
        WHERE Id_Proveedor = @IdProveedor
    );
END
GO

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
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria,
        dbo.fn_ProveedorProducto(p.Id_Producto) AS Proveedor,
        (SELECT TOP 1 pp.Id_Proveedor
         FROM ProductoProveedor pp
         WHERE pp.Id_Producto = p.Id_Producto AND pp.Activo = 1
         ORDER BY pp.Id_ProductoProveedor DESC) AS Id_Proveedor
    FROM Producto p
    INNER JOIN CategoriaProducto c
        ON p.Id_Categoria = c.Id_Categoria
    ORDER BY p.Activo DESC, p.Nombre_Producto ASC;
END;
GO

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
        p.Activo,
        c.Nombre_Categoria AS NombreCategoria,
        dbo.fn_ProveedorProducto(p.Id_Producto) AS Proveedor,
        (SELECT TOP 1 pp.Id_Proveedor
         FROM ProductoProveedor pp
         WHERE pp.Id_Producto = p.Id_Producto AND pp.Activo = 1
         ORDER BY pp.Id_ProductoProveedor DESC) AS Id_Proveedor
    FROM Producto p
    INNER JOIN CategoriaProducto c
        ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Nombre_Producto LIKE '%' + @Filtro + '%'
       OR c.Nombre_Categoria LIKE '%' + @Filtro + '%'
    ORDER BY p.Activo DESC, p.Nombre_Producto ASC;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarProducto
    @Id_Categoria INT,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT = 0,
    @Stock_Minimo INT = 2,
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Producto
        WHERE Nombre_Producto = @Nombre_Producto
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe un producto activo con ese nombre.', 1;
    END;

    IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE Id_Proveedor = @Id_Proveedor AND Activo = 1)
    BEGIN
        THROW 50000, 'Debe elegir un proveedor activo para el producto.', 1;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Producto (
            Id_Categoria,
            Nombre_Producto,
            Descripcion,
            Precio_Venta,
            Stock_Actual,
            Stock_Minimo,
            Activo
        )
        VALUES (
            @Id_Categoria,
            @Nombre_Producto,
            @Descripcion,
            @Precio_Venta,
            @Stock_Actual,
            @Stock_Minimo,
            1
        );

        DECLARE @Id_Producto INT = SCOPE_IDENTITY();

        UPDATE ProductoProveedor
        SET Activo = 0
        WHERE Id_Producto = @Id_Producto
          AND Id_Proveedor <> @Id_Proveedor;

        IF EXISTS (SELECT 1 FROM ProductoProveedor WHERE Id_Producto = @Id_Producto AND Id_Proveedor = @Id_Proveedor)
            UPDATE ProductoProveedor
            SET Activo = 1
            WHERE Id_Producto = @Id_Producto
              AND Id_Proveedor = @Id_Proveedor;
        ELSE
            INSERT INTO ProductoProveedor (Id_Producto, Id_Proveedor, Activo)
            VALUES (@Id_Producto, @Id_Proveedor, 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_ModificarProducto
    @Id_Producto INT,
    @Id_Categoria INT,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT,
    @Stock_Minimo INT,
    @Activo BIT = 1,
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

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

    IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE Id_Proveedor = @Id_Proveedor AND Activo = 1)
    BEGIN
        THROW 50000, 'Debe elegir un proveedor activo para el producto.', 1;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Producto
        SET
            Id_Categoria = @Id_Categoria,
            Nombre_Producto = @Nombre_Producto,
            Descripcion = @Descripcion,
            Precio_Venta = @Precio_Venta,
            Stock_Actual = @Stock_Actual,
            Stock_Minimo = @Stock_Minimo,
            Activo = @Activo
        WHERE Id_Producto = @Id_Producto;

        UPDATE ProductoProveedor
        SET Activo = 0
        WHERE Id_Producto = @Id_Producto
          AND Id_Proveedor <> @Id_Proveedor;

        IF EXISTS (SELECT 1 FROM ProductoProveedor WHERE Id_Producto = @Id_Producto AND Id_Proveedor = @Id_Proveedor)
            UPDATE ProductoProveedor
            SET Activo = 1
            WHERE Id_Producto = @Id_Producto
              AND Id_Proveedor = @Id_Proveedor;
        ELSE
            INSERT INTO ProductoProveedor (Id_Producto, Id_Proveedor, Activo)
            VALUES (@Id_Producto, @Id_Proveedor, 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

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

CREATE OR ALTER PROCEDURE sp_ReactivarProducto
    @Id_Producto INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Producto P
        INNER JOIN Producto Otro
            ON Otro.Nombre_Producto = P.Nombre_Producto
           AND Otro.Id_Producto <> P.Id_Producto
           AND Otro.Activo = 1
        WHERE P.Id_Producto = @Id_Producto
    )
    BEGIN
        THROW 50000, 'Ya existe otro producto activo con ese nombre.', 1;
    END;

    UPDATE Producto
    SET Activo = 1
    WHERE Id_Producto = @Id_Producto;
END;
GO

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

CREATE OR ALTER PROCEDURE sp_AsignarProveedorProducto
    @Id_Producto INT,
    @Id_Proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM Producto
        WHERE Id_Producto = @Id_Producto
    )
    BEGIN
        THROW 50000, 'El producto no existe.', 1;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM Proveedor
        WHERE Id_Proveedor = @Id_Proveedor
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'El proveedor no existe o está inactivo.', 1;
    END;

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

CREATE OR ALTER PROCEDURE sp_InsertarCategoria
    @Nombre_Categoria NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM CategoriaProducto
        WHERE Nombre_Categoria = @Nombre_Categoria
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'Ya existe una categoría con ese nombre.', 1;
    END;

    IF EXISTS (
        SELECT 1
        FROM CategoriaProducto
        WHERE Nombre_Categoria = @Nombre_Categoria
    )
    BEGIN
        UPDATE CategoriaProducto
        SET Activo = 1
        WHERE Nombre_Categoria = @Nombre_Categoria;

        RETURN;
    END;

    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES (@Nombre_Categoria, 1);
END;
GO

CREATE OR ALTER PROCEDURE sp_ModificarCategoria
    @Id_Categoria INT,
    @Nombre_Categoria NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM CategoriaProducto
        WHERE Nombre_Categoria = @Nombre_Categoria
          AND Id_Categoria <> @Id_Categoria
    )
    BEGIN
        THROW 50000, 'Ya existe otra categoría con ese nombre.', 1;
    END;

    UPDATE CategoriaProducto
    SET Nombre_Categoria = @Nombre_Categoria
    WHERE Id_Categoria = @Id_Categoria;
END;
GO

CREATE OR ALTER PROCEDURE sp_InactivarCategoria
    @Id_Categoria INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Producto
        WHERE Id_Categoria = @Id_Categoria
          AND Activo = 1
    )
    BEGIN
        THROW 50000, 'No se puede dar de baja la categoría porque tiene productos activos.', 1;
    END;

    UPDATE CategoriaProducto
    SET Activo = 0
    WHERE Id_Categoria = @Id_Categoria;
END;
GO
