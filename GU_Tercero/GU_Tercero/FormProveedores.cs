using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;

namespace Vista
{
    public partial class FormProveedores : Form
    {
        // Consulta: los campos están bloqueados. Agregando o Modificando: se habilitan
        // y se termina con Confirmar (graba) o Cancelar (descarta).
        private enum Modo { Consulta, Agregando, Modificando }

        private static readonly Color ROJO = Color.FromArgb(239, 68, 68);
        private static readonly Color VERDE = Color.FromArgb(16, 185, 129);
        private static readonly Color GRIS = Color.FromArgb(148, 163, 184);

        private Modo modo = Modo.Consulta;
        private int idProveedorSeleccionado = 0;
        private bool activoSeleccionado = true;
        private readonly GestorProveedores gestorProveedores = new GestorProveedores();

        public FormProveedores()
        {
            InitializeComponent();

            this.Load += FormProveedores_Load;
            this.dgvProveedores.CellClick += dgvProveedores_CellClick;
            this.dgvProveedores.DataBindingComplete += dgvProveedores_DataBindingComplete;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnModificar.Click += btnModificar_Click;
            this.btnEliminar.Click += btnEliminar_Click;
            this.btnNuevo.Click += btnNuevo_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            Grillas.Configurar(dgvProveedores);
            CargarProveedores();
            LimpiarControles();
            AplicarModo(Modo.Consulta);
        }

        // Bloquea o habilita los campos y muestra solo los botones que sirven en cada momento.
        // Al tocar Agregar desaparece Modificar y al tocar Modificar desaparece Agregar.
        private void AplicarModo(Modo nuevoModo)
        {
            modo = nuevoModo;
            bool editando = modo != Modo.Consulta;
            bool haySeleccion = idProveedorSeleccionado != 0;

            txtRazonSocial.ReadOnly = !editando;
            txtCUIT.ReadOnly = !editando;
            txtTelefono.ReadOnly = !editando;
            txtEmail.ReadOnly = !editando;
            txtDireccion.ReadOnly = !editando;

            // Mientras se edita no se puede elegir otro proveedor ni buscar: la grilla sigue habilitada
            // para poder desplazarla, pero los clics se ignoran en dgvProveedores_CellClick.
            txtBuscar.Enabled = !editando;

            btnNuevo.Visible = modo != Modo.Modificando;
            btnModificar.Visible = modo == Modo.Modificando || (modo == Modo.Consulta && haySeleccion);
            btnGuardar.Visible = editando;
            btnCancelar.Visible = editando;
            btnEliminar.Visible = modo == Modo.Consulta && haySeleccion;

            // Inactivar (rojo) si el proveedor está activo; Activar (verde) si está dado de baja.
            btnEliminar.Text = activoSeleccionado ? "Inactivar" : "Activar";
            btnEliminar.BackColor = activoSeleccionado ? ROJO : VERDE;

            if (modo == Modo.Agregando)
            {
                grpDetalleProveedores.Text = "Nuevo Proveedor";
                txtRazonSocial.Focus();
            }
            else if (modo == Modo.Modificando)
            {
                grpDetalleProveedores.Text = "Modificando Proveedor";
                txtRazonSocial.Focus();
            }
            else
            {
                grpDetalleProveedores.Text = "Detalle del Proveedor";
            }
        }

        // Se muestran todos, también los inactivos (en gris), para poder volver a activarlos.
        private void CargarProveedores()
        {
            try
            {
                DataTable proveedores = gestorProveedores.ObtenerTodosProveedores();
                string filtro = txtBuscar.Text.Trim().Replace("'", "''");

                if (!string.IsNullOrEmpty(filtro))
                {
                    proveedores.DefaultView.RowFilter =
                        "Razon_Social LIKE '%" + filtro + "%' OR CUIT LIKE '%" + filtro + "%' OR Email LIKE '%" + filtro + "%'";
                }

                dgvProveedores.DataSource = proveedores.DefaultView;
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

        private void dgvProveedores_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvProveedores.Columns.Contains("Razon_Social"))
                dgvProveedores.Columns["Razon_Social"].HeaderText = "Razón Social";

            if (dgvProveedores.Columns.Contains("Telefono"))
                dgvProveedores.Columns["Telefono"].HeaderText = "Teléfono";

            if (dgvProveedores.Columns.Contains("Direccion"))
                dgvProveedores.Columns["Direccion"].HeaderText = "Dirección";

            if (dgvProveedores.Columns.Contains("Fecha_Alta"))
            {
                dgvProveedores.Columns["Fecha_Alta"].HeaderText = "Fecha de alta";
                dgvProveedores.Columns["Fecha_Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (!dgvProveedores.Columns.Contains("Activo"))
                return;

            foreach (DataGridViewRow fila in dgvProveedores.Rows)
            {
                bool activo = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);

                if (!activo)
                    fila.DefaultCellStyle.ForeColor = GRIS;
            }
        }

        private void LimpiarControles()
        {
            idProveedorSeleccionado = 0;
            activoSeleccionado = true;

            txtRazonSocial.Clear();
            txtCUIT.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            dgvProveedores.ClearSelection();
        }

        private Proveedor LeerProveedor()
        {
            return new Proveedor()
            {
                Id_Proveedor = idProveedorSeleccionado,
                Razon_Social = txtRazonSocial.Text.Trim(),
                CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? null : txtCUIT.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                // Al modificar se mantiene el estado que tenía (un inactivo sigue inactivo).
                Activo = modo == Modo.Agregando || activoSeleccionado
            };
        }

        // Confirmar: graba el alta o la modificación según lo que se esté haciendo.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            try
            {
                string mensaje;

                if (modo == Modo.Agregando)
                {
                    bool reactivado = gestorProveedores.RegistrarProveedor(LeerProveedor());

                    mensaje = reactivado
                        ? "El proveedor estaba dado de baja: se reactivó con los datos ingresados (conserva su historial)."
                        : "Proveedor registrado con éxito.";
                }
                else if (modo == Modo.Modificando)
                {
                    gestorProveedores.ModificarProveedor(LeerProveedor());
                    mensaje = "Proveedor modificado correctamente.";
                }
                else
                {
                    return;
                }

                CargarProveedores();
                LimpiarControles();
                AplicarModo(Modo.Consulta);
                Mensajes.Exito(lblResultado, mensaje);
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

        // Modificar solo habilita los campos; los cambios se graban con Confirmar.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor de la lista para modificar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            AplicarModo(Modo.Modificando);
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);
            LimpiarControles();
            AplicarModo(Modo.Consulta);
        }

        // Inactivar (baja lógica) o Activar, según el estado del proveedor elegido.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor de la lista.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                string mensaje;

                if (activoSeleccionado)
                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Está seguro de que desea inactivar este proveedor?",
                        "Confirmar Inactivación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado != DialogResult.Yes)
                        return;

                    gestorProveedores.InactivarProveedor(idProveedorSeleccionado);
                    mensaje = "Proveedor inactivado con éxito.";
                }
                else
                {
                    gestorProveedores.ActivarProveedor(idProveedorSeleccionado);
                    mensaje = "Proveedor activado con éxito.";
                }

                CargarProveedores();
                LimpiarControles();
                AplicarModo(Modo.Consulta);
                Mensajes.Exito(lblResultado, mensaje);
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

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modo != Modo.Consulta)
            {
                return;
            }

            Mensajes.Limpiar(lblResultado);

            DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

            if (fila.Cells["Id_Proveedor"].Value != null && fila.Cells["Id_Proveedor"].Value != DBNull.Value)
            {
                idProveedorSeleccionado = Convert.ToInt32(fila.Cells["Id_Proveedor"].Value);
            }

            txtRazonSocial.Text = Texto(fila, "Razon_Social");
            txtCUIT.Text = Texto(fila, "CUIT");
            txtTelefono.Text = Texto(fila, "Telefono");
            txtEmail.Text = Texto(fila, "Email");
            txtDireccion.Text = Texto(fila, "Direccion");

            activoSeleccionado = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);

            AplicarModo(Modo.Consulta);
        }

        private static string Texto(DataGridViewRow fila, string columna)
        {
            object? valor = fila.Cells[columna].Value;
            return valor == null || valor == DBNull.Value ? "" : valor.ToString() ?? "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(lblResultado);

            LimpiarControles();
            AplicarModo(Modo.Agregando);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        // Cierra el formulario y devuelve el control al menú principal, que reaparece
        // solo porque FormMenu abre este form con ShowDialog. Igual que en Productos.
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
