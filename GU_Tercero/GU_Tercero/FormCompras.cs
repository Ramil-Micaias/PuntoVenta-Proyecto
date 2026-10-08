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
        private Usuario? usuarioLogueado;

        public FormCompras()
        {
            InitializeComponent();

            this.btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            this.btnRegistrar.Click += btnRegistrar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            this.txtCosto.KeyDown += txtImporte_KeyDown;
            this.txtCantidad.KeyDown += txtImporte_KeyDown;
            this.txtPrecioVenta.KeyDown += txtImporte_KeyDown;
            this.dgvDetalle.CellDoubleClick += dgvDetalle_CellDoubleClick;
        }

        public FormCompras(Usuario? usuario) : this()
        {
            usuarioLogueado = usuario;
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CrearDetalle();
            CargarProveedores();
            CargarMetodosPago();
            CargarProductos();
            ActualizarTotal();
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
            dgvDetalle.RowTemplate.Height = 26;
        }

        private void CrearDetalle()
        {
            detalle.Columns.Add("Id_Producto", typeof(int));
            detalle.Columns.Add("Codigo", typeof(string));
            detalle.Columns.Add("Producto", typeof(string));
            detalle.Columns.Add("Cantidad", typeof(int));
            detalle.Columns.Add("Precio_Costo_Unitario", typeof(decimal));
            detalle.Columns.Add("Precio_Venta_Sugerido", typeof(decimal));
            detalle.Columns.Add("Subtotal", typeof(decimal));

            dgvDetalle.DataSource = detalle;

            OcultarColumna(dgvDetalle, "Id_Producto");
            EncabezadoColumna(dgvDetalle, "Codigo", "Código", 0);
            EncabezadoColumna(dgvDetalle, "Producto", "Producto", 1);
            EncabezadoColumna(dgvDetalle, "Precio_Costo_Unitario", "Costo Unit.", 2, "0.##");
            EncabezadoColumna(dgvDetalle, "Cantidad", "Cant.", 3);
            EncabezadoColumna(dgvDetalle, "Precio_Venta_Sugerido", "P. Venta Sug.", 4, "0.##");
            EncabezadoColumna(dgvDetalle, "Subtotal", "Subtotal", 5, "0.##");
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
                DataTable productos = gestorCompras.BuscarProductos(string.Empty, null);

                cmbProducto.DisplayMember = "Producto";
                cmbProducto.ValueMember = "Id_Producto";
                cmbProducto.DataSource = productos;
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

            decimal? precioVenta = null;

            if (!string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                if (!IntentarParsearDecimal(txtPrecioVenta.Text, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show(
                        "El precio de venta sugerido debe ser un importe mayor a cero.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtPrecioVenta.Focus();
                    return;
                }

                precioVenta = precio;
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
                nuevo["Precio_Venta_Sugerido"] = precioVenta.HasValue ? precioVenta.Value : DBNull.Value;
                nuevo["Subtotal"] = cantidad * costo;
                detalle.Rows.Add(nuevo);
            }
            else
            {
                int cantidadTotal = Convert.ToInt32(existente["Cantidad"]) + cantidad;
                existente["Cantidad"] = cantidadTotal;
                existente["Precio_Costo_Unitario"] = costo;
                existente["Precio_Venta_Sugerido"] = precioVenta.HasValue ? precioVenta.Value : DBNull.Value;
                existente["Subtotal"] = cantidadTotal * costo;
            }

            txtCantidad.Clear();
            txtPrecioVenta.Clear();
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

            if (cmbProveedor.SelectedValue == null || cmbProveedor.SelectedValue == DBNull.Value)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor.",
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
                Id_Proveedor = Convert.ToInt32(cmbProveedor.SelectedValue),
                Id_Usuario = usuarioLogueado.Id_Usuario,
                Id_MetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue),
                Total = CalcularTotal(),
                Fecha_Compra = DateTime.Now
            };

            foreach (DataRow fila in detalle.Rows)
            {
                decimal? precioVenta = fila["Precio_Venta_Sugerido"] == DBNull.Value
                    ? (decimal?)null
                    : Convert.ToDecimal(fila["Precio_Venta_Sugerido"]);

                compra.Detalles.Add(new DetalleCompra
                {
                    Id_Producto = Convert.ToInt32(fila["Id_Producto"]),
                    Codigo = Convert.ToString(fila["Codigo"]) ?? string.Empty,
                    Producto = Convert.ToString(fila["Producto"]) ?? string.Empty,
                    Cantidad = Convert.ToInt32(fila["Cantidad"]),
                    Precio_Costo_Unitario = Convert.ToDecimal(fila["Precio_Costo_Unitario"]),
                    Precio_Venta_Sugerido = precioVenta
                });
            }

            try
            {
                ResultadoOperacion resultado = gestorCompras.RegistrarCompra(compra);

                MessageBox.Show(
                    "Compra registrada con éxito.\n" +
                    "Comprobante: " + (resultado.Comprobante ?? string.Empty) + "\n" +
                    "Total: " + FormatoMoneda(resultado.Total),
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCompra();
                CargarProductos();
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
            txtCosto.Clear();
            txtCantidad.Clear();
            txtPrecioVenta.Clear();

            if (cmbProveedor.Items.Count > 0)
            {
                cmbProveedor.SelectedIndex = 0;
            }

            if (cmbMetodoPago.Items.Count > 0)
            {
                cmbMetodoPago.SelectedIndex = 0;
            }

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

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is DataRowView fila)
            {
                txtCosto.Text = fila["Precio_Costo"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToDecimal(fila["Precio_Costo"]).ToString("0.##", CultureInfo.CurrentCulture);

                txtPrecioVenta.Text = fila["Precio_Venta"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToDecimal(fila["Precio_Venta"]).ToString("0.##", CultureInfo.CurrentCulture);
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

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}