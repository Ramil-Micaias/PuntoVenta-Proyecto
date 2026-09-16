using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Localidad
    {
        public int Id_Localidad {  get; set; }
        public int Id_Partido {  get; set; }
        public string Nombre_Localidad {  get; set; }
        public string Codigo_Postal {  get; set; }
        public bool Activo {  get; set; }
    }
}
