using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Correo
    {
        public int Id_Correo { get; set; }
        public int Id_TipoCorreo {  get; set; }

        public int Id_Persona { get; set; }

        public string Direccion_Correo { get; set; }

        public bool Verificado { get; set; }

        public DateTime Fecha_Verificacion { get; set; }

        public bool Activo { get; set; }
    }
}
