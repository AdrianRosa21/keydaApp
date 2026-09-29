using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Categorias_Inventario_Empleado
{
    public partial class frmCategoriasInventarioSecretario : Form
    {
        public frmCategoriasInventarioSecretario()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
        }

        // DATOS PARA LA PAGINACIÓN
        private DataTable dtCategorias;
        private int paginaActual = 1;
        private int registrosPorPagina = 20;
        private int totalPaginas = 0;

        private const string TextoBusqueda = "Buscar...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);

        private void ConfigurarBarraBusqueda()
        {
            ConfigurarBusqueda(txtBuscarCategoria);

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
        // CARGA INICIAL DEL FORMULARIO
        private void frmCategoriasInventarioSecretario_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga las categorías y estadísticas
                MostrarCategorias();
                CargarEstadisticasCategorias();

                // CONFIGURAR TOOLTIPS
                ConfigurarTooltips();

                // Configuración inicial de la tabla
                ConfigurarColumnas();
                ConfigurarTablaCategorias();
                ConfigurarBarraBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------
        // CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            // Configuración del ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            // Buscador
            toolTip.SetToolTip(txtBuscarCategoria, "Ingrese el nombre de una categoría para buscarla.");

            // Paginación
            toolTip.SetToolTip(btnAnterior, "Muestra la página anterior.");
            toolTip.SetToolTip(btnSiguiente, "Muestra la página siguiente.");

            // Tabla
            toolTip.SetToolTip(dgvCategorias, "Muestra las categorías registradas.");
        }

        //---------------------------------------------------------
        // MOSTRAR CATEGORÍAS

        public void MostrarCategorias()
        {
            try
            {
                // Cargar todas las categorías
                dtCategorias = Categorias.CargarCategorias();

                // Iniciar desde la primera página
                paginaActual = 1;

                // Calcular cantidad de páginas
                CalcularPaginasCategorias();

                // Mostrar la primera página
                MostrarPaginaCategorias();

                // Actualiza las estadísticas
                CargarEstadisticasCategorias();

                // Configura los nombres de las columnas
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las categorías: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------
        // CALCULAR PAGINACIÓN

        private void CalcularPaginasCategorias()
        {
            if (dtCategorias == null || dtCategorias.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling((double)dtCategorias.Rows.Count / registrosPorPagina);

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }

        //---------------------------------------------------------
        // MOSTRAR PÁGINA DE CATEGORÍAS

        private void MostrarPaginaCategorias()
        {
            if (dtCategorias == null)
                return;

            DataTable dtPagina = dtCategorias.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtCategorias.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtCategorias.Rows[i]);
            }

            // Mostrar únicamente los registros de la página actual
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = dtPagina;

            // Configura los nombres de las columnas
            ConfigurarColumnas();

            // Configurar diseño de la tabla
            ConfigurarTablaCategorias();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;

            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        //---------------------------------------------------------
        // CONFIGURAR COLUMNAS

        private void ConfigurarColumnas()
        {
            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.Columns["IdCategoria"].HeaderText = "#";
                dgvCategorias.Columns["Nombre_Categoria"].HeaderText = "Categoría";
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
                dgvCategorias.Columns["Estado"].HeaderText = "Estado";
            }
        }


        //---------------------------------------------------------
        // CONFIGURAR DISEÑO DE LA TABLA
        private void ConfigurarTablaCategorias()
        {
            // Configuración general
            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.AllowUserToResizeColumns = false;

            // Encabezado
            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Altura del encabezado
            dgvCategorias.ColumnHeadersHeight = 40;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvCategorias.DefaultCellStyle.BackColor = Color.White;
            dgvCategorias.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvCategorias.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvCategorias.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategorias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvCategorias.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Filas alternadas
            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Altura de las filas
            dgvCategorias.RowTemplate.Height = 36;
            dgvCategorias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Bordes
            dgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategorias.GridColor = Color.FromArgb(220, 220, 220);
            dgvCategorias.BorderStyle = BorderStyle.None;

            // Selección
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;

            // Ajustar columnas
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bloquear tamaño del encabezado lateral
            dgvCategorias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Ocultar cuadrito de la izquierda
            dgvCategorias.RowHeadersVisible = false;
        }

        //--------------------------------------------------------------------------
        //BUSQUEDA
        private void txtBuscarCategoria_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCategoria.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscarCategoria.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtCategorias = null;
                    MostrarCategorias();
                    return;
                }

                dtCategorias = Categorias.Buscar(buscar);

                int totalResultados = dtCategorias.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPaginaCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar categorías.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------

        // ESTADÍSTICAS
        private void CargarEstadisticasCategorias()
        {
            try
            {
                lblCategoriasRegistradas.Text = Categorias.ContarCategoriasTotales().ToString();
                lblCategoriasActivas.Text = Categorias.ContarCategoriasActivas().ToString();
                lblCategoriasInactivas.Text = Categorias.ContarCategoriasInactivas().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                MostrarPaginaCategorias();
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                MostrarPaginaCategorias();
            }
        }


    }
}
