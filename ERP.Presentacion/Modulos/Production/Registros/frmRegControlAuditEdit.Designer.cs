namespace ERP.Presentacion.Modulos.Production.Registros
{
    partial class frmRegControlAuditEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegControlAuditEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcProgramProductionAudit = new DevExpress.XtraGrid.GridControl();
            this.gvProgramProductionAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtNumeroOI = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtComment = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSituation = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtGarmentBox = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListadoProgramProductionAudit = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroOI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtGarmentBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoProgramProductionAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcProgramProductionAudit);
            this.groupControl1.Location = new System.Drawing.Point(2, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1262, 387);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Control Audit";
            // 
            // gcProgramProductionAudit
            // 
            this.gcProgramProductionAudit.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionAudit.Location = new System.Drawing.Point(1, 29);
            this.gcProgramProductionAudit.MainView = this.gvProgramProductionAudit;
            this.gcProgramProductionAudit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionAudit.Name = "gcProgramProductionAudit";
            this.gcProgramProductionAudit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtComment,
            this.gcTxtSituation,
            this.gcTxtNumeroOI,
            this.gcTxtGarmentBox});
            this.gcProgramProductionAudit.Size = new System.Drawing.Size(1256, 358);
            this.gcProgramProductionAudit.TabIndex = 244;
            this.gcProgramProductionAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProductionAudit});
            // 
            // gvProgramProductionAudit
            // 
            this.gvProgramProductionAudit.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvProgramProductionAudit.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProductionAudit.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProgramProductionAudit.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProgramProductionAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn42});
            this.gvProgramProductionAudit.GridControl = this.gcProgramProductionAudit;
            this.gvProgramProductionAudit.Name = "gvProgramProductionAudit";
            this.gvProgramProductionAudit.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gvProgramProductionAudit.OptionsSelection.MultiSelect = true;
            this.gvProgramProductionAudit.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProductionAudit.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProductionAudit.OptionsView.RowAutoHeight = true;
            this.gvProgramProductionAudit.OptionsView.ShowGroupPanel = false;
            this.gvProgramProductionAudit.OptionsView.ShowViewCaption = true;
            this.gvProgramProductionAudit.ViewCaption = "LIST CONTROL OI\'S";
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "IdCompany";
            this.gridColumn35.FieldName = "IdCompany";
            this.gridColumn35.Name = "gridColumn35";
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "IdProgramProduction";
            this.gridColumn36.FieldName = "IdProgramProduction";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "IdProgramProductionDetail";
            this.gridColumn37.FieldName = "IdProgramProductionDetail";
            this.gridColumn37.Name = "gridColumn37";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdProgramProductionAudit";
            this.gridColumn5.FieldName = "IdProgramProductionAudit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IdStyle";
            this.gridColumn9.FieldName = "IdStyle";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.DisplayFormat.FormatString = "d";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "AuditDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "O/I";
            this.gridColumn6.ColumnEdit = this.gcTxtNumeroOI;
            this.gridColumn6.FieldName = "NumeroOI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gcTxtNumeroOI
            // 
            this.gcTxtNumeroOI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtNumeroOI.Name = "gcTxtNumeroOI";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceCell.ForeColor = System.Drawing.Color.Navy;
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn7.Caption = "Send Date";
            this.gridColumn7.DisplayFormat.FormatString = "d";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "SendDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn1.Caption = "Return Date";
            this.gridColumn1.DisplayFormat.FormatString = "d";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "ReturnDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Comment";
            this.gridColumn3.ColumnEdit = this.gcTxtComment;
            this.gridColumn3.FieldName = "Comment";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 500;
            // 
            // gcTxtComment
            // 
            this.gcTxtComment.Appearance.Options.UseTextOptions = true;
            this.gcTxtComment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcTxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtComment.Name = "gcTxtComment";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° File Box";
            this.gridColumn2.ColumnEdit = this.gcTxtSituation;
            this.gridColumn2.FieldName = "FileBox";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 90;
            // 
            // gcTxtSituation
            // 
            this.gcTxtSituation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSituation.Name = "gcTxtSituation";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "N° Garment Box";
            this.gridColumn8.ColumnEdit = this.gcTxtGarmentBox;
            this.gridColumn8.FieldName = "GarmentBox";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 120;
            // 
            // gcTxtGarmentBox
            // 
            this.gcTxtGarmentBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtGarmentBox.Name = "gcTxtGarmentBox";
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "TipoOper";
            this.gridColumn42.FieldName = "TipoOper";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
            this.gridColumn42.OptionsColumn.AllowFocus = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1172, 395);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(1079, 395);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 21;
            this.btnGrabar.Text = "Save";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegControlAuditEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 436);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegControlAuditEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegControlAuditEdit";
            this.Load += new System.EventHandler(this.frmRegControlAuditEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroOI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtGarmentBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoProgramProductionAudit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcProgramProductionAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProductionAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtNumeroOI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtComment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtGarmentBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.BindingSource bsListadoProgramProductionAudit;
    }
}