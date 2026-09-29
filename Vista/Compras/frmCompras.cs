using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Compras
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);

            ConfigurarBotones();
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
            ConfigurarBoton(btnActualizar);
            ConfigurarBoton(btnGuardar);
            ConfigurarBoton(btnAgregarProductos);
            ConfigurarBoton(btnCancelar);
            ConfigurarBoton(btnActualizarCompra);
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

        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        // VARIABLES PARA COMPRA Y DETALLES

        // Id de la compra que estamos editando.
        // 0 significa que estamos creando una compra nueva.
        private int idCompraSeleccionada = 0;

        // Indica si estamos creando o editando.
        private bool modoEdicion = false;

        // Detalles que el usuario est creando/modificando.
        private List<DetalleCompraMaterial> detallesTemporales = new List<DetalleCompraMaterial>();

        // Detalles originales de una compra cuando se carga para editar.
        private List<DetalleCompraMaterial> detallesOriginales = new List<DetalleCompraMaterial>();

        // VARIABLES PARA LA PAGINACIÓN
        private DataTable dtCompras;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private int totalPaginas = 0;
        private int idDetalleEditando = 0;
        private decimal totalCompra = 0;

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            //Cuando el usuario de enter para escribir, se va a borrar el texto de indicacion
            // Y el texto ya no sera opaco, sera color negro
            if (txtBuscar.Text == "Buscar Compra...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;

            }
        }
        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar compra...";
                txtBuscar.ForeColor = Color.Gray;
            }

        }
        private void ConfigurarTooltips()
        {
            ToolTip toolTip = new ToolTip();

            // Configuración del ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            // Búsqueda
            toolTip.SetToolTip(txtBuscar, "Busca una compra por su número, fecha o proveedor.");
            // Datos de la compra
            toolTip.SetToolTip(cbProveedor, "Seleccione el proveedor de la compra.");
            toolTip.SetToolTip(dtpFechaDeCompra, "Seleccione la fecha en que se realizó la compra.");
            // Datos del material
            toolTip.SetToolTip(cbMaterial, "Seleccione el material que desea agregar a la compra.");
            toolTip.SetToolTip(nudCantidad, "Indique la cantidad de unidades del material.");
            toolTip.SetToolTip(txtPrecioUnitario, "Ingrese el precio de una unidad del material.");
            // Botones de materiales
            toolTip.SetToolTip(btnAgregarProductos, "Agrega el material seleccionado a la compra.");
            toolTip.SetToolTip(btnActualizar, "Actualiza los datos del material seleccionado.");
            // Total
            toolTip.SetToolTip(txtTotalCompra, "Muestra el total de la compra.");
            // Botones de compra
            toolTip.SetToolTip(btnNueva, "Limpia el formulario para registrar una nueva compra.");
            toolTip.SetToolTip(btnGuardar, "Guarda la compra y sus materiales.");
            toolTip.SetToolTip(btnActualizarCompra, "Guarda los cambios realizados en la compra seleccionada.");
            toolTip.SetToolTip(btnCancelar, "Elimina la compra seleccionada y ajusta el inventario.");
        }

        // CONFIGURAR DISEÑO DE LAS TABLAS
        private void ConfigurarTablasCompras()
        {
            // TABLA HISTORIAL DE COMPRAS

            // Encabezado
            dgvHistorialCompras.EnableHeadersVisualStyles = false;
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvHistorialCompras.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvHistorialCompras.DefaultCellStyle.BackColor = Color.White;
            dgvHistorialCompras.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvHistorialCompras.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvHistorialCompras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvHistorialCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvHistorialCompras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvHistorialCompras.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvHistorialCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorialCompras.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvHistorialCompras.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvHistorialCompras.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvHistorialCompras.ReadOnly = true;
            dgvHistorialCompras.AllowUserToAddRows = false;
            dgvHistorialCompras.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvHistorialCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialCompras.MultiSelect = false;

            // Quitar borde exterior
            dgvHistorialCompras.BorderStyle = BorderStyle.None;


            // TABLA DETALLE DE COMPRAS

            // Encabezado
            dgvDetalleCompras.EnableHeadersVisualStyles = false;
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvDetalleCompras.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvDetalleCompras.DefaultCellStyle.BackColor = Color.White;
            dgvDetalleCompras.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvDetalleCompras.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvDetalleCompras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvDetalleCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvDetalleCompras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvDetalleCompras.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvDetalleCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleCompras.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvDetalleCompras.RowTemplate.Height = 32;

            // Alto del encabezado
            dgvDetalleCompras.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvDetalleCompras.ReadOnly = true;
            dgvDetalleCompras.AllowUserToAddRows = false;
            dgvDetalleCompras.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvDetalleCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleCompras.MultiSelect = false;

            // Quitar borde exterior
            dgvDetalleCompras.BorderStyle = BorderStyle.None;
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            MostrarCompras();

            ConfigurarDetalleCompra();
            CargarComboBoxMateriales();
            CargarComboBoxProveedores();

            //Configurar tooltips
            ConfigurarTooltips();
            ConfigurarBarraBusqueda();

            DesactivarCopiarPegar(this);

            btnGuardar.Visible = true;
            btnActualizarCompra.Visible = false;

            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;

            txtTotalCompra.Text = "0.00";
            //Navegar con TabIndex
            cbProveedor.TabIndex = 0;
            dtpFechaDeCompra.TabIndex = 1;
            cbMaterial.TabIndex = 2;
            nudCantidad.TabIndex = 3;
            txtPrecioUnitario.TabIndex = 4;
            btnAgregarProductos.TabIndex = 5;
            btnActualizar.TabIndex = 6;

            // No se podra seleccionar fechas futuras
            dtpFechaDeCompra.MaxDate = DateTime.Today;
            dtpFechaDeCompra.Value = DateTime.Today;

            dgvHistorialCompras.Columns["IdCompra"].HeaderText = "N.º de compra";
            dgvHistorialCompras.Columns["FechaCompra"].HeaderText = "Fecha de compra";
            dgvHistorialCompras.Columns["Proveedor"].HeaderText = "Proveedor";
            dgvHistorialCompras.Columns["TotalCompra"].HeaderText = "Total de compra";

            dgvDetalleCompras.Columns["Material"].HeaderText = "Material";
            dgvDetalleCompras.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalleCompras.Columns["PrecioUnitario"].HeaderText = "Precio unitario";
            dgvDetalleCompras.Columns["Subtotal"].HeaderText = "Subtotal";

            // Aplicar diseño de las tablas
            ConfigurarTablasCompras();


        }
        private void MostrarCompras()
        {
            try
            {
                // Cargar todas las compras
                dtCompras = ComprasDb.CargarComprasRegistradas();

                // Iniciar desde la primera página
                paginaActual = 1;

                // Calcular cantidad de páginas
                CalcularPaginasCompras();

                // Mostrar la primera página
                MostrarPaginaCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las compras: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularPaginasCompras()
        {
            if (dtCompras == null || dtCompras.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling(
                (double)dtCompras.Rows.Count / registrosPorPagina
            );

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }

        private void MostrarPaginaCompras()
        {
            if (dtCompras == null)
                return;

            DataTable dtPagina = dtCompras.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(
                inicio + registrosPorPagina,
                dtCompras.Rows.Count
            );

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtCompras.Rows[i]);
            }

            // Mostrar únicamente los registros de la página actual
            dgvHistorialCompras.DataSource = null;
            dgvHistorialCompras.DataSource = dtPagina;

            // Configurar encabezados
            dgvHistorialCompras.Columns["IdCompra"].HeaderText = "N.º de compra";
            dgvHistorialCompras.Columns["FechaCompra"].HeaderText = "Fecha de compra";
            dgvHistorialCompras.Columns["Proveedor"].HeaderText = "Proveedor";
            dgvHistorialCompras.Columns["TotalCompra"].HeaderText = "Total de compra";

            // Aplicar diseño
            ConfigurarTablasCompras();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {

            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPaginaCompras();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPaginaCompras();
            }
        }


        private void CargarComboBoxMateriales()
        {
            DataTable dtMaterial = Material.CargarMateriales();

            cbMaterial.DataSource = dtMaterial;
            cbMaterial.DisplayMember = "Material";
            cbMaterial.ValueMember = "IdMaterial";
            cbMaterial.SelectedIndex = -1;
            cbMaterial.DropDownStyle = ComboBoxStyle.DropDown;
            cbMaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaterial.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarComboBoxProveedores()
        {
            DataTable dtProveedor = DbProveedor.CargarProveedor();

            cbProveedor.DataSource = dtProveedor;
            cbProveedor.DisplayMember = "Proveedor";
            cbProveedor.ValueMember = "IdProveedor";
            cbProveedor.SelectedIndex = -1;
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDown;
            cbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private string ObtenerNombreMaterial(int idMaterial)
        {
            DataTable dt = Material.CargarMateriales();

            foreach (DataRow fila in dt.Rows)
            {
                if (Convert.ToInt32(fila["IdMaterial"]) == idMaterial)
                {
                    return fila["Material"].ToString();
                }
            }

            return "";
        }

        private void ConfigurarDetalleCompra()
        {
            dgvDetalleCompras.Columns.Clear();

            dgvDetalleCompras.AutoGenerateColumns = false;
            dgvDetalleCompras.AllowUserToAddRows = false;
            dgvDetalleCompras.ReadOnly = true;

            dgvDetalleCompras.ColumnHeadersVisible = true;
            dgvDetalleCompras.RowHeadersVisible = false;

            // ID MATERIAL
            DataGridViewTextBoxColumn idMaterial =
                new DataGridViewTextBoxColumn();

            idMaterial.Name = "IdMaterial";
            idMaterial.HeaderText = "IdMaterial";
            idMaterial.Visible = false;

            dgvDetalleCompras.Columns.Add(idMaterial);


            // MATERIAL
            DataGridViewTextBoxColumn material = new DataGridViewTextBoxColumn();

            material.Name = "Material";
            material.HeaderText = "Material";

            dgvDetalleCompras.Columns.Add(material);


            // CANTIDAD
            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();

            cantidad.Name = "Cantidad";
            cantidad.HeaderText = "Cantidad";

            dgvDetalleCompras.Columns.Add(cantidad);


            // PRECIO UNITARIO
            DataGridViewTextBoxColumn precio = new DataGridViewTextBoxColumn();

            precio.Name = "PrecioUnitario";
            precio.HeaderText = "Precio Unitario";

            dgvDetalleCompras.Columns.Add(precio);


            // SUBTOTAL
            DataGridViewTextBoxColumn subtotal = new DataGridViewTextBoxColumn();

            subtotal.Name = "Subtotal";
            subtotal.HeaderText = "Subtotal";

            dgvDetalleCompras.Columns.Add(subtotal);

            //ID DETALLE DE COMPRA
            DataGridViewTextBoxColumn idDetalle = new DataGridViewTextBoxColumn();

            idDetalle.Name = "IdDetalleCompraMaterial";
            idDetalle.HeaderText = "IdDetalleCompraMaterial";
            idDetalle.Visible = false;

            dgvDetalleCompras.Columns.Add(idDetalle);

            // ELIMINAR
            DataGridViewButtonColumn eliminar = new DataGridViewButtonColumn();

            eliminar.Name = "Eliminar";
            eliminar.HeaderText = "Eliminar";
            eliminar.Text = "Eliminar";
            eliminar.UseColumnTextForButtonValue = true;

            dgvDetalleCompras.Columns.Add(eliminar);


            // Ajustar columnas
            dgvDetalleCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // Ajustar columnas
            dgvDetalleCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Aplicar diseño
            ConfigurarTablasCompras();

        }
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                errorProvider1.SetError(txtPrecioUnitario, "Ingresa un precio válido.");
                MessageBox.Show("Ingresa un precio válido.", "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }
            int cantidad = Convert.ToInt32(nudCantidad.Value);

            int idMaterial = Convert.ToInt32(cbMaterial.SelectedValue);

            // Buscar el detalle que estamos editando
            foreach (DetalleCompraMaterial detalle in detallesTemporales)
            {
                if (detalle.IdDetalleCompraMaterial1 == idDetalleEditando)
                {
                    detalle.IdMaterial1 = idMaterial;
                    detalle.Cantidad1 = cantidad;
                    detalle.PrecioUnitario1 = precio;

                    break;
                }
            }

            // Mostrar nuevamente los materiales
            MostrarDetallesTemporales();

            // Limpiar SOLO los controles para ingresar/editar otro material
            cbMaterial.SelectedIndex = -1;
            nudCantidad.Value = 1;
            txtPrecioUnitario.Clear();

            // Reiniciar el detalle que se está editando
            idDetalleEditando = 0;
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            // Validar material
            if (cbMaterial.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbMaterial, "Selecciona un material.");
                MessageBox.Show("Selecciona un material.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaterial.Focus();
                return;
            }

            // Validar que el precio no esté vacío
            if (string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                errorProvider1.SetError(txtPrecioUnitario, "Ingresa el precio unitario.");
                MessageBox.Show("Ingresa el precio unitario.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }

            // Validar que el precio sea numérico
            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                errorProvider1.SetError(txtPrecioUnitario, "Ingresa un precio válido.");
                MessageBox.Show("Ingresa un precio válido.", "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }

            // Validar que el precio sea mayor que 0
            if (precio <= 0)
            {
                errorProvider1.SetError(txtPrecioUnitario, "El precio unitario debe ser mayor que 0.");
                MessageBox.Show("El precio unitario debe ser mayor que 0.", "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }

            // Obtener cantidad
            int cantidad = Convert.ToInt32(nudCantidad.Value);

            // Validar cantidad
            if (cantidad <= 0)
            {
                errorProvider1.SetError(nudCantidad, "La cantidad debe ser mayor que 0.");
                MessageBox.Show("La cantidad debe ser mayor que 0.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }

            int idMaterial = Convert.ToInt32(cbMaterial.SelectedValue);

            // Verificar si ya está en la lista
            foreach (DetalleCompraMaterial detalle in detallesTemporales)
            {
                if (detalle.IdMaterial1 == idMaterial)
                {
                    MessageBox.Show("Este material ya está agregado.", "Material duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string nombreMaterial = cbMaterial.Text;

            // Crear detalle
            DetalleCompraMaterial nuevoDetalle = new DetalleCompraMaterial(0, idCompraSeleccionada, idMaterial, cantidad, precio);

            // Agregar a la lista temporal
            detallesTemporales.Add(nuevoDetalle);

            // Mostrar en el DataGridView
            MostrarDetallesTemporales();

            // Limpiar controles
            cbMaterial.SelectedIndex = -1;
            nudCantidad.Value = 1;
            txtPrecioUnitario.Clear();
        }

        private void MostrarDetallesTemporales()
        {
            dgvDetalleCompras.Rows.Clear();

            foreach (DetalleCompraMaterial detalle in detallesTemporales)
            {
                string nombreMaterial = ObtenerNombreMaterial(detalle.IdMaterial1);

                decimal subtotal =
                    detalle.Cantidad1 * detalle.PrecioUnitario1;

                int indice = dgvDetalleCompras.Rows.Add(detalle.IdMaterial1, nombreMaterial, detalle.Cantidad1, detalle.PrecioUnitario1.ToString("0.00"), subtotal.ToString("0.00"), detalle.IdDetalleCompraMaterial1);
                dgvDetalleCompras.Rows[indice].Tag = detalle;
            }

            CalcularTotalCompra();
        }
        private void CalcularTotalCompra()
        {
            totalCompra = 0;

            foreach (DetalleCompraMaterial detalle in detallesTemporales)
            {
                totalCompra += detalle.Cantidad1 * detalle.PrecioUnitario1;
            }

            txtTotalCompra.Text = totalCompra.ToString("0.00");
        }

        private void LimpiarCompra()
        {
            cbProveedor.SelectedIndex = -1;
            cbMaterial.SelectedIndex = -1;

            nudCantidad.Value = 1;

            txtPrecioUnitario.Clear();

            dtpFechaDeCompra.Value = DateTime.Today;

            detallesTemporales.Clear();
            detallesOriginales.Clear();

            dgvDetalleCompras.Rows.Clear();

            idCompraSeleccionada = 0;
            modoEdicion = false;

            totalCompra = 0;

            txtTotalCompra.Text = "0.00";

            // Volver al modo nueva compra
            btnGuardar.Visible = true;
            btnActualizarCompra.Visible = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Validar que se seleccionó un proveedor
            if (cbProveedor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbProveedor, "Selecciona un proveedor.");
                MessageBox.Show("Selecciona un proveedor.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProveedor.Focus();
                return;
            }

            // Validar que haya materiales
            if (dgvDetalleCompras.Rows.Count == 0)
            {
                errorProvider1.SetError(dgvDetalleCompras, "Agrega al menos un material.");
                MessageBox.Show("Agrega al menos un material.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDetalleCompras.Focus();
                return;
            }

            // Validar fecha
            if (dtpFechaDeCompra.Value == null)
            {
                errorProvider1.SetError(dtpFechaDeCompra, "Debe ingresar la fecha de la compra.");
                MessageBox.Show("Debe ingresar la fecha de la compra.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaDeCompra.Focus();
                return;
            }

            // Volver a calcular el total
            CalcularTotalCompra();

            int idProveedor = Convert.ToInt32(cbProveedor.SelectedValue);

            int idCompra;

            try
            {
                idCompra = ComprasDb.GuardarCompleta(0, dtpFechaDeCompra.Value, idProveedor, detallesTemporales);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Compra registrada correctamente.\n\nNúmero de compra: " + idCompra, "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualizar historial de compras
            MostrarCompras();

            // Limpiar formulario de compras
            LimpiarCompra();
        }

        private void dgvHistorialCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || ((DataGridView)sender).Rows[e.RowIndex].IsNewRow)
                return;

            idCompraSeleccionada = Convert.ToInt32(dgvHistorialCompras.Rows[e.RowIndex].Cells["IdCompra"].Value);

            modoEdicion = true;

            CargarCompraParaEditar(idCompraSeleccionada);
        }

        private void CargarCompraParaEditar(int idCompra)
        {
            btnGuardar.Visible = false;
            btnActualizarCompra.Visible = true;

            // Limpiar listas anteriores
            detallesOriginales.Clear();
            detallesTemporales.Clear();

            DataTable dtCompra = ComprasDb.ObtenerCompraPorId(idCompra);

            if (dtCompra == null || dtCompra.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la compra seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            DataRow filaCompra = dtCompra.Rows[0];

            // Fecha
            dtpFechaDeCompra.Value = Convert.ToDateTime(filaCompra["FechaCompra"]);

            // Proveedor
            int idProveedor = Convert.ToInt32(filaCompra["IdProveedor"]);

            cbProveedor.SelectedValue = idProveedor;

            // Total
            totalCompra = Convert.ToDecimal(filaCompra["TotalCompra"]);

            txtTotalCompra.Text = totalCompra.ToString("0.00");


            // CARGAR DETALLES DE LA COMPRA

            DataTable dt = DetalleCompraMaterial.CargarDetallesPorCompra(idCompra);


            foreach (DataRow fila in dt.Rows)
            {
                DetalleCompraMaterial detalle = new DetalleCompraMaterial(Convert.ToInt32(fila["IdDetalleCompraMaterial"]),

                        Convert.ToInt32(fila["IdCompra"]),

                        Convert.ToInt32(fila["IdMaterial"]),

                        Convert.ToInt32(fila["Cantidad"]),

                        Convert.ToDecimal(fila["PrecioUnitario"])
                    );

                detallesOriginales.Add(detalle);
            }

            // COPIAR ORIGINALES A TEMPORALES
            foreach (DetalleCompraMaterial original in detallesOriginales)
            {
                DetalleCompraMaterial temporal = new DetalleCompraMaterial(original.IdDetalleCompraMaterial1, original.IdCompra1, original.IdMaterial1, original.Cantidad1, original.PrecioUnitario1
            );

                detallesTemporales.Add(temporal);
            }

            // MOSTRAR TEMPORALES

            MostrarDetallesTemporales();

        }

        private void dgvDetalleCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || ((DataGridView)sender).Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow fila = dgvDetalleCompras.Rows[e.RowIndex];
            idDetalleEditando = Convert.ToInt32(fila.Cells["IdDetalleCompraMaterial"].Value);

            int idMaterial = Convert.ToInt32(fila.Cells["IdMaterial"].Value);

            int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

            decimal precio = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);

            // Pasar informacin al formulario de la izquierda
            cbMaterial.SelectedValue = idMaterial;

            nudCantidad.Value = cantidad;

            txtPrecioUnitario.Text = precio.ToString("0.00");
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

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnActualizarCompra_Click_1(object sender, EventArgs e)
        {
            // Validar que exista una compra seleccionada
            if (!modoEdicion || idCompraSeleccionada == 0)
            {
                errorProvider1.SetError(cbProveedor, "Primero selecciona una compra para editar.");
                cbProveedor.Focus();
                return;
            }

            // Validar proveedor
            if (cbProveedor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbProveedor, "Selecciona un proveedor.");
                cbProveedor.Focus();
                return;
            }

            // Validar que haya materiales
            if (detallesTemporales.Count == 0)
            {
                errorProvider1.SetError(dgvDetalleCompras, "La compra debe tener al menos un material.");
                dgvDetalleCompras.Focus();
                return;
            }

            try
            {
                int idProveedor = Convert.ToInt32(cbProveedor.SelectedValue);

                CalcularTotalCompra();

                ComprasDb.GuardarCompleta(idCompraSeleccionada, dtpFechaDeCompra.Value, idProveedor, detallesTemporales);

                MessageBox.Show("Compra actualizada correctamente.", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarCompras();

                LimpiarCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar la compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            LimpiarCompra();
            dgvHistorialCompras.ClearSelection();
            dgvHistorialCompras.CurrentCell = null;
        }

        private void dgvDetalleCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar fila y columna
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Verificar que se hizo clic en el botón Eliminar
            if (dgvDetalleCompras.Columns[e.ColumnIndex].Name != "Eliminar")
                return;

            DetalleCompraMaterial detalle = dgvDetalleCompras.Rows[e.RowIndex].Tag as DetalleCompraMaterial;
            if (detalle == null)
                return;

            bool ultimo = detallesTemporales.Count == 1;
            // Confirmar eliminación
            DialogResult resultado = MessageBox.Show(ultimo && modoEdicion ? "Al eliminar el último material se eliminará automáticamente el registro de esta compra y se revertirá todo el inventario que sumó. Los demás movimientos de inventario se conservarán. ¿Desea continuar?"
                : "¿Está seguro de quitar este material? Los cambios se aplicarán al guardar o actualizar la compra.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (resultado != DialogResult.Yes)
                return;

            if (ultimo && modoEdicion)
            {
                var compra = new ComprasDb();
                compra.IdCompra1 = idCompraSeleccionada;
                if (!compra.EliminarCompra())
                    return;
                LimpiarCompra();
                MostrarCompras();
                CargarComboBoxMateriales();
                MessageBox.Show("Compra eliminada e inventario ajustado correctamente.");
                return;
            }

            // Eliminar de la lista temporal
            detallesTemporales.Remove(detalle);

            // Actualizar el DataGridView
            MostrarDetallesTemporales();

            MessageBox.Show("Material quitado de la lista. Guarda o actualiza la compra para aplicar el cambio.", "Eliminación",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idCompraSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una compra dando doble clic en la tabla inferior.");
                return;
            }

            DialogResult res = MessageBox.Show("¿Desea eliminar esta compra y todos sus materiales? Se revertirá el inventario que sumó esta compra, conservando los demás movimientos.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                ComprasDb compra = new ComprasDb();
                compra.IdCompra1 = idCompraSeleccionada;
                if (compra.EliminarCompra())
                {
                    MessageBox.Show("Compra eliminada correctamente.");
                    MostrarCompras();
                    LimpiarCompra();
                    CargarComboBoxMateriales();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtCompras = null;
                    MostrarCompras();
                    return;
                }

                dtCompras = ComprasDb.Buscar(buscar);

                int totalResultados = dtCompras.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPaginaCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar compras.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void dtpFechaDeCompra_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }
    }
}

