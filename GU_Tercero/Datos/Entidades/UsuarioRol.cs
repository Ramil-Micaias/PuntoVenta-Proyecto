using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class UsuarioRol
    {
        public int Id_UsuarioRol {  get; set; }

        public int Id_Rol { get; set; }
        public int Id_Usuario{  get; set; }

        public DateTime Fecha_Asignacion { get; set; }
    }
}
