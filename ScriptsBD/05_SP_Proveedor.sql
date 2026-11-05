USE GU_Tercero;
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

DECLARE @RestriccionCuit SYSNAME = (
    SELECT TOP 1 kc.name
    FROM sys.key_constraints kc
    INNER JOIN sys.index_columns ic ON ic.object_id = kc.parent_object_id AND ic.index_id = kc.unique_index_id
    INNER JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
    WHERE kc.parent_object_id = OBJECT_ID('Proveedor') AND kc.type = 'UQ' AND c.name = 'CUIT'
);
IF @RestriccionCuit IS NOT NULL
    EXEC('ALTER TABLE Proveedor DROP CONSTRAINT ' + @RestriccionCuit);

GO

CREATE OR ALTER PROCEDURE sp_InsertarProveedor
    @Razon_Social NVARCHAR(100),
    @CUIT NVARCHAR(20) = NULL,
    @Telefono NVARCHAR(30) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Direccion NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @CUIT IS NOT NULL AND LTRIM(RTRIM(@CUIT)) = ''
        SET @CUIT = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM Proveedor WITH (UPDLOCK, HOLDLOCK)
                   WHERE Razon_Social = @Razon_Social AND Activo = 1)
        BEGIN
            RAISERROR('Ya existe un proveedor activo con esa Razón Social.', 16, 1);
        END

        IF @CUIT IS NOT NULL
           AND EXISTS (SELECT 1 FROM Proveedor WITH (UPDLOCK, HOLDLOCK)
                       WHERE CUIT = @CUIT AND Activo = 1)
        BEGIN
            RAISERROR('Ya existe un proveedor activo con ese CUIT.', 16, 1);
        END

        DECLARE @IdDadoDeBaja INT = (
            SELECT TOP 1 Id_Proveedor
            FROM Proveedor
            WHERE Activo = 0
              AND ((@CUIT IS NOT NULL AND CUIT = @CUIT) OR Razon_Social = @Razon_Social)
            ORDER BY CASE WHEN CUIT = @CUIT THEN 0 ELSE 1 END, Id_Proveedor DESC
        );

        IF @IdDadoDeBaja IS NOT NULL
        BEGIN
            IF @CUIT IS NOT NULL
               AND EXISTS (SELECT 1 FROM Proveedor WHERE CUIT = @CUIT AND Id_Proveedor <> @IdDadoDeBaja)
            BEGIN
                RAISERROR('Ya existe otro proveedor dado de baja con ese CUIT.', 16, 1);
            END

            UPDATE Proveedor
            SET Razon_Social = @Razon_Social,
                CUIT = ISNULL(@CUIT, CUIT),
                Telefono = @Telefono,
                Email = @Email,
                Direccion = @Direccion,
                Activo = 1
            WHERE Id_Proveedor = @IdDadoDeBaja;

            COMMIT TRANSACTION;
            SELECT 'REACTIVADO' AS Resultado, @IdDadoDeBaja AS Id_Proveedor;
            RETURN;
        END

        INSERT INTO Proveedor (Razon_Social, CUIT, Telefono, Email, Direccion, Fecha_Alta, Activo)
        VALUES (@Razon_Social, @CUIT, @Telefono, @Email, @Direccion, GETDATE(), 1);

        DECLARE @IdNuevo INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
        SELECT 'NUEVO' AS Resultado, @IdNuevo AS Id_Proveedor;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

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

    IF @CUIT IS NOT NULL AND LTRIM(RTRIM(@CUIT)) <> ''
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM Proveedor
            WHERE CUIT = @CUIT
              AND Id_Proveedor <> @Id_Proveedor
        )
        BEGIN
            THROW 50000, 'Ya existe otro proveedor con ese CUIT (puede estar dado de baja).', 1;
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
