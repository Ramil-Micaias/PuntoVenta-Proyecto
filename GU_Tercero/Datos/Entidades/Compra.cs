using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    public class Compra
    {
        public int Id_Compra { get; set; }
        public string? Numero_Comprobante { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Usuario { get; set; }
        public int? Id_MetodoPago { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha_Compra { get; set; } = DateTime.Now;

        public List<DetalleCompra> Detalle { get; set; } = new List<DetalleCompra>();

        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;

                foreach (DetalleCompra item in Detalle)
                {
                    subtotal += item.Subtotal;
                }

                return subtotal;
            }
        }
    }
}
