using System;

namespace Logica.Seguridad
{
    public static class DigitoVerificador
    {
        public static int Calcular(string texto)
        {
            int suma = 0;
            int posicion = 0;

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                int valor = Convert.ToInt32(texto[i].ToString(), 16);

                if (posicion % 2 == 0)
                    valor = valor * 2;

                while (valor > 9)
                    valor = (valor / 10) + (valor % 10);

                suma = suma + valor;
                posicion++;
            }

            return (suma * 9) % 10;
        }
    }
}
