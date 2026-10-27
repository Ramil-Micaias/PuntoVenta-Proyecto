using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista;

namespace GU_Tercero
{
    // CU08: consulta de órdenes de reparación.
    // Desde acá se registra una orden nueva (CU05) y se abre una existente para actualizarla (CU09).
    public partial class FormTaller : Form
    {
        private readonly GestorTaller gestorTaller = new GestorTaller();
        private Usuario? usuarioLogueado;

        // Color de las órdenes pendientes cuya fecha prometida ya pasó.
        private readonly Color colorVencida = Color.FromArgb(254, 226, 226);

        public FormTaller()
        {
            InitializeComponent();

            this.Load += FormTaller_Load;
            this.btnBuscar.Click += btnBuscar_Click;
            this.txtBuscar.KeyDown += txtBuscar_KeyDown;
            this.chkSoloPendientes.CheckedChanged += Filtro_CheckedChanged;
            this.chkMisOrdenes.CheckedChanged += Filtro_CheckedChanged;
            this.btnNuevaOrden.Click += btnNuevaOrden_Click;
            this.btnVerOrden.Click += btnVerOrden_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.dgvOrdenes.CellDoubleClick += dgvOrdenes_CellDoubleClick;
            this.dgvOrdenes.CellFormatting += dgvOrdenes_CellFormatting;
        }

        public FormTaller(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private bool EsTecnico()
        {
            return usuarioLogueado != null && usuarioLogueado.Nombre_Rol == "Tecnico";
        }

        private void FormTaller_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvOrdenes);
            CargarFiltros();

            // El técnico arranca viendo solo las órdenes que tiene asignadas.
            if (EsTecnico())
            {
                chkMisOrdenes.Visible = true;
                chkMisOrdenes.Checked = true;
            }

            CargarOrdenes();
            txtBuscar.Focus();
        }

        private void CargarFiltros()
        {
            try
            {
                DataTable estados = gestorTaller.ObtenerEstados();
                DataRow todos = estados.NewRow();
                todos["Id_Estado"] = DBNull.Value;
                todos["Nombre_Estado"] = "Todos";
                estados.Rows.InsertAt(todos, 0);

                cmbEstado.DisplayMember = "Nombre_Estado";
                cmbEstado.ValueMember = "Id_Estado";
                cmbEstado.DataSource = estados;

                DataTable tecnicos = gestorTaller.ObtenerTecnicos();
                DataRow todosTecnicos = tecnicos.NewRow();
                todosTecnicos["Id_Usuario"] = DBNull.Value;
                todosTecnicos["Tecnico"] = "Todos";
                tecnicos.Rows.InsertAt(todosTecnicos, 0);

                cmbTecnico.DisplayMember = "Tecnico";
                cmbTecnico.ValueMember = "Id_Usuario";
                cmbTecnico.DataSource = tecnicos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los filtros: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static int? ValorSeleccionado(ComboBox combo)
        {
            object? valor = combo.SelectedValue;

            if (valor != null && valor != DBNull.Value && int.TryParse(valor.ToString(), out int numero))
            {
                return numero;
            }

            return null;
        }

        private void CargarOrdenes()
        {
            try
            {
                int? idEstado = ValorSeleccionado(cmbEstado);
                int? idTecnico = ValorSeleccionado(cmbTecnico);

                // "Solo mis órdenes" pisa el combo de técnico.
                cmbTecnico.Enabled = !chkMisOrdenes.Checked;
                if (chkMisOrdenes.Checked && usuarioLogueado != null)
                {
                    idTecnico = usuarioLogueado.Id_Usuario;
                }

                DataTable ordenes = gestorTaller.ConsultarOrdenes(
                    txtBuscar.Text.Trim(),
                    idEstado,
                    idTecnico,
                    chkSoloPendientes.Checked
                );

                dgvOrdenes.DataSource = ordenes;
                ConfigurarColumnas();

                if (ordenes.Rows.Count == 0)
                {
                    lblResumen.Text = "No se encontraron órdenes para la búsqueda realizada.";
                }
                else
                {
                    lblResumen.Text = "Órdenes: " + ordenes.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar las órdenes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvOrdenes.Columns.Contains("Ingreso"))
                dgvOrdenes.Columns["Ingreso"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dgvOrdenes.Columns.Contains("Prometida"))
                dgvOrdenes.Columns["Prometida"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvOrdenes.Columns.Contains("Tecnico"))
                dgvOrdenes.Columns["Tecnico"].HeaderText = "Técnico";

            if (dgvOrdenes.Columns.Contains("Total"))
                dgvOrdenes.Columns["Total"].DefaultCellStyle.Format = "0.##";
        }

        // Una orden está vencida si sigue pendiente y la fecha prometida ya pasó.
        private static bool EstaVencida(object prometida, object estado)
        {
            if (prometida == null || prometida == DBNull.Value)
                return false;

            string nombreEstado = Convert.ToString(estado) ?? string.Empty;

            if (nombreEstado == "Reparado" || nombreEstado == "Entregado" || nombreEstado == "Cancelado")
                return false;

            return Convert.ToDateTime(prometida).Date < DateTime.Today;
        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvOrdenes.Columns.Contains("Prometida"))
                return;

            DataGridViewRow fila = dgvOrdenes.Rows[e.RowIndex];

            if (EstaVencida(fila.Cells["Prometida"].Value, fila.Cells["Estado"].Value))
            {
                e.CellStyle.BackColor = colorVencida;
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void AbrirOrden(int idOrden)
        {
            if (usuarioLogueado == null)
            {
                MessageBox.Show(
                    "Debe iniciar sesión para trabajar con órdenes.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (FormOrdenReparacion formOrden = new FormOrdenReparacion(usuarioLogueado, idOrden))
            {
                if (formOrden.ShowDialog() == DialogResult.OK)
                {
                    CargarOrdenes();
                }
            }
        }

        private void VerOrdenSeleccionada()
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una orden de la lista.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idOrden = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["Id_Orden"].Value);
            AbrirOrden(idOrden);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarOrdenes();
                e.SuppressKeyPress = true;
            }
        }

        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {
            // Mientras la pantalla se está abriendo todavía no hay que consultar.
            if (this.Visible)
                CargarOrdenes();
        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            AbrirOrden(0);
        }

        private void btnVerOrden_Click(object sender, EventArgs e)
        {
            VerOrdenSeleccionada();
        }

        private void dgvOrdenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                VerOrdenSeleccionada();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
