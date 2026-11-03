namespace Datos.Entidades
{
    public class PagoCompra
    {
        public int Id_MetodoPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }
}
