using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ProductoDAO
    {
        public DataTable ObtenerProductos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerProductos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }


        public DataTable ObtenerCategorias()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCategorias", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }


        public DataTable BuscarProductos(string filtro)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarProductos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100)
                    .Value = filtro ?? string.Empty;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }


        public void RegistrarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = producto.Id_Categoria;

                cmd.Parameters.Add("@Nombre_Producto", SqlDbType.NVarChar, 50)
                    .Value = producto.Nombre_Producto;

                cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 120)
                    .Value = (object)producto.Descripcion ?? DBNull.Value;

                cmd.Parameters.Add("@Precio_Venta", SqlDbType.Decimal)
                    .Value = producto.Precio_Venta;

                cmd.Parameters.Add("@Stock_Actual", SqlDbType.Int)
                    .Value = producto.Stock_Actual;

                cmd.Parameters.Add("@Stock_Minimo", SqlDbType.Int)
                    .Value = producto.Stock_Minimo;

                cmd.Parameters.Add("@Es_Repuesto", SqlDbType.Bit)
                    .Value = producto.Es_Repuesto;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void ModificarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Producto", SqlDbType.Int)
                    .Value = producto.Id_Producto;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = producto.Id_Categoria;

                cmd.Parameters.Add("@Nombre_Producto", SqlDbType.NVarChar, 50)
                    .Value = producto.Nombre_Producto;

                cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 120)
                    .Value = (object)producto.Descripcion ?? DBNull.Value;

                cmd.Parameters.Add("@Precio_Venta", SqlDbType.Decimal)
                    .Value = producto.Precio_Venta;

                cmd.Parameters.Add("@Stock_Actual", SqlDbType.Int)
                    .Value = producto.Stock_Actual;

                cmd.Parameters.Add("@Stock_Minimo", SqlDbType.Int)
                    .Value = producto.Stock_Minimo;

                cmd.Parameters.Add("@Es_Repuesto", SqlDbType.Bit)
                    .Value = producto.Es_Repuesto;

                cmd.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = producto.Activo;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void InactivarProducto(int idProducto)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InactivarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Producto", SqlDbType.Int)
                    .Value = idProducto;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}