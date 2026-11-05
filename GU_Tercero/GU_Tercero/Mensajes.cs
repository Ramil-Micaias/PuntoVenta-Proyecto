using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public static class Mensajes
    {
        public static readonly Color VERDE = Color.FromArgb(16, 185, 129);

        public static void Exito(Control destino, string texto)
        {
            destino.ForeColor = VERDE;
            destino.Text = texto;
            destino.Visible = true;
        }

        public static void Limpiar(Control destino)
        {
            destino.Text = string.Empty;
            destino.Visible = false;
        }
    }
}
