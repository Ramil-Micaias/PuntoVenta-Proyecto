using System;

namespace Datos.Entidades
{
    public class Proveedor
    {
        public int Id_Proveedor { get; set; }
        public string Razon_Social { get; set; } = string.Empty;
        public string? CUIT { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public bool Activo { get; set; } = true;
    }
}
