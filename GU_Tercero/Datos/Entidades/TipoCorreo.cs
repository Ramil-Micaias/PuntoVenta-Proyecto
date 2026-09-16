using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class TipoCorreo
    {
        public int Id_TipoCorreo {  get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
