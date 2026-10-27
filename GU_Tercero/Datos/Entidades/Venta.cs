using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    public class Venta
    {
        public int Id_Venta { get; set; }
        public string? Numero_Factura { get; set; }
        public int Id_Usuario_Vendedor { get; set; }
        public int Id_MetodoPago { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha_Venta { get; set; } = DateTime.Now;

        public List<DetalleVenta> Detalle { get; set; } = new List<DetalleVenta>();

        // Pagos de la venta. Si se paga con un solo método hay un único pago por el total.
        public List<PagoVenta> Pagos { get; set; } = new List<PagoVenta>();

        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;

                foreach (DetalleVenta item in Detalle)
                {
                    subtotal += item.Subtotal;
                }

                return subtotal;
            }
        }

        public decimal TotalNeto
        {
            get
            {
                return Subtotal - CalcularDescuento(Subtotal, DescuentoPorcentaje);
            }
        }

        public decimal TotalPagos
        {
            get
            {
                decimal total = 0;

                foreach (PagoVenta pago in Pagos)
                {
                    total += pago.Importe;
                }

                return total;
            }
        }

        // Redondea igual que SQL Server (ROUND): el ,5 va hacia arriba.
        // Así el total que ve la pantalla es el mismo que calcula sp_RegistrarVenta.
        public static decimal CalcularDescuento(decimal subtotal, decimal porcentaje)
        {
            return Math.Round(subtotal * porcentaje / 100, 2, MidpointRounding.AwayFromZero);
        }
    }
}
