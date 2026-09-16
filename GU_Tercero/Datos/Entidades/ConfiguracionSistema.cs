using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
    {
        public class ConfiguracionSistema
        {
            public int Id_Configuracion { get; set; }

            public int Min_Caracteres { get; set; }

            public bool Requiere_Mayusculas { get; set; }

            public bool Requiere_Numeros { get; set; }

            public bool Requiere_Especial { get; set; }

            public bool Habilitar_2FA { get; set; }

            public bool Validar_DatosPersonales { get; set; }

            public bool No_RepetirPasswords { get; set; }

            public int Cantidad_HistorialPasswords { get; set; }

            public int Cantidad_Preguntas { get; set; }
        }
}


