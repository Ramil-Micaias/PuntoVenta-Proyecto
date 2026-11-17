using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Datos
{
    // datos para los paneles del menu principal
    public class ResumenDAO
    {
        // ventas, compras, ordenes y alertas de stock del dia
        public ResumenDiario ObtenerResumenDiario()
        {
            ResumenDiario resumen = new ResumenDiario();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerResumenDiario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        resumen.Total_Ventas_Dia = Convert.ToDecimal(dr["Total_Ventas_Dia"]);
                        resumen.Cantidad_Ventas_Dia = Convert.ToInt32(dr["Cantidad_Ventas_Dia"]);
                        resumen.Ordenes_Taller_Activas = Convert.ToInt32(dr["Ordenes_Taller_Activas"]);
                        resumen.Productos_Stock_Bajo = Convert.ToInt32(dr["Productos_Stock_Bajo"]);
                        resumen.Total_Compras_Dia = Convert.ToDecimal(dr["Total_Compras_Dia"]);
                        resumen.Cantidad_Compras_Dia = Convert.ToInt32(dr["Cantidad_Compras_Dia"]);
                    }
                }
            }

            return resumen;
        }

        // resumen del tecnico: sus ordenes y su comision
        public ResumenTecnico ObtenerResumenTecnico(int idTecnico)
        {
            ResumenTecnico resumen = new ResumenTecnico();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerResumenTecnico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tecnico", idTecnico);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        resumen.Ordenes_Asignadas = Convert.ToInt32(dr["Ordenes_Asignadas"]);
                        resumen.Ordenes_Terminadas = Convert.ToInt32(dr["Ordenes_Terminadas"]);
                        resumen.Total_Reparaciones = Convert.ToDecimal(dr["Total_Reparaciones"]);
                    }
                }
            }

            return resumen;
        }
    }
}
