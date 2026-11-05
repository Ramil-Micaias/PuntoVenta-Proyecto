using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Logica
{
    public static class Validaciones
    {
        private static readonly string[] PrefijosCuit = { "20", "23", "24", "27", "30", "33", "34" };

        public static bool EsEmailValido(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$"))
                return false;

            try
            {
                return new MailAddress(email).Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool EsDniValido(string? dni)
        {
            return !string.IsNullOrWhiteSpace(dni) && Regex.IsMatch(dni.Trim(), @"^[0-9]{7,8}$");
        }

        public static bool EsNombreValido(string? texto)
        {
            return !string.IsNullOrWhiteSpace(texto)
                && texto.Trim().Length <= 50
                && Regex.IsMatch(texto.Trim(), @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' \-]+$");
        }

        public static bool EsNombreUsuarioValido(string? usuario)
        {
            return !string.IsNullOrWhiteSpace(usuario) && Regex.IsMatch(usuario.Trim(), @"^[A-Za-z0-9._\-]{3,50}$");
        }

        public static bool EsTelefonoValido(string? telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            telefono = telefono.Trim();

            if (!Regex.IsMatch(telefono, @"^\+?[0-9\s\-()]+$"))
                return false;

            int digitos = telefono.Count(char.IsDigit);
            return digitos >= 8 && digitos <= 15;
        }

        public static bool EsCuitValido(string? cuit, out string normalizado)
        {
            normalizado = string.Empty;

            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            string limpio = cuit.Trim().Replace("-", string.Empty).Replace(" ", string.Empty);

            if (limpio.Length != 11 || !limpio.All(char.IsDigit))
                return false;

            if (!PrefijosCuit.Contains(limpio.Substring(0, 2)))
                return false;

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (limpio[i] - '0') * multiplicadores[i];
            }

            int resto = 11 - (suma % 11);
            int verificador = resto == 11 ? 0 : (resto == 10 ? 9 : resto);

            if (verificador != limpio[10] - '0')
                return false;

            normalizado = limpio.Substring(0, 2) + "-" + limpio.Substring(2, 8) + "-" + limpio.Substring(10, 1);
            return true;
        }
    }
}
