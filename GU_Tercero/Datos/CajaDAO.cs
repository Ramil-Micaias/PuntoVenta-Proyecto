using Datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Datos
{
    public class CajaDAO
    {
        // Devuelve la caja de hoy o null si todavía no se abrió.
        public Caja? ObtenerCajaActual()
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCajaActual", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Caja
                        {
                            Id_Caja = Convert.ToInt32(dr["Id_Caja"]),
                            Fecha_Apertura = Convert.ToDateTime(dr["Fecha_Apertura"]),
                            Saldo_Inicial = Convert.ToDecimal(dr["Saldo_Inicial"]),
                            Abierta = Convert.ToBoolean(dr["Abierta"]),
                            Fecha_Cierre = dr["Fecha_Cierre"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(dr["Fecha_Cierre"]),
                            Usuario_Apertura = dr["Usuario_Apertura"].ToString() ?? string.Empty,
                            Ingresos = Convert.ToDecimal(dr["Ingresos"]),
                            Egresos = Convert.ToDecimal(dr["Egresos"]),
                            Saldo_Disponible = Convert.ToDecimal(dr["Saldo_Disponible"])
                        };
                    }
                }
            }

            return null;
        }

        public DataTable ListarMovimientos(int idCaja)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMovimientosCaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", idCaja);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        public void AbrirCaja(int idUsuario, decimal saldoInicial)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AbrirCaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.Add("@Saldo_Inicial", SqlDbType.Decimal).Value = saldoInicial;
                cmd.Parameters["@Saldo_Inicial"].Precision = 12;
                cmd.Parameters["@Saldo_Inicial"].Scale = 2;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Cierra la caja y devuelve el saldo con el que quedó.
        public decimal CerrarCaja(int idCaja, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_CerrarCaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Caja", SqlDbType.Int).Value = idCaja;
                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;

                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // Vuelve a abrir la caja de hoy que se cerró por error.
        public void ReabrirCaja(int idCaja, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ReabrirCaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Caja", SqlDbType.Int).Value = idCaja;
                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = idUsuario;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Registra el movimiento y devuelve el saldo actualizado de la caja.
        public decimal RegistrarMovimiento(MovimientoCaja movimiento)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarMovimientoCaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id_Caja", SqlDbType.Int).Value = movimiento.Id_Caja;
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 10).Value = movimiento.Tipo;
                cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = movimiento.Importe;
                cmd.Parameters["@Importe"].Precision = 12;
                cmd.Parameters["@Importe"].Scale = 2;
                cmd.Parameters.Add("@Motivo", SqlDbType.NVarChar, 200).Value = movimiento.Motivo.Trim();
                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = movimiento.Id_Usuario;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return Convert.ToDecimal(dr["Saldo_Disponible"]);
                    }
                }
            }

            throw new Exception("El movimiento no pudo registrarse. Intente nuevamente.");
        }
    }
}
