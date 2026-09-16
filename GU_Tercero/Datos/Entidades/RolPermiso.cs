using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class RolPermiso
    {
        public int Id_RolPermiso { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Permiso { get; set; }
        public bool Activo { get; set; }

    }
}
