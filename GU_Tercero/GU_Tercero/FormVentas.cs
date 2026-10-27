using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormVentas : Form
    {
        private readonly GestorVentas gestorVentas = new GestorVentas();
        private readonly DataTable carrito = new DataTable();
        private readonly DataTable pagos = new DataTable();
        private Usuario? usuarioLogueado;

        public FormVentas()
        {
            InitializeComponent();

            this.btnBuscar.Click += btnBuscar_Click;
            this.btnAgregarCarrito.Click += btnAgregarCarrito_Click;
            this.btnQuitarSeleccionado.Click += btnQuitarSeleccionado_Click;
            this.btnConfirmarVenta.Click += btnConfirmarVenta_Click;
            this.btnCancelarOperacion.Click += btnCancelarOperacion_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.numDescuento.ValueChanged += numDescuento_ValueChanged;
            this.txtBuscar.KeyDown += txtBuscar_KeyDown;
            this.dgvResultados.CellDoubleClick += dgvResultados_CellDoubleClick;
            this.btnAgregarPago.Click += btnAgregarPago_Click;
            this.txtImportePago.KeyDown += txtImportePago_KeyDown;
            this.dgvPagos.CellDoubleClick += dgvPagos_CellDoubleClick;
        }

        public FormVentas(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrids();
            CrearCarrito();
            CrearPagos();
            CargarCategorias();
            CargarMetodosPago();
            BuscarProductos();
            ActualizarResumen();
            txtBuscar.Focus();
        }

        private void ConfigurarGrids()
        {
            foreach (DataGridView grid in new DataGridView[] { dgvResultados, dgvCarrito, dgvPagos })
            {
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;
                grid.ReadOnly = true;
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.RowHeadersVisible = false;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                grid.DefaultCellStyle.BackColor = Color.White;
                grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                grid.RowTemplate.Height = Grillas.AltoFila(grid);
            }
        }

        private void CrearCarrito()
        {
            carrito.Columns.Add("Id_Producto", typeof(int));
            carrito.Columns.Add("Codigo", typeof(string));
            carrito.Columns.Add("Producto", typeof(string));
            carrito.Columns.Add("Cantidad", typeof(int));
            carrito.Columns.Add("Precio_Unitario", typeof(decimal));
            carrito.Columns.Add("Subtotal", typeof(decimal));

            dgvCarrito.DataSource = carrito;

            OcultarColumna(dgvCarrito, "Id_Producto");
            OcultarColumna(dgvCarrito, "Codigo");
            EncabezadoColumna(dgvCarrito, "Producto", "Producto", 1);
            EncabezadoColumna(dgvCarrito, "Cantidad", "Cantidad", 2);
            EncabezadoColumna(dgvCarrito, "Precio_Unitario", "Precio Unit.", 3, "0.##");
            EncabezadoColumna(dgvCarrito, "Subtotal", "Subtotal", 4, "0.##");
        }

        // Lista de pagos de la venta (se usa cuando se paga con más de un método).
        private void CrearPagos()
        {
            pagos.Columns.Add("Id_MetodoPago", typeof(int));
            pagos.Columns.Add("Metodo", typeof(string));
            pagos.Columns.Add("Importe", typeof(decimal));

            dgvPagos.DataSource = pagos;

            OcultarColumna(dgvPagos, "Id_MetodoPago");
            EncabezadoColumna(dgvPagos, "Metodo", "Método", 0);
            EncabezadoColumna(dgvPagos, "Importe", "Importe", 1, "0.##");
        }

        private void CargarCategorias()
        {
            try
            {
                DataTable categorias = gestorVentas.ObtenerCategorias();

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

        private void CargarMetodosPago()
        {
            try
            {
                cmbMetodoPago.DisplayMember = "Nombre";
                cmbMetodoPago.ValueMember = "Id_MetodoPago";
                cmbMetodoPago.DataSource = gestorVentas.ObtenerMetodosPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar métodos de pago: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BuscarProductos()
        {
            try
            {
                int? idCategoria = null;

                object? valor = cmbCategoria.SelectedValue;
                if (valor != null && valor != DBNull.Value && int.TryParse(valor.ToString(), out int categoria))
                {
                    idCategoria = categoria;
                }

                DataTable productos = gestorVentas.BuscarProductos(txtBuscar.Text.Trim(), idCategoria);

                dgvResultados.DataSource = productos;
                ConfigurarColumnasProductos();

                if (productos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "El producto no existe en el catálogo para la búsqueda realizada.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
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

        private void ConfigurarColumnasProductos()
        {
            OcultarColumna(dgvResultados, "Id_Producto");
            OcultarColumna(dgvResultados, "Nombre_Producto");
            OcultarColumna(dgvResultados, "Descripcion");
            OcultarColumna(dgvResultados, "Precio_Costo");
            OcultarColumna(dgvResultados, "Stock_Minimo");
            OcultarColumna(dgvResultados, "Id_Categoria");

            OcultarColumna(dgvResultados, "Codigo");
            EncabezadoColumna(dgvResultados, "Producto", "Producto", 1);
            EncabezadoColumna(dgvResultados, "Precio_Venta", "Precio", 2, "0.##");
            EncabezadoColumna(dgvResultados, "Stock_Actual", "Stock", 3);
            EncabezadoColumna(dgvResultados, "NombreCategoria", "Categoría", 4);
        }

        private static void OcultarColumna(DataGridView grid, string nombre)
        {
            if (grid.Columns.Contains(nombre))
            {
                grid.Columns[nombre].Visible = false;
            }
        }

        private static void EncabezadoColumna(DataGridView grid, string nombre, string texto, int posicion, string? formato = null)
        {
            if (!grid.Columns.Contains(nombre))
            {
                return;
            }

            DataGridViewColumn columna = grid.Columns[nombre];
            columna.HeaderText = texto;
            columna.DisplayIndex = posicion;

            if (!string.IsNullOrEmpty(formato))
            {
                columna.DefaultCellStyle.Format = formato;
            }
        }

        private void AgregarAlCarrito()
        {
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto de la lista.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            OcultarResultado();

            DataRow fila = ((DataRowView)dgvResultados.CurrentRow.DataBoundItem).Row;

            int idProducto = Convert.ToInt32(fila["Id_Producto"]);
            string codigo = Convert.ToString(fila["Codigo"]) ?? string.Empty;
            string producto = Convert.ToString(fila["Producto"]) ?? string.Empty;
            decimal precio = Convert.ToDecimal(fila["Precio_Venta"]);
            int stockDisponible = Convert.ToInt32(fila["Stock_Actual"]);
            int cantidad = (int)numCantidad.Value;

            DataRow? existente = null;

            foreach (DataRow item in carrito.Rows)
            {
                if (Convert.ToInt32(item["Id_Producto"]) == idProducto)
                {
                    existente = item;
                    break;
                }
            }

            int cantidadActual = existente == null ? 0 : Convert.ToInt32(existente["Cantidad"]);
            int cantidadTotal = cantidadActual + cantidad;

            if (cantidadTotal > stockDisponible)
            {
                MessageBox.Show(
                    "Stock insuficiente para \"" + producto + "\".\n" +
                    "Stock disponible: " + stockDisponible + " unidades. Cantidad solicitada: " + cantidadTotal + ".",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (existente == null)
            {
                DataRow nuevo = carrito.NewRow();
                nuevo["Id_Producto"] = idProducto;
                nuevo["Codigo"] = codigo;
                nuevo["Producto"] = producto;
                nuevo["Cantidad"] = cantidad;
                nuevo["Precio_Unitario"] = precio;
                nuevo["Subtotal"] = cantidad * precio;
                carrito.Rows.Add(nuevo);
            }
            else
            {
                existente["Cantidad"] = cantidadTotal;
                existente["Subtotal"] = cantidadTotal * precio;
            }

            ActualizarResumen();
        }

        // Saca el comprobante de la venta anterior y vuelve a mostrar la ayuda.
        private void OcultarResultado()
        {
            lblResultado.Visible = false;
            lblAyuda.Visible = true;
        }

        private void QuitarSeleccionado()
        {
            if (dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto del carrito.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvCarrito.CurrentRow.DataBoundItem is DataRowView vista)
            {
                carrito.Rows.Remove(vista.Row);
                ActualizarResumen();
            }
        }

        private void ActualizarResumen()
        {
            decimal subtotal = 0;
            int unidades = 0;

            foreach (DataRow item in carrito.Rows)
            {
                subtotal += Convert.ToDecimal(item["Subtotal"]);
                unidades += Convert.ToInt32(item["Cantidad"]);
            }

            decimal descuento = Venta.CalcularDescuento(subtotal, numDescuento.Value);

            lblSubtotalValor.Text = FormatoMoneda(subtotal);
            lblTotalNeto.Text = FormatoMoneda(subtotal - descuento);
            lblResumenCarrito.Text = "Artículos: " + unidades + "   Subtotal: " + FormatoMoneda(subtotal);

            ActualizarPagos();
        }

        private decimal CalcularTotalNeto()
        {
            decimal subtotal = 0;

            foreach (DataRow item in carrito.Rows)
            {
                subtotal += Convert.ToDecimal(item["Subtotal"]);
            }

            return subtotal - Venta.CalcularDescuento(subtotal, numDescuento.Value);
        }

        private decimal CalcularTotalPagado()
        {
            decimal pagado = 0;

            foreach (DataRow pago in pagos.Rows)
            {
                pagado += Convert.ToDecimal(pago["Importe"]);
            }

            return pagado;
        }

        // Muestra cuánto falta pagar cuando se carga más de un pago.
        private void ActualizarPagos()
        {
            if (pagos.Rows.Count == 0)
            {
                lblFaltaPagar.Text = "Se cobra todo con el método elegido.";
                lblFaltaPagar.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            decimal falta = CalcularTotalNeto() - CalcularTotalPagado();

            if (falta > 0)
            {
                lblFaltaPagar.Text = "Falta pagar: " + FormatoMoneda(falta);
                lblFaltaPagar.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else if (falta < 0)
            {
                lblFaltaPagar.Text = "Los pagos superan el total en " + FormatoMoneda(-falta);
                lblFaltaPagar.ForeColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                lblFaltaPagar.Text = "Pagos completos.";
                lblFaltaPagar.ForeColor = Color.FromArgb(16, 185, 129);
            }
        }

        // Agrega un pago con el método y el importe elegidos.
        // Si el importe queda vacío se agrega lo que falta pagar.
        private void AgregarPago()
        {
            if (carrito.Rows.Count == 0)
            {
                MessageBox.Show("Primero agregue productos al carrito.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedValue == null || cmbMetodoPago.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal falta = CalcularTotalNeto() - CalcularTotalPagado();

            if (falta <= 0)
            {
                MessageBox.Show("Los pagos ya cubren el total de la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal importe = falta;

            if (txtImportePago.Text.Trim().Length > 0)
            {
                if (!IntentarParsearDecimal(txtImportePago.Text, out importe) || importe <= 0)
                {
                    MessageBox.Show("Ingrese un importe mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtImportePago.Focus();
                    return;
                }

                importe = Math.Round(importe, 2, MidpointRounding.AwayFromZero);

                if (importe > falta)
                {
                    MessageBox.Show(
                        "El importe supera lo que falta pagar (" + FormatoMoneda(falta) + ").",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtImportePago.Focus();
                    return;
                }
            }

            int idMetodo = Convert.ToInt32(cmbMetodoPago.SelectedValue);

            // Si el método ya estaba en la lista se suma al pago existente.
            DataRow? existente = null;
            foreach (DataRow pago in pagos.Rows)
            {
                if (Convert.ToInt32(pago["Id_MetodoPago"]) == idMetodo)
                {
                    existente = pago;
                    break;
                }
            }

            if (existente == null)
            {
                pagos.Rows.Add(idMetodo, cmbMetodoPago.Text, importe);
            }
            else
            {
                existente["Importe"] = Convert.ToDecimal(existente["Importe"]) + importe;
            }

            txtImportePago.Clear();
            ActualizarPagos();
        }

        private void QuitarPago(int fila)
        {
            if (fila >= 0 && fila < pagos.Rows.Count)
            {
                pagos.Rows.RemoveAt(fila);
                ActualizarPagos();
            }
        }

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

        private void ConfirmarVenta()
        {
            if (carrito.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un producto al carrito.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cmbMetodoPago.SelectedValue == null || cmbMetodoPago.SelectedValue == DBNull.Value)
            {
                MessageBox.Show(
                    "Debe seleccionar un método de pago.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (usuarioLogueado == null)
            {
                MessageBox.Show(
                    "Debe iniciar sesión para registrar una venta.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            decimal totalNeto = CalcularTotalNeto();

            if (pagos.Rows.Count > 0 && CalcularTotalPagado() != totalNeto)
            {
                MessageBox.Show(
                    "La suma de los pagos (" + FormatoMoneda(CalcularTotalPagado()) + ") no coincide con el total de la venta (" + FormatoMoneda(totalNeto) + ").\n" +
                    "Agregue o quite pagos (doble clic en un pago para quitarlo).",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Venta venta = new Venta
            {
                Numero_Factura = null,
                Id_Usuario_Vendedor = usuarioLogueado.Id_Usuario,
                DescuentoPorcentaje = numDescuento.Value,
                Fecha_Venta = DateTime.Now
            };

            if (pagos.Rows.Count == 0)
            {
                // Un solo método: se cobra todo con el método elegido.
                venta.Pagos.Add(new PagoVenta
                {
                    Id_MetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue),
                    MetodoPago = cmbMetodoPago.Text,
                    Importe = totalNeto
                });
            }
            else
            {
                foreach (DataRow pago in pagos.Rows)
                {
                    venta.Pagos.Add(new PagoVenta
                    {
                        Id_MetodoPago = Convert.ToInt32(pago["Id_MetodoPago"]),
                        MetodoPago = Convert.ToString(pago["Metodo"]) ?? string.Empty,
                        Importe = Convert.ToDecimal(pago["Importe"])
                    });
                }
            }

            // La venta queda registrada con el método del pago más grande.
            PagoVenta principal = venta.Pagos[0];
            foreach (PagoVenta pago in venta.Pagos)
            {
                if (pago.Importe > principal.Importe)
                {
                    principal = pago;
                }
            }
            venta.Id_MetodoPago = principal.Id_MetodoPago;

            foreach (DataRow fila in carrito.Rows)
            {
                venta.Detalle.Add(new DetalleVenta
                {
                    Id_Producto = Convert.ToInt32(fila["Id_Producto"]),
                    Codigo = Convert.ToString(fila["Codigo"]) ?? string.Empty,
                    Producto = Convert.ToString(fila["Producto"]) ?? string.Empty,
                    Cantidad = Convert.ToInt32(fila["Cantidad"]),
                    Precio_Unitario = Convert.ToDecimal(fila["Precio_Unitario"])
                });
            }

            try
            {
                ResultadoOperacion resultado = gestorVentas.RegistrarVenta(venta);

                string detallePagos = string.Empty;
                foreach (PagoVenta pago in venta.Pagos)
                {
                    detallePagos += (detallePagos.Length == 0 ? "" : " + ") + pago.MetodoPago + " " + FormatoMoneda(pago.Importe);
                }

                LimpiarVenta();
                BuscarProductos();

                // El comprobante queda escrito en la pantalla (en lugar del ayuda).
                lblAyuda.Visible = false;
                Mensajes.Exito(lblResultado,
                    "Venta registrada con éxito.\n" +
                    "Comprobante: " + (resultado.Comprobante ?? string.Empty) + " - Total: " + FormatoMoneda(resultado.Total) + "\n" +
                    "Pagos: " + detallePagos);
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

        private void LimpiarVenta()
        {
            carrito.Rows.Clear();
            pagos.Rows.Clear();
            txtImportePago.Clear();
            numCantidad.Value = 1;
            numDescuento.Value = 0;
            txtBuscar.Clear();

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }

            if (cmbMetodoPago.Items.Count > 0)
            {
                cmbMetodoPago.SelectedIndex = 0;
            }

            ActualizarResumen();
            txtBuscar.Focus();
        }

        private static string FormatoMoneda(decimal valor)
        {
            return "$" + valor.ToString("0.##");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProductos();
                e.Handled = true;
            }
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            AgregarAlCarrito();
        }

        private void dgvResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AgregarAlCarrito();
            }
        }

        private void btnQuitarSeleccionado_Click(object sender, EventArgs e)
        {
            QuitarSeleccionado();
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            ConfirmarVenta();
        }

        private void btnCancelarOperacion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cancelar la operación y descartar los datos ingresados?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                LimpiarVenta();
                OcultarResultado();
            }
        }

        private void btnAgregarPago_Click(object? sender, EventArgs e)
        {
            AgregarPago();
        }

        private void txtImportePago_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarPago();
                e.SuppressKeyPress = true;
            }
        }

        // Doble clic en un pago para quitarlo.
        private void dgvPagos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            QuitarPago(e.RowIndex);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
