namespace Vista.Compras
{
    partial class frmCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPrincipalCompras = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNueva = new System.Windows.Forms.Button();
            this.pnlComprasRegistradas = new System.Windows.Forms.Panel();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblComprasRegistradas = new System.Windows.Forms.Label();
            this.dgvHistorialCompras = new System.Windows.Forms.DataGridView();
            this.pnlPedidaDeDatos = new System.Windows.Forms.Panel();
            this.btnActualizar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAgregarProductos = new Guna.UI2.WinForms.Guna2Button();
            this.lblAgregarMaterial = new System.Windows.Forms.Label();
            this.gbBarraDecorativa = new System.Windows.Forms.GroupBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.dtpFechaDeCompra = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblDetalleCompra = new System.Windows.Forms.Label();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.pnlDetalleCompra = new System.Windows.Forms.Panel();
            this.btnActualizarCompra = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.lblDetallesCompra = new System.Windows.Forms.Label();
            this.dgvDetalleCompras = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.pblSuperior = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlPrincipalCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnlComprasRegistradas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCompras)).BeginInit();
            this.pnlPedidaDeDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.pnlDetalleCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompras)).BeginInit();
            this.pblSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipalCompras
            // 
            this.pnlPrincipalCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlPrincipalCompras.Controls.Add(this.guna2PictureBox1);
            this.pnlPrincipalCompras.Controls.Add(this.txtBuscar);
            this.pnlPrincipalCompras.Controls.Add(this.btnNueva);
            this.pnlPrincipalCompras.Controls.Add(this.pnlComprasRegistradas);
            this.pnlPrincipalCompras.Controls.Add(this.pnlPedidaDeDatos);
            this.pnlPrincipalCompras.Controls.Add(this.lblSubTexto);
            this.pnlPrincipalCompras.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlPrincipalCompras.Controls.Add(this.pnlDetalleCompra);
            this.pnlPrincipalCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipalCompras.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipalCompras.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipalCompras.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipalCompras.Name = "pnlPrincipalCompras";
            this.pnlPrincipalCompras.Size = new System.Drawing.Size(1102, 627);
            this.pnlPrincipalCompras.TabIndex = 2;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Vista.Properties.Resources.anadir_al_carrito;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(11, 41);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(68, 60);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 25;
            this.guna2PictureBox1.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.IconLeft = global::Vista.Properties.Resources.zoom_561117;
            this.txtBuscar.Location = new System.Drawing.Point(657, 53);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(406, 28);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnNueva
            // 
            this.btnNueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.btnNueva.Location = new System.Drawing.Point(12, 116);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(258, 39);
            this.btnNueva.TabIndex = 22;
            this.btnNueva.Text = "Nueva Compra";
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // pnlComprasRegistradas
            // 
            this.pnlComprasRegistradas.BackColor = System.Drawing.Color.Bisque;
            this.pnlComprasRegistradas.Controls.Add(this.lblPagina);
            this.pnlComprasRegistradas.Controls.Add(this.btnAnterior);
            this.pnlComprasRegistradas.Controls.Add(this.btnSiguiente);
            this.pnlComprasRegistradas.Controls.Add(this.lblComprasRegistradas);
            this.pnlComprasRegistradas.Controls.Add(this.dgvHistorialCompras);
            this.pnlComprasRegistradas.Location = new System.Drawing.Point(293, 361);
            this.pnlComprasRegistradas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlComprasRegistradas.Name = "pnlComprasRegistradas";
            this.pnlComprasRegistradas.Size = new System.Drawing.Size(771, 253);
            this.pnlComprasRegistradas.TabIndex = 4;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.Black;
            this.lblPagina.Location = new System.Drawing.Point(53, 229);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 35;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.hacia_atras_negro2;
            this.btnAnterior.Location = new System.Drawing.Point(16, 222);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 23);
            this.btnAnterior.TabIndex = 34;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::Vista.Properties.Resources.hacia_adelante_negro;
            this.btnSiguiente.Location = new System.Drawing.Point(140, 222);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 33;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblComprasRegistradas
            // 
            this.lblComprasRegistradas.AutoSize = true;
            this.lblComprasRegistradas.BackColor = System.Drawing.Color.Bisque;
            this.lblComprasRegistradas.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprasRegistradas.ForeColor = System.Drawing.Color.Black;
            this.lblComprasRegistradas.Location = new System.Drawing.Point(19, 12);
            this.lblComprasRegistradas.Name = "lblComprasRegistradas";
            this.lblComprasRegistradas.Size = new System.Drawing.Size(228, 26);
            this.lblComprasRegistradas.TabIndex = 1;
            this.lblComprasRegistradas.Text = "Registro de Compras";
            // 
            // dgvHistorialCompras
            // 
            this.dgvHistorialCompras.AllowUserToResizeColumns = false;
            this.dgvHistorialCompras.AllowUserToResizeRows = false;
            this.dgvHistorialCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHistorialCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistorialCompras.GridColor = System.Drawing.Color.Black;
            this.dgvHistorialCompras.Location = new System.Drawing.Point(8, 43);
            this.dgvHistorialCompras.Name = "dgvHistorialCompras";
            this.dgvHistorialCompras.ReadOnly = true;
            this.dgvHistorialCompras.RowHeadersVisible = false;
            this.dgvHistorialCompras.Size = new System.Drawing.Size(754, 173);
            this.dgvHistorialCompras.TabIndex = 0;
            this.dgvHistorialCompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialCompras_CellDoubleClick);
            this.dgvHistorialCompras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialCompras_CellDoubleClick);
            // 
            // pnlPedidaDeDatos
            // 
            this.pnlPedidaDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPedidaDeDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlPedidaDeDatos.Controls.Add(this.btnActualizar);
            this.pnlPedidaDeDatos.Controls.Add(this.btnAgregarProductos);
            this.pnlPedidaDeDatos.Controls.Add(this.lblAgregarMaterial);
            this.pnlPedidaDeDatos.Controls.Add(this.gbBarraDecorativa);
            this.pnlPedidaDeDatos.Controls.Add(this.nudCantidad);
            this.pnlPedidaDeDatos.Controls.Add(this.cbProveedor);
            this.pnlPedidaDeDatos.Controls.Add(this.cbMaterial);
            this.pnlPedidaDeDatos.Controls.Add(this.txtPrecioUnitario);
            this.pnlPedidaDeDatos.Controls.Add(this.lblPrecioUnitario);
            this.pnlPedidaDeDatos.Controls.Add(this.dtpFechaDeCompra);
            this.pnlPedidaDeDatos.Controls.Add(this.lblFechaCompra);
            this.pnlPedidaDeDatos.Controls.Add(this.lblProveedor);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCantidad);
            this.pnlPedidaDeDatos.Controls.Add(this.lblMaterial);
            this.pnlPedidaDeDatos.Controls.Add(this.lblDetalleCompra);
            this.pnlPedidaDeDatos.Location = new System.Drawing.Point(12, 164);
            this.pnlPedidaDeDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPedidaDeDatos.Name = "pnlPedidaDeDatos";
            this.pnlPedidaDeDatos.Size = new System.Drawing.Size(259, 452);
            this.pnlPedidaDeDatos.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(20, 416);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(212, 24);
            this.btnActualizar.TabIndex = 30;
            this.btnActualizar.Text = "Actualizar producto";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnAgregarProductos
            // 
            this.btnAgregarProductos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProductos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregarProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregarProductos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregarProductos.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProductos.Location = new System.Drawing.Point(21, 382);
            this.btnAgregarProductos.Name = "btnAgregarProductos";
            this.btnAgregarProductos.Size = new System.Drawing.Size(210, 24);
            this.btnAgregarProductos.TabIndex = 29;
            this.btnAgregarProductos.Text = "Agregar producto";
            this.btnAgregarProductos.Click += new System.EventHandler(this.btnAgregarProductos_Click);
            // 
            // lblAgregarMaterial
            // 
            this.lblAgregarMaterial.AutoSize = true;
            this.lblAgregarMaterial.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregarMaterial.Location = new System.Drawing.Point(37, 169);
            this.lblAgregarMaterial.Name = "lblAgregarMaterial";
            this.lblAgregarMaterial.Size = new System.Drawing.Size(174, 25);
            this.lblAgregarMaterial.TabIndex = 28;
            this.lblAgregarMaterial.Text = "Agregar Material";
            // 
            // gbBarraDecorativa
            // 
            this.gbBarraDecorativa.BackColor = System.Drawing.SystemColors.Desktop;
            this.gbBarraDecorativa.Location = new System.Drawing.Point(20, 157);
            this.gbBarraDecorativa.Margin = new System.Windows.Forms.Padding(2);
            this.gbBarraDecorativa.Name = "gbBarraDecorativa";
            this.gbBarraDecorativa.Padding = new System.Windows.Forms.Padding(2);
            this.gbBarraDecorativa.Size = new System.Drawing.Size(217, 3);
            this.gbBarraDecorativa.TabIndex = 27;
            this.gbBarraDecorativa.TabStop = false;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(20, 285);
            this.nudCantidad.Maximum = new decimal(new int[] {
            7000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(212, 20);
            this.nudCantidad.TabIndex = 25;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // cbProveedor
            // 
            this.cbProveedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(19, 72);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(212, 23);
            this.cbProveedor.TabIndex = 24;
            this.cbProveedor.SelectedIndexChanged += new System.EventHandler(this.cbProveedor_SelectedIndexChanged);
            // 
            // cbMaterial
            // 
            this.cbMaterial.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(17, 225);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(214, 23);
            this.cbMaterial.TabIndex = 23;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(23, 344);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(208, 20);
            this.txtPrecioUnitario.TabIndex = 21;
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPrecioUnitario.Location = new System.Drawing.Point(20, 317);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(99, 19);
            this.lblPrecioUnitario.TabIndex = 20;
            this.lblPrecioUnitario.Text = "Precio unitario:";
            // 
            // dtpFechaDeCompra
            // 
            this.dtpFechaDeCompra.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDeCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeCompra.Location = new System.Drawing.Point(21, 123);
            this.dtpFechaDeCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaDeCompra.MaxDate = new System.DateTime(2026, 8, 26, 0, 0, 0, 0);
            this.dtpFechaDeCompra.Name = "dtpFechaDeCompra";
            this.dtpFechaDeCompra.Size = new System.Drawing.Size(205, 23);
            this.dtpFechaDeCompra.TabIndex = 19;
            this.dtpFechaDeCompra.Value = new System.DateTime(2026, 8, 26, 0, 0, 0, 0);
            this.dtpFechaDeCompra.ValueChanged += new System.EventHandler(this.dtpFechaDeCompra_ValueChanged);
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.AutoSize = true;
            this.lblFechaCompra.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblFechaCompra.Location = new System.Drawing.Point(20, 100);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(132, 19);
            this.lblFechaCompra.TabIndex = 12;
            this.lblFechaCompra.Text = "Fecha de la compra:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblProveedor.Location = new System.Drawing.Point(17, 48);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(76, 19);
            this.lblProveedor.TabIndex = 10;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCantidad.Location = new System.Drawing.Point(21, 258);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(67, 19);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaterial.Location = new System.Drawing.Point(21, 199);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(62, 19);
            this.lblMaterial.TabIndex = 1;
            this.lblMaterial.Text = "Material:";
            // 
            // lblDetalleCompra
            // 
            this.lblDetalleCompra.AutoSize = true;
            this.lblDetalleCompra.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleCompra.Location = new System.Drawing.Point(16, 13);
            this.lblDetalleCompra.Name = "lblDetalleCompra";
            this.lblDetalleCompra.Size = new System.Drawing.Size(194, 25);
            this.lblDetalleCompra.TabIndex = 0;
            this.lblDetalleCompra.Text = "Datos de la compra";
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTexto.Location = new System.Drawing.Point(82, 81);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(253, 21);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Control del registro de compras.";
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(79, 41);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(322, 40);
            this.lblMensajeInformativoPrincipal.TabIndex = 0;
            this.lblMensajeInformativoPrincipal.Text = "Gestión de Compras";
            // 
            // pnlDetalleCompra
            // 
            this.pnlDetalleCompra.BackColor = System.Drawing.Color.Bisque;
            this.pnlDetalleCompra.Controls.Add(this.btnActualizarCompra);
            this.pnlDetalleCompra.Controls.Add(this.btnCancelar);
            this.pnlDetalleCompra.Controls.Add(this.txtTotalCompra);
            this.pnlDetalleCompra.Controls.Add(this.lblTotalCompra);
            this.pnlDetalleCompra.Controls.Add(this.lblDetallesCompra);
            this.pnlDetalleCompra.Controls.Add(this.dgvDetalleCompras);
            this.pnlDetalleCompra.Controls.Add(this.btnGuardar);
            this.pnlDetalleCompra.Location = new System.Drawing.Point(293, 113);
            this.pnlDetalleCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDetalleCompra.Name = "pnlDetalleCompra";
            this.pnlDetalleCompra.Size = new System.Drawing.Size(771, 242);
            this.pnlDetalleCompra.TabIndex = 3;
            // 
            // btnActualizarCompra
            // 
            this.btnActualizarCompra.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActualizarCompra.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActualizarCompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActualizarCompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActualizarCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualizarCompra.ForeColor = System.Drawing.Color.White;
            this.btnActualizarCompra.Location = new System.Drawing.Point(454, 206);
            this.btnActualizarCompra.Name = "btnActualizarCompra";
            this.btnActualizarCompra.Size = new System.Drawing.Size(174, 26);
            this.btnActualizarCompra.TabIndex = 6;
            this.btnActualizarCompra.Text = "Actualizar Compra";
            this.btnActualizarCompra.Visible = false;
            this.btnActualizarCompra.Click += new System.EventHandler(this.btnActualizarCompra_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(641, 204);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 29);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Eliminar compra";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCompra.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txtTotalCompra.Location = new System.Drawing.Point(283, 205);
            this.txtTotalCompra.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.ReadOnly = true;
            this.txtTotalCompra.Size = new System.Drawing.Size(151, 29);
            this.txtTotalCompra.TabIndex = 1;
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.AutoSize = true;
            this.lblTotalCompra.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCompra.Location = new System.Drawing.Point(151, 212);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(129, 17);
            this.lblTotalCompra.TabIndex = 0;
            this.lblTotalCompra.Text = "Total de la Compra:";
            // 
            // lblDetallesCompra
            // 
            this.lblDetallesCompra.AutoSize = true;
            this.lblDetallesCompra.BackColor = System.Drawing.Color.Bisque;
            this.lblDetallesCompra.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallesCompra.ForeColor = System.Drawing.Color.Black;
            this.lblDetallesCompra.Location = new System.Drawing.Point(19, 14);
            this.lblDetallesCompra.Name = "lblDetallesCompra";
            this.lblDetallesCompra.Size = new System.Drawing.Size(239, 26);
            this.lblDetallesCompra.TabIndex = 1;
            this.lblDetallesCompra.Text = "Detalles de la Compra";
            // 
            // dgvDetalleCompras
            // 
            this.dgvDetalleCompras.AllowUserToDeleteRows = false;
            this.dgvDetalleCompras.AllowUserToResizeColumns = false;
            this.dgvDetalleCompras.AllowUserToResizeRows = false;
            this.dgvDetalleCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetalleCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleCompras.GridColor = System.Drawing.Color.Black;
            this.dgvDetalleCompras.Location = new System.Drawing.Point(8, 48);
            this.dgvDetalleCompras.Name = "dgvDetalleCompras";
            this.dgvDetalleCompras.ReadOnly = true;
            this.dgvDetalleCompras.Size = new System.Drawing.Size(754, 150);
            this.dgvDetalleCompras.TabIndex = 0;
            this.dgvDetalleCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleCompras_CellContentClick);
            this.dgvDetalleCompras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleCompras_CellDoubleClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(454, 206);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(174, 26);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar compra";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // pblSuperior
            // 
            this.pblSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pblSuperior.Controls.Add(this.lblAdministrador);
            this.pblSuperior.Controls.Add(this.pbPerfil);
            this.pblSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblSuperior.Location = new System.Drawing.Point(0, 0);
            this.pblSuperior.Margin = new System.Windows.Forms.Padding(2);
            this.pblSuperior.Name = "pblSuperior";
            this.pblSuperior.Size = new System.Drawing.Size(1102, 23);
            this.pblSuperior.TabIndex = 23;
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.Location = new System.Drawing.Point(1013, 4);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(38, 14);
            this.lblAdministrador.TabIndex = 28;
            this.lblAdministrador.Text = "Admin";
            // 
            // pbPerfil
            // 
            this.pbPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pbPerfil.Image = global::Vista.Properties.Resources.user_456283;
            this.pbPerfil.Location = new System.Drawing.Point(1054, -1);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(24, 25);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerfil.TabIndex = 12;
            this.pbPerfil.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pblSuperior);
            this.Controls.Add(this.pnlPrincipalCompras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCompras";
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            this.pnlPrincipalCompras.ResumeLayout(false);
            this.pnlPrincipalCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnlComprasRegistradas.ResumeLayout(false);
            this.pnlComprasRegistradas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCompras)).EndInit();
            this.pnlPedidaDeDatos.ResumeLayout(false);
            this.pnlPedidaDeDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.pnlDetalleCompra.ResumeLayout(false);
            this.pnlDetalleCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompras)).EndInit();
            this.pblSuperior.ResumeLayout(false);
            this.pblSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipalCompras;
        private System.Windows.Forms.Panel pnlPedidaDeDatos;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.DateTimePicker dtpFechaDeCompra;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblDetalleCompra;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.Panel pnlDetalleCompra;
        private System.Windows.Forms.Panel pblSuperior;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.DataGridView dgvDetalleCompras;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.Label lblDetallesCompra;
        private System.Windows.Forms.Panel pnlComprasRegistradas;
        private System.Windows.Forms.Label lblComprasRegistradas;
        private System.Windows.Forms.DataGridView dgvHistorialCompras;
        private System.Windows.Forms.GroupBox gbBarraDecorativa;
        private System.Windows.Forms.Label lblAgregarMaterial;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button btnAgregarProductos;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnActualizarCompra;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
