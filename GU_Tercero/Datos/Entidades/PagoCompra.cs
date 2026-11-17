namespace Datos.Entidades
{
    // un pago de una compra (metodo e importe)
    public class PagoCompra
    {
        public int Id_MetodoPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }
}
