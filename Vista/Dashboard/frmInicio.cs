using Datos;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Vista.Responsive;


namespace Vista.Dashboard
{
    public partial class frmInicio : Form
    {

        private DbDashboard dbDashboard;
        public frmInicio()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            dbDashboard = new DbDashboard();
            ConfigurarTarjetas();

        }
        private Guna2Elipse elipseVentas;
        private Guna2Elipse elipseMateriales;
        private Guna2Elipse elipseClientes;
        private Guna2Elipse elipsePedidos;
        private void ConfigurarTarjetas()
        {
            elipseVentas = new Guna2Elipse
            {
                TargetControl = pnlVentasMes,
                BorderRadius = 12
            };

            elipseMateriales = new Guna2Elipse
            {
                TargetControl = pnlProductosInventario,
                BorderRadius = 12
            };

            elipseClientes = new Guna2Elipse
            {
                TargetControl = pnlCotizacionesRegistradas,
                BorderRadius = 12
            };

            elipsePedidos = new Guna2Elipse
            {
                TargetControl = pnlpClientesRegistrados,
                BorderRadius = 12
            };

            // HOVER
            ConfigurarHoverTarjeta(pnlVentasMes);
            ConfigurarHoverTarjeta(pnlProductosInventario);
            ConfigurarHoverTarjeta(pnlCotizacionesRegistradas);
            ConfigurarHoverTarjeta(pnlpClientesRegistrados);
        }
        private void ConfigurarHoverTarjeta(Control tarjeta)
        {
            tarjeta.MouseEnter += Tarjeta_MouseEnter;
            tarjeta.MouseLeave += Tarjeta_MouseLeave;

            foreach (Control control in tarjeta.Controls)
                ConfigurarHoverTarjeta(control);
        }
        private void Tarjeta_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlVentasMes &&
                   control != pnlProductosInventario &&
                   control != pnlCotizacionesRegistradas &&
                   control != pnlpClientesRegistrados)
            {
                control = control.Parent;
            }

            if (control == pnlVentasMes)
                control.BackColor = Color.FromArgb(255, 165, 125); // Naranja, mismo tono

            else if (control == pnlCotizacionesRegistradas)
                control.BackColor = Color.FromArgb(155, 118, 220); // Morado, mismo tono

            else if (control == pnlProductosInventario)
                control.BackColor = Color.FromArgb(135, 150, 225); // Azul, mismo tono

            else if (control == pnlpClientesRegistrados)
                control.BackColor = Color.FromArgb(165, 235, 145); // Verde, mismo tono
        }

        private void Tarjeta_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlVentasMes &&
                   control != pnlProductosInventario &&
                   control != pnlCotizacionesRegistradas &&
                   control != pnlpClientesRegistrados)
            {
                control = control.Parent;
            }

            if (control == pnlVentasMes)
                control.BackColor = Color.FromArgb(255, 155, 115); // ORIGINAL

            else if (control == pnlCotizacionesRegistradas)
                control.BackColor = Color.FromArgb(145, 108, 210); // ORIGINAL

            else if (control == pnlProductosInventario)
                control.BackColor = Color.FromArgb(125, 140, 215); // ORIGINAL

            else if (control == pnlpClientesRegistrados)
                control.BackColor = Color.FromArgb(155, 230, 135); // ORIGINAL
        }
        private void CargarLogoEmpresa()
        {
            try
            {
                string rutaLogo = Modelo.Properties.Settings.Default.LogoEmpresa;

                if (!string.IsNullOrWhiteSpace(rutaLogo) && File.Exists(rutaLogo))
                {
                    if (picLogo.Image != null)
                    {
                        picLogo.Image.Dispose();
                        picLogo.Image = null;
                    }

                    using (Image imagenOriginal = Image.FromFile(rutaLogo))
                    {
                        picLogo.Image = new Bitmap(imagenOriginal);
                    }

                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    // Si todavía no hay logo configurado
                    picLogo.Image = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERR-DASH-001: No se pudo cargar el logo de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        private void CargarIndicadores()
        {
            try
            {
                DataTable datos = dbDashboard.ObtenerIndicadores();

                if (datos.Rows.Count > 0)
                {
                    DataRow fila = datos.Rows[0];

                    lblMateriales.Text = Convert.ToInt32(fila["MaterialesRegistrados"]).ToString();
                    lblClientess.Text = Convert.ToInt32(fila["ClientesRegistrados"]).ToString();

                    decimal ventas = Convert.ToDecimal(fila["VentasDelMes"]);
                    lblVentas.Text = ventas.ToString("$#,##0.00");

                    lblCotizacioness.Text = Convert.ToInt32(fila["CotizacionesRegistradas"]).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los indicadores: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPedidosPorEstado()
        {
            try
            {
                DataTable datos = DbDashboard.ObtenerPedidosPorEstado();

                chartPedidosEstado.Series.Clear();

                chartPedidosEstado.Legends.Clear();

                if (datos.Rows.Count == 0)
                {
                    return;
                }

                Series serie = new Series("Pedidos");

                serie.ChartType = SeriesChartType.Doughnut;

                serie.IsValueShownAsLabel = false;

                serie["DoughnutRadius"] = "60";

                serie["PieLabelStyle"] = "Disabled";

                serie.BorderWidth = 2;

                serie.BorderColor = Color.White;

                foreach (DataRow fila in datos.Rows)
                {
                    string estado = fila["Estado"].ToString();

                    int cantidad = Convert.ToInt32(fila["Cantidad"]);

                    DataPoint punto = new DataPoint();

                    punto.SetValueXY(estado, cantidad);

                    punto.LegendText = estado + ": " + cantidad;

                    punto.ToolTip = estado + ": " + cantidad + " pedidos";

                    serie.Points.Add(punto);
                }

                chartPedidosEstado.Series.Add(serie);

                Legend leyenda = new Legend("Estados");

                leyenda.Docking = Docking.Bottom;

                leyenda.Alignment = StringAlignment.Center;

                leyenda.BackColor = Color.Transparent;

                leyenda.Font = new Font("Times New Roman", 9);

                chartPedidosEstado.Legends.Add(leyenda);

                serie.Legend = "Estados";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de pedidos:\n\n" + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarVentasPorMes()
        {
            try
            {
                DataTable datos = dbDashboard.ObtenerVentasPorMes();

                chartVentasMes.Series.Clear();
                chartVentasMes.Titles.Clear();
                chartVentasMes.Legends.Clear();

                chartVentasMes.Titles.Add("Ventas por Mes");

                Series serie = new Series("Ventas");

                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;

                serie.ToolTip = "#VALX: $#,##0.00";

                foreach (DataRow fila in datos.Rows)
                {
                    string mes = fila["Mes"].ToString();

                    decimal total = Convert.ToDecimal(fila["TotalVentas"]);

                    serie.Points.AddXY(mes, total);
                }

                chartVentasMes.Series.Add(serie);

                ChartArea area = chartVentasMes.ChartAreas[0];

                area.AxisX.Title = "Mes";
                area.AxisY.Title = "Ventas";

                area.AxisY.LabelStyle.Format = "$#,##0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de ventas: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCotizacionesPorEstado()
        {
            try
            {
                DataTable datos = DbDashboard.ObtenerCotizacionesPorEstado();

                chartCotizacionesEstado.Series.Clear();
                chartCotizacionesEstado.Titles.Clear();
                chartCotizacionesEstado.Legends.Clear();

                chartCotizacionesEstado.Titles.Add("Cotizaciones por Estado");

                Series serie = new Series("Cotizaciones");

                serie.ChartType = SeriesChartType.Doughnut;

                serie.IsValueShownAsLabel = true;

                foreach (DataRow fila in datos.Rows)
                {
                    string estado = fila["Estado"].ToString();

                    int cantidad = Convert.ToInt32(fila["Cantidad"]);

                    serie.Points.AddXY(estado, cantidad);
                }

                chartCotizacionesEstado.Series.Add(serie);

                Legend leyenda = new Legend("Estados");

                chartCotizacionesEstado.Legends.Add(leyenda);

                serie.Legend = "Estados";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de cotizaciones: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            try
            {
                CargarIndicadores();

                CargarCotizacionesPorEstado();

                CargarPedidosPorEstado();

                CargarVentasPorMes();

                CargarLogoEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Dashboard: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chartPedidosEstado_Click(object sender, EventArgs e)
        {

        }
    }

}


