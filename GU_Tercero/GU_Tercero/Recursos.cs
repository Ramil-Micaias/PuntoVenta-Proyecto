using System.Drawing;

namespace GU_Tercero
{
    /// <summary>
    /// Carga el archivo del logo desde la carpeta de salida o, si no está ahí,
    /// desde la carpeta del proyecto. Reemplaza la búsqueda con rutas fijas que
    /// dejaba el logo sin mostrar cuando el ejecutable se corría desde otro equipo.
    /// </summary>
    internal static class Recursos
    {
        private const string ArchivoLogo = "loguito trtansparente.png";

        /// <summary>
        /// Asigna el logo al PictureBox recibido. Si el archivo no aparece en ninguna
        /// de las rutas conocidas, el PictureBox simplemente queda vacío.
        /// </summary>
        public static void CargarLogo(PictureBox picture, PictureBoxSizeMode modo)
        {
            try
            {
                picture.Image = null;

                foreach (string ruta in RutasPosibles())
                {
                    if (!System.IO.File.Exists(ruta))
                    {
                        continue;
                    }

                    // Se copia el archivo para no dejar el PNG bloqueado en disco.
                    using (Image original = Image.FromFile(ruta))
                    {
                        picture.Image = new Bitmap(original);
                    }

                    picture.SizeMode = modo;
                    return;
                }
            }
            catch
            {
                picture.Image = null;
            }
        }

        private static string[] RutasPosibles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            return new[]
            {
                System.IO.Path.Combine(Application.StartupPath, ArchivoLogo),
                System.IO.Path.Combine(baseDir, ArchivoLogo),
                System.IO.Path.Combine(baseDir, System.IO.Path.Combine(@"..\..\..", ArchivoLogo)),
                System.IO.Path.Combine(baseDir, System.IO.Path.Combine(@"..\..\..\..", ArchivoLogo))
            };
        }
    }
}