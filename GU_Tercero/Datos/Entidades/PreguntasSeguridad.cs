using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class PreguntasSeguridad
    {
        public int Id_Pregunta { get; set; }
        public string Pregunta { get; set; } 

        public bool Activo {  get; set; }
    }
}
