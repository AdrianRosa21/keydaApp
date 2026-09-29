using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Pedidos
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            dgvDetallesDePedido.AllowUserToDeleteRows = false;
            dgvDetallesDePedido.AllowUserToAddRows = false;
            dgvDetallesDePedido.ReadOnly = true;
            dgvDetallesDePedido.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "EliminarProducto",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            });
            dgvDetallesDePedido.CellContentClick += EliminarProducto_Click;

            ConfigurarBarraBusqueda();
            ConfigurarBoton(btnGuardar);
            ConfigurarBoton(btnCancelar);
        }
        // PAGINACIÓN
        private DataTable dtPedidos;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private bool buscandoPedidos = false;
        private int totalPaginas = 0;
        string medidaLargo = "0";
        string medidaAncho = "0";
        string medidaAlto = "0";
        string observaciones = "";

        int idPedidoSeleccionado = 0;
        private string estadoOriginal = "";
        private DateTime fechaEntregaOriginal;
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

        private void ConfigurarBoton(Guna2Button boton)
        {
            boton.BorderRadius = 10;
            boton.BorderThickness = 1;
            boton.BorderColor = Color.FromArgb(121, 75, 45);

            boton.FillColor = Color.FromArgb(220, 200, 180);
            boton.ForeColor = Color.FromArgb(121, 75, 45);

            boton.HoverState.FillColor = Color.FromArgb(121, 75, 45);
            boton.HoverState.ForeColor = Color.White;
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(95, 55, 35);
        }





        //------------------------------------------------------------------------
        // CONFIGURAR TABLAS DE PEDIDOS
        private void ConfigurarTablas()
        {// TABLA DE PEDIDOS REGISTRADOS
            dgvPedidosRegistrados.EnableHeadersVisualStyles = false;

            // Encabezado
            dgvPedidosRegistrados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvPedidosRegistrados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPedidosRegistrados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvPedidosRegistrados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Filas
            dgvPedidosRegistrados.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvPedidosRegistrados.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvPedidosRegistrados.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvPedidosRegistrados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvPedidosRegistrados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvPedidosRegistrados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvPedidosRegistrados.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvPedidosRegistrados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidosRegistrados.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de filas
            dgvPedidosRegistrados.RowTemplate.Height = 40;

            // Alto del encabezado
            dgvPedidosRegistrados.ColumnHeadersHeight = 30;

            // No permitir modificar la tabla
            dgvPedidosRegistrados.ReadOnly = true;
            dgvPedidosRegistrados.AllowUserToAddRows = false;
            dgvPedidosRegistrados.AllowUserToDeleteRows = false;

            // Seleccionar una fila completa
            dgvPedidosRegistrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidosRegistrados.MultiSelect = false;

            // Quitar borde exterior
            dgvPedidosRegistrados.BorderStyle = BorderStyle.None;

            // Ajustar columnas
            if (dgvPedidosRegistrados.Columns.Contains("IdPedido"))
            {
                dgvPedidosRegistrados.Columns["IdPedido"].Visible = true;
                dgvPedidosRegistrados.Columns["IdPedido"].Width = 100;
                dgvPedidosRegistrados.Columns["IdPedido"].HeaderText = "N.º de Pedido";
                dgvPedidosRegistrados.Columns["IdPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("Cliente"))
            {
                dgvPedidosRegistrados.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvPedidosRegistrados.Columns.Contains("FechaDePedido"))
            {
                dgvPedidosRegistrados.Columns["FechaDePedido"].Width = 120;
                dgvPedidosRegistrados.Columns["FechaDePedido"].HeaderText = "Fecha del Pedido";

                dgvPedidosRegistrados.Columns["FechaDePedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("FechaDeEntrega"))
            {
                dgvPedidosRegistrados.Columns["FechaDeEntrega"].Width = 120;
                dgvPedidosRegistrados.Columns["FechaDeEntrega"].HeaderText = "Fecha de Entrega";

                dgvPedidosRegistrados.Columns["FechaDeEntrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("Estado"))
            {
                dgvPedidosRegistrados.Columns["Estado"].Width = 100;

                dgvPedidosRegistrados.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // TABLA DE DETALLES DEL PEDIDO

            dgvDetallesDePedido.EnableHeadersVisualStyles = false;
            dgvDetallesDePedido.RowTemplate.Height = 36;

            // TABLA DE DETALLES DE PEDIDO
            dgvDetallesDePedido.EnableHeadersVisualStyles = false;

            // Encabezado
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvDetallesDePedido.DefaultCellStyle.BackColor = Color.White;
            dgvDetallesDePedido.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvDetallesDePedido.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvDetallesDePedido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvDetallesDePedido.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvDetallesDePedido.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvDetallesDePedido.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvDetallesDePedido.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetallesDePedido.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de filas
            dgvDetallesDePedido.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvDetallesDePedido.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvDetallesDePedido.ReadOnly = true;
            dgvDetallesDePedido.AllowUserToAddRows = false;
            dgvDetallesDePedido.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvDetallesDePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallesDePedido.MultiSelect = false;

            // Quitar borde exterior
            dgvDetallesDePedido.BorderStyle = BorderStyle.None;
            // COLUMNAS DE DETALLES

            if (dgvDetallesDePedido.Columns.Contains("IdDetallePedido"))
            {
                dgvDetallesDePedido.Columns["IdDetallePedido"].Visible = false;
            }

            if (dgvDetallesDePedido.Columns.Contains("IdPedido"))
            {
                dgvDetallesDePedido.Columns["IdPedido"].Visible = false;
            }

            if (dgvDetallesDePedido.Columns.Contains("Mueble"))
            {
                dgvDetallesDePedido.Columns["Mueble"].HeaderText = "Mueble";

                dgvDetallesDePedido.Columns["Mueble"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvDetallesDePedido.Columns.Contains("Cantidad"))
            {
                dgvDetallesDePedido.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvDetallesDePedido.Columns["Cantidad"].Width = 90;

                dgvDetallesDePedido.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDetallesDePedido.Columns.Contains("Medidas"))
            {
                dgvDetallesDePedido.Columns["Medidas"].HeaderText = "Medidas";
                dgvDetallesDePedido.Columns["Medidas"].Width = 150;

                dgvDetallesDePedido.Columns["Medidas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // BOTÓN ELIMINAR

            if (dgvDetallesDePedido.Columns.Contains("EliminarProducto"))
            {
                DataGridViewButtonColumn botonEliminar = dgvDetallesDePedido.Columns["EliminarProducto"] as DataGridViewButtonColumn;

                if (botonEliminar != null)
                {
                    botonEliminar.HeaderText = "Eliminar";
                    botonEliminar.Text = "Eliminar";
                    botonEliminar.UseColumnTextForButtonValue = true;
                    botonEliminar.Width = 90;

                    botonEliminar.DefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

                    botonEliminar.DefaultCellStyle.ForeColor = Color.White;

                    botonEliminar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 56, 33);

                    botonEliminar.DefaultCellStyle.SelectionForeColor = Color.White;

                    botonEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

                    dgvDetallesDePedido.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            // Datos del pedido
            toolTip.SetToolTip(dtpFechaPedido, "Seleccione la fecha en que se realizó el pedido.");
            toolTip.SetToolTip(dtpFechaDeEntrega, "Seleccione la fecha en que se entregará el pedido.");
            toolTip.SetToolTip(txtEstado, "Estado del pedido seleccionado.");

            // Búsqueda
            toolTip.SetToolTip(txtBuscar, "Ingrese el número o información del pedido que desea buscar.");

            // Tablas
            toolTip.SetToolTip(dgvPedidosRegistrados, "Aquí se muestran los productos agregados al pedido.");
            toolTip.SetToolTip(dgvDetallesDePedido, "Aquí se muestran los pedidos registrados.");
        }

        private void EliminarProducto_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvDetallesDePedido.Columns[e.ColumnIndex].Name != "EliminarProducto")
                return;
            var fila = dgvDetallesDePedido.Rows[e.RowIndex];
            if (fila.IsNewRow) return;
            int pedido = Convert.ToInt32(fila.Cells["IdPedido"].Value);
            int detalle = Convert.ToInt32(fila.Cells["IdDetallePedido"].Value);
            try
            {
                bool ultimo = DetallePedidos.CargarDetallesPorPedido(pedido).Rows.Count == 1;
                string aviso = ultimo ? "Al eliminar el último producto, el pedido quedará marcado como Cancelado. El registro del pedido se conservará. ¿Desea continuar?"
                    : "¿Desea eliminar este producto del pedido?";
                if (MessageBox.Show(aviso, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
                bool cancelado = DetallePedidos.EliminarDetalle(pedido, detalle, ultimo);
                dgvDetallesDePedido.DataSource = DetallePedidos.CargarDetallesPorPedido(pedido);
                ConfigurarColumnasDetalles();
                MostrarPedidos();
                if (cancelado && idPedidoSeleccionado == pedido)
                {
                    txtEstado.Text = "Cancelado";
                    estadoOriginal = "Cancelado";
                }
                MessageBox.Show(cancelado ? "Producto eliminado. El pedido quedó Cancelado." : "Producto eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------------------------
        //SECCION DE BUSQUEDA
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == TextoBusqueda)
                    return;

                string texto = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    buscandoPedidos = false;
                    paginaActual = 1;

                    CargarPaginacionPedidos();

                    return;
                }

                buscandoPedidos = true;

                dtPedidos = DbPedidos.BuscarPedido(texto);

                paginaActual = 1;

                totalPaginas = (int)Math.Ceiling((double)dtPedidos.Rows.Count / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                MostrarPaginaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar pedidos.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------
        //SECCION DE PAGINACION DE PEDIDOS

        private void CargarPaginacionPedidos()
        {
            try
            {
                // Cargar todos los pedidos
                dtPedidos = DbPedidos.CargarRegistroPedidos();

                // Calcular el total de páginas
                totalPaginas = (int)Math.Ceiling((double)dtPedidos.Rows.Count / registrosPorPagina);

                // Si no existen pedidos
                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }

                // Evitar que la página actual sea mayor al total
                if (paginaActual > totalPaginas)
                {
                    paginaActual = totalPaginas;
                }

                MostrarPaginaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPaginaPedidos()
        {
            if (dtPedidos == null)
                return;

            DataTable dtPagina = dtPedidos.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtPedidos.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtPedidos.Rows[i]);
            }

            dgvPedidosRegistrados.DataSource = dtPagina;

            // Encabezados
            if (dgvPedidosRegistrados.Columns.Contains("IdPedido"))
                dgvPedidosRegistrados.Columns["IdPedido"].HeaderText = "N.º de Pedido";

            if (dgvPedidosRegistrados.Columns.Contains("Cliente"))
                dgvPedidosRegistrados.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvPedidosRegistrados.Columns.Contains("FechaDePedido"))
                dgvPedidosRegistrados.Columns["FechaDePedido"].HeaderText = "Fecha del Pedido";

            if (dgvPedidosRegistrados.Columns.Contains("FechaDeEntrega"))
                dgvPedidosRegistrados.Columns["FechaDeEntrega"].HeaderText = "Fecha de Entrega";

            if (dgvPedidosRegistrados.Columns.Contains("Estado"))
                dgvPedidosRegistrados.Columns["Estado"].HeaderText = "Estado";

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Habilitar o deshabilitar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
            MostrarDetallesPedido();

            // Configurar el diseño de las tablas
            ConfigurarTablas();

            ConfigurarTooltips();

            dtpFechaDeEntrega.Value = DateTime.Today;

            txtClienteSeleccionado.TabIndex = 1;
            dtpFechaPedido.TabIndex = 2;
            dtpFechaDeEntrega.TabIndex = 3;
            txtEstado.TabIndex = 4;

            // Encabezados visibles
            dgvDetallesDePedido.Columns["IdDetallePedido"].Visible = false;
            dgvDetallesDePedido.Columns["IdPedido"].Visible = false;
            dgvDetallesDePedido.Columns["Mueble"].HeaderText = "Mueble";
            dgvDetallesDePedido.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetallesDePedido.Columns["Medidas"].HeaderText = "Medidas";

            dgvPedidosRegistrados.Columns["IdPedido"].HeaderText = "N.º de Pedido";
            dgvPedidosRegistrados.Columns["Cliente"].HeaderText = "Cliente";
            dgvPedidosRegistrados.Columns["FechaDePedido"].HeaderText = "Fecha del Pedido";
            dgvPedidosRegistrados.Columns["FechaDeEntrega"].HeaderText = "Fecha de Entrega";
            dgvPedidosRegistrados.Columns["Estado"].HeaderText = "Estado";
        }

        private void MostrarDetallesPedido()
        {
            dgvDetallesDePedido.DataSource = null;
            dgvDetallesDePedido.DataSource = DetallePedidos.CargarDetallesPedidos();

            ConfigurarColumnasDetalles();
        }

        private void MostrarPedidos()
        {
            paginaActual = 1;

            CargarPaginacionPedidos();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                MostrarPaginaPedidos();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                MostrarPaginaPedidos();
            }
        }
        //------------------------------------------------------------------------------
        //EVENTO CLICK EN LAS CELDAS DE LA TABLA DE PEDIDOS REGISTRADOS

        private void dgvPedidosRegistrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que sea una fila válida
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow fila = dgvPedidosRegistrados.Rows[e.RowIndex];

                if (fila.IsNewRow)
                    return;

                // Obtener el ID del pedido seleccionado
                if (fila.Cells["IdPedido"].Value == null || fila.Cells["IdPedido"].Value == DBNull.Value)
                {
                    return;
                }

                idPedidoSeleccionado = Convert.ToInt32(fila.Cells["IdPedido"].Value);

                // CARGAR ESTADO
                string estado = fila.Cells["Estado"].Value?.ToString() ?? "";

                txtEstado.Text = estado;

                estadoOriginal = estado;

                // CARGAR FECHA DEL PEDIDO              

                if (fila.Cells["FechaDePedido"].Value != null && fila.Cells["FechaDePedido"].Value != DBNull.Value)
                {
                    dtpFechaPedido.Value = Convert.ToDateTime(fila.Cells["FechaDePedido"].Value);
                }


                // CARGAR FECHA DE ENTREGA


                if (fila.Cells["FechaDeEntrega"].Value != null && fila.Cells["FechaDeEntrega"].Value != DBNull.Value)
                {
                    fechaEntregaOriginal = Convert.ToDateTime(fila.Cells["FechaDeEntrega"].Value);

                    dtpFechaDeEntrega.Value = fechaEntregaOriginal;
                }

                // CARGAR CLIENTE

                if (fila.Cells["Cliente"].Value != null)
                {
                    txtClienteSeleccionado.Text = fila.Cells["Cliente"].Value.ToString();

                    txtClienteSeleccionado.ForeColor = Color.Black;

                    txtClienteSeleccionado.Enabled = false;
                }


                // CARGAR DETALLES DEL PEDIDO

                DataTable detalles = DetallePedidos.CargarDetallesPorPedido(idPedidoSeleccionado);

                dgvDetallesDePedido.DataSource = null;

                dgvDetallesDePedido.DataSource = detalles;

                // CONFIGURAR TABLA DE DETALLES
                ConfigurarColumnasDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los detalles del pedido.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //EVENTO DOBLE CLICK DE PEDIDOS REGISTRADOS
        private void dgvPedidosRegistrados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvPedidosRegistrados.Rows[e.RowIndex];

            int idPedido = Convert.ToInt32(fila.Cells["IdPedido"].Value);

            string cliente = fila.Cells["Cliente"].Value?.ToString() ?? "";

            idPedidoSeleccionado = idPedido;

            txtClienteSeleccionado.Text = cliente;
            txtClienteSeleccionado.ForeColor = Color.Black;
            txtClienteSeleccionado.Enabled = false;
        }
        //--------------------------------------------------------------------------------------
        //CONFIGURACION DE LAS COLUMNAS DE TABLA DE DETALLES
        private void ConfigurarColumnasDetalles()
        {
            if (dgvDetallesDePedido.Columns.Contains("IdDetallePedido"))
            {
                dgvDetallesDePedido.Columns["IdDetallePedido"].Visible = false;
            }

            if (dgvDetallesDePedido.Columns.Contains("IdPedido"))
            {
                dgvDetallesDePedido.Columns["IdPedido"].Visible = false;
            }

            if (dgvDetallesDePedido.Columns.Contains("Mueble"))
            {
                dgvDetallesDePedido.Columns["Mueble"].HeaderText = "Mueble";
            }

            if (dgvDetallesDePedido.Columns.Contains("Cantidad"))
            {
                dgvDetallesDePedido.Columns["Cantidad"].HeaderText = "Cantidad";
            }

            if (dgvDetallesDePedido.Columns.Contains("Medidas"))
            {
                dgvDetallesDePedido.Columns["Medidas"].HeaderText = "Medidas";
            }

            if (dgvDetallesDePedido.Columns.Contains("EliminarProducto"))
            {
                dgvDetallesDePedido.Columns["EliminarProducto"].HeaderText = "Eliminar";
            }
        }
        //-----------------------------------------------------------------------------------
        //-------------------DESACTIVAR COPIAR Y PEGAR--------------------------------------//

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
        //---------------------------------------------------------------------------------------------------------
        //------------------BOTON DE GUARDAR LOS CAMBIOS PARA ACTUALIZAR UN PEDIDO-------------------------------//

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (dtpFechaDeEntrega.Value.Date < dtpFechaPedido.Value.Date)
            {
                errorProvider1.SetError(dtpFechaDeEntrega, "La fecha de entrega no puede ser anterior a la fecha del pedido.");

                MessageBox.Show("La fecha de entrega no puede ser anterior a la fecha del pedido.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (idPedidoSeleccionado <= 0)
            {
                MessageBox.Show("Para actualizar la fecha de entrega, selecciona un pedido de la lista y presiona Guardar.", "Pedido no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DateTime nuevaFechaEntrega = dtpFechaDeEntrega.Value;

            bool fechaCambio = fechaEntregaOriginal.Date != nuevaFechaEntrega.Date;

            if (!fechaCambio)
            {
                MessageBox.Show("No se realizaron cambios en el pedido.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (DbPedidos.ActualizarPedidoFecha(idPedidoSeleccionado, nuevaFechaEntrega))
            {
                MessageBox.Show("La fecha de entrega del pedido se modificó correctamente a: " + nuevaFechaEntrega.ToString("dd/MM/yyyy"), "Fecha actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fechaEntregaOriginal = nuevaFechaEntrega;

                MostrarPedidos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la fecha del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            // Limpiar selección del pedido
            idPedidoSeleccionado = 0;

            // Limpiar estado
            txtEstado.Clear();

            // Restablecer fecha del pedido
            dtpFechaPedido.Value = DateTime.Today;

            // Restablecer fecha de entrega
            dtpFechaDeEntrega.Value = DateTime.Today;

            // Limpiar cliente seleccionado
            txtClienteSeleccionado.Clear();
            txtClienteSeleccionado.ForeColor = Color.Gray;
            txtClienteSeleccionado.Enabled = true;

            // Restablecer valores originales
            estadoOriginal = "";
            fechaEntregaOriginal = DateTime.MinValue;

            // Quitar selección de la tabla de pedidos
            dgvPedidosRegistrados.ClearSelection();

            // Limpiar tabla de detalles conservando los encabezados
            DataTable dtVacio = DetallePedidos.CargarDetallesPedidos().Clone();

            dgvDetallesDePedido.DataSource = dtVacio;

            // Volver a mostrar los pedidos
            MostrarPedidos();
        }

        private void dtpFechaPedido_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dtpFechaDeEntrega_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }
    }
}
