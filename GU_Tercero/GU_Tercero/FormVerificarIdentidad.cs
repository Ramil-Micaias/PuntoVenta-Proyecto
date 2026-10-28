using Datos.Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GU_Tercero
{
    // Antes de cambiar la contraseña o las preguntas de seguridad desde Mi Perfil,
    // el usuario tiene que responder sus 3 preguntas. Así, si alguien encuentra la
    // sesión abierta, no puede cambiar los datos de acceso.
    // Devuelve DialogResult.OK solo si las 3 respuestas son correctas.
    public partial class FormVerificarIdentidad : Form
    {
        private const int INTENTOS_MAXIMOS = 3;

        private readonly UsuarioNegocio negocio = new UsuarioNegocio();
        private readonly Usuario usuario;
        private readonly List<int> idsPreguntas = new List<int>();
        private int intentosFallidos = 0;

        public FormVerificarIdentidad(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.Load += FormVerificarIdentidad_Load;
            this.btnVerificar.Click += btnVerificar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
        }

        private void FormVerificarIdentidad_Load(object? sender, EventArgs e)
        {
            DataTable preguntas = negocio.ObtenerPreguntasUsuario(usuario.Nombre_Usuario);
            Label[] etiquetas = { lblPregunta1, lblPregunta2, lblPregunta3 };

            if (preguntas.Rows.Count < UsuarioNegocio.TOTAL_PREGUNTAS)
            {
                MessageBox.Show(
                    "No tiene sus preguntas de seguridad completas. Vuelva a iniciar sesión para cargarlas.",
                    "Verificar identidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            for (int i = 0; i < UsuarioNegocio.TOTAL_PREGUNTAS; i++)
            {
                idsPreguntas.Add(Convert.ToInt32(preguntas.Rows[i]["Id_Pregunta"]));
                etiquetas[i].Text = preguntas.Rows[i]["Pregunta"].ToString();
            }

            txtRespuesta1.Focus();
        }

        private void btnVerificar_Click(object? sender, EventArgs e)
        {
            string[] respuestas = { txtRespuesta1.Text, txtRespuesta2.Text, txtRespuesta3.Text };

            foreach (string respuesta in respuestas)
            {
                if (string.IsNullOrWhiteSpace(respuesta))
                {
                    MessageBox.Show("Responda las 3 preguntas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            bool correctas = true;

            for (int i = 0; i < idsPreguntas.Count; i++)
            {
                if (!negocio.ValidarPreguntaSeguridad(usuario.Nombre_Usuario, idsPreguntas[i], respuestas[i]))
                {
                    correctas = false;
                    break;
                }
            }

            if (correctas)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            intentosFallidos++;

            if (intentosFallidos >= INTENTOS_MAXIMOS)
            {
                MessageBox.Show(
                    "Superó los " + INTENTOS_MAXIMOS + " intentos. No se habilitó ningún cambio.",
                    "Verificar identidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // No se indica cuál respuesta falló, para no dar pistas.
            MessageBox.Show(
                "Alguna respuesta no es correcta.\nIntentos restantes: " + (INTENTOS_MAXIMOS - intentosFallidos),
                "Verificar identidad",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            txtRespuesta1.Clear();
            txtRespuesta2.Clear();
            txtRespuesta3.Clear();
            txtRespuesta1.Focus();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
