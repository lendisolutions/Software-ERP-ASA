namespace ERP.Presentacion.Modulos.Production.Reportes
{
    partial class frmRepShippingReportVicenPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepShippingReportVicenPO));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumberPO = new DevExpress.XtraEditors.TextEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 16);
            this.labelControl1.TabIndex = 86;
            this.labelControl1.Text = "# Number PO : ";
            // 
            // txtNumberPO
            // 
            this.txtNumberPO.Location = new System.Drawing.Point(109, 32);
            this.txtNumberPO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPO.Name = "txtNumberPO";
            this.txtNumberPO.Properties.DisplayFormat.FormatString = "f0";
            this.txtNumberPO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumberPO.Size = new System.Drawing.Size(267, 22);
            this.txtNumberPO.TabIndex = 85;
            this.txtNumberPO.ToolTip = "Numero de Documento de Compra";
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = global::ERP.Presentacion.Properties.Resources.excel_16x16;
            this.btnExport.ImageOptions.ImageIndex = 1;
            this.btnExport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(242, 89);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(134, 28);
            this.btnExport.TabIndex = 154;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(381, 89);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 153;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRepShippingReportVicenPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(4100, 128);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNumberPO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepShippingReportVicenPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping Report Vince PO";
            this.Load += new System.EventHandler(this.frmRepShippingReportVicenPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}