using Datos.Entidades;
using Logica;
using Seguridad;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GU_Tercero
{
    // Segundo paso del inicio de sesión: el usuario ingresa el código que recibió por correo.
    // Devuelve DialogResult.OK solo si el código fue validado.
    public partial class FormAutenticacion2FA : Form
    {
        private readonly Autenticacion2FANegocio negocio = new Autenticacion2FANegocio();
        private readonly Usuario usuario;
        private int intentosFallidos = 0;

        // Indica si el código ingresado fue validado correctamente.
        public bool CodigoValidado { get; private set; } = false;

        public FormAutenticacion2FA(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
            txtCodigo.KeyPress += txtCodigo_KeyPress;
        }

        private void FormAutenticacion2FA_Load(object sender, EventArgs e)
        {
            lblCorreo.Text = negocio.ObtenerCorreoEnmascarado(usuario);
            lblVencimiento.Text = "El código vence en " + Autenticacion2FANegocio.MINUTOS_VALIDEZ + " minutos.";
            txtCodigo.Focus();
        }

        // Solo se pueden escribir números.
        private void txtCodigo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string? error;

            try
            {
                error = negocio.ValidarCodigo(usuario, txtCodigo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo validar el código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (error == null)
            {
                CodigoValidado = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            intentosFallidos++;

            if (intentosFallidos >= Autenticacion2FANegocio.INTENTOS_MAXIMOS)
            {
                negocio.CancelarVerificacion(usuario);

                MessageBox.Show(
                    "Superó los " + Autenticacion2FANegocio.INTENTOS_MAXIMOS + " intentos permitidos. Vuelva a iniciar sesión.",
                    "Verificación en Dos Pasos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            MessageBox.Show(
                error + "\nIntentos restantes: " + (Autenticacion2FANegocio.INTENTOS_MAXIMOS - intentosFallidos),
                "Verificación en Dos Pasos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtCodigo.SelectAll();
            txtCodigo.Focus();
        }

        private void lnkReenviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ResultadoEnvioEmail envio;

            try
            {
                envio = negocio.EnviarCodigo(usuario);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (!envio.Enviado)
            {
                MessageBox.Show("No se pudo reenviar el código. " + envio.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            intentosFallidos = 0;
            txtCodigo.Clear();
            txtCodigo.Focus();

            lblVencimiento.ForeColor = Color.FromArgb(16, 185, 129);
            lblVencimiento.Text = "Se envió un código nuevo (el anterior ya no sirve). Vence en " + Autenticacion2FANegocio.MINUTOS_VALIDEZ + " minutos.";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            negocio.CancelarVerificacion(usuario);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
