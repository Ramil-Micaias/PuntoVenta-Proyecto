using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Logica.Seguridad
{
    public static class HashHelper
    {
        public static string GenerarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);

                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static string GenerarHashPassword(string nombreUsuario, string password)
        {
            string hash = GenerarSHA256(nombreUsuario + password);
            return hash + DigitoVerificador.Calcular(hash);
        }

        public static bool DigitoVerificadorValido(string? hashGuardado)
        {
            if (string.IsNullOrEmpty(hashGuardado) || hashGuardado.Length != 65)
            {
                return false;
            }

            string hash = hashGuardado.Substring(0, 64);

            return hash.All(Uri.IsHexDigit)
                && DigitoVerificador.Calcular(hash).ToString() == hashGuardado.Substring(64);
        }

        public static string NormalizarRespuesta(string? respuesta)
        {
            return respuesta == null ? string.Empty : respuesta.Trim().ToLowerInvariant();
        }

        public static string GenerarHashRespuesta(string? respuesta)
        {
            return GenerarSHA256(NormalizarRespuesta(respuesta));
        }

        public static string GenerarHashRespuestaLegado(string? respuesta)
        {
            return GenerarSHA256(respuesta == null ? string.Empty : respuesta.Trim());
        }

        public static bool CompararHashSeguro(string? hashAlmacenado, string? hashCalculado)
        {
            if (string.IsNullOrEmpty(hashAlmacenado) || string.IsNullOrEmpty(hashCalculado))
            {
                return false;
            }

            byte[] almacenado = Encoding.UTF8.GetBytes(hashAlmacenado);
            byte[] calculado = Encoding.UTF8.GetBytes(hashCalculado);

            if (almacenado.Length != calculado.Length)
            {
                return false;
            }

            return CryptographicOperations.FixedTimeEquals(almacenado, calculado);
        }
    }
}
