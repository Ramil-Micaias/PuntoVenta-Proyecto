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
