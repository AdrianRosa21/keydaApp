namespace Vista.Login
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPrincipalLogin = new System.Windows.Forms.Panel();
            this.pnlContenedorLogin = new System.Windows.Forms.Panel();
            this.btnIngresar = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnRecuperarContrasena = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblIndoInicio = new System.Windows.Forms.Label();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.pbImagenPrincipal = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlPrincipalLogin.SuspendLayout();
            this.pnlContenedorLogin.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlPrincipalLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 588);
            this.panel1.TabIndex = 0;
            // 
            // pnlPrincipalLogin
            // 
            this.pnlPrincipalLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(110)))), ((int)(((byte)(69)))));
            this.pnlPrincipalLogin.Controls.Add(this.guna2Panel1);
            this.pnlPrincipalLogin.Controls.Add(this.pnlContenedorLogin);
            this.pnlPrincipalLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipalLogin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipalLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipalLogin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPrincipalLogin.Name = "pnlPrincipalLogin";
            this.pnlPrincipalLogin.Size = new System.Drawing.Size(1084, 586);
            this.pnlPrincipalLogin.TabIndex = 2;
            // 
            // pnlContenedorLogin
            // 
            this.pnlContenedorLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlContenedorLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.pnlContenedorLogin.Controls.Add(this.btnIngresar);
            this.pnlContenedorLogin.Controls.Add(this.btnRecuperarContrasena);
            this.pnlContenedorLogin.Controls.Add(this.txtContraseña);
            this.pnlContenedorLogin.Controls.Add(this.txtUsuario);
            this.pnlContenedorLogin.Controls.Add(this.lblContraseña);
            this.pnlContenedorLogin.Controls.Add(this.lblUsuario);
            this.pnlContenedorLogin.Controls.Add(this.lblIndoInicio);
            this.pnlContenedorLogin.Controls.Add(this.lblIniciarSesion);
            this.pnlContenedorLogin.Controls.Add(this.pbImagenPrincipal);
            this.pnlContenedorLogin.Controls.Add(this.picLogo);
            this.pnlContenedorLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedorLogin.Name = "pnlContenedorLogin";
            this.pnlContenedorLogin.Size = new System.Drawing.Size(1084, 586);
            this.pnlContenedorLogin.TabIndex = 24;
            // 
            // btnIngresar
            // 
            this.btnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIngresar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(558, 490);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(402, 32);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnRecuperarContrasena
            // 
            this.btnRecuperarContrasena.Location = new System.Drawing.Point(530, 439);
            this.btnRecuperarContrasena.Name = "btnRecuperarContrasena";
            this.btnRecuperarContrasena.Size = new System.Drawing.Size(143, 27);
            this.btnRecuperarContrasena.TabIndex = 4;
            this.btnRecuperarContrasena.Text = "Recuperar contraseña";
            this.btnRecuperarContrasena.UseVisualStyleBackColor = true;
            this.btnRecuperarContrasena.Click += new System.EventHandler(this.btnRecuperarContrasena_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContraseña.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(530, 393);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(454, 32);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(530, 318);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(454, 32);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(529, 364);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(103, 21);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(531, 290);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(77, 21);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario :";
            // 
            // lblIndoInicio
            // 
            this.lblIndoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndoInicio.AutoSize = true;
            this.lblIndoInicio.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndoInicio.Location = new System.Drawing.Point(568, 249);
            this.lblIndoInicio.Name = "lblIndoInicio";
            this.lblIndoInicio.Size = new System.Drawing.Size(364, 21);
            this.lblIndoInicio.TabIndex = 2;
            this.lblIndoInicio.Text = "Ingresa tus credenciales para acceder al sistema";
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIniciarSesion.AutoSize = true;
            this.lblIniciarSesion.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciarSesion.Location = new System.Drawing.Point(652, 204);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(219, 36);
            this.lblIniciarSesion.TabIndex = 1;
            this.lblIniciarSesion.Text = "Iniciar Sesión :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(62)))), ((int)(((byte)(36)))));
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.guna2TileButton1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1084, 31);
            this.guna2Panel1.TabIndex = 13;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(67, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(107, 19);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Muebles Keyda ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.LogoPNG;
            this.pictureBox1.Location = new System.Drawing.Point(4, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.Animated = true;
            this.guna2TileButton1.BorderColor = System.Drawing.Color.White;
            this.guna2TileButton1.BorderRadius = 2;
            this.guna2TileButton1.BorderThickness = 2;
            this.guna2TileButton1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.White;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TileButton1.ForeColor = System.Drawing.Color.White;
            this.guna2TileButton1.Image = global::Vista.Properties.Resources.Cerrar16px;
            this.guna2TileButton1.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2TileButton1.Location = new System.Drawing.Point(1021, 3);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Padding = new System.Windows.Forms.Padding(10);
            this.guna2TileButton1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.Size = new System.Drawing.Size(52, 24);
            this.guna2TileButton1.TabIndex = 0;
            this.guna2TileButton1.Click += new System.EventHandler(this.guna2TileButton1_Click);
            // 
            // pbImagenPrincipal
            // 
            this.pbImagenPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbImagenPrincipal.Image = global::Vista.Properties.Resources.LoginFondo;
            this.pbImagenPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pbImagenPrincipal.Name = "pbImagenPrincipal";
            this.pbImagenPrincipal.Size = new System.Drawing.Size(434, 586);
            this.pbImagenPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenPrincipal.TabIndex = 0;
            this.pbImagenPrincipal.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(630, 37);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(241, 176);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(110)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1086, 588);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.pnlPrincipalLogin.ResumeLayout(false);
            this.pnlContenedorLogin.ResumeLayout(false);
            this.pnlContenedorLogin.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPrincipalLogin;
        private System.Windows.Forms.Panel pnlContenedorLogin;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblIndoInicio;
        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.PictureBox pbImagenPrincipal;
        private System.Windows.Forms.Button btnRecuperarContrasena;
        private System.Windows.Forms.PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2TileButton btnIngresar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}