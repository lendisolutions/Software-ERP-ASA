namespace ERP.Presentacion.Modulos.Production.Reportes
{
    partial class frmRepProgramProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepProgramProduction));
            this.btnInforme = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.cboVendor = new DevExpress.XtraEditors.LookUpEdit();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deDateFrom = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInforme
            // 
            this.btnInforme.ImageOptions.Image = global::ERP.Presentacion.Properties.Resources.m_Reportes_16x16;
            this.btnInforme.ImageOptions.ImageIndex = 1;
            this.btnInforme.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(355, 145);
            this.btnInforme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(87, 28);
            this.btnInforme.TabIndex = 94;
            this.btnInforme.Text = "Report";
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(448, 145);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboVendor
            // 
            this.cboVendor.Location = new System.Drawing.Point(100, 43);
            this.cboVendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendor.Properties.NullText = "";
            this.cboVendor.Size = new System.Drawing.Size(455, 22);
            this.cboVendor.TabIndex = 98;
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.Location = new System.Drawing.Point(6, 42);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(79, 21);
            this.chkVendor.TabIndex = 97;
            this.chkVendor.Text = "Vendor:";
            this.chkVendor.UseVisualStyleBackColor = true;
            // 
            // cboClient
            // 
            this.cboClient.Location = new System.Drawing.Point(100, 13);
            this.cboClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboClient.Name = "cboClient";
            this.cboClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClient.Properties.NullText = "";
            this.cboClient.Size = new System.Drawing.Size(455, 22);
            this.cboClient.TabIndex = 96;
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Checked = true;
            this.chkClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClient.Location = new System.Drawing.Point(6, 14);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(68, 21);
            this.chkClient.TabIndex = 95;
            this.chkClient.Text = "Client:";
            this.chkClient.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 102;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "From:";
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deDateTo.Location = new System.Drawing.Point(100, 103);
            this.deDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDateTo.Size = new System.Drawing.Size(124, 22);
            this.deDateTo.TabIndex = 100;
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deDateFrom.Location = new System.Drawing.Point(100, 73);
            this.deDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deDateFrom.TabIndex = 99;
            // 
            // frmRepProgramProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 186);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deDateTo);
            this.Controls.Add(this.deDateFrom);
            this.Controls.Add(this.cboVendor);
            this.Controls.Add(this.chkVendor);
            this.Controls.Add(this.cboClient);
            this.Controls.Add(this.chkClient);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepProgramProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Program Production";
            this.Load += new System.EventHandler(this.frmRepProgramProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInforme;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.LookUpEdit cboVendor;
        private System.Windows.Forms.CheckBox chkVendor;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deDateTo;
        private DevExpress.XtraEditors.DateEdit deDateFrom;
    }
}