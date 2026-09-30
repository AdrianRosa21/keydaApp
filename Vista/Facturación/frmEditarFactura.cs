using Modelo.Entidades;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Vista.Facturación
{
    public partial class frmEditarFactura : Form
    {
        private const decimal TasaIva = 0.13m;

        private int idFactura;
        private decimal subTotal;
        private DateTime fechaEmision;

        // VALORES TAL COMO ESTÁN GUARDADOS EN LA BASE DE DATOS (PARA DETECTAR CAMBIOS SIN GUARDAR)
        private decimal descuentoGuardado;
        private DateTime vencimientoGuardado;
        private string observacionesGuardadas = "";

        private readonly ErrorProvider errorProvider1 = new ErrorProvider();

        public frmEditarFactura()
        {
            InitializeComponent();
        }

        public frmEditarFactura(int idFactura)
        {
            InitializeComponent();

            this.idFactura = idFactura;
        }

        private void frmEditarFactura_Load(object sender, EventArgs e)
        {
            txtNumeroFactura.ReadOnly = true;
            txtSubTotal.ReadOnly = true;
            txtIVA.ReadOnly = true;
            txtTotal.ReadOnly = true;

            dtFechaEmision.Enabled = false;

            txtObservaciones.MaxLength = 500;

            if (!CargarFactura())
                Close();
        }

        // CARGA LOS DATOS DE LA FACTURA SELECCIONADA
        private bool CargarFactura()
        {
            DataTable dt = DbFactura.CargarFacturaPorId(idFactura);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la factura.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataRow fila = dt.Rows[0];

            fechaEmision = Convert.ToDateTime(fila["FechaEmision"]).Date;
            subTotal = Convert.ToDecimal(fila["SubTotal"]);

            descuentoGuardado = fila["Descuento"] == DBNull.Value ? 0m : Convert.ToDecimal(fila["Descuento"]);

            vencimientoGuardado = fila["FechaVencimiento"] == DBNull.Value
                ? fechaEmision
                : Convert.ToDateTime(fila["FechaVencimiento"]).Date;

            observacionesGuardadas = fila["Observaciones"] == DBNull.Value ? "" : fila["Observaciones"].ToString().Trim();

            txtNumeroFactura.Text = fila["IdFactura"].ToString();
            dtFechaEmision.Value = fechaEmision;
            dtpFechaVencimiento.Value = vencimientoGuardado;
            txtSubTotal.Text = subTotal.ToString("0.00");
            txtDescuento.Text = descuentoGuardado.ToString("0.00");
            txtObservaciones.Text = observacionesGuardadas;

            CalcularTotales();

            return true;
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDescuento, "");

            CalcularTotales();
        }

        // SOLO PERMITE NÚMEROS Y UN SEPARADOR DECIMAL EN EL DESCUENTO
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            string separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar.ToString() == separador && !txtDescuento.Text.Contains(separador))
                return;

            e.Handled = true;
        }

        // MUESTRA EL IVA Y EL TOTAL CON EL MISMO CÁLCULO QUE LA VISTA VerFacturaEditar
        private void CalcularTotales()
        {
            decimal descuento = 0m;

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
                decimal.TryParse(txtDescuento.Text.Trim(), out descuento);

            // UN DESCUENTO NO VÁLIDO NO SE APLICA (SE MARCA AL GUARDAR)
            if (descuento < 0 || descuento > subTotal)
                descuento = 0m;

            decimal baseImponible = subTotal - descuento;
            decimal iva = Math.Round(baseImponible * TasaIva, 2, MidpointRounding.AwayFromZero);
            decimal total = baseImponible + iva;

            txtIVA.Text = iva.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        // VALIDA LOS CAMPOS EDITABLES
        private bool ValidarFormulario(out decimal descuento)
        {
            errorProvider1.Clear();

            descuento = 0m;

            if (dtpFechaVencimiento.Value.Date < fechaEmision)
            {
                errorProvider1.SetError(dtpFechaVencimiento, "La fecha de vencimiento no puede ser menor que la fecha de emisión.");
                dtpFechaVencimiento.Focus();
                return false;
            }

            string textoDescuento = txtDescuento.Text.Trim();

            if (textoDescuento.Length > 0 && !decimal.TryParse(textoDescuento, out descuento))
            {
                errorProvider1.SetError(txtDescuento, "Ingrese un descuento válido.");
                txtDescuento.Focus();
                return false;
            }

            if (descuento < 0)
            {
                errorProvider1.SetError(txtDescuento, "El descuento no puede ser negativo.");
                txtDescuento.Focus();
                return false;
            }

            if (descuento > subTotal)
            {
                errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que el subtotal.");
                txtDescuento.Focus();
                return false;
            }

            return true;
        }

        private bool GuardarCambios()
        {
            if (!ValidarFormulario(out decimal descuento))
                return false;

            DateTime vencimiento = dtpFechaVencimiento.Value.Date;
            string observaciones = txtObservaciones.Text.Trim();

            if (!DbFactura.ActualizarFactura(idFactura, vencimiento, descuento, observaciones))
                return false;

            descuentoGuardado = descuento;
            vencimientoGuardado = vencimiento;
            observacionesGuardadas = observaciones;

            return true;
        }

        private bool HayCambiosSinGuardar()
        {
            decimal.TryParse(txtDescuento.Text.Trim(), out decimal descuento);

            return descuento != descuentoGuardado
                || dtpFechaVencimiento.Value.Date != vencimientoGuardado
                || txtObservaciones.Text.Trim() != observacionesGuardadas;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!GuardarCambios())
                return;

            MessageBox.Show("Factura actualizada correctamente.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        private void btnGerarPdfModificado_Click(object sender, EventArgs e)
        {
            try
            {
                // EL PDF SE GENERA CON LOS DATOS GUARDADOS, POR ESO SE OFRECE GUARDAR ANTES
                if (HayCambiosSinGuardar())
                {
                    DialogResult respuesta = MessageBox.Show("Hay cambios sin guardar.\n¿Deseas guardarlos antes de generar el PDF?",
                        "Generar PDF", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Cancel)
                        return;

                    if (respuesta == DialogResult.Yes && !GuardarCambios())
                        return;
                }

                using (SaveFileDialog guardar = new SaveFileDialog())
                {
                    guardar.Title = "Guardar factura en PDF";
                    guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    guardar.FileName = $"Factura_{idFactura}.pdf";

                    if (guardar.ShowDialog() != DialogResult.OK)
                        return;

                    GeneradorFactura.Generar(idFactura, guardar.FileName);

                    if (File.Exists(guardar.FileName))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = guardar.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
