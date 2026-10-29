using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    public class GestorCaja
    {
        // Largo máximo del motivo (igual que la columna Motivo de MovimientoCaja).
        public const int LARGO_MAXIMO_MOTIVO = 200;

        private readonly CajaDAO cajaDAO = new CajaDAO();
        private readonly MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAO();

        public Caja? ObtenerCajaActual()
        {
            return cajaDAO.ObtenerCajaActual();
        }

        public DataTable ListarMovimientos(int idCaja)
        {
            return cajaDAO.ListarMovimientos(idCaja);
        }

        public void AbrirCaja(int idUsuario, decimal saldoInicial)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para abrir la caja.");

            if (saldoInicial < 0)
                throw new Exception("El saldo inicial no puede ser negativo.");

            cajaDAO.AbrirCaja(idUsuario, saldoInicial);
        }

        public decimal CerrarCaja(int idCaja, int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para cerrar la caja.");

            return cajaDAO.CerrarCaja(idCaja, idUsuario);
        }

        // ---------- Historial de Caja ----------

        public DataTable ObtenerMetodosPago()
        {
            return metodoPagoDAO.ObtenerMetodosPago();
        }

        public DataTable ListarCajas(DateTime desde, DateTime hasta)
        {
            ValidarPeriodo(desde, hasta);
            return cajaDAO.ListarCajas(desde, hasta);
        }

        // Movimientos de días completos: desde las 00:00 de "desde" hasta el final de "hasta".
        public DataTable ListarMovimientosPeriodo(DateTime desde, DateTime hasta, int? idMetodoPago)
        {
            ValidarPeriodo(desde, hasta);
            return cajaDAO.ListarMovimientosPeriodo(desde.Date, hasta.Date.AddDays(1), idMetodoPago);
        }

        // Movimientos de una caja: entre el inicio y el fin de su período (los da sp_ListarCajas).
        public DataTable ListarMovimientosDeCaja(DateTime inicio, DateTime fin, int? idMetodoPago)
        {
            return cajaDAO.ListarMovimientosPeriodo(inicio, fin, idMetodoPago);
        }

        private static void ValidarPeriodo(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
                throw new Exception("La fecha desde no puede ser posterior a la fecha hasta.");
        }

        public void ReabrirCaja(int idCaja, int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para reabrir la caja.");

            cajaDAO.ReabrirCaja(idCaja, idUsuario);
        }

        // El saldo disponible es el que muestra la pantalla; el SP lo vuelve a verificar al guardar.
        public decimal RegistrarMovimiento(MovimientoCaja movimiento, decimal saldoDisponible)
        {
            ValidarMovimiento(movimiento, saldoDisponible);
            return cajaDAO.RegistrarMovimiento(movimiento);
        }

        private void ValidarMovimiento(MovimientoCaja movimiento, decimal saldoDisponible)
        {
            if (movimiento == null)
                throw new Exception("El movimiento no puede ser nulo.");

            if (movimiento.Id_Usuario <= 0)
                throw new Exception("Debe iniciar sesión para registrar un movimiento.");

            if (movimiento.Tipo != MovimientoCaja.INGRESO && movimiento.Tipo != MovimientoCaja.EGRESO)
                throw new Exception("Debe seleccionar el tipo de movimiento (Ingreso o Egreso).");

            if (movimiento.Importe <= 0)
                throw new Exception("El importe debe ser un número mayor a cero.");

            string motivo = (movimiento.Motivo ?? string.Empty).Trim();

            if (motivo.Length == 0)
                throw new Exception("Debe ingresar el motivo del movimiento.");

            if (motivo.Length > LARGO_MAXIMO_MOTIVO)
                throw new Exception("El motivo no puede superar los " + LARGO_MAXIMO_MOTIVO + " caracteres.");

            if (movimiento.Tipo == MovimientoCaja.EGRESO && movimiento.Importe > saldoDisponible)
                throw new Exception("Saldo insuficiente en caja. Saldo disponible: $" + saldoDisponible.ToString("N2") + ".");
        }
    }
}
