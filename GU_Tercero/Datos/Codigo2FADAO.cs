using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // Acceso a la tabla Codigo2FA (autenticación en dos pasos).
    public class Codigo2FADAO
    {
        public void GuardarCodigo(int idUsuario, string codigo, int minutosValidez)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GenerarCodigo2FA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 10).Value = codigo;
                cmd.Parameters.Add("@Minutos_Validez", SqlDbType.Int).Value = minutosValidez;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Devuelve "OK", "INCORRECTO" o "EXPIRADO".
        public string ValidarCodigo(int idUsuario, string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarCodigo2FA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 10).Value = codigo;

                conn.Open();
                return cmd.ExecuteScalar()?.ToString() ?? "EXPIRADO";
            }
        }

        public void InvalidarCodigos(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InvalidarCodigos2FA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
