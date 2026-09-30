using System.Windows.Forms;

namespace Vista
{
    // NAVEGACIÓN ENTRE LAS PANTALLAS PRINCIPALES (ASISTENTE DE CONFIGURACIÓN, LOGIN Y DASHBOARDS).
    // SE ABRE LA SIGUIENTE PANTALLA Y SE CIERRA LA ACTUAL (NO SE OCULTA) PARA QUE NO QUEDEN VENTANAS
    // ESCONDIDAS EN MEMORIA NI ENTRADAS REPETIDAS EN LA BARRA DE TAREAS.
    internal static class Navegacion
    {
        private static readonly ApplicationContext contexto = new ApplicationContext();

        // INICIA LA APLICACIÓN CON LA PRIMERA PANTALLA. LA APLICACIÓN TERMINA CUANDO SE CIERRA LA PANTALLA PRINCIPAL ACTIVA.
        public static void Iniciar(Form pantallaInicial)
        {
            contexto.MainForm = pantallaInicial;
            Application.Run(contexto);
        }

        // ABRE LA SIGUIENTE PANTALLA Y CIERRA LA ACTUAL
        public static void Ir(Form actual, Form siguiente)
        {
            // LA NUEVA PANTALLA PASA A SER LA PRINCIPAL ANTES DE CERRAR LA ACTUAL, PARA QUE LA APLICACIÓN NO TERMINE
            contexto.MainForm = siguiente;

            siguiente.Show();

            actual.Close();
        }
    }
}
