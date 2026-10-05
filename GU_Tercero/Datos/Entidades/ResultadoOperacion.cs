namespace Datos.Entidades
{
    public class ResultadoOperacion
    {
        public int Id_Operacion { get; set; }
        public string? Comprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
