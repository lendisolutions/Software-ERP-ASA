﻿namespace ERP.Presentacion.Modulos.Administration.Maestros
{
    partial class frmManDestination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDestination));
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlbMenu = new ERP.Presentacion.ControlUser.UIToolBar();
            this.gcDestination = new DevExpress.XtraGrid.GridControl();
            this.gvDestination = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestination)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(458, 37);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(90, 38);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(362, 22);
            this.txtDescripcion.TabIndex = 29;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 42);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Description:";
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(5);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(601, 30);
            this.tlbMenu.TabIndex = 27;
            this.tlbMenu.NewClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ERP.Presentacion.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcDestination
            // 
            this.gcDestination.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDestination.Location = new System.Drawing.Point(0, 70);
            this.gcDestination.MainView = this.gvDestination;
            this.gcDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDestination.Name = "gcDestination";
            this.gcDestination.Size = new System.Drawing.Size(600, 551);
            this.gcDestination.TabIndex = 31;
            this.gcDestination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDestination});
            // 
            // gvDestination
            // 
            this.gvDestination.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn4});
            this.gvDestination.GridControl = this.gcDestination;
            this.gvDestination.Name = "gvDestination";
            this.gvDestination.OptionsView.ShowGroupPanel = false;
            this.gvDestination.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDestination_RowCellStyle);
            this.gvDestination.DoubleClick += new System.EventHandler(this.gvDestination_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdCompany";
            this.gridColumn2.FieldName = "IdCompany";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdDestination";
            this.gridColumn8.FieldName = "IdDestination";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Destination";
            this.gridColumn7.FieldName = "NameDestination";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 478;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Line Certifcate";
            this.gridColumn1.FieldName = "NumberLineCertificate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 102;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "FlagStatus";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 69;
            // 
            // frmManDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 623);
            this.Controls.Add(this.gcDestination);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tlbMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDestination";
            this.Text = "Destination - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManDestination_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDestination)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcDestination;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDestination;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}