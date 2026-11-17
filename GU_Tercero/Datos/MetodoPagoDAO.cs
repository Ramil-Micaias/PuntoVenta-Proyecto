using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // acceso a datos de los metodos de pago
    public class MetodoPagoDAO
    {
        // trae los metodos de pago para los combos de ventas y compras
        public DataTable ObtenerMetodosPago()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerMetodosPago", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
