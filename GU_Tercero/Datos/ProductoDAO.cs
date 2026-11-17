using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    // acceso a datos de productos y categorias
    public class ProductoDAO
    {
        // todos los productos para la grilla de productos
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

        // categorias para los combos
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

        // busca productos por nombre o codigo
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

        // busqueda para la pantalla de ventas, se puede filtrar por categoria
        public DataTable BuscarProductosPOS(string filtro, int? idCategoria)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarProductosPOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100)
                    .Value = filtro ?? string.Empty;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = idCategoria.HasValue ? idCategoria.Value : DBNull.Value;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // stock de los productos, con opcion de ver solo los que estan bajo el minimo
        public DataTable ConsultarStock(string filtro, int? idCategoria, bool soloBajoMinimo)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ConsultarStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100)
                    .Value = filtro ?? string.Empty;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = idCategoria.HasValue ? idCategoria.Value : DBNull.Value;

                cmd.Parameters.Add("@SoloBajoMinimo", SqlDbType.Bit)
                    .Value = soloBajoMinimo;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // da de alta un producto nuevo
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

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = producto.Id_Proveedor.HasValue ? producto.Id_Proveedor.Value : DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // modifica los datos de un producto
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

                cmd.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = producto.Activo;

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = producto.Id_Proveedor.HasValue ? producto.Id_Proveedor.Value : DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // baja logica del producto, no se borra
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

        // vuelve a activar un producto dado de baja
        public void ReactivarProducto(int idProducto)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ReactivarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Producto", SqlDbType.Int)
                    .Value = idProducto;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // alta de categoria
        public void RegistrarCategoria(string nombreCategoria)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Nombre_Categoria", SqlDbType.NVarChar, 50)
                    .Value = nombreCategoria;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // cambia el nombre de una categoria
        public void ModificarCategoria(int idCategoria, string nombreCategoria)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = idCategoria;

                cmd.Parameters.Add("@Nombre_Categoria", SqlDbType.NVarChar, 50)
                    .Value = nombreCategoria;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // baja logica de la categoria
        public void InactivarCategoria(int idCategoria)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InactivarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Categoria", SqlDbType.Int)
                    .Value = idCategoria;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}