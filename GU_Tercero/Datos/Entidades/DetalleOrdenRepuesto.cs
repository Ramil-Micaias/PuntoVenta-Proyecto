namespace Datos.Entidades
{
    // Repuesto usado en una orden de reparación.
    public class DetalleOrdenRepuesto
    {
        public int Id_Producto { get; set; }
        public string Repuesto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }

        public decimal Subtotal => Cantidad * Precio_Unitario;
    }
}
