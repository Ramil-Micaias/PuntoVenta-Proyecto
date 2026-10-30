USE GU_Tercero;
GO

-- ============================================================
-- MODULO: BACKUP (CU20)
-- Genera una copia completa de la base en un archivo .bak usando el
-- respaldo propio de SQL Server y verifica que la copia sea válida.
-- El archivo lo escribe el servicio de SQL Server, por eso la carpeta
-- tiene que existir y el servicio tiene que tener permiso para escribir
-- (por ejemplo C:\BackupsAplBigStore; Escritorio y Documentos no sirven).
-- ============================================================

-- ------------------------------------------------------------
-- 1. SP: Generar backup
--    Arma el nombre con la fecha y hora, hace el BACKUP, lo verifica
--    con RESTORE VERIFYONLY y devuelve la ruta y el tamaño en bytes.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_GenerarBackup
    @Carpeta NVARCHAR(400)
AS
BEGIN
    SET NOCOUNT ON;

    IF RIGHT(@Carpeta, 1) <> '\'
        SET @Carpeta = @Carpeta + '\';

    DECLARE @Ruta NVARCHAR(500) = @Carpeta + 'GU_Tercero_'
        + FORMAT(GETDATE(), 'yyyyMMdd_HHmmss') + '.bak';

    BEGIN TRY
        BACKUP DATABASE GU_Tercero
            TO DISK = @Ruta
            WITH INIT, CHECKSUM, NAME = 'GU_Tercero - Backup completo';

        RESTORE VERIFYONLY FROM DISK = @Ruta WITH CHECKSUM;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH

    SELECT TOP 1
        @Ruta AS Ruta,
        BS.backup_size AS Tamanio_Bytes
    FROM msdb.dbo.backupset BS
    INNER JOIN msdb.dbo.backupmediafamily BMF
        ON BS.media_set_id = BMF.media_set_id
    WHERE BMF.physical_device_name = @Ruta
    ORDER BY BS.backup_finish_date DESC;
END
GO
