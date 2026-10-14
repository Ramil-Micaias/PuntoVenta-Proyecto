using System.Drawing;
using System.Drawing.Imaging;

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
            Asignar(picture, modo, null);
        }

        /// <summary>
        /// Igual que <see cref="CargarLogo"/> pero pinta el logo de un solo color, para que
        /// se vea sobre fondos oscuros. La cabecera es azul y el archivo viene en negro.
        /// </summary>
        public static void CargarLogoBlanco(PictureBox picture, PictureBoxSizeMode modo)
        {
            Asignar(picture, modo, Color.White);
        }

        private static void Asignar(PictureBox picture, PictureBoxSizeMode modo, Color? color)
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
                        picture.Image = Preparar(new Bitmap(original), color);
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

        /// <summary>
        /// Recorta los bordes transparentes y, si se pide, deja el logo de un solo color.
        /// El archivo original es un lienzo de 500x500 con el logo dibujado en el medio:
        /// sin recortar, dentro de un PictureBox chico queda apenas un trazo y no se lee nada.
        /// </summary>
        private static Bitmap Preparar(Bitmap original, Color? color)
        {
            Rectangle contenido = ContenidoOpaco(original);

            if (contenido.Width <= 0 || contenido.Height <= 0)
            {
                return original;
            }

            Bitmap recortado = new Bitmap(contenido.Width, contenido.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(recortado))
            {
                g.DrawImage(original, new Rectangle(0, 0, contenido.Width, contenido.Height), contenido, GraphicsUnit.Pixel);
            }

            original.Dispose();

            return color.HasValue ? Pintar(recortado, color.Value) : recortado;
        }

        /// <summary>
        /// Devuelve el rectángulo que envuelve la parte no transparente de la imagen.
        /// </summary>
        private static Rectangle ContenidoOpaco(Bitmap imagen)
        {
            int minX = imagen.Width;
            int minY = imagen.Height;
            int maxX = -1;
            int maxY = -1;

            for (int y = 0; y < imagen.Height; y++)
            {
                for (int x = 0; x < imagen.Width; x++)
                {
                    if (imagen.GetPixel(x, y).A <= 8)
                    {
                        continue;
                    }

                    if (x < minX) minX = x;
                    if (x > maxX) maxX = x;
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }
            }

            return maxX < 0
                ? Rectangle.Empty
                : Rectangle.FromLTRB(minX, minY, maxX + 1, maxY + 1);
        }

        /// <summary>
        /// Reemplaza cada píxel visible por el color pedido, conservando el canal alfa
        /// para no perder la forma del logo.
        /// </summary>
        private static Bitmap Pintar(Bitmap origen, Color color)
        {
            Bitmap resultado = new Bitmap(origen.Width, origen.Height, PixelFormat.Format32bppArgb);

            for (int y = 0; y < origen.Height; y++)
            {
                for (int x = 0; x < origen.Width; x++)
                {
                    byte alfa = origen.GetPixel(x, y).A;
                    resultado.SetPixel(x, y, Color.FromArgb(alfa, color));
                }
            }

            origen.Dispose();
            return resultado;
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