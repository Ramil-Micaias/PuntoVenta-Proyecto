USE GU_Tercero;
GO

-- ============================================================
-- DIGITO VERIFICADOR DE LAS CONTRASEÑAS
-- La contraseña se guarda como SHA-256 (64 caracteres hexadecimales) y al
-- final un dígito verificador calculado con el algoritmo de Luhn (el mismo
-- método AplicaLhun del sistema), como el último número de un código de barras.
-- Al iniciar sesión el sistema controla primero ese dígito: si no coincide,
-- la contraseña guardada se alteró y no se deja ingresar.
-- Este script les agrega el dígito a las contraseñas que ya estaban guardadas
-- (las de 64 caracteres), así los usuarios siguen entrando con su misma contraseña.
-- Se puede ejecutar varias veces: las que ya tienen el dígito no se tocan.
-- ============================================================

-- ------------------------------------------------------------
-- 1. Función: dígito verificador de Luhn de un texto hexadecimal
--    (mismos pasos que AplicaLhun.Calcular)
-- ------------------------------------------------------------
CREATE OR ALTER FUNCTION fn_DigitoLuhn (@Hexa VARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @Largo INT = LEN(@Hexa);
    DECLARE @Posicion INT = 0;
    DECLARE @Suma INT = 0;
    DECLARE @Valor INT;

    -- Se recorre de derecha a izquierda (es lo mismo que invertir los números)
    WHILE @Posicion < @Largo
    BEGIN
        SET @Valor = CHARINDEX(UPPER(SUBSTRING(@Hexa, @Largo - @Posicion, 1)), '0123456789ABCDEF') - 1;

        -- Las posiciones pares (empezando por la 0) se multiplican por 2
        IF @Posicion % 2 = 0
            SET @Valor = @Valor * 2;

        -- Si quedó un número de más de un dígito, se suman sus dígitos
        WHILE @Valor > 9
            SET @Valor = (@Valor / 10) + (@Valor % 10);

        SET @Suma = @Suma + @Valor;
        SET @Posicion = @Posicion + 1;
    END

    -- La suma se multiplica por 9 y se toma el resto de dividir por 10
    RETURN (@Suma * 9) % 10;
END
GO

-- ------------------------------------------------------------
-- 2. Agregar el dígito a las contraseñas ya guardadas
-- ------------------------------------------------------------
UPDATE Usuario
SET PasswordHash = PasswordHash + CAST(dbo.fn_DigitoLuhn(PasswordHash) AS VARCHAR(1))
WHERE LEN(PasswordHash) = 64;
GO

UPDATE HistorialPassword
SET PasswordHash = PasswordHash + CAST(dbo.fn_DigitoLuhn(PasswordHash) AS VARCHAR(1))
WHERE LEN(PasswordHash) = 64;
GO
