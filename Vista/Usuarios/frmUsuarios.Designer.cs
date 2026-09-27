namespace Vista.Usuarios
{
    partial class frmUsuarios
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
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.pnlPedidaDeDatos = new System.Windows.Forms.Panel();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreoelectronico = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.pnlBarraInformativa = new System.Windows.Forms.Panel();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.pnlPedidosRecientes = new System.Windows.Forms.Panel();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.dgvUsuariosRegistrados = new System.Windows.Forms.DataGridView();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.lblSubTexto = new System.Windows.Forms.Label();
            this.lblMensajeInformativoPrincipal = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnGuardarUsuario = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDesactivarUsuario = new Guna.UI2.WinForms.Guna2TileButton();
            this.pnlContenedor.SuspendLayout();
            this.pnlPedidaDeDatos.SuspendLayout();
            this.pnlBarraInformativa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            this.pnlPedidosRecientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosRegistrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlContenedor.Controls.Add(this.pictureBox1);
            this.pnlContenedor.Controls.Add(this.btnNuevoUsuario);
            this.pnlContenedor.Controls.Add(this.pnlPedidaDeDatos);
            this.pnlContenedor.Controls.Add(this.pnlBarraInformativa);
            this.pnlContenedor.Controls.Add(this.pnlPedidosRecientes);
            this.pnlContenedor.Controls.Add(this.lblSubTexto);
            this.pnlContenedor.Controls.Add(this.lblMensajeInformativoPrincipal);
            this.pnlContenedor.Controls.Add(this.picLogo);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1102, 627);
            this.pnlContenedor.TabIndex = 6;
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNuevoUsuario.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoUsuario.Image = global::Vista.Properties.Resources.agregar_usuario;
            this.btnNuevoUsuario.Location = new System.Drawing.Point(26, 133);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(241, 56);
            this.btnNuevoUsuario.TabIndex = 12;
            this.btnNuevoUsuario.Text = "Nuevo Usuario";
            this.btnNuevoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoUsuario.UseVisualStyleBackColor = false;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnNuevoUsuario_Click);
            // 
            // pnlPedidaDeDatos
            // 
            this.pnlPedidaDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPedidaDeDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlPedidaDeDatos.Controls.Add(this.btnGuardarUsuario);
            this.pnlPedidaDeDatos.Controls.Add(this.btnDesactivarUsuario);
            this.pnlPedidaDeDatos.Controls.Add(this.guna2HtmlLabel1);
            this.pnlPedidaDeDatos.Controls.Add(this.cmbRol);
            this.pnlPedidaDeDatos.Controls.Add(this.txtContrasena);
            this.pnlPedidaDeDatos.Controls.Add(this.lblClave);
            this.pnlPedidaDeDatos.Controls.Add(this.lblRol);
            this.pnlPedidaDeDatos.Controls.Add(this.txtCorreo);
            this.pnlPedidaDeDatos.Controls.Add(this.lblCorreoelectronico);
            this.pnlPedidaDeDatos.Controls.Add(this.txtUsuario);
            this.pnlPedidaDeDatos.Controls.Add(this.lblNombreUsuario);
            this.pnlPedidaDeDatos.Location = new System.Drawing.Point(25, 206);
            this.pnlPedidaDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPedidaDeDatos.Name = "pnlPedidaDeDatos";
            this.pnlPedidaDeDatos.Size = new System.Drawing.Size(241, 342);
            this.pnlPedidaDeDatos.TabIndex = 11;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Secretario",
            "Administrador"});
            this.cmbRol.Location = new System.Drawing.Point(20, 251);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(191, 21);
            this.cmbRol.TabIndex = 2;
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasena.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtContrasena.Location = new System.Drawing.Point(20, 202);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(191, 19);
            this.txtContrasena.TabIndex = 29;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(17, 184);
            this.lblClave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(73, 16);
            this.lblClave.TabIndex = 10;
            this.lblClave.Text = "Contraseña:";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(17, 232);
            this.lblRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 16);
            this.lblRol.TabIndex = 8;
            this.lblRol.Text = "Rol";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCorreo.Location = new System.Drawing.Point(20, 150);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(191, 19);
            this.txtCorreo.TabIndex = 4;
            // 
            // lblCorreoelectronico
            // 
            this.lblCorreoelectronico.AutoSize = true;
            this.lblCorreoelectronico.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoelectronico.Location = new System.Drawing.Point(17, 132);
            this.lblCorreoelectronico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorreoelectronico.Name = "lblCorreoelectronico";
            this.lblCorreoelectronico.Size = new System.Drawing.Size(115, 16);
            this.lblCorreoelectronico.TabIndex = 3;
            this.lblCorreoelectronico.Text = "Correo eléctronico:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(20, 99);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(191, 19);
            this.txtUsuario.TabIndex = 2;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(17, 81);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(122, 16);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de usuario :";
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
            this.pnlBarraInformativa.TabIndex = 9;
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.Location = new System.Drawing.Point(1012, 4);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(38, 14);
            this.lblAdministrador.TabIndex = 29;
            this.lblAdministrador.Text = "Admin";
            // 
            // pbPerfil
            // 
            this.pbPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPerfil.Image = global::Vista.Properties.Resources.Imagen_perfil_2;
            this.pbPerfil.Location = new System.Drawing.Point(1053, -3);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(26, 26);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerfil.TabIndex = 10;
            this.pbPerfil.TabStop = false;
            // 
            // pnlPedidosRecientes
            // 
            this.pnlPedidosRecientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPedidosRecientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(153)))), ((int)(((byte)(105)))));
            this.pnlPedidosRecientes.Controls.Add(this.lblPagina);
            this.pnlPedidosRecientes.Controls.Add(this.btnAnterior);
            this.pnlPedidosRecientes.Controls.Add(this.btnSiguiente);
            this.pnlPedidosRecientes.Controls.Add(this.lblUsuarios);
            this.pnlPedidosRecientes.Controls.Add(this.dgvUsuariosRegistrados);
            this.pnlPedidosRecientes.Controls.Add(this.chkEstado);
            this.pnlPedidosRecientes.Location = new System.Drawing.Point(293, 144);
            this.pnlPedidosRecientes.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPedidosRecientes.Name = "pnlPedidosRecientes";
            this.pnlPedidosRecientes.Size = new System.Drawing.Size(739, 472);
            this.pnlPedidosRecientes.TabIndex = 8;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.White;
            this.lblPagina.Location = new System.Drawing.Point(600, 447);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(39, 13);
            this.lblPagina.TabIndex = 33;
            this.lblPagina.Text = "label1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::Vista.Properties.Resources.flecha_atras;
            this.btnAnterior.Location = new System.Drawing.Point(571, 442);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 23);
            this.btnAnterior.TabIndex = 32;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::Vista.Properties.Resources.flecha_adelante;
            this.btnSiguiente.Location = new System.Drawing.Point(695, 442);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 23);
            this.btnSiguiente.TabIndex = 31;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold);
            this.lblUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblUsuarios.Location = new System.Drawing.Point(25, 5);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(276, 35);
            this.lblUsuarios.TabIndex = 1;
            this.lblUsuarios.Text = "Usuarios Regstrados";
            // 
            // dgvUsuariosRegistrados
            // 
            this.dgvUsuariosRegistrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosRegistrados.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuariosRegistrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuariosRegistrados.GridColor = System.Drawing.Color.Black;
            this.dgvUsuariosRegistrados.Location = new System.Drawing.Point(13, 43);
            this.dgvUsuariosRegistrados.Name = "dgvUsuariosRegistrados";
            this.dgvUsuariosRegistrados.Size = new System.Drawing.Size(712, 393);
            this.dgvUsuariosRegistrados.TabIndex = 0;
            this.dgvUsuariosRegistrados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosRegistrados_CellDoubleClick);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(83, 230);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(95, 17);
            this.chkEstado.TabIndex = 30;
            this.chkEstado.Text = "Usuario Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // lblSubTexto
            // 
            this.lblSubTexto.AutoSize = true;
            this.lblSubTexto.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTexto.Location = new System.Drawing.Point(76, 77);
            this.lblSubTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTexto.Name = "lblSubTexto";
            this.lblSubTexto.Size = new System.Drawing.Size(277, 21);
            this.lblSubTexto.TabIndex = 3;
            this.lblSubTexto.Text = "Administra los usuarios del sistema.";
            // 
            // lblMensajeInformativoPrincipal
            // 
            this.lblMensajeInformativoPrincipal.AutoSize = true;
            this.lblMensajeInformativoPrincipal.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.lblMensajeInformativoPrincipal.Location = new System.Drawing.Point(66, 32);
            this.lblMensajeInformativoPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeInformativoPrincipal.Name = "lblMensajeInformativoPrincipal";
            this.lblMensajeInformativoPrincipal.Size = new System.Drawing.Size(352, 45);
            this.lblMensajeInformativoPrincipal.TabIndex = 2;
            this.lblMensajeInformativoPrincipal.Text = "Gestión de usuarios";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Location = new System.Drawing.Point(914, 25);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(205, 119);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 59);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.AutoSizeHeightOnly = true;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(49, 14);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(153, 47);
            this.guna2HtmlLabel1.TabIndex = 14;
            this.guna2HtmlLabel1.Text = "Registra un nuevo usuario";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardarUsuario.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardarUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardarUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnGuardarUsuario.Location = new System.Drawing.Point(17, 293);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(99, 27);
            this.btnGuardarUsuario.TabIndex = 14;
            this.btnGuardarUsuario.Text = "Guardar";
            // 
            // btnDesactivarUsuario
            // 
            this.btnDesactivarUsuario.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDesactivarUsuario.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDesactivarUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDesactivarUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDesactivarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDesactivarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnDesactivarUsuario.Location = new System.Drawing.Point(129, 294);
            this.btnDesactivarUsuario.Name = "btnDesactivarUsuario";
            this.btnDesactivarUsuario.Size = new System.Drawing.Size(99, 27);
            this.btnDesactivarUsuario.TabIndex = 15;
            this.btnDesactivarUsuario.Text = "Desactivar";
            // 
            // frmUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1102, 627);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.pnlPedidaDeDatos.ResumeLayout(false);
            this.pnlPedidaDeDatos.PerformLayout();
            this.pnlBarraInformativa.ResumeLayout(false);
            this.pnlBarraInformativa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            this.pnlPedidosRecientes.ResumeLayout(false);
            this.pnlPedidosRecientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosRegistrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlBarraInformativa;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Panel pnlPedidosRecientes;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuariosRegistrados;
        private System.Windows.Forms.Label lblSubTexto;
        private System.Windows.Forms.Label lblMensajeInformativoPrincipal;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlPedidaDeDatos;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreoelectronico;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2TileButton btnDesactivarUsuario;
        private Guna.UI2.WinForms.Guna2TileButton btnGuardarUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}