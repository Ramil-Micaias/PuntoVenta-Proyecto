using Datos;
using Datos.Entidades;
using System;
using System.Data;

namespace Logica
{
    // logica de la caja diaria
    public class GestorCaja
    {
        // largo maximo del motivo de un movimiento
        public const int LARGO_MAXIMO_MOTIVO = 200;

        private readonly CajaDAO cajaDAO = new CajaDAO();
        private readonly MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAO();

        // caja abierta o null
        public Caja? ObtenerCajaActual()
        {
            return cajaDAO.ObtenerCajaActual();
        }

        // movimientos de la caja
        public DataTable ListarMovimientos(int idCaja)
        {
            return cajaDAO.ListarMovimientos(idCaja);
        }

        // valida el saldo inicial, abre la caja y lo deja en la bitacora
        public void AbrirCaja(int idUsuario, decimal saldoInicial)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para abrir la caja.");

            if (saldoInicial < 0)
                throw new Exception("El saldo inicial no puede ser negativo.");

            cajaDAO.AbrirCaja(idUsuario, saldoInicial);

            GestorBitacora.Registrar(GestorBitacora.CAJA, "Apertura de caja.", GestorBitacora.INFORMATIVA, null,
                new System.Collections.Generic.Dictionary<string, object?> { ["Saldo_Inicial"] = saldoInicial });
        }

        // cierra la caja y devuelve el saldo final
        public decimal CerrarCaja(int idCaja, int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para cerrar la caja.");

            decimal saldoFinal = cajaDAO.CerrarCaja(idCaja, idUsuario);

            GestorBitacora.Registrar(GestorBitacora.CAJA, "Cierre de caja.", GestorBitacora.INFORMATIVA,
                new System.Collections.Generic.Dictionary<string, object?> { ["Estado"] = "Abierta" },
                new System.Collections.Generic.Dictionary<string, object?> { ["Estado"] = "Cerrada", ["Saldo_Final"] = saldoFinal });

            return saldoFinal;
        }

        // metodos de pago para el filtro del historial
        public DataTable ObtenerMetodosPago()
        {
            return metodoPagoDAO.ObtenerMetodosPago();
        }

        // cajas de un periodo, valida las fechas antes
        public DataTable ListarCajas(DateTime desde, DateTime hasta)
        {
            ValidarPeriodo(desde, hasta);
            return cajaDAO.ListarCajas(desde, hasta);
        }

        // movimientos de un periodo
        public DataTable ListarMovimientosPeriodo(DateTime desde, DateTime hasta, int? idMetodoPago)
        {
            ValidarPeriodo(desde, hasta);
            return cajaDAO.ListarMovimientosPeriodo(desde.Date, hasta.Date.AddDays(1), idMetodoPago);
        }

        // movimientos entre la apertura y el cierre de una caja
        public DataTable ListarMovimientosDeCaja(DateTime inicio, DateTime fin, int? idMetodoPago)
        {
            return cajaDAO.ListarMovimientosPeriodo(inicio, fin, idMetodoPago);
        }

        // la fecha desde no puede ser mayor que la hasta
        private static void ValidarPeriodo(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
                throw new Exception("La fecha desde no puede ser posterior a la fecha hasta.");
        }

        // reabre una caja cerrada, queda como operacion critica en la bitacora
        public void ReabrirCaja(int idCaja, int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Debe iniciar sesión para reabrir la caja.");

            cajaDAO.ReabrirCaja(idCaja, idUsuario);

            GestorBitacora.Registrar(GestorBitacora.CAJA, "Reapertura de una caja cerrada.", GestorBitacora.CRITICA,
                new System.Collections.Generic.Dictionary<string, object?> { ["Estado"] = "Cerrada" },
                new System.Collections.Generic.Dictionary<string, object?> { ["Estado"] = "Abierta" });
        }

        // valida y guarda un ingreso o egreso manual
        public decimal RegistrarMovimiento(MovimientoCaja movimiento, decimal saldoDisponible)
        {
            ValidarMovimiento(movimiento, saldoDisponible);
            decimal saldo = cajaDAO.RegistrarMovimiento(movimiento);

            GestorBitacora.Registrar(GestorBitacora.CAJA, movimiento.Tipo + " manual de caja: " + movimiento.Motivo.Trim() + ".",
                GestorBitacora.ADVERTENCIA,
                new System.Collections.Generic.Dictionary<string, object?> { ["Saldo"] = saldoDisponible },
                new System.Collections.Generic.Dictionary<string, object?> { ["Importe"] = movimiento.Importe, ["Saldo"] = saldo });

            return saldo;
        }

        // importe mayor a cero, motivo obligatorio y que el egreso no supere el saldo
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
