using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Partido
    {
        public int Id_Partido { get; set; }
        public int Id_Provincia { get; set; }
        public string Nombre_Partido { get; set; }
        public bool Activo { get; set; }
    }
}
