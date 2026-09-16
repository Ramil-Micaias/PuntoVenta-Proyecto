using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GU_Tercero
{
    public partial class FormAutenticacion2FA : Form
    {
        // Indica si el código ingresado fue validado correctamente.
        public bool CodigoValidado { get; private set; } = false;

        private string codigoGenerado;

        public FormAutenticacion2FA(string codigo)
        {
            InitializeComponent();

            codigoGenerado = codigo;
        }

        private void FormAutenticacion2FA_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código de verificación.");
                return;
            }

            if (txtCodigo.Text.Trim() != codigoGenerado)
            {
                MessageBox.Show("El código ingresado es incorrecto.");
                return;
            }

            CodigoValidado = true;

            this.Close();
        }
    }
}
