using Guna.UI2.WinForms;
using Microsoft.Web.WebView2.WinForms;
using Modelo;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vista.Clientes;
using Vista.Responsive;

namespace Vista.Cotizaciones
{
    public partial class frmCotizaciones : Form
    {
        public frmCotizaciones()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarPaneles();

            visorPDF = new WebView2
            {
                Dock = DockStyle.Fill
            };

            pnlPDFPreview.Controls.Add(visorPDF);

        }
        private Guna2Elipse elipseDatosGenerales;
        private Guna2Elipse elipseDetalleProductos;
        private Guna2Elipse elipseResumenPago;
        private Guna2Elipse elipseVistaPrevia;
        private Guna2Elipse elipsePDFPreview;
        private Guna2Elipse elipseObservaciones;
        private Guna2Elipse elipseRegistrosCotizaciones;

        private void ConfigurarPaneles()
        {
            elipseDatosGenerales = new Guna2Elipse
            {
                TargetControl = pnlDatosGenerales,
                BorderRadius = 10
            };

            elipseDetalleProductos = new Guna2Elipse
            {
                TargetControl = pnlDatalledeProductos,
                BorderRadius = 10
            };

            elipseResumenPago = new Guna2Elipse
            {
                TargetControl = pnlResumenDePago,
                BorderRadius = 10
            };

            elipseVistaPrevia = new Guna2Elipse
            {
                TargetControl = pnlVistaPrevia,
                BorderRadius = 10
            };

            elipsePDFPreview = new Guna2Elipse
            {
                TargetControl = pnlPDFPreview,
                BorderRadius = 8
            };

            elipseObservaciones = new Guna2Elipse
            {
                TargetControl = pnlObeservaciones,
                BorderRadius = 10
            };

            elipseRegistrosCotizaciones = new Guna2Elipse
            {
                TargetControl = pnlRegistrosCotizaciones,
                BorderRadius = 10
            };
        }































        // VARIABLES PARA LA PAGINACIÓN
        private DataTable dtCotizaciones;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private int totalPaginas = 0;
        //-----------------------------------
        private int idClienteSeleccionado = 0;
        private int idCotizacionGuardada = 0;
        private decimal subtotal = 0;
        private decimal iva = 0;
        private decimal total = 0;
        private WebView2 visorPDF;
        private string rutaPDFPreview;

        private void btnCotizacionDetalle_Click(object sender, EventArgs e)
        {
            pnlNuevaCotizacion.Visible = true;
            pnlRegistrosCotizaciones.Visible = false;
            pnlBarraCambio.Visible = true;
            pnlBarraCambioRegistros.Visible = false;
        }

        private void btnCotizacionesRegistradas_Click(object sender, EventArgs e)
        {
            pnlRegistrosCotizaciones.Visible = true;
            pnlNuevaCotizacion.Visible = false;
            pnlBarraCambio.Visible = false;
            pnlBarraCambioRegistros.Visible = true;
        }

        private void MostrarCotizacionesRegistradas()
        {
            try
            {
                // Cargar todas las cotizaciones
                dtCotizaciones = DbCotizacion.CargarCotizacion();

                // Volver a la primera página
                paginaActual = 1;

                // Calcular el total de páginas
                CalcularPaginasCotizaciones();

                // Mostrar la primera página
                MostrarPaginaCotizaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ConfigurarTablasCotizaciones()
        {
            // TABLA DE COTIZACIONES REGISTRADAS
            dgvCotizacionesRegistradas.EnableHeadersVisualStyles = false;

            // Encabezado
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvCotizacionesRegistradas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvCotizacionesRegistradas.DefaultCellStyle.BackColor = Color.White;
            dgvCotizacionesRegistradas.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvCotizacionesRegistradas.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvCotizacionesRegistradas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvCotizacionesRegistradas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvCotizacionesRegistradas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvCotizacionesRegistradas.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvCotizacionesRegistradas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCotizacionesRegistradas.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvCotizacionesRegistradas.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvCotizacionesRegistradas.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvCotizacionesRegistradas.ReadOnly = true;
            dgvCotizacionesRegistradas.AllowUserToAddRows = false;
            dgvCotizacionesRegistradas.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvCotizacionesRegistradas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCotizacionesRegistradas.MultiSelect = false;

            // Quitar borde exterior
            dgvCotizacionesRegistradas.BorderStyle = BorderStyle.None;

            // Ocultar el cuadrito de la izquierda
            dgvCotizacionesRegistradas.RowHeadersVisible = false;


            // TABLA DE DETALLE DE COTIZACIÓN
            dgvDetalleDeCotizacion.EnableHeadersVisualStyles = false;

            // Encabezado
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvDetalleDeCotizacion.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvDetalleDeCotizacion.DefaultCellStyle.BackColor = Color.White;
            dgvDetalleDeCotizacion.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvDetalleDeCotizacion.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvDetalleDeCotizacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvDetalleDeCotizacion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvDetalleDeCotizacion.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvDetalleDeCotizacion.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvDetalleDeCotizacion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleDeCotizacion.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvDetalleDeCotizacion.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvDetalleDeCotizacion.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvDetalleDeCotizacion.ReadOnly = true;
            dgvDetalleDeCotizacion.AllowUserToAddRows = false;
            dgvDetalleDeCotizacion.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvDetalleDeCotizacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleDeCotizacion.MultiSelect = false;

            // Quitar borde exterior
            dgvDetalleDeCotizacion.BorderStyle = BorderStyle.None;

            // Ocultar el cuadrito de la izquierda
            dgvDetalleDeCotizacion.RowHeadersVisible = false;
        }
        private void CalcularPaginasCotizaciones()
        {
            if (dtCotizaciones == null || dtCotizaciones.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling(
                (double)dtCotizaciones.Rows.Count / registrosPorPagina
            );

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }
        private void MostrarPaginaCotizaciones()
        {
            if (dtCotizaciones == null)
                return;

            DataTable dtPagina = dtCotizaciones.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(
                inicio + registrosPorPagina,
                dtCotizaciones.Rows.Count
            );

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtCotizaciones.Rows[i]);
            }

            // Mostrar únicamente los registros de la página actual
            dgvCotizacionesRegistradas.DataSource = null;
            dgvCotizacionesRegistradas.DataSource = dtPagina;

            // Configurar encabezados
            if (dgvCotizacionesRegistradas.Columns.Contains("IdCotizacion"))
            {
                dgvCotizacionesRegistradas.Columns["IdCotizacion"].HeaderText = "#";
            }

            // Aplicar diseño de la tabla
            ConfigurarTablasCotizaciones();

            // Mostrar página actual
            lblPagina.Text =
                $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        //CONFIGURACION DE TOOLTIPS
        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;
            // Navegación de cotizaciones
            toolTip1.SetToolTip(btnCotizacionDetalle, "Muestra el formulario para crear una nueva cotización.");
            toolTip1.SetToolTip(btnCotizacionesRegistradas, "Muestra las cotizaciones registradas.");

            // Datos del cliente
            toolTip1.SetToolTip(btnBuscarCliente, "Busca y selecciona un cliente para la cotización.");
            toolTip1.SetToolTip(txtCliente, "Muestra el nombre del cliente seleccionado.");
            toolTip1.SetToolTip(txtTelefono, "Muestra el número de teléfono del cliente seleccionado.");
            toolTip1.SetToolTip(txtCorreo, "Muestra el correo electrónico del cliente seleccionado.");
            toolTip1.SetToolTip(txtDireccion, "Muestra la dirección del cliente seleccionado.");

            // Datos de la cotización
            toolTip1.SetToolTip(dtpFechaCotizacion, "Muestra la fecha de la cotización.");
            toolTip1.SetToolTip(cbEstado, "Muestra el estado actual de la cotización.");
            toolTip1.SetToolTip(txtCondicionesPago, "Ingrese las condiciones de pago de la cotización.");
            toolTip1.SetToolTip(txtCondicionesEntrega, "Ingrese las condiciones de entrega de la cotización.");

            // Productos
            toolTip1.SetToolTip(txtProductosCotizacion, "Ingrese la descripción del producto que desea agregar.");
            toolTip1.SetToolTip(txtLargo, "Ingrese el largo del producto en centímetros.");
            toolTip1.SetToolTip(txtAncho, "Ingrese el ancho del producto en centímetros.");
            toolTip1.SetToolTip(txtAlto, "Ingrese el alto del producto en centímetros.");
            toolTip1.SetToolTip(nudCantidad, "Indique la cantidad de unidades del producto.");
            toolTip1.SetToolTip(txtPrecioUnitario, "Ingrese el precio de una unidad del producto.");
            toolTip1.SetToolTip(btnAgregar, "Agrega el producto a la cotización.");

            // Totales
            toolTip1.SetToolTip(txtSubTotal, "Muestra el subtotal de los productos de la cotización.");
            toolTip1.SetToolTip(txtIVA, "Muestra el IVA correspondiente a la cotización.");
            toolTip1.SetToolTip(txtTotal, "Muestra el total de la cotización.");

            // Acciones de la cotización
            toolTip1.SetToolTip(btnGuardar, "Guarda la cotización y los productos agregados.");
            toolTip1.SetToolTip(btnGenerarPDF, "Genera y abre el PDF de la cotización guardada.");

            // Búsqueda de cotizaciones
            toolTip1.SetToolTip(txtBuscar, "Busca una cotización por su código.");

            // Cotizaciones registradas
            toolTip1.SetToolTip(btnEditar, "Permite cambiar el estado de la cotización seleccionada.");
            toolTip1.SetToolTip(btnEliminar, "Elimina la cotización seleccionada.");
            toolTip1.SetToolTip(button1, "Convierte la cotización aprobada seleccionada en un pedido.");

            // Vista previa
            toolTip1.SetToolTip(pnlPDFPreview, "Muestra una vista previa del PDF de la cotización.");
            toolTip1.SetToolTip(btnLimpiar, "Limpia los campos del formulario para ingresar una nueva cotización.");
            toolTip1.SetToolTip(button2, "Limpia los filtros de búsqueda y muestra nuevamente todas las cotizaciones registradas.");
        }

        private async void frmCotizaciones_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Aprobada");
            cbEstado.Items.Add("Rechazada");

            MostrarCotizacionesRegistradas();
            ConfigurarDetalleCotizacion();

            //CONFIGURACION DE TOOLTIPS
            ConfigurarTooltips();

            // CONFIGURACIÓN DE LAS TABLAS
            ConfigurarTablasCotizaciones();

            // Datos del cliente solamente lectura
            txtCliente.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            cbEstado.Enabled = false;

            // Valores iniciales
            dtpFechaCotizacion.Value = DateTime.Now;

            //Tabla de productos de cotizacion vacia

            dgvDetalleDeCotizacion.DataSource = null;
            nudCantidad.Value = 1;
            txtSubTotal.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";

            // Estado inicial
            cbEstado.SelectedIndex = 0;
            //Fecha de cotizacion actual
            dtpFechaCotizacion.Value = DateTime.Today;
            dtpFechaCotizacion.Enabled = false;
            //Metodo para validar que no se copie texto, ni tampoco se pegue texto
            DesactivarCopiarPegar(this);

            dgvCotizacionesRegistradas.Columns["IdCotizacion"].HeaderText = "#";

            try
            {
                await visorPDF.EnsureCoreWebView2Async();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo inicializar la vista previa.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarVistaPrevia()
        {
            try
            {
                if (visorPDF == null || visorPDF.CoreWebView2 == null)
                    return;

                // Verificar que haya productos
                bool hayProductos = dgvDetalleDeCotizacion.Rows
                    .Cast<DataGridViewRow>()
                    .Any(row =>
                        !row.IsNewRow &&
                        row.Cells["DescripcionMueble"].Value != null &&
                        !string.IsNullOrWhiteSpace(
                            row.Cells["DescripcionMueble"].Value.ToString()));

                if (!hayProductos)
                    return;

                // Calcular totales
                CalcularTotalCotizacion();

                // Lista de productos
                List<ProductoPDF> productos = new List<ProductoPDF>();

                foreach (DataGridViewRow row in dgvDetalleDeCotizacion.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row.Cells["DescripcionMueble"].Value == null)
                        continue;

                    string descripcion = row.Cells["DescripcionMueble"].Value.ToString();

                    if (string.IsNullOrWhiteSpace(descripcion))
                        continue;

                    ProductoPDF producto = new ProductoPDF
                    {
                        Descripcion = descripcion,
                        Largo = Convert.ToInt32(row.Cells["Largo"].Value),
                        Ancho = Convert.ToInt32(row.Cells["Ancho"].Value),
                        Alto = Convert.ToInt32(row.Cells["Alto"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                        SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                    };

                    productos.Add(producto);
                }

                // Crear archivo temporal
                rutaPDFPreview = Path.Combine(Path.GetTempPath(), "CotizacionPreview.pdf");

                // Generar PDF
                CotizacionDocumentoPDF.Generar(rutaPDFPreview, idCotizacionGuardada, dtpFechaCotizacion.Value, txtCliente.Text.Trim(), txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(), txtDireccion.Text.Trim(), txtCondicionesPago.Text.Trim(), txtCondicionesEntrega.Text.Trim(), cbEstado.Text.Trim(), subtotal,
                    iva, total, productos);

                // Mostrar el PDF dentro del formulario
                if (File.Exists(rutaPDFPreview))
                {
                    visorPDF.CoreWebView2.Navigate(new Uri(rutaPDFPreview).AbsoluteUri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la vista previa.\n\n" + ex.ToString(), "Vista previa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            using (frmBuscarCliente modal = new frmBuscarCliente())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    idClienteSeleccionado = modal.IdClienteSeleccionado;

                    txtCliente.Text = modal.NombreClienteSeleccionado;
                    txtTelefono.Text = modal.TelefonoClienteSeleccionado;
                    txtCorreo.Text = modal.CorreoClienteSeleccionado;
                    txtDireccion.Text = modal.DireccionClienteSeleccionado;
                }
            }

            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente.");
                return;
            }
        }

        private void CalcularTotalCotizacion()
        {
            subtotal = 0;

            foreach (DataGridViewRow fila in dgvDetalleDeCotizacion.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                subtotal += Convert.ToDecimal(fila.Cells["SubTotal"].Value);
            }

            iva = subtotal * 0.13m;

            total = subtotal + iva;

            txtSubTotal.Text = subtotal.ToString("0.00");
            txtIVA.Text = iva.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        private void LimpiarFormulario()
        {
            idClienteSeleccionado = 0;

            txtCliente.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            txtCondicionesPago.Clear();
            txtCondicionesEntrega.Clear();

            dtpFechaCotizacion.Value = DateTime.Now;

            cbEstado.SelectedIndex = 0;

            subtotal = 0;
            iva = 0;
            total = 0;

            txtSubTotal.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            // Validar cliente
            if (idClienteSeleccionado == 0)
            {
                errorProvider1.SetError(btnBuscarCliente, "Selecciona un cliente.");
                btnBuscarCliente.Focus();
                return;
            }

            // Validar condiciones de pago
            if (string.IsNullOrWhiteSpace(txtCondicionesPago.Text))
            {
                errorProvider1.SetError(txtCondicionesPago, "Ingresa las condiciones de pago.");
                txtCondicionesPago.Focus();
                return;
            }

            // Validar condiciones de entrega
            if (string.IsNullOrWhiteSpace(txtCondicionesEntrega.Text))
            {
                errorProvider1.SetError(txtCondicionesEntrega, "Ingresa las condiciones de entrega.");
                txtCondicionesEntrega.Focus();
                return;
            }


            CalcularTotalCotizacion();
            // Validar total
            if (total <= 0)
            {
                errorProvider1.SetError(txtTotal, "El total de la cotización debe ser mayor que 0.");
                txtTotal.Focus();
                return;
            }

            // Validar estado
            if (cbEstado.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbEstado, "Selecciona el estado de la cotización.");
                cbEstado.Focus();
                return;
            }
            cbEstado.Enabled = false;
            string estadoSeleccionado = Convert.ToString(cbEstado.Text);

            DbCotizacion cotizacion = new DbCotizacion(0, dtpFechaCotizacion.Value, idClienteSeleccionado, txtCondicionesPago.Text.Trim(), txtCondicionesEntrega.Text.Trim(), total, estadoSeleccionado);

            int idCotizacion = cotizacion.InsertarCotizacion();

            if (idCotizacion == 0)
            {
                MessageBox.Show("No se pudo registrar la cotizaci?n.");
                return;
            }
            idCotizacionGuardada = idCotizacion;
            // Guardar detalles
            foreach (DataGridViewRow row in dgvDetalleDeCotizacion.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["DescripcionMueble"].Value == null) continue;

                ProductosCotizacion prod = new ProductosCotizacion();
                prod.Idcotizacion1 = idCotizacion;
                prod.Descripcion_Del_Mueble1 = row.Cells["DescripcionMueble"].Value.ToString();
                prod.Largo1 = Convert.ToInt32(row.Cells["Largo"].Value);
                prod.Ancho1 = Convert.ToInt32(row.Cells["Ancho"].Value);
                prod.Alto1 = Convert.ToInt32(row.Cells["Alto"].Value);
                prod.Cantidad1 = Convert.ToInt32(row.Cells["Cantidad"].Value);
                prod.PrecioUnitario1 = Convert.ToDouble(row.Cells["PrecioUnitario"].Value);
                prod.SubTotal1 = Convert.ToDouble(row.Cells["SubTotal"].Value);

                prod.InsertarProductoCotizacion();
            }

            MessageBox.Show("Cotización y productos registrados correctamente.\n\n" + "Número de cotización: " + idCotizacion, "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MostrarCotizacionesRegistradas();


        }


        private void ConfigurarDetalleCotizacion()
        {
            dgvDetalleDeCotizacion.Columns.Clear();

            dgvDetalleDeCotizacion.Columns.Add("DescripcionMueble", "Producto");

            dgvDetalleDeCotizacion.Columns.Add("Largo", "Largo");

            dgvDetalleDeCotizacion.Columns.Add("Ancho", "Ancho");

            dgvDetalleDeCotizacion.Columns.Add("Alto", "Alto");

            dgvDetalleDeCotizacion.Columns.Add("Cantidad", "Cantidad");

            dgvDetalleDeCotizacion.Columns.Add("PrecioUnitario", "Precio Unitario");

            dgvDetalleDeCotizacion.Columns.Add("SubTotal", "Subtotal");

            dgvDetalleDeCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarProducto()
        {
            txtProductosCotizacion.Clear();

            txtLargo.Clear();
            txtAncho.Clear();
            txtAlto.Clear();

            nudCantidad.Value = 1;

            txtPrecioUnitario.Clear();

            txtProductosCotizacion.Focus();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Validar producto
            if (string.IsNullOrWhiteSpace(txtProductosCotizacion.Text))
            {
                errorProvider1.SetError(txtProductosCotizacion, "Ingresa el producto.");
                txtProductosCotizacion.Focus();
                return;
            }

            // Validar cantidad
            int cantidad = Convert.ToInt32(nudCantidad.Value);

            if (cantidad <= 0)
            {
                errorProvider1.SetError(nudCantidad, "La cantidad debe ser mayor que 0.");
                nudCantidad.Focus();
                return;
            }

            // Validar largo
            // Out significa que si se puede convertir el texto lo guardará en una variable,
            // ya que por TextBox se reciben string.
            if (!int.TryParse(txtLargo.Text, out int largo) || largo <= 0)
            {
                errorProvider1.SetError(txtLargo, "Ingresa un largo válido.");
                txtLargo.Focus();
                return;
            }

            // Validar ancho
            if (!int.TryParse(txtAncho.Text, out int ancho) || ancho <= 0)
            {
                errorProvider1.SetError(txtAncho, "Ingresa un ancho válido.");
                txtAncho.Focus();
                return;
            }

            // Validar alto
            if (!int.TryParse(txtAlto.Text, out int alto) || alto <= 0)
            {
                errorProvider1.SetError(txtAlto, "Ingresa un alto válido.");
                txtAlto.Focus();
                return;
            }

            // Validar precio
            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                errorProvider1.SetError(txtPrecioUnitario, "Ingresa un precio válido.");
                txtPrecioUnitario.Focus();
                return;
            }

            // Validar que el precio no sea 0
            if (precio <= 0)
            {
                errorProvider1.SetError(txtPrecioUnitario, "El precio debe ser mayor que 0.");
                txtPrecioUnitario.Focus();
                return;
            }
            decimal subtotal = cantidad * precio;

            dgvDetalleDeCotizacion.Rows.Add(txtProductosCotizacion.Text.Trim(), largo, ancho, alto, cantidad, precio.ToString("0.00"), subtotal.ToString("0.00"));

            CalcularTotalCotizacion();

            // Actualizar vista previa
            ActualizarVistaPrevia();

            LimpiarProducto();
        }
        private void dgvDetalleDeCotizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || ((DataGridView)sender).Rows[e.RowIndex].IsNewRow)
                return;

            int idCotizacion = Convert.ToInt32(dgvDetalleDeCotizacion.Rows[e.RowIndex].Cells["IdCotizacion"].Value);

            dgvDetalleDeCotizacion.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCotizacionesRegistradas.CurrentRow != null)
            {
                int idCotizacion = Convert.ToInt32(dgvCotizacionesRegistradas.CurrentRow.Cells["IdCotizacion"].Value);
                string estado = dgvCotizacionesRegistradas.CurrentRow.Cells["Estado"].Value?.ToString();

                if (estado != "Aprobada")
                {
                    MessageBox.Show("Solo las cotizaciones Aprobadas pueden convertirse en Pedidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaEntrega = DateTime.Now.AddDays(15);
                bool exito = DbPedidos.ConvertirCotizacionAPedido(idCotizacion, fechaEntrega);
                if (exito)
                {
                    MessageBox.Show("¡La cotización se ha convertido en Pedido exitosamente!\nFecha estimada de entrega: " + fechaEntrega.ToShortDateString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una cotización de la tabla primero.");
            }
        }

        private void dgvCotizacionesRegistradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCotizacionesRegistradas.Rows[e.RowIndex].IsNewRow) return;
            DataGridViewRow row = dgvCotizacionesRegistradas.Rows[e.RowIndex];
            lblNumeroSelec.Text = row.Cells["IdCotizacion"].Value?.ToString();
            lblClienteSelec.Text = row.Cells["Cliente"].Value?.ToString();
            lblEtsado.Text = row.Cells["Estado"].Value?.ToString();
            lblMostrarTotal.Text = "$" + row.Cells["Total"].Value?.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCotizacionesRegistradas.CurrentRow != null)
            {
                int idCotizacion = Convert.ToInt32(dgvCotizacionesRegistradas.CurrentRow.Cells["IdCotizacion"].Value);
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro de que deseas eliminar la cotización #" + idCotizacion + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DbCotizacion cotizacion = new DbCotizacion();
                    cotizacion.IdCotizacion1 = idCotizacion;
                    if (cotizacion.EliminarCotizacion())
                    {
                        MessageBox.Show("Cotización eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCotizacionesRegistradas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una cotización de la tabla para eliminar.");
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            cbEstado.Enabled = false;
            if (dgvCotizacionesRegistradas.CurrentRow != null)
            {
                int idCotizacion = Convert.ToInt32(dgvCotizacionesRegistradas.CurrentRow.Cells["IdCotizacion"].Value);
                string estadoActual = dgvCotizacionesRegistradas.CurrentRow.Cells["Estado"].Value?.ToString();

                DialogResult result = MessageBox.Show("¿Deseas cambiar el estado de la cotización? #" + idCotizacion + "?\n\nPresiona SI para marcarla como 'Aprobada'.\nPresiona NO para marcarla como 'Rechazada'.\nPresiona CANCELAR para no hacer nada.", "Cambiar Estado",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                string nuevoEstado = "";
                if (result == DialogResult.Yes) nuevoEstado = "Aprobada";
                else if (result == DialogResult.No) nuevoEstado = "Rechazada";
                else return;

                DbCotizacion cot = new DbCotizacion();
                cot.IdCotizacion1 = idCotizacion;

                if (cot.ActualizarEstado(nuevoEstado))
                {
                    MessageBox.Show("El estado se actualizó exitosamente a: " + nuevoEstado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCotizacionesRegistradas();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona una cotización primero.");
            }
        }
        //Metodo para validar que no se pueda ni copiar ni pegar en los formularios
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "Buscar por código de cotización...")
                {
                    return;
                }

                string buscar = txtBuscar.Text.Trim();

                // Si la búsqueda está vacía,
                // mostrar nuevamente todas las cotizaciones
                if (string.IsNullOrWhiteSpace(buscar))
                {
                    MostrarCotizacionesRegistradas();
                    return;
                }

                // Buscar las cotizaciones
                dtCotizaciones = DbCotizacion.BuscarCotizacion(buscar);

                // Volver a la primera página
                paginaActual = 1;

                // Calcular páginas
                CalcularPaginasCotizaciones();

                // Mostrar resultados paginados
                MostrarPaginaCotizaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscar.Text == "Buscar por código de cotización...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar por código de cotización...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que la cotización haya sido guardada
                if (idCotizacionGuardada <= 0)
                {
                    MessageBox.Show("Primero debes guardar la cotización.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Verificar que existan productos
                List<ProductoPDF> productos = new List<ProductoPDF>();

                foreach (DataGridViewRow row in dgvDetalleDeCotizacion.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row.Cells["DescripcionMueble"].Value == null)
                        continue;

                    string descripcion =
                        row.Cells["DescripcionMueble"].Value.ToString();

                    if (string.IsNullOrWhiteSpace(descripcion))
                        continue;

                    ProductoPDF producto = new ProductoPDF
                    {
                        Descripcion = descripcion,

                        Largo = Convert.ToInt32(row.Cells["Largo"].Value),

                        Ancho = Convert.ToInt32(row.Cells["Ancho"].Value),

                        Alto = Convert.ToInt32(row.Cells["Alto"].Value),

                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),

                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),

                        SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                    };

                    productos.Add(producto);
                }

                if (productos.Count == 0)
                {
                    MessageBox.Show("Debes agregar al menos un producto.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Recalcular totales
                CalcularTotalCotizacion();

                // Crear carpeta de Cotizaciones
                string carpeta = Path.Combine(Application.StartupPath, "Cotizaciones");

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                Directory.CreateDirectory(carpeta);

                // Ruta del PDF
                string rutaPDF = Path.Combine(carpeta, $"Cotizacion_{idCotizacionGuardada}.pdf");
                // Mostrar la ruta real que se está utilizando
                MessageBox.Show("La ruta del PDF será:\n\n" + rutaPDF + "\n\nCarpeta:\n" + carpeta, "Ruta del PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Generar PDF
                CotizacionDocumentoPDF.Generar(rutaPDF, idCotizacionGuardada, dtpFechaCotizacion.Value, txtCliente.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(), txtCondicionesPago.Text.Trim(), txtCondicionesEntrega.Text.Trim(), cbEstado.Text.Trim(), subtotal, iva, total,
                    productos);

                // Verificar que se haya creado
                if (!File.Exists(rutaPDF))
                {
                    MessageBox.Show("No se pudo crear el archivo PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Abrir PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });

                MessageBox.Show("PDF generado correctamente.\n\n" + "Guardado en:\n" + rutaPDF, "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el PDF.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPaginaCotizaciones();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPaginaCotizaciones();
            }
        }

        private void dgvCotizacionesRegistradas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCotizacionesRegistradas.CurrentRow == null)
                    return;

                if (dgvCotizacionesRegistradas.CurrentRow.IsNewRow)
                    return;

                if (dgvCotizacionesRegistradas.CurrentRow.Cells["IdCotizacion"].Value == null)
                    return;

                DataGridViewRow fila = dgvCotizacionesRegistradas.CurrentRow;

                lblNumeroSelec.Text = fila.Cells["IdCotizacion"].Value?.ToString() ?? "";

                lblClienteSelec.Text = fila.Cells["Cliente"].Value?.ToString() ?? "";

                lblEstado.Text = fila.Cells["Estado"].Value?.ToString() ?? "";

                lblMostrarTotal.Text = "$" + Convert.ToDecimal(fila.Cells["Total"].Value).ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cotización seleccionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solamente un punto decimal
            if (e.KeyChar == '.' && txtPrecioUnitario.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}



