using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vista
{
    // Consulta de todos los clientes del taller para el administrador.
    // Muestra si el cliente además es usuario del sistema y cuántas órdenes tiene.
    public partial class FormClientes : Form
    {
        private readonly GestorTaller gestorTaller = new GestorTaller();

        public FormClientes()
        {
            InitializeComponent();

            this.Load += FormClientes_Load;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
            this.btnVolver.Click += btnVolver_Click;
        }

        private void FormClientes_Load(object? sender, EventArgs e)
        {
            Grillas.Configurar(dgvClientes);
            CargarClientes();
            txtBuscar.Focus();
        }

        private void CargarClientes()
        {
            try
            {
                DataTable clientes = gestorTaller.ListarClientes(txtBuscar.Text.Trim());
                dgvClientes.DataSource = clientes;

                if (dgvClientes.Columns.Contains("Fecha_Alta"))
                    dgvClientes.Columns["Fecha_Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvClientes.Columns.Contains("Es_Usuario"))
                    dgvClientes.Columns["Es_Usuario"].HeaderText = "Usuario del sistema";

                if (dgvClientes.Columns.Contains("Telefono"))
                    dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";

                if (dgvClientes.Columns.Contains("Ordenes"))
                    dgvClientes.Columns["Ordenes"].HeaderText = "Órdenes";

                lblResumen.Text = "Clientes: " + clientes.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los clientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
