using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Logica
{
    // Validaciones de formato que se usan en varias pantallas (proveedores, usuarios, clientes).
    public static class Validaciones
    {
        // Prefijos válidos de CUIT/CUIL: personas (20, 23, 24, 27) y empresas (30, 33, 34).
        private static readonly string[] PrefijosCuit = { "20", "23", "24", "27", "30", "33", "34" };

        // Email con formato nombre@dominio.algo: un solo @, sin espacios y con punto en el dominio.
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

        // Teléfono: solo números, espacios, guiones, + y paréntesis, con entre 8 y 15 números.
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

        // CUIT: 11 números (con o sin guiones), prefijo válido y dígito verificador correcto (módulo 11).
        // Si es válido devuelve true y en "normalizado" el CUIT con formato XX-XXXXXXXX-X.
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
