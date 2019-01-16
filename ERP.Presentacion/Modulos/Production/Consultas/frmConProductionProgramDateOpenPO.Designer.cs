namespace ERP.Presentacion.Modulos.Production.Consultas
{
    partial class frmConProductionProgramDateOpenPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProductionProgramDateOpenPO));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deRevenueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deRevenueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcProgramProduction = new DevExpress.XtraGrid.GridControl();
            this.gvProgramProduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducionProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProduction)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1450, 27);
            this.toolStrip1.TabIndex = 64;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = global::ERP.Presentacion.Properties.Resources.excel_16x16;
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(24, 24);
            this.toolstpExportarExcel.ToolTipText = "Export To Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(24, 24);
            this.toolstpSalir.ToolTipText = "Close Window";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcProgramProduction);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1450, 626);
            this.splitContainerControl1.SplitterPosition = 74;
            this.splitContainerControl1.TabIndex = 65;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.deRevenueDateTo);
            this.groupControl1.Controls.Add(this.deRevenueDateFrom);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1450, 74);
            this.groupControl1.TabIndex = 27;
            this.groupControl1.Text = "Search Criteria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // deRevenueDateTo
            // 
            this.deRevenueDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deRevenueDateTo.Location = new System.Drawing.Point(214, 42);
            this.deRevenueDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deRevenueDateTo.Name = "deRevenueDateTo";
            this.deRevenueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRevenueDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deRevenueDateTo.Size = new System.Drawing.Size(124, 22);
            this.deRevenueDateTo.TabIndex = 62;
            // 
            // deRevenueDateFrom
            // 
            this.deRevenueDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deRevenueDateFrom.Location = new System.Drawing.Point(58, 42);
            this.deRevenueDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deRevenueDateFrom.Name = "deRevenueDateFrom";
            this.deRevenueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRevenueDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deRevenueDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deRevenueDateFrom.TabIndex = 60;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(344, 40);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcProgramProduction
            // 
            this.gcProgramProduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProgramProduction.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProduction.Location = new System.Drawing.Point(0, 0);
            this.gcProgramProduction.MainView = this.gvProgramProduction;
            this.gcProgramProduction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProduction.Name = "gcProgramProduction";
            this.gcProgramProduction.Size = new System.Drawing.Size(1450, 546);
            this.gcProgramProduction.TabIndex = 67;
            this.gcProgramProduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProduction});
            // 
            // gvProgramProduction
            // 
            this.gvProgramProduction.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvProgramProduction.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProduction.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProgramProduction.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProgramProduction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gcProducionProgram,
            this.gridColumn1,
            this.gridColumn12,
            this.gridColumn8,
            this.gridColumn6,
            this.gcColumna5,
            this.gcXfDate});
            this.gvProgramProduction.GridControl = this.gcProgramProduction;
            this.gvProgramProduction.Name = "gvProgramProduction";
            this.gvProgramProduction.OptionsSelection.MultiSelect = true;
            this.gvProgramProduction.OptionsView.AllowCellMerge = true;
            this.gvProgramProduction.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProduction.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProduction.OptionsView.ShowGroupPanel = false;
            this.gvProgramProduction.OptionsView.ShowViewCaption = true;
            this.gvProgramProduction.ViewCaption = "LIST ASA Open PO Report";
            this.gvProgramProduction.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProgramProduction_RowCellStyle);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdProgramProduction";
            this.gridColumn3.FieldName = "IdProgramProduction";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gcProducionProgram
            // 
            this.gcProducionProgram.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gcProducionProgram.AppearanceCell.ForeColor = System.Drawing.Color.Navy;
            this.gcProducionProgram.AppearanceCell.Options.UseFont = true;
            this.gcProducionProgram.AppearanceCell.Options.UseForeColor = true;
            this.gcProducionProgram.Caption = "Client";
            this.gcProducionProgram.FieldName = "NameClient";
            this.gcProducionProgram.Name = "gcProducionProgram";
            this.gcProducionProgram.OptionsColumn.AllowEdit = false;
            this.gcProducionProgram.OptionsColumn.AllowFocus = false;
            this.gcProducionProgram.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gcProducionProgram.Visible = true;
            this.gcProducionProgram.VisibleIndex = 0;
            this.gcProducionProgram.Width = 300;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Vendor";
            this.gridColumn1.FieldName = "NameVendor";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 250;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Division";
            this.gridColumn12.FieldName = "NameDivision";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 150;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Style";
            this.gridColumn8.FieldName = "NameStyle";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Description";
            this.gridColumn6.FieldName = "Description";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 200;
            // 
            // gcColumna5
            // 
            this.gcColumna5.Caption = "Units";
            this.gcColumna5.DisplayFormat.FormatString = "#,0";
            this.gcColumna5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcColumna5.FieldName = "Units";
            this.gcColumna5.Name = "gcColumna5";
            this.gcColumna5.OptionsColumn.AllowEdit = false;
            this.gcColumna5.OptionsColumn.AllowFocus = false;
            this.gcColumna5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcColumna5.Visible = true;
            this.gcColumna5.VisibleIndex = 5;
            this.gcColumna5.Width = 100;
            // 
            // gcXfDate
            // 
            this.gcXfDate.Caption = "Xf Date";
            this.gcXfDate.DisplayFormat.FormatString = "d";
            this.gcXfDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcXfDate.FieldName = "XfDate";
            this.gcXfDate.Name = "gcXfDate";
            this.gcXfDate.OptionsColumn.AllowEdit = false;
            this.gcXfDate.OptionsColumn.AllowFocus = false;
            this.gcXfDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcXfDate.Visible = true;
            this.gcXfDate.VisibleIndex = 6;
            // 
            // frmConProductionProgramDateOpenPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 653);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConProductionProgramDateOpenPO";
            this.Text = "Consulting Production ASA Open PO Report ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConProductionProgramDateOpenPO_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProduction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deRevenueDateTo;
        private DevExpress.XtraEditors.DateEdit deRevenueDateFrom;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcProgramProduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProduction;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gcProducionProgram;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}