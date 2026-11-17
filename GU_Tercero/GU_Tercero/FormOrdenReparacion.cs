using Datos.Entidades;
using Logica;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Vista
{
    // alta y seguimiento de una orden de reparacion
    public partial class FormOrdenReparacion : Form
    {
        public string MensajeResultado { get; private set; } = string.Empty;

        private readonly GestorTaller gestorTaller = new GestorTaller();
        // repuestos cargados en la orden
        private readonly DataTable repuestos = new DataTable();
        private Usuario usuarioLogueado;

        private int idOrden;

        private DataTable repuestosOriginales = new DataTable();

        private bool cargando = false;

        // idOrden 0 es una orden nueva, si no se abre la existente
        public FormOrdenReparacion(Usuario usuario, int idOrden)
        {
            InitializeComponent();

            usuarioLogueado = usuario;
            this.idOrden = idOrden;

            this.Load += FormOrdenReparacion_Load;
            this.cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            this.cmbRepuesto.SelectedIndexChanged += cmbRepuesto_SelectedIndexChanged;
            this.btnNuevoCliente.Click += btnNuevoCliente_Click;
            this.btnEditarCliente.Click += btnEditarCliente_Click;
            this.btnNuevoEquipo.Click += btnNuevoEquipo_Click;
            this.btnAgregarRepuesto.Click += btnAgregarRepuesto_Click;
            this.btnQuitarRepuesto.Click += btnQuitarRepuesto_Click;
            this.txtManoObra.TextChanged += txtManoObra_TextChanged;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnVolver.Click += btnVolver_Click;
        }

        // al abrir carga los combos y la orden
        private void FormOrdenReparacion_Load(object sender, EventArgs e)
        {
            Navegacion.AjustarAPantalla(this);
            Grillas.Configurar(dgvRepuestos);
            Grillas.Configurar(dgvHistorial);
            CrearTablaRepuestos();

            try
            {
                cargando = true;
                CargarClientes();
                CargarTecnicos();
                CargarEstados();
                CargarRepuestos();
                cargando = false;

                if (idOrden == 0)
                {
                    PrepararOrdenNueva();
                }
                else
                {
                    CargarOrden();
                }
            }
            catch (Exception ex)
            {
                cargando = false;
                MessageBox.Show(
                    "Error al cargar los datos de la orden: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            ActualizarTotales();
        }

        // combo de clientes
        private void CargarClientes()
        {
            cmbCliente.DisplayMember = "Cliente";
            cmbCliente.ValueMember = "Id_Cliente";
            cmbCliente.DataSource = gestorTaller.ObtenerClientes();
            cmbCliente.SelectedIndex = -1;
        }

        // combo de equipos del cliente elegido
        private void CargarEquipos()
        {
            cmbEquipo.DataSource = null;

            if (cmbCliente.SelectedValue == null || cmbCliente.SelectedIndex < 0)
            {
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);

            cmbEquipo.DisplayMember = "Equipo";
            cmbEquipo.ValueMember = "Id_Equipo";
            cmbEquipo.DataSource = gestorTaller.ObtenerEquipos(idCliente);
        }

        // combo de tecnicos
        private void CargarTecnicos()
        {
            DataTable tecnicos = gestorTaller.ObtenerTecnicos();

            DataRow sinAsignar = tecnicos.NewRow();
            sinAsignar["Id_Usuario"] = DBNull.Value;
            sinAsignar["Tecnico"] = "Sin asignar";
            tecnicos.Rows.InsertAt(sinAsignar, 0);

            cmbTecnico.DisplayMember = "Tecnico";
            cmbTecnico.ValueMember = "Id_Usuario";
            cmbTecnico.DataSource = tecnicos;
        }

        // combo de estados
        private void CargarEstados()
        {
            cmbEstado.DisplayMember = "Nombre_Estado";
            cmbEstado.ValueMember = "Id_Estado";
            cmbEstado.DataSource = gestorTaller.ObtenerEstados();
        }

        // combo de repuestos con su stock
        private void CargarRepuestos()
        {
            cmbRepuesto.DisplayMember = "Producto";
            cmbRepuesto.ValueMember = "Id_Producto";
            cmbRepuesto.DataSource = gestorTaller.ObtenerRepuestos();
            cmbRepuesto.SelectedIndex = -1;
            txtPrecio.Clear();
        }

        // columnas de la tabla de repuestos
        private void CrearTablaRepuestos()
        {
            repuestos.Columns.Add("Id_Producto", typeof(int));
            repuestos.Columns.Add("Repuesto", typeof(string));
            repuestos.Columns.Add("Cantidad", typeof(int));
            repuestos.Columns.Add("Precio_Unitario", typeof(decimal));
            repuestos.Columns.Add("Subtotal", typeof(decimal));

            dgvRepuestos.DataSource = repuestos;

            if (dgvRepuestos.Columns.Contains("Precio_Unitario"))
            {
                dgvRepuestos.Columns["Precio_Unitario"].HeaderText = "Precio Unit.";
                dgvRepuestos.Columns["Precio_Unitario"].DefaultCellStyle.Format = "0.##";
            }

            if (dgvRepuestos.Columns.Contains("Subtotal"))
            {
                dgvRepuestos.Columns["Subtotal"].DefaultCellStyle.Format = "0.##";
            }
        }

        // valores por defecto de una orden nueva
        private void PrepararOrdenNueva()
        {
            lblTitulo.Text = "NUEVA ORDEN DE REPARACIÓN";
            lblRecepcion.Text = "Recibe: " + usuarioLogueado.Nombre_Usuario + "   |   Ingreso: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            SeleccionarEstado("Ingresado");

            if (usuarioLogueado.Nombre_Rol == "Tecnico")
            {
                cmbTecnico.SelectedValue = usuarioLogueado.Id_Usuario;
            }

            dtpPrometida.MinDate = DateTime.Today;
            dtpPrometida.Value = DateTime.Today.AddDays(3);
            dtpPrometida.Checked = false;

            tabDetalle.TabPages.Remove(tabHistorial);
            lblObservacion.Visible = false;
            txtObservacion.Visible = false;
        }

        // elige un estado del combo por su nombre
        private void SeleccionarEstado(string nombreEstado)
        {
            for (int i = 0; i < cmbEstado.Items.Count; i++)
            {
                DataRowView fila = (DataRowView)cmbEstado.Items[i];

                if (Convert.ToString(fila["Nombre_Estado"]) == nombreEstado)
                {
                    cmbEstado.SelectedIndex = i;
                    return;
                }
            }
        }

        // carga los datos de una orden existente con sus repuestos e historial
        private void CargarOrden()
        {
            DataTable datos = gestorTaller.ObtenerOrden(idOrden);

            if (datos.Rows.Count == 0)
            {
                MessageBox.Show(
                    "La orden no existe.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            DataRow orden = datos.Rows[0];

            lblTitulo.Text = "ORDEN OR-" + idOrden.ToString("00000000");
            lblRecepcion.Text = "Recibió: " + Convert.ToString(orden["Recepcion"])
                + "   |   Ingreso: " + Convert.ToDateTime(orden["Fecha_Ingreso"]).ToString("dd/MM/yyyy HH:mm");

            cargando = true;
            cmbCliente.SelectedValue = Convert.ToInt32(orden["Id_Cliente"]);
            cargando = false;
            CargarEquipos();
            cmbEquipo.SelectedValue = Convert.ToInt32(orden["Id_Equipo"]);

            if (orden["Id_Tecnico"] != DBNull.Value)
            {
                int idTecnico = Convert.ToInt32(orden["Id_Tecnico"]);
                cmbTecnico.SelectedValue = idTecnico;

                if (cmbTecnico.SelectedIndex < 0)
                {
                    DataTable tecnicos = (DataTable)cmbTecnico.DataSource;
                    DataRow asignado = tecnicos.NewRow();
                    asignado["Id_Usuario"] = idTecnico;
                    asignado["Tecnico"] = Convert.ToString(orden["Tecnico"]);
                    tecnicos.Rows.Add(asignado);
                    cmbTecnico.SelectedValue = idTecnico;
                }
            }
            else
            {
                cmbTecnico.SelectedIndex = 0;
            }

            cmbEstado.SelectedValue = Convert.ToInt32(orden["Id_Estado"]);

            DateTime ingreso = Convert.ToDateTime(orden["Fecha_Ingreso"]).Date;
            dtpPrometida.MinDate = ingreso;

            if (orden["Fecha_Prometida"] != DBNull.Value)
            {
                DateTime prometida = Convert.ToDateTime(orden["Fecha_Prometida"]).Date;
                if (prometida < ingreso)
                    dtpPrometida.MinDate = prometida;

                dtpPrometida.Value = prometida;
                dtpPrometida.Checked = true;
            }
            else
            {
                dtpPrometida.Checked = false;
            }

            txtFalla.Text = Convert.ToString(orden["Falla_Declarada"]);
            txtPatron.Text = Convert.ToString(orden["Patron_Clave_Desbloqueo"]);
            txtDiagnostico.Text = Convert.ToString(orden["Diagnostico_Tecnico"]);
            txtManoObra.Text = Convert.ToDecimal(orden["Costo_Mano_Obra"]).ToString("0.##", CultureInfo.CurrentCulture);

            cmbCliente.Enabled = false;
            cmbEquipo.Enabled = false;
            btnNuevoCliente.Visible = false;
            btnEditarCliente.Left = btnNuevoCliente.Left;
            btnNuevoEquipo.Visible = false;

            repuestosOriginales = gestorTaller.ObtenerRepuestosOrden(idOrden);

            foreach (DataRow item in repuestosOriginales.Rows)
            {
                DataRow nuevo = repuestos.NewRow();
                nuevo["Id_Producto"] = item["Id_Producto"];
                nuevo["Repuesto"] = item["Repuesto"];
                nuevo["Cantidad"] = item["Cantidad"];
                nuevo["Precio_Unitario"] = item["Precio_Unitario"];
                nuevo["Subtotal"] = item["Subtotal"];
                repuestos.Rows.Add(nuevo);
            }

            dgvHistorial.DataSource = gestorTaller.ObtenerHistorialOrden(idOrden);

            string estado = Convert.ToString(orden["Nombre_Estado"]) ?? string.Empty;

            if (estado == "Entregado" || estado == "Cancelado")
            {
                BloquearOrden();
            }
        }

        // si la orden esta entregada o cancelada ya no se puede modificar
        private void BloquearOrden()
        {
            grpEquipo.Enabled = false;
            grpDiagnostico.Enabled = false;
            txtManoObra.ReadOnly = true;
            lblRepuesto.Visible = false;
            cmbRepuesto.Visible = false;
            lblCantidad.Visible = false;
            numCantidad.Visible = false;
            lblPrecio.Visible = false;
            txtPrecio.Visible = false;
            btnAgregarRepuesto.Visible = false;
            btnQuitarRepuesto.Visible = false;
            btnGuardar.Visible = false;
            lblAviso.Visible = true;
        }

        // cuantos de ese repuesto tenia la orden guardada (para controlar el stock)
        private int CantidadOriginal(int idProducto)
        {
            int cantidad = 0;

            foreach (DataRow item in repuestosOriginales.Rows)
            {
                if (Convert.ToInt32(item["Id_Producto"]) == idProducto)
                {
                    cantidad += Convert.ToInt32(item["Cantidad"]);
                }
            }

            return cantidad;
        }

        // agrega un repuesto controlando el stock
        private void AgregarRepuesto()
        {
            DataRowView? fila = cmbRepuesto.SelectedItem as DataRowView;

            if (fila == null || cmbRepuesto.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un repuesto.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!IntentarParsearDecimal(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show(
                    "El precio del repuesto debe ser un importe válido.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPrecio.Focus();
                return;
            }

            int idProducto = Convert.ToInt32(fila["Id_Producto"]);
            int cantidad = (int)numCantidad.Value;

            DataRow? existente = null;

            foreach (DataRow item in repuestos.Rows)
            {
                if (Convert.ToInt32(item["Id_Producto"]) == idProducto)
                {
                    existente = item;
                    break;
                }
            }

            int cantidadTotal = cantidad;
            if (existente != null)
            {
                cantidadTotal += Convert.ToInt32(existente["Cantidad"]);
            }

            int disponible = Convert.ToInt32(fila["Stock_Actual"]) + CantidadOriginal(idProducto);

            if (cantidadTotal > disponible)
            {
                MessageBox.Show(
                    "No hay stock suficiente de ese repuesto.\n" +
                    "Disponible: " + disponible + " unidades. Cantidad pedida: " + cantidadTotal + ".",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (existente == null)
            {
                DataRow nuevo = repuestos.NewRow();
                nuevo["Id_Producto"] = idProducto;
                nuevo["Repuesto"] = QuitarStockDelNombre(Convert.ToString(fila["Producto"]) ?? string.Empty);
                nuevo["Cantidad"] = cantidad;
                nuevo["Precio_Unitario"] = precio;
                nuevo["Subtotal"] = cantidad * precio;
                repuestos.Rows.Add(nuevo);
            }
            else
            {
                existente["Cantidad"] = cantidadTotal;
                existente["Precio_Unitario"] = precio;
                existente["Subtotal"] = cantidadTotal * precio;
            }

            numCantidad.Value = 1;
            ActualizarTotales();
        }

        // saca el "(stock N)" del nombre que se muestra en el combo
        private static string QuitarStockDelNombre(string texto)
        {
            int posicion = texto.LastIndexOf(" (stock ");

            if (posicion > 0)
            {
                return texto.Substring(0, posicion);
            }

            return texto;
        }

        // saca el repuesto elegido
        private void QuitarRepuesto()
        {
            if (dgvRepuestos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un repuesto de la lista.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvRepuestos.CurrentRow.DataBoundItem is DataRowView vista)
            {
                repuestos.Rows.Remove(vista.Row);
                ActualizarTotales();
            }
        }

        // lee el costo de mano de obra
        private decimal ManoDeObra()
        {
            if (IntentarParsearDecimal(txtManoObra.Text, out decimal valor) && valor >= 0)
            {
                return valor;
            }

            return 0;
        }

        // total = repuestos + mano de obra
        private void ActualizarTotales()
        {
            decimal totalRepuestos = 0;

            foreach (DataRow item in repuestos.Rows)
            {
                totalRepuestos += Convert.ToDecimal(item["Subtotal"]);
            }

            lblRepuestosValor.Text = FormatoMoneda(totalRepuestos);
            lblTotalValor.Text = FormatoMoneda(totalRepuestos + ManoDeObra());
        }

        // arma la orden con los datos de la pantalla y la guarda
        private void GuardarOrden()
        {
            if (txtManoObra.Text.Trim() != "" && (!IntentarParsearDecimal(txtManoObra.Text, out decimal mano) || mano < 0))
            {
                MessageBox.Show(
                    "La mano de obra debe ser un importe válido.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtManoObra.Focus();
                return;
            }

            if (cmbEquipo.SelectedValue == null || cmbEquipo.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe seleccionar el cliente y el equipo. Si son nuevos, cárguelos con \"+ Nuevo\".",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cmbEstado.Text == "Cancelado" && repuestos.Rows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Al cancelar la orden, los repuestos cargados vuelven al stock. ¿Desea continuar?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }
            }

            OrdenReparacion orden = new OrdenReparacion();
            orden.Id_Orden = idOrden;
            orden.Id_Equipo = Convert.ToInt32(cmbEquipo.SelectedValue);
            orden.Id_Usuario = usuarioLogueado.Id_Usuario;
            orden.Id_Estado = Convert.ToInt32(cmbEstado.SelectedValue);
            orden.Falla_Declarada = txtFalla.Text;
            orden.Patron_Clave = txtPatron.Text.Trim();
            orden.Diagnostico = txtDiagnostico.Text.Trim();
            orden.Costo_Mano_Obra = ManoDeObra();
            orden.Observacion = txtObservacion.Text.Trim();

            if (cmbTecnico.SelectedValue != null && cmbTecnico.SelectedValue != DBNull.Value)
            {
                orden.Id_Tecnico = Convert.ToInt32(cmbTecnico.SelectedValue);
            }

            if (dtpPrometida.Checked)
            {
                orden.Fecha_Prometida = dtpPrometida.Value.Date;
            }

            foreach (DataRow item in repuestos.Rows)
            {
                DetalleOrdenRepuesto detalle = new DetalleOrdenRepuesto();
                detalle.Id_Producto = Convert.ToInt32(item["Id_Producto"]);
                detalle.Repuesto = Convert.ToString(item["Repuesto"]) ?? string.Empty;
                detalle.Cantidad = Convert.ToInt32(item["Cantidad"]);
                detalle.Precio_Unitario = Convert.ToDecimal(item["Precio_Unitario"]);
                orden.Repuestos.Add(detalle);
            }

            try
            {
                ResultadoOperacion resultado = gestorTaller.GuardarOrden(orden);

                MensajeResultado = cmbEstado.Text == "Cancelado"
                    ? "Orden " + resultado.Comprobante + " cancelada correctamente."
                    : "Orden " + resultado.Comprobante + " guardada correctamente. Total del presupuesto: " +
                      FormatoMoneda(resultado.Total);

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        // formato de pesos
        private static string FormatoMoneda(decimal valor)
        {
            return "$" + valor.ToString("0.##");
        }

        // convierte texto a decimal
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

        // al cambiar el cliente carga sus equipos
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                CargarEquipos();
            }
        }

        // al elegir un repuesto pone su precio
        private void cmbRepuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRepuesto.SelectedItem is DataRowView fila)
            {
                txtPrecio.Text = Convert.ToDecimal(fila["Precio_Venta"]).ToString("0.##", CultureInfo.CurrentCulture);
            }
        }

        // abre la ventana de cliente nuevo y lo deja elegido
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FormNuevoCliente formCliente = new FormNuevoCliente())
            {
                if (formCliente.ShowDialog() == DialogResult.OK)
                {
                    cargando = true;
                    CargarClientes();
                    cargando = false;
                    cmbCliente.SelectedValue = formCliente.IdClienteNuevo;
                    CargarEquipos();
                }
            }
        }

        // abre el cliente elegido para corregir sus datos
        private void btnEditarCliente_Click(object? sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbCliente.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Primero seleccione el cliente a modificar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);

            using (FormNuevoCliente formCliente = new FormNuevoCliente(idCliente))
            {
                if (formCliente.ShowDialog() == DialogResult.OK)
                {
                    object? equipo = cmbEquipo.SelectedValue;
                    cargando = true;
                    CargarClientes();
                    cmbCliente.SelectedValue = idCliente;
                    cargando = false;

                    if (cmbEquipo.Items.Count == 0)
                        CargarEquipos();
                    if (equipo != null)
                        cmbEquipo.SelectedValue = equipo;
                }
            }
        }

        // abre la ventana de equipo nuevo
        private void btnNuevoEquipo_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbCliente.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Primero seleccione el cliente dueño del equipo.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);

            using (FormNuevoEquipo formEquipo = new FormNuevoEquipo(idCliente, cmbCliente.Text))
            {
                if (formEquipo.ShowDialog() == DialogResult.OK)
                {
                    CargarEquipos();
                    cmbEquipo.SelectedValue = formEquipo.IdEquipoNuevo;
                }
            }
        }

        // boton Agregar repuesto
        private void btnAgregarRepuesto_Click(object sender, EventArgs e)
        {
            AgregarRepuesto();
        }

        // boton Quitar repuesto
        private void btnQuitarRepuesto_Click(object sender, EventArgs e)
        {
            QuitarRepuesto();
        }

        // al cambiar la mano de obra recalcula el total
        private void txtManoObra_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        // boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarOrden();
        }

        // cierra la orden
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
