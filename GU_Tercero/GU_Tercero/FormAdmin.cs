using Logica;
using Datos.Entidades;

namespace GU_Tercero
{
    //FormAdmin: Funciona como panel central de administración del sistema, permitiendo gestionar usuarios, roles y estados mediante una interfaz gráfica.
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        //Este metodo obtiene los roles desde SQL SERVER, luego muestra en el ComboBox.
        private void CargarRoles()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            cmbRol.DataSource = negocio.ObtenerRoles();

            cmbRol.DisplayMember = "Nombre_Rol";

            cmbRol.ValueMember = "Id_Rol";
        }

        //Este metodo Restablece los CONTROLES.
        private void LimpiarControles()
        {
            txtIdUsuario.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();
            txtPasswordTemporal.Clear();

            cmbRol.SelectedIndex = -1;

            chkActivo.Checked = true;
            chkBloqueado.Checked = false;
        }

        //Este metodo obtiene los usuarios desde la capa de negocio y los muestra en el DataGridView.
        private void CargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            dgvUsuarios.DataSource = negocio.ObtenerUsuarios();
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }

        private void lblRol_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Cuando el administrador hace clic sobre un usuario:se cargan automáticamente los datos en pantalla.
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                txtIdUsuario.Text = fila.Cells["Id_Usuario"].Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                txtDni.Text = fila.Cells["DNI"].Value?.ToString() ?? "";
                txtCorreo.Text = fila.Cells["Direccion_Correo"].Value == DBNull.Value ? "" : fila.Cells["Direccion_Correo"].Value.ToString();
                txtNombreUsuario.Text = fila.Cells["Nombre_Usuario"].Value?.ToString() ?? "";
                chkActivo.Checked = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);
                chkBloqueado.Checked = fila.Cells["Bloqueado"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Bloqueado"].Value);
                cmbRol.Text = fila.Cells["Nombre_Rol"].Value == DBNull.Value ? "" : fila.Cells["Nombre_Rol"].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    cmbRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();

                // Al llamar a InsertarUsuarioCompleto, si el DNI ya existe, saltará al catch con el mensaje limpio
                string passwordTemporal = negocio.InsertarUsuarioCompleto(
                    txtApellido.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtDni.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtNombreUsuario.Text.Trim(),
                    Convert.ToInt32(cmbRol.SelectedValue)
                );

                MessageBox.Show("Usuario creado correctamente.\n\nContraseña temporal: " + passwordTemporal, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                // Captura tanto la excepción de DNI duplicado de UsuarioNegocio como cualquier otro error
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.ModificarUsuario(Convert.ToInt32(txtIdUsuario.Text), txtApellido.Text.Trim(), txtNombre.Text.Trim(), txtDni.Text.Trim(), txtCorreo.Text.Trim(), txtNombreUsuario.Text.Trim(), Convert.ToInt32(cmbRol.SelectedValue), chkActivo.Checked, chkBloqueado.Checked);
                MessageBox.Show("Usuario modificado correctamente.");

                CargarUsuarios();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario.\n" + ex.Message);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro de dar de baja este usuario?", "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    negocio.DesactivarUsuario(Convert.ToInt32(txtIdUsuario.Text));

                    MessageBox.Show("Usuario dado de baja correctamente.");

                    CargarUsuarios();

                    LimpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario.\n" + ex.Message);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
