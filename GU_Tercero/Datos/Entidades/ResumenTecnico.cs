namespace Datos.Entidades
{
    // Trabajo del técnico en el taller que se muestra en el menú principal.
    public class ResumenTecnico
    {
        public int Ordenes_Asignadas { get; set; }
        public int Ordenes_Terminadas { get; set; }
        public decimal Total_Reparaciones { get; set; }
    }
}
