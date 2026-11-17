namespace Datos.Entidades
{
    // un producto dentro de una compra
    public class DetalleCompra
    {
        public int Id_Producto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio_Costo_Unitario { get; set; }

        // cantidad por costo unitario
        public decimal Subtotal => Cantidad * Precio_Costo_Unitario;
    }
}
