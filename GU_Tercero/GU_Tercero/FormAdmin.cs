using Seguridad;
using Logica;
using Datos.Entidades;
using Vista;

namespace GU_Tercero
{
    public partial class FormAdmin : Form
    {
        private enum Modo { Consulta, Agregando, Modificando }

        private static readonly Color ROJO = Color.FromArgb(239, 68, 68);
        private static readonly Color VERDE = Color.FromArgb(16, 185, 129);

        private Modo modo = Modo.Consulta;

        private int idUsuarioSeleccionado = 0;
        private bool activoSeleccionado = true;
        private bool bloqueadoSeleccionado = false;

        public FormAdmin()
        {
            InitializeComponent();
            Grillas.Configurar(dgvUsuarios);
            txtDni.KeyPress += txtDni_KeyPress;
        }

        private void txtDni_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void CargarRoles()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            cmbRol.DataSource = negocio.ObtenerRoles();

            cmbRol.DisplayMember = "Nombre_Rol";

            cmbRol.ValueMember = "Id_Rol";
        }

        private void LimpiarControles()
        {
            idUsuarioSeleccionado = 0;
            activoSeleccionado = true;
            bloqueadoSeleccionado = false;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();

            cmbRol.SelectedIndex = -1;
        }

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
            AplicarModo(Modo.Consulta);
        }

        private void AplicarModo(Modo nuevoModo)
        {
            modo = nuevoModo;
            bool editando = modo != Modo.Consulta;
            bool haySeleccion = idUsuarioSeleccionado != 0;

            txtApellido.ReadOnly = !editando;
            txtNombre.ReadOnly = !editando;
            txtDni.ReadOnly = !editando;
            txtCorreo.ReadOnly = !editando;
            txtNombreUsuario.ReadOnly = !editando;
            cmbRol.Enabled = editando;

            btnNuevo.Visible = modo != Modo.Modificando;
            btnModificar.Visible = modo == Modo.Modificando || (modo == Modo.Consulta && haySeleccion);
            btnGuardar.Visible = editando;
            btnCancelar.Visible = editando;
            btnEliminar.Visible = modo == Modo.Consulta && haySeleccion;

            ActualizarBotonEstado();
            AcomodarBotones();

            if (modo == Modo.Agregando)
            {
                grpDatos.Text = "Nuevo Usuario";
                txtApellido.Focus();
            }
            else if (modo == Modo.Modificando)
            {
                grpDatos.Text = "Modificando Usuario";
                txtApellido.Focus();
            }
            else
            {
                grpDatos.Text = "Datos del Usuario";
            }
        }

        private void ActualizarBotonEstado()
        {
            if (!activoSeleccionado)
            {
                btnEliminar.Text = "Activar";
                btnEliminar.BackColor = VERDE;
            }
            else if (bloqueadoSeleccionado)
            {
                btnEliminar.Text = "Desbloquear";
                btnEliminar.BackColor = VERDE;
            }
            else
            {
                btnEliminar.Text = "Inactivar";
                btnEliminar.BackColor = ROJO;
            }
        }

        private void AcomodarBotones()
        {
            bool editando = modo != Modo.Consulta;
            bool haySeleccion = idUsuarioSeleccionado != 0;

            var botones = new List<(Button boton, bool visible)>
            {
                (btnNuevo, modo != Modo.Modificando),
                (btnModificar, modo == Modo.Modificando || (modo == Modo.Consulta && haySeleccion)),
                (btnGuardar, editando),
                (btnCancelar, editando),
                (btnEliminar, modo == Modo.Consulta && haySeleccion),
            };

            int alto = btnNuevo.Height;
            int y = alto * 22 / 32;
            foreach (var (boton, visible) in botones)
            {
                if (!visible)
                    continue;

                boton.Top = y;
                y += alto * 38 / 32;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && modo == Modo.Consulta)
            {
                Mensajes.Limpiar(txtResultado);

                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["Id_Usuario"].Value);
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                txtDni.Text = fila.Cells["DNI"].Value?.ToString() ?? "";
                txtCorreo.Text = fila.Cells["Direccion_Correo"].Value == DBNull.Value ? "" : fila.Cells["Direccion_Correo"].Value.ToString();
                txtNombreUsuario.Text = fila.Cells["Nombre_Usuario"].Value?.ToString() ?? "";
                activoSeleccionado = fila.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Activo"].Value);
                bloqueadoSeleccionado = fila.Cells["Bloqueado"].Value != DBNull.Value && Convert.ToBoolean(fila.Cells["Bloqueado"].Value);
                cmbRol.Text = fila.Cells["Nombre_Rol"].Value == DBNull.Value ? "" : fila.Cells["Nombre_Rol"].Value.ToString();

                AplicarModo(Modo.Consulta);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(txtResultado);
            dgvUsuarios.ClearSelection();
            LimpiarControles();
            AplicarModo(Modo.Agregando);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(txtResultado);

            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            AplicarModo(Modo.Modificando);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(txtResultado);
            dgvUsuarios.ClearSelection();
            LimpiarControles();
            AplicarModo(Modo.Consulta);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Mensajes.Limpiar(txtResultado);

            if (modo == Modo.Modificando)
            {
                GuardarModificacion();
                return;
            }

            if (modo == Modo.Agregando)
            {
                GuardarNuevo();
            }
        }

        private void GuardarNuevo()
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                string passwordTemporal = negocio.InsertarUsuarioCompleto(
                    txtApellido.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtDni.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtNombreUsuario.Text.Trim(),
                    cmbRol.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbRol.SelectedValue)
                );

                Cursor = Cursors.WaitCursor;
                ResultadoEnvioEmail envio = negocio.EnviarPasswordInicial(txtCorreo.Text.Trim(), txtNombreUsuario.Text.Trim(), passwordTemporal);
                Cursor = Cursors.Default;

                string correo = txtCorreo.Text.Trim();

                CargarUsuarios();
                LimpiarControles();
                AplicarModo(Modo.Consulta);

                if (envio.Enviado)
                {
                    Mensajes.Exito(txtResultado, "Usuario creado correctamente. Se envió la contraseña temporal a " + correo + ".");
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
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GuardarModificacion()
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.ModificarUsuario(idUsuarioSeleccionado, txtApellido.Text.Trim(), txtNombre.Text.Trim(), txtDni.Text.Trim(),
                    txtCorreo.Text.Trim(), txtNombreUsuario.Text.Trim(),
                    cmbRol.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbRol.SelectedValue),
                    activoSeleccionado, bloqueadoSeleccionado);

                CargarUsuarios();
                LimpiarControles();
                AplicarModo(Modo.Consulta);
                Mensajes.Exito(txtResultado, "Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string mensaje;

                if (!activoSeleccionado)
                {
                    DialogResult resultado = MessageBox.Show("¿Está seguro de activar este usuario?", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                        return;

                    negocio.ActivarUsuario(idUsuarioSeleccionado);
                    mensaje = "Usuario activado correctamente.";
                }
                else if (bloqueadoSeleccionado)
                {
                    negocio.DesbloquearUsuario(idUsuarioSeleccionado);
                    mensaje = "Usuario desbloqueado correctamente.";
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("¿Está seguro de inactivar este usuario?", "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                        return;

                    negocio.DesactivarUsuario(idUsuarioSeleccionado);
                    mensaje = "Usuario inactivado correctamente.";
                }

                CargarUsuarios();
                LimpiarControles();
                AplicarModo(Modo.Consulta);
                Mensajes.Exito(txtResultado, mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado del usuario.\n" + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
