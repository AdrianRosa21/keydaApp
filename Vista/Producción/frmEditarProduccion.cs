using Modelo.Entidades;
using System;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Producción
{
    public partial class frmEditarProduccion : Form
    {
        private int idProduccion;
        private DateTime fechaOriginal;
        private int progresoOriginal;
        public frmEditarProduccion(int idProduccion)
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);

            this.idProduccion = idProduccion;

            // Cargar los datos inmediatamente
            CargarProduccion();

            txtCliente.Enabled = false;
            txtCodigoProduccion.Enabled = false;
            txtMuebleRealizar.Enabled = false;

            dtpFechaEntrega.Value = DateTime.Today;

            //Navegacion con la tecla TAB
            dtpFechaEntrega.TabIndex = 1;
            nudProgreso.TabIndex = 2;
            btnCancelar.TabIndex = 3;
            btnGuardarCambios.TabIndex = 4;
        }

        private void CargarProduccion()
        {
            DbProducción produccion = new DbProducción();

            produccion.IdProduccion1 = idProduccion;

            bool encontrado = produccion.ObtenerProduccion();

            if (encontrado)
            {
                txtCodigoProduccion.Text = produccion.IdProduccion1.ToString();

                txtCliente.Text = produccion.Cliente1;

                txtMuebleRealizar.Text = produccion.Mueble1;

                // Cargar datos reales de la producción
                dtpFechaEntrega.Value = produccion.FechaEntrega1;
                nudProgreso.Value = produccion.Progreso1;

                lblEstado.Text = produccion.Estado1;

                // Guardar valores originales
                fechaOriginal = produccion.FechaEntrega1.Date;
                progresoOriginal = produccion.Progreso1;
            }
            else
            {
                MessageBox.Show("NO se encontró la producción con ID: " + idProduccion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void nudProgreso_ValueChanged_1(object sender, EventArgs e)
        {
            ActualizarEstado();

        }
        private void ActualizarEstado()
        {
            int progreso = (int)nudProgreso.Value;

            if (progreso == 0)
                lblEstado.Text = "Pendiente";
            else if (progreso < 100)
                lblEstado.Text = "En producción";
            else
                lblEstado.Text = "Finalizado";
        }
        private void btnGuardarCambios_Click_1(object sender, EventArgs e)
        {
            bool cambioFecha = dtpFechaEntrega.Value.Date != fechaOriginal.Date;

            bool cambioProgreso = (int)nudProgreso.Value != progresoOriginal;

            // No se modificó nada
            if (!cambioFecha && !cambioProgreso)
            {
                MessageBox.Show("No se detectaron cambios en la producción.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            DbProducción produccion = new DbProducción();

            produccion.IdProduccion1 = idProduccion;
            produccion.FechaEntrega1 = dtpFechaEntrega.Value.Date;
            produccion.Progreso1 = (int)nudProgreso.Value;

            if (produccion.ActualizarProduccion())
            {
                string mensaje;

                if (cambioFecha && cambioProgreso)
                {
                    mensaje = "La fecha de entrega y el progreso de la producción han sido actualizados correctamente.";
                }
                else if (cambioFecha)
                {
                    mensaje = "La fecha de entrega de la producción ha sido modificada correctamente.";
                }
                else
                {
                    mensaje = "El progreso de la producción ha sido actualizado correctamente.";
                    DialogResult = DialogResult.OK;

                }

                MessageBox.Show(mensaje, "Producción actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la producción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

