USE GU_Tercero;
GO

DROP FUNCTION IF EXISTS fn_DigitoLuhn;
GO

CREATE OR ALTER FUNCTION fn_DigitoVerificador (@Hexa VARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @Largo INT = LEN(@Hexa);
    DECLARE @Posicion INT = 0;
    DECLARE @Suma INT = 0;
    DECLARE @Valor INT;

    WHILE @Posicion < @Largo
    BEGIN
        SET @Valor = CHARINDEX(UPPER(SUBSTRING(@Hexa, @Largo - @Posicion, 1)), '0123456789ABCDEF') - 1;

        IF @Posicion % 2 = 0
            SET @Valor = @Valor * 2;

        WHILE @Valor > 9
            SET @Valor = (@Valor / 10) + (@Valor % 10);

        SET @Suma = @Suma + @Valor;
        SET @Posicion = @Posicion + 1;
    END

    RETURN (@Suma * 9) % 10;
END
GO

UPDATE Usuario
SET PasswordHash = PasswordHash + CAST(dbo.fn_DigitoVerificador(PasswordHash) AS VARCHAR(1))
WHERE LEN(PasswordHash) = 64;
GO

UPDATE HistorialPassword
SET PasswordHash = PasswordHash + CAST(dbo.fn_DigitoVerificador(PasswordHash) AS VARCHAR(1))
WHERE LEN(PasswordHash) = 64;
GO
