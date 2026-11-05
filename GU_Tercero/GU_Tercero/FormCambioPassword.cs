using System;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    public partial class FormCambioPassword : Form
    {
        private Usuario usuarioLogueado;

        public FormCambioPassword(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormCambioPassword_Load(object sender, EventArgs e)
        {
            if (usuarioLogueado.Es_Primer_Ingreso || usuarioLogueado.Debe_Cambiar_Password)
            {
                btnCancelar.Enabled = false;
            }
        }

        private void FormCambioPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((usuarioLogueado.Es_Primer_Ingreso || usuarioLogueado.Debe_Cambiar_Password)
                && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Debe cambiar su contraseña para continuar. ¿Desea salir del sistema?",
                    "Cambio Obligatorio",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaPassword.Text))
            {
                MessageBox.Show("Ingrese la nueva contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            string resultado = configuracionNegocio.ValidarPassword(txtNuevaPassword.Text.Trim(), usuarioLogueado);

            if (resultado != "OK")
            {
                MessageBox.Show(resultado, "Validación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevaPasswordHash = HashHelper.GenerarHashPassword(usuarioLogueado.Nombre_Usuario, txtNuevaPassword.Text.Trim());
            UsuarioNegocio negocio = new UsuarioNegocio();

            negocio.CambiarPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);
            negocio.RegistrarHistorialPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);

            usuarioLogueado.Debe_Cambiar_Password = false;
            usuarioLogueado.Es_Primer_Ingreso = false;

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}