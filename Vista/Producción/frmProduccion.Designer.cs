namespace Vista.Producción
{
    partial class frmProduccion
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
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.lblMostrarRegistrados = new System.Windows.Forms.Label();
            this.pbTotalTrabajos = new System.Windows.Forms.PictureBox();
            this.lblRegistrados = new System.Windows.Forms.Label();
            this.pnlContenedorTabla = new System.Windows.Forms.Panel();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaterialUtilizado = new Guna.UI2.WinForms.Guna2Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnAtrass = new System.Windows.Forms.Button();
            this.btnSiguient = new System.Windows.Forms.Button();
            this.dgvProduccion = new System.Windows.Forms.DataGridView();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.lblMostrarEnProduccion = new System.Windows.Forms.Label();
            this.pbPendientes = new System.Windows.Forms.PictureBox();
            this.lblEnProduccion = new System.Windows.Forms.Label();
            this.pnlBarraInformativa = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.lblMostrarPendientes = new System.Windows.Forms.Label();
            this.pbCancelados = new System.Windows.Forms.PictureBox();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblMostrarFinalizados = new System.Windows.Forms.Label();
            this.pbFinalizados = new System.Windows.Forms.PictureBox();
            this.lblFinalizados = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlIndicador4 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIndicador3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIndicador2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIndicador1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalTrabajos)).BeginInit();
            this.pnlContenedorTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPendientes)).BeginInit();
            this.pnlBarraInformativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizados)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlIndicador4.SuspendLayout();
            this.pnlIndicador3.SuspendLayout();
            this.pnlIndicador2.SuspendLayout();
            this.pnlIndicador1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTexto.Location = new System.Drawing.Point(35, 90);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(383, 21);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Seguimiento de los trabajos que están en proceso.";
            // 
            // cbEstados
            // 
            this.cbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstados.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Items.AddRange(new object[] {
            "Finalizado",
            "Pendiente",
            "En producción"});
            this.cbEstados.Location = new System.Drawing.Point(53, 231);
            this.cbEstados.Margin = new System.Windows.Forms.Padding(2);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(217, 29);
            this.cbEstados.TabIndex = 9;
            this.cbEstados.SelectedIndexChanged += new System.EventHandler(this.cbEstados_SelectedIndexChanged);
            // 
            // lblMostrarRegistrados
            // 
            this.lblMostrarRegistrados.AutoSize = true;
            this.lblMostrarRegistrados.Location = new System.Drawing.Point(115, 46);
            this.lblMostrarRegistrados.Name = "lblMostrarRegistrados";
            this.lblMostrarRegistrados.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarRegistrados.TabIndex = 5;
            this.lblMostrarRegistrados.Text = "label4";
            // 
            // pbTotalTrabajos
            // 
            this.pbTotalTrabajos.Image = global::Vista.Properties.Resources.Total_de_trabajos;
            this.pbTotalTrabajos.Location = new System.Drawing.Point(3, 3);
            this.pbTotalTrabajos.Name = "pbTotalTrabajos";
            this.pbTotalTrabajos.Size = new System.Drawing.Size(62, 66);
            this.pbTotalTrabajos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTotalTrabajos.TabIndex = 4;
            this.pbTotalTrabajos.TabStop = false;
            // 
            // lblRegistrados
            // 
            this.lblRegistrados.AutoSize = true;
            this.lblRegistrados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrados.Location = new System.Drawing.Point(71, 14);
            this.lblRegistrados.Name = "lblRegistrados";
            this.lblRegistrados.Size = new System.Drawing.Size(128, 19);
            this.lblRegistrados.TabIndex = 3;
            this.lblRegistrados.Text = "Total Registrados";
            // 
            // pnlContenedorTabla
            // 
            this.pnlContenedorTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedorTabla.BackColor = System.Drawing.Color.White;
            this.pnlContenedorTabla.Controls.Add(this.btnEditar);
            this.pnlContenedorTabla.Controls.Add(this.btnMaterialUtilizado);
            this.pnlContenedorTabla.Controls.Add(this.lblPage);
            this.pnlContenedorTabla.Controls.Add(this.btnAtrass);
            this.pnlContenedorTabla.Controls.Add(this.btnSiguient);
            this.pnlContenedorTabla.Controls.Add(this.dgvProduccion);
            this.pnlContenedorTabla.Location = new System.Drawing.Point(29, 268);
            this.pnlContenedorTabla.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedorTabla.Name = "pnlContenedorTabla";
            this.pnlContenedorTabla.Size = new System.Drawing.Size(1045, 337);
            this.pnlContenedorTabla.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(19, 296);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(183, 30);
            this.btnEditar.TabIndex = 29;
            this.btnEditar.Text = "Editar ";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnMaterialUtilizado
            // 
            this.btnMaterialUtilizado.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaterialUtilizado.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaterialUtilizado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaterialUtilizado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaterialUtilizado.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialUtilizado.ForeColor = System.Drawing.Color.White;
            this.btnMaterialUtilizado.Location = new System.Drawing.Point(209, 296);
            this.btnMaterialUtilizado.Name = "btnMaterialUtilizado";
            this.btnMaterialUtilizado.Size = new System.Drawing.Size(239, 30);
            this.btnMaterialUtilizado.TabIndex = 29;
            this.btnMaterialUtilizado.Text = "Gestión de materiales utilizados";
            this.btnMaterialUtilizado.Click += new System.EventHandler(this.btnMaterialUtilizado_Click_1);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.ForeColor = System.Drawing.Color.Black;
            this.lblPage.Location = new System.Drawing.Point(913, 303);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(39, 13);
            this.lblPage.TabIndex = 10;
            this.lblPage.Text = "label1";
            // 
            // btnAtrass
            // 
            this.btnAtrass.FlatAppearance.BorderSize = 0;
            this.btnAtrass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtrass.Image = global::Vista.Properties.Resources.hacia_atras_negro2;
            this.btnAtrass.Location = new System.Drawing.Point(876, 298);
            this.btnAtrass.Name = "btnAtrass";
            this.btnAtrass.Size = new System.Drawing.Size(30, 23);
            this.btnAtrass.TabIndex = 9;
            this.btnAtrass.UseVisualStyleBackColor = true;
            this.btnAtrass.Click += new System.EventHandler(this.btnAtrass_Click);
            // 
            // btnSiguient
            // 
            this.btnSiguient.FlatAppearance.BorderSize = 0;
            this.btnSiguient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguient.Image = global::Vista.Properties.Resources.hacia_adelante_negro;
            this.btnSiguient.Location = new System.Drawing.Point(1000, 296);
            this.btnSiguient.Name = "btnSiguient";
            this.btnSiguient.Size = new System.Drawing.Size(30, 23);
            this.btnSiguient.TabIndex = 8;
            this.btnSiguient.UseVisualStyleBackColor = true;
            this.btnSiguient.Click += new System.EventHandler(this.btnSiguient_Click);
            // 
            // dgvProduccion
            // 
            this.dgvProduccion.AllowUserToDeleteRows = false;
            this.dgvProduccion.AllowUserToResizeColumns = false;
            this.dgvProduccion.AllowUserToResizeRows = false;
            this.dgvProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduccion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProduccion.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduccion.ColumnHeadersHeight = 42;
            this.dgvProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduccion.GridColor = System.Drawing.Color.Black;
            this.dgvProduccion.Location = new System.Drawing.Point(19, 6);
            this.dgvProduccion.Name = "dgvProduccion";
            this.dgvProduccion.ReadOnly = true;
            this.dgvProduccion.RowHeadersVisible = false;
            this.dgvProduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProduccion.Size = new System.Drawing.Size(1011, 274);
            this.dgvProduccion.TabIndex = 3;
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(25, 41);
            this.lblMensajeInformativoPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(534, 40);
            this.lblMensajeInformativoPrincipal.TabIndex = 0;
            this.lblMensajeInformativoPrincipal.Text = "Control de producción de trabajos";
            // 
            // lblMostrarEnProduccion
            // 
            this.lblMostrarEnProduccion.AutoSize = true;
            this.lblMostrarEnProduccion.Location = new System.Drawing.Point(115, 43);
            this.lblMostrarEnProduccion.Name = "lblMostrarEnProduccion";
            this.lblMostrarEnProduccion.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarEnProduccion.TabIndex = 4;
            this.lblMostrarEnProduccion.Text = "label3";
            // 
            // pbPendientes
            // 
            this.pbPendientes.Image = global::Vista.Properties.Resources.Reloj_Pendiente;
            this.pbPendientes.Location = new System.Drawing.Point(13, 5);
            this.pbPendientes.Name = "pbPendientes";
            this.pbPendientes.Size = new System.Drawing.Size(62, 68);
            this.pbPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPendientes.TabIndex = 3;
            this.pbPendientes.TabStop = false;
            // 
            // lblEnProduccion
            // 
            this.lblEnProduccion.AutoSize = true;
            this.lblEnProduccion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnProduccion.Location = new System.Drawing.Point(93, 13);
            this.lblEnProduccion.Name = "lblEnProduccion";
            this.lblEnProduccion.Size = new System.Drawing.Size(103, 19);
            this.lblEnProduccion.TabIndex = 2;
            this.lblEnProduccion.Text = "En producción";
            // 
            // pnlBarraInformativa
            // 
            this.pnlBarraInformativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pnlBarraInformativa.Controls.Add(this.lblAdministrador);
            this.pnlBarraInformativa.Controls.Add(this.pbPerfil);
            this.pnlBarraInformativa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraInformativa.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraInformativa.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBarraInformativa.Name = "pnlBarraInformativa";
            this.pnlBarraInformativa.Size = new System.Drawing.Size(1102, 23);
            this.pnlBarraInformativa.TabIndex = 12;
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
            this.pbPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(177)))), ((int)(((byte)(114)))));
            this.pbPerfil.Image = global::Vista.Properties.Resources.user_456283;
            this.pbPerfil.Location = new System.Drawing.Point(1054, -1);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(26, 24);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerfil.TabIndex = 25;
            this.pbPerfil.TabStop = false;
            // 
            // lblMostrarPendientes
            // 
            this.lblMostrarPendientes.AutoSize = true;
            this.lblMostrarPendientes.Location = new System.Drawing.Point(119, 44);
            this.lblMostrarPendientes.Name = "lblMostrarPendientes";
            this.lblMostrarPendientes.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarPendientes.TabIndex = 2;
            this.lblMostrarPendientes.Text = "label1";
            // 
            // pbCancelados
            // 
            this.pbCancelados.Image = global::Vista.Properties.Resources.Trabajo_cancelado;
            this.pbCancelados.Location = new System.Drawing.Point(16, 5);
            this.pbCancelados.Name = "pbCancelados";
            this.pbCancelados.Size = new System.Drawing.Size(67, 67);
            this.pbCancelados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancelados.TabIndex = 1;
            this.pbCancelados.TabStop = false;
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(101, 13);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(82, 19);
            this.lblPendientes.TabIndex = 0;
            this.lblPendientes.Text = "Pendientes";
            // 
            // lblMostrarFinalizados
            // 
            this.lblMostrarFinalizados.AutoSize = true;
            this.lblMostrarFinalizados.Location = new System.Drawing.Point(109, 45);
            this.lblMostrarFinalizados.Name = "lblMostrarFinalizados";
            this.lblMostrarFinalizados.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarFinalizados.TabIndex = 3;
            this.lblMostrarFinalizados.Text = "label2";
            // 
            // pbFinalizados
            // 
            this.pbFinalizados.Image = global::Vista.Properties.Resources.Trabajo_finalizado;
            this.pbFinalizados.Location = new System.Drawing.Point(16, 1);
            this.pbFinalizados.Name = "pbFinalizados";
            this.pbFinalizados.Size = new System.Drawing.Size(68, 74);
            this.pbFinalizados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFinalizados.TabIndex = 2;
            this.pbFinalizados.TabStop = false;
            // 
            // lblFinalizados
            // 
            this.lblFinalizados.AutoSize = true;
            this.lblFinalizados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalizados.Location = new System.Drawing.Point(93, 14);
            this.lblFinalizados.Name = "lblFinalizados";
            this.lblFinalizados.Size = new System.Drawing.Size(83, 19);
            this.lblFinalizados.TabIndex = 1;
            this.lblFinalizados.Text = "Finalizados";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.pnlIndicador4);
            this.pnlHeader.Controls.Add(this.pnlIndicador3);
            this.pnlHeader.Controls.Add(this.pnlIndicador2);
            this.pnlHeader.Controls.Add(this.pnlIndicador1);
            this.pnlHeader.Controls.Add(this.btnLimpiar);
            this.pnlHeader.Controls.Add(this.pnlBarraInformativa);
            this.pnlHeader.Controls.Add(this.lblSubTexto);
            this.pnlHeader.Controls.Add(this.cbEstados);
            this.pnlHeader.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlHeader.Controls.Add(this.pnlContenedorTabla);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1102, 627);
            this.pnlHeader.TabIndex = 3;
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
            this.txtBuscar.Location = new System.Drawing.Point(282, 227);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(499, 31);
            this.txtBuscar.TabIndex = 33;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pnlIndicador4
            // 
            this.pnlIndicador4.BackColor = System.Drawing.Color.White;
            this.pnlIndicador4.Controls.Add(this.lblMostrarRegistrados);
            this.pnlIndicador4.Controls.Add(this.pbTotalTrabajos);
            this.pnlIndicador4.Controls.Add(this.lblRegistrados);
            this.pnlIndicador4.Location = new System.Drawing.Point(704, 132);
            this.pnlIndicador4.Name = "pnlIndicador4";
            this.pnlIndicador4.Size = new System.Drawing.Size(208, 78);
            this.pnlIndicador4.TabIndex = 32;
            // 
            // pnlIndicador3
            // 
            this.pnlIndicador3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(237)))), ((int)(((byte)(147)))));
            this.pnlIndicador3.Controls.Add(this.lblMostrarFinalizados);
            this.pnlIndicador3.Controls.Add(this.pbFinalizados);
            this.pnlIndicador3.Controls.Add(this.lblFinalizados);
            this.pnlIndicador3.Location = new System.Drawing.Point(487, 132);
            this.pnlIndicador3.Name = "pnlIndicador3";
            this.pnlIndicador3.Size = new System.Drawing.Size(208, 78);
            this.pnlIndicador3.TabIndex = 31;
            // 
            // pnlIndicador2
            // 
            this.pnlIndicador2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlIndicador2.Controls.Add(this.lblMostrarEnProduccion);
            this.pnlIndicador2.Controls.Add(this.pbPendientes);
            this.pnlIndicador2.Controls.Add(this.lblEnProduccion);
            this.pnlIndicador2.Location = new System.Drawing.Point(269, 133);
            this.pnlIndicador2.Name = "pnlIndicador2";
            this.pnlIndicador2.Size = new System.Drawing.Size(208, 78);
            this.pnlIndicador2.TabIndex = 30;
            // 
            // pnlIndicador1
            // 
            this.pnlIndicador1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.pnlIndicador1.Controls.Add(this.lblMostrarPendientes);
            this.pnlIndicador1.Controls.Add(this.pbCancelados);
            this.pnlIndicador1.Controls.Add(this.lblPendientes);
            this.pnlIndicador1.Location = new System.Drawing.Point(48, 133);
            this.pnlIndicador1.Name = "pnlIndicador1";
            this.pnlIndicador1.Size = new System.Drawing.Size(208, 78);
            this.pnlIndicador1.TabIndex = 29;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLimpiar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(806, 227);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 32);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.White;
            this.lblPagina.Location = new System.Drawing.Point(482, 162);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 13;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.flecha_atras;
            this.btnAnterior.Location = new System.Drawing.Point(445, 157);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 23);
            this.btnAnterior.TabIndex = 12;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::Vista.Properties.Resources.flecha_adelante;
            this.btnSiguiente.Location = new System.Drawing.Point(569, 157);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 11;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 25);
            this.button1.TabIndex = 28;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmProduccion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProduccion";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProduccion";
            this.Load += new System.EventHandler(this.frmProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalTrabajos)).EndInit();
            this.pnlContenedorTabla.ResumeLayout(false);
            this.pnlContenedorTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPendientes)).EndInit();
            this.pnlBarraInformativa.ResumeLayout(false);
            this.pnlBarraInformativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizados)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlIndicador4.ResumeLayout(false);
            this.pnlIndicador4.PerformLayout();
            this.pnlIndicador3.ResumeLayout(false);
            this.pnlIndicador3.PerformLayout();
            this.pnlIndicador2.ResumeLayout(false);
            this.pnlIndicador2.PerformLayout();
            this.pnlIndicador1.ResumeLayout(false);
            this.pnlIndicador1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.PictureBox pbTotalTrabajos;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.Label lblRegistrados;
        private System.Windows.Forms.Panel pnlContenedorTabla;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.PictureBox pbPendientes;
        private System.Windows.Forms.Label lblEnProduccion;
        private System.Windows.Forms.Panel pnlBarraInformativa;
        private System.Windows.Forms.PictureBox pbCancelados;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.PictureBox pbFinalizados;
        private System.Windows.Forms.Label lblFinalizados;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.DataGridView dgvProduccion;
        private System.Windows.Forms.Label lblMostrarRegistrados;
        private System.Windows.Forms.Label lblMostrarEnProduccion;
        private System.Windows.Forms.Label lblMostrarPendientes;
        private System.Windows.Forms.Label lblMostrarFinalizados;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnAtrass;
        private System.Windows.Forms.Button btnSiguient;
        private Guna.UI2.WinForms.Guna2Button btnMaterialUtilizado;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Panel pnlIndicador1;
        private Guna.UI2.WinForms.Guna2Panel pnlIndicador4;
        private Guna.UI2.WinForms.Guna2Panel pnlIndicador3;
        private Guna.UI2.WinForms.Guna2Panel pnlIndicador2;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
    }
}
