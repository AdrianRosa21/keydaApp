using Guna.UI2.WinForms;
using Modelo;
using Modelo.Entidades;
using Modelo.PDF;
using QuestPDF.Fluent;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Reportes
{
    public partial class frmReportes : Form
    {
        private string rutaLogo;
        public frmReportes()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            btnVentas.Cursor = Cursors.Default;
            btnConsultarVentas.Visible = false;
            btnExportarReporteVentas.Visible = false;
            ConfigurarBotonesReportes();
            ConfigurarDataGridViews();
            ConfigurarPanelesReportes();
        }

        private void ConfigurarBotonesReportes()
        {
            ConfigurarBotonReporte(btnConsultarVentas, Color.FromArgb(121, 75, 45));
            ConfigurarBotonReporte(btnConsultar, Color.FromArgb(166, 126, 91));
            ConfigurarBotonReporte(btnConsultarCotizaciones, Color.FromArgb(174, 91, 57));
            ConfigurarBotonReporte(btnExportarReporteClientes, Color.FromArgb(112, 153, 82));
            ConfigurarBotonReporte(btnExportarCotizaciones, Color.FromArgb(196, 133, 67));
            ConfigurarBotonReporte(btnExportarReporteVentas, Color.FromArgb(94, 58, 36));
        }
        private void ConfigurarBotonReporte(Guna.UI2.WinForms.Guna2Button boton, Color color)
        {
            boton.FillColor = color;
            boton.ForeColor = Color.White;

            boton.BorderColor = Color.FromArgb(
                Math.Max(color.R - 15, 0),
                Math.Max(color.G - 15, 0),
                Math.Max(color.B - 15, 0)
            );

            boton.BorderThickness = 1;
            boton.BorderRadius = 6;

            boton.HoverState.FillColor = Color.FromArgb(
                Math.Min(color.R + 20, 255),
                Math.Min(color.G + 20, 255),
                Math.Min(color.B + 20, 255)
            );

            boton.HoverState.ForeColor = Color.White;
            boton.HoverState.BorderColor = color;

            boton.PressedColor = Color.FromArgb(
                Math.Max(color.R - 25, 0),
                Math.Max(color.G - 25, 0),
                Math.Max(color.B - 25, 0)
            );

            boton.Cursor = Cursors.Hand;
        }
        private Guna2Elipse elipseDgvVentas;
        private Guna2Elipse elipseDgvClientes;
        private Guna2Elipse elipseDgvCotizaciones;

        private void ConfigurarDataGridViews()
        {
            elipseDgvVentas = new Guna2Elipse
            {
                TargetControl = dgvReporteVentas,
                BorderRadius = 10
            };

            elipseDgvClientes = new Guna2Elipse
            {
                TargetControl = dgvReporteClientes,
                BorderRadius = 10
            };

            elipseDgvCotizaciones = new Guna2Elipse
            {
                TargetControl = dgvReporteCotizaciones,
                BorderRadius = 10
            };
        }
        private Guna2Elipse elipseReporteCotizaciones;
        private Guna2Elipse elipseReporteVentas;
        private Guna2Elipse elipseReporteClientes;

        private void ConfigurarPanelesReportes()
        {
            elipseReporteCotizaciones = new Guna2Elipse
            {
                TargetControl = pnlReporteCotizaciones,
                BorderRadius = 12
            };

            elipseReporteVentas = new Guna2Elipse
            {
                TargetControl = pnlReportesVentas,
                BorderRadius = 12
            };

            elipseReporteClientes = new Guna2Elipse
            {
                TargetControl = pnlReporteDeClientes,
                BorderRadius = 12
            };
        }







        private void btnClientes_Click(object sender, EventArgs e)
        {
            //Ventas
            pnlReportesVentas.Visible = false;
            pnlBarraCambioVentas.Visible = false;
            btnExportarReporteVentas.Visible = false;
            btnConsultarVentas.Visible = false;

            //Clientes
            btnConsultar.Visible = true;
            pnlBarraCambiosClientes.Visible = true;
            pnlReporteDeClientes.Visible = true;
            btnExportarReporteClientes.Visible = true;


            //Cotizaciones
            pnlBarraCambiosCotizaciones.Visible = false;
            pnlReporteCotizaciones.Visible = false;
            btnConsultarCotizaciones.Visible = false;
            btnExportarCotizaciones.Visible = false;

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //Ventas
            pnlReportesVentas.Visible = true;
            pnlBarraCambioVentas.Visible = true;
            btnExportarReporteVentas.Visible = true;
            btnConsultarVentas.Visible = true;

            //Clientes
            btnConsultar.Visible = false;
            pnlBarraCambiosClientes.Visible = false;
            pnlReporteDeClientes.Visible = false;
            btnExportarReporteClientes.Visible = false;


            //Cotizaciones
            pnlBarraCambiosCotizaciones.Visible = false;
            pnlReporteCotizaciones.Visible = false;
            btnConsultarCotizaciones.Visible = false;
            btnExportarCotizaciones.Visible = false;
        }
        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            //Ventas
            pnlReportesVentas.Visible = false;
            pnlBarraCambioVentas.Visible = false;
            btnExportarReporteVentas.Visible = false;
            btnConsultarVentas.Visible = false;

            //Clientes
            btnConsultar.Visible = false;
            pnlBarraCambiosClientes.Visible = false;
            pnlReporteDeClientes.Visible = false;
            btnExportarReporteClientes.Visible = false;


            //Cotizaciones
            pnlBarraCambiosCotizaciones.Visible = true;
            pnlReporteCotizaciones.Visible = true;
            btnConsultarCotizaciones.Visible = true;
            btnExportarCotizaciones.Visible = true;
        }
        public void CargarReporteClientes()
        {
            dgvReporteClientes.DataSource = null;
            dgvReporteClientes.DataSource = ReportesClientes.CargarReporteClientes();
        }

        public void CargarReporteVentas()
        {
            dgvReporteVentas.DataSource = null;
            dgvReporteVentas.DataSource = ReportesVentas.CargarReporteVentas();
        }

        public void CargarReporteCotizaciones()
        {
            dgvReporteCotizaciones.DataSource = null;
            dgvReporteCotizaciones.DataSource =
                ReportesCotizaciones.CargarReporteCotizaciones();


        }

        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Tipos de reportes
            toolTip1.SetToolTip(btnClientes, "Muestra el reporte de clientes registrados.");
            toolTip1.SetToolTip(btnVentas, "Muestra el reporte de ventas realizadas.");
            toolTip1.SetToolTip(btnCotizaciones, "Muestra el reporte de cotizaciones registradas.");

            // Filtros por fecha
            toolTip1.SetToolTip(dtpFechaInicio, "Seleccione la fecha de inicio del período del reporte.");
            toolTip1.SetToolTip(dtpFechaFin, "Seleccione la fecha final del período del reporte.");

            // Reporte de clientes
            toolTip1.SetToolTip(btnConsultar, "Consulta los clientes registrados durante el período seleccionado.");
            toolTip1.SetToolTip(btnExportarReporteClientes, "Genera y abre un PDF con el reporte de clientes.");
            toolTip1.SetToolTip(dgvReporteClientes, "Muestra los clientes registrados durante el período seleccionado.");

            // Estadísticas de clientes
            toolTip1.SetToolTip(lblContadorTotal, "Cantidad total de clientes registrados.");
            toolTip1.SetToolTip(lblContadorCorporativos, "Cantidad de clientes corporativos registrados.");
            toolTip1.SetToolTip(lblContadorIndividual, "Cantidad de clientes individuales registrados.");

            // Reporte de ventas
            toolTip1.SetToolTip(btnConsultarVentas, "Consulta las ventas realizadas durante el período seleccionado.");
            toolTip1.SetToolTip(btnExportarReporteVentas, "Genera y abre un PDF con el reporte de ventas.");
            toolTip1.SetToolTip(dgvReporteVentas, "Muestra las ventas registradas durante el período seleccionado.");

            // Estadísticas de ventas
            toolTip1.SetToolTip(lblContadorVentasTotales, "Cantidad total de ventas registradas.");
            toolTip1.SetToolTip(lblMostrarFacturasEmitidas, "Cantidad de facturas emitidas durante el período seleccionado.");

            // Reporte de cotizaciones
            toolTip1.SetToolTip(btnConsultarCotizaciones, "Consulta las cotizaciones registradas durante el período seleccionado.");
            toolTip1.SetToolTip(btnExportarCotizaciones, "Genera y abre un PDF con el reporte de cotizaciones.");
            toolTip1.SetToolTip(dgvReporteCotizaciones, "Muestra las cotizaciones registradas durante el período seleccionado.");

            // Estadísticas de cotizaciones
            toolTip1.SetToolTip(lblMostrarCotizacionesAprobadas, "Cantidad de cotizaciones aprobadas.");
            toolTip1.SetToolTip(lblMostrarCotizacionesRechazadas, "Cantidad de cotizaciones rechazadas.");
            toolTip1.SetToolTip(lblMostrarTotalCotizaciones, "Cantidad total de cotizaciones registradas.");
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            CargarReporteClientes();
            CargarReporteVentas();
            CargarReporteCotizaciones();
            ActualizarEstadisticasClientes();
            ActualizarEstadisticasVentas();
            ActualizarEstadisticasCotizaciones();

            //CONFIGURACION DE TOOLTPS
            ConfigurarTooltips();

            dtpFechaFin.MaxDate = DateTime.Today;
            dtpFechaInicio.MaxDate = DateTime.Now;

            //Ventas
            pnlReportesVentas.Visible = false;
            pnlBarraCambioVentas.Visible = false;
            btnExportarReporteVentas.Visible = false;
            btnConsultarVentas.Visible = false;

            //Clientes
            btnConsultar.Visible = true;
            pnlBarraCambiosClientes.Visible = true;
            pnlReporteDeClientes.Visible = true;
            btnExportarReporteClientes.Visible = true;

            //Cotizaciones
            pnlBarraCambiosCotizaciones.Visible = false;
            pnlReporteCotizaciones.Visible = false;
            btnConsultarCotizaciones.Visible = false;
            btnExportarCotizaciones.Visible = false;


            dgvReporteVentas.Columns["IdVenta"].HeaderText = "N° de Venta";
            //dgvReporteVentas.Columns["N° FACTURA"].Visible = false;
            dgvReporteVentas.Columns["FechaVenta"].HeaderText = "Fecha de venta";


            // ENCABEZADOS DE COTIZACIONES

            dgvReporteCotizaciones.Columns["IdCotizacion"].HeaderText = "N° Cotización";

            dgvReporteCotizaciones.Columns["Fecha"].HeaderText = "Fecha";

            dgvReporteCotizaciones.Columns["Cliente"].HeaderText = "Cliente";

            dgvReporteCotizaciones.Columns["TipoCliente"].HeaderText = "Tipo de Cliente";

            dgvReporteCotizaciones.Columns["Estado"].HeaderText = "Estado";

            dgvReporteCotizaciones.Columns["Total"].HeaderText = "Total";

            // ESPACIO DE COLUMNAS

            dgvReporteCotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvReporteCotizaciones.Columns["IdCotizacion"].FillWeight = 80;
            dgvReporteCotizaciones.Columns["Fecha"].FillWeight = 90;
            dgvReporteCotizaciones.Columns["Cliente"].FillWeight = 150;
            dgvReporteCotizaciones.Columns["TipoCliente"].FillWeight = 120;
            dgvReporteCotizaciones.Columns["Estado"].FillWeight = 100;
            dgvReporteCotizaciones.Columns["Total"].FillWeight = 100;

            dgvReporteCotizaciones.Columns["Total"].DefaultCellStyle.Format = "$#,##0.00";

        }

        private void ActualizarEstadisticasClientes()
        {
            lblContadorTotal.Text = ReportesClientes.ContarClientesTotales().ToString();
            lblContadorCorporativos.Text = ReportesClientes.ContarClientesCorporativos().ToString();
            lblContadorIndividual.Text = ReportesClientes.ContarClientesIndividuales().ToString();
        }

        private void ActualizarEstadisticasVentas()
        {
            lblContadorVentasTotales.Text = ReportesVentas.ContarVentasTotales().ToString();
            lblMostrarFacturasEmitidas.Text = ReportesVentas.ContarFacturasEmitidas().ToString();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                ReportesClientes reporte = new ReportesClientes();
                DataTable clientes = reporte.ObtenerClientesPorFecha(fechaInicio, fechaFin);


                if (clientes == null || clientes.Rows.Count == 0)
                {
                    MessageBox.Show("No existen clientes registrados durante el período seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                dgvReporteClientes.DataSource = null;
                dgvReporteClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar el reporte de clientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarReporteClientes_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // VALIDAR PERÍODO

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // OBTENER CLIENTES DEL PERÍODO

                ReportesClientes reporte = new ReportesClientes();

                DataTable clientes = reporte.ObtenerClientesPorFecha(fechaInicio, fechaFin);

                if (clientes == null || clientes.Rows.Count == 0)
                {
                    MessageBox.Show("No existen clientes registrados durante el período seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // OBTENER ESTADÍSTICAS

                DataTable estadisticas = ReportesClientes.ObtenerEstadisticasClientes(fechaInicio, fechaFin);

                int clientesTotales = 0;
                int clientesCorporativos = 0;
                int clientesIndividuales = 0;

                if (estadisticas != null &&
                    estadisticas.Rows.Count > 0)
                {
                    clientesTotales = Convert.ToInt32(estadisticas.Rows[0]["ClientesTotales"]);

                    clientesCorporativos = Convert.ToInt32(estadisticas.Rows[0]["ClientesCorporativos"]);

                    clientesIndividuales = Convert.ToInt32(estadisticas.Rows[0]["ClientesIndividuales"]);
                }

                // CREAR CARPETA DE REPORTES

                string carpetaReportes = Path.Combine(Application.StartupPath, "Reportes");

                if (!Directory.Exists(carpetaReportes))
                {
                    Directory.CreateDirectory(carpetaReportes);
                }

                // NOMBRE DEL ARCHIVO

                string nombreArchivo = $"Reporte_Clientes_{fechaInicio:dd-MM-yyyy}_{fechaFin:dd-MM-yyyy}.pdf";

                string rutaArchivo = Path.Combine(carpetaReportes, nombreArchivo);

                // CREAR DOCUMENTO PDF

                ClientesDocumentoPDF documento = new ClientesDocumentoPDF(clientes, fechaInicio, fechaFin, clientesTotales, clientesCorporativos, clientesIndividuales);

                documento.GeneratePdf(rutaArchivo);

                // MENSAJE

                MessageBox.Show("El reporte de clientes se generó correctamente.\n\n" + $"Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}\n\n" + $"Clientes totales: {clientesTotales}\n" + $"Clientes corporativos: {clientesCorporativos}\n" +
                    $"Clientes individuales: {clientesIndividuales}\n\n" + $"Guardado en:\n{rutaArchivo}", "Reporte generado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ABRIR PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaArchivo,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte de clientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                dgvReporteVentas.DataSource = ReportesVentas.ObtenerVentasPorFecha(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar el reporte de ventas:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // VALIDAR PERÍODO

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // OBTENER VENTAS DEL PERÍODO

                DataTable ventas = ReportesVentas.ObtenerVentasPorFecha(fechaInicio, fechaFin);

                if (ventas == null || ventas.Rows.Count == 0)
                {
                    MessageBox.Show("No existen ventas registradas durante el período seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // OBTENER ESTADÍSTICAS

                DataTable estadisticas = ReportesVentas.ObtenerEstadisticasVentas(fechaInicio, fechaFin);

                int facturasEmitidas = 0;
                double totalVentas = 0;
                double ventaMasAlta = 0;

                if (estadisticas != null && estadisticas.Rows.Count > 0)
                {
                    facturasEmitidas = Convert.ToInt32(estadisticas.Rows[0]["FacturasEmitidas"]);

                    totalVentas = Convert.ToDouble(estadisticas.Rows[0]["TotalVentas"]);

                    ventaMasAlta = Convert.ToDouble(estadisticas.Rows[0]["VentaMasAlta"]);
                }

                // CREAR CARPETA DE REPORTES

                string carpetaReportes = Path.Combine(Application.StartupPath, "Reportes");

                if (!Directory.Exists(carpetaReportes))
                {
                    Directory.CreateDirectory(carpetaReportes);
                }

                // NOMBRE DEL ARCHIVO

                string nombreArchivo = $"Reporte_Ventas_{fechaInicio:dd-MM-yyyy}_{fechaFin:dd-MM-yyyy}.pdf";

                string rutaArchivo = Path.Combine(carpetaReportes, nombreArchivo);

                // CREAR DOCUMENTO

                VentasDocumentoPDF documento = new VentasDocumentoPDF(ventas, estadisticas, fechaInicio, fechaFin, rutaLogo);

                // GENERAR PDF
                documento.GenerarPDF(rutaArchivo);


                // MENSAJE

                MessageBox.Show("El reporte de ventas se generó correctamente.\n\n" + $"Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}\n\n" + $"Facturas emitidas: {facturasEmitidas}\n" +
                    $"Total de ventas: ${totalVentas:N2}\n" + $"Venta más alta: ${ventaMasAlta:N2}\n\n" + $"Guardado en:\n{rutaArchivo}", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // VERIFICAR QUE EL PDF EXISTA

                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("El PDF se generó, pero no se encontró en:\n\n" + rutaArchivo, "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                // ABRIR PDF

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaArchivo,
                    UseShellExecute = true
                });

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR:\n\n" + ex.ToString(), "Error al generar el reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadisticasCotizaciones()
        {
            try
            {
                // Tomamos todo el período disponible
                DateTime fechaInicio = new DateTime(2000, 1, 1);
                DateTime fechaFin = DateTime.Today;

                DataTable estadisticas = ReportesCotizaciones.ObtenerEstadisticasCotizaciones(fechaInicio, fechaFin);

                if (estadisticas != null && estadisticas.Rows.Count > 0)
                {
                    lblMostrarCotizacionesAprobadas.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesAprobadas"]).ToString();

                    lblMostrarCotizacionesRechazadas.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRechazadas"]).ToString();

                    lblMostrarTotalCotizaciones.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRegistradas"]).ToString();
                }
                else
                {
                    lblMostrarCotizacionesAprobadas.Text = "0";
                    lblMostrarCotizacionesRechazadas.Text = "0";
                    lblMostrarTotalCotizaciones.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar las estadísticas de cotizaciones:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarCotizaciones_Click_1(object sender, EventArgs e)
        {

            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // VALIDAR FECHAS

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // OBTENER COTIZACIONES

                DataTable cotizaciones = ReportesCotizaciones.ObtenerCotizacionesPorFecha(fechaInicio, fechaFin);

                // VALIDAR RESULTADOS

                if (cotizaciones == null || cotizaciones.Rows.Count == 0)
                {
                    dgvReporteCotizaciones.DataSource = null;

                    lblMostrarCotizacionesAprobadas.Text = "0";
                    lblMostrarCotizacionesRechazadas.Text = "0";
                    lblMostrarTotalCotizaciones.Text = "0";

                    MessageBox.Show("No existen cotizaciones registradas durante el período seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // MOSTRAR COTIZACIONES

                dgvReporteCotizaciones.DataSource = null;
                dgvReporteCotizaciones.DataSource = cotizaciones;

                // OBTENER ESTADÍSTICAS DEL MISMO PERÍODO

                DataTable estadisticas = ReportesCotizaciones.ObtenerEstadisticasCotizaciones(fechaInicio, fechaFin);

                // MOSTRAR ESTADÍSTICAS

                if (estadisticas != null &&
                    estadisticas.Rows.Count > 0)
                {
                    lblMostrarCotizacionesAprobadas.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesAprobadas"]).ToString();

                    lblMostrarCotizacionesRechazadas.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRechazadas"]).ToString();

                    lblMostrarTotalCotizaciones.Text = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRegistradas"]).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar el reporte de cotizaciones:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReportePDF(DataTable cotizaciones, DateTime fechaInicio, DateTime fechaFin, int cotizacionesRegistradas, int cotizacionesAprobadas, int cotizacionesRechazadas)
        {
            try
            {
                // CREAR CARPETA DE REPORTES

                string carpetaReportes = Path.Combine(Application.StartupPath, "Reportes");

                if (!Directory.Exists(carpetaReportes))
                {
                    Directory.CreateDirectory(carpetaReportes);
                }

                // NOMBRE DEL ARCHIVO

                string nombreArchivo = $"Reporte_Cotizaciones_{fechaInicio:dd-MM-yyyy}_{fechaFin:dd-MM-yyyy}.pdf";

                string rutaArchivo = Path.Combine(carpetaReportes, nombreArchivo);


                // CREAR DOCUMENTO

                CotizacionesDocumentoPDF documento = new CotizacionesDocumentoPDF(cotizaciones, fechaInicio, fechaFin, cotizacionesRegistradas, cotizacionesAprobadas, cotizacionesRechazadas);

                // GENERAR PDF

                documento.GeneratePdf(rutaArchivo);

                // MENSAJE

                MessageBox.Show("El reporte de cotizaciones se generó correctamente.\n\n" + $"Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}\n\n" + $"Cotizaciones registradas: {cotizacionesRegistradas}\n" +
                    $"Cotizaciones aprobadas: {cotizacionesAprobadas}\n" + $"Cotizaciones rechazadas: {cotizacionesRechazadas}\n\n" + $"Guardado en:\n{rutaArchivo}", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // ABRIR PDF

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaArchivo,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte de cotizaciones:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarCotizaciones_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // VALIDAR FECHAS

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }


                // OBTENER COTIZACIONES

                DataTable cotizaciones = ReportesCotizaciones.ObtenerCotizacionesPorFecha(fechaInicio, fechaFin);


                if (cotizaciones == null || cotizaciones.Rows.Count == 0)
                {
                    MessageBox.Show("No existen cotizaciones registradas durante el período seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // OBTENER ESTADÍSTICAS

                DataTable estadisticas = ReportesCotizaciones.ObtenerEstadisticasCotizaciones(fechaInicio, fechaFin);


                int cotizacionesRegistradas = 0;
                int cotizacionesAprobadas = 0;
                int cotizacionesRechazadas = 0;


                if (estadisticas != null &&
                    estadisticas.Rows.Count > 0)
                {
                    cotizacionesRegistradas = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRegistradas"]);

                    cotizacionesAprobadas = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesAprobadas"]);

                    cotizacionesRechazadas = Convert.ToInt32(estadisticas.Rows[0]["CotizacionesRechazadas"]);
                }


                // GENERAR PDF

                GenerarReportePDF(cotizaciones, fechaInicio, fechaFin, cotizacionesRegistradas, cotizacionesAprobadas, cotizacionesRechazadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al exportar el reporte de cotizaciones:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


