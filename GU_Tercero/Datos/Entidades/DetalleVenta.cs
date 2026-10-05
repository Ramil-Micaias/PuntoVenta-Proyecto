using System.Collections.Generic;

namespace Datos.Entidades
{
    public class DetalleVenta
    {
        public int Id_Producto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }

        public decimal Subtotal => Cantidad * Precio_Unitario;
    }
}
