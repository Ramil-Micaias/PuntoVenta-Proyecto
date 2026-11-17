using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Datos
{
    // acceso a datos de compras a proveedores
    public class CompraDAO
    {
        // productos para el combo de compras, con su proveedor
        public DataTable BuscarProductosCompra()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarProductosCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                new SqlDataAdapter(cmd).Fill(tabla);
            }

            return tabla;
        }

        // guarda la compra completa: cabecera, detalle y pagos
        public ResultadoOperacion RegistrarCompra(Compra compra)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                conn.Open();
                // usamos una transaccion asi si falla algo no queda la compra a medias
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdCompra = new SqlCommand("sp_RegistrarCompra", conn, transaccion);
                    cmdCompra.CommandType = CommandType.StoredProcedure;

                    cmdCompra.Parameters.Add("@Numero_Comprobante", SqlDbType.VarChar, 50).Value =
                        string.IsNullOrWhiteSpace(compra.Numero_Comprobante) ? DBNull.Value : compra.Numero_Comprobante.Trim();

                    cmdCompra.Parameters.Add("@Id_Proveedor", SqlDbType.Int).Value = compra.Id_Proveedor;
                    cmdCompra.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = compra.Id_Usuario;
                    cmdCompra.Parameters.Add("@Id_MetodoPago", SqlDbType.Int).Value = compra.Id_MetodoPago;
                    cmdCompra.Parameters.Add("@Total", SqlDbType.Decimal).Value = compra.Total;
                    cmdCompra.Parameters.Add("@Fecha_Compra", SqlDbType.DateTime).Value = compra.Fecha_Compra;

                    SqlParameter paramIdCompra = new SqlParameter("@Id_CompraGenerado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmdCompra.Parameters.Add(paramIdCompra);

                    cmdCompra.ExecuteNonQuery();

                    // el sp devuelve el id de la compra nueva por parametro de salida
                    int idCompraGenerado = Convert.ToInt32(cmdCompra.Parameters["@Id_CompraGenerado"].Value);

                    // un registro por cada producto comprado
                    foreach (DetalleCompra item in compra.Detalles)
                    {
                        SqlCommand cmdDetalle = new SqlCommand("sp_RegistrarDetalleCompra", conn, transaccion);
                        cmdDetalle.CommandType = CommandType.StoredProcedure;

                        cmdDetalle.Parameters.Add("@Id_Compra", SqlDbType.Int).Value = idCompraGenerado;
                        cmdDetalle.Parameters.Add("@Id_Producto", SqlDbType.Int).Value = item.Id_Producto;
                        cmdDetalle.Parameters.Add("@Precio_Costo_Unitario", SqlDbType.Decimal).Value = item.Precio_Costo_Unitario;
                        cmdDetalle.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;

                        cmdDetalle.ExecuteNonQuery();
                    }

                    // un registro por cada forma de pago
                    foreach (PagoCompra pago in compra.Pagos)
                    {
                        SqlCommand cmdPago = new SqlCommand("sp_RegistrarPagoCompra", conn, transaccion);
                        cmdPago.CommandType = CommandType.StoredProcedure;

                        cmdPago.Parameters.Add("@Id_Compra", SqlDbType.Int).Value = idCompraGenerado;
                        cmdPago.Parameters.Add("@Id_MetodoPago", SqlDbType.Int).Value = pago.Id_MetodoPago;
                        cmdPago.Parameters.Add("@Importe", SqlDbType.Decimal).Value = pago.Importe;

                        cmdPago.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return new ResultadoOperacion
                    {
                        Id_Operacion = idCompraGenerado,
                        Comprobante = "COM-" + idCompraGenerado.ToString("00000000"),
                        Subtotal = compra.Subtotal,
                        Descuento = 0,
                        Total = compra.Total
                    };
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }
}