using Datos.Entidades;
using Logica;
using Logica.Seguridad;
using Seguridad;

namespace GU_Tercero
{
    // pantalla de inicio de sesion
    public partial class Form1 : Form
    {
        // constructor: arma la pantalla y engancha los eventos
        public Form1()
        {
            InitializeComponent();
            txtUsuario.KeyDown += txtUsuario_KeyDown;
        }

        // con Enter en el usuario pasa a la contrasenia
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        // muestra u oculta la contrasenia
        private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkMostrarPassword.Checked ? '\0' : '*';
        }

        // borra usuario y contrasenia
        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Focus();
        }

        // abre el menu segun el rol, al cerrarlo vuelve al login o sale
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

        // boton Ingresar: valida el login, el 2FA y si tiene que cambiar la contrasenia o cargar las preguntas
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

        // si el 2FA esta activo abre la pantalla del codigo, devuelve true si lo valido
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

        // al abrir carga el logo
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLogo();
        }

        // carga la imagen del logo desde la carpeta del programa
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

        // abre la pantalla para recuperar la contrasenia
        private void llb_OlvidoContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecuperoContraseña formrecupero = new FormRecuperoContraseña();

            formrecupero.FormClosed += (s, args) => this.Show();

            formrecupero.Show();
            this.Hide();
        }
    }
}