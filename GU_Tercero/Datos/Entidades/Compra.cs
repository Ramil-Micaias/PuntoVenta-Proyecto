using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    // compra a proveedores con su detalle y sus pagos
    public class Compra
    {
        public int Id_Compra { get; set; }
        public string? Numero_Comprobante { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_MetodoPago { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha_Compra { get; set; } = DateTime.Now;

        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();

        public List<PagoCompra> Pagos { get; set; } = new List<PagoCompra>();

        // suma de lo que se pago
        public decimal TotalPagos
        {
            get
            {
                decimal total = 0;

                foreach (PagoCompra pago in Pagos)
                {
                    total += pago.Importe;
                }

                return total;
            }
        }

        // suma de los subtotales del detalle
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;

                foreach (DetalleCompra item in Detalles)
                {
                    subtotal += item.Subtotal;
                }

                return subtotal;
            }
        }
    }
}
