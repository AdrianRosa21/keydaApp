namespace Vista.Iventario_Secretario
{
    partial class frmInventarioSecretario
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
            this.lblPocasUnidades = new System.Windows.Forms.Label();
            this.cbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblMedida = new System.Windows.Forms.Label();
            this.pnlIndicador = new System.Windows.Forms.Panel();
            this.lblMaterialesAgotados = new System.Windows.Forms.Label();
            this.lblAgotados = new System.Windows.Forms.Label();
            this.pbAgotados = new System.Windows.Forms.PictureBox();
            this.pnlIndicador1 = new System.Windows.Forms.Panel();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.lblMaterialDisponible = new System.Windows.Forms.Label();
            this.pbDisponibles = new System.Windows.Forms.PictureBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.pnlIndicador2 = new System.Windows.Forms.Panel();
            this.lblAgotandose = new System.Windows.Forms.Label();
            this.pbPocasUnidades = new System.Windows.Forms.PictureBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.dgvMateriales = new System.Windows.Forms.DataGridView();
            this.lblDatosMaterial = new System.Windows.Forms.Label();
            this.pnlIndicador3 = new System.Windows.Forms.Panel();
            this.lblTotalRegistrados = new System.Windows.Forms.Label();
            this.lblTotalInventario = new System.Windows.Forms.Label();
            this.pbTotalRegistros = new System.Windows.Forms.PictureBox();
            this.pnlBarraSuperior = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.pnlPedidaDeDatos = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.pnlContenedorPrincipalInventario = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgotados)).BeginInit();
            this.pnlIndicador1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisponibles)).BeginInit();
            this.pnlIndicador2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPocasUnidades)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriales)).BeginInit();
            this.pnlIndicador3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalRegistros)).BeginInit();
            this.pnlBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            this.pnlPedidaDeDatos.SuspendLayout();
            this.pnlContenedorPrincipalInventario.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPocasUnidades
            // 
            this.lblPocasUnidades.AutoSize = true;
            this.lblPocasUnidades.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblPocasUnidades.Location = new System.Drawing.Point(90, 11);
            this.lblPocasUnidades.Name = "lblPocasUnidades";
            this.lblPocasUnidades.Size = new System.Drawing.Size(111, 17);
            this.lblPocasUnidades.TabIndex = 5;
            this.lblPocasUnidades.Text = "Pocas Unidades";
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidadMedida.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.Items.AddRange(new object[] {
            "Centimetros",
            "Metros",
            "Pliegos"});
            this.cbUnidadMedida.Location = new System.Drawing.Point(21, 301);
            this.cbUnidadMedida.Margin = new System.Windows.Forms.Padding(2);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(182, 27);
            this.cbUnidadMedida.TabIndex = 18;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnGuardar.Location = new System.Drawing.Point(118, 342);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 36);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnEditar.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnEditar.Location = new System.Drawing.Point(22, 342);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(91, 36);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMedida.Location = new System.Drawing.Point(19, 270);
            this.lblMedida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(123, 19);
            this.lblMedida.TabIndex = 8;
            this.lblMedida.Text = "Unidad de medida:";
            // 
            // pnlIndicador
            // 
            this.pnlIndicador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.pnlIndicador.Controls.Add(this.lblMaterialesAgotados);
            this.pnlIndicador.Controls.Add(this.lblAgotados);
            this.pnlIndicador.Controls.Add(this.pbAgotados);
            this.pnlIndicador.Location = new System.Drawing.Point(260, 533);
            this.pnlIndicador.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador.Name = "pnlIndicador";
            this.pnlIndicador.Size = new System.Drawing.Size(201, 77);
            this.pnlIndicador.TabIndex = 4;
            // 
            // lblMaterialesAgotados
            // 
            this.lblMaterialesAgotados.AutoSize = true;
            this.lblMaterialesAgotados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialesAgotados.Location = new System.Drawing.Point(132, 39);
            this.lblMaterialesAgotados.Name = "lblMaterialesAgotados";
            this.lblMaterialesAgotados.Size = new System.Drawing.Size(18, 25);
            this.lblMaterialesAgotados.TabIndex = 6;
            this.lblMaterialesAgotados.Text = "l";
            // 
            // lblAgotados
            // 
            this.lblAgotados.AutoSize = true;
            this.lblAgotados.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblAgotados.Location = new System.Drawing.Point(115, 12);
            this.lblAgotados.Name = "lblAgotados";
            this.lblAgotados.Size = new System.Drawing.Size(70, 17);
            this.lblAgotados.TabIndex = 4;
            this.lblAgotados.Text = "Agotados";
            // 
            // pbAgotados
            // 
            this.pbAgotados.Image = global::Vista.Properties.Resources.material_no_disponible;
            this.pbAgotados.Location = new System.Drawing.Point(19, 7);
            this.pbAgotados.Name = "pbAgotados";
            this.pbAgotados.Size = new System.Drawing.Size(80, 64);
            this.pbAgotados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAgotados.TabIndex = 2;
            this.pbAgotados.TabStop = false;
            // 
            // pnlIndicador1
            // 
            this.pnlIndicador1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(237)))), ((int)(((byte)(147)))));
            this.pnlIndicador1.Controls.Add(this.lblDisponibles);
            this.pnlIndicador1.Controls.Add(this.lblMaterialDisponible);
            this.pnlIndicador1.Controls.Add(this.pbDisponibles);
            this.pnlIndicador1.Location = new System.Drawing.Point(467, 533);
            this.pnlIndicador1.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador1.Name = "pnlIndicador1";
            this.pnlIndicador1.Size = new System.Drawing.Size(201, 77);
            this.pnlIndicador1.TabIndex = 4;
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.Location = new System.Drawing.Point(133, 44);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(18, 25);
            this.lblDisponibles.TabIndex = 7;
            this.lblDisponibles.Text = "l";
            // 
            // lblMaterialDisponible
            // 
            this.lblMaterialDisponible.AutoSize = true;
            this.lblMaterialDisponible.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaterialDisponible.Location = new System.Drawing.Point(108, 12);
            this.lblMaterialDisponible.Name = "lblMaterialDisponible";
            this.lblMaterialDisponible.Size = new System.Drawing.Size(85, 17);
            this.lblMaterialDisponible.TabIndex = 3;
            this.lblMaterialDisponible.Text = "Disponibles";
            // 
            // pbDisponibles
            // 
            this.pbDisponibles.Image = global::Vista.Properties.Resources.material_si_disponible;
            this.pbDisponibles.Location = new System.Drawing.Point(20, 7);
            this.pbDisponibles.Name = "pbDisponibles";
            this.pbDisponibles.Size = new System.Drawing.Size(80, 64);
            this.pbDisponibles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDisponibles.TabIndex = 2;
            this.pbDisponibles.TabStop = false;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCantidad.Location = new System.Drawing.Point(21, 240);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(180, 19);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCantidad.Location = new System.Drawing.Point(21, 210);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(67, 19);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCategoria.Location = new System.Drawing.Point(21, 148);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(71, 19);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaterial.Location = new System.Drawing.Point(20, 95);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(62, 19);
            this.lblMaterial.TabIndex = 1;
            this.lblMaterial.Text = "Material:";
            // 
            // pnlIndicador2
            // 
            this.pnlIndicador2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(186)))), ((int)(((byte)(120)))));
            this.pnlIndicador2.Controls.Add(this.lblAgotandose);
            this.pnlIndicador2.Controls.Add(this.lblPocasUnidades);
            this.pnlIndicador2.Controls.Add(this.pbPocasUnidades);
            this.pnlIndicador2.Location = new System.Drawing.Point(672, 533);
            this.pnlIndicador2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador2.Name = "pnlIndicador2";
            this.pnlIndicador2.Size = new System.Drawing.Size(201, 77);
            this.pnlIndicador2.TabIndex = 4;
            // 
            // lblAgotandose
            // 
            this.lblAgotandose.AutoSize = true;
            this.lblAgotandose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgotandose.Location = new System.Drawing.Point(132, 39);
            this.lblAgotandose.Name = "lblAgotandose";
            this.lblAgotandose.Size = new System.Drawing.Size(18, 25);
            this.lblAgotandose.TabIndex = 7;
            this.lblAgotandose.Text = "l";
            // 
            // pbPocasUnidades
            // 
            this.pbPocasUnidades.Image = global::Vista.Properties.Resources.material_alerta;
            this.pbPocasUnidades.Location = new System.Drawing.Point(12, 8);
            this.pbPocasUnidades.Name = "pbPocasUnidades";
            this.pbPocasUnidades.Size = new System.Drawing.Size(80, 64);
            this.pbPocasUnidades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPocasUnidades.TabIndex = 1;
            this.pbPocasUnidades.TabStop = false;
            // 
            // txtMaterial
            // 
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterial.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaterial.Location = new System.Drawing.Point(21, 123);
            this.txtMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterial.MaxLength = 100;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(182, 19);
            this.txtMaterial.TabIndex = 2;
            this.txtMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterial_KeyPress);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(153)))), ((int)(((byte)(105)))));
            this.pnlPrincipal.Controls.Add(this.lblPagina);
            this.pnlPrincipal.Controls.Add(this.btnAnterior);
            this.pnlPrincipal.Controls.Add(this.btnSiguiente);
            this.pnlPrincipal.Controls.Add(this.dgvMateriales);
            this.pnlPrincipal.Location = new System.Drawing.Point(260, 104);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(820, 417);
            this.pnlPrincipal.TabIndex = 3;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.White;
            this.lblPagina.Location = new System.Drawing.Point(694, 389);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 10;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.flecha_atras;
            this.btnAnterior.Location = new System.Drawing.Point(657, 385);
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
            this.btnSiguiente.Image = global::Vista.Properties.Resources.flecha_adelante;
            this.btnSiguiente.Location = new System.Drawing.Point(781, 384);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // dgvMateriales
            // 
            this.dgvMateriales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMateriales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMateriales.BackgroundColor = System.Drawing.Color.White;
            this.dgvMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMateriales.GridColor = System.Drawing.Color.Black;
            this.dgvMateriales.Location = new System.Drawing.Point(12, 7);
            this.dgvMateriales.Name = "dgvMateriales";
            this.dgvMateriales.ReadOnly = true;
            this.dgvMateriales.Size = new System.Drawing.Size(799, 376);
            this.dgvMateriales.TabIndex = 1;
            this.dgvMateriales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellDoubleClick);
            // 
            // lblDatosMaterial
            // 
            this.lblDatosMaterial.AutoSize = true;
            this.lblDatosMaterial.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblDatosMaterial.Location = new System.Drawing.Point(9, 24);
            this.lblDatosMaterial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatosMaterial.Name = "lblDatosMaterial";
            this.lblDatosMaterial.Size = new System.Drawing.Size(200, 26);
            this.lblDatosMaterial.TabIndex = 0;
            this.lblDatosMaterial.Text = "Datos del material";
            // 
            // pnlIndicador3
            // 
            this.pnlIndicador3.BackColor = System.Drawing.Color.White;
            this.pnlIndicador3.Controls.Add(this.lblTotalRegistrados);
            this.pnlIndicador3.Controls.Add(this.lblTotalInventario);
            this.pnlIndicador3.Controls.Add(this.pbTotalRegistros);
            this.pnlIndicador3.Location = new System.Drawing.Point(878, 532);
            this.pnlIndicador3.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIndicador3.Name = "pnlIndicador3";
            this.pnlIndicador3.Size = new System.Drawing.Size(201, 77);
            this.pnlIndicador3.TabIndex = 4;
            // 
            // lblTotalRegistrados
            // 
            this.lblTotalRegistrados.AutoSize = true;
            this.lblTotalRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistrados.Location = new System.Drawing.Point(120, 44);
            this.lblTotalRegistrados.Name = "lblTotalRegistrados";
            this.lblTotalRegistrados.Size = new System.Drawing.Size(18, 25);
            this.lblTotalRegistrados.TabIndex = 8;
            this.lblTotalRegistrados.Text = "l";
            // 
            // lblTotalInventario
            // 
            this.lblTotalInventario.AutoSize = true;
            this.lblTotalInventario.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalInventario.Location = new System.Drawing.Point(78, 13);
            this.lblTotalInventario.Name = "lblTotalInventario";
            this.lblTotalInventario.Size = new System.Drawing.Size(125, 17);
            this.lblTotalInventario.TabIndex = 6;
            this.lblTotalInventario.Text = "Total de Inventario";
            // 
            // pbTotalRegistros
            // 
            this.pbTotalRegistros.Image = global::Vista.Properties.Resources.Material_Registrado;
            this.pbTotalRegistros.Location = new System.Drawing.Point(10, 11);
            this.pbTotalRegistros.Name = "pbTotalRegistros";
            this.pbTotalRegistros.Size = new System.Drawing.Size(71, 54);
            this.pbTotalRegistros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTotalRegistros.TabIndex = 0;
            this.pbTotalRegistros.TabStop = false;
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
            this.pnlBarraSuperior.Size = new System.Drawing.Size(1117, 23);
            this.pnlBarraSuperior.TabIndex = 8;
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
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.lblSubTexto.Location = new System.Drawing.Point(70, 69);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(344, 25);
            this.lblSubTexto.TabIndex = 1;
            this.lblSubTexto.Text = "Administración general de materiales.";
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold);
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(63, 25);
            this.lblMensajeInformativoPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(373, 43);
            this.lblMensajeInformativoPrincipal.TabIndex = 0;
            this.lblMensajeInformativoPrincipal.Text = "Gestión de Inventario";
            // 
            // pnlPedidaDeDatos
            // 
            this.pnlPedidaDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPedidaDeDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlPedidaDeDatos.Controls.Add(this.btnNuevo);
            this.pnlPedidaDeDatos.Controls.Add(this.btnGuardarCambios);
            this.pnlPedidaDeDatos.Controls.Add(this.cbCategorias);
            this.pnlPedidaDeDatos.Controls.Add(this.cbUnidadMedida);
            this.pnlPedidaDeDatos.Controls.Add(this.btnGuardar);
            this.pnlPedidaDeDatos.Controls.Add(this.btnEditar);
            this.pnlPedidaDeDatos.Controls.Add(this.lblMedida);
            this.pnlPedidaDeDatos.Controls.Add(this.txtCantidad);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCantidad);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCategoria);
            this.pnlPedidaDeDatos.Controls.Add(this.txtMaterial);
            this.pnlPedidaDeDatos.Controls.Add(this.lblMaterial);
            this.pnlPedidaDeDatos.Controls.Add(this.lblDatosMaterial);
            this.pnlPedidaDeDatos.Location = new System.Drawing.Point(15, 114);
            this.pnlPedidaDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPedidaDeDatos.Name = "pnlPedidaDeDatos";
            this.pnlPedidaDeDatos.Size = new System.Drawing.Size(219, 398);
            this.pnlPedidaDeDatos.TabIndex = 2;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(23, 62);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(174, 28);
            this.btnNuevo.TabIndex = 25;
            this.btnNuevo.Text = "Nuevo Material";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarCambios.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnGuardarCambios.Location = new System.Drawing.Point(118, 342);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(91, 36);
            this.btnGuardarCambios.TabIndex = 19;
            this.btnGuardarCambios.Text = "Guardar";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // cbCategorias
            // 
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(22, 182);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(181, 21);
            this.cbCategorias.TabIndex = 2;
            // 
            // pnlContenedorPrincipalInventario
            // 
            this.pnlContenedorPrincipalInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlContenedorPrincipalInventario.Controls.Add(this.lblSubTexto);
            this.pnlContenedorPrincipalInventario.Controls.Add(this.pnlHeader);
            this.pnlContenedorPrincipalInventario.Location = new System.Drawing.Point(-1, -1);
            this.pnlContenedorPrincipalInventario.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedorPrincipalInventario.Name = "pnlContenedorPrincipalInventario";
            this.pnlContenedorPrincipalInventario.Size = new System.Drawing.Size(1117, 663);
            this.pnlContenedorPrincipalInventario.TabIndex = 4;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.pnlPedidaDeDatos);
            this.pnlHeader.Controls.Add(this.pnlBarraSuperior);
            this.pnlHeader.Controls.Add(this.pnlIndicador3);
            this.pnlHeader.Controls.Add(this.pnlIndicador2);
            this.pnlHeader.Controls.Add(this.pnlIndicador);
            this.pnlHeader.Controls.Add(this.pnlIndicador1);
            this.pnlHeader.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlHeader.Controls.Add(this.pnlPrincipal);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1117, 663);
            this.pnlHeader.TabIndex = 0;
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
            this.txtBuscar.Location = new System.Drawing.Point(595, 50);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(475, 29);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.productos_totales;
            this.pictureBox1.Location = new System.Drawing.Point(4, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmInventarioSecretario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlContenedorPrincipalInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInventarioSecretario";
            this.Text = "frmInventarioSecretario";
            this.Load += new System.EventHandler(this.frmInventarioSecretario_Load);
            this.pnlIndicador.ResumeLayout(false);
            this.pnlIndicador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgotados)).EndInit();
            this.pnlIndicador1.ResumeLayout(false);
            this.pnlIndicador1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisponibles)).EndInit();
            this.pnlIndicador2.ResumeLayout(false);
            this.pnlIndicador2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPocasUnidades)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriales)).EndInit();
            this.pnlIndicador3.ResumeLayout(false);
            this.pnlIndicador3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotalRegistros)).EndInit();
            this.pnlBarraSuperior.ResumeLayout(false);
            this.pnlBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            this.pnlPedidaDeDatos.ResumeLayout(false);
            this.pnlPedidaDeDatos.PerformLayout();
            this.pnlContenedorPrincipalInventario.ResumeLayout(false);
            this.pnlContenedorPrincipalInventario.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTotalRegistros;
        private System.Windows.Forms.Label lblPocasUnidades;
        private System.Windows.Forms.PictureBox pbPocasUnidades;
        private System.Windows.Forms.ComboBox cbUnidadMedida;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Panel pnlIndicador;
        private System.Windows.Forms.Label lblAgotados;
        private System.Windows.Forms.PictureBox pbAgotados;
        private System.Windows.Forms.Panel pnlIndicador1;
        private System.Windows.Forms.Label lblMaterialDisponible;
        private System.Windows.Forms.PictureBox pbDisponibles;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Panel pnlIndicador2;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label lblDatosMaterial;
        private System.Windows.Forms.Panel pnlIndicador3;
        private System.Windows.Forms.Label lblTotalInventario;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Panel pnlBarraSuperior;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.Panel pnlPedidaDeDatos;
        private System.Windows.Forms.Panel pnlContenedorPrincipalInventario;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.DataGridView dgvMateriales;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label lblMaterialesAgotados;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label lblAgotandose;
        private System.Windows.Forms.Label lblTotalRegistrados;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}