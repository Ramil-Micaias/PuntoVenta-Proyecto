using System;

namespace Logica.Seguridad
{
    // Dígito verificador con el algoritmo de Luhn: el mismo método que se usa para el último
    // número de una tarjeta o de un código de barras. Se calcula a partir de los demás números
    // y sirve para comprobar que estén bien. Acepta números o texto hexadecimal (por ejemplo
    // un hash SHA-256) y devuelve un dígito del 0 al 9.
    // Se usa en el código de la verificación en dos pasos y en la contraseña guardada.
    public static class DigitoVerificador
    {
        public static int Calcular(string texto)
        {
            int suma = 0;
            int posicion = 0;

            // Se recorre de derecha a izquierda: las posiciones pares (empezando por la 0) se multiplican por 2.
            for (int i = texto.Length - 1; i >= 0; i--)
            {
                int valor = Convert.ToInt32(texto[i].ToString(), 16);

                if (posicion % 2 == 0)
                    valor = valor * 2;

                // Si el resultado tiene más de un dígito, se suman sus dígitos (por ejemplo 18 -> 1 + 8 = 9).
                while (valor > 9)
                    valor = (valor / 10) + (valor % 10);

                suma = suma + valor;
                posicion++;
            }

            // La suma se multiplica por 9 y el dígito es el resto de dividir por 10.
            return (suma * 9) % 10;
        }
    }
}
