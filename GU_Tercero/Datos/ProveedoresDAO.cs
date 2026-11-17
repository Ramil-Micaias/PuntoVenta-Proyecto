using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // acceso a datos de proveedores
    public class ProveedoresDAO
    {
        // solo los proveedores activos
        public DataTable ObtenerProveedores()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerProveedores", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // proveedores activos e inactivos, para la grilla
        public DataTable ObtenerTodosProveedores()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerTodosProveedores", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // alta de proveedor, devuelve true si se pudo guardar
        public bool RegistrarProveedor(Proveedor proveedor)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Razon_Social", SqlDbType.NVarChar, 100)
                    .Value = proveedor.Razon_Social;

                cmd.Parameters.Add("@CUIT", SqlDbType.NVarChar, 20)
                    .Value = string.IsNullOrWhiteSpace(proveedor.CUIT) ? DBNull.Value : proveedor.CUIT;

                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Telefono) ? DBNull.Value : proveedor.Telefono;

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Email) ? DBNull.Value : proveedor.Email;

                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 150)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Direccion) ? DBNull.Value : proveedor.Direccion;

                conn.Open();
                return Convert.ToString(cmd.ExecuteScalar()) == "REACTIVADO";
            }
        }

        // modifica los datos del proveedor
        public void ModificarProveedor(Proveedor proveedor)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = proveedor.Id_Proveedor;

                cmd.Parameters.Add("@Razon_Social", SqlDbType.NVarChar, 100)
                    .Value = proveedor.Razon_Social;

                cmd.Parameters.Add("@CUIT", SqlDbType.NVarChar, 20)
                    .Value = string.IsNullOrWhiteSpace(proveedor.CUIT) ? DBNull.Value : proveedor.CUIT;

                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Telefono) ? DBNull.Value : proveedor.Telefono;

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Email) ? DBNull.Value : proveedor.Email;

                cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 150)
                    .Value = string.IsNullOrWhiteSpace(proveedor.Direccion) ? DBNull.Value : proveedor.Direccion;

                cmd.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = proveedor.Activo;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // baja logica del proveedor
        public void InactivarProveedor(int idProveedor)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InactivarProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = idProveedor;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // vuelve a activar el proveedor
        public void ReactivarProveedor(int idProveedor)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ReactivarProveedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = idProveedor;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
