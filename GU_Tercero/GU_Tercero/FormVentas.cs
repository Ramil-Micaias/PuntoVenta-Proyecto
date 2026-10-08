using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormVentas : Form
    {
        private readonly GestorVentas gestorVentas = new GestorVentas();
        private readonly DataTable carrito = new DataTable();
        private Usuario? usuarioLogueado;

        public FormVentas()
        {
            InitializeComponent();

            this.btnBuscar.Click += btnBuscar_Click;
            this.btnAgregarCarrito.Click += btnAgregarCarrito_Click;
            this.btnQuitarSeleccionado.Click += btnQuitarSeleccionado_Click;
            this.btnConfirmarVenta.Click += btnConfirmarVenta_Click;
            this.btnCancelarOperacion.Click += btnCancelarOperacion_Click;
            this.numDescuento.ValueChanged += numDescuento_ValueChanged;
            this.txtBuscar.KeyDown += txtBuscar_KeyDown;
            this.dgvResultados.CellDoubleClick += dgvResultados_CellDoubleClick;
        }

        public FormVentas(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrids();
            CrearCarrito();
            CargarCategorias();
            CargarMetodosPago();
            CargarClientes();
            BuscarProductos();
            ActualizarResumen();
            txtBuscar.Focus();
        }

        private void ConfigurarGrids()
        {
            foreach (DataGridView grid in new DataGridView[] { dgvResultados, dgvCarrito })
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
                grid.RowTemplate.Height = 26;
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
            EncabezadoColumna(dgvCarrito, "Codigo", "Código", 0);
            EncabezadoColumna(dgvCarrito, "Producto", "Producto", 1);
            EncabezadoColumna(dgvCarrito, "Cantidad", "Cantidad", 2);
            EncabezadoColumna(dgvCarrito, "Precio_Unitario", "Precio Unit.", 3, "0.##");
            EncabezadoColumna(dgvCarrito, "Subtotal", "Subtotal", 4, "0.##");
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

        private void CargarClientes()
        {
            try
            {
                DataTable clientes = gestorVentas.BuscarClientes(string.Empty);

                DataRow consumidor = clientes.NewRow();
                consumidor["Id_Cliente"] = DBNull.Value;
                consumidor["NombreCompleto"] = "Consumidor Final";
                clientes.Rows.InsertAt(consumidor, 0);

                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "Id_Cliente";
                cmbCliente.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar clientes: " + ex.Message,
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

            EncabezadoColumna(dgvResultados, "Codigo", "Código", 0);
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

            decimal descuento = Math.Round(subtotal * numDescuento.Value / 100, 2);

            lblSubtotalValor.Text = FormatoMoneda(subtotal);
            lblTotalNeto.Text = FormatoMoneda(subtotal - descuento);
            lblResumenCarrito.Text = "Artículos: " + unidades + "   Subtotal: " + FormatoMoneda(subtotal);
        }

        private int? ObtenerIdCliente()
        {
            object? valor = cmbCliente.SelectedValue;

            if (valor == null || valor == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(valor);
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

            Venta venta = new Venta
            {
                Numero_Factura = null,
                Id_Cliente = ObtenerIdCliente(),
                Id_Usuario_Vendedor = usuarioLogueado.Id_Usuario,
                Id_MetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue),
                DescuentoPorcentaje = numDescuento.Value,
                Fecha_Venta = DateTime.Now
            };

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

                MessageBox.Show(
                    "Venta registrada con éxito.\n" +
                    "Comprobante: " + (resultado.Comprobante ?? string.Empty) + "\n" +
                    "Subtotal: " + FormatoMoneda(resultado.Subtotal) + "\n" +
                    "Descuento: " + FormatoMoneda(resultado.Descuento) + "\n" +
                    "Total: " + FormatoMoneda(resultado.Total),
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarVenta();
                BuscarProductos();
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
            numCantidad.Value = 1;
            numDescuento.Value = 0;
            txtBuscar.Clear();

            if (cmbCliente.Items.Count > 0)
            {
                cmbCliente.SelectedIndex = 0;
            }

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
            }
        }
    }
}
