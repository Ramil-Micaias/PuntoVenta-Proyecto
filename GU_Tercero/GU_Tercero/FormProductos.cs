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
        private bool productoActivo = true;
        private Modo modoCategoria = Modo.Consulta;

        private static readonly System.Drawing.Color NARANJA = System.Drawing.Color.FromArgb(217, 119, 6);
        private static readonly System.Drawing.Color ROJO = System.Drawing.Color.FromArgb(239, 68, 68);
        private static readonly System.Drawing.Color VERDE = System.Drawing.Color.FromArgb(16, 185, 129);
        private static readonly System.Drawing.Color GRIS = System.Drawing.Color.FromArgb(148, 163, 184);

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
            CargarProveedores();
            CargarProductos();
            LimpiarControles();
            LimpiarCategoria();
        }

        // Proveedores para asociar al producto. Se cargan todos para poder mostrar el de cada producto
        // aunque esté dado de baja (con la aclaración); al guardar solo se acepta uno activo.
        private void CargarProveedores()
        {
            try
            {
                DataTable proveedores = new GestorProveedores().ObtenerTodosProveedores();
                proveedores.Columns.Add("Nombre", typeof(string),
                    "Razon_Social + IIF(Activo, '', ' (" + Idioma.Texto("Txt_DadoDeBaja", "dado de baja") + ")')");
                proveedores.DefaultView.Sort = "Activo DESC, Razon_Social ASC";

                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "Id_Proveedor";
                cmbProveedor.DataSource = proveedores.DefaultView;
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    Idioma.Texto("Msg_ErrorProveedores", "Error al cargar los proveedores: ") + ex.Message,
                    Idioma.Texto("Titulo_Error", "Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
            cmbProveedor.Enabled = editando;

            // Mientras se edita no se puede elegir otro producto (la grilla sigue habilitada
            // para poder desplazarla; los clics se ignoran en dgvProductos_CellClick).
            txtBuscar.Enabled = !editando;

            btnNuevo.Visible = modo == Modo.Consulta;
            btnModificar.Visible = modo == Modo.Consulta && idProductoSeleccionado != 0;
            btnGuardar.Visible = modo == Modo.Agregando;
            btnConfirmar.Visible = modo == Modo.Modificando;
            btnCancelarEdicion.Visible = editando;

            // Inactivar (rojo) si el producto está activo; Activar (verde) si está dado de baja.
            btnEstadoProducto.Visible = modo == Modo.Consulta && idProductoSeleccionado != 0;
            btnEstadoProducto.Text = productoActivo ? Idioma.Texto("Btn_Inactivar", "Inactivar") : Idioma.Texto("Btn_Activar", "Activar");
            btnEstadoProducto.BackColor = productoActivo ? ROJO : VERDE;

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
            destino.Visible = true;
        }

        private void LimpiarControles()
        {
            idProductoSeleccionado = 0;
            productoActivo = true;

            txtNombreProducto.Clear();
            txtDescripcion.Clear();
            txtPrecioVenta.Clear();
            txtStockActual.Clear();
            txtStockMinimo.Clear();

            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;

            dgvProductos.ClearSelection();
            AplicarModoProducto(Modo.Consulta);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);

            try
            {
                Producto prod = LeerProducto();

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
                Producto prod = LeerProducto();

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
            // Escudo protector contra clics en los encabezados de columna.
            // Mientras se agrega o modifica no se puede elegir otro producto.
            if (e.RowIndex < 0 || modoProducto != Modo.Consulta)
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

            productoActivo = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);

            if (fila.Cells["Id_Categoria"].Value != null && fila.Cells["Id_Categoria"].Value != DBNull.Value)
            {
                cmbCategoria.SelectedValue = Convert.ToInt32(fila.Cells["Id_Categoria"].Value);
            }
            else
            {
                cmbCategoria.SelectedIndex = -1;
            }

            // Proveedor asociado (si está dado de baja no figura en el combo y hay que elegir otro al modificar).
            cmbProveedor.SelectedIndex = -1;
            if (fila.Cells["Id_Proveedor"].Value != null && fila.Cells["Id_Proveedor"].Value != DBNull.Value)
            {
                cmbProveedor.SelectedValue = Convert.ToInt32(fila.Cells["Id_Proveedor"].Value);
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

        // Lee los campos del producto. Todos son obligatorios y los números tienen que ser números
        // (antes un precio con letras se guardaba como 0 sin avisar).
        private Producto LeerProducto()
        {
            if (cmbCategoria.SelectedValue == null)
                throw new Exception(Idioma.Texto("Msg_FaltaCategoria", "Debe seleccionar una categoría."));

            if (cmbProveedor.SelectedValue == null)
                throw new Exception(Idioma.Texto("Msg_FaltaProveedor", "Debe seleccionar el proveedor del producto."));

            if (cmbProveedor.SelectedItem is DataRowView proveedor && !Convert.ToBoolean(proveedor["Activo"]))
                throw new Exception(Idioma.Texto("Msg_ProveedorDadoDeBaja", "El proveedor elegido está dado de baja. Elija un proveedor activo."));

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text)
                || string.IsNullOrWhiteSpace(txtPrecioVenta.Text) || string.IsNullOrWhiteSpace(txtStockActual.Text)
                || string.IsNullOrWhiteSpace(txtStockMinimo.Text))
                throw new Exception(Idioma.Texto("Msg_CamposObligatorios", "Todos los campos son obligatorios."));

            if (!LeerPrecio(txtPrecioVenta.Text, out decimal precio))
                throw new Exception(Idioma.Texto("Msg_PrecioInvalido", "El precio de venta debe ser un número (por ejemplo 15000 o 15000,50)."));

            if (!int.TryParse(txtStockActual.Text.Trim(), out int stockActual))
                throw new Exception(Idioma.Texto("Msg_StockActualInvalido", "El stock actual debe ser un número entero."));

            if (!int.TryParse(txtStockMinimo.Text.Trim(), out int stockMinimo))
                throw new Exception(Idioma.Texto("Msg_StockMinimoInvalido", "El stock mínimo debe ser un número entero."));

            return new Producto()
            {
                Id_Producto = idProductoSeleccionado,
                Nombre_Producto = txtNombreProducto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Id_Categoria = Convert.ToInt32(cmbCategoria.SelectedValue),
                Id_Proveedor = Convert.ToInt32(cmbProveedor.SelectedValue),
                Precio_Venta = precio,
                Stock_Actual = stockActual,
                Stock_Minimo = stockMinimo,
                // Al modificar se mantiene el estado que tenía (un inactivo sigue inactivo).
                Activo = modoProducto == Modo.Agregando || productoActivo
            };
        }

        // Acepta el precio con coma o con punto decimal (15000,50 o 15000.50) y con punto de miles (15.000 o 15.000,50).
        private static bool LeerPrecio(string texto, out decimal precio)
        {
            texto = texto.Trim().Replace("$", string.Empty).Replace(" ", string.Empty);

            // Si hay coma, la coma es el decimal y los puntos son de miles (formato argentino).
            if (texto.Contains(','))
                return decimal.TryParse(texto, System.Globalization.NumberStyles.Number, new System.Globalization.CultureInfo("es-AR"), out precio);

            // Un solo punto seguido de 1 o 2 dígitos es el decimal (15000.50); si no, los puntos son de miles (15.000).
            int punto = texto.LastIndexOf('.');
            bool puntoDecimal = punto >= 0 && texto.IndexOf('.') == punto && texto.Length - punto - 1 <= 2;

            if (!puntoDecimal)
                texto = texto.Replace(".", string.Empty);

            return decimal.TryParse(texto, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out precio);
        }

        // Inactivar (baja lógica) o Activar, según el estado del producto elegido.
        private void btnEstadoProducto_Click(object? sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultadoProducto);

            if (idProductoSeleccionado == 0)
                return;

            try
            {
                GestorProducto gestor = new GestorProducto();
                string mensaje;

                if (productoActivo)
                {
                    DialogResult resultado = MessageBox.Show(
                        Idioma.Texto("Msg_ConfirmarInactivarProducto", "¿Está seguro de que desea inactivar este producto? No se podrá vender ni comprar hasta que se vuelva a activar."),
                        Idioma.Texto("Titulo_Confirmar", "Confirmar"),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado != DialogResult.Yes)
                        return;

                    gestor.InactivarProducto(idProductoSeleccionado);
                    mensaje = Idioma.Texto("Msg_ProductoInactivado", "Producto inactivado correctamente.");
                }
                else
                {
                    gestor.ActivarProducto(idProductoSeleccionado);
                    mensaje = Idioma.Texto("Msg_ProductoActivado", "Producto activado correctamente.");
                }

                CargarProductos();
                LimpiarControles();
                Mensajes.Exito(lblResultadoProducto, mensaje);
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
            DataGridView grilla = (DataGridView)sender!;
            Idioma.TraducirColumnas(grilla);

            // Los productos dados de baja se ven en gris.
            if (grilla == dgvProductos && grilla.Columns.Contains("Activo"))
            {
                foreach (DataGridViewRow fila in grilla.Rows)
                {
                    bool activo = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);
                    fila.DefaultCellStyle.ForeColor = activo ? grilla.DefaultCellStyle.ForeColor : GRIS;
                }
            }
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
            CargarProveedores();
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
