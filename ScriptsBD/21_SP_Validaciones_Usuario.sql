USE GU_Tercero;
GO

-- trae el hash de la respuesta que guardo el usuario para una pregunta
CREATE OR ALTER PROCEDURE sp_ObtenerHashRespuesta
    @NombreUsuario NVARCHAR(50),
    @IdPregunta INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UPS.RespuestaHash
    FROM UsuarioPreguntaSeguridad UPS
    INNER JOIN Usuario U ON U.Id_Usuario = UPS.Id_Usuario
    WHERE U.Nombre_Usuario = @NombreUsuario
      AND UPS.Id_Pregunta = @IdPregunta;
END
GO

-- 1 si ya hay otro usuario con ese DNI (no cuenta al usuario que se esta modificando)
CREATE OR ALTER PROCEDURE sp_ExisteDniEnOtroUsuario
    @DNI NVARCHAR(20),
    @IdUsuarioExcluido INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
               FROM Usuario U
               INNER JOIN Persona P ON P.Id_Persona = U.Id_Persona
               WHERE P.DNI = @DNI
                 AND U.Id_Usuario <> @IdUsuarioExcluido)
        SELECT CAST(1 AS BIT);
    ELSE
        SELECT CAST(0 AS BIT);
END
GO

-- 1 si el correo ya lo tiene otra persona
-- la persona propia es la del usuario, o si es un alta la que ya tiene ese DNI (por ejemplo un cliente del taller)
CREATE OR ALTER PROCEDURE sp_ExisteCorreoDeOtraPersona
    @Correo NVARCHAR(255),
    @DNI NVARCHAR(20),
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdPersonaPropia INT = COALESCE(
        (SELECT Id_Persona FROM Usuario WHERE Id_Usuario = @IdUsuario),
        (SELECT Id_Persona FROM Persona WHERE DNI = @DNI),
        -1);

    IF EXISTS (SELECT 1
               FROM Correo
               WHERE Direccion_Correo = @Correo
                 AND Id_Persona <> @IdPersonaPropia)
        SELECT CAST(1 AS BIT);
    ELSE
        SELECT CAST(0 AS BIT);
END
GO

-- 1 si el DNI ya es de otra persona distinta a la del usuario
CREATE OR ALTER PROCEDURE sp_ExisteDniDeOtraPersona
    @DNI NVARCHAR(20),
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdPersonaPropia INT = (SELECT Id_Persona FROM Usuario WHERE Id_Usuario = @IdUsuario);

    IF EXISTS (SELECT 1
               FROM Persona
               WHERE DNI = @DNI
                 AND Id_Persona <> @IdPersonaPropia)
        SELECT CAST(1 AS BIT);
    ELSE
        SELECT CAST(0 AS BIT);
END
GO

-- 1 si el nombre de usuario ya lo usa otro usuario
CREATE OR ALTER PROCEDURE sp_ExisteNombreUsuario
    @NombreUsuario NVARCHAR(50),
    @IdUsuarioExcluido INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
               FROM Usuario
               WHERE Nombre_Usuario = @NombreUsuario
                 AND Id_Usuario <> @IdUsuarioExcluido)
        SELECT CAST(1 AS BIT);
    ELSE
        SELECT CAST(0 AS BIT);
END
GO
