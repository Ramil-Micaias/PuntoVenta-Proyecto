using Seguridad;
using Logica;
using Datos.Entidades;
using Vista;

namespace GU_Tercero
{
    //FormAdmin: Funciona como panel central de administración del sistema, permitiendo gestionar usuarios, roles y estados mediante una interfaz gráfica.
    public partial class FormAdmin : Form
    {
        // Usuario elegido en la grilla (0 = ninguno). El ID ya no se muestra en pantalla.
        private int idUsuarioSeleccionado = 0;

        public FormAdmin()
        {
            InitializeComponent();
            Grillas.Configurar(dgvUsuarios);
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
            idUsuarioSeleccionado = 0;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();

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
            LimpiarControles();
        }

        //Cuando el administrador hace clic sobre un usuario:se cargan automáticamente los datos en pantalla.
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["Id_Usuario"].Value);
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
            Mensajes.Limpiar(txtResultado);

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

                // La contraseña temporal se envía al correo del usuario nuevo.
                // Solo si el correo no sale se muestra en pantalla, para que no quede sin acceso.
                Cursor = Cursors.WaitCursor;
                ResultadoEnvioEmail envio = negocio.EnviarPasswordInicial(txtCorreo.Text.Trim(), txtNombreUsuario.Text.Trim(), passwordTemporal);
                Cursor = Cursors.Default;

                if (envio.Enviado)
                {
                    Mensajes.Exito(txtResultado, "Usuario creado correctamente. Se envió la contraseña temporal a " + txtCorreo.Text.Trim() + ".");
                }
                else
                {
                    MessageBox.Show(
                        "El usuario se creó, pero no se pudo enviar el correo con la contraseña temporal.\n" + envio.Error,
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    Mensajes.Exito(txtResultado, "Usuario creado. Contraseña temporal (no se pudo enviar por correo): " + passwordTemporal);
                }

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
            Mensajes.Limpiar(txtResultado);

            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.ModificarUsuario(idUsuarioSeleccionado, txtApellido.Text.Trim(), txtNombre.Text.Trim(), txtDni.Text.Trim(), txtCorreo.Text.Trim(), txtNombreUsuario.Text.Trim(), Convert.ToInt32(cmbRol.SelectedValue), chkActivo.Checked, chkBloqueado.Checked);
                Mensajes.Exito(txtResultado, "Usuario modificado correctamente.");

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
            Mensajes.Limpiar(txtResultado);

            if (idUsuarioSeleccionado == 0)
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

                    negocio.DesactivarUsuario(idUsuarioSeleccionado);

                    Mensajes.Exito(txtResultado, "Usuario dado de baja correctamente.");

                    CargarUsuarios();

                    LimpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario.\n" + ex.Message);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
