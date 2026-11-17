using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    // relacion entre persona y direccion
    public class PersonaDireccion
    {
        public int Id_PersonaDireccion { get; set; }
        public int Id_Persona { get; set; }
        public int Id_Direccion { get; set; }
    }
}
