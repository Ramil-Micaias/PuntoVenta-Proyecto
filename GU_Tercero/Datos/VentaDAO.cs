using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Datos
{
    public class VentaDAO
    {
        public ResultadoOperacion RegistrarVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Numero_Factura", SqlDbType.NVarChar, 20)
                    .Value = string.IsNullOrWhiteSpace(venta.Numero_Factura)
                        ? DBNull.Value
                        : venta.Numero_Factura.Trim();

                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int)
                    .Value = venta.Id_Cliente.HasValue ? venta.Id_Cliente.Value : DBNull.Value;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int)
                    .Value = venta.Id_Usuario_Vendedor;

                cmd.Parameters.Add("@Id_MetodoPago", SqlDbType.Int)
                    .Value = venta.Id_MetodoPago;

                cmd.Parameters.Add("@DescuentoPorcentaje", SqlDbType.Decimal)
                    .Value = venta.DescuentoPorcentaje;

                cmd.Parameters["@DescuentoPorcentaje"].Precision = 5;
                cmd.Parameters["@DescuentoPorcentaje"].Scale = 2;

                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime)
                    .Value = venta.Fecha_Venta;

                cmd.Parameters.Add("@Detalles", SqlDbType.NVarChar, -1)
                    .Value = SerializarDetalle(venta);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ResultadoOperacion
                        {
                            Id_Operacion = Convert.ToInt32(reader["Id_Venta"]),
                            Comprobante = reader["Numero_Comprobante"] == DBNull.Value
                                ? null
                                : reader["Numero_Comprobante"].ToString(),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                            Descuento = Convert.ToDecimal(reader["Descuento"]),
                            Total = Convert.ToDecimal(reader["Total"])
                        };
                    }
                }
            }

            throw new Exception("La venta no pudo registrarse. Intente nuevamente.");
        }

        private static string SerializarDetalle(Venta venta)
        {
            List<object> items = new List<object>();

            foreach (DetalleVenta item in venta.Detalle)
            {
                items.Add(new
                {
                    item.Id_Producto,
                    item.Cantidad,
                    Precio = item.Precio_Unitario
                });
            }

            return JsonSerializer.Serialize(items);
        }
    }
}
