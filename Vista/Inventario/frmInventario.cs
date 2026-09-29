using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Inventario
{
    public partial class frmInventario : Form
    {
        // PAGINACIÓN
        private DataTable dtInventario;
        private int paginaActual = 1;
        private int registrosPorPagina = 20;
        private int totalPaginas = 0;

        public frmInventario()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
        }
        private Guna2Elipse elipseIndicador;
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
                TargetControl = pnlIndicador,
                BorderRadius = 12
            };

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

            ConfigurarHoverTarjeta(pnlIndicador);
            ConfigurarHoverTarjeta(pnlIndicador1);
            ConfigurarHoverTarjeta(pnlIndicador2);
            ConfigurarHoverTarjeta(pnlIndicador3);
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
                   control != pnlIndicador &&
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador)
                control.BackColor = Color.FromArgb(245, 175, 160);

            else if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(175, 240, 150);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(255, 210, 145);

            else if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(245, 238, 225);
        }

        private void Tarjeta_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null &&
                   control != pnlIndicador &&
                   control != pnlIndicador1 &&
                   control != pnlIndicador2 &&
                   control != pnlIndicador3)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador)
                control.BackColor = Color.FromArgb(235, 157, 145);

            else if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(157, 230, 132);

            else if (control == pnlIndicador2)
                control.BackColor = Color.FromArgb(245, 185, 115);

            else if (control == pnlIndicador3)
                control.BackColor = Color.White;
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

        //-----------------------------------------------------------------------------------------------------------------------------------------------

        private void CargarPaginacion()
        {
            try
            {
                // Cargar todos los materiales
                dtInventario = Material.CargarMateriales();

                // Calcular el total de páginas
                totalPaginas = (int)Math.Ceiling((double)dtInventario.Rows.Count / registrosPorPagina);

                // Si no hay registros
                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }

                // Evitar que la página actual sea mayor al total
                if (paginaActual > totalPaginas)
                {
                    paginaActual = totalPaginas;
                }

                MostrarPagina();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarPagina()
        {
            if (dtInventario == null)
                return;

            DataTable dtPagina = dtInventario.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtInventario.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtInventario.Rows[i]);
            }

            dgvMateriales.DataSource = dtPagina;

            // Encabezados de las columnas
            if (dgvMateriales.Columns.Contains("IdMaterial"))
                dgvMateriales.Columns["IdMaterial"].HeaderText = "#";

            if (dgvMateriales.Columns.Contains("UnidadMedida"))
                dgvMateriales.Columns["UnidadMedida"].HeaderText = "Unidad de medida";

            // Configurar diseño de la tabla
            ConfigurarTablaInventario();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar/desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        //-------------------------------------------------------------------------
        // CONFIGURAR DISEÑO DE LA TABLA
        private void ConfigurarTablaInventario()
        {
            // Configuración general
            dgvMateriales.AutoGenerateColumns = true;
            dgvMateriales.EnableHeadersVisualStyles = false;
            dgvMateriales.AllowUserToAddRows = false;
            dgvMateriales.AllowUserToDeleteRows = false;
            dgvMateriales.AllowUserToResizeRows = false;
            dgvMateriales.AllowUserToResizeColumns = false;
            dgvMateriales.ReadOnly = true;
            dgvMateriales.MultiSelect = false;
            dgvMateriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMateriales.RowHeadersVisible = false;
            dgvMateriales.BorderStyle = BorderStyle.None;
            dgvMateriales.BackgroundColor = Color.White;
            dgvMateriales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMateriales.GridColor = Color.FromArgb(225, 225, 225);

            // Altura del encabezado
            dgvMateriales.ColumnHeadersHeight = 40;
            dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Altura de las filas
            dgvMateriales.RowTemplate.Height = 36;

            // No cambiar automáticamente la altura
            dgvMateriales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Ajustar columnas
            dgvMateriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Encabezado
            dgvMateriales.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 75, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 75, 45),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            // Filas
            dgvMateriales.DefaultCellStyle = new DataGridViewCellStyle
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
            dgvMateriales.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 246, 240),
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35)
            };

            // Fila seleccionada
            dgvMateriales.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 215, 185);
            dgvMateriales.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 45, 35);

            // No permitir ordenar
            foreach (DataGridViewColumn columna in dgvMateriales.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void MostrarInventario()
        {
            paginaActual = 1;

            CargarPaginacion();

            CargarEstadisticasInventario();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        // CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();
            // Buscador
            toolTip.SetToolTip(txtBuscar, "Busca un material por su nombre.");

            // Datos del material
            toolTip.SetToolTip(txtMaterial, "Ingrese el nombre del material.");
            toolTip.SetToolTip(cbCategorias, "Seleccione la categoría a la que pertenece el material.");
            toolTip.SetToolTip(cbUnidadMedida, "Seleccione la unidad de medida del material.");
            toolTip.SetToolTip(txtCantidad, "Ingrese la cantidad disponible del material.");

            // Botones
            toolTip.SetToolTip(btnNuevo, "Limpia el formulario para registrar un nuevo material.");
            toolTip.SetToolTip(btnGuardar, "Guarda el nuevo material en el inventario.");
            toolTip.SetToolTip(btnEditar, "Permite modificar los datos del material seleccionado.");
            toolTip.SetToolTip(btnGuardarCambios, "Guarda los cambios realizados al material.");

            // Tabla
            toolTip.SetToolTip(dgvMateriales, "Muestra los materiales registrados en el inventario. Haz doble clic en un material para seleccionarlo.");

            // Estadísticas
            toolTip.SetToolTip(lblTotalRegistrados, "Cantidad total de materiales registrados.");
            toolTip.SetToolTip(lblAgotandose, "Cantidad de materiales cuyo stock está próximo a agotarse.");
            toolTip.SetToolTip(lblDisponibles, "Cantidad de materiales disponibles actualmente.");
            toolTip.SetToolTip(lblMaterialesAgotados, "Cantidad de materiales que se encuentran agotados.");
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            MostrarInventario();

            CargarComboBoxCategorias();

            CargarComboBoxUnidadDeMedida();

            DesactivarCopiarPegar(this);

            //CONFIGURA LOS TOOLTIPS
            ConfigurarTooltips();
            ConfigurarBarraBusqueda();

            // Configurar diseño de la tabla
            ConfigurarTablaInventario();

            btnGuardarCambios.Visible = false;
            btnEditar.Visible = false;

            //Navegar con la tecla Tab
            txtMaterial.TabIndex = 1;
            cbCategorias.TabIndex = 2;
            txtCantidad.TabIndex = 3;
            cbUnidadMedida.TabIndex = 4;
            btnGuardar.TabIndex = 5;
            btnEditar.TabIndex = 6;

            //Maximo de caracteres admitidos
            txtMaterial.MaxLength = 100;

            txtCantidad.MaxLength = 100000;

            CargarEstadisticasInventario();
            ConfigurarIndicadores();
        }

        //Combo box para cargar categorias
        private void CargarComboBoxCategorias()
        {
            //Llamar al metodo de las categorias
            DataTable dtCategoria = Categorias.CargarCategorias();
            cbCategorias.DataSource = dtCategoria;
            cbCategorias.DisplayMember = "Nombre_Categoria";
            cbCategorias.ValueMember = "IdCategoria";
            cbCategorias.SelectedIndex = -1;
            cbCategorias.DropDownStyle = ComboBoxStyle.DropDown;
            cbCategorias.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCategorias.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Combo box para mostrar las unidades de medida registradas en la base de datos
        private void CargarComboBoxUnidadDeMedida()
        {
            DataTable dtUnidades = new DataTable();
            //Llamar al metodo de las unidades de medida
            DataTable dtUnidadMedida = UnidadMedida.CargarUnidadesDeMedida();
            cbUnidadMedida.DataSource = dtUnidadMedida;
            cbUnidadMedida.DisplayMember = "UnidadMedida";
            cbUnidadMedida.ValueMember = "IdUnidadMedida";
            cbUnidadMedida.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar nombre del material
            if (string.IsNullOrWhiteSpace(txtMaterial.Text))
            {
                errorProvider1.SetError(txtMaterial, "Ingrese el nombre del material.");
                MessageBox.Show("Ingrese el nombre del material.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterial.Focus();
                return;
            }

            // Validar unidad de medida
            if (string.IsNullOrWhiteSpace(cbUnidadMedida.Text))
            {
                errorProvider1.SetError(cbUnidadMedida, "Ingrese la unidad de medida.");
                MessageBox.Show("Ingrese la unidad de medida.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbUnidadMedida.Focus();
                return;
            }

            // Validar categoría
            if (cbCategorias.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCategorias, "Seleccione una categoría.");
                MessageBox.Show("Seleccione una categoría.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategorias.Focus();
                return;
            }

            // Validar stock inicial
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                errorProvider1.SetError(txtCantidad, "Ingrese el stock inicial.");
                MessageBox.Show("Ingrese el stock inicial.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            // Validar que el stock sea numérico
            if (!int.TryParse(txtCantidad.Text, out int stock))
            {
                errorProvider1.SetError(txtCantidad, "El stock inicial debe ser un número.");
                MessageBox.Show("El stock inicial debe ser un número.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            // Validar que no sea negativo
            if (stock < 0)
            {
                errorProvider1.SetError(txtCantidad, "El stock inicial no puede ser negativo.");
                MessageBox.Show("El stock inicial no puede ser negativo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            //INSERT
            Material material = new Material();

            material.idMaterial1 = 0;
            material.NombreDelMaterial1 = txtMaterial.Text;
            material.UnidadDeMedida1 = Convert.ToInt32(cbUnidadMedida.SelectedValue);
            material.Stock1 = 0;
            material.Categoria1 = cbCategorias.Text;

            bool resultado = material.InsertarMateriales();

            if (resultado)
            {
                MessageBox.Show("Material registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MostrarInventario();
            LimpiarFormulario();


        }
        private int idMaterialSeleccionado = 0;
        // Valores originales del material seleccionado
        private string nombreMaterialOriginal = "";
        private string unidadMedidaOriginal = "";
        private string stockOriginal = "";
        private string categoriaOriginal = "";

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idMaterialSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un material primero.");
                return;
            }
            HabilitarCampos();
            btnGuardarCambios.Visible = true;
        }
        private void BloquearCampos()
        {
            txtMaterial.ReadOnly = true;
            cbUnidadMedida.Enabled = false;
            cbCategorias.Enabled = false;
            txtCantidad.ReadOnly = true;

            btnEditar.Visible = true;
            btnGuardar.Visible = false;
        }

        private void HabilitarCampos()
        {
            txtMaterial.ReadOnly = false;
            cbUnidadMedida.Enabled = true;
            cbCategorias.Enabled = true;
            txtCantidad.ReadOnly = false;

            btnEditar.Visible = true;
            btnGuardar.Visible = false;

            btnGuardarCambios.Visible = true;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idMaterialSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un material primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool cambioNombre = txtMaterial.Text != nombreMaterialOriginal;
            bool cambioUnidad = cbUnidadMedida.Text != unidadMedidaOriginal;
            bool cambioStock = txtCantidad.Text != stockOriginal;
            bool cambioCategoria = cbCategorias.Text != categoriaOriginal;

            if (!cambioNombre && !cambioUnidad && !cambioStock && !cambioCategoria)
            {
                MessageBox.Show("No se detectaron cambios en el material.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cambios = "Se realizaron los siguientes cambios:\n\n";

            if (cambioNombre)
                cambios += "• Material: " + nombreMaterialOriginal + " → " + txtMaterial.Text + "\n";

            if (cambioUnidad)
                cambios += "• Unidad de medida: " + unidadMedidaOriginal + " → " + cbUnidadMedida.Text + "\n";

            if (cambioStock)
                cambios += "• Stock: " + stockOriginal + " → " + txtCantidad.Text + "\n";

            if (cambioCategoria)
                cambios += "• Categoría: " + categoriaOriginal + " → " + cbCategorias.Text + "\n";

            Material material = new Material();

            material.idMaterial1 = idMaterialSeleccionado;
            material.NombreDelMaterial1 = txtMaterial.Text;
            material.UnidadDeMedida1 = Convert.ToInt32(cbUnidadMedida.SelectedValue);
            material.Stock1 = Convert.ToInt32(txtCantidad.Text);
            material.Categoria1 = cbCategorias.Text;

            if (material.ActualizarMaterial())
            {
                MessageBox.Show(cambios, "Material actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarInventario();

                btnGuardarCambios.Visible = false;
                btnEditar.Visible = true;
                btnGuardar.Visible = true;

                txtMaterial.ReadOnly = true;
                cbUnidadMedida.Enabled = false;
                txtCantidad.ReadOnly = true;
                cbCategorias.Enabled = false;

                idMaterialSeleccionado = 0;
            }

            CargarEstadisticasInventario();
            LimpiarFormulario();
        }

        private void dgvMateriales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || dgvMateriales.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow fila = dgvMateriales.Rows[e.RowIndex];

            idMaterialSeleccionado = Convert.ToInt32(fila.Cells["IdMaterial"].Value);

            txtMaterial.Text = fila.Cells["Material"].Value?.ToString() ?? "";

            cbUnidadMedida.Text = fila.Cells["UnidadMedida"].Value?.ToString() ?? "";

            txtCantidad.Text = fila.Cells["Stock"].Value?.ToString() ?? "";

            cbCategorias.Text = fila.Cells["Categoria"].Value?.ToString() ?? "";

            // Guardar los valores originales para detectar cambios
            nombreMaterialOriginal = txtMaterial.Text;
            unidadMedidaOriginal = cbUnidadMedida.Text;
            stockOriginal = txtCantidad.Text;
            categoriaOriginal = cbCategorias.Text;

            btnEditar.Visible = true;

            dgvMateriales.Columns["IdMaterial"].HeaderText = "#";
            dgvMateriales.Columns["UnidadMedida"].HeaderText = "Unidad de medida";

            BloquearCampos();
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

        private void txtMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMaterial.MaxLength = 100;

            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //METODO PARA CARGAR LAS ESTADISTICAS
        private void CargarEstadisticasInventario()
        {
            try
            {
                lblTotalRegistrados.Text = Material.ContarMaterialesTotales().ToString();
                lblAgotandose.Text = Material.ContarMaterialesAgotandose().ToString();
                lblDisponibles.Text = Material.ContarMaterialesDisponibles().ToString();
                lblMaterialesAgotados.Text = Material.ContarMaterialesAgotados().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas del inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtMaterial.Clear();

            txtCantidad.Clear();

            btnEditar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            cbCategorias.SelectedIndex = -1;
            cbUnidadMedida.SelectedIndex = -1;

            txtMaterial.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "Buscar...")
                    return;

                string buscar = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtInventario = null;
                    MostrarInventario();
                    return;
                }

                dtInventario = Material.BuscarMaterial(buscar);

                int totalResultados = dtInventario.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina
                );

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPagina();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar materiales.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void cbCategorias_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void cbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }
    }
}




