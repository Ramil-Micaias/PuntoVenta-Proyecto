using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Logica.Seguridad
{
    // Clase centralizada para el hasheo de contraseñas y respuestas de seguridad.
    // La normalización de las respuestas vive acá y no en las pantallas: antes cada
    // formulario aplicaba su propia versión (uno con ToLower y otro sin él), por lo que
    // el hash guardado nunca coincidía con el hash calculado al recuperar la contraseña.
    public static class HashHelper
    {
        // Genera un hash SHA256 a partir de un texto.
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

        // Hash de una contraseña con su dígito verificador al final: SHA-256 de usuario + contraseña
        // (64 caracteres hexadecimales) más un dígito del 0 al 9 calculado con DigitoVerificador (algoritmo de Luhn),
        // igual que el último número de un código de barras o de un CUIT.
        public static string GenerarHashPassword(string nombreUsuario, string password)
        {
            string hash = GenerarSHA256(nombreUsuario + password);
            return hash + DigitoVerificador.Calcular(hash);
        }

        // Controla que el hash guardado no se haya alterado: el último dígito tiene que coincidir
        // con el que se calcula a partir de los 64 caracteres anteriores.
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

        // Normaliza una respuesta de seguridad antes de hashearla, de modo que
        // "Firulais", " firulais " y "FIRULAIS" produzcan siempre el mismo hash.
        public static string NormalizarRespuesta(string? respuesta)
        {
            return respuesta == null ? string.Empty : respuesta.Trim().ToLowerInvariant();
        }

        // Hash oficial de una respuesta de seguridad. Tanto el alta como la validación
        // deben usar este método para que los hashes sean comparables.
        public static string GenerarHashRespuesta(string? respuesta)
        {
            return GenerarSHA256(NormalizarRespuesta(respuesta));
        }

        // Reproduce el hash que generaban las versiones anteriores del sistema, que
        // guardaban la respuesta sin pasar a minúsculas. Sirve para poder recuperar la
        // contraseña de los usuarios que ya tienen respuestas cargadas en la base.
        public static string GenerarHashRespuestaLegado(string? respuesta)
        {
            return GenerarSHA256(respuesta == null ? string.Empty : respuesta.Trim());
        }

        // Compara dos hashes sin filtrar información por tiempos de ejecución.
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
