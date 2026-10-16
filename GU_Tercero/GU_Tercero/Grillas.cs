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
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(15, 23, 42);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = AltoFila(grid);

            grid.DataBindingComplete += Grilla_DataBindingComplete;
        }

        // Alto de fila según la fuente, para que el texto no se corte con escalado de pantalla alto.
        public static int AltoFila(DataGridView grid)
        {
            return grid.DefaultCellStyle.Font.Height + 12;
        }

        private static void Grilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            OcultarIds(grid);
            TitulosLegibles(grid);
        }

        // Oculta todas las columnas de identificadores internos (Id_...).
        public static void OcultarIds(DataGridView grid)
        {
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                if (columna.Name.StartsWith("Id_"))
                {
                    columna.Visible = false;
                }
            }
        }

        // Cambia los nombres de columna de la base por títulos legibles.
        // Ejemplo: "Razon_Social" pasa a "Razon Social".
        private static void TitulosLegibles(DataGridView grid)
        {
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                if (columna.HeaderText != columna.Name)
                {
                    continue;
                }

                if (columna.Name == "NombreCategoria")
                {
                    columna.HeaderText = "Categoría";
                }
                else
                {
                    columna.HeaderText = columna.Name.Replace("_", " ");
                }
            }
        }
    }
}
