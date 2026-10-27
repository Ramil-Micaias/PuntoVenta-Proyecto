using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    // CU06 Registrar Movimiento de Caja: muestra la caja de la jornada y sus movimientos.
    public partial class FormCaja : Form
    {
        private readonly GestorCaja gestorCaja = new GestorCaja();
        private Usuario? usuarioLogueado;
        private Caja? cajaActual;

        public FormCaja()
        {
            InitializeComponent();

            this.btnAbrirCaja.Click += btnAbrirCaja_Click;
            this.btnCerrarCaja.Click += btnCerrarCaja_Click;
            this.btnRegistrarMovimiento.Click += btnRegistrarMovimiento_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.txtSaldoInicial.KeyDown += txtSaldoInicial_KeyDown;
            this.dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
        }

        public FormCaja(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvMovimientos);
            CargarCaja();
        }

        // Paso 2: muestra la caja de la jornada con sus totales y movimientos.
        private void CargarCaja()
        {
            try
            {
                cajaActual = gestorCaja.ObtenerCajaActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la caja: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            bool hayCaja = cajaActual != null;
            bool abierta = hayCaja && cajaActual!.Abierta;

            // 2.1: sin caja abierta no se pueden registrar movimientos.
            btnRegistrarMovimiento.Enabled = abierta;
            btnCerrarCaja.Enabled = abierta;

            if (!abierta)
            {
                Mensajes.Limpiar(lblResultado);
            }

            // La apertura se ofrece si no hay caja de hoy o si la última ya se cerró.
            lblApertura.Visible = !abierta;
            txtSaldoInicial.Visible = !abierta;
            btnAbrirCaja.Visible = !abierta;

            if (!hayCaja)
            {
                lblEstado.Text = "No hay una caja abierta para la jornada actual. Ingrese el saldo inicial y presione \"Abrir Caja\".";
                lblEstado.ForeColor = Color.FromArgb(239, 68, 68);
                MostrarTotales(0, 0, 0, 0);
                dgvMovimientos.DataSource = null;
                return;
            }

            if (abierta)
            {
                lblEstado.Text = "Caja abierta el " + cajaActual!.Fecha_Apertura.ToString("dd/MM/yyyy HH:mm") +
                    " por " + cajaActual.Usuario_Apertura + ".";
                lblEstado.ForeColor = Color.FromArgb(16, 185, 129);
            }
            else
            {
                lblEstado.Text = "La caja se cerró" +
                    (cajaActual!.Fecha_Cierre.HasValue ? " a las " + cajaActual.Fecha_Cierre.Value.ToString("HH:mm") : string.Empty) +
                    ". Para registrar movimientos ingrese el saldo inicial y presione \"Abrir Caja\".";
                lblEstado.ForeColor = Color.FromArgb(239, 68, 68);
            }

            MostrarTotales(cajaActual.Saldo_Inicial, cajaActual.Ingresos, cajaActual.Egresos, cajaActual.Saldo_Disponible);
            CargarMovimientos();
        }

        private void MostrarTotales(decimal saldoInicial, decimal ingresos, decimal egresos, decimal saldo)
        {
            lblSaldoInicialValor.Text = FormatoMoneda(saldoInicial);
            lblIngresosValor.Text = FormatoMoneda(ingresos);
            lblEgresosValor.Text = FormatoMoneda(egresos);
            lblSaldoValor.Text = FormatoMoneda(saldo);
        }

        private void CargarMovimientos()
        {
            try
            {
                dgvMovimientos.DataSource = gestorCaja.ListarMovimientos(cajaActual!.Id_Caja);

                EncabezadoColumna("Fecha", "Fecha y Hora", "dd/MM/yyyy HH:mm");
                EncabezadoColumna("Importe", "Importe", "N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los movimientos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EncabezadoColumna(string nombre, string texto, string formato)
        {
            if (!dgvMovimientos.Columns.Contains(nombre))
            {
                return;
            }

            DataGridViewColumn columna = dgvMovimientos.Columns[nombre];
            columna.HeaderText = texto;
            columna.DefaultCellStyle.Format = formato;
        }

        private void AbrirCaja()
        {
            if (usuarioLogueado == null)
            {
                MessageBox.Show("Debe iniciar sesión para abrir la caja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IntentarParsearDecimal(txtSaldoInicial.Text, out decimal saldoInicial) || saldoInicial < 0)
            {
                MessageBox.Show(
                    "Ingrese un saldo inicial válido (cero o mayor).",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtSaldoInicial.Focus();
                return;
            }

            try
            {
                gestorCaja.AbrirCaja(usuarioLogueado.Id_Usuario, saldoInicial);
                txtSaldoInicial.Clear();
                CargarCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarCaja();
            }
        }

        private void CerrarCaja()
        {
            if (cajaActual == null || usuarioLogueado == null)
            {
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la caja de hoy? Después de cerrarla no se podrán registrar más movimientos.\n" +
                "Saldo disponible: " + FormatoMoneda(cajaActual.Saldo_Disponible),
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                decimal saldoCierre = gestorCaja.CerrarCaja(cajaActual.Id_Caja, usuarioLogueado.Id_Usuario);
                CargarCaja();

                // Con la caja cerrada se muestra arriba, en el estado de la caja.
                Mensajes.Exito(lblEstado, "Caja cerrada correctamente. Saldo de cierre: " + FormatoMoneda(saldoCierre) +
                    ". Para seguir, ingrese el saldo inicial y presione \"Abrir Caja\".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarCaja();
            }
        }

        // Pasos 3 a 12: abre el formulario del movimiento y, si se guardó, actualiza la caja.
        private void RegistrarMovimiento()
        {
            Mensajes.Limpiar(lblResultado);

            // Se vuelve a leer la caja por si otro usuario la cerró mientras tanto (2.1).
            CargarCaja();

            if (cajaActual == null || !cajaActual.Abierta)
            {
                MessageBox.Show(
                    "No hay una caja abierta para la jornada actual. No se pueden registrar movimientos.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (usuarioLogueado == null)
            {
                MessageBox.Show("Debe iniciar sesión para registrar un movimiento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormMovimientoCaja form = new FormMovimientoCaja(cajaActual, usuarioLogueado))
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
            }

            CargarCaja();

            Mensajes.Exito(lblResultado,
                "Movimiento registrado con éxito.\nSaldo disponible: " + FormatoMoneda(cajaActual!.Saldo_Disponible));
        }

        // Importes de ingresos en verde y de egresos en rojo.
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvMovimientos.Columns.Contains("Tipo") || !dgvMovimientos.Columns.Contains("Importe"))
            {
                return;
            }

            if (e.ColumnIndex != dgvMovimientos.Columns["Importe"].Index)
            {
                return;
            }

            string tipo = Convert.ToString(dgvMovimientos.Rows[e.RowIndex].Cells["Tipo"].Value) ?? string.Empty;

            e.CellStyle!.ForeColor = tipo == MovimientoCaja.EGRESO
                ? Color.FromArgb(239, 68, 68)
                : Color.FromArgb(16, 185, 129);
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

        private static string FormatoMoneda(decimal valor)
        {
            return "$" + valor.ToString("N2");
        }

        private void txtSaldoInicial_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AbrirCaja();
                e.Handled = true;
            }
        }

        private void btnAbrirCaja_Click(object? sender, EventArgs e)
        {
            AbrirCaja();
        }

        private void btnCerrarCaja_Click(object? sender, EventArgs e)
        {
            CerrarCaja();
        }

        private void btnRegistrarMovimiento_Click(object? sender, EventArgs e)
        {
            RegistrarMovimiento();
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
