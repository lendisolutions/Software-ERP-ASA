namespace ERP.Presentacion.Modulos.Otros
{
    partial class frmBusDestination
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
            this.gcDestination = new DevExpress.XtraGrid.GridControl();
            this.gvDestination = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSerie = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDestination
            // 
            this.gcDestination.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDestination.Location = new System.Drawing.Point(7, 43);
            this.gcDestination.MainView = this.gvDestination;
            this.gcDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDestination.Name = "gcDestination";
            this.gcDestination.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtSerie});
            this.gcDestination.Size = new System.Drawing.Size(441, 646);
            this.gcDestination.TabIndex = 198;
            this.gcDestination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDestination});
            // 
            // gvDestination
            // 
            this.gvDestination.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvDestination.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvDestination.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDestination.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvDestination.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn4});
            this.gvDestination.GridControl = this.gcDestination;
            this.gvDestination.Name = "gvDestination";
            this.gvDestination.OptionsView.ColumnAutoWidth = false;
            this.gvDestination.OptionsView.ShowGroupPanel = false;
            this.gvDestination.OptionsView.ShowViewCaption = true;
            this.gvDestination.ViewCaption = "LIST DESTINATION";
            this.gvDestination.DoubleClick += new System.EventHandler(this.gvDestination_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdDestination";
            this.gridColumn8.FieldName = "IdDestination";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Destination";
            this.gridColumn4.FieldName = "NameDestination";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 300;
            // 
            // gcTxtSerie
            // 
            this.gcTxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSerie.Name = "gcTxtSerie";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(86, 13);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(362, 22);
            this.txtDescription.TabIndex = 196;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 197;
            this.labelControl1.Text = "Description:";
            // 
            // frmBusDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 693);
            this.Controls.Add(this.gcDestination);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusDestination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Destination";
            this.Load += new System.EventHandler(this.frmBusDestination_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDestination;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDestination;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSerie;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}