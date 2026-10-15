using System;
using System.Data;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;

namespace Vista
{
    public partial class FormProductos : Form
    {
        private int idProductoSeleccionado = 0;
        private int idCategoriaSeleccionada = 0;

        public FormProductos()
        {
            InitializeComponent();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvProductos);
            Grillas.Configurar(dgvCategorias);
            CargarCategorias();
            CargarProductos();
            LimpiarControles();
            LimpiarCategoria();
        }

        private void CargarCategorias()
        {
            try
            {
                GestorProducto gestor = new GestorProducto();
                DataTable categorias = gestor.ObtenerCategorias();

                cmbCategoria.DisplayMember = "Nombre_Categoria";
                cmbCategoria.ValueMember = "Id_Categoria";
                cmbCategoria.DataSource = categorias;
                cmbCategoria.SelectedIndex = -1;

                dgvCategorias.DataSource = categorias.Copy();

                if (dgvCategorias.Columns.Contains("Nombre_Categoria"))
                    dgvCategorias.Columns["Nombre_Categoria"].HeaderText = "Categoría";
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
                string filtro = txtBuscar.Text.Trim();
                GestorProducto gestor = new GestorProducto();

                dgvProductos.DataSource = string.IsNullOrEmpty(filtro)
                    ? gestor.ObtenerProductos()
                    : gestor.BuscarProductos(filtro);
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

        // agregando -> solo Guardar; con un producto elegido -> Modificar (y Agregar para empezar otro).
        private void MostrarBotones(bool agregando)
        {
            btnNuevo.Visible = !agregando;
            btnGuardar.Visible = agregando;
            btnModificar.Visible = !agregando && idProductoSeleccionado != 0;
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

            dgvProductos.ClearSelection();
            MostrarBotones(false);
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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Escudo protector contra clics en los encabezados de columna
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            if (fila.Cells["Id_Producto"].Value != null && fila.Cells["Id_Producto"].Value != DBNull.Value)
            {
                idProductoSeleccionado = Convert.ToInt32(fila.Cells["Id_Producto"].Value);
            }

            txtNombreProducto.Text = fila.Cells["Nombre_Producto"].Value != DBNull.Value
                ? fila.Cells["Nombre_Producto"].Value?.ToString() ?? ""
                : "";

            txtDescripcion.Text = fila.Cells["Descripcion"].Value != DBNull.Value
                ? fila.Cells["Descripcion"].Value?.ToString() ?? ""
                : "";

            txtPrecioVenta.Text = fila.Cells["Precio_Venta"].Value != DBNull.Value
                ? fila.Cells["Precio_Venta"].Value?.ToString() ?? "0"
                : "0";

            txtStockActual.Text = fila.Cells["Stock_Actual"].Value != DBNull.Value
                ? fila.Cells["Stock_Actual"].Value?.ToString() ?? "0"
                : "0";

            txtStockMinimo.Text = fila.Cells["Stock_Minimo"].Value != DBNull.Value
                ? fila.Cells["Stock_Minimo"].Value?.ToString() ?? "0"
                : "0";

            if (fila.Cells["Id_Categoria"].Value != null && fila.Cells["Id_Categoria"].Value != DBNull.Value)
            {
                cmbCategoria.SelectedValue = Convert.ToInt32(fila.Cells["Id_Categoria"].Value);
            }
            else
            {
                cmbCategoria.SelectedIndex = -1;
            }

            MostrarBotones(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MostrarBotones(true);
            cmbCategoria.Focus();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // ---------------------------------------------
        // Categorías
        // ---------------------------------------------

        // agregando -> solo Guardar; con una categoría elegida -> Modificar / Eliminar (y Agregar).
        private void MostrarBotonesCategoria(bool agregando)
        {
            bool haySeleccion = idCategoriaSeleccionada != 0;

            btnNuevaCategoria.Visible = !agregando;
            btnGuardarCategoria.Visible = agregando;
            btnModificarCategoria.Visible = !agregando && haySeleccion;
            btnEliminarCategoria.Visible = !agregando && haySeleccion;
        }

        private void LimpiarCategoria()
        {
            idCategoriaSeleccionada = 0;
            txtNombreCategoria.Clear();
            dgvCategorias.ClearSelection();
            MostrarBotonesCategoria(false);
        }

        // Recarga las categorías en la grilla y en el combo de productos.
        private void RefrescarCategorias()
        {
            CargarCategorias();
            CargarProductos();
            LimpiarCategoria();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];

            idCategoriaSeleccionada = Convert.ToInt32(fila.Cells["Id_Categoria"].Value);
            txtNombreCategoria.Text = fila.Cells["Nombre_Categoria"].Value?.ToString() ?? "";

            MostrarBotonesCategoria(false);
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();
            MostrarBotonesCategoria(true);
            txtNombreCategoria.Focus();
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                GestorProducto gestor = new GestorProducto();
                gestor.RegistrarCategoria(txtNombreCategoria.Text);

                MessageBox.Show(
                    "Categoría registrada con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                RefrescarCategorias();
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

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                GestorProducto gestor = new GestorProducto();
                gestor.ModificarCategoria(idCategoriaSeleccionada, txtNombreCategoria.Text);

                MessageBox.Show(
                    "Categoría modificada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                RefrescarCategorias();
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

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar la categoría \"" + txtNombreCategoria.Text.Trim() + "\"?",
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
                GestorProducto gestor = new GestorProducto();
                gestor.InactivarCategoria(idCategoriaSeleccionada);

                MessageBox.Show(
                    "Categoría eliminada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                RefrescarCategorias();
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
    }
}
