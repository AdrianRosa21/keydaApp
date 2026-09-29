namespace Vista.Producción
{
    partial class frmEditarProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProduccion));
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.nudProgreso = new System.Windows.Forms.NumericUpDown();
            this.txtMuebleRealizar = new System.Windows.Forms.TextBox();
            this.txtCodigoProduccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMuebleRealizar = new System.Windows.Forms.Label();
            this.lblCodigoProduccion = new System.Windows.Forms.Label();
            this.pnlBuscarClienteSuperior = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblDetalleProduccion = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTextoEstado = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudProgreso)).BeginInit();
            this.pnlBuscarClienteSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(466, 73);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(119, 20);
            this.dtpFechaEntrega.TabIndex = 46;
            // 
            // nudProgreso
            // 
            this.nudProgreso.Location = new System.Drawing.Point(467, 113);
            this.nudProgreso.Name = "nudProgreso";
            this.nudProgreso.Size = new System.Drawing.Size(119, 20);
            this.nudProgreso.TabIndex = 45;
            this.nudProgreso.ValueChanged += new System.EventHandler(this.nudProgreso_ValueChanged_1);
            // 
            // txtMuebleRealizar
            // 
            this.txtMuebleRealizar.Location = new System.Drawing.Point(129, 114);
            this.txtMuebleRealizar.Name = "txtMuebleRealizar";
            this.txtMuebleRealizar.Size = new System.Drawing.Size(157, 20);
            this.txtMuebleRealizar.TabIndex = 43;
            // 
            // txtCodigoProduccion
            // 
            this.txtCodigoProduccion.Location = new System.Drawing.Point(165, 73);
            this.txtCodigoProduccion.Name = "txtCodigoProduccion";
            this.txtCodigoProduccion.Size = new System.Drawing.Size(121, 20);
            this.txtCodigoProduccion.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label3.Location = new System.Drawing.Point(348, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Fecha de Entrega :";
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblProgreso.Location = new System.Drawing.Point(348, 114);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(65, 16);
            this.lblProgreso.TabIndex = 40;
            this.lblProgreso.Text = "Progreso :";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblCliente.Location = new System.Drawing.Point(20, 151);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 16);
            this.lblCliente.TabIndex = 37;
            this.lblCliente.Text = "Cliente :";
            // 
            // lblMuebleRealizar
            // 
            this.lblMuebleRealizar.AutoSize = true;
            this.lblMuebleRealizar.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblMuebleRealizar.Location = new System.Drawing.Point(20, 114);
            this.lblMuebleRealizar.Name = "lblMuebleRealizar";
            this.lblMuebleRealizar.Size = new System.Drawing.Size(103, 16);
            this.lblMuebleRealizar.TabIndex = 36;
            this.lblMuebleRealizar.Text = "Mueble a relizar :";
            // 
            // lblCodigoProduccion
            // 
            this.lblCodigoProduccion.AutoSize = true;
            this.lblCodigoProduccion.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblCodigoProduccion.Location = new System.Drawing.Point(19, 74);
            this.lblCodigoProduccion.Name = "lblCodigoProduccion";
            this.lblCodigoProduccion.Size = new System.Drawing.Size(140, 16);
            this.lblCodigoProduccion.TabIndex = 35;
            this.lblCodigoProduccion.Text = "Codigó de Producción :";
            // 
            // pnlBuscarClienteSuperior
            // 
            this.pnlBuscarClienteSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(62)))), ((int)(((byte)(36)))));
            this.pnlBuscarClienteSuperior.Controls.Add(this.btnSalir);
            this.pnlBuscarClienteSuperior.Controls.Add(this.lblDetalleProduccion);
            this.pnlBuscarClienteSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscarClienteSuperior.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscarClienteSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlBuscarClienteSuperior.Name = "pnlBuscarClienteSuperior";
            this.pnlBuscarClienteSuperior.Size = new System.Drawing.Size(608, 38);
            this.pnlBuscarClienteSuperior.TabIndex = 32;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Vista.Properties.Resources.Cerrar16px;
            this.btnSalir.Location = new System.Drawing.Point(562, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(32, 25);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblDetalleProduccion
            // 
            this.lblDetalleProduccion.AutoSize = true;
            this.lblDetalleProduccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalleProduccion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleProduccion.ForeColor = System.Drawing.Color.White;
            this.lblDetalleProduccion.Location = new System.Drawing.Point(15, 9);
            this.lblDetalleProduccion.Name = "lblDetalleProduccion";
            this.lblDetalleProduccion.Size = new System.Drawing.Size(140, 15);
            this.lblDetalleProduccion.TabIndex = 0;
            this.lblDetalleProduccion.Text = "EDITAR PRODUCCION";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(261, 194);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 27);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCambios.Location = new System.Drawing.Point(408, 194);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(177, 27);
            this.btnGuardarCambios.TabIndex = 34;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click_1);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblEstado.Location = new System.Drawing.Point(428, 155);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 16);
            this.lblEstado.TabIndex = 38;
            this.lblEstado.Text = "Estado :";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(129, 149);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(157, 20);
            this.txtCliente.TabIndex = 48;
            // 
            // lblTextoEstado
            // 
            this.lblTextoEstado.AutoSize = true;
            this.lblTextoEstado.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTextoEstado.Location = new System.Drawing.Point(348, 155);
            this.lblTextoEstado.Name = "lblTextoEstado";
            this.lblTextoEstado.Size = new System.Drawing.Size(52, 16);
            this.lblTextoEstado.TabIndex = 49;
            this.lblTextoEstado.Text = "Estado :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditarProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(608, 246);
            this.Controls.Add(this.lblTextoEstado);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.nudProgreso);
            this.Controls.Add(this.txtMuebleRealizar);
            this.Controls.Add(this.txtCodigoProduccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblMuebleRealizar);
            this.Controls.Add(this.lblCodigoProduccion);
            this.Controls.Add(this.pnlBuscarClienteSuperior);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.lblEstado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditarProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditarProduccion";
            ((System.ComponentModel.ISupportInitialize)(this.nudProgreso)).EndInit();
            this.pnlBuscarClienteSuperior.ResumeLayout(false);
            this.pnlBuscarClienteSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.NumericUpDown nudProgreso;
        private System.Windows.Forms.TextBox txtMuebleRealizar;
        private System.Windows.Forms.TextBox txtCodigoProduccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMuebleRealizar;
        private System.Windows.Forms.Label lblCodigoProduccion;
        private System.Windows.Forms.Panel pnlBuscarClienteSuperior;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblDetalleProduccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTextoEstado;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}