using Datos.Entidades;
using System.Drawing;
using Vista;

namespace GU_Tercero
{
    /// <summary>
    /// Menú general del sistema. Es el contenedor de todas las pantallas: la cabecera y la
    /// barra de secciones quedan siempre visibles y la sección elegida se abre dentro del
    /// panel de contenido, sin cerrar el menú.
    /// </summary>
    public partial class FormMenu : Form
    {
        /// <summary>
        /// Secciones que se pueden abrir desde la barra superior. El orden coincide con el
        /// que se ve en la barra.
        /// </summary>
        private enum Seccion
        {
            Inicio,
            Ventas,
            Compras,
            Productos,
            Proveedores,
            Taller,
            Usuarios,
            Perfil,
            Configuracion
        }

        private readonly Usuario usuarioLogueado;

        /// <summary>True cuando el menú se cerró pidiendo cerrar sesión, para volver al login.</summary>
        public bool EsCierreSesion { get; private set; } = false;

        private Seccion seccionActual = Seccion.Inicio;
        private readonly Dictionary<Seccion, Button> botonesSeccion = new Dictionary<Seccion, Button>();
        private readonly Dictionary<Seccion, bool> seccionesPermitidas = new Dictionary<Seccion, bool>();

        private Form? vistaActual;
        private Panel? vistaInicio;
        private Size tamanoDisenoVista = Size.Empty;

        /// <summary>Evita que el cierre de una pantalla vuelva a disparar la navegación.</summary>
        private bool quitandoVista;

        public FormMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }

        private void FormMenu_Load(object? sender, EventArgs e)
        {
            // El archivo del logo viene en negro: sobre la cabecera azul se ve en blanco.
            Recursos.CargarLogoBlanco(picLogo, PictureBoxSizeMode.Zoom);

            CargarDatosCabecera();

            AplicarPermisosPorRol();
            ConstruirBarraSecciones();

            pnlContenido.Resize += pnlContenido_Resize;

            lblTituloPantalla.Text = TituloDe(Seccion.Inicio);
            MostrarInicio();

            // El campo "Sistema" es informativo: se le sacan el foco y la selección.
            txtSistema.TabStop = false;
            ActiveControl = null;
        }

        /// <summary>
        /// Muestra nombre y rol en la cabecera para que se sepa con qué usuario se está trabajando.
        /// </summary>
        private void CargarDatosCabecera()
        {
            if (usuarioLogueado == null)
            {
                return;
            }

            string nombre = string.IsNullOrWhiteSpace(usuarioLogueado.Nombre_Usuario)
                ? "usuario"
                : usuarioLogueado.Nombre_Usuario;

            txtSistema.Text = $"AplBigstore - {nombre} ({usuarioLogueado.Nombre_Rol})";
        }

        // ------------------------------------------------------------------
        // Barra de secciones
        // ------------------------------------------------------------------

        /// <summary>
        /// Arma los botones de la barra. Solo aparecen las secciones habilitadas para el rol
        /// del usuario y se separan con un punto, igual que en el menú de referencia.
        /// </summary>
        private void ConstruirBarraSecciones()
        {
            // Se limpian a mano los controles anteriores (solo se repite si cambia el rol).
            foreach (Control control in flpSecciones.Controls)
            {
                control.Dispose();
            }

            flpSecciones.Controls.Clear();
            botonesSeccion.Clear();

            // Las secciones se colocan una al lado de la otra a partir del margen del panel.
            int x = flpSecciones.Padding.Left;
            int y = flpSecciones.Padding.Top;

            foreach (Seccion seccion in SeccionesVisibles())
            {
                if (botonesSeccion.Count > 0)
                {
                    Label separador = CrearSeparador();
                    separador.Location = new Point(x, y);
                    flpSecciones.Controls.Add(separador);
                    x += separador.Width;
                }

                Button boton = CrearBotonSeccion(seccion);
                boton.Location = new Point(x, y);
                flpSecciones.Controls.Add(boton);
                botonesSeccion[seccion] = boton;
                x += boton.Width;
            }

            flpSecciones.AutoScrollMinSize = new Size(x, 0);
        }

        private Label CrearSeparador()
        {
            Label separador = new Label
            {
                Text = "•",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Tema.NavSeparador,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(22, 41),
                Margin = new Padding(0)
            };

            return separador;
        }

        private Button CrearBotonSeccion(Seccion seccion)
        {
            string texto = NombreDe(seccion);

            Button boton = new Button
            {
                Text = texto,
                AutoSize = false,
                Size = new Size(TextRenderer.MeasureText(texto, Tema.FuenteNav).Width + 30, 41),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.NavFondo,
                ForeColor = Tema.NavTexto,
                Font = Tema.FuenteNav,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Margin = new Padding(0),
                Tag = seccion,
                UseVisualStyleBackColor = false,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Tema.NavFondoActivo,
                    MouseDownBackColor = Tema.NavFondoActivo
                }
            };

            boton.Click += BotonSeccion_Click;
            return boton;
        }

        private void BotonSeccion_Click(object? sender, EventArgs e)
        {
            if (sender is Button boton && boton.Tag is Seccion seccion)
            {
                NavegarA(seccion);
            }
        }

        /// <summary>
        /// Marca la sección abierta cambiando el color del botón y el título de la cabecera.
        /// </summary>
        private void ResaltarSeccion(Seccion seccion)
        {
            foreach (KeyValuePair<Seccion, Button> par in botonesSeccion)
            {
                bool activa = par.Key == seccion;
                par.Value.BackColor = activa ? Tema.NavFondoActivo : Tema.NavFondo;
                par.Value.ForeColor = activa ? Tema.NavTextoActivo : Tema.NavTexto;
            }
        }

        // ------------------------------------------------------------------
        // Permisos por rol
        // ------------------------------------------------------------------

        /// <summary>
        /// Define qué secciones ve cada rol. Es la misma lógica que usaba el menú anterior,
        /// translateada a las secciones de la barra.
        /// </summary>
        private void AplicarPermisosPorRol()
        {
            string rol = usuarioLogueado?.Nombre_Rol ?? "Administrador";

            foreach (Seccion seccion in Enum.GetValues(typeof(Seccion)))
            {
                seccionesPermitidas[seccion] = false;
            }

            if (rol == "Vendedor")
            {
                // El vendedor solo ve Ventas, Mi Perfil y Configuración del Sistema.
                Habilitar(Seccion.Ventas, Seccion.Perfil, Seccion.Configuracion);
            }
            else if (rol == "Tecnico")
            {
                // El técnico solo ve Taller, Mi Perfil y Configuración del Sistema.
                Habilitar(Seccion.Taller, Seccion.Perfil, Seccion.Configuracion);
            }
            else if (rol == "Administrador")
            {
                Habilitar(
                    Seccion.Ventas,
                    Seccion.Compras,
                    Seccion.Productos,
                    Seccion.Proveedores,
                    Seccion.Taller,
                    Seccion.Usuarios,
                    Seccion.Perfil,
                    Seccion.Configuracion);
            }
            else
            {
                // Cualquier otro rol entra solo a su perfil.
                Habilitar(Seccion.Perfil);
            }
        }

        private void Habilitar(params Seccion[] secciones)
        {
            foreach (Seccion seccion in secciones)
            {
                seccionesPermitidas[seccion] = true;
            }
        }

        private List<Seccion> SeccionesVisibles()
        {
            List<Seccion> visibles = new List<Seccion>();

            foreach (Seccion seccion in Enum.GetValues(typeof(Seccion)))
            {
                // El Inicio siempre está disponible, incluso para roles sin permisos.
                if (seccion == Seccion.Inicio || seccionesPermitidas[seccion])
                {
                    visibles.Add(seccion);
                }
            }

            return visibles;
        }

        // ------------------------------------------------------------------
        // Navegación entre pantallas
        // ------------------------------------------------------------------

        private void NavegarA(Seccion seccion)
        {
            seccionActual = seccion;
            lblTituloPantalla.Text = TituloDe(seccion);
            ResaltarSeccion(seccion);

            QuitarVistaActual();

            if (seccion == Seccion.Inicio)
            {
                MostrarInicio();
                return;
            }

            Form? vista = CrearVista(seccion);

            if (vista == null)
            {
                MostrarInicio();
                return;
            }

            PrepararComoPanel(vista);
            tamanoDisenoVista = vista.ClientSize;
            vistaActual = vista;

            vista.FormClosed += Vista_FormClosed;

            pnlContenido.Controls.Add(vista);
            vista.Show();

            UbicarVistaActual();
        }

        /// <summary>
        /// Crea el formulario de la sección elegida. Devuelve null si la sección no aplica.
        /// </summary>
        private Form? CrearVista(Seccion seccion)
        {
            switch (seccion)
            {
                case Seccion.Ventas:
                    return new FormVentas(usuarioLogueado);
                case Seccion.Compras:
                    return new FormCompras(usuarioLogueado);
                case Seccion.Productos:
                    return new FormProductos();
                case Seccion.Proveedores:
                    return new FormProveedores();
                case Seccion.Taller:
                    return new FormTaller();
                case Seccion.Usuarios:
                    return new FormAdmin();
                case Seccion.Perfil:
                    return new FormUsuario(usuarioLogueado);
                case Seccion.Configuracion:
                    return new FormConfiguracion();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convierte un formulario en un panel embebido: le saca los bordes, la barra de
        /// tareas y el tamaño mínimo para que ocupe el contenido del menú.
        /// </summary>
        private void PrepararComoPanel(Form vista)
        {
            vista.TopLevel = false;
            vista.FormBorderStyle = FormBorderStyle.None;
            vista.StartPosition = FormStartPosition.Manual;
            vista.MinimumSize = Size.Empty;
            vista.MaximumSize = Size.Empty;
            vista.MaximizeBox = false;
            vista.MinimizeBox = false;
            vista.ShowInTaskbar = false;
            vista.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Si el área de contenido da, la pantalla conserva su tamaño de diseño y queda
        /// centrada; si el menú quedó más chico, se estira para que entre completa.
        /// </summary>
        private void UbicarVistaActual()
        {
            if (vistaActual == null || vistaActual.IsDisposed)
            {
                return;
            }

            Size area = TamañoAreaContenido();

            if (area.Width >= tamanoDisenoVista.Width && area.Height >= tamanoDisenoVista.Height)
            {
                vistaActual.Dock = DockStyle.None;
                vistaActual.Bounds = new Rectangle(
                    (area.Width - tamanoDisenoVista.Width) / 2,
                    (area.Height - tamanoDisenoVista.Height) / 2,
                    tamanoDisenoVista.Width,
                    tamanoDisenoVista.Height);
            }
            else
            {
                vistaActual.Dock = DockStyle.Fill;
            }
        }

        private Size TamañoAreaContenido()
        {
            Size area = pnlContenido.ClientSize;

            return new Size(
                Math.Max(0, area.Width - pnlContenido.Padding.Horizontal),
                Math.Max(0, area.Height - pnlContenido.Padding.Vertical));
        }

        private void pnlContenido_Resize(object? sender, EventArgs e)
        {
            UbicarVistaActual();
        }

        /// <summary>
        /// Saca del panel la pantalla que estaba abierta. Los formularios que ya se cierran
        /// solos desde aquí, así que hay que descartarlos a mano para no dejar memoria.
        /// </summary>
        private void QuitarVistaActual()
        {
            vistaActual = null;
            vistaInicio = null;
            tamanoDisenoVista = Size.Empty;

            if (pnlContenido.Controls.Count == 0)
            {
                return;
            }

            quitandoVista = true;

            try
            {
                foreach (Control control in pnlContenido.Controls)
                {
                    pnlContenido.Controls.Remove(control);
                    control.Dispose();
                }
            }
            finally
            {
                quitandoVista = false;
            }
        }

        /// <summary>
        /// Los botones "Volver"/"Cerrar sesión" de cada pantalla cierran ese formulario, así que
        /// cuando pasa el formulario vuelve el Inicio en lugar de cerrarse el menú entero.
        /// </summary>
        private void Vista_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!quitandoVista)
            {
                MostrarInicio();
            }
        }

        // ------------------------------------------------------------------
        // Pantalla de bienvenida
        // ------------------------------------------------------------------

        private void MostrarInicio()
        {
            seccionActual = Seccion.Inicio;
            lblTituloPantalla.Text = TituloDe(Seccion.Inicio);
            ResaltarSeccion(Seccion.Inicio);

            if (vistaInicio != null || vistaActual != null)
            {
                QuitarVistaActual();
            }

            vistaInicio = CrearPanelInicio();
            pnlContenido.Controls.Add(vistaInicio);
        }

        private Panel CrearPanelInicio()
        {
            const int anchoTarjeta = 620;
            const int altoTarjeta = 400;

            Panel fondo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Panel tarjeta = new Panel
            {
                Width = anchoTarjeta,
                Height = altoTarjeta,
                BackColor = Color.FromArgb(248, 250, 252),
                Anchor = AnchorStyles.None
            };

            PictureBox logo = new PictureBox
            {
                Location = new Point(190, 18),
                Size = new Size(240, 240),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Recursos.CargarLogo(logo, PictureBoxSizeMode.Zoom);

            string nombre = usuarioLogueado?.Nombre_Usuario ?? string.Empty;
            string rol = usuarioLogueado?.Nombre_Rol ?? string.Empty;

            tarjeta.Controls.Add(logo);
            tarjeta.Controls.Add(CrearEtiquetaInicio(
                "Bienvenido",
                anchoTarjeta,
                272,
                28,
                new Font("Segoe UI Semibold", 15F),
                Tema.TextoSuave));
            tarjeta.Controls.Add(CrearEtiquetaInicio(
                string.IsNullOrWhiteSpace(nombre) ? "usuario" : nombre,
                anchoTarjeta,
                302,
                38,
                new Font("Segoe UI Semibold", 24F, FontStyle.Bold),
                Tema.NavTextoActivo));
            tarjeta.Controls.Add(CrearEtiquetaInicio(
                string.IsNullOrWhiteSpace(rol) ? string.Empty : $"Rol: {rol}",
                anchoTarjeta,
                342,
                22,
                new Font("Segoe UI", 10.5F),
                Tema.TextoSuave));
            tarjeta.Controls.Add(CrearEtiquetaInicio(
                "Usá la barra de secciones de arriba para abrir cualquier pantalla.",
                anchoTarjeta,
                368,
                22,
                new Font("Segoe UI", 9.5F, FontStyle.Italic),
                Tema.NavSeparador));

            // TableLayoutPanel con una sola celda centran la tarjeta al cambiar el tamaño.
            TableLayoutPanel centrador = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 1
            };
            centrador.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            centrador.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            centrador.Controls.Add(tarjeta, 0, 0);

            fondo.Controls.Add(centrador);
            return fondo;
        }

        private static Label CrearEtiquetaInicio(string texto, int ancho, int y, int alto, Font fuente, Color color)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(0, y),
                Size = new Size(ancho, alto),
                Font = fuente,
                ForeColor = color,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        // ------------------------------------------------------------------
        // Acciones de la cabecera
        // ------------------------------------------------------------------

        /// <summary>
        /// Vuelve a cargar la pantalla abierta para dejarla como recién salida.
        /// </summary>
        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            NavegarA(seccionActual);
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Querés cerrar sesión y volver al acceso al sistema?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            EsCierreSesion = true;
            Close();
        }

        private void FormMenu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Si la ventana se cierra por la cruz (X) y NO por cerrar sesión, salimos del proceso completo
            if (!EsCierreSesion)
            {
                Application.Exit();
            }
        }

        // ------------------------------------------------------------------
        // Nombres de las secciones
        // ------------------------------------------------------------------

        private static string NombreDe(Seccion seccion)
        {
            switch (seccion)
            {
                case Seccion.Inicio:
                    return "Inicio";
                case Seccion.Ventas:
                    return "Ventas";
                case Seccion.Compras:
                    return "Compras";
                case Seccion.Productos:
                    return "Stock";
                case Seccion.Proveedores:
                    return "Proveedores";
                case Seccion.Taller:
                    return "Taller";
                case Seccion.Usuarios:
                    return "Usuarios";
                case Seccion.Perfil:
                    return "Mi Perfil";
                case Seccion.Configuracion:
                    return "Configuración";
                default:
                    return seccion.ToString();
            }
        }

        private static string TituloDe(Seccion seccion)
        {
            switch (seccion)
            {
                case Seccion.Ventas:
                    return "Punto de Venta";
                case Seccion.Productos:
                    return "Productos y Stock";
                case Seccion.Usuarios:
                    return "Gestión de Usuarios";
                case Seccion.Configuracion:
                    return "Configuración del Sistema";
                default:
                    return NombreDe(seccion);
            }
        }
    }
}