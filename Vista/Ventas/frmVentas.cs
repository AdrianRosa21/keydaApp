using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Facturación;
using Vista.Responsive;

namespace Vista.Ventas
{
    public partial class frmVentas : Form
    {

        private DataTable dtVentas;
        private int paginaActual = 1;
        private int registrosPorPagina = 20;
        private int totalPaginas = 0;
        public frmVentas()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            pnlFacturaRegistrada.Visible = false;
            ConfigurarBotones();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private const string TextoBusqueda = "Buscar...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);


        private void ConfigurarBarraBusqueda()
        {
            ConfigurarBusqueda(txtBuscar);

        }
        private void ConfigurarBusqueda(Guna2TextBox txtBuscar)
        {
            txtBuscar.Text = TextoBusqueda;
            txtBuscar.ForeColor = ColorPlaceholder;

            txtBuscar.BorderRadius = 10;
            txtBuscar.BorderThickness = 1;
            txtBuscar.BorderColor = Color.LightGray;

            txtBuscar.FocusedState.BorderColor = ColorCafe;

            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == TextoBusqueda)
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }

                txtBuscar.BorderColor = ColorCafe;
                txtBuscar.BorderThickness = 2;
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = TextoBusqueda;
                    txtBuscar.ForeColor = ColorPlaceholder;
                }

                txtBuscar.BorderColor = Color.LightGray;
                txtBuscar.BorderThickness = 1;
            };
        }

        private void ConfigurarBotones()
        {
            ConfigurarBoton(btnRegistrarFactura);
            ConfigurarBoton(btnEliminar);
        }

        private void ConfigurarBoton(Guna.UI2.WinForms.Guna2Button boton)
        {
            boton.FillColor = Color.FromArgb(230, 215, 198);
            boton.ForeColor = Color.FromArgb(121, 75, 45);

            boton.BorderColor = Color.FromArgb(121, 75, 45);
            boton.BorderThickness = 1;
            boton.BorderRadius = 10;

            boton.HoverState.FillColor = Color.FromArgb(215, 195, 173);
            boton.HoverState.ForeColor = Color.FromArgb(90, 55, 32);
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(200, 175, 150);

            boton.Cursor = Cursors.Hand;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------SECCION DE BUSCAR UNA VENTA--------------//
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtVentas = null;
                    MostrarVentas();
                    return;
                }

                dtVentas = DbVentas.BuscarVenta(buscar);

                int totalResultados = dtVentas.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPaginaVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //----------------------METODO PARA CARGAR LA TABLA DE VENTAS-------------------------------//
        public void MostrarVentas()
        {
            try
            {
                // Cargar todas las ventas
                dtVentas = DbVentas.CargarVentas();

                // Iniciar desde la primera página
                paginaActual = 1;

                // Calcular cantidad de páginas
                CalcularPaginasVentas();

                // Mostrar la primera página
                MostrarPaginaVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------//
        // CONFIGURAR DISEÑO DE LAS TABLAS
        private void ConfigurarTablasVentas()
        {
            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AllowUserToResizeRows = false;
            dgvVentas.AllowUserToResizeColumns = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.MultiSelect = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentas.GridColor = Color.FromArgb(225, 225, 225);
            dgvVentas.ColumnHeadersHeight = 40;
            dgvVentas.RowTemplate.Height = 36;
            dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVentas.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 75, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 75, 45),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            dgvVentas.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35),
                Padding = new Padding(5)
            };

            dgvVentas.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 246, 240),
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35)
            };

            dgvVentas.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 215, 185);
            dgvVentas.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 45, 35);

            foreach (DataGridViewColumn columna in dgvVentas.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvDetalleDeVenta.AutoGenerateColumns = true;
            dgvDetalleDeVenta.EnableHeadersVisualStyles = false;
            dgvDetalleDeVenta.AllowUserToAddRows = false;
            dgvDetalleDeVenta.AllowUserToDeleteRows = false;
            dgvDetalleDeVenta.AllowUserToResizeRows = false;
            dgvDetalleDeVenta.AllowUserToResizeColumns = false;
            dgvDetalleDeVenta.ReadOnly = true;
            dgvDetalleDeVenta.MultiSelect = false;
            dgvDetalleDeVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleDeVenta.RowHeadersVisible = false;
            dgvDetalleDeVenta.BorderStyle = BorderStyle.None;
            dgvDetalleDeVenta.BackgroundColor = Color.White;
            dgvDetalleDeVenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleDeVenta.GridColor = Color.FromArgb(225, 225, 225);
            dgvDetalleDeVenta.ColumnHeadersHeight = 40;
            dgvDetalleDeVenta.RowTemplate.Height = 36;
            dgvDetalleDeVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDetalleDeVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalleDeVenta.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 75, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 75, 45),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            dgvDetalleDeVenta.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35),
                Padding = new Padding(5)
            };

            dgvDetalleDeVenta.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 246, 240),
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35)
            };

            dgvDetalleDeVenta.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 215, 185);
            dgvDetalleDeVenta.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 45, 35);

            foreach (DataGridViewColumn columna in dgvDetalleDeVenta.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        //-----------------------------------------PAGINACIÓN DE VENTAS--------------------------------------//
        private void MostrarPaginaVentas()
        {
            if (dtVentas == null)
                return;

            DataTable dtPagina = dtVentas.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtVentas.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtVentas.Rows[i]);
            }


            // Mostrar únicamente los registros de la página actual
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = dtPagina;

            // Configurar columna del número de venta
            if (dgvVentas.Columns.Contains("IdVenta"))
            {
                dgvVentas.Columns["IdVenta"].HeaderText = "N° de Venta";
            }

            // Aplicar diseño
            ConfigurarTablasVentas();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void CalcularPaginasVentas()
        {
            if (dtVentas == null || dtVentas.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling((double)dtVentas.Rows.Count / registrosPorPagina);

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                MostrarPaginaVentas();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                MostrarPaginaVentas();
            }
        }
        //-----------------------------------------------------------------
        // CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Tooltips de búsqueda
            toolTip1.SetToolTip(txtBuscar, "Buscar una venta por número, cliente o información relacionada.");

            toolTip1.SetToolTip(txtMostrarCliente, "Muestra el cliente que se registro desde el pedido.");

            // Datos de la venta
            toolTip1.SetToolTip(dtFechaVenta, "Seleccione la fecha en que se realizó la venta.");

            toolTip1.SetToolTip(txtNVenta, "Muestra el número de la venta.");

            toolTip1.SetToolTip(dgvDetalleDeVenta, "Muestra los productos agregados a la venta.");

            // Totales

            toolTip1.SetToolTip(txtSubTotal, "Muestra el IVA correspondiente al subtotal.");

            // Botones de venta
            toolTip1.SetToolTip(btnRegistrarFactura, "Dirige al formulario de facturación, para geerar factura de la venta.");


            toolTip1.SetToolTip(btnEliminar, "Eliminar la venta seleccionada.");

            // Historial de ventas
            toolTip1.SetToolTip(dgvVentas, "Muestra las ventas registradas. Haz doble clic en una venta para editarla.");
        }
        //-------------------------------------------------------------------------------------
        //SELECCION DE UNA VENTA
        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow == null)
                    return;

                if (dgvVentas.CurrentRow.IsNewRow)
                    return;

                if (dgvVentas.CurrentRow.Cells["IdVenta"].Value == null)
                    return;

                // Obtener el ID de la venta seleccionada
                int idVenta = Convert.ToInt32(
                    dgvVentas.CurrentRow.Cells["IdVenta"].Value
                );

                // Cargar información de la venta
                CargarInformacionVentaSeleccionada();

                // Cargar detalle de la venta
                DataTable detalle = DetalleVenta.CargarDetalleVenta(idVenta);

                // Verificar si la venta ya tiene factura
                bool tieneFactura = DbVentas.VentaTieneFactura(idVenta);
                if (tieneFactura)
                {
                    pnlFacturaRegistrada.Visible = false;
                    btnRegistrarFactura.Enabled = false;
                }
                else
                {
                    pnlFacturaRegistrada.Visible = true;
                    btnRegistrarFactura.Enabled = true;
                }

                dgvDetalleDeVenta.DataSource = null;
                dgvDetalleDeVenta.DataSource = detalle;

                // Ocultar columnas que no queremos mostrar
                if (dgvDetalleDeVenta.Columns.Contains("IdDetalleVenta"))
                    dgvDetalleDeVenta.Columns["IdDetalleVenta"].Visible = false;

                if (dgvDetalleDeVenta.Columns.Contains("IdVenta"))
                    dgvDetalleDeVenta.Columns["IdVenta"].Visible = false;

                // Cambiar encabezados
                if (dgvDetalleDeVenta.Columns.Contains("ProductoVendido"))
                {
                    dgvDetalleDeVenta.Columns["ProductoVendido"].HeaderText = "Producto";
                    dgvDetalleDeVenta.Columns["ProductoVendido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvDetalleDeVenta.Columns.Contains("Cantidad"))
                {
                    dgvDetalleDeVenta.Columns["Cantidad"].HeaderText = "Cantidad";
                }

                if (dgvDetalleDeVenta.Columns.Contains("PrecioUnitario"))
                {
                    dgvDetalleDeVenta.Columns["PrecioUnitario"].HeaderText = "Precio unitario";
                }

                if (dgvDetalleDeVenta.Columns.Contains("Subtotal"))
                {
                    dgvDetalleDeVenta.Columns["Subtotal"].HeaderText = "Subtotal";
                }

                ConfigurarTablasVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInformacionVentaSeleccionada()
        {
            try
            {
                if (dgvVentas.CurrentRow == null)
                    return;

                DataGridViewRow fila = dgvVentas.CurrentRow;

                if (fila.IsNewRow)
                    return;

                if (fila.Cells["IdVenta"].Value == null)
                    return;

                int idVenta = Convert.ToInt32(fila.Cells["IdVenta"].Value);

                txtMostrarCliente.Text = fila.Cells["Cliente"].Value?.ToString() ?? "";

                txtSubTotal.Text = fila.Cells["SubTotal"].Value?.ToString() ?? "0.00";

                dtFechaVenta.Value = Convert.ToDateTime(fila.Cells["Fecha de Venta"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información de la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------EVENTO LOAD-----------------------------------------------//

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarTooltips();

                txtMostrarCliente.Enabled = false;

                dtFechaVenta.Enabled = false;

                txtSubTotal.Enabled = false;


                MostrarVentas();

                ConfigurarTablasVentas();

                //Navegacion con TabIndex
                txtNVenta.TabIndex = 1;
                txtMostrarCliente.TabIndex = 2;
                dtFechaVenta.TabIndex = 3;
                txtSubTotal.TabIndex = 4;
                btnRegistrarFactura.TabIndex = 5;
                btnEliminar.TabIndex = 6;

                ConfigurarBarraBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario de ventas:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------BOTON DE ELIMIAR UNA VENTA---------------------------------//
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la tabla.");
                return;
            }

            int id = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);

            DialogResult res = MessageBox.Show("Est seguro de eliminar esta venta? Se eliminarn todos los detalles y facturas asociados de forma permanente.", "Confirmar Eliminacin (Cascada)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Modelo.Entidades.DbVentas venta = new Modelo.Entidades.DbVentas();
                venta.IdVenta1 = id;
                if (venta.EliminarVenta())
                {
                    MessageBox.Show("Venta eliminada correctamente.");
                    MostrarVentas();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //DESACTIVAR COMANDOS DE COPIAR CORTAR Y PEGAR------------------------------------


        private void DesactivarCopiarPegar(Control control)
        {
            foreach (Control elemento in control.Controls)
            {
                if (elemento is TextBox)
                {
                    ((TextBox)elemento).ShortcutsEnabled = false;
                }

                if (elemento.HasChildren)
                {
                    DesactivarCopiarPegar(elemento);
                }
            }
        }



        private void btnRegistrarFactura_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una venta para registrar la factura.", "Venta requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);

                frmFacturacion formularioFactura = new frmFacturacion();

                formularioFactura.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de facturación:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
