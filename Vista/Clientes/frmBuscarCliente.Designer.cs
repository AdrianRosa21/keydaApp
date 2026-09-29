namespace Vista.Clientes
{
    partial class frmBuscarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCliente));
            this.pnlBuscarClienteSuperior = new System.Windows.Forms.Panel();
            this.btnSlir = new System.Windows.Forms.Button();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.pbxBuscar = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarCliente = new System.Windows.Forms.Button();
            this.pnlBuscarClienteSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBuscarClienteSuperior
            // 
            this.pnlBuscarClienteSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(62)))), ((int)(((byte)(36)))));
            this.pnlBuscarClienteSuperior.Controls.Add(this.btnSlir);
            this.pnlBuscarClienteSuperior.Controls.Add(this.lblBuscarCliente);
            this.pnlBuscarClienteSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscarClienteSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlBuscarClienteSuperior.Name = "pnlBuscarClienteSuperior";
            this.pnlBuscarClienteSuperior.Size = new System.Drawing.Size(537, 35);
            this.pnlBuscarClienteSuperior.TabIndex = 0;
            // 
            // btnSlir
            // 
            this.btnSlir.Image = global::Vista.Properties.Resources.Cerrar16px;
            this.btnSlir.Location = new System.Drawing.Point(482, 4);
            this.btnSlir.Name = "btnSlir";
            this.btnSlir.Size = new System.Drawing.Size(47, 23);
            this.btnSlir.TabIndex = 3;
            this.btnSlir.UseVisualStyleBackColor = true;
            this.btnSlir.Click += new System.EventHandler(this.btnSlir_Click);
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.AutoSize = true;
            this.lblBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscarCliente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.lblBuscarCliente.Location = new System.Drawing.Point(15, 8);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(115, 15);
            this.lblBuscarCliente.TabIndex = 0;
            this.lblBuscarCliente.Text = "Seleccionar Cliente";
            // 
            // dgvClientes
            // 
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Location = new System.Drawing.Point(18, 89);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(507, 243);
            this.dgvClientes.TabIndex = 1;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.Location = new System.Drawing.Point(17, 51);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(401, 22);
            this.txtBuscarCliente.TabIndex = 3;
            this.txtBuscarCliente.Text = "Buscar Cliente...";
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            this.txtBuscarCliente.Enter += new System.EventHandler(this.txtBuscarCliente_Enter);
            this.txtBuscarCliente.Leave += new System.EventHandler(this.txtBuscarCliente_Leave);
            // 
            // pbxBuscar
            // 
            this.pbxBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbxBuscar.Image = global::Vista.Properties.Resources.zoom_5611171;
            this.pbxBuscar.Location = new System.Drawing.Point(394, 51);
            this.pbxBuscar.Name = "pbxBuscar";
            this.pbxBuscar.Size = new System.Drawing.Size(24, 22);
            this.pbxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBuscar.TabIndex = 27;
            this.pbxBuscar.TabStop = false;
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSeleccionarCliente.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(97, 338);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(336, 37);
            this.btnSeleccionarCliente.TabIndex = 28;
            this.btnSeleccionarCliente.Text = "Selecionar Cliente";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(537, 385);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.pbxBuscar);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.pnlBuscarClienteSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cliente";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.pnlBuscarClienteSuperior.ResumeLayout(false);
            this.pnlBuscarClienteSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBuscarClienteSuperior;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.PictureBox pbxBuscar;
        private System.Windows.Forms.Button btnSeleccionarCliente;
        private System.Windows.Forms.Button btnSlir;
    }
}
