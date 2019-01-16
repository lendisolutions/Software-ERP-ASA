namespace ERP.Presentacion.Modulos.Otros
{
    partial class frmBusStyle
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
            this.gcStyle = new DevExpress.XtraGrid.GridControl();
            this.gvStyle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSerie = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcStyle
            // 
            this.gcStyle.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcStyle.Location = new System.Drawing.Point(-1, 38);
            this.gcStyle.MainView = this.gvStyle;
            this.gcStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcStyle.Name = "gcStyle";
            this.gcStyle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtSerie});
            this.gcStyle.Size = new System.Drawing.Size(704, 646);
            this.gcStyle.TabIndex = 204;
            this.gcStyle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStyle});
            // 
            // gvStyle
            // 
            this.gvStyle.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvStyle.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvStyle.Appearance.ViewCaption.Options.UseFont = true;
            this.gvStyle.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvStyle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2});
            this.gvStyle.GridControl = this.gcStyle;
            this.gvStyle.Name = "gvStyle";
            this.gvStyle.OptionsView.ColumnAutoWidth = false;
            this.gvStyle.OptionsView.ShowGroupPanel = false;
            this.gvStyle.OptionsView.ShowViewCaption = true;
            this.gvStyle.ViewCaption = "LIST STYLE";
            this.gvStyle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvStyle_KeyUp);
            this.gvStyle.DoubleClick += new System.EventHandler(this.gvStyle_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdStyle";
            this.gridColumn8.FieldName = "IdStyle";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Style";
            this.gridColumn1.FieldName = "NameStyle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Description";
            this.gridColumn4.FieldName = "Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 300;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Item";
            this.gridColumn2.FieldName = "Item";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 150;
            // 
            // gcTxtSerie
            // 
            this.gcTxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSerie.Name = "gcTxtSerie";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(114, 8);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(405, 22);
            this.txtDescription.TabIndex = 202;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 8);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 203;
            this.labelControl1.Text = "Description:";
            // 
            // frmBusStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 693);
            this.Controls.Add(this.gcStyle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusStyle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Style";
            this.Load += new System.EventHandler(this.frmBusStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcStyle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSerie;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}