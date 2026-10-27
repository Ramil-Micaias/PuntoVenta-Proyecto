using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // CU07: consulta de las existencias de productos y repuestos.
    // La pueden usar todos los roles; el precio de costo solo lo ve el administrador.
    public partial class FormConsultaStock : Form
    {
        private readonly GestorProducto gestorProducto = new GestorProducto();
        private Usuario? usuarioLogueado;

        // Color de las filas que están en el stock mínimo o por debajo.
        private readonly Color colorStockBajo = Color.FromArgb(254, 226, 226);

        public FormConsultaStock()
        {
            InitializeComponent();

            this.Load += FormConsultaStock_Load;
            this.btnAplicarFiltros.Click += btnAplicarFiltros_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.txtBuscar.KeyDown += txtBuscar_KeyDown;
            this.chkSoloBajoMinimo.CheckedChanged += chkSoloBajoMinimo_CheckedChanged;
            this.dgvStock.CellFormatting += dgvStock_CellFormatting;
        }

        // soloBajoMinimo: la pantalla abre mostrando solo las alertas de stock
        // (lo usa el acceso rápido "Verificar Alertas de Stock").
        public FormConsultaStock(Usuario? usuario, bool soloBajoMinimo) : this()
        {
            usuarioLogueado = usuario;
            chkSoloBajoMinimo.Checked = soloBajoMinimo;
        }

        private void FormConsultaStock_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvStock);
            CargarCategorias();
            CargarStock();
            txtBuscar.Focus();
        }

        private bool EsAdministrador()
        {
            return usuarioLogueado == null || usuarioLogueado.Nombre_Rol == "Administrador";
        }

        private void CargarCategorias()
        {
            try
            {
                DataTable categorias = gestorProducto.ObtenerCategorias();

                DataRow todas = categorias.NewRow();
                todas["Id_Categoria"] = DBNull.Value;
                todas["Nombre_Categoria"] = "Todas";
                categorias.Rows.InsertAt(todas, 0);

                cmbCategoria.DisplayMember = "Nombre_Categoria";
                cmbCategoria.ValueMember = "Id_Categoria";
                cmbCategoria.DataSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarStock()
        {
            try
            {
                int? idCategoria = null;

                object? valor = cmbCategoria.SelectedValue;
                if (valor != null && valor != DBNull.Value && int.TryParse(valor.ToString(), out int categoria))
                {
                    idCategoria = categoria;
                }

                DataTable stock = gestorProducto.ConsultarStock(txtBuscar.Text.Trim(), idCategoria, chkSoloBajoMinimo.Checked);
                dgvStock.DataSource = stock;
                ConfigurarColumnas();
                ActualizarResumen(stock);

                if (stock.Rows.Count == 0)
                {
                    lblResumen.Text = "No se encontraron productos para la búsqueda realizada.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar el stock: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvStock.Columns.Contains("Codigo"))
                dgvStock.Columns["Codigo"].HeaderText = "Código";

            if (dgvStock.Columns.Contains("Categoria"))
                dgvStock.Columns["Categoria"].HeaderText = "Categoría";

            if (dgvStock.Columns.Contains("Stock_Minimo"))
                dgvStock.Columns["Stock_Minimo"].HeaderText = "Stock Mínimo";

            if (dgvStock.Columns.Contains("Precio_Costo"))
            {
                dgvStock.Columns["Precio_Costo"].DefaultCellStyle.Format = "0.##";
                // El costo es un dato sensible del negocio: solo lo ve el administrador.
                dgvStock.Columns["Precio_Costo"].Visible = EsAdministrador();
            }

            if (dgvStock.Columns.Contains("Precio_Venta"))
                dgvStock.Columns["Precio_Venta"].DefaultCellStyle.Format = "0.##";
        }

        private void ActualizarResumen(DataTable stock)
        {
            int bajoMinimo = 0;

            foreach (DataRow fila in stock.Rows)
            {
                if (EstaBajoMinimo(fila["Stock_Actual"], fila["Stock_Minimo"]))
                {
                    bajoMinimo++;
                }
            }

            lblResumen.Text = "Productos: " + stock.Rows.Count + "   |   En el mínimo o por debajo: " + bajoMinimo;
        }

        private static bool EstaBajoMinimo(object stockActual, object stockMinimo)
        {
            if (stockActual == DBNull.Value || stockMinimo == DBNull.Value)
                return false;

            return Convert.ToInt32(stockActual) <= Convert.ToInt32(stockMinimo);
        }

        // Pinta de rojo claro las filas que necesitan reposición.
        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvStock.Columns.Contains("Stock_Actual"))
                return;

            DataGridViewRow fila = dgvStock.Rows[e.RowIndex];

            if (EstaBajoMinimo(fila.Cells["Stock_Actual"].Value, fila.Cells["Stock_Minimo"].Value))
            {
                e.CellStyle.BackColor = colorStockBajo;
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            CargarStock();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarStock();
                e.SuppressKeyPress = true;
            }
        }

        private void chkSoloBajoMinimo_CheckedChanged(object sender, EventArgs e)
        {
            // Mientras la pantalla se está abriendo todavía no hay que consultar.
            if (this.Visible)
                CargarStock();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
