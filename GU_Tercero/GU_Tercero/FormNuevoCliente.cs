using Logica;
using System;
using System.Windows.Forms;

namespace Vista
{
    // Alta rápida de un cliente desde la orden de reparación.
    public partial class FormNuevoCliente : Form
    {
        // Id del cliente que se acaba de crear (lo usa la orden para seleccionarlo).
        public int IdClienteNuevo { get; private set; }

        public FormNuevoCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorTaller gestor = new GestorTaller();

                IdClienteNuevo = gestor.RegistrarCliente(
                    txtApellido.Text,
                    txtNombre.Text,
                    txtDni.Text,
                    txtTelefono.Text
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
