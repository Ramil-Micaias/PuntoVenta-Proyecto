using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormCompras : Form
    {
        private readonly GestorCompras gestorCompras = new GestorCompras();
        private readonly DataTable detalle = new DataTable();

        // Pagos de la compra (cuando se paga con más de un método).
        private readonly DataTable pagos = new DataTable();
        private Usuario? usuarioLogueado;
        private DataTable productos = new DataTable();

        // Proveedor de la compra: lo define el primer producto agregado (0 = todavía ninguno).
        private int idProveedorCompra = 0;

        public FormCompras()
        {
            InitializeComponent();

            this.btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            this.btnRegistrar.Click += btnRegistrar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnVolver.Click += btnVolver_Click;
            this.cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            this.txtCosto.KeyDown += txtImporte_KeyDown;
            this.txtCantidad.KeyDown += txtImporte_KeyDown;
            this.dgvDetalle.CellDoubleClick += dgvDetalle_CellDoubleClick;
            this.btnAgregarPago.Click += btnAgregarPago_Click;
            this.txtImportePago.KeyDown += txtImportePago_KeyDown;
            this.dgvPagos.CellDoubleClick += dgvPagos_CellDoubleClick;
        }

        public FormCompras(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CrearDetalle();
            CrearPagos();
            CargarProveedores();
            CargarMetodosPago();
            CargarProductos();
            ActualizarTotal();

            // El proveedor no se elige: sale del producto (el que tiene asignado en Productos).
            cmbProveedor.Enabled = false;
            MostrarProveedorDelProducto();
            grpProveedor.Focus();
        }

        private void ConfigurarGrid()
        {
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvDetalle.DefaultCellStyle.BackColor = Color.White;
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvDetalle.RowTemplate.Height = Grillas.AltoFila(dgvDetalle);
        }

        private void CrearDetalle()
        {
            detalle.Columns.Add("Id_Producto", typeof(int));
            detalle.Columns.Add("Codigo", typeof(string));
            detalle.Columns.Add("Producto", typeof(string));
            detalle.Columns.Add("Cantidad", typeof(int));
            detalle.Columns.Add("Precio_Costo_Unitario", typeof(decimal));
            detalle.Columns.Add("Subtotal", typeof(decimal));

            dgvDetalle.DataSource = detalle;

            OcultarColumna(dgvDetalle, "Id_Producto");
            OcultarColumna(dgvDetalle, "Codigo");
            EncabezadoColumna(dgvDetalle, "Producto", "Producto", 1);
            EncabezadoColumna(dgvDetalle, "Precio_Costo_Unitario", "Costo Unit.", 2, "0.##");
            EncabezadoColumna(dgvDetalle, "Cantidad", "Cant.", 3);
            EncabezadoColumna(dgvDetalle, "Subtotal", "Subtotal", 4, "0.##");
        }

        // Lista de pagos de la compra. Sin pagos agregados se paga todo con el método elegido.
        private void CrearPagos()
        {
            Grillas.Configurar(dgvPagos);

            pagos.Columns.Add("Id_MetodoPago", typeof(int));
            pagos.Columns.Add("Metodo", typeof(string));
            pagos.Columns.Add("Importe", typeof(decimal));

            dgvPagos.DataSource = pagos;

            OcultarColumna(dgvPagos, "Id_MetodoPago");
            EncabezadoColumna(dgvPagos, "Metodo", "Método", 0);
            EncabezadoColumna(dgvPagos, "Importe", "Importe", 1, "0.##");
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
                lblFaltaPagar.Text = "Sin pagos agregados se paga todo con el método elegido.";
                lblFaltaPagar.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            decimal falta = CalcularTotal() - CalcularTotalPagado();

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

        // Agrega un pago con el método y el importe elegidos. Si el importe queda vacío se agrega lo que falta pagar.
        private void AgregarPago()
        {
            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("Primero agregue productos al detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedValue == null || cmbMetodoPago.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal falta = CalcularTotal() - CalcularTotalPagado();

            if (falta <= 0)
            {
                MessageBox.Show("Los pagos ya cubren el total de la compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("El importe supera lo que falta pagar (" + FormatoMoneda(falta) + ").", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CargarProveedores()
        {
            try
            {
                cmbProveedor.DisplayMember = "Razon_Social";
                cmbProveedor.ValueMember = "Id_Proveedor";
                cmbProveedor.DataSource = gestorCompras.ObtenerProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar proveedores: " + ex.Message,
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
                cmbMetodoPago.DataSource = gestorCompras.ObtenerMetodosPago();

                // Arranca vacío: el método de pago se elige siempre (no queda Efectivo por defecto).
                cmbMetodoPago.SelectedIndex = -1;
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

        private void CargarProductos()
        {
            try
            {
                productos = gestorCompras.BuscarProductos();

                cmbProducto.DisplayMember = "Producto";
                cmbProducto.ValueMember = "Id_Producto";
                cmbProducto.DataSource = productos.DefaultView;
                FiltrarProductosPorProveedor();
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

        private void AgregarAlDetalle()
        {
            DataRowView? fila = cmbProducto.SelectedItem as DataRowView;
            if (fila == null || cmbProducto.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto del catálogo.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!IntentarParsearDecimal(txtCosto.Text, out decimal costo) || costo <= 0)
            {
                MessageBox.Show(
                    "El costo unitario debe ser un importe mayor a cero.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtCosto.Focus();
                return;
            }

            if (!IntentarParsearEntero(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad recibida debe ser un número mayor a cero.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtCantidad.Focus();
                return;
            }

            // Proveedor asignado al producto, un solo proveedor por compra y costo no mayor al precio de venta.
            string? error = GestorCompras.ValidarRenglon(fila.Row, costo, idProveedorCompra);
            if (error != null)
            {
                MessageBox.Show(error, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            if (idProveedorCompra == 0)
            {
                idProveedorCompra = Convert.ToInt32(fila["Id_Proveedor"]);
                FiltrarProductosPorProveedor();
            }

            int idProducto = Convert.ToInt32(fila["Id_Producto"]);
            DataRow? existente = null;

            foreach (DataRow item in detalle.Rows)
            {
                if (Convert.ToInt32(item["Id_Producto"]) == idProducto)
                {
                    existente = item;
                    break;
                }
            }

            if (existente == null)
            {
                DataRow nuevo = detalle.NewRow();
                nuevo["Id_Producto"] = idProducto;
                nuevo["Codigo"] = Convert.ToString(fila["Codigo"]) ?? string.Empty;
                nuevo["Producto"] = Convert.ToString(fila["Producto"]) ?? string.Empty;
                nuevo["Cantidad"] = cantidad;
                nuevo["Precio_Costo_Unitario"] = costo;
                nuevo["Subtotal"] = cantidad * costo;
                detalle.Rows.Add(nuevo);
            }
            else
            {
                int cantidadTotal = Convert.ToInt32(existente["Cantidad"]) + cantidad;
                existente["Cantidad"] = cantidadTotal;
                existente["Precio_Costo_Unitario"] = costo;
                existente["Subtotal"] = cantidadTotal * costo;
            }

            txtCantidad.Clear();
            lblMensaje.Text = string.Empty;
            ActualizarTotal();
            txtCantidad.Focus();
        }

        private void QuitarSeleccionado()
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto del detalle.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvDetalle.CurrentRow.DataBoundItem is DataRowView vista)
            {
                detalle.Rows.Remove(vista.Row);

                // Sin productos en el detalle, la compra vuelve a quedar sin proveedor.
                if (detalle.Rows.Count == 0)
                {
                    idProveedorCompra = 0;
                    FiltrarProductosPorProveedor();
                }

                ActualizarTotal();
            }
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (DataRow item in detalle.Rows)
            {
                total += Convert.ToDecimal(item["Subtotal"]);
            }

            return total;
        }

        private void ActualizarTotal()
        {
            lblTotalValor.Text = FormatoMoneda(CalcularTotal());
            btnRegistrar.Visible = detalle.Rows.Count > 0;
            ActualizarPagos();
        }

        private void RegistrarCompra()
        {
            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un producto al detalle de la compra.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (idProveedorCompra <= 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Sin pagos agregados hace falta el método para pagar todo con él.
            if (pagos.Rows.Count == 0 && (cmbMetodoPago.SelectedValue == null || cmbMetodoPago.SelectedValue == DBNull.Value))
            {
                MessageBox.Show(
                    "Debe seleccionar un método de pago.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (pagos.Rows.Count > 0 && CalcularTotalPagado() != CalcularTotal())
            {
                MessageBox.Show(
                    "La suma de los pagos (" + FormatoMoneda(CalcularTotalPagado()) + ") no coincide con el total de la compra (" + FormatoMoneda(CalcularTotal()) + ").\n" +
                    "Agregue o quite pagos (doble clic en un pago para quitarlo).",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (usuarioLogueado == null)
            {
                MessageBox.Show(
                    "Debe iniciar sesión para registrar una compra.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Compra compra = new Compra
            {
                Numero_Comprobante = null,
                Id_Proveedor = idProveedorCompra,
                Id_Usuario = usuarioLogueado.Id_Usuario,
                Total = CalcularTotal(),
                Fecha_Compra = DateTime.Now
            };

            foreach (DataRow fila in detalle.Rows)
            {
                compra.Detalles.Add(new DetalleCompra
                {
                    Id_Producto = Convert.ToInt32(fila["Id_Producto"]),
                    Codigo = Convert.ToString(fila["Codigo"]) ?? string.Empty,
                    Producto = Convert.ToString(fila["Producto"]) ?? string.Empty,
                    Cantidad = Convert.ToInt32(fila["Cantidad"]),
                    Precio_Costo_Unitario = Convert.ToDecimal(fila["Precio_Costo_Unitario"])
                });
            }

            if (pagos.Rows.Count == 0)
            {
                // Un solo método: se paga todo con el método elegido.
                compra.Pagos.Add(new PagoCompra
                {
                    Id_MetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue),
                    MetodoPago = cmbMetodoPago.Text,
                    Importe = compra.Total
                });
            }
            else
            {
                foreach (DataRow pago in pagos.Rows)
                {
                    compra.Pagos.Add(new PagoCompra
                    {
                        Id_MetodoPago = Convert.ToInt32(pago["Id_MetodoPago"]),
                        MetodoPago = Convert.ToString(pago["Metodo"]) ?? string.Empty,
                        Importe = Convert.ToDecimal(pago["Importe"])
                    });
                }
            }

            // La compra queda registrada con el método del pago más grande.
            PagoCompra principal = compra.Pagos[0];
            foreach (PagoCompra pago in compra.Pagos)
            {
                if (pago.Importe > principal.Importe)
                {
                    principal = pago;
                }
            }
            compra.Id_MetodoPago = principal.Id_MetodoPago;

            try
            {
                ResultadoOperacion resultado = gestorCompras.RegistrarCompra(compra);

                LimpiarCompra();
                CargarProductos();

                lblMensaje.Text =
                    "Compra registrada con éxito.\n" +
                    "Comprobante: " + (resultado.Comprobante ?? string.Empty) + "\n" +
                    "Total: " + FormatoMoneda(resultado.Total);
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

        private void LimpiarCompra()
        {
            detalle.Rows.Clear();
            pagos.Rows.Clear();
            txtCosto.Clear();
            txtCantidad.Clear();
            txtImportePago.Clear();
            lblMensaje.Text = string.Empty;

            idProveedorCompra = 0;
            FiltrarProductosPorProveedor();
            MostrarProveedorDelProducto();

            cmbMetodoPago.SelectedIndex = -1;

            ActualizarTotal();
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

        private static bool IntentarParsearEntero(string texto, out int valor)
        {
            valor = 0;
            texto = (texto ?? string.Empty).Trim();

            if (texto.Length == 0)
            {
                return false;
            }

            if (int.TryParse(texto, NumberStyles.Integer, CultureInfo.CurrentCulture, out valor))
            {
                return true;
            }

            return int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out valor);
        }

        private static string FormatoMoneda(decimal valor)
        {
            return "$" + valor.ToString("0.##");
        }

        // Con productos en el detalle solo se listan los del mismo proveedor (una compra es a un solo proveedor).
        private void FiltrarProductosPorProveedor()
        {
            productos.DefaultView.RowFilter = idProveedorCompra > 0 ? "Id_Proveedor = " + idProveedorCompra : string.Empty;
        }

        // Muestra (sin dejar cambiarlo) el proveedor asignado al producto elegido.
        private void MostrarProveedorDelProducto()
        {
            int idProveedor = idProveedorCompra;

            if (idProveedor == 0 && cmbProducto.SelectedItem is DataRowView fila && fila["Id_Proveedor"] != DBNull.Value)
                idProveedor = Convert.ToInt32(fila["Id_Proveedor"]);

            if (idProveedor > 0)
                cmbProveedor.SelectedValue = idProveedor;
            else
                cmbProveedor.SelectedIndex = -1;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProveedorDelProducto();

            if (cmbProducto.SelectedItem is DataRowView fila)
            {
                txtCosto.Text = fila["Precio_Costo"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToDecimal(fila["Precio_Costo"]).ToString("0.##", CultureInfo.CurrentCulture);
            }
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarAlDetalle();
                e.Handled = true;
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            AgregarAlDetalle();
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                QuitarSeleccionado();
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

        private void dgvPagos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            QuitarPago(e.RowIndex);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarCompra();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cancelar la operación y descartar los datos ingresados?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                LimpiarCompra();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}