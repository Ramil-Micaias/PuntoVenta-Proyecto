using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormNuevoCliente : Form
    {
        public int IdClienteNuevo { get; private set; }

        private readonly int idClienteEditado;

        public FormNuevoCliente()
        {
            InitializeComponent();
        }

        public FormNuevoCliente(int idCliente) : this()
        {
            idClienteEditado = idCliente;
            IdClienteNuevo = idCliente;

            lblTitulo.Text = "MODIFICAR CLIENTE";
            this.Text = "ApIBigStore - Modificar Cliente";

            DataTable cliente = new GestorTaller().ObtenerCliente(idCliente);
            if (cliente.Rows.Count > 0)
            {
                DataRow fila = cliente.Rows[0];
                txtApellido.Text = Convert.ToString(fila["Apellido"]);
                txtNombre.Text = Convert.ToString(fila["Nombre"]);
                txtDni.Text = Convert.ToString(fila["DNI"]);
                txtTelefono.Text = fila["Telefono"] == DBNull.Value ? string.Empty : Convert.ToString(fila["Telefono"]);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorTaller gestor = new GestorTaller();

                if (idClienteEditado > 0)
                {
                    gestor.ModificarCliente(idClienteEditado, txtApellido.Text, txtNombre.Text, txtDni.Text, txtTelefono.Text);
                }
                else
                {
                    IdClienteNuevo = gestor.RegistrarCliente(
                        txtApellido.Text,
                        txtNombre.Text,
                        txtDni.Text,
                        txtTelefono.Text
                    );
                }

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
