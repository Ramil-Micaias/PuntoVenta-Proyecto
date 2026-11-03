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

            lblPreguntaTres.Visible = true;
            txtRespuestaTres.Visible = true;

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

            string hash1 = HashHelper.GenerarHashRespuesta(txtRespuestaUno.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 1, hash1);

            string hash2 = HashHelper.GenerarHashRespuesta(txtRespuestaDos.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 2, hash2);

            string hash3 = HashHelper.GenerarHashRespuesta(txtRespuestaTres.Text);
            negocio.GuardarPreguntaSeguridad(usuarioLogueado.Id_Usuario, 3, hash3);

            MessageBox.Show("Preguntas de seguridad configuradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            preguntasGuardadas = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormPreguntasSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    e.Cancel = true;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}