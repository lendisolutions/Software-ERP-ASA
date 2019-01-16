namespace ERP.Presentacion.Modulos.Otros
{
    partial class frmBusElementTable
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
            this.gcElementTablet = new DevExpress.XtraGrid.GridControl();
            this.gvElementTablet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSerie = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcElementTablet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvElementTablet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 13);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(362, 22);
            this.txtDescription.TabIndex = 59;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(2, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 60;
            this.labelControl1.Text = "Description:";
            // 
            // gcElementTablet
            // 
            this.gcElementTablet.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcElementTablet.Location = new System.Drawing.Point(2, 45);
            this.gcElementTablet.MainView = this.gvElementTablet;
            this.gcElementTablet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcElementTablet.Name = "gcElementTablet";
            this.gcElementTablet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtSerie});
            this.gcElementTablet.Size = new System.Drawing.Size(436, 211);
            this.gcElementTablet.TabIndex = 196;
            this.gcElementTablet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvElementTablet});
            // 
            // gvElementTablet
            // 
            this.gvElementTablet.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvElementTablet.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvElementTablet.Appearance.ViewCaption.Options.UseFont = true;
            this.gvElementTablet.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvElementTablet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn4});
            this.gvElementTablet.GridControl = this.gcElementTablet;
            this.gvElementTablet.Name = "gvElementTablet";
            this.gvElementTablet.OptionsView.ColumnAutoWidth = false;
            this.gvElementTablet.OptionsView.ShowGroupPanel = false;
            this.gvElementTablet.OptionsView.ShowViewCaption = true;
            this.gvElementTablet.ViewCaption = "LIST ELEMENT TABLET";
            this.gvElementTablet.DoubleClick += new System.EventHandler(this.gvElementTablet_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdElementTablet";
            this.gridColumn8.FieldName = "IdElementTablet";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Description";
            this.gridColumn4.FieldName = "NameElementTablet";
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
            // frmBusElementTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 269);
            this.Controls.Add(this.gcElementTablet);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusElementTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBusElementTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcElementTablet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvElementTablet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcElementTablet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvElementTablet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSerie;
    }
}