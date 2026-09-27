namespace Vista.Ventas
{
    partial class frmVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDetalleVentas = new System.Windows.Forms.Label();
            this.dgvDetalleDeVenta = new System.Windows.Forms.DataGridView();
            this.pnlBarraSuperior = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.pnlPedidaDeDatos = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlFacturaRegistrada = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMostrarCliente = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.dtFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.txtNVenta = new System.Windows.Forms.TextBox();
            this.lblNVenta = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.lblDetalleVenta = new System.Windows.Forms.Label();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.pnlTablaContenido = new System.Windows.Forms.Panel();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblRegistroVentas = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnRegistrarFactura = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2TileButton();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDeVenta)).BeginInit();
            this.pnlBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            this.pnlPedidaDeDatos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFacturaRegistrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTablaContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.pictureBox3);
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Controls.Add(this.pnlBarraSuperior);
            this.pnlHeader.Controls.Add(this.pnlPedidaDeDatos);
            this.pnlHeader.Controls.Add(this.lblSubTexto);
            this.pnlHeader.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlHeader.Controls.Add(this.pnlTablaContenido);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1102, 627);
            this.pnlHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.lblDetalleVentas);
            this.panel1.Controls.Add(this.dgvDetalleDeVenta);
            this.panel1.Location = new System.Drawing.Point(37, 431);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 179);
            this.panel1.TabIndex = 4;
            // 
            // lblDetalleVentas
            // 
            this.lblDetalleVentas.AutoSize = true;
            this.lblDetalleVentas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVentas.Location = new System.Drawing.Point(14, 6);
            this.lblDetalleVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetalleVentas.Name = "lblDetalleVentas";
            this.lblDetalleVentas.Size = new System.Drawing.Size(166, 22);
            this.lblDetalleVentas.TabIndex = 28;
            this.lblDetalleVentas.Text = "Detalle de la venta.";
            // 
            // dgvDetalleDeVenta
            // 
            this.dgvDetalleDeVenta.AllowUserToAddRows = false;
            this.dgvDetalleDeVenta.AllowUserToResizeColumns = false;
            this.dgvDetalleDeVenta.AllowUserToResizeRows = false;
            this.dgvDetalleDeVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleDeVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleDeVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleDeVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleDeVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleDeVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleDeVenta.GridColor = System.Drawing.Color.Black;
            this.dgvDetalleDeVenta.Location = new System.Drawing.Point(14, 37);
            this.dgvDetalleDeVenta.Name = "dgvDetalleDeVenta";
            this.dgvDetalleDeVenta.RowHeadersVisible = false;
            this.dgvDetalleDeVenta.Size = new System.Drawing.Size(741, 122);
            this.dgvDetalleDeVenta.TabIndex = 0;
            // 
            // pnlBarraSuperior
            // 
            this.pnlBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pnlBarraSuperior.Controls.Add(this.lblAdministrador);
            this.pnlBarraSuperior.Controls.Add(this.pbPerfil);
            this.pnlBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraSuperior.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBarraSuperior.Name = "pnlBarraSuperior";
            this.pnlBarraSuperior.Size = new System.Drawing.Size(1102, 23);
            this.pnlBarraSuperior.TabIndex = 6;
            this.pnlBarraSuperior.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
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
            // pbPerfil
            // 
            this.pbPerfil.Image = global::Vista.Properties.Resources.Imagen_perfil_2;
            this.pbPerfil.Location = new System.Drawing.Point(1054, -1);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(22, 22);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerfil.TabIndex = 12;
            this.pbPerfil.TabStop = false;
            // 
            // pnlPedidaDeDatos
            // 
            this.pnlPedidaDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPedidaDeDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlPedidaDeDatos.Controls.Add(this.btnEliminar);
            this.pnlPedidaDeDatos.Controls.Add(this.btnRegistrarFactura);
            this.pnlPedidaDeDatos.Controls.Add(this.panel2);
            this.pnlPedidaDeDatos.Controls.Add(this.txtMostrarCliente);
            this.pnlPedidaDeDatos.Controls.Add(this.lblSubTotal);
            this.pnlPedidaDeDatos.Controls.Add(this.txtSubTotal);
            this.pnlPedidaDeDatos.Controls.Add(this.dtFechaVenta);
            this.pnlPedidaDeDatos.Controls.Add(this.txtNVenta);
            this.pnlPedidaDeDatos.Controls.Add(this.lblNVenta);
            this.pnlPedidaDeDatos.Controls.Add(this.lblFechaVenta);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCodigoCliente);
            this.pnlPedidaDeDatos.Controls.Add(this.lblDetalleVenta);
            this.pnlPedidaDeDatos.Location = new System.Drawing.Point(824, 102);
            this.pnlPedidaDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPedidaDeDatos.Name = "pnlPedidaDeDatos";
            this.pnlPedidaDeDatos.Size = new System.Drawing.Size(241, 335);
            this.pnlPedidaDeDatos.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.Controls.Add(this.pnlFacturaRegistrada);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(26, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 39);
            this.panel2.TabIndex = 34;
            // 
            // pnlFacturaRegistrada
            // 
            this.pnlFacturaRegistrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlFacturaRegistrada.Controls.Add(this.pictureBox2);
            this.pnlFacturaRegistrada.Controls.Add(this.label2);
            this.pnlFacturaRegistrada.Location = new System.Drawing.Point(0, 0);
            this.pnlFacturaRegistrada.Name = "pnlFacturaRegistrada";
            this.pnlFacturaRegistrada.Size = new System.Drawing.Size(194, 39);
            this.pnlFacturaRegistrada.TabIndex = 35;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Vista.Properties.Resources.controlar;
            this.pictureBox2.Location = new System.Drawing.Point(22, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 35);
            this.label2.TabIndex = 33;
            this.label2.Text = "Venta disponible para facturar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(22, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 27);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 35);
            this.label1.TabIndex = 33;
            this.label1.Text = "Venta con factura registrada";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMostrarCliente
            // 
            this.txtMostrarCliente.Location = new System.Drawing.Point(23, 117);
            this.txtMostrarCliente.Name = "txtMostrarCliente";
            this.txtMostrarCliente.Size = new System.Drawing.Size(197, 20);
            this.txtMostrarCliente.TabIndex = 32;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(21, 202);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(60, 16);
            this.lblSubTotal.TabIndex = 25;
            this.lblSubTotal.Text = "Sub total:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(92, 202);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(128, 16);
            this.txtSubTotal.TabIndex = 24;
            // 
            // dtFechaVenta
            // 
            this.dtFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVenta.Location = new System.Drawing.Point(22, 165);
            this.dtFechaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaVenta.Name = "dtFechaVenta";
            this.dtFechaVenta.Size = new System.Drawing.Size(198, 20);
            this.dtFechaVenta.TabIndex = 20;
            // 
            // txtNVenta
            // 
            this.txtNVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNVenta.Enabled = false;
            this.txtNVenta.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNVenta.Location = new System.Drawing.Point(98, 65);
            this.txtNVenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtNVenta.Name = "txtNVenta";
            this.txtNVenta.Size = new System.Drawing.Size(109, 19);
            this.txtNVenta.TabIndex = 17;
            // 
            // lblNVenta
            // 
            this.lblNVenta.AutoSize = true;
            this.lblNVenta.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVenta.Location = new System.Drawing.Point(24, 65);
            this.lblNVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNVenta.Name = "lblNVenta";
            this.lblNVenta.Size = new System.Drawing.Size(60, 16);
            this.lblNVenta.TabIndex = 10;
            this.lblNVenta.Text = "N° Venta:";
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVenta.Location = new System.Drawing.Point(21, 144);
            this.lblFechaVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(95, 16);
            this.lblFechaVenta.TabIndex = 5;
            this.lblFechaVenta.Text = "Fecha de venta:";
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCliente.Location = new System.Drawing.Point(23, 94);
            this.lblCodigoCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(52, 16);
            this.lblCodigoCliente.TabIndex = 1;
            this.lblCodigoCliente.Text = "Cliente :";
            // 
            // lblDetalleVenta
            // 
            this.lblDetalleVenta.AutoSize = true;
            this.lblDetalleVenta.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVenta.Location = new System.Drawing.Point(33, 13);
            this.lblDetalleVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetalleVenta.Name = "lblDetalleVenta";
            this.lblDetalleVenta.Size = new System.Drawing.Size(165, 25);
            this.lblDetalleVenta.TabIndex = 0;
            this.lblDetalleVenta.Text = "Detalle de Venta";
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTexto.Location = new System.Drawing.Point(72, 75);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(327, 21);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Registro y control de las ventas realizadas.";
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(69, 35);
            this.lblMensajeInformativoPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(285, 40);
            this.lblMensajeInformativoPrincipal.TabIndex = 0;
            this.lblMensajeInformativoPrincipal.Text = "Gestión de Ventas";
            // 
            // pnlTablaContenido
            // 
            this.pnlTablaContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTablaContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(235)))));
            this.pnlTablaContenido.Controls.Add(this.lblPagina);
            this.pnlTablaContenido.Controls.Add(this.btnAnterior);
            this.pnlTablaContenido.Controls.Add(this.btnSiguiente);
            this.pnlTablaContenido.Controls.Add(this.lblRegistroVentas);
            this.pnlTablaContenido.Controls.Add(this.dgvVentas);
            this.pnlTablaContenido.Location = new System.Drawing.Point(37, 102);
            this.pnlTablaContenido.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTablaContenido.Name = "pnlTablaContenido";
            this.pnlTablaContenido.Size = new System.Drawing.Size(766, 317);
            this.pnlTablaContenido.TabIndex = 3;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.Black;
            this.lblPagina.Location = new System.Drawing.Point(638, 286);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 32;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.hacia_atras_negro2;
            this.btnAnterior.Location = new System.Drawing.Point(601, 279);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 23);
            this.btnAnterior.TabIndex = 31;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::Vista.Properties.Resources.hacia_adelante_negro;
            this.btnSiguiente.Location = new System.Drawing.Point(725, 279);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 30;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblRegistroVentas
            // 
            this.lblRegistroVentas.AutoSize = true;
            this.lblRegistroVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRegistroVentas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroVentas.Location = new System.Drawing.Point(14, 5);
            this.lblRegistroVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistroVentas.Name = "lblRegistroVentas";
            this.lblRegistroVentas.Size = new System.Drawing.Size(168, 22);
            this.lblRegistroVentas.TabIndex = 29;
            this.lblRegistroVentas.Text = "Registro de Ventas.";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToResizeColumns = false;
            this.dgvVentas.AllowUserToResizeRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentas.GridColor = System.Drawing.Color.Black;
            this.dgvVentas.Location = new System.Drawing.Point(14, 30);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.Size = new System.Drawing.Size(741, 243);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.SelectionChanged += new System.EventHandler(this.dgvVentas_SelectionChanged);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::Vista.Properties.Resources.basura2;
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 740;
            // 
            // btnRegistrarFactura
            // 
            this.btnRegistrarFactura.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegistrarFactura.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegistrarFactura.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegistrarFactura.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegistrarFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegistrarFactura.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarFactura.Location = new System.Drawing.Point(16, 290);
            this.btnRegistrarFactura.Name = "btnRegistrarFactura";
            this.btnRegistrarFactura.Size = new System.Drawing.Size(118, 33);
            this.btnRegistrarFactura.TabIndex = 35;
            this.btnRegistrarFactura.Text = "Registrar Factura";
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(140, 290);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 33);
            this.btnEliminar.TabIndex = 36;
            this.btnEliminar.Text = "Eliminar";
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
            this.txtBuscar.Location = new System.Drawing.Point(600, 50);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(451, 25);
            this.txtBuscar.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(16, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 51);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVentas";
            this.Text = "frmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleDeVenta)).EndInit();
            this.pnlBarraSuperior.ResumeLayout(false);
            this.pnlBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            this.pnlPedidaDeDatos.ResumeLayout(false);
            this.pnlPedidaDeDatos.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlFacturaRegistrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTablaContenido.ResumeLayout(false);
            this.pnlTablaContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlPedidaDeDatos;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.DateTimePicker dtFechaVenta;
        private System.Windows.Forms.TextBox txtNVenta;
        private System.Windows.Forms.Label lblNVenta;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.Label lblDetalleVenta;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.Panel pnlTablaContenido;
        private System.Windows.Forms.Panel pnlBarraSuperior;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDetalleVentas;
        private System.Windows.Forms.DataGridView dgvDetalleDeVenta;
        private System.Windows.Forms.Label lblRegistroVentas;
        private System.Windows.Forms.TextBox txtMostrarCliente;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlFacturaRegistrada;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TileButton btnEliminar;
        private Guna.UI2.WinForms.Guna2TileButton btnRegistrarFactura;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
    }
}