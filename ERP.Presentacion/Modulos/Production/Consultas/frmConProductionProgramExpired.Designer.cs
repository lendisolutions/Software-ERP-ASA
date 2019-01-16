namespace ERP.Presentacion.Modulos.Production.Consultas
{
    partial class frmConProductionProgramExpired
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProductionProgramExpired));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNumberPO = new DevExpress.XtraEditors.TextEdit();
            this.chkNumberPO = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deRevenueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deRevenueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkXfDate = new System.Windows.Forms.CheckBox();
            this.cboDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.chkDivision = new System.Windows.Forms.CheckBox();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcProgramProduction = new DevExpress.XtraGrid.GridControl();
            this.gvProgramProduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTypeProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
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
            this.toolStrip1.TabIndex = 63;
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
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 64;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtNumberPO);
            this.groupControl1.Controls.Add(this.chkNumberPO);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.deRevenueDateTo);
            this.groupControl1.Controls.Add(this.deRevenueDateFrom);
            this.groupControl1.Controls.Add(this.chkXfDate);
            this.groupControl1.Controls.Add(this.cboDivision);
            this.groupControl1.Controls.Add(this.chkDivision);
            this.groupControl1.Controls.Add(this.cboClient);
            this.groupControl1.Controls.Add(this.chkClient);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1450, 102);
            this.groupControl1.TabIndex = 27;
            this.groupControl1.Text = "Search Criteria";
            // 
            // txtNumberPO
            // 
            this.txtNumberPO.Location = new System.Drawing.Point(541, 66);
            this.txtNumberPO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPO.Name = "txtNumberPO";
            this.txtNumberPO.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPO.Properties.Mask.EditMask = "f0";
            this.txtNumberPO.Properties.MaxLength = 20;
            this.txtNumberPO.Size = new System.Drawing.Size(184, 22);
            this.txtNumberPO.TabIndex = 73;
            this.txtNumberPO.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumberPO
            // 
            this.chkNumberPO.AutoSize = true;
            this.chkNumberPO.Location = new System.Drawing.Point(474, 67);
            this.chkNumberPO.Name = "chkNumberPO";
            this.chkNumberPO.Size = new System.Drawing.Size(61, 21);
            this.chkNumberPO.TabIndex = 70;
            this.chkNumberPO.Text = "P.O.:";
            this.chkNumberPO.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // deRevenueDateTo
            // 
            this.deRevenueDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deRevenueDateTo.Location = new System.Drawing.Point(336, 66);
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
            this.deRevenueDateFrom.Location = new System.Drawing.Point(176, 66);
            this.deRevenueDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deRevenueDateFrom.Name = "deRevenueDateFrom";
            this.deRevenueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRevenueDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deRevenueDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deRevenueDateFrom.TabIndex = 60;
            // 
            // chkXfDate
            // 
            this.chkXfDate.AutoSize = true;
            this.chkXfDate.Location = new System.Drawing.Point(22, 67);
            this.chkXfDate.Name = "chkXfDate";
            this.chkXfDate.Size = new System.Drawing.Size(75, 21);
            this.chkXfDate.TabIndex = 36;
            this.chkXfDate.Text = "Xf Date";
            this.chkXfDate.UseVisualStyleBackColor = true;
            // 
            // cboDivision
            // 
            this.cboDivision.Location = new System.Drawing.Point(634, 36);
            this.cboDivision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDivision.Properties.NullText = "";
            this.cboDivision.Size = new System.Drawing.Size(467, 22);
            this.cboDivision.TabIndex = 35;
            // 
            // chkDivision
            // 
            this.chkDivision.AutoSize = true;
            this.chkDivision.Location = new System.Drawing.Point(547, 37);
            this.chkDivision.Name = "chkDivision";
            this.chkDivision.Size = new System.Drawing.Size(81, 21);
            this.chkDivision.TabIndex = 34;
            this.chkDivision.Text = "Division:";
            this.chkDivision.UseVisualStyleBackColor = true;
            // 
            // cboClient
            // 
            this.cboClient.Location = new System.Drawing.Point(96, 36);
            this.cboClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboClient.Name = "cboClient";
            this.cboClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClient.Properties.NullText = "";
            this.cboClient.Size = new System.Drawing.Size(445, 22);
            this.cboClient.TabIndex = 33;
            this.cboClient.EditValueChanged += new System.EventHandler(this.cboClient_EditValueChanged);
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Checked = true;
            this.chkClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClient.Location = new System.Drawing.Point(22, 37);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(68, 21);
            this.chkClient.TabIndex = 32;
            this.chkClient.Text = "Client:";
            this.chkClient.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(1116, 48);
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
            this.gcProgramProduction.Size = new System.Drawing.Size(1450, 518);
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
            this.gridColumn5,
            this.gcXfDate,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn14,
            this.gridColumn13,
            this.gcColumna5,
            this.gcColumna6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn9,
            this.gcTypeProduct,
            this.gcIndcDate,
            this.gridColumn7,
            this.gcDays,
            this.gcSituation});
            this.gvProgramProduction.GridControl = this.gcProgramProduction;
            this.gvProgramProduction.Name = "gvProgramProduction";
            this.gvProgramProduction.OptionsSelection.MultiSelect = true;
            this.gvProgramProduction.OptionsView.AllowCellMerge = true;
            this.gvProgramProduction.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProduction.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProduction.OptionsView.ShowGroupPanel = false;
            this.gvProgramProduction.OptionsView.ShowViewCaption = true;
            this.gvProgramProduction.ViewCaption = "LIST PRODUCTION PROGRAM";
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
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Navy;
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "P.O.";
            this.gridColumn5.FieldName = "NumberPO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 100;
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
            this.gcXfDate.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Division";
            this.gridColumn12.FieldName = "NameDivision";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 150;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Vendor";
            this.gridColumn11.FieldName = "NameVendor";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 250;
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
            this.gridColumn8.VisibleIndex = 4;
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
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Item";
            this.gridColumn14.FieldName = "Item";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Color";
            this.gridColumn13.FieldName = "Detail";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            this.gridColumn13.Width = 200;
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
            this.gcColumna5.VisibleIndex = 8;
            this.gcColumna5.Width = 100;
            // 
            // gcColumna6
            // 
            this.gcColumna6.Caption = "Fob";
            this.gcColumna6.DisplayFormat.FormatString = "#,0.00";
            this.gcColumna6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcColumna6.FieldName = "Fob";
            this.gcColumna6.Name = "gcColumna6";
            this.gcColumna6.OptionsColumn.AllowEdit = false;
            this.gcColumna6.OptionsColumn.AllowFocus = false;
            this.gcColumna6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcColumna6.Visible = true;
            this.gcColumna6.VisibleIndex = 9;
            this.gcColumna6.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Total";
            this.gridColumn1.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Total";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Commiment";
            this.gridColumn2.FieldName = "NumberCommiment";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            this.gridColumn2.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Label";
            this.gridColumn4.FieldName = "Label";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 12;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Destination";
            this.gridColumn10.FieldName = "NameDestination";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 13;
            this.gridColumn10.Width = 130;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Season";
            this.gridColumn9.FieldName = "NameSeason";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 14;
            this.gridColumn9.Width = 130;
            // 
            // gcTypeProduct
            // 
            this.gcTypeProduct.Caption = "Type Product";
            this.gcTypeProduct.FieldName = "NameTypeProduct";
            this.gcTypeProduct.Name = "gcTypeProduct";
            this.gcTypeProduct.OptionsColumn.AllowEdit = false;
            this.gcTypeProduct.OptionsColumn.AllowFocus = false;
            this.gcTypeProduct.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcTypeProduct.Visible = true;
            this.gcTypeProduct.VisibleIndex = 15;
            this.gcTypeProduct.Width = 80;
            // 
            // gcIndcDate
            // 
            this.gcIndcDate.Caption = "INDC Date";
            this.gcIndcDate.DisplayFormat.FormatString = "d";
            this.gcIndcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcIndcDate.FieldName = "IndcDate";
            this.gcIndcDate.Name = "gcIndcDate";
            this.gcIndcDate.OptionsColumn.AllowEdit = false;
            this.gcIndcDate.OptionsColumn.AllowFocus = false;
            this.gcIndcDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcIndcDate.Visible = true;
            this.gcIndcDate.VisibleIndex = 16;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ship Mode";
            this.gridColumn7.FieldName = "NameShipMode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 17;
            this.gridColumn7.Width = 90;
            // 
            // gcDays
            // 
            this.gcDays.Caption = "Days To Beat";
            this.gcDays.FieldName = "Days";
            this.gcDays.Name = "gcDays";
            this.gcDays.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcDays.Visible = true;
            this.gcDays.VisibleIndex = 18;
            // 
            // gcSituation
            // 
            this.gcSituation.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gcSituation.AppearanceCell.Options.UseFont = true;
            this.gcSituation.Caption = "Situation";
            this.gcSituation.FieldName = "Situation";
            this.gcSituation.Name = "gcSituation";
            this.gcSituation.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcSituation.Visible = true;
            this.gcSituation.VisibleIndex = 19;
            this.gcSituation.Width = 80;
            // 
            // frmConProductionProgramExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 653);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConProductionProgramExpired";
            this.Text = "Consulting Production Program Expired";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConProductionProgramExpired_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
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
        private System.Windows.Forms.CheckBox chkNumberPO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deRevenueDateTo;
        private DevExpress.XtraEditors.DateEdit deRevenueDateFrom;
        private System.Windows.Forms.CheckBox chkXfDate;
        public DevExpress.XtraEditors.LookUpEdit cboDivision;
        private System.Windows.Forms.CheckBox chkDivision;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private System.Windows.Forms.CheckBox chkClient;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcProgramProduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProduction;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna5;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gcTypeProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcDays;
        private DevExpress.XtraGrid.Columns.GridColumn gcSituation;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
    }
}