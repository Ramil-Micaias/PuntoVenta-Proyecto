namespace Datos.Entidades
{
    // Un pago de una compra. Una compra puede tener varios (por ejemplo efectivo + transferencia).
    public class PagoCompra
    {
        public int Id_MetodoPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }
}
