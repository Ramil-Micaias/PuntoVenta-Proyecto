using Logica;
using System;
using System.Windows.Forms;

namespace Vista
{
    // Alta rápida del equipo que trae el cliente, desde la orden de reparación.
    public partial class FormNuevoEquipo : Form
    {
        private int idCliente;

        // Id del equipo que se acaba de crear (lo usa la orden para seleccionarlo).
        public int IdEquipoNuevo { get; private set; }

        public FormNuevoEquipo(int idCliente, string nombreCliente)
        {
            InitializeComponent();

            this.idCliente = idCliente;
            lblCliente.Text = "Cliente: " + nombreCliente;
            cmbTipo.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorTaller gestor = new GestorTaller();

                IdEquipoNuevo = gestor.RegistrarEquipo(
                    idCliente,
                    cmbTipo.Text,
                    txtMarca.Text,
                    txtModelo.Text,
                    txtSerie.Text,
                    txtImei.Text,
                    txtColor.Text
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
