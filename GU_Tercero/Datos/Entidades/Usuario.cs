using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {
        public int Id_Usuario {  get; set; }
        public int Id_Persona { get; set; }
        public int Id_Rol { get; set; }
        public string Nombre_Usuario { get; set; }
        public string PasswordHash { get; set; }
        public string Nombre_Rol { get; set; }
        public DateTime? Fecha_Ultimo_Cambio { get; set; }

        public bool Debe_Cambiar_Password {  get; set; }

        public bool Es_Primer_Ingreso { get; set; }

        public DateTime? Fecha_Alta {  get; set; }

        public DateTime? Fecha_Baja { get; set; }

        public int Intentos_Fallidos { get; set; }

        public bool Bloqueado {  get; set; }

        public DateTime? Fecha_Bloqueo { get; set; }

        public DateTime? Ultimo_Login { get; set; }

        public bool Activo {  get; set; }

    }
}
