using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // linea de referencias que explica los colores de una grilla
    public static class Leyenda
    {
        // colores que se usan en las grillas
        public static readonly Color FONDO_ROJO = Color.FromArgb(254, 226, 226);
        public static readonly Color FONDO_AMARILLO = Color.FromArgb(254, 243, 199);
        public static readonly Color FONDO_BLANCO = Color.White;
        public static readonly Color LETRA_ROJA = Color.FromArgb(239, 68, 68);
        public static readonly Color LETRA_VERDE = Color.FromArgb(16, 185, 129);
        public static readonly Color LETRA_GRIS = Color.FromArgb(148, 163, 184);
        public static readonly Color LETRA_GRIS_OSCURO = Color.FromArgb(100, 116, 139);

        // alto de la linea y espacio con la grilla
        private const int ALTO = 20;
        private const int SEPARACION = 4;

        // agrega las referencias abajo de la grilla, achicando un poco la grilla
        public static FlowLayoutPanel Agregar(DataGridView grilla, params (Color color, bool esFondo, string texto)[] items)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Name = "pnlLeyenda";
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.WrapContents = false;
            panel.BackColor = Color.Transparent;
            panel.Margin = Padding.Empty;
            panel.Padding = Padding.Empty;

            Label titulo = new Label();
            titulo.AutoSize = true;
            titulo.Text = "Referencias:";
            titulo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(30, 41, 59);
            titulo.Margin = new Padding(0, 2, 6, 0);
            panel.Controls.Add(titulo);

            foreach (var item in items)
            {
                panel.Controls.Add(CrearMuestra(item.color, item.esFondo));
                panel.Controls.Add(CrearTexto(item.texto));
            }

            panel.Size = panel.GetPreferredSize(Size.Empty);
            grilla.Height -= ALTO + SEPARACION;

            bool anclaAbajo = (grilla.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom;
            panel.Anchor = (anclaAbajo ? AnchorStyles.Bottom : AnchorStyles.Top) | AnchorStyles.Left;

            grilla.Parent!.Controls.Add(panel);
            panel.Location = new Point(grilla.Left, grilla.Bottom + SEPARACION);
            return panel;
        }

        // cuadradito de muestra: pintado si es fondo, con "Aa" si es color de letra
        private static Control CrearMuestra(Color color, bool esFondo)
        {
            Label muestra = new Label();
            muestra.AutoSize = false;
            muestra.Size = new Size(30, 16);
            muestra.Margin = new Padding(0, 2, 4, 0);
            muestra.BorderStyle = BorderStyle.FixedSingle;
            muestra.TextAlign = ContentAlignment.MiddleCenter;
            muestra.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);

            if (esFondo)
            {
                muestra.BackColor = color;
            }
            else
            {
                muestra.BackColor = Color.White;
                muestra.ForeColor = color;
                muestra.Text = "Aa";
            }

            return muestra;
        }

        // texto de la referencia
        private static Label CrearTexto(string texto)
        {
            Label etiqueta = new Label();
            etiqueta.AutoSize = true;
            etiqueta.Text = texto;
            etiqueta.Font = new Font("Segoe UI", 8.5F);
            etiqueta.ForeColor = Color.FromArgb(30, 41, 59);
            etiqueta.Margin = new Padding(0, 2, 14, 0);
            return etiqueta;
        }
    }
}
