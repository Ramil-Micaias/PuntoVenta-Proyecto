using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormBitacora : Form
    {
        private const string TODOS = "Todos";
        private const string TODAS = "Todas";

        private static readonly Color FONDO_CRITICA = Color.FromArgb(254, 226, 226);
        private static readonly Color SELECCION_CRITICA = Color.FromArgb(220, 38, 38);
        private static readonly Color FONDO_ADVERTENCIA = Color.FromArgb(254, 243, 199);
        private static readonly Color SELECCION_ADVERTENCIA = Color.FromArgb(217, 119, 6);

        private DataTable movimientos = new DataTable();

        public FormBitacora()
        {
            InitializeComponent();
            Leyenda.Agregar(dgvBitacora,
                (Leyenda.FONDO_ROJO, true, "Crítica"),
                (Leyenda.FONDO_AMARILLO, true, "Advertencia"),
                (Leyenda.FONDO_BLANCO, true, "Informativa"));

            this.Load += FormBitacora_Load;
            this.btnVolver.Click += btnVolver_Click;
            this.btnAplicarFiltros.Click += btnAplicarFiltros_Click;
            this.btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            this.txtMovimiento.KeyDown += txtMovimiento_KeyDown;
            this.dgvBitacora.DataBindingComplete += dgvBitacora_DataBindingComplete;
            this.dgvBitacora.CellFormatting += dgvBitacora_CellFormatting;
        }

        private void FormBitacora_Load(object? sender, EventArgs e)
        {
            Grillas.Configurar(dgvBitacora);
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);
            dtpHoraDesde.Checked = false;
            dtpHoraHasta.Checked = false;
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            try
            {
                movimientos = GestorBitacora.ListarTodo();

                movimientos.Columns.Add("Antes", typeof(string));
                movimientos.Columns.Add("Despues", typeof(string));
                foreach (DataRow fila in movimientos.Rows)
                {
                    fila["Antes"] = GestorBitacora.TextoEstado(fila["Estado_Anterior"] as string);
                    fila["Despues"] = GestorBitacora.TextoEstado(fila["Estado_Posterior"] as string);
                }

                CargarCombos();
                MostrarMovimientos(movimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCombos()
        {
            cmbUsuario.Items.Clear();
            cmbUsuario.Items.Add(TODOS);
            foreach (string usuario in GestorBitacora.UsuariosDe(movimientos))
                cmbUsuario.Items.Add(usuario);
            cmbUsuario.SelectedIndex = 0;

            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.Add(TODAS);
            foreach (string criticidad in GestorBitacora.CRITICIDADES)
                cmbCriticidad.Items.Add(criticidad);
            cmbCriticidad.SelectedIndex = 0;
        }

        private void MostrarMovimientos(DataTable tabla)
        {
            dgvBitacora.DataSource = tabla;

            if (tabla.Rows.Count == movimientos.Rows.Count)
                lblCantidad.Text = "Movimientos: " + tabla.Rows.Count;
            else
                lblCantidad.Text = "Movimientos: " + tabla.Rows.Count + " de " + movimientos.Rows.Count;
        }

        private void AplicarFiltros()
        {
            try
            {
                string? usuario = cmbUsuario.SelectedIndex > 0 ? cmbUsuario.SelectedItem?.ToString() : null;
                string? criticidad = cmbCriticidad.SelectedIndex > 0 ? cmbCriticidad.SelectedItem?.ToString() : null;
                DateTime? fecha = dtpFecha.Checked ? dtpFecha.Value.Date : null;
                TimeSpan? horaDesde = dtpHoraDesde.Checked ? HoraDe(dtpHoraDesde) : null;
                TimeSpan? horaHasta = dtpHoraHasta.Checked ? HoraDe(dtpHoraHasta) : null;

                DataTable filtrados = GestorBitacora.Filtrar(movimientos, usuario, fecha, horaDesde, horaHasta, txtMovimiento.Text, criticidad);
                MostrarMovimientos(filtrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static TimeSpan HoraDe(DateTimePicker selector)
        {
            return new TimeSpan(selector.Value.Hour, selector.Value.Minute, 0);
        }

        private void btnAplicarFiltros_Click(object? sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtMovimiento_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AplicarFiltros();
                e.SuppressKeyPress = true;
            }
        }

        private void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cmbUsuario.SelectedIndex = 0;
            cmbCriticidad.SelectedIndex = 0;
            txtMovimiento.Clear();
            dtpFecha.Value = DateTime.Today;
            dtpFecha.Checked = false;
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);
            dtpHoraDesde.Checked = false;
            dtpHoraHasta.Checked = false;
            MostrarMovimientos(movimientos);
        }

        private void dgvBitacora_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (string columna in new[] { "Id_Bitacora", "Estado_Anterior", "Estado_Posterior" })
            {
                if (dgvBitacora.Columns.Contains(columna))
                    dgvBitacora.Columns[columna].Visible = false;
            }

            Columna("Fecha_Hora", "Fecha y hora", 120);
            Columna("Usuario", "Usuario", 80);
            Columna("Apellido_Nombre", "Apellido y nombre", 130);
            Columna("Rol", "Rol", 90);
            Columna("Modulo", "Módulo", 90);
            Columna("Operacion", "Operación", 230);
            Columna("Criticidad", "Criticidad", 85);
            Columna("Antes", "Antes", 150);
            Columna("Despues", "Después", 150);

            if (dgvBitacora.Columns.Contains("Fecha_Hora"))
                dgvBitacora.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvBitacora.ClearSelection();
        }

        private void dgvBitacora_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle == null || !dgvBitacora.Columns.Contains("Criticidad"))
                return;

            string criticidad = dgvBitacora.Rows[e.RowIndex].Cells["Criticidad"].Value?.ToString() ?? "";

            if (criticidad == GestorBitacora.CRITICA)
            {
                e.CellStyle.BackColor = FONDO_CRITICA;
                e.CellStyle.SelectionBackColor = SELECCION_CRITICA;
            }
            else if (criticidad == GestorBitacora.ADVERTENCIA)
            {
                e.CellStyle.BackColor = FONDO_ADVERTENCIA;
                e.CellStyle.SelectionBackColor = SELECCION_ADVERTENCIA;
            }
        }

        private void Columna(string nombre, string titulo, int peso)
        {
            if (!dgvBitacora.Columns.Contains(nombre))
                return;

            dgvBitacora.Columns[nombre].HeaderText = titulo;
            dgvBitacora.Columns[nombre].FillWeight = peso;
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
