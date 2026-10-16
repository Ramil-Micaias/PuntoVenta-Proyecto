using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    // Menú que aparece arriba de cada pantalla para poder ir directo a cualquier otra
    // sin tener que volver al menú principal.
    public static class Navegacion
    {
        // Pantallas del sistema (también son los textos que muestra el menú).
        public const string MENU_PRINCIPAL = "Inicio";
        public const string USUARIOS = "Usuarios";
        public const string PRODUCTOS = "Producto y Stock";
        public const string PROVEEDORES = "Proveedores";
        public const string VENTAS = "Ventas (POS)";
        public const string COMPRAS = "Compras";
        public const string TALLER = "Taller";
        public const string MI_PERFIL = "Mi Perfil";
        public const string CONFIGURACION = "Configuración del Sistema";
        public const string CERRAR_SESION = "Cerrar Sesion";

        // Pantalla que el usuario eligió en el menú. El menú principal la lee
        // cuando se cierra la pantalla actual para abrir la siguiente.
        public static string Destino = MENU_PRINCIPAL;

        // Qué pantallas puede usar cada rol.
        public static bool PuedeVer(string rol, string pantalla)
        {
            if (pantalla == MENU_PRINCIPAL || pantalla == MI_PERFIL || pantalla == CERRAR_SESION)
            {
                return true;
            }

            if (rol == "Vendedor")
            {
                return pantalla == VENTAS;
            }

            if (rol == "Tecnico")
            {
                return pantalla == TALLER;
            }

            // Administrador tiene acceso completo
            return true;
        }

        // Agrega el menú arriba del formulario. La pantalla actual queda deshabilitada.
        public static void AgregarMenu(Form form, string rol, string pantallaActual)
        {
            MenuStrip menu = new MenuStrip();
            menu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            menu.Dock = DockStyle.Top;

            menu.Items.Add(CrearOpcion(MENU_PRINCIPAL, rol, pantallaActual));

            // Textos cortos para que todo entre también en las pantallas angostas.
            menu.Items.Add(CrearOpcion(USUARIOS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(PRODUCTOS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(PROVEEDORES, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(VENTAS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(COMPRAS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(TALLER, rol, pantallaActual));

            ToolStripMenuItem configuracion = new ToolStripMenuItem("Configuración");
            configuracion.DropDownItems.Add(CrearOpcion(MI_PERFIL, rol, pantallaActual));
            configuracion.DropDownItems.Add(CrearOpcion(CONFIGURACION, rol, pantallaActual));
            menu.Items.Add(configuracion);

            menu.Items.Add(CrearOpcion(CERRAR_SESION, rol, pantallaActual));

            // Al agregarlo último queda por encima de los demás paneles acoplados arriba.
            form.Controls.Add(menu);
            form.MainMenuStrip = menu;
            form.Load += Form_Load;
        }

        private static ToolStripMenuItem CrearOpcion(string pantalla, string rol, string pantallaActual)
        {
            ToolStripMenuItem opcion = new ToolStripMenuItem(pantalla);
            opcion.Tag = pantalla;
            opcion.Visible = PuedeVer(rol, pantalla);
            opcion.Enabled = pantalla != pantallaActual;
            opcion.Click += Opcion_Click;
            return opcion;
        }

        // Guarda a dónde quiere ir el usuario y cierra la pantalla actual.
        private static void Opcion_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem opcion = (ToolStripMenuItem)sender;

            // Las opciones de los submenús cuelgan de otra opción: se sube hasta la barra del menú.
            ToolStripItem item = opcion;
            while (item.OwnerItem != null)
            {
                item = item.OwnerItem;
            }
            Form form = item.Owner.FindForm();

            Destino = (string)opcion.Tag;
            form.Close();
        }

        // Cuando se abre la pantalla se agranda el alto del menú y se bajan los controles
        // para que el menú no tape nada. Se hace en el Load porque ahí ya está aplicado el zoom de pantalla.
        private static void Form_Load(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            int alto = form.MainMenuStrip.Height;

            if (form.MinimumSize.Height > 0)
            {
                form.MinimumSize = new Size(form.MinimumSize.Width, form.MinimumSize.Height + alto);
            }
            form.Height += alto;

            foreach (Control control in form.Controls)
            {
                // Los acoplados (Dock) ya se acomodan solos debajo del menú.
                if (control.Dock != DockStyle.None)
                {
                    continue;
                }

                bool anclaArriba = (control.Anchor & AnchorStyles.Top) == AnchorStyles.Top;
                bool anclaAbajo = (control.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom;

                if (anclaArriba && anclaAbajo)
                {
                    // Se estiró al agrandar el formulario: se baja y se le devuelve el alto que tenía.
                    control.Top += alto;
                    control.Height -= alto;
                }
                else if (!anclaAbajo)
                {
                    control.Top += alto;
                }
                // Los anclados solo abajo ya bajaron solos al agrandar el formulario.
            }
        }
    }
}
