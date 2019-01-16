namespace ERP.Presentacion.Modulos.Otros
{
    partial class frmBusType
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
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcType = new DevExpress.XtraGrid.GridControl();
            this.gvType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSerie = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 13);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(362, 22);
            this.txtDescription.TabIndex = 57;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 58;
            this.labelControl1.Text = "Description:";
            // 
            // gcType
            // 
            this.gcType.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcType.Location = new System.Drawing.Point(3, 43);
            this.gcType.MainView = this.gvType;
            this.gcType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcType.Name = "gcType";
            this.gcType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtSerie});
            this.gcType.Size = new System.Drawing.Size(436, 211);
            this.gcType.TabIndex = 195;
            this.gcType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvType});
            // 
            // gvType
            // 
            this.gvType.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvType.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvType.Appearance.ViewCaption.Options.UseFont = true;
            this.gvType.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn4});
            this.gvType.GridControl = this.gcType;
            this.gvType.Name = "gvType";
            this.gvType.OptionsView.ColumnAutoWidth = false;
            this.gvType.OptionsView.ShowGroupPanel = false;
            this.gvType.OptionsView.ShowViewCaption = true;
            this.gvType.ViewCaption = "LIST TYPE";
            this.gvType.DoubleClick += new System.EventHandler(this.gvType_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdType";
            this.gridColumn8.FieldName = "IdType";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Type";
            this.gridColumn4.FieldName = "NameType";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 200;
            // 
            // gcTxtSerie
            // 
            this.gcTxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSerie.Name = "gcTxtSerie";
            // 
            // frmBusType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 253);
            this.Controls.Add(this.gcType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FInd Type";
            this.Load += new System.EventHandler(this.frmBusType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSerie;
    }
}