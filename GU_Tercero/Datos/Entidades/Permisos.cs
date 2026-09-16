using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Permisos
    {
        public int Id_Permiso {  get; set; }
        public string Codigo {  get; set; }
        public string Descripcion {  get; set; }
        public string Modulo {  get; set; }
        public bool Activo {  get; set; }
    }
}
