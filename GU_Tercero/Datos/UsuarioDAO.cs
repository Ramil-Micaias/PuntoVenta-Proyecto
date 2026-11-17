using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // acceso a datos de usuarios, login, contrasenias y preguntas de seguridad
    public class UsuarioDAO
    {
        // busca el usuario por nombre para el login, si no existe devuelve null
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
        // suma un intento fallido de login
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
        // bloquea el usuario cuando se pasa de intentos
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
        // pone los intentos en cero cuando entra bien
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
        // guarda la fecha del ultimo ingreso
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
        // guarda la contrasenia nueva (ya viene hasheada)
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
        
        // guarda la contrasenia en el historial para no repetirla
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

        // se fija si la contrasenia ya se uso antes
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
        
        // guarda la respuesta (hasheada) de una pregunta del usuario
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

        // cuantas preguntas tiene cargadas el usuario
        public int CantidadPreguntasUsuario(int idUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_UsuarioTienePreguntas", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // usuarios para la grilla de gestion de usuarios
        public DataTable ObtenerUsuarios()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarios", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(tabla);
            }

            return tabla;
        }

        // roles para el combo
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

        // igual que el anterior pero sin contar al usuario que se esta modificando (sp_ExisteDniEnOtroUsuario)
        public bool ExisteDniEnOtroUsuario(string dni, int idUsuarioExcluido)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteDniEnOtroUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@IdUsuarioExcluido", idUsuarioExcluido);

                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        // true si el correo ya lo tiene otra persona (sp_ExisteCorreoDeOtraPersona)
        // el sp averigua cual es la persona propia: la del usuario o, si es un alta, la que ya tiene ese DNI
        public bool ExisteCorreoDeOtraPersona(string correo, string dni, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteCorreoDeOtraPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        // true si el DNI ya es de otra persona (sp_ExisteDniDeOtraPersona)
        public bool ExisteDniDeOtraPersona(string dni, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteDniDeOtraPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        // true si el nombre de usuario ya esta usado por otro (sp_ExisteNombreUsuario)
        public bool ExisteNombreUsuario(string nombreUsuario, int idUsuarioExcluido)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteNombreUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@IdUsuarioExcluido", idUsuarioExcluido);

                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        // alta del usuario con su persona y su correo, devuelve el id
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

        // modifica los datos del usuario y de su persona
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
        
        // baja logica del usuario
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

        // vuelve a activar el usuario
        public void ActivarUsuario(int idUsuario)
        {
            EjecutarPorId("sp_ActivarUsuario", idUsuario);
        }

        // desbloquea el usuario y le reinicia los intentos
        public void DesbloquearUsuario(int idUsuario)
        {
            EjecutarPorId("sp_DesbloquearUsuario", idUsuario);
        }

        // ejecuta un sp que solo recibe el id del usuario
        private void EjecutarPorId(string procedimiento, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(procedimiento, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // preguntas que cargo el usuario, para recuperar la contrasenia
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

        // trae el hash de la respuesta guardada para compararla (sp_ObtenerHashRespuesta)
        public string ObtenerHashRespuesta(string nombreUsuario, int idPregunta)
        {
            using (SqlConnection conexion = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerHashRespuesta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@IdPregunta", idPregunta);

                conexion.Open();

                object resultado = cmd.ExecuteScalar();

                // si el usuario no tiene esa pregunta cargada devolvemos vacio
                if (resultado == null || resultado == DBNull.Value)
                {
                    return string.Empty;
                }

                return resultado.ToString()!;
            }
        }

        // pone la contrasenia nueva cuando la recupera
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

        // correo del usuario, para mandarle mails
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

        // datos personales del usuario (nombre, apellido, DNI)
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