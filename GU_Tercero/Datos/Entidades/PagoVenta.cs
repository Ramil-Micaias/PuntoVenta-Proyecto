namespace Datos.Entidades
{
    // Un pago de una venta. Una venta puede tener varios (por ejemplo efectivo + tarjeta).
    public class PagoVenta
    {
        public int Id_MetodoPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }
}
