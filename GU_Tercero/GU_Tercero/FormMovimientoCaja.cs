using Datos.Entidades;
using Logica;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    // Formulario del movimiento de caja (CU06 pasos 4 a 11).
    // Devuelve DialogResult.OK solo si el movimiento quedó registrado.
    public partial class FormMovimientoCaja : Form
    {
        private readonly GestorCaja gestorCaja = new GestorCaja();
        private readonly Caja caja;
        private readonly Usuario usuario;

        public FormMovimientoCaja(Caja caja, Usuario usuario)
        {
            InitializeComponent();

            this.caja = caja;
            this.usuario = usuario;

            lblSaldo.Text = "Saldo disponible: $" + caja.Saldo_Disponible.ToString("N2");

            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
        }

        private void Guardar()
        {
            // 9.1: se informa el dato a corregir y no se registra el movimiento.
            if (!rbIngreso.Checked && !rbEgreso.Checked)
            {
                Avisar("Debe seleccionar el tipo de movimiento (Ingreso o Egreso).");
                rbIngreso.Focus();
                return;
            }

            if (!IntentarParsearDecimal(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                Avisar("El importe debe ser un número mayor a cero.");
                txtImporte.Focus();
                return;
            }

            MovimientoCaja movimiento = new MovimientoCaja
            {
                Id_Caja = caja.Id_Caja,
                Tipo = rbIngreso.Checked ? MovimientoCaja.INGRESO : MovimientoCaja.EGRESO,
                Importe = importe,
                Motivo = txtMotivo.Text,
                Id_Usuario = usuario.Id_Usuario,
                Fecha = DateTime.Now
            };

            try
            {
                // 9.2, 10 y 10.1: el gestor y el SP validan el saldo y que la caja siga abierta.
                gestorCaja.RegistrarMovimiento(movimiento, caja.Saldo_Disponible);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Avisar(ex.Message);
            }
        }

        private static void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static bool IntentarParsearDecimal(string texto, out decimal valor)
        {
            valor = 0;
            texto = (texto ?? string.Empty).Trim().Replace("$", string.Empty).Trim();

            if (texto.Length == 0)
            {
                return false;
            }

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
            {
                return true;
            }

            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            Guardar();
        }

        // 8.1: cierra el formulario sin registrar el movimiento.
        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
