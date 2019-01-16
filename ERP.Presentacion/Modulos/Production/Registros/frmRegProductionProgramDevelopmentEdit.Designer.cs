namespace ERP.Presentacion.Modulos.Production.Registros
{
    partial class frmRegProductionProgramDevelopmentEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegProductionProgramDevelopmentEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcProgramProductionDevelopment = new DevExpress.XtraGrid.GridControl();
            this.mnuContextualPorgramProductionDevelopment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoProgramProductionDevelopmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProgramProductionDevelopmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gvProgramProductionDevelopment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtComment = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSituation = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListadoProgramProductionDevelopment = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionDevelopment)).BeginInit();
            this.mnuContextualPorgramProductionDevelopment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionDevelopment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoProgramProductionDevelopment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcProgramProductionDevelopment);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1071, 431);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Development and Production";
            // 
            // gcProgramProductionDevelopment
            // 
            this.gcProgramProductionDevelopment.ContextMenuStrip = this.mnuContextualPorgramProductionDevelopment;
            this.gcProgramProductionDevelopment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionDevelopment.Location = new System.Drawing.Point(1, 29);
            this.gcProgramProductionDevelopment.MainView = this.gvProgramProductionDevelopment;
            this.gcProgramProductionDevelopment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionDevelopment.Name = "gcProgramProductionDevelopment";
            this.gcProgramProductionDevelopment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtComment,
            this.gcTxtSituation});
            this.gcProgramProductionDevelopment.Size = new System.Drawing.Size(1070, 399);
            this.gcProgramProductionDevelopment.TabIndex = 244;
            this.gcProgramProductionDevelopment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProductionDevelopment});
            // 
            // mnuContextualPorgramProductionDevelopment
            // 
            this.mnuContextualPorgramProductionDevelopment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualPorgramProductionDevelopment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProgramProductionDevelopmentToolStripMenuItem,
            this.eliminarProgramProductionDevelopmentToolStripMenuItem,
            this.toolStripSeparator1});
            this.mnuContextualPorgramProductionDevelopment.Name = "contextMenuStrip1";
            this.mnuContextualPorgramProductionDevelopment.Size = new System.Drawing.Size(137, 62);
            // 
            // nuevoProgramProductionDevelopmentToolStripMenuItem
            // 
            this.nuevoProgramProductionDevelopmentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoProgramProductionDevelopmentToolStripMenuItem.Image")));
            this.nuevoProgramProductionDevelopmentToolStripMenuItem.Name = "nuevoProgramProductionDevelopmentToolStripMenuItem";
            this.nuevoProgramProductionDevelopmentToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.nuevoProgramProductionDevelopmentToolStripMenuItem.Text = "Nuevo";
            this.nuevoProgramProductionDevelopmentToolStripMenuItem.Click += new System.EventHandler(this.nuevoProgramProductionDevelopmentToolStripMenuItem_Click);
            // 
            // eliminarProgramProductionDevelopmentToolStripMenuItem
            // 
            this.eliminarProgramProductionDevelopmentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarProgramProductionDevelopmentToolStripMenuItem.Image")));
            this.eliminarProgramProductionDevelopmentToolStripMenuItem.Name = "eliminarProgramProductionDevelopmentToolStripMenuItem";
            this.eliminarProgramProductionDevelopmentToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.eliminarProgramProductionDevelopmentToolStripMenuItem.Text = "Eliminar";
            this.eliminarProgramProductionDevelopmentToolStripMenuItem.Click += new System.EventHandler(this.eliminarProgramProductionDevelopmentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // gvProgramProductionDevelopment
            // 
            this.gvProgramProductionDevelopment.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvProgramProductionDevelopment.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProductionDevelopment.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProgramProductionDevelopment.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProgramProductionDevelopment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn42});
            this.gvProgramProductionDevelopment.GridControl = this.gcProgramProductionDevelopment;
            this.gvProgramProductionDevelopment.Name = "gvProgramProductionDevelopment";
            this.gvProgramProductionDevelopment.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gvProgramProductionDevelopment.OptionsSelection.MultiSelect = true;
            this.gvProgramProductionDevelopment.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProductionDevelopment.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProductionDevelopment.OptionsView.RowAutoHeight = true;
            this.gvProgramProductionDevelopment.OptionsView.ShowGroupPanel = false;
            this.gvProgramProductionDevelopment.OptionsView.ShowViewCaption = true;
            this.gvProgramProductionDevelopment.ViewCaption = "LIST DEVELOPMENT AND PRODUCTION";
            this.gvProgramProductionDevelopment.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProgramProductionDevelopment_RowCellStyle);
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
            this.gridColumn5.Caption = "IdProgramProductionDetail";
            this.gridColumn5.FieldName = "IdProgramProductionDetail";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.DisplayFormat.FormatString = "d";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "DevDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 90;
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
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 700;
            // 
            // gcTxtComment
            // 
            this.gcTxtComment.Appearance.Options.UseTextOptions = true;
            this.gcTxtComment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcTxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtComment.Name = "gcTxtComment";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdSituation";
            this.gridColumn1.FieldName = "IdSituation";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Situation";
            this.gridColumn2.ColumnEdit = this.gcTxtSituation;
            this.gridColumn2.FieldName = "Situation";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 80;
            // 
            // gcTxtSituation
            // 
            this.gcTxtSituation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSituation.Name = "gcTxtSituation";
            this.gcTxtSituation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcTxtSituation_KeyDown);
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
            this.btnCancelar.Location = new System.Drawing.Point(976, 445);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(883, 445);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "Save";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegProductionProgramDevelopmentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 481);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegProductionProgramDevelopmentEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegProductionProgramDevelopmentEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionDevelopment)).EndInit();
            this.mnuContextualPorgramProductionDevelopment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionDevelopment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoProgramProductionDevelopment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcProgramProductionDevelopment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProductionDevelopment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtComment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.BindingSource bsListadoProgramProductionDevelopment;
        public System.Windows.Forms.ContextMenuStrip mnuContextualPorgramProductionDevelopment;
        private System.Windows.Forms.ToolStripMenuItem nuevoProgramProductionDevelopmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProgramProductionDevelopmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}