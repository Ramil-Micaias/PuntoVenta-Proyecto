using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public static class Navegacion
    {
        public const string MENU_PRINCIPAL = "Inicio";
        public const string USUARIOS = "Usuarios";
        public const string PRODUCTOS = "Productos y Categorías";
        public const string CONSULTA_STOCK = "Consulta de Stock";
        public const string PROVEEDORES = "Proveedores";
        public const string VENTAS = "Ventas (POS)";
        public const string COMPRAS = "Compras";
        public const string CAJA = "Caja Diaria";
        public const string TALLER = "Taller";
        public const string BITACORA = "Bitácora";
        public const string MI_PERFIL = "Mi Perfil";
        public const string CONFIGURACION = "Configuración del Sistema";
        public const string CERRAR_SESION = "Cerrar Sesion";

        public static string Destino = MENU_PRINCIPAL;

        public static bool PuedeVer(string rol, string pantalla)
        {
            if (pantalla == MENU_PRINCIPAL || pantalla == MI_PERFIL || pantalla == CERRAR_SESION || pantalla == CONSULTA_STOCK)
            {
                return true;
            }

            if (pantalla == BITACORA)
            {
                return Logica.Sesion.PuedeVerBitacora;
            }

            if (rol == "Vendedor")
            {
                return pantalla == VENTAS || pantalla == CAJA;
            }

            if (rol == "Tecnico")
            {
                return pantalla == TALLER;
            }

            return true;
        }

        public static void AgregarMenu(Form form, string rol, string pantallaActual)
        {
            MenuStrip menu = new MenuStrip();
            menu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            menu.Dock = DockStyle.Top;

            menu.Items.Add(CrearOpcion(MENU_PRINCIPAL, rol, pantallaActual));

            menu.Items.Add(CrearOpcion(USUARIOS, rol, pantallaActual));

            ToolStripMenuItem productoYStock = new ToolStripMenuItem("Producto y Stock");
            productoYStock.DropDownItems.Add(CrearOpcion(PRODUCTOS, rol, pantallaActual));
            productoYStock.DropDownItems.Add(CrearOpcion(CONSULTA_STOCK, rol, pantallaActual));
            menu.Items.Add(productoYStock);

            menu.Items.Add(CrearOpcion(PROVEEDORES, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(VENTAS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(COMPRAS, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(CAJA, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(TALLER, rol, pantallaActual));
            menu.Items.Add(CrearOpcion(BITACORA, rol, pantallaActual));

            ToolStripMenuItem configuracion = new ToolStripMenuItem("Configuración");
            configuracion.DropDownItems.Add(CrearOpcion(MI_PERFIL, rol, pantallaActual));
            configuracion.DropDownItems.Add(CrearOpcion(CONFIGURACION, rol, pantallaActual));
            menu.Items.Add(configuracion);

            menu.Items.Add(CrearOpcion(CERRAR_SESION, rol, pantallaActual));

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

        private static void Opcion_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem opcion = (ToolStripMenuItem)sender;

            ToolStripItem item = opcion;
            while (item.OwnerItem != null)
            {
                item = item.OwnerItem;
            }
            Form form = item.Owner.FindForm();

            Destino = (string)opcion.Tag;
            form.Close();
        }

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
                if (control.Dock != DockStyle.None)
                {
                    continue;
                }

                bool anclaArriba = (control.Anchor & AnchorStyles.Top) == AnchorStyles.Top;
                bool anclaAbajo = (control.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom;

                if (anclaArriba && anclaAbajo)
                {
                    control.Top += alto;
                    control.Height -= alto;
                }
                else if (!anclaAbajo)
                {
                    control.Top += alto;
                }
            }
        }
    }
}
