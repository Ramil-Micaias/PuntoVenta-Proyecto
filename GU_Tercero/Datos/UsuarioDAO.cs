using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    //La clase UsuarioDAO pertenece a la capa de datos y se encarga de toda la comunicación con SQL Server.
    //Su responsabilidad es ejecutar procedimientos almacenados, obtener información de la base de datos y convertir los registros en objetos C#.
    //No contiene lógica de negocio; solamente acceso a datos.
    public class UsuarioDAO
    {
        public Usuario Login(string nombreUsuario)
        {
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]);

                    usuario.Id_Rol = Convert.ToInt32(reader["Id_Rol"]);

                    usuario.Nombre_Usuario = reader["Nombre_Usuario"].ToString();

                    usuario.PasswordHash = reader["PasswordHash"].ToString();

                    usuario.Nombre_Rol = reader["Nombre_Rol"].ToString();

                    usuario.Activo = Convert.ToBoolean(reader["Activo"]);

                    usuario.Bloqueado = Convert.ToBoolean(reader["Bloqueado"]);

                    usuario.Intentos_Fallidos = Convert.ToInt32(reader["Intentos_Fallidos"]);

                    usuario.Debe_Cambiar_Password = Convert.ToBoolean(reader["Debe_Cambiar_Password"]);

                    usuario.Es_Primer_Ingreso = Convert.ToBoolean(reader["Es_Primer_Ingreso"]);
                }
            }
            return usuario;
        }
        public void AumentarIntentos(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AumentarIntentos", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void BloquearUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BloquearUsuario", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void ReiniciarIntentos(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ReiniciarIntentos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarUltimoLogin(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarUltimoLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void CambiarPassword(int idUsuario, string passwordHash)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_CambiarPassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        // Este método registra una contraseña en el historial del usuario.
        public void RegistrarHistorialPassword(int idUsuario, string passwordHash)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarHistorialPassword", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // Este método verifica si la contraseña ya fue utilizada anteriormente por el usuario.
        public bool ExistePasswordHistorial(int idUsuario, string passwordHash)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ExistePasswordHistorial", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                return reader.HasRows;
            }
        }
        
        //Este metodo ejecuta SP, trae Preguntas activas, crea Listade objetos, devuelve datos a Negocio
        public List<PreguntasSeguridad> ObtenerPreguntas()
        {
            List<PreguntasSeguridad> lista = new List<PreguntasSeguridad>();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPreguntasSeguridad", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PreguntasSeguridad pregunta = new PreguntasSeguridad();

                    pregunta.Id_Pregunta = Convert.ToInt32(reader["Id_Pregunta"]);

                    pregunta.Pregunta = reader["Pregunta"].ToString()!;

                    pregunta.Activo = Convert.ToBoolean(reader["Activo"]);

                    lista.Add(pregunta);
                }
            }

            return lista;
        }

        //Ese método ejecuta el Stored Procedure sp_GuardarPreguntaSeguridad
        //para guardar en SQL Server la Pregunta elegida y la Respuesta encriptada del usuario.
        public void GuardarPreguntaSeguridad(int idUsuario, int idPregunta, string respuestaHash)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GuardarPreguntaSeguridad", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@IdPregunta", idPregunta);
                cmd.Parameters.AddWithValue("@RespuestaHash", respuestaHash);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // Verifica si el usuario ya posee preguntas de seguridad configuradas.
        public bool UsuarioTienePreguntas(int idUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_UsuarioTienePreguntas", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }

        //Este método ejecuta el SP, trae usuarios desde SQL, llena un DataTable, devuelve los datos para el DataGridView
        public DataTable ObtenerUsuarios()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarios", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //SqlDataAdapter Se encarga de extraer datos de la Base de Datos y
                //de guardar los cambios locales de vuelta en ella.
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Llena la Tabla.
                da.Fill(tabla);
            }

            return tabla;
        }

        //Este método ejecuta sp_ObtenerRoles y devuelve los roles activos en un DataTable.
        public DataTable ObtenerRoles()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRoles", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }

        //Existencia del DNI
        public bool ExisteDni(string dni)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                string query = "SELECT COUNT(1) FROM Persona WHERE DNI = @DNI";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DNI", dni);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        //Ejecuta el Stored Procedure sp_InsertarUsuarioCompleto enviando todos los datos necesarios
        //para crear un usuario con su persona, correo y rol asociado.
        public int InsertarUsuarioCompleto(string apellido, string nombre, string dni, string correo, string nombreUsuario, string passwordHash, int idRol)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@Direccion_Correo", correo);
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@IdRol", idRol);

                    conn.Open();

                    int idUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                    return idUsuario;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new Exception("El DNI ingresado ya se encuentra registrado en el sistema.");
            }
        }

        //Ejecuta el Stored Procedure sp_ModificarUsuario para actualizar
        //los datos personales, correo, usuario, rol y estado del usuario en la base de datos.
        public void ModificarUsuario(int idUsuario, string apellido, string nombre, string dni, string correo, string nombreUsuario, int idRol, bool activo, bool bloqueado)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@IdRol", idRol);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.AddWithValue("@Bloqueado", bloqueado);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        
        //Ejecuta el Stored Procedure sp_DesactivarUsuario para realizar la baja lógica de un usuario en la base de datos.
        public void DesactivarUsuario(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand( "sp_DesactivarUsuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                
                conn.Open();
                
                cmd.ExecuteNonQuery();
            }
        }

        //Este método obtiene las preguntas de seguridad asociadas a un usuario.
        public DataTable ObtenerPreguntasUsuario(string nombreUsuario)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPreguntasUsuario",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }

        //Este método valida si la respuesta de seguridad ingresada coincide con la almacenada para el usuario indicado.
        public bool ValidarPreguntaSeguridad(string nombreUsuario, int idPregunta, string respuestaHash)
        {
            using (SqlConnection conexion = new SqlConnection (ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarPreguntaSeguridad", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@IdPregunta", idPregunta);
                cmd.Parameters.AddWithValue("@RespuestaHash", respuestaHash);

                conexion.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                return reader.HasRows;
            }
        }

        public void ReestablecerPassword(string nombreUsuario, string passwordHash)
        {
            using (SqlConnection conexion = new SqlConnection (ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ReestablecerPassword", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }

        // Este método obtiene el correo electrónico asociado al usuario.
        public string ObtenerCorreoUsuario(string nombreUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCorreoUsuario", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                conexion.Open();

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    return resultado.ToString();
                }

                return string.Empty;
            }
        }

        // Este método obtiene los datos personales asociados a un usuario.
        public Persona ObtenerPersona(int idUsuario)
        {
            Persona persona = null;

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPersonaUsuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    persona = new Persona();

                    persona.Nombre = reader["Nombre"].ToString();

                    persona.Apellido = reader["Apellido"].ToString();

                    persona.DNI = reader["DNI"].ToString();

                    if (reader["Fecha_Nacimiento"] != DBNull.Value)
                    {
                        persona.Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]);
                    }
                }
            }

            return persona;
        }
    }
}