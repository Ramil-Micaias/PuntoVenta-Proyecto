using System;
using System.Collections.Generic;

namespace Datos.Entidades
{
    // Orden de reparación del taller (CU05 / CU09).
    public class OrdenReparacion
    {
        public int Id_Orden { get; set; }
        public int Id_Equipo { get; set; }
        public int? Id_Tecnico { get; set; }

        // Usuario que guarda la orden: en el alta es quien recibe el equipo
        // y en las actualizaciones queda registrado en el historial.
        public int Id_Usuario { get; set; }

        public int Id_Estado { get; set; }
        public string Falla_Declarada { get; set; } = string.Empty;
        public string? Patron_Clave { get; set; }
        public string? Diagnostico { get; set; }
        public decimal Costo_Mano_Obra { get; set; }
        public DateTime? Fecha_Prometida { get; set; }

        // Comentario que se guarda en el historial cuando cambia el estado.
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
