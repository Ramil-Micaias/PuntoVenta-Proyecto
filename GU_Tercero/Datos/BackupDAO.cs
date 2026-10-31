using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // Copia de seguridad de la base de datos (CU20).
    public class BackupDAO
    {
        // Genera el .bak en la carpeta indicada y devuelve la ruta y el tamaño en bytes.
        public (string ruta, long tamanioBytes) GenerarBackup(string carpeta)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GenerarBackup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;

                cmd.Parameters.Add("@Carpeta", SqlDbType.NVarChar, 400).Value = carpeta;

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return ("", 0);

                    string ruta = dr["Ruta"].ToString() ?? "";
                    long tamanio = dr["Tamanio_Bytes"] == DBNull.Value ? 0 : Convert.ToInt64(dr["Tamanio_Bytes"]);
                    return (ruta, tamanio);
                }
            }
        }
    }
}
