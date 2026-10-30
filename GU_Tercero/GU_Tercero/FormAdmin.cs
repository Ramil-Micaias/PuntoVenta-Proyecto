using Seguridad;
using Logica;
using Datos.Entidades;
using Vista;

namespace GU_Tercero
{
    //FormAdmin: Funciona como panel central de administración del sistema, permitiendo gestionar usuarios, roles y estados mediante una interfaz gráfica.
    public partial class FormAdmin : Form
    {
        // Consulta: los campos están bloqueados. Agregando (Nuevo) o Modificando: se habilitan
        // y Guardar graba el alta o la modificación según corresponda.
        private enum Modo { Consulta, Agregando, Modificando }

        private static readonly Color ROJO = Color.FromArgb(239, 68, 68);
        private static readonly Color VERDE = Color.FromArgb(16, 185, 129);

        private Modo modo = Modo.Consulta;

        // Usuario elegido en la grilla (0 = ninguno). El ID ya no se muestra en pantalla.
        private int idUsuarioSeleccionado = 0;
        private bool activoSeleccionado = true;
        private bool bloqueadoSeleccionado = false;

        public FormAdmin()
        {
            InitializeComponent();
            Grillas.Configurar(dgvUsuarios);
            txtDni.KeyPress += txtDni_KeyPress;
        }

        // En el DNI solo se pueden escribir números (máximo 8, por MaxLength).
        private void txtDni_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
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
            activoSeleccionado = true;
            bloqueadoSeleccionado = false;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();

            cmbRol.SelectedIndex = -1;
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
            AplicarModo(Modo.Consulta);
        }

        // Bloquea o habilita los campos y muestra solo los botones que sirven en cada momento.
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

            // Mientras se edita no se puede elegir otro usuario.
            dgvUsuarios.Enabled = !editando;

            // Al tocar Nuevo desaparece Modificar y al tocar Modificar desaparece Nuevo.
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

        // Inactivar (rojo) si el usuario está activo; Activar (verde) si está dado de baja;
        // Desbloquear (verde) si está activo pero bloqueado por intentos fallidos.
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

        // Ubica los botones visibles uno debajo del otro, sin huecos (Volver queda fijo abajo).
        private void AcomodarBotones()
        {
            // Se usa el modo y no boton.Visible, que es false mientras la pantalla todavía no se mostró.
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

            // Las medidas salen del alto real del botón (en el diseño: arriba 22, alto 32, paso 38),
            // así se respetan con el zoom de pantalla (125%, 150%...).
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

        //Cuando el administrador hace clic sobre un usuario:se cargan automáticamente los datos en pantalla.
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

            // Modificar solo habilita los campos; los cambios se graban con Guardar.
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

                // InsertarUsuarioCompleto valida todos los datos antes de guardar.
                string passwordTemporal = negocio.InsertarUsuarioCompleto(
                    txtApellido.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtDni.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtNombreUsuario.Text.Trim(),
                    cmbRol.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbRol.SelectedValue)
                );

                // La contraseña temporal se envía al correo del usuario nuevo.
                // Solo si el correo no sale se muestra en pantalla, para que no quede sin acceso.
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

                // El estado (activo / bloqueado) no se cambia acá: se mantiene el que tenía.
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

        // Botón de estado: Inactivar (baja lógica), Activar o Desbloquear según el usuario elegido.
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
