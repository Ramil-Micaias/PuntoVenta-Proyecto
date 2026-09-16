using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Seguridad
{
    // Esta clase genera el código de verificación utilizado en la autenticación en dos pasos (2FA).
    public static class Autenticacion2FAHelper
    {
        // Genera un código numérico aleatorio de 6 dígitos.
        public static string GenerarCodigo()
        {
            Random random = new Random();

            return random.Next(100000, 999999).ToString();
        }
    }
}