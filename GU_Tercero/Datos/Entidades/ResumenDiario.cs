namespace Datos.Entidades
{
    public class ResumenDiario
    {
        public decimal Total_Ventas_Dia { get; set; }
        public int Cantidad_Ventas_Dia { get; set; }
        public int Ordenes_Taller_Activas { get; set; }
        public int Productos_Stock_Bajo { get; set; }
        public decimal Total_Compras_Dia { get; set; }
        public int Cantidad_Compras_Dia { get; set; }
    }
}
