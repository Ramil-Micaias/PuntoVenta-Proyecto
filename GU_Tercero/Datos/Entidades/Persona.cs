using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Persona
    {
        public int Id_Persona {  get; set; }
        public string Apellido {  get; set; }
        public string Nombre {  get; set; }
        public string DNI {  get; set; }
        public DateTime Fecha_Alta {  get; set; }
        public DateTime? Fecha_Baja {  get; set; }
        public DateTime? Fecha_Nacimiento {  get; set; }
        public bool Activo {  get; set; }
        
    }
}
