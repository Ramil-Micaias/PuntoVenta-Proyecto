using System;
using System.Windows.Forms;
using Vista;

namespace GU_Tercero
{
    // punto de entrada del programa
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            // arranca con la pantalla de login
            Application.Run(new Form1());
        }
    }
}
