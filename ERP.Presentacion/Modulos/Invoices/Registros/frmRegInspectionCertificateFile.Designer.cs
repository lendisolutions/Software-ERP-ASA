namespace ERP.Presentacion.Modulos.Invoices.Registros
{
    partial class frmRegInspectionCertificateFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInspectionCertificateFile));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNumberCertificateFrom = new DevExpress.XtraEditors.TextEdit();
            this.txtNumberCertificateTo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVendor = new DevExpress.XtraEditors.LookUpEdit();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcInspectionCertificate = new DevExpress.XtraGrid.GridControl();
            this.gvInspectionCertificate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspectionCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionCertificate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtNumberCertificateFrom);
            this.groupControl1.Controls.Add(this.txtNumberCertificateTo);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cboVendor);
            this.groupControl1.Controls.Add(this.chkVendor);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1318, 66);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Search Criteria";
            // 
            // txtNumberCertificateFrom
            // 
            this.txtNumberCertificateFrom.Location = new System.Drawing.Point(622, 37);
            this.txtNumberCertificateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberCertificateFrom.Name = "txtNumberCertificateFrom";
            this.txtNumberCertificateFrom.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCertificateFrom.Properties.Mask.EditMask = "f0";
            this.txtNumberCertificateFrom.Properties.MaxLength = 20;
            this.txtNumberCertificateFrom.Size = new System.Drawing.Size(184, 22);
            this.txtNumberCertificateFrom.TabIndex = 76;
            this.txtNumberCertificateFrom.ToolTip = "Numero de Documento de Compra";
            // 
            // txtNumberCertificateTo
            // 
            this.txtNumberCertificateTo.Location = new System.Drawing.Point(842, 37);
            this.txtNumberCertificateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberCertificateTo.Name = "txtNumberCertificateTo";
            this.txtNumberCertificateTo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCertificateTo.Properties.Mask.EditMask = "f0";
            this.txtNumberCertificateTo.Properties.MaxLength = 20;
            this.txtNumberCertificateTo.Size = new System.Drawing.Size(184, 22);
            this.txtNumberCertificateTo.TabIndex = 75;
            this.txtNumberCertificateTo.ToolTip = "Numero de Documento de Compra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // cboVendor
            // 
            this.cboVendor.Location = new System.Drawing.Point(126, 36);
            this.cboVendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendor.Properties.NullText = "";
            this.cboVendor.Size = new System.Drawing.Size(445, 22);
            this.cboVendor.TabIndex = 33;
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.Checked = true;
            this.chkVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendor.Location = new System.Drawing.Point(22, 37);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(79, 21);
            this.chkVendor.TabIndex = 32;
            this.chkVendor.Text = "Vendor:";
            this.chkVendor.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(1032, 34);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcInspectionCertificate
            // 
            this.gcInspectionCertificate.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspectionCertificate.Location = new System.Drawing.Point(0, 74);
            this.gcInspectionCertificate.MainView = this.gvInspectionCertificate;
            this.gcInspectionCertificate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspectionCertificate.Name = "gcInspectionCertificate";
            this.gcInspectionCertificate.Size = new System.Drawing.Size(1318, 592);
            this.gcInspectionCertificate.TabIndex = 67;
            this.gcInspectionCertificate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInspectionCertificate});
            // 
            // gvInspectionCertificate
            // 
            this.gvInspectionCertificate.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvInspectionCertificate.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvInspectionCertificate.Appearance.ViewCaption.Options.UseFont = true;
            this.gvInspectionCertificate.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvInspectionCertificate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gcXfDate,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn1});
            this.gvInspectionCertificate.GridControl = this.gcInspectionCertificate;
            this.gvInspectionCertificate.Name = "gvInspectionCertificate";
            this.gvInspectionCertificate.OptionsSelection.MultiSelect = true;
            this.gvInspectionCertificate.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvInspectionCertificate.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvInspectionCertificate.OptionsView.ColumnAutoWidth = false;
            this.gvInspectionCertificate.OptionsView.ShowGroupPanel = false;
            this.gvInspectionCertificate.OptionsView.ShowViewCaption = true;
            this.gvInspectionCertificate.ViewCaption = "LIST INSPECTION CERTIFICATE";
            this.gvInspectionCertificate.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvInspectionCertificate_RowCellStyle);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdInspectionCertificate";
            this.gridColumn3.FieldName = "IdInspectionCertificate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.DarkViolet;
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "Certificate";
            this.gridColumn5.FieldName = "NumberCertificate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 120;
            // 
            // gcXfDate
            // 
            this.gcXfDate.Caption = "Issue Date";
            this.gcXfDate.DisplayFormat.FormatString = "d";
            this.gcXfDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcXfDate.FieldName = "IssueDate";
            this.gcXfDate.Name = "gcXfDate";
            this.gcXfDate.OptionsColumn.AllowEdit = false;
            this.gcXfDate.OptionsColumn.AllowFocus = false;
            this.gcXfDate.Visible = true;
            this.gcXfDate.VisibleIndex = 2;
            this.gcXfDate.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Client";
            this.gridColumn4.FieldName = "NameClient";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Invoice";
            this.gridColumn6.FieldName = "NumberInvoice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "P.O";
            this.gridColumn11.FieldName = "NumberPO";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            this.gridColumn11.Width = 300;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Style";
            this.gridColumn7.FieldName = "DescriptionStyle";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdStatus";
            this.gridColumn2.FieldName = "IdStatus";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Status";
            this.gridColumn1.FieldName = "NameStatus";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 90;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1219, 674);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 237;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(1126, 674);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 236;
            this.btnGrabar.Text = "Save";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegInspectionCertificateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 713);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.gcInspectionCertificate);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegInspectionCertificateFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Status Finished";
            this.Load += new System.EventHandler(this.frmRegInspectionCertificateFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspectionCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionCertificate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.LookUpEdit cboVendor;
        private System.Windows.Forms.CheckBox chkVendor;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtNumberCertificateFrom;
        private DevExpress.XtraEditors.TextEdit txtNumberCertificateTo;
        private DevExpress.XtraGrid.GridControl gcInspectionCertificate;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInspectionCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}