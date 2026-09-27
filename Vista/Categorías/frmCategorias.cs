using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Categorías
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
        }
        // Variables para la paginación
        private DataTable dtCategorias;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private int totalPaginas = 0;
        // CARGA INICIAL DEL FORMULARIO
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga las categorías y estadísticas
                MostrarCategorias();
                CargarEstadisticasCategorias();

                //CONFIGURAR TOOLTIPS
                ConfigurarTooltips();

                // Desactiva copiar y pegar
                DesactivarCopiarPegar(this);

                // Configuración inicial de botones y controles
                btnGuardarCambios.Visible = false;
                btnEditar.Visible = false;
                cbEstado.Enabled = false;

                // Máximo de caracteres permitidos
                txtCategoria.MaxLength = 50;
                txtDescripcion.MaxLength = 200;

                // Orden de navegación con la tecla Tab
                txtCategoria.TabIndex = 1;
                txtDescripcion.TabIndex = 2;
                cbEstado.TabIndex = 3;
                btnGuardar.TabIndex = 4;
                btnEditar.TabIndex = 5;

                // Configura los encabezados del DataGridView
                ConfigurarColumnas();

                // Configurar diseño de la tabla
                ConfigurarTablaCategorias();
                ConfigurarIndicadores();
                ConfigurarBotones();
                ConfigurarBarraBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Guna2Elipse elipseIndicador1;
        private Guna2Elipse elipseIndicador2;
        private Guna2Elipse elipseIndicador3;
        private const string TextoBusqueda = "Buscar...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);

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

            ConfigurarHoverTarjeta(pnlIndicador1);
            ConfigurarHoverTarjeta(pnlIndicador2);
            ConfigurarHoverTarjeta(pnlIndicador3);
        }

        private void Tarjeta_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(245, 175, 160);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(175, 240, 150);

            else if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(245, 238, 225);
        }

        private void Tarjeta_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(235, 157, 145);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(157, 230, 132);

            else if (control == pnlIndicador3)
                control.BackColor = Color.White;
        }

        private void ConfigurarHoverTarjeta(Control tarjeta)
        {
            tarjeta.MouseEnter += Tarjeta_MouseEnter;
            tarjeta.MouseLeave += Tarjeta_MouseLeave;

            foreach (Control control in tarjeta.Controls)
                ConfigurarHoverTarjeta(control);
        }

        private void ConfigurarBotones()
        {
            ConfigurarBoton(btnEditar);
            ConfigurarBoton(btnGuardar);
            ConfigurarBoton(btnGuardarCambios);
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



































        //-------------------------------------------------------------------------
        // CONFIGURAR DISEÑO DE LA TABLA

        private void ConfigurarTablaCategorias()
        {
            // Encabezado
            dgvCategorias.EnableHeadersVisualStyles = false;

            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(121, 75, 45);

            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCategorias.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);

            dgvCategorias.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(121, 75, 45);

            dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            // Filas
            dgvCategorias.DefaultCellStyle.BackColor =
                Color.White;

            dgvCategorias.DefaultCellStyle.ForeColor =
                Color.FromArgb(45, 45, 45);

            dgvCategorias.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);

            dgvCategorias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 241, 232);

            // Selección
            dgvCategorias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(224, 193, 157);

            dgvCategorias.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            // Bordes
            dgvCategorias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCategorias.GridColor =
                Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvCategorias.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvCategorias.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvCategorias.ReadOnly = true;

            dgvCategorias.AllowUserToAddRows = false;

            dgvCategorias.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategorias.MultiSelect = false;

            // Quitar borde exterior
            dgvCategorias.BorderStyle =
                BorderStyle.None;

            // Ajustar contenido
            dgvCategorias.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dgvCategorias.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dgvCategorias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            // Ocultar cuadrito de la izquierda
            dgvCategorias.RowHeadersVisible = false;
        }

        //CONFIGURAR TOOLTIPS--------------------------------------
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            // Configuración del ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            // Campos de la categoría
            toolTip.SetToolTip(txtCategoria, "Ingrese el nombre de la categoría.");
            toolTip.SetToolTip(txtDescripcion, "Ingrese una descripción para la categoría.");
            toolTip.SetToolTip(cbEstado, "Seleccione el estado de la categoría.");

            // Buscador
            toolTip.SetToolTip(txtBuscarCategoria, "Ingrese el nombre de una categoría para buscarla.");

            // Botones
            toolTip.SetToolTip(btnNueva, "Limpia el formulario para registrar una nueva categoría.");
            toolTip.SetToolTip(btnGuardar, "Guarda la nueva categoría.");
            toolTip.SetToolTip(btnEditar, "Permite modificar la categoría seleccionada.");
            toolTip.SetToolTip(btnGuardarCambios, "Guarda los cambios realizados a la categoría.");
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
        //-----------------------------------------------------------------------------------
        //MOSTRAR PAGINA POR CATEGORIA
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
        // Configura los encabezados del DataGridView
        private void ConfigurarColumnas()
        {
            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.Columns["IdCategoria"].HeaderText = "#";
                dgvCategorias.Columns["Nombre_Categoria"].HeaderText = "Categoría";
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
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
        //--------------------------------------------------------------------------
        // REGISTRAR CATEGORÍA

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que exista una categoría seleccionada
                if (idCategoriaSeleccionada == 0)
                {
                    errorProvider1.SetError(txtCategoria, "No hay ninguna categoría seleccionada.");
                    txtCategoria.Focus();
                    return;
                }

                // Valida el nombre
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    errorProvider1.SetError(txtCategoria, "Debe ingresar el nombre de la categoría.");
                    txtCategoria.Focus();
                    return;
                }

                // Valida la descripción
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    errorProvider1.SetError(txtDescripcion, "Debe ingresar la descripción de la categoría.");
                    txtDescripcion.Focus();
                    return;
                }

                // Valida el estado
                if (cbEstado.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbEstado, "Debe seleccionar el estado de la categoría.");
                    cbEstado.Focus();
                    return;
                }

                // Crea el objeto categoría
                Categorias categoria = new Categorias();

                categoria.Nombre_Categoria1 = txtCategoria.Text.Trim();

                categoria.Descripción1 = txtDescripcion.Text.Trim();

                categoria.Estado1 = cbEstado.Text;

                // Inserta la categoría en la base de datos
                bool resultado = categoria.InsertarCategoria();

                if (resultado)
                {
                    MessageBox.Show("Categoría registrada correctamente.", "Registro exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarCategorias();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la categoría: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------------------------------------------------
        // SELECCIONAR CATEGORÍA
        private int idCategoriaSeleccionada = 0;
        // Valores originales de la categoría seleccionada
        private string nombreCategoriaOriginal = "";
        private string descripcionOriginal = "";
        private string estadoOriginal = "";

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Evita seleccionar el encabezado
                if (e.RowIndex < 0 ||
                    dgvCategorias.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }

                // Obtiene el ID de la categoría seleccionada
                idCategoriaSeleccionada = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["IdCategoria"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la categoría: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DOBLE CLIC PARA EDITAR
        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Evita seleccionar el encabezado
                if (e.RowIndex < 0 ||
                    dgvCategorias.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }

                DataGridViewRow fila =
                    dgvCategorias.Rows[e.RowIndex];

                // Obtiene el ID de la categoría
                idCategoriaSeleccionada = Convert.ToInt32(fila.Cells["IdCategoria"].Value);

                // Carga los datos en los controles
                txtCategoria.Text = fila.Cells["Nombre_Categoria"].Value?.ToString() ?? "";

                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString() ?? "";

                cbEstado.Text = fila.Cells["Estado"].Value?.ToString() ?? "";

                // Guarda los valores originales para detectar cambios
                nombreCategoriaOriginal = txtCategoria.Text;
                descripcionOriginal = txtDescripcion.Text;
                estadoOriginal = cbEstado.Text;

                // Bloquea los campos hasta presionar Editar
                BloquearCampos();

                // Configura los botones
                btnEditar.Visible = true;
                btnGuardarCambios.Visible = false;
                btnGuardar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la categoría: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //------------------------------------------------------------
        // BOTON DE EDITAR CATEGORÍA
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que exista una categoría seleccionada
                if (idCategoriaSeleccionada == 0)
                {
                    MessageBox.Show(
                        "No hay ninguna categoría seleccionada."
                    );

                    return;
                }

                // Habilita los campos para editar
                DesbloquearCampos();

                // Cambia los botones
                btnEditar.Visible = false;
                btnGuardarCambios.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al habilitar la edición: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------


        // Habilita los campos para poder modificarlos
        private void DesbloquearCampos()
        {
            txtCategoria.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            cbEstado.Enabled = true;
        }


        // Bloquea los campos cuando no se está editando
        private void BloquearCampos()
        {
            txtCategoria.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            cbEstado.Enabled = false;
        }
        //--------------------------------------------------------------
        //GUARDAR CAMBIOS
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que exista una categoría seleccionada
                if (idCategoriaSeleccionada == 0)
                {
                    errorProvider1.SetError(txtCategoria, "No hay ninguna categoría seleccionada.");
                    txtCategoria.Focus();
                    return;
                }

                // Valida el nombre
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    errorProvider1.SetError(txtCategoria, "Debe ingresar el nombre de la categoría.");
                    txtCategoria.Focus();
                    return;
                }

                // Valida la descripción
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    errorProvider1.SetError(txtDescripcion, "Debe ingresar la descripción de la categoría.");
                    txtDescripcion.Focus();
                    return;
                }

                // Valida el estado
                if (cbEstado.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbEstado, "Debe seleccionar el estado de la categoría.");
                    cbEstado.Focus();
                    return;
                }
                // Obtener los nuevos valores
                string nuevoNombre = txtCategoria.Text.Trim();
                string nuevaDescripcion = txtDescripcion.Text.Trim();
                string nuevoEstado = cbEstado.Text;

                // Verificar si realmente hubo cambios
                bool cambioNombre = nuevoNombre != nombreCategoriaOriginal;
                bool cambioDescripcion = nuevaDescripcion != descripcionOriginal;
                bool cambioEstado = nuevoEstado != estadoOriginal;

                if (!cambioNombre && !cambioDescripcion && !cambioEstado)
                {
                    MessageBox.Show("No se detectaron cambios en la categoría.", "Sin cambios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                // Crear objeto categoría
                Categorias categoria = new Categorias();

                // Envía los datos de la categoría seleccionada
                categoria.IdCategoria1 = idCategoriaSeleccionada;
                categoria.Nombre_Categoria1 = nuevoNombre;
                categoria.Descripción1 = nuevaDescripcion;
                categoria.Estado1 = nuevoEstado;

                // Llama al método ActualizarCategoria
                bool resultado = categoria.ActualizarCategoria();

                if (resultado)
                {
                    // Crear mensaje indicando qué se modificó
                    string cambios = "Se modificó:\n";

                    if (cambioNombre)
                    {
                        cambios += "• Nombre de la categoría\n";
                    }

                    if (cambioDescripcion)
                    {
                        cambios += "• Descripción\n";
                    }

                    if (cambioEstado)
                    {
                        cambios += "• Estado: " + estadoOriginal + " → " + nuevoEstado + "\n";
                    }

                    MessageBox.Show("Categoría actualizada correctamente.\n\n" + cambios, "Actualización exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar tabla
                    MostrarCategorias();

                    // Actualizar estadísticas
                    CargarEstadisticasCategorias();

                    // Limpiar formulario
                    LimpiarFormulario();

                    // Limpiar valores originales
                    nombreCategoriaOriginal = "";
                    descripcionOriginal = "";
                    estadoOriginal = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //------------------------------------------------------
        //BUSQUEDA
        private void txtBuscarCategoria_Enter(object sender, EventArgs e)
        {
            //Cuando el usuario de enter para escribir, se va a borrar el texto de indicacion
            // Y el texto ya no sera opaco, sera color negro
            if (txtBuscarCategoria.Text == "Buscar Categoría...")
            {
                txtBuscarCategoria.Text = "";
                txtBuscarCategoria.ForeColor = Color.Black;

            }
        }

        private void txtBuscarCategoria_Leave(object sender, EventArgs e)
        {
            // Vuelve a mostrar el texto de indicación
            if (string.IsNullOrWhiteSpace(txtBuscarCategoria.Text))
            {
                txtBuscarCategoria.Text = "Buscar Categoría...";
                txtBuscarCategoria.ForeColor = Color.Gray;
            }
        }
        // Realiza la búsqueda de categorías
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCategoria.Text == "Buscar Categoría...")
                {
                    return;
                }

                dgvCategorias.DataSource = null;

                dgvCategorias.DataSource = Categorias.Buscar(txtBuscarCategoria.Text.Trim());

                ConfigurarColumnas();

                // Mantener el diseño después de buscar
                ConfigurarTablaCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // Actualiza la tabla cuando se borra el texto de búsqueda
        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtBuscarCategoria.Text))
                {
                    MostrarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la búsqueda: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //-------------------------------------------------------------

        // ESTADÍSTICAS
        private void CargarEstadisticasCategorias()
        {
            try
            {
                // Cantidad total de categorías
                lblCategoriasRegistradas.Text = Categorias.ContarCategoriasTotales().ToString();

                // Cantidad de categorías activas
                lblCategoriasActivas.Text = Categorias.ContarCategoriasActivas().ToString();

                // Cantidad de categorías inactivas
                lblCategoriasInactivas.Text = Categorias.ContarCategoriasInactivas().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------
        // NUEVA CATEGORÍA
        private void btnNueva_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        //-----------------------------------------------------------------------
        // Limpia los controles para registrar una nueva categoría
        private void LimpiarFormulario()
        {
            txtCategoria.Clear();
            txtDescripcion.Clear();

            cbEstado.SelectedIndex = -1;

            idCategoriaSeleccionada = 0;

            // Habilita los campos
            txtCategoria.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            cbEstado.Enabled = true;

            // Configura los botones
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnGuardarCambios.Visible = false;

            txtCategoria.Focus();
        }
        //--------------------------------------------------------------------
        // VALIDACIONES DE TECLADO
        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }


        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //letterOrDigith comprueba si es letra o numero
            // IsControl permite espacios
            // ´ ´solo se permite un espacio, no mas 
            // tmb permite ","
            //permite "."
            // permite "-"
            // y permite ()
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }
        //---------------------------------------------------------------
        // DESACTIVAR COPIAR Y PEGAR
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
    }
}

