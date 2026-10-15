using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // Estilo y comportamiento comunes para las grillas del sistema.
    public static class Grillas
    {
        // Aplica el estilo de la aplicación y oculta las columnas de ID cada vez que la grilla se carga.
        public static void Configurar(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.FromArgb(226, 232, 240);
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.FromArgb(203, 213, 225);
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 26;

            grid.DataBindingComplete += (s, e) => OcultarIds(grid);
        }

        // Oculta todas las columnas de identificadores internos (Id_...).
        public static void OcultarIds(DataGridView grid)
        {
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                if (columna.Name.StartsWith("Id_") || columna.Name == "Id")
                {
                    columna.Visible = false;
                }
            }
        }
    }
}
