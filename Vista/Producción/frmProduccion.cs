using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Producción
{
    public partial class frmProduccion : Form
    {
        // PAGINACIÓN
        private DataTable dtProduccion;
        private int paginaActual = 1;
        private int registrosPorPagina = 20;
        private int totalPaginas = 0;
        private DataTable dtProduccionOriginal;

        private const string TextoBusqueda = "Buscar por código o nombre de cliente...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);
        public frmProduccion()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);

        }
        // CARGA INICIAL DEL FORMULARIO
        private void frmProduccion_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga las producciones
                MostrarProduccion();

                // Configura el diseño de la tabla
                ConfigurarTablaProduccion();

                // Ajusta el texto y el tamaño de las filas
                dgvProduccion.DefaultCellStyle.WrapMode =
                    DataGridViewTriState.True;

                dgvProduccion.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;

                // Carga las estadísticas
                ActualizarEstadisticas();

                //Mostrar Tooltips
                ConfigurarTooltips();
                ConfigurarBotones();
                ConfigurarBarraBusqueda();
                ConfigurarIndicadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarBotones()
        {
            ConfigurarBoton(btnEditar);
            ConfigurarBoton(btnMaterialUtilizado);
            ConfigurarBoton(btnLimpiar);
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

        private Guna2Elipse elipseIndicador1;
        private Guna2Elipse elipseIndicador2;
        private Guna2Elipse elipseIndicador3;
        private Guna2Elipse elipseIndicador4;

        private void ConfigurarIndicadores()
        {
            elipseIndicador1 = new Guna2Elipse
            {
                TargetControl = pnlIndicador1,
                BorderRadius = 12
            };

            elipseIndicador2 = new Guna2Elipse
            {
                TargetControl = pnlIndicador2,
                BorderRadius = 12
            };

            elipseIndicador3 = new Guna2Elipse
            {
                TargetControl = pnlIndicador3,
                BorderRadius = 12
            };

            elipseIndicador4 = new Guna2Elipse
            {
                TargetControl = pnlIndicador4,
                BorderRadius = 12
            };

            ConfigurarHoverTarjeta(pnlIndicador1);
            ConfigurarHoverTarjeta(pnlIndicador2);
            ConfigurarHoverTarjeta(pnlIndicador3);
            ConfigurarHoverTarjeta(pnlIndicador4);
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
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3 &&
                   control != pnlIndicador4)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(235, 143, 132);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(245, 195, 130);

            else if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(151, 225, 130);

            else if (control == pnlIndicador4)
                control.BackColor = Color.FromArgb(245, 238, 225);
        }
        private void Tarjeta_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3 &&
                   control != pnlIndicador4)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(235, 157, 145);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(245, 185, 115);

            else if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(157, 230, 132);

            else if (control == pnlIndicador4)
                control.BackColor = Color.White;
        }


        //---------------------------------------------------------------
        // CONFIGURAR DISEÑO DE LA TABLA
        private void ConfigurarTablaProduccion()
        {
            // Configuración general
            dgvProduccion.AutoGenerateColumns = true;
            dgvProduccion.EnableHeadersVisualStyles = false;
            dgvProduccion.AllowUserToAddRows = false;
            dgvProduccion.AllowUserToDeleteRows = false;
            dgvProduccion.AllowUserToResizeRows = false;
            dgvProduccion.AllowUserToResizeColumns = false;
            dgvProduccion.ReadOnly = true;
            dgvProduccion.MultiSelect = false;
            dgvProduccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduccion.RowHeadersVisible = false;
            dgvProduccion.BorderStyle = BorderStyle.None;
            dgvProduccion.BackgroundColor = Color.White;
            dgvProduccion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProduccion.GridColor = Color.FromArgb(225, 225, 225);

            // Alto del encabezado
            dgvProduccion.ColumnHeadersHeight = 40;

            // Alto de las filas
            dgvProduccion.RowTemplate.Height = 36;
            dgvProduccion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Ajustar columnas
            dgvProduccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Encabezado
            dgvProduccion.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 75, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 75, 45),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            // Filas
            dgvProduccion.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35),
                Padding = new Padding(5)
            };

            // Filas alternadas
            dgvProduccion.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 246, 240),
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35)
            };

            // Fila seleccionada
            dgvProduccion.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 215, 185);
            dgvProduccion.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 45, 35);

            // No permitir ordenar las columnas
            foreach (DataGridViewColumn columna in dgvProduccion.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        //CONFIGURAR TOOLTIPS----------------------------------------------------------
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            // Buscador
            toolTip.SetToolTip(txtBuscar, "Busca una producción por código o nombre del cliente.");

            // Filtro por estado
            toolTip.SetToolTip(cbEstados, "Selecciona un estado para filtrar las producciones.");

            // Limpiar filtros
            toolTip.SetToolTip(btnLimpiar, "Limpia el buscador y los filtros aplicados.");

            // Editar producción
            toolTip.SetToolTip(btnEditar, "Edita la producción seleccionada.");

            // Material utilizado
            toolTip.SetToolTip(btnMaterialUtilizado, "Consulta los materiales utilizados en la producción seleccionada.");

            // Tabla de producciones
            toolTip.SetToolTip(dgvProduccion, "Muestra las producciones registradas y su información.");

            // Estadísticas
            toolTip.SetToolTip(lblMostrarRegistrados, "Cantidad total de producciones registradas.");
            toolTip.SetToolTip(lblMostrarPendientes, "Cantidad de producciones pendientes.");
            toolTip.SetToolTip(lblMostrarEnProduccion, "Cantidad de producciones que se encuentran en proceso.");
            toolTip.SetToolTip(lblMostrarFinalizados, "Cantidad de producciones finalizadas.");
        }
        //---------------------------------------------------------------
        // CONFIGURAR COLUMNAS
        private void ConfigurarColumnasProduccion()
        {
            if (dgvProduccion.Columns.Contains("IdProduccion"))
                dgvProduccion.Columns["IdProduccion"].Visible = false;

            if (dgvProduccion.Columns.Contains("IdPedido"))
                dgvProduccion.Columns["IdPedido"].HeaderText = "N.º Pedido";

            if (dgvProduccion.Columns.Contains("Cliente"))
                dgvProduccion.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvProduccion.Columns.Contains("Producto"))
                dgvProduccion.Columns["Producto"].HeaderText = "Producto";

            if (dgvProduccion.Columns.Contains("Largo"))
                dgvProduccion.Columns["Largo"].HeaderText = "Largo (cm)";

            if (dgvProduccion.Columns.Contains("Ancho"))
                dgvProduccion.Columns["Ancho"].HeaderText = "Ancho (cm)";

            if (dgvProduccion.Columns.Contains("Alto"))
                dgvProduccion.Columns["Alto"].HeaderText = "Alto (cm)";

            if (dgvProduccion.Columns.Contains("Cantidad"))
                dgvProduccion.Columns["Cantidad"].HeaderText = "Cantidad";

            if (dgvProduccion.Columns.Contains("Progreso"))
                dgvProduccion.Columns["Progreso"].HeaderText = "Progreso (%)";

            if (dgvProduccion.Columns.Contains("Estado"))
                dgvProduccion.Columns["Estado"].HeaderText = "Estado";
        }

        //---------------------------------------------------------------
        // MOSTRAR PRODUCCIÓN
        public void MostrarProduccion()
        {
            try
            {
                // Obtiene las producciones de la base de datos
                dtProduccionOriginal = DbProducción.CargarProducción();

                dtProduccion = dtProduccionOriginal.Copy();

                paginaActual = 1;

                CalcularPaginas();

                MostrarPaginaProduccion();

                dgvProduccion.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las producciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAtrass_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                MostrarPaginaProduccion();
            }
        }

        private void btnSiguient_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                MostrarPaginaProduccion();
            }
        }

        private void CalcularPaginas()
        {
            int totalRegistros = dtProduccion.Rows.Count;

            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina
            );

            if (totalPaginas == 0)
            {
                totalPaginas = 1;
            }

            if (paginaActual > totalPaginas)
            {
                paginaActual = totalPaginas;
            }
        }

        private void MostrarPaginaProduccion()
        {
            try
            {
                if (dtProduccion == null)
                    return;

                DataTable dtPagina = dtProduccion.Clone();

                int inicio = (paginaActual - 1) * registrosPorPagina;

                int fin = Math.Min(inicio + registrosPorPagina, dtProduccion.Rows.Count
                );

                for (int i = inicio; i < fin; i++)
                {
                    dtPagina.ImportRow(dtProduccion.Rows[i]);
                }

                dgvProduccion.DataSource = null;
                dgvProduccion.DataSource = dtPagina;

                // Configura las columnas
                ConfigurarColumnasProduccion();

                // Configura el diseño
                ConfigurarTablaProduccion();

                // Configura las columnas
                ConfigurarColumnasProduccion();

                // Mostrar página actual
                lblPage.Text = $"Página {paginaActual} de {totalPaginas}";

                // Activar/desactivar botones
                btnAtrass.Enabled = paginaActual > 1;

                btnSiguient.Enabled = paginaActual < totalPaginas;

                // Ajusta el texto y el tamaño de las filas
                dgvProduccion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvProduccion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la página: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------
        // EDITAR PRODUCCIÓN

        private void btnEditar_Click_1(object sender, EventArgs e)
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
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por código o nombre de cliente...")
            {
                FiltrarTabla();
            }
        }

        // Filtra la tabla según el estado y búsqueda
        private void FiltrarTabla()
        {
            try
            {
                if (dtProduccionOriginal == null)
                    return;

                string estado = cbEstados.Text;

                string buscar = txtBuscar.Text == "Buscar por código o nombre de cliente..." ? "" : txtBuscar.Text.Trim();

                string filtro = "1=1";

                // Filtra por estado
                if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
                {
                    filtro += " AND Estado = '" + estado.Replace("'", "''") + "'";
                }

                // Filtra por cliente, producción o pedido
                if (!string.IsNullOrWhiteSpace(buscar))
                {
                    buscar = buscar.Replace("'", "''");

                    filtro += " AND (Cliente LIKE '%" + buscar + "%' OR " + "Convert(IdProduccion, 'System.String') LIKE '%" + buscar + "%' OR " + "Convert(IdPedido, 'System.String') LIKE '%" + buscar + "%')";
                }

                // Aplicar filtro sobre los datos originales
                DataView vista = new DataView(dtProduccionOriginal);

                vista.RowFilter = filtro;

                // Guardar resultados filtrados
                dtProduccion = vista.ToTable();

                // Volver a la primera página
                paginaActual = 1;

                // Calcular total de páginas
                CalcularPaginas();

                // Mostrar resultados
                MostrarPaginaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las producciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ejecuta el filtro cuando cambia el estado
        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }
        // Ejecuta el filtro cuando cambia el texto

        //------------------------------------------------------------------------------
        // LIMPIAR FILTROS
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Reiniciar buscador
                txtBuscar.Text = TextoBusqueda;
                txtBuscar.ForeColor = Color.LightGray;

                // Reiniciar estado
                cbEstados.SelectedIndex = -1;

                // Restaurar todos los registros originales
                dtProduccion = dtProduccionOriginal.Copy();

                // Volver a la primera página
                paginaActual = 1;

                // Recalcular páginas
                CalcularPaginas();

                // Mostrar nuevamente todos los registros
                MostrarPaginaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los filtros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------
        // MATERIAL UTILIZADO
        private void btnMaterialUtilizado_Click_1(object sender, EventArgs e)
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



