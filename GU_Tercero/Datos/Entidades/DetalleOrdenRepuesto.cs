namespace Datos.Entidades
{
    // repuesto usado en una orden de reparacion
    public class DetalleOrdenRepuesto
    {
        public int Id_Producto { get; set; }
        public string Repuesto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }

        // cantidad por precio
        public decimal Subtotal => Cantidad * Precio_Unitario;
    }
}
