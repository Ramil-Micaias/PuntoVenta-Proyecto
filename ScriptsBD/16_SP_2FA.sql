USE GU_Tercero;
GO

CREATE OR ALTER PROCEDURE sp_GenerarCodigo2FA
    @Id_Usuario INT,
    @Codigo NVARCHAR(10),
    @Minutos_Validez INT = 5
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Codigo2FA
        SET Usado = 1
        WHERE Id_Usuario = @Id_Usuario
          AND Usado = 0;

        INSERT INTO Codigo2FA (Id_Usuario, Codigo, Fecha_Generacion, Fecha_Expiracion, Usado)
        VALUES (@Id_Usuario, @Codigo, GETDATE(), DATEADD(MINUTE, @Minutos_Validez, GETDATE()), 0);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_ValidarCodigo2FA
    @Id_Usuario INT,
    @Codigo NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdCodigo INT;
    DECLARE @CodigoGuardado NVARCHAR(10);
    DECLARE @Expiracion DATETIME;

    SELECT TOP 1
        @IdCodigo = Id_Codigo2FA,
        @CodigoGuardado = Codigo,
        @Expiracion = Fecha_Expiracion
    FROM Codigo2FA
    WHERE Id_Usuario = @Id_Usuario
      AND Usado = 0
    ORDER BY Id_Codigo2FA DESC;

    IF @IdCodigo IS NULL OR @Expiracion < GETDATE()
    BEGIN
        SELECT 'EXPIRADO' AS Resultado;
        RETURN;
    END

    IF @CodigoGuardado <> LTRIM(RTRIM(ISNULL(@Codigo, '')))
    BEGIN
        SELECT 'INCORRECTO' AS Resultado;
        RETURN;
    END

    UPDATE Codigo2FA
    SET Usado = 1
    WHERE Id_Codigo2FA = @IdCodigo
      AND Usado = 0;

    IF @@ROWCOUNT = 0
    BEGIN
        SELECT 'EXPIRADO' AS Resultado;
        RETURN;
    END

    SELECT 'OK' AS Resultado;
END
GO

CREATE OR ALTER PROCEDURE sp_InvalidarCodigos2FA
    @Id_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Codigo2FA
    SET Usado = 1
    WHERE Id_Usuario = @Id_Usuario
      AND Usado = 0;
END
GO
