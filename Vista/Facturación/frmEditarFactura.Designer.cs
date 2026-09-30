namespace Vista.Facturación
{
    partial class frmEditarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarFactura));
            this.pnlDatosGeneralesFactura = new System.Windows.Forms.Panel();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblNFactura = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.dtFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblDatosGeneralesClienteFactura = new System.Windows.Forms.Label();
            this.lblFechaEmisionFactura = new System.Windows.Forms.Label();
            this.pnlResumenDePagoFactura = new System.Windows.Forms.Panel();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblPagoFactura = new System.Windows.Forms.Label();
            this.lblSubTotalFactura = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblIvaFactura = new System.Windows.Forms.Label();
            this.lblTotalFactura = new System.Windows.Forms.Label();
            this.pnlObservacion = new System.Windows.Forms.Panel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.btnGerarPdfModificado = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.pnlDatosGeneralesFactura.SuspendLayout();
            this.pnlResumenDePagoFactura.SuspendLayout();
            this.pnlObservacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatosGeneralesFactura
            // 
            this.pnlDatosGeneralesFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlDatosGeneralesFactura.Controls.Add(this.dtpFechaVencimiento);
            this.pnlDatosGeneralesFactura.Controls.Add(this.lblNFactura);
            this.pnlDatosGeneralesFactura.Controls.Add(this.txtNumeroFactura);
            this.pnlDatosGeneralesFactura.Controls.Add(this.dtFechaEmision);
            this.pnlDatosGeneralesFactura.Controls.Add(this.lblFechaVencimiento);
            this.pnlDatosGeneralesFactura.Controls.Add(this.lblDatosGeneralesClienteFactura);
            this.pnlDatosGeneralesFactura.Controls.Add(this.lblFechaEmisionFactura);
            this.pnlDatosGeneralesFactura.Location = new System.Drawing.Point(11, 12);
            this.pnlDatosGeneralesFactura.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatosGeneralesFactura.Name = "pnlDatosGeneralesFactura";
            this.pnlDatosGeneralesFactura.Size = new System.Drawing.Size(328, 142);
            this.pnlDatosGeneralesFactura.TabIndex = 38;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(159, 103);
            this.dtpFechaVencimiento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(160, 23);
            this.dtpFechaVencimiento.TabIndex = 28;
            // 
            // lblNFactura
            // 
            this.lblNFactura.AutoSize = true;
            this.lblNFactura.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFactura.Location = new System.Drawing.Point(10, 43);
            this.lblNFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNFactura.Name = "lblNFactura";
            this.lblNFactura.Size = new System.Drawing.Size(84, 19);
            this.lblNFactura.TabIndex = 25;
            this.lblNFactura.Text = "N° Factura :";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroFactura.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFactura.Location = new System.Drawing.Point(101, 45);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(216, 19);
            this.txtNumeroFactura.TabIndex = 24;
            // 
            // dtFechaEmision
            // 
            this.dtFechaEmision.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dtFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEmision.Location = new System.Drawing.Point(138, 71);
            this.dtFechaEmision.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaEmision.Name = "dtFechaEmision";
            this.dtFechaEmision.Size = new System.Drawing.Size(179, 23);
            this.dtFechaEmision.TabIndex = 21;
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVencimiento.Location = new System.Drawing.Point(10, 103);
            this.lblFechaVencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(145, 19);
            this.lblFechaVencimiento.TabIndex = 18;
            this.lblFechaVencimiento.Text = "Fecha de Vencimiento:";
            // 
            // lblDatosGeneralesClienteFactura
            // 
            this.lblDatosGeneralesClienteFactura.AutoSize = true;
            this.lblDatosGeneralesClienteFactura.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosGeneralesClienteFactura.Location = new System.Drawing.Point(56, 8);
            this.lblDatosGeneralesClienteFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatosGeneralesClienteFactura.Name = "lblDatosGeneralesClienteFactura";
            this.lblDatosGeneralesClienteFactura.Size = new System.Drawing.Size(197, 25);
            this.lblDatosGeneralesClienteFactura.TabIndex = 0;
            this.lblDatosGeneralesClienteFactura.Text = "Datos de la Factura";
            // 
            // lblFechaEmisionFactura
            // 
            this.lblFechaEmisionFactura.AutoSize = true;
            this.lblFechaEmisionFactura.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEmisionFactura.Location = new System.Drawing.Point(10, 73);
            this.lblFechaEmisionFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaEmisionFactura.Name = "lblFechaEmisionFactura";
            this.lblFechaEmisionFactura.Size = new System.Drawing.Size(123, 19);
            this.lblFechaEmisionFactura.TabIndex = 1;
            this.lblFechaEmisionFactura.Text = "Fecha de Emisión :";
            // 
            // pnlResumenDePagoFactura
            // 
            this.pnlResumenDePagoFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlResumenDePagoFactura.Controls.Add(this.lblDescuento);
            this.pnlResumenDePagoFactura.Controls.Add(this.txtDescuento);
            this.pnlResumenDePagoFactura.Controls.Add(this.txtTotal);
            this.pnlResumenDePagoFactura.Controls.Add(this.txtIVA);
            this.pnlResumenDePagoFactura.Controls.Add(this.lblPagoFactura);
            this.pnlResumenDePagoFactura.Controls.Add(this.lblSubTotalFactura);
            this.pnlResumenDePagoFactura.Controls.Add(this.txtSubTotal);
            this.pnlResumenDePagoFactura.Controls.Add(this.lblIvaFactura);
            this.pnlResumenDePagoFactura.Controls.Add(this.lblTotalFactura);
            this.pnlResumenDePagoFactura.Location = new System.Drawing.Point(11, 168);
            this.pnlResumenDePagoFactura.Margin = new System.Windows.Forms.Padding(2);
            this.pnlResumenDePagoFactura.Name = "pnlResumenDePagoFactura";
            this.pnlResumenDePagoFactura.Size = new System.Drawing.Size(332, 158);
            this.pnlResumenDePagoFactura.TabIndex = 40;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblDescuento.Location = new System.Drawing.Point(24, 94);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(80, 19);
            this.lblDescuento.TabIndex = 16;
            this.lblDescuento.Text = "Descuento :";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtDescuento.Location = new System.Drawing.Point(109, 94);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(155, 19);
            this.txtDescuento.TabIndex = 15;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTotal.Location = new System.Drawing.Point(109, 122);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(155, 19);
            this.txtTotal.TabIndex = 14;
            // 
            // txtIVA
            // 
            this.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIVA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtIVA.Location = new System.Drawing.Point(109, 67);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(155, 19);
            this.txtIVA.TabIndex = 13;
            // 
            // lblPagoFactura
            // 
            this.lblPagoFactura.AutoSize = true;
            this.lblPagoFactura.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoFactura.Location = new System.Drawing.Point(76, 5);
            this.lblPagoFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPagoFactura.Name = "lblPagoFactura";
            this.lblPagoFactura.Size = new System.Drawing.Size(177, 25);
            this.lblPagoFactura.TabIndex = 0;
            this.lblPagoFactura.Text = "Resumen de pago";
            // 
            // lblSubTotalFactura
            // 
            this.lblSubTotalFactura.AutoSize = true;
            this.lblSubTotalFactura.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSubTotalFactura.Location = new System.Drawing.Point(27, 41);
            this.lblSubTotalFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTotalFactura.Name = "lblSubTotalFactura";
            this.lblSubTotalFactura.Size = new System.Drawing.Size(66, 19);
            this.lblSubTotalFactura.TabIndex = 3;
            this.lblSubTotalFactura.Text = "SubTotal:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtSubTotal.Location = new System.Drawing.Point(109, 40);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(155, 19);
            this.txtSubTotal.TabIndex = 2;
            // 
            // lblIvaFactura
            // 
            this.lblIvaFactura.AutoSize = true;
            this.lblIvaFactura.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblIvaFactura.Location = new System.Drawing.Point(27, 67);
            this.lblIvaFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIvaFactura.Name = "lblIvaFactura";
            this.lblIvaFactura.Size = new System.Drawing.Size(37, 19);
            this.lblIvaFactura.TabIndex = 10;
            this.lblIvaFactura.Text = "IVA:";
            // 
            // lblTotalFactura
            // 
            this.lblTotalFactura.AutoSize = true;
            this.lblTotalFactura.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTotalFactura.Location = new System.Drawing.Point(28, 122);
            this.lblTotalFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalFactura.Name = "lblTotalFactura";
            this.lblTotalFactura.Size = new System.Drawing.Size(42, 19);
            this.lblTotalFactura.TabIndex = 1;
            this.lblTotalFactura.Text = "Total:";
            // 
            // pnlObservacion
            // 
            this.pnlObservacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlObservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlObservacion.Controls.Add(this.txtObservaciones);
            this.pnlObservacion.Controls.Add(this.lblObservacion);
            this.pnlObservacion.Location = new System.Drawing.Point(8, 343);
            this.pnlObservacion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlObservacion.Name = "pnlObservacion";
            this.pnlObservacion.Size = new System.Drawing.Size(332, 84);
            this.pnlObservacion.TabIndex = 43;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservaciones.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(17, 37);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(300, 37);
            this.txtObservaciones.TabIndex = 36;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(19, 8);
            this.lblObservacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(169, 25);
            this.lblObservacion.TabIndex = 0;
            this.lblObservacion.Text = "Observaciones  :";
            // 
            // btnGerarPdfModificado
            // 
            this.btnGerarPdfModificado.BackColor = System.Drawing.Color.Silver;
            this.btnGerarPdfModificado.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarPdfModificado.Image = global::Vista.Properties.Resources.archivo_pdfIconoManuales;
            this.btnGerarPdfModificado.Location = new System.Drawing.Point(11, 446);
            this.btnGerarPdfModificado.Margin = new System.Windows.Forms.Padding(2);
            this.btnGerarPdfModificado.Name = "btnGerarPdfModificado";
            this.btnGerarPdfModificado.Size = new System.Drawing.Size(133, 41);
            this.btnGerarPdfModificado.TabIndex = 44;
            this.btnGerarPdfModificado.Text = "Generar PDF";
            this.btnGerarPdfModificado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGerarPdfModificado.UseVisualStyleBackColor = false;
            this.btnGerarPdfModificado.Click += new System.EventHandler(this.btnGerarPdfModificado_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarCambios.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Location = new System.Drawing.Point(148, 453);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(191, 29);
            this.btnGuardarCambios.TabIndex = 45;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // frmEditarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(363, 498);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnGerarPdfModificado);
            this.Controls.Add(this.pnlObservacion);
            this.Controls.Add(this.pnlResumenDePagoFactura);
            this.Controls.Add(this.pnlDatosGeneralesFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar factura";
            this.Load += new System.EventHandler(this.frmEditarFactura_Load);
            this.pnlDatosGeneralesFactura.ResumeLayout(false);
            this.pnlDatosGeneralesFactura.PerformLayout();
            this.pnlResumenDePagoFactura.ResumeLayout(false);
            this.pnlResumenDePagoFactura.PerformLayout();
            this.pnlObservacion.ResumeLayout(false);
            this.pnlObservacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatosGeneralesFactura;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label lblNFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.DateTimePicker dtFechaEmision;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblDatosGeneralesClienteFactura;
        private System.Windows.Forms.Label lblFechaEmisionFactura;
        private System.Windows.Forms.Panel pnlResumenDePagoFactura;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblPagoFactura;
        private System.Windows.Forms.Label lblSubTotalFactura;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblIvaFactura;
        private System.Windows.Forms.Label lblTotalFactura;
        private System.Windows.Forms.Panel pnlObservacion;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Button btnGerarPdfModificado;
        private System.Windows.Forms.Button btnGuardarCambios;
    }
}