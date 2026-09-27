using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Responsive
{
    /// <summary>
    /// Hace que los formularios WinForms se adapten al tamaño de la ventana.
    /// Conserva el diseño original y ajusta posiciones, tamaños y fuentes de
    /// controles que no están administrados por Dock/Flow/TableLayout.
    /// </summary>
    public static class ResponsiveHelper
    {
        private class ControlInfo
        {
            public Control Control { get; set; }
            public Rectangle BoundsOriginales { get; set; }
            public float TamanoFuenteOriginal { get; set; }
        }

        private class FormInfo
        {
            public Size TamanoOriginal { get; set; }
            public List<ControlInfo> Controles { get; set; }
            public Timer TimerResize { get; set; }
        }

        private static Dictionary<Form, FormInfo> formularios = new Dictionary<Form, FormInfo>();


        public static void Apply(Form formulario)
        {
            // Evitar aplicar dos veces al mismo formulario
            if (formularios.ContainsKey(formulario))
                return;


            FormInfo infoFormulario = new FormInfo();

            // IMPORTANTE:
            // Este es el tamaño desde el cual se diseñó el formulario
            infoFormulario.TamanoOriginal = formulario.ClientSize;

            infoFormulario.Controles = new List<ControlInfo>();


            // Guardar posiciones y tamaños originales
            GuardarControles(formulario, infoFormulario.Controles);


            // Timer para esperar a que termine el Resize
            Timer timer = new Timer();

            timer.Interval = 10;

            timer.Tick += (sender, e) =>
            {
                timer.Stop();

                AjustarFormulario(formulario, infoFormulario);
            };


            infoFormulario.TimerResize = timer;

            formularios.Add(formulario, infoFormulario);


            // Cada vez que cambia el tamaño
            formulario.Resize += (sender, e) =>
            {
                timer.Stop();
                timer.Start();
            };
        }


        private static void GuardarControles(Control padre, List<ControlInfo> lista)
        {
            foreach (Control control in padre.Controls)
            {
                lista.Add(new ControlInfo
                {
                    Control = control,

                    BoundsOriginales = control.Bounds,

                    TamanoFuenteOriginal = control.Font.Size
                });


                // Buscar controles dentro de Panel,
                // GroupBox, TabPage, etc.
                if (control.HasChildren)
                {
                    GuardarControles(control, lista);
                }
            }
        }


        private static void AjustarFormulario(Form formulario, FormInfo info)
        {
            int anchoOriginal = info.TamanoOriginal.Width;

            int altoOriginal = info.TamanoOriginal.Height;


            if (anchoOriginal <= 0 ||
                altoOriginal <= 0)
                return;


            // Calcular escala
            float escalaX =
                (float)formulario.ClientSize.Width / anchoOriginal;

            float escalaY =
                (float)formulario.ClientSize.Height / altoOriginal;


            // Usar una sola escala para mantener
            // las proporciones
            float escala = Math.Min(escalaX, escalaY);

            foreach (ControlInfo controlInfo in info.Controles)
            {
                Control control = controlInfo.Control;


                // Si el control fue eliminado
                // o ya no existe
                if (control.IsDisposed)
                    continue;


                Rectangle original = controlInfo.BoundsOriginales;


                int x = (int)(original.X * escala);

                int y = (int)(original.Y * escala);

                int ancho = (int)(original.Width * escala);

                int alto = (int)(original.Height * escala);


                control.SetBounds(x, y, ancho, alto);

                float nuevoTamano =
    controlInfo.TamanoFuenteOriginal * escala;

                if (nuevoTamano < 6)
                    nuevoTamano = 6;

                if (nuevoTamano > 40)
                    nuevoTamano = 40;

                if (Math.Abs(control.Font.Size - nuevoTamano) > 0.1f)
                {
                    control.Font = new Font(
                        control.Font.FontFamily,
                        nuevoTamano,
                        control.Font.Style
                    );
                }


            }
        }
    }
}
