using System;
using System.Data;
using System.Windows.Forms;
using Datos.Entidades;
using Logica;

namespace Vista
{
    public partial class FormProveedores : Form
    {
        private int idProveedorSeleccionado = 0;
        private readonly GestorProveedores gestorProveedores = new GestorProveedores();

        public FormProveedores()
        {
            InitializeComponent();

            this.Load += FormProveedores_Load;
            this.dgvProveedores.CellClick += dgvProveedores_CellClick;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnModificar.Click += btnModificar_Click;
            this.btnEliminar.Click += btnEliminar_Click;
            this.btnNuevo.Click += btnNuevo_Click;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarProveedores();
        }

        private void ConfigurarGrid()
        {
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = gestorProveedores.ObtenerProveedores();
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

        private void LimpiarControles()
        {
            idProveedorSeleccionado = 0;

            txtRazonSocial.Clear();
            txtCUIT.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor prov = new Proveedor()
                {
                    Razon_Social = txtRazonSocial.Text.Trim(),
                    CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? null : txtCUIT.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                    Activo = true
                };

                gestorProveedores.RegistrarProveedor(prov);

                MessageBox.Show(
                    "Proveedor registrado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProveedores();
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

            try
            {
                Proveedor prov = new Proveedor()
                {
                    Id_Proveedor = idProveedorSeleccionado,
                    Razon_Social = txtRazonSocial.Text.Trim(),
                    CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? null : txtCUIT.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                    Activo = true
                };

                gestorProveedores.ModificarProveedor(prov);

                MessageBox.Show(
                    "Proveedor modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProveedores();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor de la lista para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea inactivar este proveedor?",
                "Confirmar Inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    gestorProveedores.InactivarProveedor(idProveedorSeleccionado);

                    MessageBox.Show(
                        "Proveedor inactivado con éxito.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CargarProveedores();
                    LimpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

            if (fila.Cells["Id_Proveedor"].Value != null && fila.Cells["Id_Proveedor"].Value != DBNull.Value)
            {
                idProveedorSeleccionado = Convert.ToInt32(fila.Cells["Id_Proveedor"].Value);
            }

            txtRazonSocial.Text = fila.Cells["Razon_Social"].Value != DBNull.Value
                ? fila.Cells["Razon_Social"].Value?.ToString() ?? ""
                : "";

            txtCUIT.Text = fila.Cells["CUIT"].Value != DBNull.Value
                ? fila.Cells["CUIT"].Value?.ToString() ?? ""
                : "";

            txtTelefono.Text = fila.Cells["Telefono"].Value != DBNull.Value
                ? fila.Cells["Telefono"].Value?.ToString() ?? ""
                : "";

            txtEmail.Text = fila.Cells["Email"].Value != DBNull.Value
                ? fila.Cells["Email"].Value?.ToString() ?? ""
                : "";

            txtDireccion.Text = fila.Cells["Direccion"].Value != DBNull.Value
                ? fila.Cells["Direccion"].Value?.ToString() ?? ""
                : "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
