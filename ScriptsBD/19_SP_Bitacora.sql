USE GU_Tercero;
GO

-- ============================================================
-- MODULO: BITÁCORA (CU19)
-- Tabla independiente del resto (sin claves foráneas): cada registro es una
-- "foto" del momento con quién hizo la operación (usuario, apellido y nombre,
-- rol), qué hizo, cuándo, su criticidad y, cuando corresponde, el estado
-- anterior y el posterior en formato JSON.
-- No se puede modificar ni borrar. Se consulta desde el formulario Bitácora,
-- que solo ven los usuarios con el permiso VER_BITACORA.
-- ============================================================

-- Primera versión de prueba de la tabla (con Id_Usuario): se reemplaza.
IF OBJECT_ID('Bitacora', 'U') IS NOT NULL AND COL_LENGTH('Bitacora', 'Apellido_Nombre') IS NULL
    DROP TABLE Bitacora;
GO

IF OBJECT_ID('Bitacora', 'U') IS NULL
BEGIN
    CREATE TABLE Bitacora (
        Id_Bitacora INT IDENTITY(1,1) PRIMARY KEY,
        Fecha_Hora DATETIME DEFAULT GETDATE() NOT NULL,
        Usuario NVARCHAR(50) NOT NULL,
        Apellido_Nombre NVARCHAR(110) NULL,
        Rol NVARCHAR(30) NULL,
        Modulo NVARCHAR(50) NOT NULL,
        Operacion NVARCHAR(300) NOT NULL,
        Criticidad NVARCHAR(15) NOT NULL,
        Estado_Anterior NVARCHAR(MAX) NULL,
        Estado_Posterior NVARCHAR(MAX) NULL,
        CONSTRAINT CK_Bitacora_Criticidad CHECK (Criticidad IN (N'Crítica', N'Advertencia', N'Informativa')),
        CONSTRAINT CK_Bitacora_EstadoAnterior CHECK (Estado_Anterior IS NULL OR ISJSON(Estado_Anterior) = 1),
        CONSTRAINT CK_Bitacora_EstadoPosterior CHECK (Estado_Posterior IS NULL OR ISJSON(Estado_Posterior) = 1)
    );

    CREATE INDEX IX_Bitacora_Fecha ON Bitacora (Fecha_Hora);
END
GO

-- ------------------------------------------------------------
-- 1. Trigger: la bitácora no se puede modificar ni borrar
-- ------------------------------------------------------------
CREATE OR ALTER TRIGGER TR_Bitacora_NoModificar
ON Bitacora
INSTEAD OF UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    RAISERROR(N'La bitácora no se puede modificar ni borrar.', 16, 1);
END
GO

-- ------------------------------------------------------------
-- 2. SP: Registrar una operación
--    Si no se pasan el apellido y nombre o el rol, se toman del usuario
--    en ese momento (quedan guardados como texto, no como referencia).
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_RegistrarBitacora
    @Usuario NVARCHAR(50),
    @Apellido_Nombre NVARCHAR(110) = NULL,
    @Rol NVARCHAR(30) = NULL,
    @Modulo NVARCHAR(50),
    @Operacion NVARCHAR(300),
    @Criticidad NVARCHAR(15),
    @Estado_Anterior NVARCHAR(MAX) = NULL,
    @Estado_Posterior NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Apellido_Nombre IS NULL OR @Rol IS NULL
    BEGIN
        SELECT TOP 1
            @Apellido_Nombre = ISNULL(@Apellido_Nombre, P.Apellido + ', ' + P.Nombre),
            @Rol = ISNULL(@Rol, R.Nombre_Rol)
        FROM Usuario U
        INNER JOIN Persona P ON P.Id_Persona = U.Id_Persona
        LEFT JOIN UsuarioRol UR ON UR.Id_Usuario = U.Id_Usuario
        LEFT JOIN Rol R ON R.Id_Rol = UR.Id_Rol
        WHERE U.Nombre_Usuario = @Usuario;
    END

    INSERT INTO Bitacora (Usuario, Apellido_Nombre, Rol, Modulo, Operacion, Criticidad, Estado_Anterior, Estado_Posterior)
    VALUES (LEFT(@Usuario, 50), @Apellido_Nombre, @Rol, @Modulo, LEFT(@Operacion, 300), @Criticidad,
            NULLIF(@Estado_Anterior, ''), NULLIF(@Estado_Posterior, ''));
END
GO

-- ------------------------------------------------------------
-- 3. SP: Consultar la bitácora con filtros (los NULL no filtran)
--    @Hasta incluye todo ese día.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ListarBitacora
    @Desde DATE,
    @Hasta DATE,
    @Criticidad NVARCHAR(15) = NULL,
    @Modulo NVARCHAR(50) = NULL,
    @Texto NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Bitacora,
        Fecha_Hora,
        Usuario,
        Apellido_Nombre,
        Rol,
        Modulo,
        Operacion,
        Criticidad,
        Estado_Anterior,
        Estado_Posterior
    FROM Bitacora
    WHERE Fecha_Hora >= @Desde
      AND Fecha_Hora < DATEADD(DAY, 1, @Hasta)
      AND (@Criticidad IS NULL OR Criticidad = @Criticidad)
      AND (@Modulo IS NULL OR Modulo = @Modulo)
      AND (@Texto IS NULL
           OR Usuario LIKE '%' + @Texto + '%'
           OR Apellido_Nombre LIKE '%' + @Texto + '%'
           OR Operacion LIKE '%' + @Texto + '%')
    ORDER BY Fecha_Hora DESC, Id_Bitacora DESC;
END
GO

-- ------------------------------------------------------------
-- 4. Permiso especial para ver la bitácora (asignado al rol Administrador)
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM Permisos WHERE Codigo = 'VER_BITACORA')
    INSERT INTO Permisos (Codigo, Descripcion, Modulo, Activo)
    VALUES ('VER_BITACORA', N'Consultar la bitácora del sistema', N'Bitácora', 1);
GO

INSERT INTO RolPermiso (Id_Rol, Id_Permiso, Activo)
SELECT R.Id_Rol, P.Id_Permiso, 1
FROM Rol R
CROSS JOIN Permisos P
WHERE R.Nombre_Rol = 'Administrador'
  AND P.Codigo = 'VER_BITACORA'
  AND NOT EXISTS (SELECT 1 FROM RolPermiso RP WHERE RP.Id_Rol = R.Id_Rol AND RP.Id_Permiso = P.Id_Permiso);
GO

-- ------------------------------------------------------------
-- 5. SP: ¿El usuario tiene el permiso?
--    Un permiso propio del usuario (UsuarioPermiso) manda sobre el de su rol.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_UsuarioTienePermiso
    @Id_Usuario INT,
    @Codigo NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id_Permiso INT = (SELECT Id_Permiso FROM Permisos WHERE Codigo = @Codigo AND Activo = 1);
    DECLARE @Concedido BIT = (SELECT Concedido FROM UsuarioPermiso WHERE Id_Usuario = @Id_Usuario AND Id_Permiso = @Id_Permiso);

    IF @Id_Permiso IS NULL
        SELECT CAST(0 AS BIT) AS Tiene;
    ELSE IF @Concedido IS NOT NULL
        SELECT @Concedido AS Tiene;
    ELSE IF EXISTS (SELECT 1 FROM UsuarioRol UR
                    INNER JOIN RolPermiso RP ON RP.Id_Rol = UR.Id_Rol AND RP.Activo = 1
                    WHERE UR.Id_Usuario = @Id_Usuario AND RP.Id_Permiso = @Id_Permiso)
        SELECT CAST(1 AS BIT) AS Tiene;
    ELSE
        SELECT CAST(0 AS BIT) AS Tiene;
END
GO
