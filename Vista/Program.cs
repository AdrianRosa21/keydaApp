using Modelo.Entidades;
using QuestPDF.Infrastructure;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vista.Configuracion_Inicial;
using Vista.Login;

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

            AplicarIconoPredeterminado();

            bool existenUsuarios = DbUsuarios.ExistenUsuarios();

            // SI YA HAY USUARIOS SE MUESTRA EL LOGIN; SI NO, EL ASISTENTE DE CONFIGURACIÓN INICIAL
            Form pantallaInicial = existenUsuarios ? (Form)new frmLogin() : new ConfiguracionInicial();

            Navegacion.Iniciar(pantallaInicial);

        }

        // LAS VENTANAS SIN ICONO PROPIO USAN EL ICONO DE LA APLICACIÓN EN LUGAR DEL DE WINDOWS FORMS
        private static void AplicarIconoPredeterminado()
        {
            try
            {
                using (Stream flujo = Assembly.GetExecutingAssembly().GetManifestResourceStream("icono-app.ico"))
                {
                    if (flujo == null)
                        return;

                    FieldInfo campo = typeof(Form).GetField("defaultIcon", BindingFlags.Static | BindingFlags.NonPublic);

                    if (campo != null)
                        campo.SetValue(null, new Icon(flujo));
                }
            }
            catch (Exception)
            {
                // SI FALLA, SE CONSERVA EL ICONO PREDETERMINADO
            }
        }
    }
}
