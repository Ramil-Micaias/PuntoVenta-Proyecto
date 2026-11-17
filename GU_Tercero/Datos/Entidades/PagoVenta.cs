namespace Datos.Entidades
{
    // un pago de una venta (metodo e importe)
    public class PagoVenta
    {
        public int Id_MetodoPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }
}
