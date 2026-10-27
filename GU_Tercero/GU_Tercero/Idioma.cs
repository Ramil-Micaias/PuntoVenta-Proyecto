using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Vista
{
    // CU18 Gestión de Múltiples Idiomas. Basada en la clase Idioma del ejemplo
    // "Ejemplo_Multilenguaje" del profesor: los textos están en Idiomas\Strings.resx
    // (Español, idioma por defecto) e Idiomas\Strings.en-US.resx (Inglés).
    // La clave de cada texto es el nombre del control; si falta la traducción
    // de un texto en inglés, el ResourceManager devuelve el de Español (flujo 2.1).
    // Solo la usa el formulario de Productos.
    public class Idioma
    {
        public const string ESPANOL = "es-AR";
        public const string INGLES = "en-US";

        private static readonly ResourceManager Strings =
            new ResourceManager("Vista.Idiomas.Strings", typeof(Idioma).Assembly);

        public String Nombre { get; set; } = string.Empty;
        public String Abreviacion { get; set; } = string.Empty;
        public String Pais { get; set; } = string.Empty;
        public String AbreviacionPais { get; set; } = string.Empty;
        public String NombrePais { get => Nombre + "(" + Pais + ")"; }
        public String InfoCultura { get => Abreviacion + "-" + AbreviacionPais; }

        // Idioma elegido en el formulario. Cada vez que se abre Productos vuelve a Español.
        public static string Actual { get; set; } = ESPANOL;

        public static List<Idioma> ObtenerIdiomas()
        {
            return new List<Idioma> {
                new Idioma
                {
                    Nombre = "Español",
                    Abreviacion = "es",
                    Pais = "Argentina",
                    AbreviacionPais = "AR"
                },
                new Idioma
                {
                    Nombre = "English",
                    Abreviacion = "en",
                    Pais = "Estados Unidos",
                    AbreviacionPais = "US"
                }
            };
        }

        // Aplica el idioma actual al formulario y a todos sus controles.
        public static void CargarIdioma(Control.ControlCollection controls, Form frm)
        {
            string? titulo = Texto(frm.Name);
            if (titulo != null)
            {
                frm.Text = titulo;
            }

            CambiarTexto(controls);
        }

        // Devuelve el texto de la clave en el idioma actual (o null si no existe en ningún idioma).
        public static string? Texto(string clave)
        {
            return Strings.GetString(clave, new CultureInfo(Actual));
        }

        // Igual que Texto, pero si la clave no existe devuelve el texto por defecto.
        public static string Texto(string clave, string porDefecto)
        {
            return Texto(clave) ?? porDefecto;
        }

        // Traduce los títulos de las columnas de una grilla (clave "Columna_" + nombre de la columna).
        public static void TraducirColumnas(DataGridView grid)
        {
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                string? text = Texto("Columna_" + columna.Name);
                if (text != null)
                {
                    columna.HeaderText = text;
                }
            }
        }

        private static void CambiarTexto(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                // El ejemplo recorría Panel y GroupBox; acá también hay pestañas (TabControl)
                // y paneles de botones, por eso se entra en todo control que tenga hijos.
                if (c.HasChildren)
                {
                    CambiarTexto(c.Controls);
                }

                String? text = Texto(c.Name);
                if (text != null)
                {
                    c.Text = text;
                }

                if (c is TextBox txt)
                {
                    String? placeholder = Texto(c.Name + "_Placeholder");
                    if (placeholder != null)
                    {
                        txt.PlaceholderText = placeholder;
                    }
                }

                if (c is DataGridView grid)
                {
                    TraducirColumnas(grid);
                }
            }
        }
    }
}
