namespace ERP.Presentacion.Modulos.Otros
{
    partial class frmBusUbigeo
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
            this.gcUbigeo = new DevExpress.XtraGrid.GridControl();
            this.gvUbigeo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSerie = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcUbigeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUbigeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUbigeo
            // 
            this.gcUbigeo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcUbigeo.Location = new System.Drawing.Point(7, 38);
            this.gcUbigeo.MainView = this.gvUbigeo;
            this.gcUbigeo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcUbigeo.Name = "gcUbigeo";
            this.gcUbigeo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtSerie});
            this.gcUbigeo.Size = new System.Drawing.Size(484, 646);
            this.gcUbigeo.TabIndex = 201;
            this.gcUbigeo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUbigeo});
            // 
            // gvUbigeo
            // 
            this.gvUbigeo.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvUbigeo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvUbigeo.Appearance.ViewCaption.Options.UseFont = true;
            this.gvUbigeo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvUbigeo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn4});
            this.gvUbigeo.GridControl = this.gcUbigeo;
            this.gvUbigeo.Name = "gvUbigeo";
            this.gvUbigeo.OptionsView.ColumnAutoWidth = false;
            this.gvUbigeo.OptionsView.ShowGroupPanel = false;
            this.gvUbigeo.OptionsView.ShowViewCaption = true;
            this.gvUbigeo.ViewCaption = "LIST UBIGEO";
            this.gvUbigeo.DoubleClick += new System.EventHandler(this.gvUbigeo_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdUbigeo";
            this.gridColumn8.FieldName = "IdUbigeo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "NomDist";
            this.gridColumn1.FieldName = "NomDist";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ubigeo";
            this.gridColumn4.FieldName = "NomUbigeo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 400;
            // 
            // gcTxtSerie
            // 
            this.gcTxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSerie.Name = "gcTxtSerie";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(86, 8);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(405, 22);
            this.txtDescription.TabIndex = 199;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 200;
            this.labelControl1.Text = "Description:";
            // 
            // frmBusUbigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 693);
            this.Controls.Add(this.gcUbigeo);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusUbigeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FInd District";
            this.Load += new System.EventHandler(this.frmBusUbigeo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUbigeo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUbigeo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUbigeo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUbigeo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSerie;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}