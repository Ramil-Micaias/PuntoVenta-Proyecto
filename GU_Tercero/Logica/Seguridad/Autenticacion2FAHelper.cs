using System;
using System.Security.Cryptography;

namespace Logica.Seguridad
{
    // Esta clase genera y controla el código de verificación utilizado en la autenticación en dos pasos (2FA).
    // El código tiene 6 dígitos: 5 al azar + 1 dígito verificador calculado con AplicaLhun (algoritmo de Luhn).
    // Así, si el usuario se equivoca al tipear un número, se detecta sin consultar la base.
    public static class Autenticacion2FAHelper
    {
        public const int LARGO_CODIGO = 6;

        // Genera un código numérico de 6 dígitos con dígito verificador.
        public static string GenerarCodigo()
        {
            // RandomNumberGenerator es seguro para códigos de acceso (Random es predecible).
            string numero = RandomNumberGenerator.GetInt32(0, 100000).ToString("D5");

            return numero + AplicaLhun.Calcular(numero);
        }

        // Verifica que el código tenga 6 dígitos y que el último sea el dígito verificador correcto.
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

            return AplicaLhun.Calcular(numero) == digitoVerificador;
        }
    }
}
