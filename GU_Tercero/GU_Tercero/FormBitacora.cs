using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // Consulta de la bitácora del sistema (CU19). Solo la ven los usuarios con el
    // permiso VER_BITACORA. Es de solo lectura: muestra quién hizo cada operación,
    // cuándo, su criticidad y el estado anterior y posterior de lo que se cambió.
    public partial class FormBitacora : Form
    {
        private const string TODAS = "Todas";
        private const string TODOS = "Todos";

        private static readonly Color ROJO = Color.FromArgb(185, 28, 28);
        private static readonly Color NARANJA = Color.FromArgb(180, 83, 9);

        public FormBitacora()
        {
            InitializeComponent();

            this.Load += FormBitacora_Load;
            this.btnBuscar.Click += btnBuscar_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.txtTexto.KeyDown += txtTexto_KeyDown;
            this.dgvBitacora.SelectionChanged += dgvBitacora_SelectionChanged;
            this.dgvBitacora.DataBindingComplete += dgvBitacora_DataBindingComplete;
        }

        private void FormBitacora_Load(object? sender, EventArgs e)
        {
            Grillas.Configurar(dgvBitacora);

            cmbCriticidad.Items.Add(TODAS);
            cmbCriticidad.Items.AddRange(GestorBitacora.CRITICIDADES);
            cmbCriticidad.SelectedIndex = 0;

            cmbModulo.Items.Add(TODOS);
            cmbModulo.Items.AddRange(GestorBitacora.MODULOS);
            cmbModulo.SelectedIndex = 0;

            // Por defecto, la última semana.
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            Buscar();
        }

        private void Buscar()
        {
            try
            {
                string? criticidad = cmbCriticidad.Text == TODAS ? null : cmbCriticidad.Text;
                string? modulo = cmbModulo.Text == TODOS ? null : cmbModulo.Text;

                DataTable operaciones = GestorBitacora.Listar(dtpDesde.Value, dtpHasta.Value, criticidad, modulo, txtTexto.Text);
                dgvBitacora.DataSource = operaciones;

                lblCantidad.Text = operaciones.Rows.Count == 0
                    ? "No se encontraron operaciones para los filtros elegidos."
                    : "Operaciones encontradas: " + operaciones.Rows.Count;

                MostrarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Títulos y colores de la grilla: las operaciones críticas en rojo y las advertencias en naranja.
        private void dgvBitacora_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            string[] ocultas = { "Id_Bitacora", "Estado_Anterior", "Estado_Posterior" };
            foreach (string columna in ocultas)
            {
                if (dgvBitacora.Columns.Contains(columna))
                    dgvBitacora.Columns[columna].Visible = false;
            }

            if (dgvBitacora.Columns.Contains("Fecha_Hora"))
            {
                dgvBitacora.Columns["Fecha_Hora"].HeaderText = "Fecha y hora";
                dgvBitacora.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }

            if (dgvBitacora.Columns.Contains("Apellido_Nombre"))
                dgvBitacora.Columns["Apellido_Nombre"].HeaderText = "Apellido y nombre";

            if (dgvBitacora.Columns.Contains("Modulo"))
                dgvBitacora.Columns["Modulo"].HeaderText = "Módulo";

            // La Operación es la columna más ancha (la grilla reparte el ancho según este peso).
            if (dgvBitacora.Columns.Contains("Operacion"))
            {
                dgvBitacora.Columns["Operacion"].HeaderText = "Operación";
                dgvBitacora.Columns["Operacion"].FillWeight = 260;
            }

            if (dgvBitacora.Columns.Contains("Fecha_Hora"))
                dgvBitacora.Columns["Fecha_Hora"].FillWeight = 140;

            if (dgvBitacora.Columns.Contains("Apellido_Nombre"))
                dgvBitacora.Columns["Apellido_Nombre"].FillWeight = 140;

            foreach (DataGridViewRow fila in dgvBitacora.Rows)
            {
                string criticidad = fila.Cells["Criticidad"].Value?.ToString() ?? "";

                if (criticidad == GestorBitacora.CRITICA)
                    fila.DefaultCellStyle.ForeColor = ROJO;
                else if (criticidad == GestorBitacora.ADVERTENCIA)
                    fila.DefaultCellStyle.ForeColor = NARANJA;
            }
        }

        private void dgvBitacora_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarEstados();
        }

        // Muestra el estado anterior y el posterior (JSON) de la operación elegida.
        private void MostrarEstados()
        {
            if (dgvBitacora.CurrentRow == null || dgvBitacora.CurrentRow.DataBoundItem is not DataRowView fila)
            {
                txtAnterior.Clear();
                txtPosterior.Clear();
                return;
            }

            txtAnterior.Text = ConSaltos(GestorBitacora.FormatearJson(fila["Estado_Anterior"] as string));
            txtPosterior.Text = ConSaltos(GestorBitacora.FormatearJson(fila["Estado_Posterior"] as string));
        }

        // El TextBox necesita saltos de línea de Windows.
        private static string ConSaltos(string texto)
        {
            return texto.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            Buscar();
        }

        private void txtTexto_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Buscar();
            }
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
