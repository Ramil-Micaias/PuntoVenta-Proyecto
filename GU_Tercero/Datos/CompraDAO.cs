using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Datos
{
    public class CompraDAO
    {
        public ResultadoOperacion RegistrarCompra(Compra compra)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Numero_Comprobante", SqlDbType.NVarChar, 50)
                    .Value = string.IsNullOrWhiteSpace(compra.Numero_Comprobante)
                        ? DBNull.Value
                        : compra.Numero_Comprobante.Trim();

                cmd.Parameters.Add("@Id_Proveedor", SqlDbType.Int)
                    .Value = compra.Id_Proveedor;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int)
                    .Value = compra.Id_Usuario;

                cmd.Parameters.Add("@Id_MetodoPago", SqlDbType.Int)
                    .Value = compra.Id_MetodoPago.HasValue
                        ? compra.Id_MetodoPago.Value
                        : DBNull.Value;

                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime)
                    .Value = compra.Fecha_Compra;

                cmd.Parameters.Add("@Detalles", SqlDbType.NVarChar, -1)
                    .Value = SerializarDetalle(compra);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ResultadoOperacion
                        {
                            Id_Operacion = Convert.ToInt32(reader["Id_Compra"]),
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

            throw new Exception("La compra no pudo registrarse. Intente nuevamente.");
        }

        private static string SerializarDetalle(Compra compra)
        {
            List<object> items = new List<object>();

            foreach (DetalleCompra item in compra.Detalle)
            {
                items.Add(new
                {
                    item.Id_Producto,
                    item.Cantidad,
                    Precio = item.Precio_Costo_Unitario,
                    PrecioVenta = item.Precio_Venta_Sugerido
                });
            }

            return JsonSerializer.Serialize(items);
        }
    }
}
