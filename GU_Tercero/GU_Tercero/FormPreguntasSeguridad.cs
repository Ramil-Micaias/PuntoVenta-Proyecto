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

            // Siempre se registran las 3 preguntas (la configuración solo define cuántas se piden al recuperar).
            lblPreguntaTres.Visible = true;
            txtRespuestaTres.Visible = true;

            // Deshabilitamos el botón cancelar si la configuración es obligatoria en primer ingreso
            btnCancelar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuestaUno.Text) || string.IsNullOrWhiteSpace(txtRespuestaDos.Text)
                || string.IsNullOrWhiteSpace(txtRespuestaTres.Text))
            {
                MessageBox.Show("Complete las 3 respuestas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            // El hash se genera siempre con el helper centralizado: acá y en la pantalla de
            // recuperación tienen que aplicar exactamente la misma normalización, o el hash
            // guardado nunca va a coincidir con el hash calculado al validar.
            string hash1 = HashHelper.GenerarHashRespuesta(txtRespuestaUno.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            string hash2 = HashHelper.GenerarHashRespuesta(txtRespuestaDos.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            string hash3 = HashHelper.GenerarHashRespuesta(txtRespuestaTres.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);

            MessageBox.Show("Preguntas de seguridad configuradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            preguntasGuardadas = true;

            // Avisamos a Form1 que se completaron las preguntas con éxito
            this.DialogResult = DialogResult.OK;
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