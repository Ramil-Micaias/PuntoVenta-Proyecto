using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    public class Venta
    {
        public int Id_Venta { get; set; }
        public string? Numero_Factura { get; set; }
        public int? Id_Cliente { get; set; }
        public int Id_Usuario_Vendedor { get; set; }
        public int Id_MetodoPago { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha_Venta { get; set; } = DateTime.Now;

        public List<DetalleVenta> Detalle { get; set; } = new List<DetalleVenta>();

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
                decimal montoDescuento = Math.Round(Subtotal * DescuentoPorcentaje / 100, 2);
                return Subtotal - montoDescuento;
            }
        }
    }
}
