namespace ERP.Presentacion.Modulos.Production.Consultas
{
    partial class frmConProductionProgramSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProductionProgramSummary));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNumberCommiment = new DevExpress.XtraEditors.TextEdit();
            this.chkCommiment = new System.Windows.Forms.CheckBox();
            this.txtNumberPO = new DevExpress.XtraEditors.TextEdit();
            this.chkNumberPO = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deIndcDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deIndcDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkIndcDate = new System.Windows.Forms.CheckBox();
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
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCommiment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateFrom.Properties)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1451, 27);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1451, 719);
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 65;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtNumberCommiment);
            this.groupControl1.Controls.Add(this.chkCommiment);
            this.groupControl1.Controls.Add(this.txtNumberPO);
            this.groupControl1.Controls.Add(this.chkNumberPO);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.deIndcDateTo);
            this.groupControl1.Controls.Add(this.deIndcDateFrom);
            this.groupControl1.Controls.Add(this.chkIndcDate);
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
            this.groupControl1.Size = new System.Drawing.Size(1451, 102);
            this.groupControl1.TabIndex = 27;
            this.groupControl1.Text = "Search Criteria";
            // 
            // txtNumberCommiment
            // 
            this.txtNumberCommiment.Location = new System.Drawing.Point(1175, 68);
            this.txtNumberCommiment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberCommiment.Name = "txtNumberCommiment";
            this.txtNumberCommiment.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCommiment.Properties.MaxLength = 20;
            this.txtNumberCommiment.Size = new System.Drawing.Size(184, 22);
            this.txtNumberCommiment.TabIndex = 74;
            this.txtNumberCommiment.ToolTip = "Numero de Documento de Compra";
            // 
            // chkCommiment
            // 
            this.chkCommiment.AutoSize = true;
            this.chkCommiment.Location = new System.Drawing.Point(1063, 68);
            this.chkCommiment.Name = "chkCommiment";
            this.chkCommiment.Size = new System.Drawing.Size(110, 21);
            this.chkCommiment.TabIndex = 73;
            this.chkCommiment.Text = "Commiment:";
            this.chkCommiment.UseVisualStyleBackColor = true;
            // 
            // txtNumberPO
            // 
            this.txtNumberPO.Location = new System.Drawing.Point(1175, 38);
            this.txtNumberPO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPO.Name = "txtNumberPO";
            this.txtNumberPO.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPO.Properties.Mask.EditMask = "f0";
            this.txtNumberPO.Properties.MaxLength = 20;
            this.txtNumberPO.Size = new System.Drawing.Size(184, 22);
            this.txtNumberPO.TabIndex = 72;
            this.txtNumberPO.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumberPO
            // 
            this.chkNumberPO.AutoSize = true;
            this.chkNumberPO.Location = new System.Drawing.Point(1119, 39);
            this.chkNumberPO.Name = "chkNumberPO";
            this.chkNumberPO.Size = new System.Drawing.Size(61, 21);
            this.chkNumberPO.TabIndex = 70;
            this.chkNumberPO.Text = "P.O.:";
            this.chkNumberPO.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(807, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "From";
            // 
            // deIndcDateTo
            // 
            this.deIndcDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deIndcDateTo.Location = new System.Drawing.Point(837, 65);
            this.deIndcDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deIndcDateTo.Name = "deIndcDateTo";
            this.deIndcDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIndcDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIndcDateTo.Size = new System.Drawing.Size(124, 22);
            this.deIndcDateTo.TabIndex = 67;
            // 
            // deIndcDateFrom
            // 
            this.deIndcDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deIndcDateFrom.Location = new System.Drawing.Point(677, 65);
            this.deIndcDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deIndcDateFrom.Name = "deIndcDateFrom";
            this.deIndcDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIndcDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIndcDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deIndcDateFrom.TabIndex = 66;
            // 
            // chkIndcDate
            // 
            this.chkIndcDate.AutoSize = true;
            this.chkIndcDate.Location = new System.Drawing.Point(548, 66);
            this.chkIndcDate.Name = "chkIndcDate";
            this.chkIndcDate.Size = new System.Drawing.Size(62, 21);
            this.chkIndcDate.TabIndex = 65;
            this.chkIndcDate.Text = "INDC";
            this.chkIndcDate.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(1365, 50);
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
            this.gcProgramProduction.Size = new System.Drawing.Size(1451, 611);
            this.gcProgramProduction.TabIndex = 66;
            this.gcProgramProduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProduction});
            // 
            // gvProgramProduction
            // 
            this.gvProgramProduction.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gvProgramProduction.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProduction.Appearance.FooterPanel.Options.UseFont = true;
            this.gvProgramProduction.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvProgramProduction.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gvProgramProduction.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProduction.Appearance.GroupFooter.Options.UseFont = true;
            this.gvProgramProduction.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvProgramProduction.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvProgramProduction.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProduction.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProgramProduction.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProgramProduction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1,
            this.gcColumna6,
            this.gcTotal});
            this.gvProgramProduction.GridControl = this.gcProgramProduction;
            this.gvProgramProduction.Name = "gvProgramProduction";
            this.gvProgramProduction.OptionsSelection.MultiSelect = true;
            this.gvProgramProduction.OptionsView.AllowCellMerge = true;
            this.gvProgramProduction.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProduction.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProduction.OptionsView.ShowGroupPanel = false;
            this.gvProgramProduction.OptionsView.ShowViewCaption = true;
            this.gvProgramProduction.ViewCaption = "LIST PRODUCTION PROGRAM SUMMARY";
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Style";
            this.gridColumn2.FieldName = "NameStyle";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Description";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 200;
            // 
            // gcColumna6
            // 
            this.gcColumna6.Caption = "Total Units";
            this.gcColumna6.DisplayFormat.FormatString = "#,0";
            this.gcColumna6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcColumna6.FieldName = "TotalUnits";
            this.gcColumna6.Name = "gcColumna6";
            this.gcColumna6.OptionsColumn.AllowEdit = false;
            this.gcColumna6.OptionsColumn.AllowFocus = false;
            this.gcColumna6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcColumna6.Visible = true;
            this.gcColumna6.VisibleIndex = 5;
            this.gcColumna6.Width = 100;
            // 
            // gcTotal
            // 
            this.gcTotal.Caption = "Total Amount US$";
            this.gcTotal.DisplayFormat.FormatString = "#,0.00";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "TotalAmount";
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.OptionsColumn.AllowEdit = false;
            this.gcTotal.OptionsColumn.AllowFocus = false;
            this.gcTotal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 6;
            this.gcTotal.Width = 160;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Vendor";
            this.gridColumn3.FieldName = "NameVendor";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 250;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "XfDate";
            this.gridColumn4.DisplayFormat.FormatString = "d";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "XfDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // frmConProductionProgramSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 746);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConProductionProgramSummary";
            this.Text = "frmConProductionProgramSummary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConProductionProgramSummary_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCommiment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIndcDateFrom.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtNumberCommiment;
        private System.Windows.Forms.CheckBox chkCommiment;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
        private System.Windows.Forms.CheckBox chkNumberPO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit deIndcDateTo;
        private DevExpress.XtraEditors.DateEdit deIndcDateFrom;
        private System.Windows.Forms.CheckBox chkIndcDate;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna6;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}