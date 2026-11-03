using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    public class OrdenReparacion
    {
        public int Id_Orden { get; set; }
        public int Id_Equipo { get; set; }
        public int? Id_Tecnico { get; set; }

        public int Id_Usuario { get; set; }

        public int Id_Estado { get; set; }
        public string Falla_Declarada { get; set; } = string.Empty;
        public string? Patron_Clave { get; set; }
        public string? Diagnostico { get; set; }
        public decimal Costo_Mano_Obra { get; set; }
        public DateTime? Fecha_Prometida { get; set; }

        public string? Observacion { get; set; }

        public List<DetalleOrdenRepuesto> Repuestos { get; set; } = new List<DetalleOrdenRepuesto>();

        public decimal Total
        {
            get
            {
                decimal total = Costo_Mano_Obra;

                foreach (DetalleOrdenRepuesto item in Repuestos)
                {
                    total += item.Subtotal;
                }

                return total;
            }
        }
    }
}
