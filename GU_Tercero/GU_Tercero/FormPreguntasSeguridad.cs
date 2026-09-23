using System;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    public partial class FormPreguntasSeguridad : Form
    {
        private Usuario usuarioLogueado;
        private bool preguntasGuardadas = false;

        public FormPreguntasSeguridad(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormPreguntasSeguridad_Load(object sender, EventArgs e)
        {
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            lblPreguntaTres.Text = "¿Comida favorita?";

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            bool requiereTresPreguntas = configuracion.Cantidad_Preguntas != 2;
            lblPreguntaTres.Visible = requiereTresPreguntas;
            txtRespuestaTres.Visible = requiereTresPreguntas;

            // Deshabilitamos el botón cancelar si la configuración es obligatoria en primer ingreso
            btnCancelar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuestaUno.Text) || string.IsNullOrWhiteSpace(txtRespuestaDos.Text))
            {
                MessageBox.Show("Complete todas las respuestas obligatorias.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfiguracionNegocio configuracionNegocio = new ConfiguracionNegocio();
            ConfiguracionSistema configuracion = configuracionNegocio.ObtenerConfiguracion();

            if (configuracion.Cantidad_Preguntas == 3 && string.IsNullOrWhiteSpace(txtRespuestaTres.Text))
            {
                MessageBox.Show("Complete la tercera respuesta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // Normalización a minúsculas y eliminación de espacios laterales antes de aplicar Hash
            string hash1 = HashHelper.GenerarSHA256(txtRespuestaUno.Text.Trim().ToLower());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            string hash2 = HashHelper.GenerarSHA256(txtRespuestaDos.Text.Trim().ToLower());
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            if (configuracion.Cantidad_Preguntas == 3)
            {
                string hash3 = HashHelper.GenerarSHA256(txtRespuestaTres.Text.Trim().ToLower());
                negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);
            }

            MessageBox.Show("Preguntas de seguridad configuradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            preguntasGuardadas = true;

            // Simplemente cerramos el formulario. El flujo retornará a FormCambioPassword o al Login limpiamente.
            this.Close();
        }

        private void FormPreguntasSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si no guardó las preguntas y el cierre fue iniciado por el usuario (la cruz X)
            if (!preguntasGuardadas && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Debe configurar sus preguntas de seguridad para continuar. ¿Desea salir del sistema?",
                    "Configuración Obligatoria",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true; // Bloquea el cierre y permanece en la pantalla
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}