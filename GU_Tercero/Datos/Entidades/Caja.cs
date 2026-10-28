using System;

namespace Datos.Entidades
{
    // Caja de la jornada con los totales que muestra la pantalla Caja Diaria.
    public class Caja
    {
        public int Id_Caja { get; set; }
        public DateTime Fecha_Apertura { get; set; }
        public decimal Saldo_Inicial { get; set; }
        public bool Abierta { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public string Usuario_Apertura { get; set; } = string.Empty;
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal Saldo_Disponible { get; set; }
    }
}
