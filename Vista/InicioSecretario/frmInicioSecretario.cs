using Datos;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Vista.Responsive;

namespace Vista.InicioSecretario
{

    public partial class frmInicioSecretario : Form
    {
        private DbDashboard dbDashboard;
        public frmInicioSecretario()
        {
            InitializeComponent();


            //CONFIGURACIÓN DEL DATA GRID
            ConfigurarDataGrid();

            //TOOLTIPS
            ConfigurarToolTips();

            //CONFIGURACIÓN DE LOS GRÁFICOS
            ConfigurarGraficoPedidos();
            ConfigurarGraficoInventario();

            ResponsiveHelper.Apply(this);
            dbDashboard = new DbDashboard();

        }

        //PEDIDOS RECIENTES

        private void MostrarPedidosRecientes()
        {
            try
            {
                dgvPedidosRecientes.DataSource = null;

                dgvPedidosRecientes.DataSource =
                    DbPedidos.CargarPedidosRecientes();

                FormatearDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los pedidos recientes.\n\n" +
                    ex.Message,
                    "Pedidos recientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        //CONFIGURACIÓN DEL DATA GRID

        private void ConfigurarDataGrid()
        {
            dgvPedidosRecientes.AutoGenerateColumns = true;

            dgvPedidosRecientes.AllowUserToAddRows = false;
            dgvPedidosRecientes.AllowUserToDeleteRows = false;
            dgvPedidosRecientes.AllowUserToResizeRows = false;

            dgvPedidosRecientes.ReadOnly = true;

            dgvPedidosRecientes.MultiSelect = false;

            dgvPedidosRecientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPedidosRecientes.RowHeadersVisible = false;

            dgvPedidosRecientes.BackgroundColor = Color.White;

            dgvPedidosRecientes.BorderStyle = BorderStyle.None;

            dgvPedidosRecientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPedidosRecientes.GridColor = Color.FromArgb(225, 225, 225);

            dgvPedidosRecientes.EnableHeadersVisualStyles = false;

            dgvPedidosRecientes.ColumnHeadersHeight = 38;

            dgvPedidosRecientes.RowTemplate.Height = 32;

            dgvPedidosRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //ENCABEZADO

            dgvPedidosRecientes.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(121, 78, 48),

                    ForeColor = Color.White,

                    Font = new Font("Times New Roman", 10, FontStyle.Bold),

                    Alignment = DataGridViewContentAlignment.MiddleCenter,

                    SelectionBackColor = Color.FromArgb(121, 78, 48),

                    SelectionForeColor = Color.White
                };


            //FILAS

            dgvPedidosRecientes.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Color.White,

                    ForeColor = Color.FromArgb(55, 55, 55),

                    Font = new Font("Times New Roman", 10),

                    Alignment = DataGridViewContentAlignment.MiddleCenter,

                    SelectionBackColor = Color.FromArgb(238, 215, 185),

                    SelectionForeColor = Color.FromArgb(60, 45, 35),

                    Padding = new Padding(5)
                };


            //FILAS ALTERNADAS

            dgvPedidosRecientes.AlternatingRowsDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(250, 246, 240),

                    ForeColor = Color.FromArgb(55, 55, 55),

                    Font = new Font("Times New Roman", 10),

                    SelectionBackColor = Color.FromArgb(238, 215, 185),

                    SelectionForeColor = Color.FromArgb(60, 45, 35)
                };
        }


        private void FormatearDataGrid()
        {
            if (dgvPedidosRecientes.Columns.Count == 0)
                return;


            foreach (
                DataGridViewColumn columna
                in dgvPedidosRecientes.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            //ID DEL PEDIDO

            if (dgvPedidosRecientes.Columns.Contains("IdPedido"))
            {
                dgvPedidosRecientes.Columns["IdPedido"].HeaderText = "N.º Pedido";
            }


            //FECHA DEL PEDIDO

            if (dgvPedidosRecientes.Columns.Contains("FechaDePedido"))
            {
                dgvPedidosRecientes.Columns["FechaDePedido"].HeaderText = "Fecha de pedido";

                dgvPedidosRecientes.Columns["FechaDePedido"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }


            //FECHA DE ENTREGA

            if (dgvPedidosRecientes.Columns.Contains("FechaDeEntrega"))
            {
                dgvPedidosRecientes.Columns["FechaDeEntrega"].HeaderText = "Fecha de entrega";

                dgvPedidosRecientes.Columns["FechaDeEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }


            //ESTADO

            if (dgvPedidosRecientes.Columns.Contains("Estado"))
            {
                dgvPedidosRecientes.Columns["Estado"].HeaderText = "Estado";
            }


            dgvPedidosRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //GRÁFICO PEDIDOS POR ESTADO

        private void ConfigurarGraficoPedidos()
        {
            chartPedidosEstado.Series.Clear();

            chartPedidosEstado.ChartAreas.Clear();

            chartPedidosEstado.Legends.Clear();

            chartPedidosEstado.Titles.Clear();


            ChartArea area = new ChartArea("AreaPedidos");

            area.BackColor = Color.Transparent;


            chartPedidosEstado.ChartAreas.Add(area);


            Title titulo = new Title("Pedidos por estado", Docking.Top, new Font("Times New Roman", 12, FontStyle.Bold),
                    Color.FromArgb(70, 45, 30)
                );


            chartPedidosEstado.Titles.Add(titulo);
        }

        //GRÁFICO INVENTARIO

        private void ConfigurarGraficoInventario()
        {
            chartInventarioEstado.Series.Clear();

            chartInventarioEstado.ChartAreas.Clear();

            chartInventarioEstado.Legends.Clear();

            chartInventarioEstado.Titles.Clear();


            ChartArea area = new ChartArea("AreaInventario");

            area.BackColor = Color.Transparent;


            area.AxisX.MajorGrid.Enabled = false;

            area.AxisY.MajorGrid.LineColor = Color.FromArgb(225, 225, 225);

            area.AxisX.LabelStyle.Font = new Font("Times New Roman", 9);

            area.AxisY.LabelStyle.Font = new Font("Times New Roman", 9);

            area.AxisY.Interval = 1;

            chartInventarioEstado.ChartAreas.Add(area);

            Series serie = new Series("Inventario");

            serie.ChartType = SeriesChartType.Column;

            serie.IsValueShownAsLabel = true;

            serie.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            serie.BorderWidth = 1;

            chartInventarioEstado.Series.Add(serie);

            Title titulo = new Title("Estado del inventario", Docking.Top, new Font("Times New Roman", 12, FontStyle.Bold), Color.FromArgb(70, 45, 30));


            chartInventarioEstado.Titles.Add(titulo);
        }
        private void CargarIndicadores()
        {
            try
            {
                DataTable datos = dbDashboard.ObtenerIndicadores();

                if (datos.Rows.Count > 0)
                {
                    DataRow fila = datos.Rows[0];

                    // Materiales registrados
                    lblMateriales.Text =
                        Convert.ToInt32(
                            fila["MaterialesRegistrados"]
                        ).ToString();

                    // Clientes registrados
                    lblClientess.Text =
                        Convert.ToInt32(
                            fila["ClientesRegistrados"]
                        ).ToString();

                    //Pedidos Activos
                    lblPedidosActivos.Text = DbDashboard.ContarPedidosActivos().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los indicadores: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        //CARGAR PEDIDOS POR ESTADO

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

        //CARGAR INVENTARIO

        private void CargarInventarioPorEstado()
        {
            try
            {
                DataTable datos = dbDashboard.ObtenerInventarioEstado();

                chartInventarioEstado.Series.Clear();

                if (datos.Rows.Count == 0)
                {
                    return;
                }

                Series serie = new Series("Inventario");

                serie.ChartType = SeriesChartType.Column;

                serie.IsValueShownAsLabel = true;

                serie.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                serie.BorderWidth = 1;

                foreach (DataRow fila in datos.Rows)
                {
                    string estado = fila["EstadoInventario"].ToString();

                    int cantidad = Convert.ToInt32(fila["Cantidad"]);

                    DataPoint punto = new DataPoint();

                    punto.SetValueXY(estado, cantidad);

                    punto.Label = cantidad.ToString();

                    punto.ToolTip = estado + ": " + cantidad + " materiales";


                    serie.Points.Add(punto);
                }

                chartInventarioEstado.Series.Add(serie);

                ChartArea area = chartInventarioEstado.ChartAreas["AreaInventario"];

                area.AxisX.Title = "Estado";

                area.AxisY.Title = "Cantidad";

                area.AxisY.LabelStyle.Format = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico del inventario:\n\n" + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //TOOLTIPS

        private void ConfigurarToolTips()
        {
            ToolTip tooltip = new ToolTip();

            tooltip.AutoPopDelay = 5000;

            tooltip.InitialDelay = 400;

            tooltip.ReshowDelay = 200;

            tooltip.ShowAlways = true;

            //CLIENTES

            tooltip.SetToolTip(lblClientes, "Total de clientes registrados.");

            //PEDIDOS

            tooltip.SetToolTip(lblPedidosAc, "Total de pedidos activos.");

            //INVENTARIO

            tooltip.SetToolTip(lblMaterialesRegistrados, "Total de materiales del inventario.");

            //DATA GRID

            tooltip.SetToolTip(dgvPedidosRecientes, "Muestra los últimos pedidos registrados.");

            //GRÁFICOS

            tooltip.SetToolTip(chartPedidosEstado, "Distribución de los pedidos según su estado.");

            tooltip.SetToolTip(chartInventarioEstado, "Muestra los materiales agotados, por agotarse y disponibles.");
        }

        private void CargarLogoEmpresa()
        {
            try
            {
                string rutaLogo =
                    Modelo.Properties.Settings.Default.LogoEmpresa;

                if (!string.IsNullOrWhiteSpace(rutaLogo) &&
                    File.Exists(rutaLogo))
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
                MessageBox.Show("ERR-DASH-001: No se pudo cargar el logo de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD
        private void frmInicioSecretario_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarPedidosRecientes();

                CargarPedidosPorEstado();
                CargarIndicadores();

                CargarInventarioPorEstado();

                CargarPedidosPorEstado();

                CargarLogoEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Dashboard: " + ex.Message, "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


