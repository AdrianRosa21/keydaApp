using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vista.Responsive;
using Color = System.Drawing.Color;

namespace Vista.Facturación
{
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {

            InitializeComponent();
            ResponsiveHelper.Apply(this);

            ConfigurarPaneles();
            ConfigurarBotonesFactura();
        }

        private Guna2Elipse elipseDatosVenta;
        private Guna2Elipse elipseDatosCliente;
        private Guna2Elipse elipseDatosFactura;
        private Guna2Elipse elipseDetalleProductos;
        private Guna2Elipse elipseResumenPago;
        private Guna2Elipse elipseObservaciones;

        private void ConfigurarPaneles()
        {
            elipseDatosVenta = new Guna2Elipse
            {
                TargetControl = panel3,
                BorderRadius = 10
            };

            elipseDatosCliente = new Guna2Elipse
            {
                TargetControl = pnlDatosVenta,
                BorderRadius = 10
            };

            elipseDatosFactura = new Guna2Elipse
            {
                TargetControl = pnlDatosGeneralesFactura,
                BorderRadius = 10
            };

            elipseDetalleProductos = new Guna2Elipse
            {
                TargetControl = pnlDatalledeProductos,
                BorderRadius = 10
            };

            elipseResumenPago = new Guna2Elipse
            {
                TargetControl = pnlResumenDePagoFactura,
                BorderRadius = 10
            };

            elipseObservaciones = new Guna2Elipse
            {
                TargetControl = panel4,
                BorderRadius = 10
            };
        }

        private void ConfigurarBotonesFactura()
        {
            ConfigurarBotonFactura(btnGuardarFactura, Color.FromArgb(121, 75, 45));

            ConfigurarBotonFactura(btnGenerarPDF, Color.FromArgb(112, 153, 82));

            ConfigurarBotonFactura(btnLimpiarFactura, Color.FromArgb(174, 91, 75));
        }

        private void ConfigurarBotonFactura(Guna.UI2.WinForms.Guna2Button boton, Color color)
        {
            boton.FillColor = color;
            boton.ForeColor = Color.White;

            boton.BorderColor = Color.FromArgb(121, 75, 45);
            boton.BorderThickness = 1;
            boton.BorderRadius = 8;

            boton.HoverState.FillColor = Color.FromArgb(
                Math.Min(color.R + 20, 255),
                Math.Min(color.G + 20, 255),
                Math.Min(color.B + 20, 255)
            );

            boton.HoverState.ForeColor = Color.White;
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(
                Math.Max(color.R - 25, 0),
                Math.Max(color.G - 25, 0),
                Math.Max(color.B - 25, 0)
            );

            boton.Cursor = Cursors.Hand;
        }


























        // VARIABLES PARA LA PAGINACIÓN
        private DataTable dtFacturas;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private int totalPaginas = 0;

        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Navegación de facturación
            toolTip1.SetToolTip(btnNuevaFactura, "Muestra el formulario para crear una nueva factura.");

            toolTip1.SetToolTip(btnRegistrosfacturas, "Muestra las facturas registradas.");

            // Datos de la venta
            toolTip1.SetToolTip(txtnVenta, "Ingrese el número de la venta que desea facturar.");

            toolTip1.SetToolTip(btnBuscarVenta, "Busca la venta ingresada para utilizar sus datos en la factura.");

            // Datos del cliente
            toolTip1.SetToolTip(txtMostrarCliente, "Muestra el nombre del cliente asociado a la venta.");

            toolTip1.SetToolTip(txtDui, "Muestra el documento de identidad del cliente.");

            toolTip1.SetToolTip(txtTelefono, "Muestra el número de teléfono del cliente.");

            toolTip1.SetToolTip(txtCorreo, "Muestra el correo electrónico del cliente.");

            // Datos de la factura
            toolTip1.SetToolTip(txtNumeroFactura, "Muestra el número de la factura. Se asigna al guardar la factura.");

            toolTip1.SetToolTip(dtFechaDatosGeneralesFactura, "Muestra la fecha de emisión de la factura.");

            toolTip1.SetToolTip(dtpFechaVencimiento, "Seleccione la fecha de vencimiento de la factura.");

            // Detalle de la venta
            toolTip1.SetToolTip(dgvDetalleVenta, "Muestra los productos incluidos en la venta seleccionada.");

            toolTip1.SetToolTip(lblTotalDeProductos, "Muestra la cantidad total de productos incluidos en la venta.");

            // Resumen de la factura
            toolTip1.SetToolTip(txtSubTotal, "Muestra el subtotal de la venta.");

            toolTip1.SetToolTip(txtDescuento, "Ingrese el descuento que desea aplicar a la factura.");

            toolTip1.SetToolTip(txtIVA, "Muestra el IVA correspondiente después de aplicar el descuento.");

            toolTip1.SetToolTip(txtTotal, "Muestra el total a pagar de la factura.");

            toolTip1.SetToolTip(lblTotalAPagar, "Muestra el total final que debe pagar el cliente.");

            // Observaciones
            toolTip1.SetToolTip(txtObservaciones, "Ingrese observaciones adicionales relacionadas con la factura.");

            // Botones de factura
            toolTip1.SetToolTip(btnGuardarFactura, "Guarda la factura con los datos ingresados.");

            toolTip1.SetToolTip(btnGenerarPDF, "Genera la factura en formato PDF.");

            toolTip1.SetToolTip(btnLimpiarFactura, "Limpia los datos de la factura actual.");

            // Búsqueda de facturas
            toolTip1.SetToolTip(txtBuscar, "Busca una factura por su número.");

            toolTip1.SetToolTip(btnLimpiar, "Limpia el buscador y muestra nuevamente todas las facturas.");

            // Registro de facturas
            toolTip1.SetToolTip(dgvFacturasRegistradas, "Muestra las facturas registradas. Haz doble clic en una factura para editarla.");
        }
        //------------------------------------------------------------------------------------------------------
        //---------------------- CONFIGURAR TABLAS DE FACTURACIÓN ----------------------------------------------//
        private void ConfigurarTablasFacturacion()
        {
            // =========================
            // TABLA DE FACTURAS
            // =========================

            // Encabezado
            dgvFacturasRegistradas.EnableHeadersVisualStyles = false;

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Regular);

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

            dgvFacturasRegistradas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvFacturasRegistradas.DefaultCellStyle.BackColor = Color.White;
            dgvFacturasRegistradas.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvFacturasRegistradas.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
            dgvFacturasRegistradas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Filas alternadas
            dgvFacturasRegistradas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvFacturasRegistradas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);

            dgvFacturasRegistradas.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvFacturasRegistradas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvFacturasRegistradas.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvFacturasRegistradas.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvFacturasRegistradas.ColumnHeadersHeight = 40;

            // No permitir modificar
            dgvFacturasRegistradas.ReadOnly = true;

            dgvFacturasRegistradas.AllowUserToAddRows = false;

            dgvFacturasRegistradas.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvFacturasRegistradas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvFacturasRegistradas.MultiSelect = false;

            // Quitar borde exterior
            dgvFacturasRegistradas.BorderStyle =
                BorderStyle.None;

            // Quitar columna de selección de filas
            dgvFacturasRegistradas.RowHeadersVisible = false;


            // TABLA DETALLE DE VENTA

            // Encabezado
            dgvDetalleVenta.EnableHeadersVisualStyles = false;

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Regular);

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

            dgvDetalleVenta.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvDetalleVenta.DefaultCellStyle.BackColor = Color.White;

            dgvDetalleVenta.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);

            dgvDetalleVenta.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);

            dgvDetalleVenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvDetalleVenta.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvDetalleVenta.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);

            dgvDetalleVenta.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvDetalleVenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDetalleVenta.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvDetalleVenta.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvDetalleVenta.ColumnHeadersHeight = 40;

            // No permitir modificar
            dgvDetalleVenta.ReadOnly = true;

            dgvDetalleVenta.AllowUserToAddRows = false;

            dgvDetalleVenta.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDetalleVenta.MultiSelect = false;

            // Quitar borde exterior
            dgvDetalleVenta.BorderStyle = BorderStyle.None;

            // Quitar columna de selección de filas
            dgvDetalleVenta.RowHeadersVisible = false;
        }
        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            MostrarRegistrosFacturas();

            MostrarDetalleFactura();

            // CONFIGURACION DE LAS TABLAS
            ConfigurarTablasFacturacion();

            //BLOQUEA LOS CONTROLES DE CORTAR COPIAR Y PEGAR
            DesactivarCopiarPegar(this);

            ConfigurarTooltips();

            //Validamos que las fechas ingresadas esten acorde a la lógica del negocio
            dtFechaDatosGeneralesFactura.Value = DateTime.Today;
            dtFechaDatosGeneralesFactura.Enabled = false;
            dtFechaDatosGeneralesFactura.MinDate = DateTime.Today;
            dtFechaDatosGeneralesFactura.MaxDate = DateTime.Today;
            dtpFechaVencimiento.MinDate = DateTime.Today;

            //El numero de factura inicial estara pendiente, hasta que esta factura se guarde

            txtNumeroFactura.Text = "Pendiente";

            dgvFacturasRegistradas.Columns["IdFactura"].HeaderText = "N° de Factura";
            dgvFacturasRegistradas.Columns["Fecha"].HeaderText = "Fecha de emisión";
        }
        private void MostrarRegistrosFacturas()
        {
            try
            {
                // Cargar todas las facturas
                dtFacturas = DbFactura.CargarRegistrosFacturas();

                // Iniciar desde la primera página
                paginaActual = 1;

                // Calcular cantidad de páginas
                CalcularPaginasFacturas();

                // Mostrar la primera página
                MostrarPaginaFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcularPaginasFacturas()
        {
            if (dtFacturas == null || dtFacturas.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling((double)dtFacturas.Rows.Count / registrosPorPagina);

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }

        private void MostrarPaginaFacturas()
        {
            if (dtFacturas == null)
                return;

            DataTable dtPagina = dtFacturas.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtFacturas.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtFacturas.Rows[i]);
            }

            // Mostrar únicamente los registros de la página actual
            dgvFacturasRegistradas.DataSource = null;
            dgvFacturasRegistradas.DataSource = dtPagina;

            // Configurar encabezados
            dgvFacturasRegistradas.Columns["IdFactura"].HeaderText = "N° de Factura";
            dgvFacturasRegistradas.Columns["Fecha"].HeaderText = "Fecha de emisión";

            // CONFIGURAR DISEÑO DE LA TABLA
            ConfigurarTablasFacturacion();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void MostrarDetalleFactura()
        {
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = DbFactura.BuscarVentaParaFactura(0);
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            pnlNuevaFactura.Visible = true;
            pnlBarraCambioRegistros.Visible = false;
            pnlContenedorDeCotizacionNueva.Visible = true;
            pnlRegistroCotizacion.Visible = false;
        }

        private void btnRegistrosfacturas_Click(object sender, EventArgs e)
        {
            pnlNuevaFactura.Visible = false;
            pnlBarraCambioRegistros.Visible = true;
            pnlContenedorDeCotizacionNueva.Visible = false;
            pnlRegistroCotizacion.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

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
        //Metodo para buscar venta para generar factura y usar los datos de esa venta
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtnVenta.Text.Trim(), out int idVenta))
            {
                MessageBox.Show("Ingresa un número de venta válido.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataTable dt = DbFactura.BuscarVentaParaFactura(idVenta);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("La venta no existe o ya tiene una factura.", "Venta no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataRow fila = dt.Rows[0];

            MessageBox.Show("Venta encontrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Datos del cliente en los TextBox
            txtMostrarCliente.Text = fila["Cliente"].ToString();
            txtDui.Text = fila["Documento"].ToString();
            txtTelefono.Text = fila["Telefono"].ToString();
            txtCorreo.Text = fila["Correo"].ToString();

            // FECHA DE VENTA
            dtpFechaVenta.Text = Convert.ToDateTime(fila["Fecha de Venta"]).ToString("dd/MM/yyyy");

            // SUBTOTAL
            txtSubTotal.Text = Convert.ToDecimal(fila["SubTotal"]).ToString("0.00");

            // DESCUENTO
            txtDescuento.Text = "0.00";

            // CALCULAR IVA Y TOTAL
            CalcularTotales();

            DataTable detalle = DbFactura.CargarDetalleVentaParaFactura(idVenta);

            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = detalle;

            // CONFIGURAR DISEÑO DE LA TABLA
            ConfigurarTablasFacturacion();

            // Calcular cantidad total de productos
            int cantidadProductos = CalcularCantidadProductos();

            // Mostrar cantidad en la pestaña verde
            lblTotalDeProductos.Text = cantidadProductos.ToString();


        }

        private void CalcularTotales()
        {
            // Obtener el subtotal 
            if (!decimal.TryParse(txtSubTotal.Text, out decimal subtotal))
                return;

            // Obtener el descuento
            if (!decimal.TryParse(txtDescuento.Text, out decimal descuento))
                descuento = 0;

            // Validar que el descuento no puede ser un numero negativo
            if (descuento < 0)
            {
                descuento = 0;
                txtDescuento.Text = "0.00";
            }

            // El descuento no puede superar el subtotal
            if (descuento > subtotal)
            {
                MessageBox.Show("El descuento no puede ser mayor que el subtotal.", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                descuento = 0;
                //Declarar el valor del descuento inicial
                txtDescuento.Text = "";
            }

            // Restar el descuento al subtotal de la vista
            decimal subtotalConDescuento = subtotal - descuento;

            // Calcular IVA del 13% ya con el descuento aplicado
            decimal iva = subtotalConDescuento * 0.13m;

            // Calcular total de la venta para mostrarlo en la factura
            decimal total = subtotalConDescuento + iva;

            // Mostrar resultados finales
            txtIVA.Text = iva.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        //Método para limpiar los controles
        private void btnLimpiarFactura_Click(object sender, EventArgs e)
        {
            txtnVenta.Text = null;
            txtMostrarCliente.Text = null;
            txtTelefono.Text = null;
            txtDui.Text = null;
            txtCorreo.Text = null;
            txtNumeroFactura.Text = null;
            txtSubTotal.Text = null;
            txtIVA.Text = null;
            txtDescuento.Text = null;
            txtTotal.Text = null;
            txtObservaciones.Text = null;

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            lblTotalAPagar.Text = "Total a pagar: $ " + txtTotal.Text;
        }

        //Metodo para calcular la cantidad total de la venta
        private int CalcularCantidadProductos()
        {
            int cantidadTotal = 0;
            //Recorre todas las filas de la tabla y las acumula dentro de la variable

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.IsNewRow)
                    continue;
                //Tomma en cuenta cada valor que se encuentre en la columna de cantidad y lo guarda en otra variable
                // para luego poder sumar los productos

                if (fila.Cells["Cantidad"].Value != null)
                {
                    if (int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out int cantidad))
                    {
                        cantidadTotal += cantidad;
                    }
                }
            }

            return cantidadTotal;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "Buscar por número de factura...")
                {
                    return;
                }

                string buscar = txtBuscar.Text.Trim();

                // Si la búsqueda está vacía,
                // mostrar nuevamente todas las facturas
                if (string.IsNullOrWhiteSpace(buscar))
                {
                    MostrarRegistrosFacturas();
                    return;
                }

                // Buscar las facturas
                dtFacturas = DbFactura.BuscarFacturas(buscar);

                // Volver a la primera página
                paginaActual = 1;

                // Calcular páginas
                CalcularPaginasFacturas();

                // Mostrar resultados paginados
                MostrarPaginaFacturas();
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
                    txtBuscar.Text = "Buscar por número de factura...";
                    txtBuscar.ForeColor = Color.Gray;
                }
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
                if (txtBuscar.Text == "Buscar por número de factura...")
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Vaciar el buscador
            txtBuscar.Text = "";

            // Volver a mostrar el texto de indicación
            txtBuscar.Text = "Buscar por número de factura...";
            txtBuscar.ForeColor = Color.Gray;

            // Recargar todas las facturas
            MostrarRegistrosFacturas();
        }

        private void dgvFacturasRegistradas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int idFactura = Convert.ToInt32(dgvFacturasRegistradas.Rows[e.RowIndex].Cells["IdFactura"].Value);

            frmEditarFactura formulario = new frmEditarFactura(idFactura);

            formulario.ShowDialog();

            MostrarRegistrosFacturas();
            dgvFacturasRegistradas.Columns["IdFactura"].HeaderText = "N° de Factura";
            dgvFacturasRegistradas.Columns["Fecha"].HeaderText = "Fecha de emisión";
        }


        private void GuardarFactura()
        {
            try
            {
                // VALIDAR EL NUMERO DE LA VENTA QUE SE INGRESO
                if (string.IsNullOrWhiteSpace(txtnVenta.Text))
                {
                    errorProvider1.SetError(txtnVenta, "Debe ingresar el número de venta.");
                    txtnVenta.Focus();
                    return;
                }

                if (!int.TryParse(txtnVenta.Text.Trim(), out int idVenta))
                {
                    errorProvider1.SetError(txtnVenta, "El número de venta debe ser un número válido.");
                    txtnVenta.Focus();
                    return;
                }

                // VALIDACIÓN DE FECHAS
                DateTime fechaEmision = dtFechaDatosGeneralesFactura.Value;
                DateTime fechaVencimiento = dtpFechaVencimiento.Value;

                if (fechaVencimiento < fechaEmision)
                {
                    errorProvider1.SetError(dtpFechaVencimiento, "La fecha de vencimiento no puede ser menor que la fecha de emisión.");
                    dtpFechaVencimiento.Focus();
                    return;
                }

                // OBTIENE EL DESCUENTO Y LO ALMACENA EN LA VARIABLE LUEGO DE CONVERTIRLO
                if (!decimal.TryParse(txtDescuento.Text.Trim(), out decimal descuento))
                {
                    descuento = 0;
                }

                if (descuento < 0)
                {
                    errorProvider1.SetError(txtDescuento, "El descuento no puede ser negativo.");
                    txtDescuento.Focus();
                    return;
                }
                // OBSERVACIONES
                string observaciones = txtObservaciones.Text.Trim();
                //CREA EL OBJETO DE UNA NUEVA FACTURA
                DbFactura factura = new DbFactura();

                factura.FechaEmisión1 = fechaEmision;
                factura.FechaVencimiento1 = fechaVencimiento;
                factura.Venta1 = idVenta;
                factura.Descuento1 = descuento;
                factura.Observaciones1 = observaciones;

                int idFactura = factura.InsertarFactura();

                //GUARDA EL ID DE LA FACTURA Y LO MUESTRA EN EL TEXTBOX
                if (idFactura == 0)
                {
                    return;
                }
                //MUESTRA EL NUMERO DE LA FACTURA
                txtNumeroFactura.Text = idFactura.ToString();

                //ACTUALIZA LA TABLA DE LOS REGISTROS LUEGO DE GUARDAR LA FACTURA
                MostrarRegistrosFacturas();

                MessageBox.Show($"La factura N.º {idFactura} se guardó correctamente.\n\n" + "Ahora puedes presionar 'Generar PDF'.", "Factura guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar la factura:\n\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            // Limpiar número de venta
            txtnVenta.Clear();

            // Limpiar datos del cliente
            txtMostrarCliente.Clear();
            txtTelefono.Clear();
            txtDui.Clear();
            txtCorreo.Clear();

            // Restablecer fechas
            if (DateTime.Now >= dtFechaDatosGeneralesFactura.MinDate && DateTime.Now <= dtFechaDatosGeneralesFactura.MaxDate)
            {
                dtFechaDatosGeneralesFactura.Value = DateTime.Now;
            }

            if (DateTime.Now >= dtpFechaVencimiento.MinDate && DateTime.Now <= dtpFechaVencimiento.MaxDate)
            {
                dtpFechaVencimiento.Value = DateTime.Now;
            }

            // Limpiar número de factura
            txtNumeroFactura.Clear();

            //Limpiar total de productos
            lblTotalDeProductos.Text = "";

            // Limpiar observaciones
            txtObservaciones.Clear();

            // Limpiar detalles de productos
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.Rows.Clear();

            // Limpiar resumen de pago
            txtSubTotal.Clear();
            txtIVA.Clear();
            txtDescuento.Clear();
            txtTotal.Clear();

            // Restablecer total a pagar
            lblTotalAPagar.Text = "Total a pagar $ : 0.00";
        }
        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            GuardarFactura();
            MostrarRegistrosFacturas();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {// Verificar que exista una factura
                if (!int.TryParse(txtNumeroFactura.Text.Trim(), out int idFactura))
                {
                    MessageBox.Show("Primero debes guardar una factura.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Ventana para elegir dónde guardar el PDF
                using (SaveFileDialog guardar = new SaveFileDialog())
                {
                    guardar.Title = "Guardar factura en PDF";
                    guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    guardar.FileName = $"Factura_{idFactura}.pdf";

                    if (guardar.ShowDialog() != DialogResult.OK)
                        return;

                    // Generar el PDF
                    GeneradorFactura.Generar(idFactura, guardar.FileName);

                    // Limpiar solamente después de generar
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPaginaFacturas();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPaginaFacturas();
            }
        }
    }
}

