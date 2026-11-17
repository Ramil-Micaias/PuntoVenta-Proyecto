using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Datos
{
    // acceso a datos del taller: clientes, equipos y ordenes de reparacion
    public class TallerDAO
    {
        // clientes del taller para el combo de la orden
        public DataTable ObtenerClientes()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerClientesTaller", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // alta de cliente, devuelve el id nuevo
        public int InsertarCliente(string apellido, string nombre, string dni, string? telefono)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarClienteTaller", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 50).Value = apellido;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = nombre;
                cmd.Parameters.Add("@DNI", SqlDbType.NVarChar, 20).Value = dni;
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value =
                    string.IsNullOrWhiteSpace(telefono) ? DBNull.Value : telefono;

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // trae un cliente para poder editarlo
        public DataTable ObtenerCliente(int idCliente)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerClienteTaller", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = idCliente;

                new SqlDataAdapter(cmd).Fill(tabla);
            }

            return tabla;
        }

        // guarda los datos corregidos del cliente
        public void ModificarCliente(int idCliente, string apellido, string nombre, string dni, string? telefono)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarClienteTaller", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 50).Value = apellido;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = nombre;
                cmd.Parameters.Add("@DNI", SqlDbType.NVarChar, 20).Value = dni;
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 15).Value =
                    string.IsNullOrWhiteSpace(telefono) ? DBNull.Value : telefono;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // equipos que tiene cargados un cliente
        public DataTable ObtenerEquipos(int idCliente)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerEquiposCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = idCliente;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // alta de un equipo del cliente, devuelve el id
        public int InsertarEquipo(int idCliente, string tipo, string marca, string modelo, string? numeroSerie, string? imei, string? color)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@Tipo_Dispositivo", SqlDbType.NVarChar, 50).Value = tipo;
                cmd.Parameters.Add("@Marca", SqlDbType.NVarChar, 50).Value = marca;
                cmd.Parameters.Add("@Modelo", SqlDbType.NVarChar, 80).Value = modelo;
                cmd.Parameters.Add("@Numero_Serie", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(numeroSerie) ? DBNull.Value : numeroSerie;
                cmd.Parameters.Add("@IMEI", SqlDbType.NVarChar, 20).Value =
                    string.IsNullOrWhiteSpace(imei) ? DBNull.Value : imei;
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar, 30).Value =
                    string.IsNullOrWhiteSpace(color) ? DBNull.Value : color;

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // usuarios con rol tecnico para asignar la orden
        public DataTable ObtenerTecnicos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerTecnicos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // estados posibles de la orden (recibido, en reparacion, etc)
        public DataTable ObtenerEstados()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerEstadosOrden", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // productos que se pueden usar como repuesto
        public DataTable ObtenerRepuestos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRepuestos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // crea o actualiza la orden (si Id_Orden es 0 es nueva) junto con los repuestos
        public ResultadoOperacion GuardarOrden(OrdenReparacion orden)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GuardarOrdenReparacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Orden", SqlDbType.Int).Value = orden.Id_Orden;
                cmd.Parameters.Add("@Id_Equipo", SqlDbType.Int).Value = orden.Id_Equipo;
                cmd.Parameters.Add("@Id_Tecnico", SqlDbType.Int).Value =
                    orden.Id_Tecnico.HasValue ? orden.Id_Tecnico.Value : DBNull.Value;
                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = orden.Id_Usuario;
                cmd.Parameters.Add("@Id_Estado", SqlDbType.Int).Value = orden.Id_Estado;
                cmd.Parameters.Add("@Falla_Declarada", SqlDbType.NVarChar, 500).Value = orden.Falla_Declarada;
                cmd.Parameters.Add("@Patron_Clave", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(orden.Patron_Clave) ? DBNull.Value : orden.Patron_Clave;
                cmd.Parameters.Add("@Diagnostico", SqlDbType.NVarChar, 500).Value =
                    string.IsNullOrWhiteSpace(orden.Diagnostico) ? DBNull.Value : orden.Diagnostico;

                cmd.Parameters.Add("@Costo_Mano_Obra", SqlDbType.Decimal).Value = orden.Costo_Mano_Obra;
                cmd.Parameters["@Costo_Mano_Obra"].Precision = 12;
                cmd.Parameters["@Costo_Mano_Obra"].Scale = 2;

                cmd.Parameters.Add("@Fecha_Prometida", SqlDbType.Date).Value =
                    orden.Fecha_Prometida.HasValue ? orden.Fecha_Prometida.Value : DBNull.Value;
                cmd.Parameters.Add("@Observacion", SqlDbType.NVarChar, 255).Value =
                    string.IsNullOrWhiteSpace(orden.Observacion) ? DBNull.Value : orden.Observacion;
                // los repuestos van todos juntos en un json
                cmd.Parameters.Add("@Repuestos", SqlDbType.NVarChar, -1).Value = SerializarRepuestos(orden);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ResultadoOperacion
                        {
                            Id_Operacion = Convert.ToInt32(reader["Id_Orden"]),
                            Comprobante = reader["Numero_Orden"].ToString(),
                            Subtotal = Convert.ToDecimal(reader["Total"]),
                            Descuento = 0,
                            Total = Convert.ToDecimal(reader["Total"])
                        };
                    }
                }
            }

            throw new Exception("La orden no pudo guardarse. Intente nuevamente.");
        }

        // arma el json con los repuestos de la orden para mandarlo al sp
        private static string SerializarRepuestos(OrdenReparacion orden)
        {
            List<object> items = new List<object>();

            foreach (DetalleOrdenRepuesto item in orden.Repuestos)
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

        // ordenes para la grilla del taller con los filtros elegidos
        public DataTable ConsultarOrdenes(string filtro, int? idEstado, int? idTecnico, bool soloPendientes, int? idUsuarioPropio = null)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ConsultarOrdenes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100).Value = filtro ?? string.Empty;
                cmd.Parameters.Add("@Id_Estado", SqlDbType.Int).Value =
                    idEstado.HasValue ? idEstado.Value : DBNull.Value;
                cmd.Parameters.Add("@Id_Tecnico", SqlDbType.Int).Value =
                    idTecnico.HasValue ? idTecnico.Value : DBNull.Value;
                cmd.Parameters.Add("@Solo_Pendientes", SqlDbType.Bit).Value = soloPendientes;
                cmd.Parameters.Add("@Id_Usuario_Propio", SqlDbType.Int).Value =
                    idUsuarioPropio.HasValue ? idUsuarioPropio.Value : DBNull.Value;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // datos de una orden
        public DataTable ObtenerOrden(int idOrden)
        {
            return ConsultarPorOrden("sp_ObtenerOrden", idOrden);
        }

        // repuestos usados en una orden
        public DataTable ObtenerRepuestosOrden(int idOrden)
        {
            return ConsultarPorOrden("sp_ObtenerRepuestosOrden", idOrden);
        }

        // historial de cambios de estado de la orden
        public DataTable ObtenerHistorialOrden(int idOrden)
        {
            return ConsultarPorOrden("sp_ObtenerHistorialOrden", idOrden);
        }

        // metodo comun para los sp que reciben solo el id de la orden
        private static DataTable ConsultarPorOrden(string procedimiento, int idOrden)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(procedimiento, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Orden", SqlDbType.Int).Value = idOrden;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
