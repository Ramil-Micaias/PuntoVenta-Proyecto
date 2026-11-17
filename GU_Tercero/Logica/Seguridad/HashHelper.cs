using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Logica.Seguridad
{
    // hash de contrasenias y respuestas
    public static class HashHelper
    {
        // hash SHA-256 del texto en hexadecimal
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

        // hash de usuario + contrasenia y al final el digito verificador (65 caracteres)
        public static string GenerarHashPassword(string nombreUsuario, string password)
        {
            string hash = GenerarSHA256(nombreUsuario + password);
            return hash + DigitoVerificador.Calcular(hash);
        }

        // controla que el hash guardado tenga bien el digito verificador
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

        // respuesta sin espacios y en minuscula
        public static string NormalizarRespuesta(string? respuesta)
        {
            return respuesta == null ? string.Empty : respuesta.Trim().ToLowerInvariant();
        }

        // hash de la respuesta de seguridad
        public static string GenerarHashRespuesta(string? respuesta)
        {
            return GenerarSHA256(NormalizarRespuesta(respuesta));
        }

        // hash viejo de las respuestas (sin pasar a minuscula), para usuarios anteriores
        public static string GenerarHashRespuestaLegado(string? respuesta)
        {
            return GenerarSHA256(respuesta == null ? string.Empty : respuesta.Trim());
        }

        // compara los hash en tiempo fijo
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
