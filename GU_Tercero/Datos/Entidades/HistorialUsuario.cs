using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class HistorialUsuario
    {
        public int Id_HistorialUsuario { get; set; }
        public int Id_Usuario { get; set; }
        public string Tipo_Movimiento { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public string Motivo { get; set; }
    }
}
