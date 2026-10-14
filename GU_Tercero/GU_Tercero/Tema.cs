namespace GU_Tercero
{
    /// <summary>
    /// Paleta y tipografías de la aplicación. Centraliza los colores de la cabecera,
    /// de la barra de secciones y del fondo de las pantallas para que todas las
    /// interfaces se vean iguales.
    /// </summary>
    internal static class Tema
    {
        // Cabecera azul oscuro
        public static readonly Color CabeceraFondo = Color.FromArgb(44, 62, 80);
        public static readonly Color CabeceraTitulo = Color.White;
        public static readonly Color CabeceraSubtitulo = Color.FromArgb(150, 170, 190);

        // Barra de secciones
        public static readonly Color NavFondo = Color.FromArgb(248, 250, 252);
        public static readonly Color NavBorde = Color.FromArgb(213, 222, 232);
        public static readonly Color NavTexto = Color.FromArgb(93, 109, 126);
        public static readonly Color NavTextoActivo = Color.FromArgb(27, 108, 168);
        public static readonly Color NavFondoActivo = Color.FromArgb(226, 238, 249);
        public static readonly Color NavSeparador = Color.FromArgb(176, 190, 205);

        // Botones de la cabecera
        public static readonly Color BotonNeutro = Color.FromArgb(57, 79, 99);
        public static readonly Color BotonNeutroHover = Color.FromArgb(70, 95, 119);
        public static readonly Color Acento = Color.FromArgb(41, 128, 185);
        public static readonly Color AcentoHover = Color.FromArgb(31, 110, 161);

        // Fondo de las pantallas
        public static readonly Color FondoPantalla = Color.FromArgb(238, 242, 246);
        public static readonly Color Texto = Color.FromArgb(15, 23, 42);
        public static readonly Color TextoSuave = Color.FromArgb(100, 116, 139);

        // Tipografías
        public static readonly Font FuenteMarca = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 7.5F);
        public static readonly Font FuenteTituloPantalla = new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
        public static readonly Font FuenteNav = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        public static readonly Font FuenteEtiqueta = new Font("Segoe UI", 8.25F);
        public static readonly Font FuenteCampo = new Font("Segoe UI", 9.5F);
    }
}