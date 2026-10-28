using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // Mensajes de operación exitosa escritos dentro de la pantalla (en verde),
    // igual que en Compras, en lugar de un cuadro de mensaje.
    // Los errores, advertencias y confirmaciones siguen usando MessageBox.
    public static class Mensajes
    {
        public static readonly Color VERDE = Color.FromArgb(16, 185, 129);

        public static void Exito(Control destino, string texto)
        {
            destino.ForeColor = VERDE;
            destino.Text = texto;
            destino.Visible = true;
        }

        // Se oculta además de vaciarse: un Label vacío igual tapa lo que tenga debajo.
        public static void Limpiar(Control destino)
        {
            destino.Text = string.Empty;
            destino.Visible = false;
        }
    }
}
