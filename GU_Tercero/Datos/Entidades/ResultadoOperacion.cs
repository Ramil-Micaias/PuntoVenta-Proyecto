namespace Datos.Entidades
{
    // lo que devuelven los sp de venta, compra y orden: id, comprobante y totales
    public class ResultadoOperacion
    {
        public int Id_Operacion { get; set; }
        public string? Comprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
