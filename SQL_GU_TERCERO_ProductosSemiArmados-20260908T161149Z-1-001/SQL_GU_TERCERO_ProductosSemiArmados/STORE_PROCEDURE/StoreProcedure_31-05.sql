-----------------------------------------------------
-- PROYECTO: GU_Tercero
-- MODULO: STORED PROCEDURES
-- MOTOR: SQL SERVER
-- AUTOR: Esteban, Luciano, Micaias, Franco, Leandro
-----------------------------------------------------
USE GU_Tercero;
GO

-------------------
-- CONFIGURACION --
-------------------

CREATE OR ALTER PROCEDURE sp_ObtenerConfiguracion
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        Id_Configuracion,
        Nombre_Empresa,
        Email_Emisor,
        Min_Caracteres,
        Requiere_Mayusculas,
        Requiere_Numeros,
        Requiere_Especial,
        Habilitar_2fa,
        Validar_DatosPersonales,
        No_repetirPasswords,
        Cantidad_HistorialPasswords,
        Cantidad_Preguntas
    FROM ConfiguracionSistema;
END;
GO

CREATE OR ALTER PROCEDURE sp_GuardarConfiguracion
(
    @Id_Configuracion INT,
    @Nombre_Empresa VARCHAR(100),
    @Email_Emisor VARCHAR(150),
    @Min_Caracteres INT,
    @Requiere_Mayusculas BIT,
    @Requiere_Numeros BIT,
    @Requiere_Especial BIT,
    @Habilitar_2fa BIT,
    @Validar_DatosPersonales BIT,
    @No_repetirPasswords BIT,
    @Cantidad_HistorialPasswords INT,
    @Cantidad_Preguntas INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE ConfiguracionSistema
        SET
            Nombre_Empresa = @Nombre_Empresa,
            Email_Emisor = @Email_Emisor,
            Min_Caracteres = @Min_Caracteres,
            Requiere_Mayusculas = @Requiere_Mayusculas,
            Requiere_Numeros = @Requiere_Numeros,
            Requiere_Especial = @Requiere_Especial,
            Habilitar_2fa = @Habilitar_2fa,
            Validar_DatosPersonales = @Validar_DatosPersonales,
            No_repetirPasswords = @No_repetirPasswords,
            Cantidad_HistorialPasswords = @Cantidad_HistorialPasswords,
            Cantidad_Preguntas = @Cantidad_Preguntas
        WHERE Id_Configuracion = @Id_Configuracion;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

--------------
-- USUARIOS --
--------------

CREATE OR ALTER PROCEDURE sp_ObtenerUsuarios
AS
BEGIN 
    SET NOCOUNT ON;

    SELECT
        U.Id_Usuario,
        P.Apellido,
        P.Nombre,
        P.DNI,
        C.Direccion_Correo,
        U.Nombre_Usuario,
        R.Nombre_Rol,
        R.Id_Rol,
        U.Intentos_Fallidos,
        U.Bloqueado,
        U.Activo,
        U.Fecha_Alta,
        U.Ultimo_Login
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    LEFT JOIN Correo C
        ON P.Id_Persona = C.Id_Persona AND C.Activo = 1
    LEFT JOIN UsuarioRol UR
        ON U.Id_Usuario = UR.Id_Usuario
    LEFT JOIN Rol R
        ON UR.Id_Rol = R.Id_Rol
    ORDER BY P.Apellido, P.Nombre;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarUsuario
(
    @Apellido VARCHAR(100),
    @Nombre VARCHAR(100),
    @DNI VARCHAR(20),
    @Direccion_Correo VARCHAR(150),
    @NombreUsuario VARCHAR(50),
    @PasswordHash VARCHAR(255),
    @IdRol INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        DECLARE @IdPersona INT;
        DECLARE @IdUsuario INT;
        DECLARE @IdTipoCorreo INT;

        -- 1. Insertar Persona
        INSERT INTO Persona (Apellido, Nombre, DNI, Fecha_Alta, Activo)
        VALUES (@Apellido, @Nombre, @DNI, GETDATE(), 1);

        SET @IdPersona = SCOPE_IDENTITY();

        -- 2. Insertar Correo
        SELECT TOP 1 @IdTipoCorreo = Id_TipoCorreo FROM TipoCorreo WHERE Activo = 1;

        INSERT INTO Correo (Id_Persona, Id_TipoCorreo, Direccion_Correo, Verificado, Activo)
        VALUES (@IdPersona, ISNULL(@IdTipoCorreo, 1), @Direccion_Correo, 0, 1);

        -- 3. Insertar Usuario
        INSERT INTO Usuario (
            Id_Persona,
            Nombre_Usuario,
            PasswordHash,
            Fecha_Ultimo_Cambio,
            Debe_Cambiar_Password,
            Es_Primer_Ingreso,
            Fecha_Alta,
            Intentos_Fallidos,
            Bloqueado,
            Activo
        )
        VALUES (
            @IdPersona,
            @NombreUsuario,
            @PasswordHash,
            GETDATE(),
            1,
            1,
            GETDATE(),
            0,
            0,
            1
        );

        SET @IdUsuario = SCOPE_IDENTITY();

        -- 4. Asignar Rol
        INSERT INTO UsuarioRol (Id_Usuario, Id_Rol, Fecha_Asignacion)
        VALUES (@IdUsuario, @IdRol, GETDATE());

        COMMIT TRANSACTION;

        SELECT @IdUsuario AS Id_Usuario;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE sp_ModificarUsuario
(
    @IdUsuario INT,
    @Apellido VARCHAR(100),
    @Nombre VARCHAR(100),
    @DNI VARCHAR(20),
    @Correo VARCHAR(150),
    @NombreUsuario VARCHAR(50),
    @IdRol INT,
    @Activo BIT,
    @Bloqueado BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        DECLARE @IdPersona INT;

        SELECT @IdPersona = Id_Persona
        FROM Usuario
        WHERE Id_Usuario = @IdUsuario;

        -- Actualizar Persona
        UPDATE Persona
        SET
            Apellido = @Apellido,
            Nombre = @Nombre,
            DNI = @DNI
        WHERE Id_Persona = @IdPersona;

        -- Actualizar Correo
        UPDATE Correo
        SET Direccion_Correo = @Correo
        WHERE Id_Persona = @IdPersona AND Activo = 1;

        -- Actualizar Usuario
        UPDATE Usuario
        SET
            Nombre_Usuario = @NombreUsuario,
            Activo = @Activo,
            Bloqueado = @Bloqueado
        WHERE Id_Usuario = @IdUsuario;

        -- Actualizar Rol
        UPDATE UsuarioRol
        SET Id_Rol = @IdRol
        WHERE Id_Usuario = @IdUsuario;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE sp_DesactivarUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET Activo = 0, Fecha_Baja = GETDATE()
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ActivarUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET Activo = 1, Fecha_Baja = NULL
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerPersonaUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        P.Nombre,
        P.Apellido,
        P.DNI,
        P.Fecha_Nacimiento
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    WHERE U.Id_Usuario = @IdUsuario;
END;
GO

-----------
-- LOGIN --
-----------

CREATE OR ALTER PROCEDURE sp_LoginUsuario
    @NombreUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.Id_Usuario,
        U.Nombre_Usuario,
        U.PasswordHash,
        U.Activo,
        U.Bloqueado,
        U.Intentos_Fallidos,
        U.Debe_Cambiar_Password,
        U.Es_Primer_Ingreso,
        R.Id_Rol,
        R.Nombre_Rol
    FROM Usuario U
    INNER JOIN UsuarioRol UR
        ON U.Id_Usuario = UR.Id_Usuario
    INNER JOIN Rol R
        ON UR.Id_Rol = R.Id_Rol
    WHERE U.Nombre_Usuario = @NombreUsuario;
END;
GO

------------------
-- LOGIN SEGURO --
------------------

CREATE OR ALTER PROCEDURE sp_AumentarIntentos
    @IdUsuario INT 
AS
BEGIN 
    SET NOCOUNT ON;

    UPDATE Usuario
    SET Intentos_Fallidos = Intentos_Fallidos + 1
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ReiniciarIntentos
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;

    UPDATE Usuario 
    SET Intentos_Fallidos = 0
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_BloquearUsuario
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;

    UPDATE Usuario
    SET 
        Bloqueado = 1,
        Fecha_Bloqueo = GETDATE(),
        Intentos_Fallidos = 3
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarUltimoLogin
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;

    UPDATE Usuario
    SET Ultimo_Login = GETDATE()
    WHERE Id_Usuario = @IdUsuario;
END;
GO

------------------------
-- SEGURIDAD PASSWORD --
------------------------

CREATE OR ALTER PROCEDURE sp_CambiarPassword
    @IdUsuario INT,
    @PasswordHash VARCHAR(255)
AS 
BEGIN
    SET NOCOUNT ON; 

    UPDATE Usuario
    SET 
        PasswordHash = @PasswordHash,
        Fecha_Ultimo_Cambio = GETDATE(),
        Es_Primer_Ingreso = 0,
        Debe_Cambiar_Password = 0
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_RegistrarHistorialPassword
    @IdUsuario INT,
    @PasswordHash VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HistorialPassword (Id_Usuario, PasswordHash, Fecha_Cambio)
    VALUES (@IdUsuario, @PasswordHash, GETDATE());
END;
GO

CREATE OR ALTER PROCEDURE sp_ExistePasswordHistorial
    @IdUsuario INT,
    @PasswordHash VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 1
    FROM HistorialPassword
    WHERE Id_Usuario = @IdUsuario
      AND PasswordHash = @PasswordHash;
END;
GO

CREATE OR ALTER PROCEDURE sp_DesbloquearUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET 
        Bloqueado = 0,
        Intentos_Fallidos = 0,
        Fecha_Bloqueo = NULL
    WHERE Id_Usuario = @IdUsuario;
END;
GO

----------------------
-- ROLES Y PERMISOS --
----------------------

CREATE OR ALTER PROCEDURE sp_AsignarRolUsuario
    @IdUsuario INT,
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO UsuarioRol (Id_Usuario, Id_Rol, Fecha_Asignacion)
    VALUES (@IdUsuario, @IdRol, GETDATE());
END;
GO

CREATE OR ALTER PROCEDURE sp_AsignarPermisoRol
    @IdRol INT,
    @IdPermiso INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO RolPermiso (Id_Rol, Id_Permiso)
    VALUES (@IdRol, @IdPermiso);
END;
GO

------------------------
-- HISTORIAL USUARIO --
------------------------

CREATE OR ALTER PROCEDURE sp_RegistrarHistorialUsuario
    @IdUsuario INT,
    @TipoMovimiento VARCHAR(50),
    @Motivo VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HistorialUsuario (Id_Usuario, Tipo_Movimiento, Fecha_Movimiento, Motivo)
    VALUES (@IdUsuario, @TipoMovimiento, GETDATE(), @Motivo);
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerHistorialUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Tipo_Movimiento,
        Fecha_Movimiento,
        Motivo
    FROM HistorialUsuario
    WHERE Id_Usuario = @IdUsuario
    ORDER BY Fecha_Movimiento DESC;
END;
GO

--------------------------------
-- RECUPERACION DE CONTRASEÑA --
--------------------------------

CREATE OR ALTER PROCEDURE sp_ValidarPreguntaSeguridad
    @NombreUsuario VARCHAR(50),
    @IdPregunta INT,
    @RespuestaHash VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UPS.Id_UsuarioPregunta
    FROM UsuarioPreguntaSeguridad UPS
    INNER JOIN Usuario U
        ON UPS.Id_Usuario = U.Id_Usuario
    WHERE U.Nombre_Usuario = @NombreUsuario
      AND UPS.Id_Pregunta = @IdPregunta
      AND UPS.RespuestaHash = @RespuestaHash;
END;
GO

CREATE OR ALTER PROCEDURE sp_GenerarCodigo2FA
    @IdUsuario INT,
    @Codigo VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Codigo2FA (Id_Usuario, Codigo, Fecha_Expiracion, Usado)
    VALUES (@IdUsuario, @Codigo, DATEADD(MINUTE, 10, GETDATE()), 0);
END;
GO

CREATE OR ALTER PROCEDURE sp_ValidarCodigo2FA
    @IdUsuario INT,
    @Codigo VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id_Codigo2FA
    FROM Codigo2FA
    WHERE Id_Usuario = @IdUsuario
      AND Codigo = @Codigo
      AND Fecha_Expiracion >= GETDATE()
      AND Usado = 0;
END;
GO

CREATE OR ALTER PROCEDURE sp_ReestablecerPassword
    @NombreUsuario VARCHAR(50),
    @PasswordHash VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET
        PasswordHash = @PasswordHash,
        Fecha_Ultimo_Cambio = GETDATE(),
        Debe_Cambiar_Password = 1,
        Intentos_Fallidos = 0,
        Bloqueado = 0
    WHERE Nombre_Usuario = @NombreUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ExpirarCodigo2FA
    @IdCodigo2FA INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Codigo2FA
    SET Usado = 1
    WHERE Id_Codigo2FA = @IdCodigo2FA;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerPreguntasUsuario
    @NombreUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        PS.Id_Pregunta,
        PS.Pregunta
    FROM Usuario U
    INNER JOIN UsuarioPreguntaSeguridad UPS
        ON U.Id_Usuario = UPS.Id_Usuario
    INNER JOIN PreguntasSeguridad PS
        ON UPS.Id_Pregunta = PS.Id_Pregunta
    WHERE U.Nombre_Usuario = @NombreUsuario
    ORDER BY PS.Id_Pregunta;
END;
GO

CREATE OR ALTER PROCEDURE sp_UsuarioTienePreguntas
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Cantidad
    FROM UsuarioPreguntaSeguridad
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerCorreoUsuario
    @NombreUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT C.Direccion_Correo
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    INNER JOIN Correo C
        ON P.Id_Persona = C.Id_Persona
    WHERE U.Nombre_Usuario = @NombreUsuario
      AND C.Activo = 1;
END;
GO

--------------------------
-- CONSULTAS Y REPORTES --
--------------------------

CREATE OR ALTER PROCEDURE sp_ObtenerUsuariosBloqueados
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.Id_Usuario,
        P.Apellido,
        P.Nombre,
        U.Nombre_Usuario,
        U.Intentos_Fallidos,
        U.Fecha_Bloqueo
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    WHERE U.Bloqueado = 1;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUsuariosActivos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.Id_Usuario,
        P.Apellido,
        P.Nombre,
        U.Nombre_Usuario,
        U.Fecha_Alta
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    WHERE U.Activo = 1;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUsuariosPorRol
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.Id_Usuario,
        P.Apellido,
        P.Nombre,
        U.Nombre_Usuario,
        R.Nombre_Rol
    FROM Usuario U
    INNER JOIN Persona P
        ON U.Id_Persona = P.Id_Persona
    INNER JOIN UsuarioRol UR
        ON U.Id_Usuario = UR.Id_Usuario
    INNER JOIN Rol R
        ON UR.Id_Rol = R.Id_Rol
    WHERE R.Id_Rol = @IdRol;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUltimosLogins
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.Nombre_Usuario,
        U.Ultimo_Login
    FROM Usuario U
    WHERE U.Ultimo_Login IS NOT NULL
    ORDER BY U.Ultimo_Login DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerCantidadUsuarios
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Cantidad_Usuarios
    FROM Usuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerPreguntasSeguridad
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Pregunta,
        Pregunta,
        Activo
    FROM PreguntasSeguridad
    WHERE Activo = 1;
END;
GO

CREATE OR ALTER PROCEDURE sp_GuardarPreguntaSeguridad
    @IdUsuario INT,
    @IdPregunta INT,
    @RespuestaHash VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM UsuarioPreguntaSeguridad
        WHERE Id_Usuario = @IdUsuario
          AND Id_Pregunta = @IdPregunta
    )
    BEGIN
        UPDATE UsuarioPreguntaSeguridad
        SET RespuestaHash = @RespuestaHash
        WHERE Id_Usuario = @IdUsuario
          AND Id_Pregunta = @IdPregunta;
    END
    ELSE
    BEGIN
        INSERT INTO UsuarioPreguntaSeguridad (Id_Usuario, Id_Pregunta, RespuestaHash)
        VALUES (@IdUsuario, @IdPregunta, @RespuestaHash);
    END
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerRoles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Rol,
        Nombre_Rol
    FROM Rol
    WHERE Activo = 1
    ORDER BY Nombre_Rol;
END;
GO