using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Telefono
    {
        public int Id_Telefono { get; set; }
        public int Id_TipoTelefono { get; set; }
        public int Id_Persona { get; set; }
        public string Numero { get; set; }

        public bool Activo {  get; set; }

        public DateTime Fecha_Baja { get; set; }
    }
}
