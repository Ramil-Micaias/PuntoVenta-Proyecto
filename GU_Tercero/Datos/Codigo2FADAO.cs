using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // acceso a datos de los codigos de verificacion en dos pasos
    public class Codigo2FADAO
    {
        // guarda el codigo que se mando por mail con los minutos que dura
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

        // valida el codigo que escribio el usuario, el sp devuelve el resultado como texto
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

        // anula los codigos que tenia pendientes el usuario
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
