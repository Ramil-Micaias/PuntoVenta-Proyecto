using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // mensajes de exito en verde dentro del formulario
    public static class Mensajes
    {
        public static readonly Color VERDE = Color.FromArgb(16, 185, 129);

        // muestra el mensaje en verde
        public static void Exito(Control destino, string texto)
        {
            destino.ForeColor = VERDE;
            destino.Text = texto;
            destino.Visible = true;
        }

        // borra y oculta el mensaje
        public static void Limpiar(Control destino)
        {
            destino.Text = string.Empty;
            destino.Visible = false;
        }
    }
}
