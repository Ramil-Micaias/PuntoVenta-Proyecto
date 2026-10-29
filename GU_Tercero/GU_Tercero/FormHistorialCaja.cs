using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    // CU10: Historial de Caja. Consulta las cajas y todo lo que se vendió, compró
    // y movió en un período, con filtro por medio de pago. No modifica nada.
    public partial class FormHistorialCaja : Form
    {
        private readonly GestorCaja gestorCaja = new GestorCaja();

        // Lo último que trajo la base; los filtros de hora, texto e importe se aplican sobre esto.
        private DataTable movimientosActuales = new DataTable();
        private string tituloActual = string.Empty;

        public FormHistorialCaja()
        {
            InitializeComponent();

            this.Load += FormHistorialCaja_Load;
            this.btnBuscar.Click += btnBuscar_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.dgvCajas.CellClick += dgvCajas_CellClick;
            this.dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
            this.txtTexto.KeyDown += Filtro_KeyDown;
            this.txtImporteDesde.KeyDown += Filtro_KeyDown;
            this.txtImporteHasta.KeyDown += Filtro_KeyDown;
        }

        private void FormHistorialCaja_Load(object? sender, EventArgs e)
        {
            Grillas.Configurar(dgvCajas);
            Grillas.Configurar(dgvMovimientos);

            // Por defecto, el mes actual.
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;

            // Por defecto, el día completo.
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);

            CargarMediosDePago();
            Buscar();
        }

        private void CargarMediosDePago()
        {
            try
            {
                DataTable medios = gestorCaja.ObtenerMetodosPago();

                DataRow todos = medios.NewRow();
                todos["Id_MetodoPago"] = DBNull.Value;
                todos["Nombre"] = "Todos";
                medios.Rows.InsertAt(todos, 0);

                cmbMedio.DisplayMember = "Nombre";
                cmbMedio.ValueMember = "Id_MetodoPago";
                cmbMedio.DataSource = medios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los medios de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? MedioSeleccionado()
        {
            object? valor = cmbMedio.SelectedValue;

            if (valor != null && valor != DBNull.Value && int.TryParse(valor.ToString(), out int id))
            {
                return id;
            }

            return null;
        }

        // Cajas del período y todos sus movimientos.
        private void Buscar()
        {
            try
            {
                DataTable cajas = gestorCaja.ListarCajas(dtpDesde.Value, dtpHasta.Value);
                dgvCajas.DataSource = cajas;
                FormatoColumna(dgvCajas, "Fecha_Apertura", "Apertura", "dd/MM/yyyy HH:mm");
                FormatoColumna(dgvCajas, "Fecha_Cierre", "Cierre", "dd/MM/yyyy HH:mm");
                FormatoColumna(dgvCajas, "Abrio", "Abrió", "");
                FormatoColumna(dgvCajas, "Saldo_Inicial", "Saldo Inicial", "N2");
                FormatoColumna(dgvCajas, "Ingresos", "Ingresos (efectivo)", "N2");
                FormatoColumna(dgvCajas, "Egresos", "Egresos (efectivo)", "N2");
                FormatoColumna(dgvCajas, "Saldo", "Saldo", "N2");
                dgvCajas.ClearSelection();

                DataTable movimientos = gestorCaja.ListarMovimientosPeriodo(dtpDesde.Value, dtpHasta.Value, MedioSeleccionado());
                MostrarMovimientos(movimientos,
                    "Todo el período: del " + dtpDesde.Value.ToString("dd/MM/yyyy") + " al " + dtpHasta.Value.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Al tocar una caja se ven solo sus movimientos (por ejemplo, la de un día anterior).
        private void dgvCajas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvCajas.Rows[e.RowIndex];

            // Id_Desde e Id_Hasta son el inicio y el fin del período de la caja
            // (empiezan con "Id_" para que la grilla no los muestre).
            DateTime inicio = Convert.ToDateTime(fila.Cells["Id_Desde"].Value);
            DateTime fin = Convert.ToDateTime(fila.Cells["Id_Hasta"].Value);
            DateTime apertura = Convert.ToDateTime(fila.Cells["Fecha_Apertura"].Value);

            try
            {
                DataTable movimientos = gestorCaja.ListarMovimientosDeCaja(inicio, fin, MedioSeleccionado());
                MostrarMovimientos(movimientos, "Caja del " + apertura.ToString("dd/MM/yyyy") + " (abierta a las " + apertura.ToString("HH:mm") + ")");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarMovimientos(DataTable movimientos, string titulo)
        {
            movimientosActuales = movimientos;
            tituloActual = titulo;
            AplicarFiltros();
        }

        // Filtros de hora, texto (comprobante, detalle, usuario o medio) e importe.
        private void AplicarFiltros()
        {
            TimeSpan horaDesde = dtpHoraDesde.Value.TimeOfDay;
            TimeSpan horaHasta = dtpHoraHasta.Value.TimeOfDay.Add(TimeSpan.FromSeconds(59));
            string texto = txtTexto.Text.Trim().ToLower();

            if (horaDesde > horaHasta)
            {
                MessageBox.Show("La hora desde no puede ser posterior a la hora hasta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!LeerImporte(txtImporteDesde.Text, out decimal? importeDesde) || !LeerImporte(txtImporteHasta.Text, out decimal? importeHasta))
            {
                MessageBox.Show("El importe debe ser un número. Ej: 5000", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable filtrados = movimientosActuales.Clone();

            foreach (DataRow fila in movimientosActuales.Rows)
            {
                TimeSpan hora = Convert.ToDateTime(fila["Fecha"]).TimeOfDay;
                decimal importe = Convert.ToDecimal(fila["Importe"]);

                if (hora < horaDesde || hora > horaHasta)
                    continue;

                if (importeDesde.HasValue && importe < importeDesde.Value)
                    continue;

                if (importeHasta.HasValue && importe > importeHasta.Value)
                    continue;

                if (texto.Length > 0)
                {
                    string contenido = (Convert.ToString(fila["Comprobante"]) + " " + Convert.ToString(fila["Detalle"]) + " " +
                                        Convert.ToString(fila["Usuario"]) + " " + Convert.ToString(fila["Medio"])).ToLower();

                    if (!contenido.Contains(texto))
                        continue;
                }

                filtrados.ImportRow(fila);
            }

            bool hayFiltro = filtrados.Rows.Count != movimientosActuales.Rows.Count;
            lblMostrando.Text = tituloActual + (hayFiltro ? "  (con filtros: " + filtrados.Rows.Count + " de " + movimientosActuales.Rows.Count + ")" : string.Empty);

            dgvMovimientos.DataSource = filtrados;
            FormatoColumna(dgvMovimientos, "Fecha", "Fecha y Hora", "dd/MM/yyyy HH:mm");
            FormatoColumna(dgvMovimientos, "Importe", "Importe", "N2");

            if (filtrados.Rows.Count == 0)
            {
                lblResumen.Text = "No hay ventas ni movimientos para el período o el filtro indicado.";
                return;
            }

            lblResumen.Text = ArmarResumen(filtrados);
        }

        // Vacío = sin filtro. Devuelve false si se escribió algo que no es un número.
        private static bool LeerImporte(string texto, out decimal? importe)
        {
            importe = null;
            texto = (texto ?? string.Empty).Trim().Replace("$", string.Empty).Trim();

            if (texto.Length == 0)
                return true;

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor)
                || decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            {
                importe = valor;
                return true;
            }

            return false;
        }

        // Enter en los filtros de texto o importe los aplica sin volver a consultar la base.
        private void Filtro_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AplicarFiltros();
                e.SuppressKeyPress = true;
            }
        }

        // Cantidad de ventas, total vendido, ticket promedio, desglose por medio de pago y compras.
        private static string ArmarResumen(DataTable movimientos)
        {
            HashSet<string> ventas = new HashSet<string>();
            Dictionary<string, decimal> porMedio = new Dictionary<string, decimal>();
            decimal totalVendido = 0;
            decimal totalCompras = 0;
            decimal ingresosManuales = 0;
            decimal egresosManuales = 0;

            foreach (DataRow fila in movimientos.Rows)
            {
                string origen = Convert.ToString(fila["Origen"]) ?? string.Empty;
                string medio = Convert.ToString(fila["Medio"]) ?? string.Empty;
                decimal importe = Convert.ToDecimal(fila["Importe"]);

                if (origen == "Venta")
                {
                    ventas.Add(Convert.ToString(fila["Comprobante"]) ?? string.Empty);
                    totalVendido += importe;

                    if (!porMedio.ContainsKey(medio))
                    {
                        porMedio[medio] = 0;
                    }
                    porMedio[medio] += importe;
                }
                else if (origen == "Compra")
                {
                    totalCompras += importe;
                }
                else if (Convert.ToString(fila["Tipo"]) == "Ingreso")
                {
                    ingresosManuales += importe;
                }
                else
                {
                    egresosManuales += importe;
                }
            }

            decimal ticketPromedio = ventas.Count == 0 ? 0 : totalVendido / ventas.Count;

            string detalleMedios = string.Empty;
            foreach (KeyValuePair<string, decimal> medio in porMedio)
            {
                decimal porcentaje = totalVendido == 0 ? 0 : medio.Value * 100 / totalVendido;
                detalleMedios += (detalleMedios.Length == 0 ? "" : "   |   ") +
                    medio.Key + ": $" + medio.Value.ToString("N2") + " (" + porcentaje.ToString("0") + "%)";
            }

            return "Ventas: " + ventas.Count +
                   "   Total vendido: $" + totalVendido.ToString("N2") +
                   "   Ticket promedio: $" + ticketPromedio.ToString("N2") + "\n" +
                   (detalleMedios.Length == 0 ? "Sin ventas en el período." : "Por medio de pago: " + detalleMedios) + "\n" +
                   "Compras: $" + totalCompras.ToString("N2") +
                   "   Movimientos manuales: ingresos $" + ingresosManuales.ToString("N2") +
                   ", egresos $" + egresosManuales.ToString("N2");
        }

        private static void FormatoColumna(DataGridView grid, string nombre, string titulo, string formato)
        {
            if (!grid.Columns.Contains(nombre))
            {
                return;
            }

            grid.Columns[nombre].HeaderText = titulo;
            grid.Columns[nombre].DefaultCellStyle.Format = formato;
        }

        // Importes de ingresos en verde y de egresos en rojo (igual que Caja Diaria).
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvMovimientos.Columns.Contains("Importe") || e.ColumnIndex != dgvMovimientos.Columns["Importe"].Index)
            {
                return;
            }

            string tipo = Convert.ToString(dgvMovimientos.Rows[e.RowIndex].Cells["Tipo"].Value) ?? string.Empty;

            e.CellStyle!.ForeColor = tipo == "Egreso"
                ? Color.FromArgb(239, 68, 68)
                : Color.FromArgb(16, 185, 129);
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            Buscar();
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
