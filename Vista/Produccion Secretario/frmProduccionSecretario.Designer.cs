namespace Vista.Produccion_Secretario
{
    partial class frmProduccionSecretario
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
            this.lblFinalizados = new System.Windows.Forms.Label();
            this.pnlIndicador2 = new System.Windows.Forms.Panel();
            this.lblMostrarFinalizados = new System.Windows.Forms.Label();
            this.pbFinalizados = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenedorTabla = new System.Windows.Forms.Panel();
            this.dgvProduccion = new System.Windows.Forms.DataGridView();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnAtrass = new System.Windows.Forms.Button();
            this.btnSiguient = new System.Windows.Forms.Button();
            this.btnMaterialUtilizado = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pnlIndicador1 = new System.Windows.Forms.Panel();
            this.lblMostrarPendientes = new System.Windows.Forms.Label();
            this.pbCancelados = new System.Windows.Forms.PictureBox();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.pnlIndicador3 = new System.Windows.Forms.Panel();
            this.lblMostrarEnProduccion = new System.Windows.Forms.Label();
            this.pbPendientes = new System.Windows.Forms.PictureBox();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.lblRegistrados = new System.Windows.Forms.Label();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.pnlIndicador4 = new System.Windows.Forms.Panel();
            this.lblMostrarRegistrados = new System.Windows.Forms.Label();
            this.pbTotalRegistros = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlBarraInformativa = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicador2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizados)).BeginInit();
            this.pnlContenedorTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).BeginInit();
            this.pnlIndicador1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelados)).BeginInit();
            this.pnlIndicador3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPendientes)).BeginInit();
            this.pnlIndicador4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalRegistros)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBarraInformativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFinalizados
            // 
            this.lblFinalizados.AutoSize = true;
            this.lblFinalizados.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblFinalizados.Location = new System.Drawing.Point(106, 11);
            this.lblFinalizados.Name = "lblFinalizados";
            this.lblFinalizados.Size = new System.Drawing.Size(103, 22);
            this.lblFinalizados.TabIndex = 1;
            this.lblFinalizados.Text = "Finalizados";
            // 
            // pnlIndicador2
            // 
            this.pnlIndicador2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(237)))), ((int)(((byte)(147)))));
            this.pnlIndicador2.Controls.Add(this.lblMostrarFinalizados);
            this.pnlIndicador2.Controls.Add(this.pbFinalizados);
            this.pnlIndicador2.Controls.Add(this.lblFinalizados);
            this.pnlIndicador2.Location = new System.Drawing.Point(272, 134);
            this.pnlIndicador2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador2.Name = "pnlIndicador2";
            this.pnlIndicador2.Size = new System.Drawing.Size(221, 77);
            this.pnlIndicador2.TabIndex = 8;
            // 
            // lblMostrarFinalizados
            // 
            this.lblMostrarFinalizados.AutoSize = true;
            this.lblMostrarFinalizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarFinalizados.Location = new System.Drawing.Point(142, 43);
            this.lblMostrarFinalizados.Name = "lblMostrarFinalizados";
            this.lblMostrarFinalizados.Size = new System.Drawing.Size(18, 25);
            this.lblMostrarFinalizados.TabIndex = 4;
            this.lblMostrarFinalizados.Text = "l";
            // 
            // pbFinalizados
            // 
            this.pbFinalizados.Image = global::Vista.Properties.Resources.Trabajo_finalizado;
            this.pbFinalizados.Location = new System.Drawing.Point(24, 1);
            this.pbFinalizados.Name = "pbFinalizados";
            this.pbFinalizados.Size = new System.Drawing.Size(68, 74);
            this.pbFinalizados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFinalizados.TabIndex = 2;
            this.pbFinalizados.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(102, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancelados";
            // 
            // pnlContenedorTabla
            // 
            this.pnlContenedorTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedorTabla.BackColor = System.Drawing.Color.White;
            this.pnlContenedorTabla.Controls.Add(this.dgvProduccion);
            this.pnlContenedorTabla.Controls.Add(this.lblPage);
            this.pnlContenedorTabla.Controls.Add(this.btnAtrass);
            this.pnlContenedorTabla.Controls.Add(this.btnSiguient);
            this.pnlContenedorTabla.Controls.Add(this.btnMaterialUtilizado);
            this.pnlContenedorTabla.Controls.Add(this.btnEditar);
            this.pnlContenedorTabla.Location = new System.Drawing.Point(29, 268);
            this.pnlContenedorTabla.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedorTabla.Name = "pnlContenedorTabla";
            this.pnlContenedorTabla.Size = new System.Drawing.Size(1045, 337);
            this.pnlContenedorTabla.TabIndex = 3;
            // 
            // dgvProduccion
            // 
            this.dgvProduccion.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduccion.Location = new System.Drawing.Point(15, 14);
            this.dgvProduccion.Name = "dgvProduccion";
            this.dgvProduccion.Size = new System.Drawing.Size(1014, 274);
            this.dgvProduccion.TabIndex = 14;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.ForeColor = System.Drawing.Color.Black;
            this.lblPage.Location = new System.Drawing.Point(905, 306);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(39, 13);
            this.lblPage.TabIndex = 13;
            this.lblPage.Text = "label1";
            // 
            // btnAtrass
            // 
            this.btnAtrass.FlatAppearance.BorderSize = 0;
            this.btnAtrass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtrass.Image = global::Vista.Properties.Resources.hacia_atras_negro2;
            this.btnAtrass.Location = new System.Drawing.Point(868, 301);
            this.btnAtrass.Name = "btnAtrass";
            this.btnAtrass.Size = new System.Drawing.Size(30, 23);
            this.btnAtrass.TabIndex = 12;
            this.btnAtrass.UseVisualStyleBackColor = true;
            this.btnAtrass.Click += new System.EventHandler(this.btnAtrass_Click);
            // 
            // btnSiguient
            // 
            this.btnSiguient.FlatAppearance.BorderSize = 0;
            this.btnSiguient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguient.Image = global::Vista.Properties.Resources.hacia_adelante_negro;
            this.btnSiguient.Location = new System.Drawing.Point(992, 301);
            this.btnSiguient.Name = "btnSiguient";
            this.btnSiguient.Size = new System.Drawing.Size(30, 23);
            this.btnSiguient.TabIndex = 11;
            this.btnSiguient.UseVisualStyleBackColor = true;
            this.btnSiguient.Click += new System.EventHandler(this.btnSiguient_Click);
            // 
            // btnMaterialUtilizado
            // 
            this.btnMaterialUtilizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaterialUtilizado.BackColor = System.Drawing.Color.SandyBrown;
            this.btnMaterialUtilizado.FlatAppearance.BorderSize = 0;
            this.btnMaterialUtilizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterialUtilizado.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialUtilizado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMaterialUtilizado.Location = new System.Drawing.Point(251, 294);
            this.btnMaterialUtilizado.Name = "btnMaterialUtilizado";
            this.btnMaterialUtilizado.Size = new System.Drawing.Size(219, 35);
            this.btnMaterialUtilizado.TabIndex = 5;
            this.btnMaterialUtilizado.Text = "Gestion de Material Utilizado";
            this.btnMaterialUtilizado.UseVisualStyleBackColor = false;
            this.btnMaterialUtilizado.Click += new System.EventHandler(this.btnMaterialUtilizado_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(61)))), ((int)(((byte)(21)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Location = new System.Drawing.Point(19, 294);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(219, 35);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pnlIndicador1
            // 
            this.pnlIndicador1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.pnlIndicador1.Controls.Add(this.lblMostrarPendientes);
            this.pnlIndicador1.Controls.Add(this.pbCancelados);
            this.pnlIndicador1.Controls.Add(this.label1);
            this.pnlIndicador1.Location = new System.Drawing.Point(48, 134);
            this.pnlIndicador1.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador1.Name = "pnlIndicador1";
            this.pnlIndicador1.Size = new System.Drawing.Size(219, 77);
            this.pnlIndicador1.TabIndex = 7;
            // 
            // lblMostrarPendientes
            // 
            this.lblMostrarPendientes.AutoSize = true;
            this.lblMostrarPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarPendientes.Location = new System.Drawing.Point(136, 37);
            this.lblMostrarPendientes.Name = "lblMostrarPendientes";
            this.lblMostrarPendientes.Size = new System.Drawing.Size(18, 25);
            this.lblMostrarPendientes.TabIndex = 3;
            this.lblMostrarPendientes.Text = "l";
            // 
            // pbCancelados
            // 
            this.pbCancelados.Image = global::Vista.Properties.Resources.Trabajo_cancelado;
            this.pbCancelados.Location = new System.Drawing.Point(24, 5);
            this.pbCancelados.Name = "pbCancelados";
            this.pbCancelados.Size = new System.Drawing.Size(67, 67);
            this.pbCancelados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancelados.TabIndex = 1;
            this.pbCancelados.TabStop = false;
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblPendientes.Location = new System.Drawing.Point(110, 13);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(98, 22);
            this.lblPendientes.TabIndex = 2;
            this.lblPendientes.Text = "Pendientes";
            // 
            // pnlIndicador3
            // 
            this.pnlIndicador3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.pnlIndicador3.Controls.Add(this.lblMostrarEnProduccion);
            this.pnlIndicador3.Controls.Add(this.pbPendientes);
            this.pnlIndicador3.Controls.Add(this.lblPendientes);
            this.pnlIndicador3.Location = new System.Drawing.Point(498, 133);
            this.pnlIndicador3.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador3.Name = "pnlIndicador3";
            this.pnlIndicador3.Size = new System.Drawing.Size(221, 77);
            this.pnlIndicador3.TabIndex = 6;
            // 
            // lblMostrarEnProduccion
            // 
            this.lblMostrarEnProduccion.AutoSize = true;
            this.lblMostrarEnProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarEnProduccion.Location = new System.Drawing.Point(143, 44);
            this.lblMostrarEnProduccion.Name = "lblMostrarEnProduccion";
            this.lblMostrarEnProduccion.Size = new System.Drawing.Size(18, 25);
            this.lblMostrarEnProduccion.TabIndex = 5;
            this.lblMostrarEnProduccion.Text = "l";
            // 
            // pbPendientes
            // 
            this.pbPendientes.Image = global::Vista.Properties.Resources.Reloj_Pendiente;
            this.pbPendientes.Location = new System.Drawing.Point(26, 4);
            this.pbPendientes.Name = "pbPendientes";
            this.pbPendientes.Size = new System.Drawing.Size(62, 68);
            this.pbPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPendientes.TabIndex = 3;
            this.pbPendientes.TabStop = false;
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(74, 35);
            this.lblMensajeInformativoPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(534, 40);
            this.lblMensajeInformativoPrincipal.TabIndex = 0;
            this.lblMensajeInformativoPrincipal.Text = "Control de producción de trabajos";
            // 
            // lblRegistrados
            // 
            this.lblRegistrados.AutoSize = true;
            this.lblRegistrados.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lblRegistrados.Location = new System.Drawing.Point(85, 13);
            this.lblRegistrados.Name = "lblRegistrados";
            this.lblRegistrados.Size = new System.Drawing.Size(144, 20);
            this.lblRegistrados.TabIndex = 3;
            this.lblRegistrados.Text = "Total Registrados";
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTexto.Location = new System.Drawing.Point(80, 77);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(383, 21);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Seguimiento de los trabajos que están en proceso.";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(797, 228);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(159, 29);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbEstados
            // 
            this.cbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstados.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Items.AddRange(new object[] {
            "Pendiente",
            "En producción",
            "Finalizado"});
            this.cbEstados.Location = new System.Drawing.Point(53, 231);
            this.cbEstados.Margin = new System.Windows.Forms.Padding(2);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(217, 29);
            this.cbEstados.TabIndex = 9;
            this.cbEstados.SelectedIndexChanged += new System.EventHandler(this.cbEstados_SelectedIndexChanged);
            // 
            // pnlIndicador4
            // 
            this.pnlIndicador4.BackColor = System.Drawing.Color.White;
            this.pnlIndicador4.Controls.Add(this.lblMostrarRegistrados);
            this.pnlIndicador4.Controls.Add(this.pbTotalRegistros);
            this.pnlIndicador4.Controls.Add(this.lblRegistrados);
            this.pnlIndicador4.Location = new System.Drawing.Point(724, 133);
            this.pnlIndicador4.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador4.Name = "pnlIndicador4";
            this.pnlIndicador4.Size = new System.Drawing.Size(232, 77);
            this.pnlIndicador4.TabIndex = 5;
            // 
            // lblMostrarRegistrados
            // 
            this.lblMostrarRegistrados.AutoSize = true;
            this.lblMostrarRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarRegistrados.Location = new System.Drawing.Point(147, 44);
            this.lblMostrarRegistrados.Name = "lblMostrarRegistrados";
            this.lblMostrarRegistrados.Size = new System.Drawing.Size(18, 25);
            this.lblMostrarRegistrados.TabIndex = 6;
            this.lblMostrarRegistrados.Text = "l";
            // 
            // pbTotalRegistros
            // 
            this.pbTotalRegistros.Image = global::Vista.Properties.Resources.Total_de_trabajos;
            this.pbTotalRegistros.Location = new System.Drawing.Point(22, 5);
            this.pbTotalRegistros.Name = "pbTotalRegistros";
            this.pbTotalRegistros.Size = new System.Drawing.Size(62, 66);
            this.pbTotalRegistros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTotalRegistros.TabIndex = 4;
            this.pbTotalRegistros.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.pnlBarraInformativa);
            this.pnlHeader.Controls.Add(this.lblSubTexto);
            this.pnlHeader.Controls.Add(this.btnLimpiar);
            this.pnlHeader.Controls.Add(this.cbEstados);
            this.pnlHeader.Controls.Add(this.pnlIndicador4);
            this.pnlHeader.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlHeader.Controls.Add(this.pnlIndicador3);
            this.pnlHeader.Controls.Add(this.pnlContenedorTabla);
            this.pnlHeader.Controls.Add(this.pnlIndicador1);
            this.pnlHeader.Controls.Add(this.pnlIndicador2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1102, 627);
            this.pnlHeader.TabIndex = 2;
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
            this.txtBuscar.Location = new System.Drawing.Point(289, 228);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(482, 29);
            this.txtBuscar.TabIndex = 13;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
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
            this.lblAdministrador.Location = new System.Drawing.Point(998, 4);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(53, 14);
            this.lblAdministrador.TabIndex = 27;
            this.lblAdministrador.Text = "Secretario";
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.produccion;
            this.pictureBox1.Location = new System.Drawing.Point(9, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // frmProduccionSecretario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProduccionSecretario";
            this.Text = "frmProduccionSecretario";
            this.Load += new System.EventHandler(this.frmProduccionSecretario_Load);
            this.pnlIndicador2.ResumeLayout(false);
            this.pnlIndicador2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizados)).EndInit();
            this.pnlContenedorTabla.ResumeLayout(false);
            this.pnlContenedorTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).EndInit();
            this.pnlIndicador1.ResumeLayout(false);
            this.pnlIndicador1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelados)).EndInit();
            this.pnlIndicador3.ResumeLayout(false);
            this.pnlIndicador3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPendientes)).EndInit();
            this.pnlIndicador4.ResumeLayout(false);
            this.pnlIndicador4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalRegistros)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBarraInformativa.ResumeLayout(false);
            this.pnlBarraInformativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFinalizados;
        private System.Windows.Forms.Panel pnlIndicador2;
        private System.Windows.Forms.PictureBox pbFinalizados;
        private System.Windows.Forms.PictureBox pbCancelados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContenedorTabla;
        private System.Windows.Forms.Panel pnlIndicador1;
        private System.Windows.Forms.PictureBox pbPendientes;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Panel pnlIndicador3;
        private System.Windows.Forms.PictureBox pbTotalRegistros;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.Label lblRegistrados;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.Panel pnlIndicador4;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBarraInformativa;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Button btnMaterialUtilizado;
        private System.Windows.Forms.Label lblMostrarPendientes;
        private System.Windows.Forms.Label lblMostrarFinalizados;
        private System.Windows.Forms.Label lblMostrarEnProduccion;
        private System.Windows.Forms.Label lblMostrarRegistrados;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnAtrass;
        private System.Windows.Forms.Button btnSiguient;
        private System.Windows.Forms.DataGridView dgvProduccion;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}