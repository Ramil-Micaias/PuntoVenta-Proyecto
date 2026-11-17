using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    // codigo de verificacion en dos pasos que se manda por mail
    public class Codigo2FA
    {
        public int Id_Codigo2FA { get; set; }
        public int Id_Usuario {  get; set; }
        public string Codigo {  get; set; }
        public DateTime Fecha_Generacion {  get; set; }
        public DateTime Fecha_Expiracion{  get; set; }
        public bool Usado {  get; set; }
    }
}
