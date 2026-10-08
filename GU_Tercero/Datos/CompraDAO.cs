using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Datos
{
    public class CompraDAO
    {
        public ResultadoOperacion RegistrarCompra(Compra compra)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    // 1. Ejecutar la Cabecera de Compra
                    SqlCommand cmdCompra = new SqlCommand("sp_RegistrarCompra", conn, transaccion);
                    cmdCompra.CommandType = CommandType.StoredProcedure;

                    cmdCompra.Parameters.Add("@Numero_Comprobante", SqlDbType.VarChar, 50).Value =
                        string.IsNullOrWhiteSpace(compra.Numero_Comprobante) ? DBNull.Value : compra.Numero_Comprobante.Trim();

                    cmdCompra.Parameters.Add("@Id_Proveedor", SqlDbType.Int).Value = compra.Id_Proveedor;
                    cmdCompra.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = compra.Id_Usuario;
                    cmdCompra.Parameters.Add("@Id_MetodoPago", SqlDbType.Int).Value = compra.Id_MetodoPago;
                    cmdCompra.Parameters.Add("@Total", SqlDbType.Decimal).Value = compra.Total;
                    cmdCompra.Parameters.Add("@Fecha_Compra", SqlDbType.DateTime).Value = compra.Fecha_Compra;

                    // Parámetro de salida para recuperar el ID generado
                    SqlParameter paramIdCompra = new SqlParameter("@Id_CompraGenerado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmdCompra.Parameters.Add(paramIdCompra);

                    cmdCompra.ExecuteNonQuery();

                    int idCompraGenerado = Convert.ToInt32(cmdCompra.Parameters["@Id_CompraGenerado"].Value);

                    // 2. Iterar y registrar cada ítem del detalle
                    foreach (DetalleCompra item in compra.Detalles)
                    {
                        SqlCommand cmdDetalle = new SqlCommand("sp_RegistrarDetalleCompra", conn, transaccion);
                        cmdDetalle.CommandType = CommandType.StoredProcedure;

                        cmdDetalle.Parameters.Add("@Id_Compra", SqlDbType.Int).Value = idCompraGenerado;
                        cmdDetalle.Parameters.Add("@Id_Producto", SqlDbType.Int).Value = item.Id_Producto;
                        cmdDetalle.Parameters.Add("@Precio_Costo_Unitario", SqlDbType.Decimal).Value = item.Precio_Costo_Unitario;
                        cmdDetalle.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;
                        cmdDetalle.Parameters.Add("@Precio_Venta_Sugerido", SqlDbType.Decimal).Value =
                            item.Precio_Venta_Sugerido.HasValue ? item.Precio_Venta_Sugerido.Value : DBNull.Value;

                        cmdDetalle.ExecuteNonQuery();
                    }

                    // Confirmamos la transacción
                    transaccion.Commit();

                    return new ResultadoOperacion
                    {
                        Id_Operacion = idCompraGenerado,
                        Comprobante = compra.Numero_Comprobante,
                        Subtotal = compra.Subtotal,
                        Descuento = 0,
                        Total = compra.Total
                    };
                }
                catch (Exception)
                {
                    // Cancela error
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }
}