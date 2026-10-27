using System;

namespace Datos.Entidades
{
    public class MovimientoCaja
    {
        public const string INGRESO = "Ingreso";
        public const string EGRESO = "Egreso";

        public int Id_Movimiento { get; set; }
        public int Id_Caja { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Importe { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public int Id_Usuario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
