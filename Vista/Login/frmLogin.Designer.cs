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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPrincipalLogin = new System.Windows.Forms.Panel();
            this.pnlContenedorLogin = new System.Windows.Forms.Panel();
            this.btnRecuperarContrasena = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblIndoInicio = new System.Windows.Forms.Label();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.pbImagenPrincipal = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrarClientes = new System.Windows.Forms.Button();
            this.btnIngresar = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel1.SuspendLayout();
            this.pnlPrincipalLogin.SuspendLayout();
            this.pnlContenedorLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlPrincipalLogin);
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 550);
            this.panel1.TabIndex = 0;
            // 
            // pnlPrincipalLogin
            // 
            this.pnlPrincipalLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(110)))), ((int)(((byte)(69)))));
            this.pnlPrincipalLogin.Controls.Add(this.pnlContenedorLogin);
            this.pnlPrincipalLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipalLogin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipalLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipalLogin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPrincipalLogin.Name = "pnlPrincipalLogin";
            this.pnlPrincipalLogin.Size = new System.Drawing.Size(1065, 550);
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
            this.pnlContenedorLogin.Size = new System.Drawing.Size(1065, 550);
            this.pnlContenedorLogin.TabIndex = 24;
            // 
            // btnRecuperarContrasena
            // 
            this.btnRecuperarContrasena.Location = new System.Drawing.Point(523, 439);
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
            this.txtContraseña.Location = new System.Drawing.Point(523, 393);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(435, 32);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(523, 318);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(435, 32);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(522, 364);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(103, 21);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(523, 289);
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
            this.lblIndoInicio.Location = new System.Drawing.Point(561, 231);
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
            this.lblIniciarSesion.Location = new System.Drawing.Point(645, 186);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(219, 36);
            this.lblIniciarSesion.TabIndex = 1;
            this.lblIniciarSesion.Text = "Iniciar Sesión :";
            // 
            // pbImagenPrincipal
            // 
            this.pbImagenPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbImagenPrincipal.Image = global::Vista.Properties.Resources.LoginFondo;
            this.pbImagenPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pbImagenPrincipal.Name = "pbImagenPrincipal";
            this.pbImagenPrincipal.Size = new System.Drawing.Size(434, 550);
            this.pbImagenPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenPrincipal.TabIndex = 0;
            this.pbImagenPrincipal.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(615, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(281, 201);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(62)))), ((int)(((byte)(36)))));
            this.panel2.Controls.Add(this.btnCerrarClientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 30);
            this.panel2.TabIndex = 10;
            // 
            // btnCerrarClientes
            // 
            this.btnCerrarClientes.Image = global::Vista.Properties.Resources.Cerrar16px;
            this.btnCerrarClientes.Location = new System.Drawing.Point(1044, 3);
            this.btnCerrarClientes.Name = "btnCerrarClientes";
            this.btnCerrarClientes.Size = new System.Drawing.Size(32, 23);
            this.btnCerrarClientes.TabIndex = 10;
            this.btnCerrarClientes.UseVisualStyleBackColor = true;
            this.btnCerrarClientes.Click += new System.EventHandler(this.btnCerrarClientes_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIngresar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(535, 490);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(402, 32);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(110)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1086, 588);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.pnlPrincipalLogin.ResumeLayout(false);
            this.pnlContenedorLogin.ResumeLayout(false);
            this.pnlContenedorLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrarClientes;
        private System.Windows.Forms.Button btnRecuperarContrasena;
        private System.Windows.Forms.PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2TileButton btnIngresar;
    }
}