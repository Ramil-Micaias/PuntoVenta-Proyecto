using System;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;
using Logica.Seguridad;

namespace GU_Tercero
{
    // carga de las 3 preguntas de seguridad en el primer ingreso
    public partial class FormPreguntasSeguridad : Form
    {
        private Usuario usuarioLogueado;
        private bool preguntasGuardadas = false;

        // recibe el usuario que tiene que cargar las preguntas
        public FormPreguntasSeguridad(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        // pone el texto de las 3 preguntas y no deja cancelar
        private void FormPreguntasSeguridad_Load(object sender, EventArgs e)
        {
            lblPreguntaUno.Text = "¿Nombre de tu primera mascota?";
            lblPreguntaDos.Text = "¿Ciudad donde naciste?";
            lblPreguntaTres.Text = "¿Comida favorita?";

            lblPreguntaTres.Visible = true;
            txtRespuestaTres.Visible = true;

            btnCancelar.Enabled = false;
        }

        // controla que responda las 3 y guarda las respuestas hasheadas
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

        // cierra la pantalla
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}