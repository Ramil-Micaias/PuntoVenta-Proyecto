using System;
using System.Security.Cryptography;

namespace Logica.Seguridad
{
    // genera y valida el formato del codigo 2FA
    public static class Autenticacion2FAHelper
    {
        // 5 numeros al azar + 1 digito verificador
        public const int LARGO_CODIGO = 6;

        // genera el codigo con su digito verificador
        public static string GenerarCodigo()
        {
            string numero = RandomNumberGenerator.GetInt32(0, 100000).ToString("D5");

            return numero + DigitoVerificador.Calcular(numero);
        }

        // controla que tenga 6 numeros y el digito este bien
        public static bool TieneFormatoValido(string? codigo)
        {
            codigo = (codigo ?? string.Empty).Trim();

            if (codigo.Length != LARGO_CODIGO)
            {
                return false;
            }

            foreach (char caracter in codigo)
            {
                if (!char.IsDigit(caracter))
                {
                    return false;
                }
            }

            string numero = codigo.Substring(0, LARGO_CODIGO - 1);
            int digitoVerificador = codigo[LARGO_CODIGO - 1] - '0';

            return DigitoVerificador.Calcular(numero) == digitoVerificador;
        }
    }
}
