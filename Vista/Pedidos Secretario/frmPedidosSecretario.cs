using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Pedidos_Secretario
{
    public partial class frmPedidosSecretario : Form
    {
        public frmPedidosSecretario()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            dgvDetallesDePedido.AllowUserToDeleteRows = false;
            dgvDetallesDePedido.AllowUserToAddRows = false;
            dgvDetallesDePedido.ReadOnly = true;
            ConfigurarBarraBusqueda();

        }
        // PAGINACIÓN
        private DataTable dtPedidos;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private bool buscandoPedidos = false;
        private int totalPaginas = 0;
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
                string aviso = ultimo ? "Al eliminar el último producto, el pedido quedará marcado como Cancelado. El registro del pedido se conservará. ¿Desea continuar?" : "¿Desea eliminar este producto del pedido?";
                if (MessageBox.Show(aviso, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
                bool cancelado = DetallePedidos.EliminarDetalle(pedido, detalle, ultimo);
                dgvDetallesDePedido.DataSource = DetallePedidos.CargarDetallesPorPedido(pedido);
                MostrarPedidosRegistrados();

                MessageBox.Show(cancelado ? "Producto eliminado. El pedido quedó Cancelado." : "Producto eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------
        //METODOS DE BUSQUEDA

        private void txtBuscar_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar Pedido...";
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void txtBuscar_Enter_1(object sender, EventArgs e)
        {
            //Cuando el usuario de enter para escribir, se va a borrar el texto de indicacion
            // Y el texto ya no sera opaco, sera color negro

            if (txtBuscar.Text == "Buscar Pedido...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "Buscar pedido...")
                    return;

                string texto = txtBuscar.Text.Trim();

                // Si el buscador está vacío
                if (string.IsNullOrWhiteSpace(texto))
                {
                    buscandoPedidos = false;
                    paginaActual = 1;

                    CargarPaginacionPedidos();

                    return;
                }

                buscandoPedidos = true;

                // Buscar pedidos
                dtPedidos = DbPedidos.BuscarPedido(texto);

                paginaActual = 1;

                // Calcular páginas de los resultados
                totalPaginas = (int)Math.Ceiling((double)dtPedidos.Rows.Count / registrosPorPagina);

                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }
                MostrarPaginaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //------------------------------------------------------------------------
        // MOSTRAR PÁGINA

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
        //------------------------------------------------------------------------
        //EVENTO LOAD
        private void frmPedidosSecretario_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarTablas();
                ConfigurarTooltips();
                MostrarPedidosRegistrados();
                LimpiarDetalles();
                DesactivarCopiarPegar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el formulario de pedidos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTablas()
        {
            ConfigurarEstiloTabla(dgvPedidosRegistrados);
            ConfigurarEstiloTabla(dgvDetallesDePedido);

            dgvPedidosRegistrados.RowTemplate.Height = 32;
            dgvPedidosRegistrados.ColumnHeadersHeight = 30;

            dgvDetallesDePedido.RowTemplate.Height = 32;
            dgvDetallesDePedido.ColumnHeadersHeight = 30;

            ConfigurarColumnasPedidos();
            ConfigurarColumnasDetalles();
        }

        private void ConfigurarEstiloTabla(DataGridView tabla)
        {
            tabla.RowHeadersVisible = false;
            tabla.EnableHeadersVisualStyles = false;

            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            tabla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

            tabla.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            tabla.DefaultCellStyle.BackColor = Color.White;
            tabla.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);

            tabla.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            tabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);

            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;

            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            tabla.GridColor = Color.FromArgb(220, 220, 220);

            tabla.BorderStyle = BorderStyle.None;

            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabla.MultiSelect = false;
            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
        }


        private void ConfigurarColumnasPedidos()
        {
            if (dgvPedidosRegistrados.Columns.Contains("IdPedido"))
            {
                dgvPedidosRegistrados.Columns["IdPedido"].HeaderText = "N.º de Pedido";
                dgvPedidosRegistrados.Columns["IdPedido"].Width = 100;
                dgvPedidosRegistrados.Columns["IdPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("Cliente"))
            {
                dgvPedidosRegistrados.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPedidosRegistrados.Columns["Cliente"].HeaderText = "Cliente";
            }

            if (dgvPedidosRegistrados.Columns.Contains("FechaDePedido"))
            {
                dgvPedidosRegistrados.Columns["FechaDePedido"].HeaderText = "Fecha del Pedido";

                dgvPedidosRegistrados.Columns["FechaDePedido"].Width = 120;

                dgvPedidosRegistrados.Columns["FechaDePedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("FechaDeEntrega"))
            {
                dgvPedidosRegistrados.Columns["FechaDeEntrega"].HeaderText = "Fecha de Entrega";

                dgvPedidosRegistrados.Columns["FechaDeEntrega"].Width = 120;

                dgvPedidosRegistrados.Columns["FechaDeEntrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPedidosRegistrados.Columns.Contains("Estado"))
            {
                dgvPedidosRegistrados.Columns["Estado"].HeaderText = "Estado";
                dgvPedidosRegistrados.Columns["Estado"].Width = 100;

                dgvPedidosRegistrados.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ConfigurarColumnasDetalles()
        {
            if (dgvDetallesDePedido.Columns.Contains("IdDetallePedido"))
                dgvDetallesDePedido.Columns["IdDetallePedido"].Visible = false;

            if (dgvDetallesDePedido.Columns.Contains("IdPedido"))
                dgvDetallesDePedido.Columns["IdPedido"].Visible = false;

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


        }
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(txtBuscar, "Ingrese el número o información del pedido que desea buscar.");

            toolTip.SetToolTip(dgvPedidosRegistrados, "Seleccione un pedido para consultar sus productos.");

            toolTip.SetToolTip(dgvDetallesDePedido, "Aquí se muestran los productos del pedido seleccionado.");
        }

        private void MostrarPedidosRegistrados()
        {
            paginaActual = 1;
            CargarPaginacionPedidos();
        }

        private void CargarPaginacionPedidos()
        {
            try
            {
                dtPedidos = DbPedidos.CargarRegistroPedidos();

                totalPaginas = Math.Max(1, (int)Math.Ceiling((double)dtPedidos.Rows.Count / registrosPorPagina));

                paginaActual = Math.Min(paginaActual, totalPaginas);

                MostrarPaginaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los pedidos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------------------------------
        // DESACTIVAR COPIAR Y PEGAR

        private void DesactivarCopiarPegar(Control control)
        {
            foreach (Control elemento in control.Controls)
            {
                if (elemento is TextBox)
                {
                    ((TextBox)elemento).ShortcutsEnabled =
                        false;
                }

                if (elemento.HasChildren)
                {
                    DesactivarCopiarPegar(elemento);
                }
            }
        }
        //Botones de paginación--------------------------------------------------------
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
        private void dgvPedidosRegistrados_SelectionChanged(object sender, EventArgs e)
        {
            CargarDetallesPedidoSeleccionado();
        }

        private void CargarDetallesPedidoSeleccionado()
        {
            try
            {
                if (dgvPedidosRegistrados.CurrentRow == null)
                {
                    LimpiarDetalles();
                    return;
                }

                if (!dgvPedidosRegistrados.Columns.Contains("IdPedido"))
                {
                    LimpiarDetalles();
                    return;
                }

                object valorId = dgvPedidosRegistrados.CurrentRow.Cells["IdPedido"].Value;

                if (valorId == null || valorId == DBNull.Value)
                {
                    LimpiarDetalles();
                    return;
                }

                int idPedido = Convert.ToInt32(valorId);

                DataTable detalles = DetallePedidos.CargarDetallesPorPedido(idPedido);

                dgvDetallesDePedido.DataSource = detalles;

                ConfigurarColumnasDetalles();
            }
            catch (Exception ex)
            {
                dgvDetallesDePedido.DataSource = null;

                MessageBox.Show("No se pudieron cargar los productos del pedido.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDetalles()
        {
            dgvDetallesDePedido.DataSource = null;
        }

        private void dgvPedidosRegistrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (!dgvPedidosRegistrados.Columns.Contains("IdPedido"))
                    return;

                object valorId = dgvPedidosRegistrados.Rows[e.RowIndex].Cells["IdPedido"].Value;

                if (valorId == null || valorId == DBNull.Value)
                {
                    dgvDetallesDePedido.DataSource = null;
                    return;
                }

                int idPedido = Convert.ToInt32(valorId);

                DataTable detalles = DetallePedidos.CargarDetallesPorPedido(idPedido);

                dgvDetallesDePedido.DataSource = detalles;

                ConfigurarColumnasDetalles();
            }
            catch (Exception ex)
            {
                dgvDetallesDePedido.DataSource = null;

                MessageBox.Show("No se pudieron cargar los productos del pedido.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------------------------------
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
    }
}


