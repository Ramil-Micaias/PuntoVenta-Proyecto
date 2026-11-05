using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormBitacora : Form
    {
        private static readonly Color ROJO = Color.FromArgb(185, 28, 28);
        private static readonly Color NARANJA = Color.FromArgb(180, 83, 9);

        public FormBitacora()
        {
            InitializeComponent();

            this.Load += FormBitacora_Load;
            this.btnVolver.Click += btnVolver_Click;
            this.dgvBitacora.DataBindingComplete += dgvBitacora_DataBindingComplete;
        }

        private void FormBitacora_Load(object? sender, EventArgs e)
        {
            Grillas.Configurar(dgvBitacora);
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            try
            {
                DataTable movimientos = GestorBitacora.ListarTodo();

                movimientos.Columns.Add("Antes", typeof(string));
                movimientos.Columns.Add("Despues", typeof(string));
                foreach (DataRow fila in movimientos.Rows)
                {
                    fila["Antes"] = GestorBitacora.TextoEstado(fila["Estado_Anterior"] as string);
                    fila["Despues"] = GestorBitacora.TextoEstado(fila["Estado_Posterior"] as string);
                }

                dgvBitacora.DataSource = movimientos;
                lblCantidad.Text = "Movimientos: " + movimientos.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBitacora_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (string columna in new[] { "Id_Bitacora", "Estado_Anterior", "Estado_Posterior" })
            {
                if (dgvBitacora.Columns.Contains(columna))
                    dgvBitacora.Columns[columna].Visible = false;
            }

            Columna("Fecha_Hora", "Fecha y hora", 120);
            Columna("Usuario", "Usuario", 80);
            Columna("Apellido_Nombre", "Apellido y nombre", 130);
            Columna("Rol", "Rol", 90);
            Columna("Modulo", "Módulo", 90);
            Columna("Operacion", "Operación", 230);
            Columna("Criticidad", "Criticidad", 85);
            Columna("Antes", "Antes", 150);
            Columna("Despues", "Después", 150);

            if (dgvBitacora.Columns.Contains("Fecha_Hora"))
                dgvBitacora.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            foreach (DataGridViewRow fila in dgvBitacora.Rows)
            {
                string criticidad = fila.Cells["Criticidad"].Value?.ToString() ?? "";

                if (criticidad == GestorBitacora.CRITICA)
                    fila.DefaultCellStyle.ForeColor = ROJO;
                else if (criticidad == GestorBitacora.ADVERTENCIA)
                    fila.DefaultCellStyle.ForeColor = NARANJA;
            }

            dgvBitacora.ClearSelection();
        }

        private void Columna(string nombre, string titulo, int peso)
        {
            if (!dgvBitacora.Columns.Contains(nombre))
                return;

            dgvBitacora.Columns[nombre].HeaderText = titulo;
            dgvBitacora.Columns[nombre].FillWeight = peso;
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
