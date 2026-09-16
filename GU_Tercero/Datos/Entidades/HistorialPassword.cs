using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class HistorialPassword
    {
        public int Id_HistorialPassword {  get; set; }
        public int Id_Usuario {  get; set; }
        public string PasswordHash {  get; set; }
        public DateTime Fecha_Cambio {  get; set; }
    }
}
