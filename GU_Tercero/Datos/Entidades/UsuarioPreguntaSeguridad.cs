using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class UsuarioPreguntaSeguridad
    {
        public int Id_UsuarioPregunta { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Pregunta { get; set; }
        public string RespuestaHash { get; set; }
        public bool Acitvo {  get; set; }
    }
}
