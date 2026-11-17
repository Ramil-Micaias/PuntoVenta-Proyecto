using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    // pantalla de caja diaria: abrir, cerrar y registrar movimientos
    public partial class FormCaja : Form
    {
        private readonly GestorCaja gestorCaja = new GestorCaja();
        private Usuario? usuarioLogueado;
        private Caja? cajaActual;

        // constructor: referencias de colores y eventos
        public FormCaja()
        {
            InitializeComponent();
            Leyenda.Agregar(dgvMovimientos,
                (Leyenda.LETRA_VERDE, false, "Ingreso o venta en efectivo"),
                (Leyenda.LETRA_ROJA, false, "Egreso"),
                (Leyenda.LETRA_GRIS, false, "Cobro con otro medio (no entra en la caja)"));

            this.btnAbrirCaja.Click += btnAbrirCaja_Click;
            this.btnCerrarCaja.Click += btnCerrarCaja_Click;
            this.btnRegistrarMovimiento.Click += btnRegistrarMovimiento_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.btnHistorial.Click += btnHistorial_Click;
            this.txtSaldoInicial.KeyDown += txtSaldoInicial_KeyDown;
            this.dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
        }

        // recibe el usuario logueado
        public FormCaja(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        // al abrir carga el estado de la caja
        private void FormCaja_Load(object sender, EventArgs e)
        {
            btnHistorial.Visible = usuarioLogueado == null || usuarioLogueado.Nombre_Rol == "Administrador";

            Grillas.Configurar(dgvMovimientos);
            CargarCaja();
        }

        // muestra si la caja esta abierta o cerrada con sus totales
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

            btnRegistrarMovimiento.Visible = abierta;
            btnCerrarCaja.Visible = abierta;

            if (!abierta)
            {
                Mensajes.Limpiar(lblResultado);
            }

            bool cerradaHoy = hayCaja && !abierta;

            lblApertura.Visible = !hayCaja;
            txtSaldoInicial.Visible = !hayCaja;
            btnAbrirCaja.Visible = !abierta;
            btnAbrirCaja.Text = cerradaHoy ? "Reabrir Caja" : "Abrir Caja";

            btnAbrirCaja.Left = cerradaHoy ? lblApertura.Left : txtSaldoInicial.Right + 10;
            AcomodarBotones(abierta);

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
                    ". Si se cerró por error, presione \"Reabrir Caja\" para seguir registrando movimientos.";
                lblEstado.ForeColor = Color.FromArgb(239, 68, 68);
            }

            MostrarTotales(cajaActual.Saldo_Inicial, cajaActual.Ingresos, cajaActual.Egresos, cajaActual.Saldo_Disponible);
            CargarMovimientos();
        }

        // muestra los botones segun si la caja esta abierta
        private void AcomodarBotones(bool abierta)
        {
            int x = dgvMovimientos.Right;

            Button[] botones = abierta
                ? new Button[] { btnRegistrarMovimiento, btnCerrarCaja, btnVolver }
                : new Button[] { btnVolver };

            foreach (Button boton in botones)
            {
                x -= boton.Width;
                boton.Left = x;
                x -= 10;
            }
        }

        // muestra saldo inicial, ingresos, egresos y saldo
        private void MostrarTotales(decimal saldoInicial, decimal ingresos, decimal egresos, decimal saldo)
        {
            lblSaldoInicialValor.Text = FormatoMoneda(saldoInicial);
            lblIngresosValor.Text = FormatoMoneda(ingresos);
            lblEgresosValor.Text = FormatoMoneda(egresos);
            lblSaldoValor.Text = FormatoMoneda(saldo);
        }

        // carga los movimientos de la caja abierta
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

        // titulo y formato de una columna
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

        // valida el saldo inicial y abre la caja
        private void AbrirCaja()
        {
            if (usuarioLogueado == null)
            {
                MessageBox.Show("Debe iniciar sesión para abrir la caja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cajaActual != null && !cajaActual.Abierta)
            {
                ReabrirCaja();
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

        // reabre la caja de hoy con sus movimientos (pide confirmacion)
        private void ReabrirCaja()
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea reabrir la caja de hoy? Se vuelve a abrir la misma caja, con su saldo inicial y sus movimientos.",
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
                gestorCaja.ReabrirCaja(cajaActual!.Id_Caja, usuarioLogueado!.Id_Usuario);
                CargarCaja();
                Mensajes.Exito(lblResultado, "Caja reabierta correctamente. Ya puede registrar movimientos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarCaja();
            }
        }

        // cierra la caja y muestra el saldo final
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

                Mensajes.Exito(lblEstado, "Caja cerrada correctamente. Saldo de cierre: " + FormatoMoneda(saldoCierre) +
                    ". Si se cerró por error, presione \"Reabrir Caja\".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarCaja();
            }
        }

        // abre la ventana para cargar un ingreso o egreso
        private void RegistrarMovimiento()
        {
            Mensajes.Limpiar(lblResultado);

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

        // importe verde si es ingreso, rojo si es egreso y gris si no es en efectivo
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvMovimientos.Columns.Contains("Tipo") || !dgvMovimientos.Columns.Contains("Importe"))
            {
                return;
            }

            if (dgvMovimientos.Columns.Contains("Medio")
                && (Convert.ToString(dgvMovimientos.Rows[e.RowIndex].Cells["Medio"].Value) ?? "Efectivo") != "Efectivo")
            {
                e.CellStyle!.ForeColor = Color.FromArgb(148, 163, 184);
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

        // convierte el texto a numero aceptando coma o punto
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

        // formato de pesos
        private static string FormatoMoneda(decimal valor)
        {
            return "$" + valor.ToString("N2");
        }

        // Enter en el saldo inicial abre la caja
        private void txtSaldoInicial_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AbrirCaja();
                e.Handled = true;
            }
        }

        // boton Abrir caja (o Reabrir)
        private void btnAbrirCaja_Click(object? sender, EventArgs e)
        {
            AbrirCaja();
        }

        // boton Cerrar caja
        private void btnCerrarCaja_Click(object? sender, EventArgs e)
        {
            CerrarCaja();
        }

        // boton Registrar movimiento
        private void btnRegistrarMovimiento_Click(object? sender, EventArgs e)
        {
            RegistrarMovimiento();
        }

        // abre el historial de caja
        private void btnHistorial_Click(object? sender, EventArgs e)
        {
            using (FormHistorialCaja historial = new FormHistorialCaja())
            {
                historial.ShowDialog(this);
            }
        }

        // vuelve al menu
        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
