using Datos.Entidades;
using Logica;
using Logica.Seguridad;
using Seguridad;

namespace GU_Tercero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtUsuario.KeyDown += txtUsuario_KeyDown;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkMostrarPassword.Checked ? '\0' : '*';
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Focus();
        }

        private void AbrirMenu(Usuario usuario)
        {
            if (usuario.Nombre_Rol == "Administrador" || usuario.Nombre_Rol == "Vendedor" || usuario.Nombre_Rol == "Tecnico")
            {
                FormMenu menu = new FormMenu(usuario);

                menu.FormClosed += (s, args) =>
                {
                    Sesion.Cerrar();

                    if (menu.EsCierreSesion)
                    {
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                };

                menu.Show();
                this.Hide();
            }
            else
            {
                FormUsuario formUsuario = new FormUsuario(usuario);

                formUsuario.FormClosed += (s, args) =>
                {
                    Sesion.Cerrar();
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    this.Show();
                };

                formUsuario.Show();
                this.Hide();
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.ValidarLogin(txtUsuario.Text, txtPassword.Text);

            if (usuario != null)
            {
                if (usuario.Bloqueado || !usuario.Activo)
                {
                    MessageBox.Show("Usuario bloqueado o inactivo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!VerificarDosPasos(usuario))
                {
                    LimpiarCampos();
                    this.Show();
                    return;
                }

                if (usuario.Es_Primer_Ingreso || usuario.Debe_Cambiar_Password)
                {
                    using (FormCambioPassword formCambio = new FormCambioPassword(usuario))
                    {
                        this.Hide();
                        if (formCambio.ShowDialog() != DialogResult.OK)
                        {
                            LimpiarCampos();
                            this.Show();
                            return;
                        }
                    }
                }

                if (!negocio.UsuarioTienePreguntas(usuario.Id_Usuario))
                {
                    using (FormPreguntasSeguridad formPreguntas = new FormPreguntasSeguridad(usuario))
                    {
                        this.Hide();
                        if (formPreguntas.ShowDialog() != DialogResult.OK)
                        {
                            LimpiarCampos();
                            this.Show();
                            return;
                        }
                    }
                }

                Sesion.Iniciar(usuario);
                AbrirMenu(usuario);
            }
            else
            {
                MessageBox.Show(negocio.MensajeLoginFallido(txtUsuario.Text), "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarDosPasos(Usuario usuario)
        {
            Autenticacion2FANegocio negocio2FA = new Autenticacion2FANegocio();
            ResultadoEnvioEmail envio;

            try
            {
                if (!negocio2FA.EstaHabilitada())
                {
                    return true;
                }

                Cursor = Cursors.WaitCursor;
                envio = negocio2FA.EnviarCodigo(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar la verificación en dos pasos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (!envio.Enviado)
            {
                MessageBox.Show(
                    "No se pudo enviar el código de verificación. " + envio.Error,
                    "Verificación en Dos Pasos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            using (FormAutenticacion2FA form2FA = new FormAutenticacion2FA(usuario))
            {
                this.Hide();
                return form2FA.ShowDialog() == DialogResult.OK;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLogo();
        }

        private void CargarLogo()
        {
            try
            {
                string[] rutasPosibles = new string[]
                {
                    System.IO.Path.Combine(Application.StartupPath, "loguito trtansparente.png"),
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\loguito trtansparente.png"),
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\loguito trtansparente.png"),
                    @"C:\Users\LanzceTest\Desktop\github isft\loguito trtansparente.png"
                };

                foreach (string ruta in rutasPosibles)
                {
                    if (System.IO.File.Exists(ruta))
                    {
                        picLogo.Image = System.Drawing.Image.FromFile(ruta);
                        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    }
                }
            }
            catch { }
        }

        private void llb_OlvidoContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperoContraseña formrecupero = new FormRecuperoContraseña();

            formrecupero.FormClosed += (s, args) => this.Show();

            formrecupero.Show();
            this.Hide();
        }
    }
}