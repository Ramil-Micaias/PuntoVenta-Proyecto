using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // La clase ConfiguracionDAO pertenece a la capa de datos y se encarga
    // de obtener y actualizar la configuración del sistema almacenada
    // en SQL Server mediante procedimientos almacenados.
    public class ConfiguracionDAO
    {
        // Obtiene la configuración actual del sistema.
        public ConfiguracionSistema ObtenerConfiguracion()
        {
            ConfiguracionSistema configuracion = null;

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerConfiguracion", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    configuracion = new ConfiguracionSistema();

                    configuracion.Id_Configuracion = Convert.ToInt32(reader["Id_Configuracion"]);

                    configuracion.Min_Caracteres = Convert.ToInt32(reader["Min_Caracteres"]);

                    configuracion.Requiere_Mayusculas = Convert.ToBoolean(reader["Requiere_Mayusculas"]);

                    configuracion.Requiere_Numeros = Convert.ToBoolean(reader["Requiere_Numeros"]);

                    configuracion.Requiere_Especial = Convert.ToBoolean(reader["Requiere_Especial"]);

                    configuracion.Habilitar_2FA = Convert.ToBoolean(reader["Habilitar_2FA"]);

                    configuracion.Validar_DatosPersonales = Convert.ToBoolean(reader["Validar_DatosPersonales"]);

                    configuracion.No_RepetirPasswords = Convert.ToBoolean(reader["No_RepetirPasswords"]);

                    configuracion.Cantidad_HistorialPasswords = Convert.ToInt32(reader["Cantidad_HistorialPasswords"]);

                    configuracion.Cantidad_Preguntas = Convert.ToInt32(reader["Cantidad_Preguntas"]);
                }
            }

            return configuracion;
        }

        // Guarda las modificaciones realizadas por el administrador.
        public void GuardarConfiguracion(ConfiguracionSistema configuracion)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GuardarConfiguracion", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Configuracion", configuracion.Id_Configuracion);

                cmd.Parameters.AddWithValue("@Min_Caracteres", configuracion.Min_Caracteres);

                cmd.Parameters.AddWithValue("@Requiere_Mayusculas", configuracion.Requiere_Mayusculas);

                cmd.Parameters.AddWithValue("@Requiere_Numeros", configuracion.Requiere_Numeros);

                cmd.Parameters.AddWithValue("@Requiere_Especial", configuracion.Requiere_Especial);

                cmd.Parameters.AddWithValue("@Habilitar_2FA", configuracion.Habilitar_2FA);

                cmd.Parameters.AddWithValue("@Validar_DatosPersonales", configuracion.Validar_DatosPersonales);

                cmd.Parameters.AddWithValue("@No_RepetirPasswords", configuracion.No_RepetirPasswords);

                cmd.Parameters.AddWithValue("@Cantidad_HistorialPasswords", configuracion.Cantidad_HistorialPasswords);

                cmd.Parameters.AddWithValue("@Cantidad_Preguntas", configuracion.Cantidad_Preguntas);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
