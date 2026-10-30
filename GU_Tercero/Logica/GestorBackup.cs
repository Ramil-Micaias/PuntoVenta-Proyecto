using Datos;
using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace Logica
{
    public class GestorBackup
    {
        // Carpeta propuesta: el servicio de SQL Server puede escribir ahí
        // (en Escritorio o Documentos no tiene permiso).
        public const string CARPETA_POR_DEFECTO = @"C:\BackupsAplBigStore";

        private readonly BackupDAO backupDAO = new BackupDAO();

        public string ObtenerCarpetaPorDefecto()
        {
            try
            {
                Directory.CreateDirectory(CARPETA_POR_DEFECTO);
            }
            catch
            {
                // Si no se puede crear, el usuario elige otra carpeta.
            }
            return CARPETA_POR_DEFECTO;
        }

        // Devuelve el mensaje para mostrar con el nombre y el tamaño del archivo.
        public string GenerarBackup(string carpeta)
        {
            if (string.IsNullOrWhiteSpace(carpeta))
                throw new Exception("Debe elegir la carpeta donde guardar el backup.");

            if (!Directory.Exists(carpeta))
                throw new Exception("La carpeta elegida no existe.");

            try
            {
                var (ruta, tamanioBytes) = backupDAO.GenerarBackup(carpeta);

                decimal megas = Math.Round(tamanioBytes / 1024m / 1024m, 2);
                return "Backup generado: " + Path.GetFileName(ruta) + " (" + megas + " MB).";
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("error 5"))
                    throw new Exception("SQL Server no tiene permiso para escribir en esa carpeta. Elija otra, por ejemplo " + CARPETA_POR_DEFECTO + ".");

                if (ex.Message.Contains("error 112"))
                    throw new Exception("No hay espacio suficiente en el disco para guardar el backup.");

                throw new Exception("No se pudo generar el backup: " + ex.Message);
            }
        }
    }
}
