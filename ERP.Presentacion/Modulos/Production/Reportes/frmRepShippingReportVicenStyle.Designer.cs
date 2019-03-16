namespace ERP.Presentacion.Modulos.Production.Reportes
{
    partial class frmRepShippingReportVicenStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepShippingReportVicenStyle));
            this.btnBusStyle = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtNameStyle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboSeason = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBusStyle
            // 
            this.btnBusStyle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBusStyle.ImageOptions.Image")));
            this.btnBusStyle.Location = new System.Drawing.Point(205, 23);
            this.btnBusStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBusStyle.Name = "btnBusStyle";
            this.btnBusStyle.Size = new System.Drawing.Size(26, 24);
            this.btnBusStyle.TabIndex = 83;
            this.btnBusStyle.Click += new System.EventHandler(this.btnBusStyle_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 51);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.DisplayFormat.FormatString = "f0";
            this.txtDescription.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescription.Size = new System.Drawing.Size(572, 22);
            this.txtDescription.TabIndex = 82;
            this.txtDescription.ToolTip = "Numero de Documento de Compra";
            // 
            // txtNameStyle
            // 
            this.txtNameStyle.Location = new System.Drawing.Point(72, 24);
            this.txtNameStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameStyle.Name = "txtNameStyle";
            this.txtNameStyle.Properties.DisplayFormat.FormatString = "f0";
            this.txtNameStyle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNameStyle.Size = new System.Drawing.Size(127, 22);
            this.txtNameStyle.TabIndex = 81;
            this.txtNameStyle.ToolTip = "Numero de Documento de Compra";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 16);
            this.labelControl1.TabIndex = 84;
            this.labelControl1.Text = "Style : ";
            // 
            // cboSeason
            // 
            this.cboSeason.Location = new System.Drawing.Point(72, 81);
            this.cboSeason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSeason.Name = "cboSeason";
            this.cboSeason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSeason.Properties.NullText = "";
            this.cboSeason.Size = new System.Drawing.Size(572, 22);
            this.cboSeason.TabIndex = 150;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 84);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(47, 16);
            this.labelControl8.TabIndex = 149;
            this.labelControl8.Text = "Season:";
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = global::ERP.Presentacion.Properties.Resources.excel_16x16;
            this.btnExport.ImageOptions.ImageIndex = 1;
            this.btnExport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(413, 127);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(134, 28);
            this.btnExport.TabIndex = 152;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(553, 127);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 151;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRepShippingReportVicenStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 166);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboSeason);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBusStyle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtNameStyle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepShippingReportVicenStyle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping Report Vicen Style";
            this.Load += new System.EventHandler(this.frmRepShippingReportVicenStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBusStyle;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtNameStyle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboSeason;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}