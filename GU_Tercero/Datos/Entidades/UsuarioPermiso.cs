using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class UsuarioPermiso
    {
        public int Id_UsuarioPermiso {  get; set; }
        public int Id_Permiso {  get; set; }
        public int Id_Usuario {  get; set; }
        public bool Concedido { get; set; }
        public string Motivo { get; set; }
    }
}
