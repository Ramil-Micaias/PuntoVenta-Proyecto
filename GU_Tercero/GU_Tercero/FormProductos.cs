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

        // Estado de la edición: al elegir un registro los datos quedan bloqueados;
        // se habilitan con Agregar o con Modificar y se cierran con Guardar/Confirmar o Cancelar.
        private enum Modo { Consulta, Agregando, Modificando }

        private Modo modoProducto = Modo.Consulta;
        private Modo modoCategoria = Modo.Consulta;

        private static readonly System.Drawing.Color NARANJA = System.Drawing.Color.FromArgb(217, 119, 6);

        public FormProductos()
        {
            InitializeComponent();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cmbIdioma.SelectionChangeCommitted += cmbIdioma_SelectionChangeCommitted;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvProductos);
            Grillas.Configurar(dgvCategorias);

            // Cada vez que se recargan las grillas se traducen los títulos de las columnas.
            dgvProductos.DataBindingComplete += Grilla_DataBindingComplete;
            dgvCategorias.DataBindingComplete += Grilla_DataBindingComplete;

            CargarComboLenguajes();
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
                Idioma.TraducirColumnas(dgvCategorias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    Idioma.Texto("Msg_ErrorCategorias", "Error al cargar las categorías: ") + ex.Message,
                    Idioma.Texto("Titulo_Error", "Error"),
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
                    Idioma.Texto("Msg_ErrorProductos", "Error al cargar productos: ") + ex.Message,
                    Idioma.Texto("Titulo_Error", "Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Consulta: datos bloqueados, Agregar y (con un producto elegido) Modificar.
        // Agregando: Guardar y Cancelar. Modificando: Confirmar y Cancelar.
        private void AplicarModoProducto(Modo modo)
        {
            modoProducto = modo;
            bool editando = modo != Modo.Consulta;

            txtNombreProducto.ReadOnly = !editando;
            txtDescripcion.ReadOnly = !editando;
            txtPrecioVenta.ReadOnly = !editando;
            txtStockActual.ReadOnly = !editando;
            txtStockMinimo.ReadOnly = !editando;
            cmbCategoria.Enabled = editando;

            // Mientras se edita no se puede elegir otro producto.
            dgvProductos.Enabled = !editando;
            txtBuscar.Enabled = !editando;

            btnNuevo.Visible = modo == Modo.Consulta;
            btnModificar.Visible = modo == Modo.Consulta && idProductoSeleccionado != 0;
            btnGuardar.Visible = modo == Modo.Agregando;
            btnConfirmar.Visible = modo == Modo.Modificando;
            btnCancelarEdicion.Visible = editando;

            if (modo == Modo.Agregando)
            {
                grpDetalleProducto.Text = Idioma.Texto("Grp_NuevoProducto", "Nuevo Producto");
                AvisoEdicion(lblResultadoProducto, Idioma.Texto("Msg_ModoNuevo", "Complete los datos y presione Guardar, o Cancelar para descartar."));
            }
            else if (modo == Modo.Modificando)
            {
                grpDetalleProducto.Text = Idioma.Texto("Grp_ModificandoProducto", "Modificando Producto");
                AvisoEdicion(lblResultadoProducto, Idioma.Texto("Msg_ModoModificar", "Modifique los datos y presione Confirmar para guardar, o Cancelar para descartar."));
            }
            else
            {
                grpDetalleProducto.Text = Idioma.Texto("grpDetalleProducto", "Detalle del Producto");
            }
        }

        // Aviso en naranja mientras se está editando.
        private static void AvisoEdicion(Label destino, string texto)
        {
            destino.ForeColor = NARANJA;
            destino.Text = texto;
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
            AplicarModoProducto(Modo.Consulta);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);

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

                Mensajes.Exito(lblResultadoProducto, Idioma.Texto("Msg_ProductoRegistrado", "Producto registrado con éxito."));

                CargarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Idioma.Texto("Titulo_Atencion", "Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);

            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    Idioma.Texto("Msg_SeleccioneProducto", "Debe seleccionar un producto de la lista para modificar."),
                    Idioma.Texto("Titulo_Atencion", "Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            AplicarModoProducto(Modo.Modificando);
            txtNombreProducto.Focus();
        }

        // Guarda los cambios del producto que se está modificando.
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    Idioma.Texto("Msg_SeleccioneProducto", "Debe seleccionar un producto de la lista para modificar."),
                    Idioma.Texto("Titulo_Atencion", "Atención"),
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

                Mensajes.Exito(lblResultadoProducto, Idioma.Texto("Msg_ProductoModificado", "Producto modificado correctamente."));

                CargarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Idioma.Texto("Titulo_Atencion", "Atención"),
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

            Mensajes.Limpiar(lblResultadoProducto);
            MostrarProducto(dgvProductos.Rows[e.RowIndex]);
        }

        // Carga en los campos (bloqueados) los datos del producto elegido.
        private void MostrarProducto(DataGridViewRow fila)
        {
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

            AplicarModoProducto(Modo.Consulta);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);
            LimpiarControles();
            AplicarModoProducto(Modo.Agregando);
            cmbCategoria.Focus();
        }

        // Descarta lo que se estaba cargando o modificando y vuelve a bloquear los datos.
        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);

            if (modoProducto == Modo.Modificando)
            {
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["Id_Producto"].Value) == idProductoSeleccionado)
                    {
                        MostrarProducto(fila);
                        fila.Selected = true;
                        return;
                    }
                }
            }

            LimpiarControles();
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
        // Idioma (CU18)
        // ---------------------------------------------

        // El formulario siempre abre en Español; el combo permite pasarlo a Inglés.
        private void CargarComboLenguajes()
        {
            Idioma.Actual = Idioma.ESPANOL;

            cmbIdioma.DataSource = Idioma.ObtenerIdiomas();
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.ValueMember = "InfoCultura";
            cmbIdioma.SelectedValue = Idioma.Actual;

            Idioma.CargarIdioma(this.Controls, this);
        }

        private void cmbIdioma_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            Idioma.Actual = cmbIdioma.SelectedValue?.ToString() ?? Idioma.ESPANOL;
            Idioma.CargarIdioma(this.Controls, this);
            AplicarModoProducto(modoProducto);
            AplicarModoCategoria(modoCategoria);
        }

        private void Grilla_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            Idioma.TraducirColumnas((DataGridView)sender!);
        }

        // ---------------------------------------------
        // Categorías
        // ---------------------------------------------

        // Igual que en productos: el nombre queda bloqueado hasta Agregar o Modificar.
        // Eliminar (rojo, aparte) solo aparece con una categoría elegida y sin editar.
        private void AplicarModoCategoria(Modo modo)
        {
            modoCategoria = modo;
            bool editando = modo != Modo.Consulta;
            bool haySeleccion = idCategoriaSeleccionada != 0;

            txtNombreCategoria.ReadOnly = !editando;
            dgvCategorias.Enabled = !editando;

            btnNuevaCategoria.Visible = modo == Modo.Consulta;
            btnModificarCategoria.Visible = modo == Modo.Consulta && haySeleccion;
            btnEliminarCategoria.Visible = modo == Modo.Consulta && haySeleccion;
            btnGuardarCategoria.Visible = modo == Modo.Agregando;
            btnConfirmarCategoria.Visible = modo == Modo.Modificando;
            btnCancelarCategoria.Visible = editando;

            if (modo == Modo.Agregando)
            {
                grpGestionCategoria.Text = Idioma.Texto("Grp_NuevaCategoria", "Nueva Categoría");
                AvisoEdicion(lblResultadoCategoria, Idioma.Texto("Msg_ModoNuevo", "Complete los datos y presione Guardar, o Cancelar para descartar."));
            }
            else if (modo == Modo.Modificando)
            {
                grpGestionCategoria.Text = Idioma.Texto("Grp_ModificandoCategoria", "Modificando Categoría");
                AvisoEdicion(lblResultadoCategoria, Idioma.Texto("Msg_ModoModificar", "Modifique los datos y presione Confirmar para guardar, o Cancelar para descartar."));
            }
            else
            {
                grpGestionCategoria.Text = Idioma.Texto("grpGestionCategoria", "Gestión de Categoría");
            }
        }

        private void LimpiarCategoria()
        {
            idCategoriaSeleccionada = 0;
            txtNombreCategoria.Clear();
            dgvCategorias.ClearSelection();
            AplicarModoCategoria(Modo.Consulta);
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

            Mensajes.Limpiar(lblResultadoCategoria);
            AplicarModoCategoria(Modo.Consulta);
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);
            LimpiarCategoria();
            AplicarModoCategoria(Modo.Agregando);
            txtNombreCategoria.Focus();
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);

            try
            {
                GestorProducto gestor = new GestorProducto();
                gestor.RegistrarCategoria(txtNombreCategoria.Text);

                Mensajes.Exito(lblResultadoCategoria, Idioma.Texto("Msg_CategoriaRegistrada", "Categoría registrada con éxito."));

                RefrescarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Idioma.Texto("Titulo_Atencion", "Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);
            AplicarModoCategoria(Modo.Modificando);
            txtNombreCategoria.Focus();
        }

        // Guarda el nuevo nombre de la categoría que se está modificando.
        private void btnConfirmarCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);

            try
            {
                GestorProducto gestor = new GestorProducto();
                gestor.ModificarCategoria(idCategoriaSeleccionada, txtNombreCategoria.Text);

                Mensajes.Exito(lblResultadoCategoria, Idioma.Texto("Msg_CategoriaModificada", "Categoría modificada correctamente."));

                RefrescarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Idioma.Texto("Titulo_Atencion", "Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Descarta los cambios y vuelve a mostrar la categoría como estaba.
        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);

            if (modoCategoria == Modo.Modificando)
            {
                foreach (DataGridViewRow fila in dgvCategorias.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["Id_Categoria"].Value) == idCategoriaSeleccionada)
                    {
                        txtNombreCategoria.Text = fila.Cells["Nombre_Categoria"].Value?.ToString() ?? "";
                        AplicarModoCategoria(Modo.Consulta);
                        return;
                    }
                }
            }

            LimpiarCategoria();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoCategoria);

            DialogResult respuesta = MessageBox.Show(
                string.Format(Idioma.Texto("Msg_ConfirmarEliminarCategoria", "¿Desea dar de baja la categoría \"{0}\"? Queda guardada pero ya no se ofrece al cargar productos."), txtNombreCategoria.Text.Trim()),
                Idioma.Texto("Titulo_Confirmar", "Confirmar"),
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

                Mensajes.Exito(lblResultadoCategoria, Idioma.Texto("Msg_CategoriaEliminada", "Categoría dada de baja correctamente."));

                RefrescarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Idioma.Texto("Titulo_Atencion", "Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
