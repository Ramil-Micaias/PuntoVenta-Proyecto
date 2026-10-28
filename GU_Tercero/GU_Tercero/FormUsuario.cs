using Datos.Entidades;
using Logica;
using Logica.Seguridad;

using Vista;

namespace GU_Tercero
{
    public partial class FormUsuario : Form
    {
        private Usuario usuarioLogueado;

        // La contraseña y las preguntas quedan bloqueadas hasta que el usuario
        // responda sus preguntas de seguridad (FormVerificarIdentidad).
        private bool passwordHabilitada = false;
        private bool preguntasHabilitadas = false;

        public FormUsuario(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            // Muestra la información del usuario.
            lblNombreUsuario.Text = usuarioLogueado.Nombre_Usuario;
            lblNombreRol.Text = usuarioLogueado.Nombre_Rol;

            // Carga las preguntas de seguridad.
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            lblPreguntaTres.Text = "¿Comida favorita?";

            // Siempre se registran las 3 preguntas (la configuración solo define cuántas se piden al recuperar).
            lblPreguntaTres.Visible = true;
            txtRespuestaTres.Visible = true;

            HabilitarPassword(false);
            HabilitarPreguntas(false);
        }

        // Pide las 3 preguntas de seguridad. Devuelve true si el usuario las respondió bien.
        private bool VerificarIdentidad()
        {
            using (FormVerificarIdentidad verificacion = new FormVerificarIdentidad(usuarioLogueado))
            {
                return verificacion.ShowDialog(this) == DialogResult.OK;
            }
        }

        private void HabilitarPassword(bool habilitar)
        {
            passwordHabilitada = habilitar;
            txtNuevaPassword.Enabled = habilitar;
            txtConfirmarPassword.Enabled = habilitar;
            txtNuevaPassword.Clear();
            txtConfirmarPassword.Clear();
            btnCambiarPassword.Text = habilitar ? "Guardar contraseña" : "Cambiar contraseña";
        }

        private void HabilitarPreguntas(bool habilitar)
        {
            preguntasHabilitadas = habilitar;
            txtRespuestaUno.Enabled = habilitar;
            txtRespuestaDos.Enabled = habilitar;
            txtRespuestaTres.Enabled = habilitar;
            txtRespuestaUno.Clear();
            txtRespuestaDos.Clear();
            txtRespuestaTres.Clear();
            btnGuardarPreguntas.Text = habilitar ? "Guardar preguntas" : "Cambiar preguntas";
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            // Primer clic: verificar identidad y habilitar los campos.
            if (!passwordHabilitada)
            {
                if (VerificarIdentidad())
                {
                    HabilitarPassword(true);
                    txtNuevaPassword.Focus();
                }
                return;
            }

            // Valida que la nueva contraseña haya sido ingresada.
            if (txtNuevaPassword.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la nueva contraseña.");
                return;
            }

            // Valida que se confirme la nueva contraseña.
            if (txtConfirmarPassword.Text.Trim() == "")
            {
                MessageBox.Show("Confirme la nueva contraseña.");
                return;
            }

            // Verifica que ambas contraseñas sean iguales.
            if (txtNuevaPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();

            // Valida que la contraseña cumpla las políticas configuradas.
            string resultado = configuracionNegocio.ValidarPassword(txtNuevaPassword.Text.Trim(), usuarioLogueado);

            if (resultado != "OK")
            {
                MessageBox.Show(resultado);
                return;
            }

            // Genera el hash de la nueva contraseña.
            string nuevaPasswordHash = HashHelper.GenerarSHA256(usuarioLogueado.Nombre_Usuario + txtNuevaPassword.Text);

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Actualiza la contraseña del usuario.
            negocio.CambiarPassword(usuarioLogueado.Id_Usuario, nuevaPasswordHash);

            Mensajes.Exito(lblResultado, "La contraseña fue modificada correctamente.");

            // Vuelve a bloquear los campos (limpia lo escrito).
            HabilitarPassword(false);
        }

        private void btnGuardarPreguntas_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            // Primer clic: verificar con las preguntas actuales y habilitar los campos.
            if (!preguntasHabilitadas)
            {
                if (VerificarIdentidad())
                {
                    HabilitarPreguntas(true);
                    txtRespuestaUno.Focus();
                }
                return;
            }

            // Verifica que las 3 respuestas hayan sido ingresadas.
            if (txtRespuestaUno.Text.Trim() == "" || txtRespuestaDos.Text.Trim() == "" || txtRespuestaTres.Text.Trim() == "")
            {
                MessageBox.Show("Complete las 3 respuestas.");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Se usa el helper centralizado para que el hash guardado se pueda validar
            // después desde la pantalla de recuperación de contraseña.
            string hash1 = HashHelper.GenerarHashRespuesta(txtRespuestaUno.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            // Guarda la segunda respuesta.
            string hash2 = HashHelper.GenerarHashRespuesta(txtRespuestaDos.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            // Guarda la tercera respuesta.
            string hash3 = HashHelper.GenerarHashRespuesta(txtRespuestaTres.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);

            Mensajes.Exito(lblResultado, "Las preguntas de seguridad fueron actualizadas correctamente.");

            HabilitarPreguntas(false);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
