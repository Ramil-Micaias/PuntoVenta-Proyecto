using System;
using System.Security.Cryptography;

namespace Logica.Seguridad
{
    public static class Autenticacion2FAHelper
    {
        public const int LARGO_CODIGO = 6;

        public static string GenerarCodigo()
        {
            string numero = RandomNumberGenerator.GetInt32(0, 100000).ToString("D5");

            return numero + DigitoVerificador.Calcular(numero);
        }

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
