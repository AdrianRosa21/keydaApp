namespace Vista.Pedidos
{
    partial class frmPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlRegistros = new System.Windows.Forms.Panel();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.pnlTitulo2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPedidosRegistrados = new System.Windows.Forms.DataGridView();
            this.pnlBarraInformativa = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblMensajeInformativoPedidos = new System.Windows.Forms.Label();
            this.pnlDEtalles = new System.Windows.Forms.Panel();
            this.pnlTitulo1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetallesDePedido = new System.Windows.Forms.DataGridView();
            this.pnlPedidaDeDatos = new System.Windows.Forms.Panel();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtClienteSeleccionado = new System.Windows.Forms.TextBox();
            this.dtpFechaDeEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.dtpFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.pnlTituloDetallesPedido = new System.Windows.Forms.Panel();
            this.lblDatosPedido = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlContenedorPrincipalInventario = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlRegistros.SuspendLayout();
            this.pnlTitulo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRegistrados)).BeginInit();
            this.pnlBarraInformativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlDEtalles.SuspendLayout();
            this.pnlTitulo1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDePedido)).BeginInit();
            this.pnlPedidaDeDatos.SuspendLayout();
            this.pnlTituloDetallesPedido.SuspendLayout();
            this.pnlContenedorPrincipalInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblSubTexto.Location = new System.Drawing.Point(78, 60);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(276, 20);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Administración y registro de pedidos.";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(21, 203);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 16);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado: ";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblSubTexto);
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.pnlRegistros);
            this.pnlHeader.Controls.Add(this.pnlBarraInformativa);
            this.pnlHeader.Controls.Add(this.lblMensajeInformativoPedidos);
            this.pnlHeader.Controls.Add(this.pnlDEtalles);
            this.pnlHeader.Controls.Add(this.pnlPedidaDeDatos);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1102, 627);
            this.pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.PedidosActivos128px;
            this.pictureBox1.Location = new System.Drawing.Point(20, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
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
            this.txtBuscar.IconLeft = global::Vista.Properties.Resources.zoom_5611171;
            this.txtBuscar.Location = new System.Drawing.Point(648, 39);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(432, 23);
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            // 
            // pnlRegistros
            // 
            this.pnlRegistros.BackColor = System.Drawing.Color.Bisque;
            this.pnlRegistros.Controls.Add(this.lblPagina);
            this.pnlRegistros.Controls.Add(this.btnAnterior);
            this.pnlRegistros.Controls.Add(this.btnSiguiente);
            this.pnlRegistros.Controls.Add(this.pnlTitulo2);
            this.pnlRegistros.Controls.Add(this.dgvPedidosRegistrados);
            this.pnlRegistros.Location = new System.Drawing.Point(265, 344);
            this.pnlRegistros.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRegistros.Name = "pnlRegistros";
            this.pnlRegistros.Size = new System.Drawing.Size(815, 272);
            this.pnlRegistros.TabIndex = 4;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.Black;
            this.lblPagina.Location = new System.Drawing.Point(59, 249);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 10;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.hacia_atras_negro2;
            this.btnAnterior.Location = new System.Drawing.Point(22, 244);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 23);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::Vista.Properties.Resources.hacia_adelante_negro;
            this.btnSiguiente.Location = new System.Drawing.Point(146, 244);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // pnlTitulo2
            // 
            this.pnlTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlTitulo2.Controls.Add(this.label3);
            this.pnlTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo2.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo2.Name = "pnlTitulo2";
            this.pnlTitulo2.Size = new System.Drawing.Size(815, 25);
            this.pnlTitulo2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pedidos Registrados";
            // 
            // dgvPedidosRegistrados
            // 
            this.dgvPedidosRegistrados.AllowUserToDeleteRows = false;
            this.dgvPedidosRegistrados.AllowUserToResizeColumns = false;
            this.dgvPedidosRegistrados.AllowUserToResizeRows = false;
            this.dgvPedidosRegistrados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidosRegistrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidosRegistrados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPedidosRegistrados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidosRegistrados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPedidosRegistrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosRegistrados.GridColor = System.Drawing.Color.Black;
            this.dgvPedidosRegistrados.Location = new System.Drawing.Point(11, 34);
            this.dgvPedidosRegistrados.Name = "dgvPedidosRegistrados";
            this.dgvPedidosRegistrados.ReadOnly = true;
            this.dgvPedidosRegistrados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidosRegistrados.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPedidosRegistrados.RowHeadersVisible = false;
            this.dgvPedidosRegistrados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPedidosRegistrados.Size = new System.Drawing.Size(794, 206);
            this.dgvPedidosRegistrados.TabIndex = 0;
            this.dgvPedidosRegistrados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosRegistrados_CellClick);
            this.dgvPedidosRegistrados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosRegistrados_CellDoubleClick);
            // 
            // pnlBarraInformativa
            // 
            this.pnlBarraInformativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pnlBarraInformativa.Controls.Add(this.lblAdministrador);
            this.pnlBarraInformativa.Controls.Add(this.pictureBox4);
            this.pnlBarraInformativa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraInformativa.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraInformativa.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBarraInformativa.Name = "pnlBarraInformativa";
            this.pnlBarraInformativa.Size = new System.Drawing.Size(1102, 23);
            this.pnlBarraInformativa.TabIndex = 7;
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.Location = new System.Drawing.Point(1013, 4);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(38, 14);
            this.lblAdministrador.TabIndex = 29;
            this.lblAdministrador.Text = "Admin";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pictureBox4.Image = global::Vista.Properties.Resources.user_456283;
            this.pictureBox4.Location = new System.Drawing.Point(1054, -1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // lblMensajeInformativoPedidos
            // 
            this.lblMensajeInformativoPedidos.AutoSize = true;
            this.lblMensajeInformativoPedidos.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblMensajeInformativoPedidos.Location = new System.Drawing.Point(71, 25);
            this.lblMensajeInformativoPedidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPedidos.Name = "lblMensajeInformativoPedidos";
            this.lblMensajeInformativoPedidos.Size = new System.Drawing.Size(274, 36);
            this.lblMensajeInformativoPedidos.TabIndex = 0;
            this.lblMensajeInformativoPedidos.Text = "Gestión de Pedidos";
            // 
            // pnlDEtalles
            // 
            this.pnlDEtalles.BackColor = System.Drawing.Color.Bisque;
            this.pnlDEtalles.Controls.Add(this.pnlTitulo1);
            this.pnlDEtalles.Controls.Add(this.dgvDetallesDePedido);
            this.pnlDEtalles.Location = new System.Drawing.Point(265, 96);
            this.pnlDEtalles.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDEtalles.Name = "pnlDEtalles";
            this.pnlDEtalles.Size = new System.Drawing.Size(815, 238);
            this.pnlDEtalles.TabIndex = 3;
            // 
            // pnlTitulo1
            // 
            this.pnlTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlTitulo1.Controls.Add(this.label2);
            this.pnlTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo1.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo1.Name = "pnlTitulo1";
            this.pnlTitulo1.Size = new System.Drawing.Size(815, 25);
            this.pnlTitulo1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detalles del Pedido";
            // 
            // dgvDetallesDePedido
            // 
            this.dgvDetallesDePedido.AllowUserToResizeColumns = false;
            this.dgvDetallesDePedido.AllowUserToResizeRows = false;
            this.dgvDetallesDePedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetallesDePedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesDePedido.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesDePedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetallesDePedido.GridColor = System.Drawing.Color.Black;
            this.dgvDetallesDePedido.Location = new System.Drawing.Point(11, 35);
            this.dgvDetallesDePedido.Name = "dgvDetallesDePedido";
            this.dgvDetallesDePedido.ReadOnly = true;
            this.dgvDetallesDePedido.RowHeadersVisible = false;
            this.dgvDetallesDePedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDetallesDePedido.Size = new System.Drawing.Size(793, 190);
            this.dgvDetallesDePedido.TabIndex = 0;
            // 
            // pnlPedidaDeDatos
            // 
            this.pnlPedidaDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPedidaDeDatos.AutoScroll = true;
            this.pnlPedidaDeDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlPedidaDeDatos.Controls.Add(this.btnGuardar);
            this.pnlPedidaDeDatos.Controls.Add(this.btnCancelar);
            this.pnlPedidaDeDatos.Controls.Add(this.txtEstado);
            this.pnlPedidaDeDatos.Controls.Add(this.txtClienteSeleccionado);
            this.pnlPedidaDeDatos.Controls.Add(this.dtpFechaDeEntrega);
            this.pnlPedidaDeDatos.Controls.Add(this.lblFechaPedido);
            this.pnlPedidaDeDatos.Controls.Add(this.dtpFechaPedido);
            this.pnlPedidaDeDatos.Controls.Add(this.pnlTituloDetallesPedido);
            this.pnlPedidaDeDatos.Controls.Add(this.lblEstado);
            this.pnlPedidaDeDatos.Controls.Add(this.lblFechaEntrega);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCliente);
            this.pnlPedidaDeDatos.Location = new System.Drawing.Point(20, 96);
            this.pnlPedidaDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPedidaDeDatos.Name = "pnlPedidaDeDatos";
            this.pnlPedidaDeDatos.Size = new System.Drawing.Size(228, 316);
            this.pnlPedidaDeDatos.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(10, 265);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 36);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(115, 266);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 36);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(19, 229);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(190, 20);
            this.txtEstado.TabIndex = 41;
            this.txtEstado.TabStop = false;
            // 
            // txtClienteSeleccionado
            // 
            this.txtClienteSeleccionado.Enabled = false;
            this.txtClienteSeleccionado.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtClienteSeleccionado.Location = new System.Drawing.Point(14, 71);
            this.txtClienteSeleccionado.Name = "txtClienteSeleccionado";
            this.txtClienteSeleccionado.Size = new System.Drawing.Size(195, 20);
            this.txtClienteSeleccionado.TabIndex = 38;
            this.txtClienteSeleccionado.Text = "Selecciona un cliente";
            // 
            // dtpFechaDeEntrega
            // 
            this.dtpFechaDeEntrega.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeEntrega.Location = new System.Drawing.Point(20, 174);
            this.dtpFechaDeEntrega.MinDate = new System.DateTime(2026, 9, 28, 0, 0, 0, 0);
            this.dtpFechaDeEntrega.Name = "dtpFechaDeEntrega";
            this.dtpFechaDeEntrega.Size = new System.Drawing.Size(188, 20);
            this.dtpFechaDeEntrega.TabIndex = 32;
            this.dtpFechaDeEntrega.ValueChanged += new System.EventHandler(this.dtpFechaDeEntrega_ValueChanged);
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblFechaPedido.Location = new System.Drawing.Point(16, 97);
            this.lblFechaPedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(105, 16);
            this.lblFechaPedido.TabIndex = 31;
            this.lblFechaPedido.Text = "Fecha del pedido:";
            // 
            // dtpFechaPedido
            // 
            this.dtpFechaPedido.Enabled = false;
            this.dtpFechaPedido.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPedido.Location = new System.Drawing.Point(18, 118);
            this.dtpFechaPedido.Name = "dtpFechaPedido";
            this.dtpFechaPedido.Size = new System.Drawing.Size(191, 20);
            this.dtpFechaPedido.TabIndex = 30;
            this.dtpFechaPedido.ValueChanged += new System.EventHandler(this.dtpFechaPedido_ValueChanged);
            // 
            // pnlTituloDetallesPedido
            // 
            this.pnlTituloDetallesPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlTituloDetallesPedido.Controls.Add(this.lblDatosPedido);
            this.pnlTituloDetallesPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloDetallesPedido.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloDetallesPedido.Name = "pnlTituloDetallesPedido";
            this.pnlTituloDetallesPedido.Size = new System.Drawing.Size(228, 29);
            this.pnlTituloDetallesPedido.TabIndex = 29;
            // 
            // lblDatosPedido
            // 
            this.lblDatosPedido.AutoSize = true;
            this.lblDatosPedido.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosPedido.ForeColor = System.Drawing.Color.White;
            this.lblDatosPedido.Location = new System.Drawing.Point(14, 6);
            this.lblDatosPedido.Name = "lblDatosPedido";
            this.lblDatosPedido.Size = new System.Drawing.Size(122, 19);
            this.lblDatosPedido.TabIndex = 0;
            this.lblDatosPedido.Text = "Datos del Pedido";
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEntrega.Location = new System.Drawing.Point(16, 147);
            this.lblFechaEntrega.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(112, 16);
            this.lblFechaEntrega.TabIndex = 3;
            this.lblFechaEntrega.Text = "Fecha de Entrega :";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCliente.Location = new System.Drawing.Point(16, 47);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(54, 19);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // pnlContenedorPrincipalInventario
            // 
            this.pnlContenedorPrincipalInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlContenedorPrincipalInventario.Controls.Add(this.pnlHeader);
            this.pnlContenedorPrincipalInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipalInventario.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedorPrincipalInventario.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedorPrincipalInventario.Name = "pnlContenedorPrincipalInventario";
            this.pnlContenedorPrincipalInventario.Size = new System.Drawing.Size(1102, 627);
            this.pnlContenedorPrincipalInventario.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPedidos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlContenedorPrincipalInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlRegistros.ResumeLayout(false);
            this.pnlRegistros.PerformLayout();
            this.pnlTitulo2.ResumeLayout(false);
            this.pnlTitulo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRegistrados)).EndInit();
            this.pnlBarraInformativa.ResumeLayout(false);
            this.pnlBarraInformativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlDEtalles.ResumeLayout(false);
            this.pnlTitulo1.ResumeLayout(false);
            this.pnlTitulo1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDePedido)).EndInit();
            this.pnlPedidaDeDatos.ResumeLayout(false);
            this.pnlPedidaDeDatos.PerformLayout();
            this.pnlTituloDetallesPedido.ResumeLayout(false);
            this.pnlTituloDetallesPedido.PerformLayout();
            this.pnlContenedorPrincipalInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMensajeInformativoPedidos;
        private System.Windows.Forms.Panel pnlDEtalles;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel pnlPedidaDeDatos;
        private System.Windows.Forms.Panel pnlContenedorPrincipalInventario;
        private System.Windows.Forms.Panel pnlBarraInformativa;
        private System.Windows.Forms.DataGridView dgvDetallesDePedido;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Panel pnlTituloDetallesPedido;
        private System.Windows.Forms.Label lblDatosPedido;
        private System.Windows.Forms.DateTimePicker dtpFechaDeEntrega;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.Panel pnlRegistros;
        private System.Windows.Forms.DataGridView dgvPedidosRegistrados;
        private System.Windows.Forms.Panel pnlTitulo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTitulo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClienteSeleccionado;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox txtEstado;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

