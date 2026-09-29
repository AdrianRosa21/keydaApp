using Modelo.Entidades;
using QuestPDF.Infrastructure;
using System;
using System.Windows.Forms;
using Vista.Configuracion_Inicial;

namespace Vista
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            QuestPDF.Settings.License = LicenseType.Community;

            bool existenUsuarios = DbUsuarios.ExistenUsuarios();

            Application.Run(new ConfiguracionInicial());
        }
    }
}
