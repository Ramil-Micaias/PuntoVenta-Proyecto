using System;
using System.Data;

using System;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;

namespace Vista
{
    public partial class FormProductos : Form
    {
        private int idProductoSeleccionado = 0;

        public FormProductos()
        {
            InitializeComponent();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            try
            {
                GestorProducto gestor = new GestorProducto();

                cmbCategoria.DisplayMember = "Nombre_Categoria";
                cmbCategoria.ValueMember = "Id_Categoria";
                cmbCategoria.DataSource = gestor.ObtenerCategorias();
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarProductos()
        {
            try
            {
                GestorProducto gestor = new GestorProducto();

                dgvProductos.DataSource = gestor.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar productos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimpiarControles()
        {
            idProductoSeleccionado = 0;

            txtNombreProducto.Clear();
            txtDescripcion.Clear();
            txtPrecioVenta.Clear();
            txtStockActual.Clear();
            txtStockMinimo.Clear();

            cmbCategoria.SelectedIndex = -1;

            if (txtBuscar != null)
            {
                txtBuscar.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(
                    txtPrecioVenta.Text.Trim(),
                    out decimal venta
                );

                int.TryParse(
                    txtStockActual.Text.Trim(),
                    out int stockAct
                );

                int.TryParse(
                    txtStockMinimo.Text.Trim(),
                    out int stockMin
                );

                int idCat = cmbCategoria.SelectedValue != null
                    ? Convert.ToInt32(cmbCategoria.SelectedValue)
                    : 0;

                Producto prod = new Producto()
                {
                    Nombre_Producto = txtNombreProducto.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Id_Categoria = idCat,
                    Precio_Venta = venta,
                    Stock_Actual = stockAct,
                    Stock_Minimo = stockMin,
                    Es_Repuesto = false,
                    Activo = true
                };

                GestorProducto gestor = new GestorProducto();

                gestor.RegistrarProducto(prod);

                MessageBox.Show(
                    "Producto registrado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto de la lista para modificar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                decimal.TryParse(
                    txtPrecioVenta.Text.Trim(),
                    out decimal venta
                );

                int.TryParse(
                    txtStockActual.Text.Trim(),
                    out int stockAct
                );

                int.TryParse(
                    txtStockMinimo.Text.Trim(),
                    out int stockMin
                );

                int idCat = cmbCategoria.SelectedValue != null
                    ? Convert.ToInt32(cmbCategoria.SelectedValue)
                    : 0;

                Producto prod = new Producto()
                {
                    Id_Producto = idProductoSeleccionado,
                    Nombre_Producto = txtNombreProducto.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Id_Categoria = idCat,
                    Precio_Venta = venta,
                    Stock_Actual = stockAct,
                    Stock_Minimo = stockMin,
                    Es_Repuesto = false,
                    Activo = true
                };

                GestorProducto gestor = new GestorProducto();

                gestor.ModificarProducto(prod);

                MessageBox.Show(
                    "Producto modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvProductos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            idProductoSeleccionado =
                Convert.ToInt32(fila.Cells["Id_Producto"].Value);

            txtNombreProducto.Text =
                fila.Cells["Nombre_Producto"].Value?.ToString() ?? "";

            txtDescripcion.Text =
                fila.Cells["Descripcion"].Value != DBNull.Value
                    ? fila.Cells["Descripcion"].Value?.ToString()
                    : "";

            txtPrecioVenta.Text =
                fila.Cells["Precio_Venta"].Value?.ToString() ?? "0";

            txtStockActual.Text =
                fila.Cells["Stock_Actual"].Value?.ToString() ?? "0";

            txtStockMinimo.Text =
                fila.Cells["Stock_Minimo"].Value?.ToString() ?? "0";

            if (fila.Cells["Id_Categoria"].Value != DBNull.Value &&
                fila.Cells["Id_Categoria"].Value != null)
            {
                cmbCategoria.SelectedValue =
                    Convert.ToInt32(fila.Cells["Id_Categoria"].Value);
            }
            else
            {
                cmbCategoria.SelectedIndex = -1;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EjecutarBusqueda()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();

                GestorProducto gestor = new GestorProducto();

                dgvProductos.DataSource = null;

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvProductos.DataSource =
                        gestor.ObtenerProductos();
                }
                else
                {
                    dgvProductos.DataSource =
                        gestor.BuscarProductos(filtro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar productos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }
    }
}