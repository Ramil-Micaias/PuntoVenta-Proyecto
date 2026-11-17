using System;

namespace Logica.Seguridad
{
    // digito verificador con el algoritmo de Luhn
    public static class DigitoVerificador
    {
        // calcula el digito de un texto en hexadecimal
        public static int Calcular(string texto)
        {
            int suma = 0;
            int posicion = 0;

            // se recorre de derecha a izquierda y se duplica uno si y uno no
            for (int i = texto.Length - 1; i >= 0; i--)
            {
                int valor = Convert.ToInt32(texto[i].ToString(), 16);

                if (posicion % 2 == 0)
                    valor = valor * 2;

                // si queda de dos cifras se suman las cifras
                while (valor > 9)
                    valor = (valor / 10) + (valor % 10);

                suma = suma + valor;
                posicion++;
            }

            // el digito es el que completa la suma
            return (suma * 9) % 10;
        }
    }
}
