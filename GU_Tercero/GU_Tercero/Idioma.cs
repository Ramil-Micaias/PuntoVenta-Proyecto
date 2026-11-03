using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Vista
{
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

        public static void CargarIdioma(Control.ControlCollection controls, Form frm)
        {
            string? titulo = Texto(frm.Name);
            if (titulo != null)
            {
                frm.Text = titulo;
            }

            CambiarTexto(controls);
        }

        public static string? Texto(string clave)
        {
            return Strings.GetString(clave, new CultureInfo(Actual));
        }

        public static string Texto(string clave, string porDefecto)
        {
            return Texto(clave) ?? porDefecto;
        }

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
