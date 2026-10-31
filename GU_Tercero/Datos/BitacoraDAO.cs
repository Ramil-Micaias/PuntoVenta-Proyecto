using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // Acceso a la tabla Bitacora (CU19).
    public class BitacoraDAO
    {
        public void Registrar(string usuario, string? apellidoNombre, string? rol, string modulo, string operacion,
            string criticidad, string? estadoAnterior, string? estadoPosterior)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarBitacora", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
                cmd.Parameters.Add("@Apellido_Nombre", SqlDbType.NVarChar, 110).Value = (object?)apellidoNombre ?? DBNull.Value;
                cmd.Parameters.Add("@Rol", SqlDbType.NVarChar, 30).Value = (object?)rol ?? DBNull.Value;
                cmd.Parameters.Add("@Modulo", SqlDbType.NVarChar, 50).Value = modulo;
                cmd.Parameters.Add("@Operacion", SqlDbType.NVarChar, 300).Value = operacion;
                cmd.Parameters.Add("@Criticidad", SqlDbType.NVarChar, 15).Value = criticidad;
                cmd.Parameters.Add("@Estado_Anterior", SqlDbType.NVarChar, -1).Value = (object?)estadoAnterior ?? DBNull.Value;
                cmd.Parameters.Add("@Estado_Posterior", SqlDbType.NVarChar, -1).Value = (object?)estadoPosterior ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Los filtros en null no se aplican.
        public DataTable Listar(DateTime desde, DateTime hasta, string? criticidad, string? modulo, string? texto)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarBitacora", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Desde", SqlDbType.Date).Value = desde.Date;
                cmd.Parameters.Add("@Hasta", SqlDbType.Date).Value = hasta.Date;
                cmd.Parameters.Add("@Criticidad", SqlDbType.NVarChar, 15).Value = (object?)criticidad ?? DBNull.Value;
                cmd.Parameters.Add("@Modulo", SqlDbType.NVarChar, 50).Value = (object?)modulo ?? DBNull.Value;
                cmd.Parameters.Add("@Texto", SqlDbType.NVarChar, 100).Value = (object?)texto ?? DBNull.Value;

                DataTable tabla = new DataTable();
                new SqlDataAdapter(cmd).Fill(tabla);
                return tabla;
            }
        }

        public bool UsuarioTienePermiso(int idUsuario, string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_UsuarioTienePermiso", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 100).Value = codigo;

                conn.Open();
                object? resultado = cmd.ExecuteScalar();
                return resultado != null && resultado != DBNull.Value && Convert.ToBoolean(resultado);
            }
        }
    }
}
