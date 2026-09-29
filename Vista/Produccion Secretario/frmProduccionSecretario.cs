using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Producción;
using Vista.Responsive;

namespace Vista.Produccion_Secretario
{
    public partial class frmProduccionSecretario : Form
    {
        public frmProduccionSecretario()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarTablaProduccion();
            ConfigurarBarraBusqueda();
        }


        // DATOS PARA LA PAGINACIÓN
        private int registrosPorPagina = 10;
        private int paginaActual = 1;
        private int totalRegistros = 0;
        private int totalPaginas = 1;

        private DataTable dtProduccion;
        private DataTable dtProduccionFiltrada;
        private const string TextoBusqueda = "Buscar por código o nombre de cliente...";
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
        // CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            // Buscador
            toolTip.SetToolTip(txtBuscar, "Busca una producción por código o nombre del cliente.");

            // Estados
            toolTip.SetToolTip(cbEstados, "Filtra las producciones según su estado.");

            // Limpiar
            toolTip.SetToolTip(btnLimpiar, "Limpia todos los filtros de producción.");

            // Editar
            toolTip.SetToolTip(btnEditar, "Permite editar la producción seleccionada.");

            // Material utilizado
            toolTip.SetToolTip(btnMaterialUtilizado, "Muestra los materiales utilizados en la producción seleccionada.");

            // Tabla
            toolTip.SetToolTip(dgvProduccion, "Selecciona una producción para consultar sus opciones.");

            // Paginación
            toolTip.SetToolTip(btnAtrass, "Muestra la página anterior.");

            toolTip.SetToolTip(btnSiguient, "Muestra la página siguiente.");

            toolTip.SetToolTip(lblPage, "Indica la página actual y el total de páginas.");
        }

        // CONFIGURAR DISEÑO DE LA TABLA
        private void ConfigurarTablaProduccion()
        {
            dgvProduccion.AutoGenerateColumns = true;
            dgvProduccion.RowHeadersVisible = false;
            // Configuración general
            dgvProduccion.AllowUserToAddRows = false;
            dgvProduccion.AllowUserToDeleteRows = false;
            dgvProduccion.AllowUserToResizeRows = false;
            dgvProduccion.AllowUserToResizeColumns = false;
            // Encabezado
            dgvProduccion.EnableHeadersVisualStyles = false;

            dgvProduccion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

            dgvProduccion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvProduccion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgvProduccion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color del encabezado al seleccionar
            dgvProduccion.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

            dgvProduccion.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvProduccion.DefaultCellStyle.BackColor = Color.White;

            dgvProduccion.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);

            dgvProduccion.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgvProduccion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvProduccion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvProduccion.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);

            dgvProduccion.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvProduccion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProduccion.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvProduccion.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvProduccion.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvProduccion.ReadOnly = true;

            dgvProduccion.AllowUserToAddRows = false;

            dgvProduccion.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvProduccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProduccion.MultiSelect = false;

            // Quitar borde exterior
            dgvProduccion.BorderStyle = BorderStyle.None;
        }

        // CARGA INICIAL DEL FORMULARIO
        private void frmProduccionSecretario_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga las producciones
                ConfigurarTooltips();

                // Carga las producciones
                MostrarProduccion();

                // Carga las estadísticas
                ActualizarEstadisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------
        // CONFIGURAR COLUMNAS
        private void ConfigurarColumnasProduccion()
        {
            if (dgvProduccion.Columns.Contains("IdProduccion"))
            {
                dgvProduccion.Columns["IdProduccion"].Visible = false;
            }

            if (dgvProduccion.Columns.Contains("IdPedido"))
            {
                dgvProduccion.Columns["IdPedido"].HeaderText = "N° Pedido";
            }

            if (dgvProduccion.Columns.Contains("Cliente"))
            {
                dgvProduccion.Columns["Cliente"].HeaderText = "Cliente";
                dgvProduccion.Columns["Cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvProduccion.Columns.Contains("Producto"))
            {
                dgvProduccion.Columns["Producto"].HeaderText = "Producto";
                dgvProduccion.Columns["Producto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvProduccion.Columns.Contains("Largo"))
            {
                dgvProduccion.Columns["Largo"].HeaderText = "Largo (cm)";
            }

            if (dgvProduccion.Columns.Contains("Ancho"))
            {
                dgvProduccion.Columns["Ancho"].HeaderText = "Ancho (cm)";
            }

            if (dgvProduccion.Columns.Contains("Alto"))
            {
                dgvProduccion.Columns["Alto"].HeaderText = "Alto (cm)";
            }

            if (dgvProduccion.Columns.Contains("Cantidad"))
            {
                dgvProduccion.Columns["Cantidad"].HeaderText = "Cantidad";
            }

            if (dgvProduccion.Columns.Contains("Progreso"))
            {
                dgvProduccion.Columns["Progreso"].HeaderText = "Progreso (%)";
            }

            if (dgvProduccion.Columns.Contains("Estado"))
            {
                dgvProduccion.Columns["Estado"].HeaderText = "Estado";
            }

            if (dgvProduccion.Columns.Contains("Fecha de Entrega"))
            {
                dgvProduccion.Columns["Fecha de Entrega"].HeaderText = "Fecha de entrega";
            }

            // Desactivar ordenamiento manual
            foreach (DataGridViewColumn columna in dgvProduccion.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvProduccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //---------------------------------------------------------------
        // MOSTRAR PRODUCCIÓN
        public void MostrarProduccion()
        {
            try
            {
                // Obtiene todas las producciones
                dtProduccion = DbProducción.CargarProducción();

                totalRegistros = dtProduccion.Rows.Count;

                totalPaginas =
                    (int)Math.Ceiling(
                        (double)totalRegistros /
                        registrosPorPagina
                    );

                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }

                paginaActual = 1;

                dtProduccionFiltrada = null;

                MostrarPaginaProduccion();

                ActualizarEstadisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las producciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------
        // MOSTRAR PÁGINA ACTUAL
        private void MostrarPaginaProduccion()
        {
            if (dtProduccion == null)
                return;

            DataTable dtPagina = dtProduccion.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtProduccion.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtProduccion.Rows[i]);
                dtPagina.ImportRow(dtProduccion.Rows[i]);
            }

            dgvProduccion.DataSource = null;
            dgvProduccion.DataSource = dtPagina;

            ConfigurarColumnasProduccion();

            dgvProduccion.Refresh();

            ActualizarControlesPaginacion();
        }
        //----------------------------------------------------
        // ACTUALIZAR CONTROLES DE PAGINACIÓN
        private void ActualizarControlesPaginacion()
        {
            lblPage.Text = $"Página {paginaActual} de {totalPaginas}";

            btnAtrass.Enabled = paginaActual > 1;

            btnSiguient.Enabled = paginaActual < totalPaginas;
        }
        //---------------------------------------------------------
        // PÁGINA ANTERIOR
        private void btnAtrass_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                if (dtProduccionFiltrada != null)
                {
                    MostrarPaginaBusquedaProduccion();
                }
                else
                {
                    MostrarPaginaProduccion();
                }
            }
        }
        // PÁGINA SIGUIENTE
        private void btnSiguient_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                if (dtProduccionFiltrada != null)
                {
                    MostrarPaginaBusquedaProduccion();
                }
                else
                {
                    MostrarPaginaProduccion();
                }
            }
        }

        // Filtra la tabla según el estado y búsqueda
        private void FiltrarTabla()
        {
            try
            {
                if (dtProduccion == null)
                    return;

                string estado = cbEstados.Text;

                string buscar = txtBuscar.Text == "Buscar por código o nombre de cliente..." ? "" : txtBuscar.Text.Trim();

                string filtro = "1=1";

                // Filtra por estado
                if (!string.IsNullOrWhiteSpace(estado) &&
                    estado != "Todos")
                {
                    filtro += " AND Estado = '" + estado.Replace("'", "''") + "'";
                }

                // Filtra por cliente, producción o pedido
                if (!string.IsNullOrWhiteSpace(buscar))
                {
                    buscar = buscar.Replace("'", "''");

                    filtro += " AND (Cliente LIKE '%" + buscar + "%' OR " + "Convert(IdProduccion, 'System.String') LIKE '%" +
                        buscar + "%' OR " + "Convert(IdPedido, 'System.String') LIKE '%" + buscar + "%')";
                }

                DataView vista = new DataView(dtProduccion);

                vista.RowFilter = filtro;

                dtProduccionFiltrada = vista.ToTable();

                totalRegistros =
                    dtProduccionFiltrada.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);

                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }

                paginaActual = 1;

                MostrarPaginaBusquedaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las producciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MOSTRAR PÁGINA DE RESULTADOS FILTRADOS
        private void MostrarPaginaBusquedaProduccion()
        {
            if (dtProduccionFiltrada == null)
                return;

            DataTable dtPagina = dtProduccionFiltrada.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtProduccionFiltrada.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtProduccionFiltrada.Rows[i]);
            }

            dgvProduccion.DataSource = null;
            dgvProduccion.DataSource = dtPagina;

            ConfigurarColumnasProduccion();

            dgvProduccion.Refresh();

            ActualizarControlesPaginacion();
        }

        //------------------------------------------------------------------
        // EDITAR PRODUCCIÓN
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que exista una producción seleccionada
                if (dgvProduccion.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona una producción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Obtiene el ID de la producción
                int idProduccion = Convert.ToInt32(dgvProduccion.CurrentRow.Cells["IdProduccion"].Value);

                // Abre el formulario de edición
                frmEditarProduccion formulario = new frmEditarProduccion(idProduccion);

                DialogResult resultado = formulario.ShowDialog();

                // Actualiza la tabla si se guardaron cambios
                if (resultado == DialogResult.OK)
                {
                    MostrarProduccion();
                    ActualizarEstadisticas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la producción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //_---------------------------------------------------------------------------------------
        // BUSCAR PRODUCCIÓN


        // Ejecuta el filtro cuando cambia el estado
        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtProduccion == null)
                return;

            FiltrarTabla();
        }
        // Ejecuta el filtro cuando cambia el texto
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por código o nombre de cliente...")
            {
                FiltrarTabla();
            }
        }

        //------------------------------------------------------------------------------
        // LIMPIAR FILTROS

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                // Reinicia el ComboBox
                cbEstados.SelectedIndex = -1;

                // Reinicia el buscador
                txtBuscar.Text =
                    "Buscar por código o nombre de cliente...";

                txtBuscar.ForeColor = Color.Gray;

                // Reinicia la paginación
                paginaActual = 1;

                // Elimina los datos filtrados
                dtProduccionFiltrada = null;

                // Muestra nuevamente todas las producciones
                MostrarProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los filtros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------------
        // MATERIAL UTILIZADO
        private void btnMaterialUtilizado_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que exista una producción seleccionada
                if (dgvProduccion.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona una producción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Obtiene el ID de la producción
                int idProduccion = Convert.ToInt32(dgvProduccion.CurrentRow.Cells["IdProduccion"].Value);

                // Obtiene el nombre del producto
                string producto = dgvProduccion.CurrentRow.Cells["Producto"].Value?.ToString() ?? "";

                // Obtiene la fecha de entrega
                DateTime fechaEntrega = Convert.ToDateTime(dgvProduccion.CurrentRow.Cells["Fecha de Entrega"].Value);

                // Abre el formulario de materiales utilizados
                frmMaterialUtilizado formulario = new frmMaterialUtilizado(idProduccion, producto, fechaEntrega);

                formulario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los materiales utilizados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //-------------------------------------------------------------------
        // ESTADÍSTICAS

        //Metodo para actualizarlas
        private void ActualizarEstadisticas()
        {
            try
            {
                // Total de producciones
                lblMostrarRegistrados.Text = DbProducción.ContarProduccionesTotales().ToString();

                // Producciones pendientes
                lblMostrarPendientes.Text = DbProducción.ContarProduccionesPendientes().ToString();

                // Producciones en proceso
                lblMostrarEnProduccion.Text = DbProducción.ContarProduccionesEnProceso().ToString();

                // Producciones finalizadas
                lblMostrarFinalizados.Text = DbProducción.ContarProduccionesFinalizadas().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar las estadísticas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
