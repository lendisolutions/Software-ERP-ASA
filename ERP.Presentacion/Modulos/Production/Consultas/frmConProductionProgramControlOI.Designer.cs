namespace ERP.Presentacion.Modulos.Production.Consultas
{
    partial class frmConProductionProgramControlOI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProductionProgramControlOI));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.chkDivision = new System.Windows.Forms.CheckBox();
            this.btnBusStyle = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtNameStyle = new DevExpress.XtraEditors.TextEdit();
            this.chkStyle = new System.Windows.Forms.CheckBox();
            this.txtNumberPO = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroOI = new DevExpress.XtraEditors.TextEdit();
            this.chkNumeroOI = new System.Windows.Forms.CheckBox();
            this.chkNumberPO = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcProgramProductionAudit = new DevExpress.XtraGrid.GridControl();
            this.mnuContextualPorgramProductionDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuProgramProductionAudittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProgramProductionAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAuditDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFileBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGarmentBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroOI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionAudit)).BeginInit();
            this.mnuContextualPorgramProductionDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionAudit)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1514, 27);
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcProgramProductionAudit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1514, 626);
            this.splitContainerControl1.SplitterPosition = 99;
            this.splitContainerControl1.TabIndex = 65;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboDivision);
            this.groupControl1.Controls.Add(this.chkDivision);
            this.groupControl1.Controls.Add(this.btnBusStyle);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.txtNameStyle);
            this.groupControl1.Controls.Add(this.chkStyle);
            this.groupControl1.Controls.Add(this.txtNumberPO);
            this.groupControl1.Controls.Add(this.txtNumeroOI);
            this.groupControl1.Controls.Add(this.chkNumeroOI);
            this.groupControl1.Controls.Add(this.chkNumberPO);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.deDateTo);
            this.groupControl1.Controls.Add(this.deDateFrom);
            this.groupControl1.Controls.Add(this.chkDate);
            this.groupControl1.Controls.Add(this.cboClient);
            this.groupControl1.Controls.Add(this.chkClient);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1514, 99);
            this.groupControl1.TabIndex = 27;
            this.groupControl1.Text = "Search Criteria";
            // 
            // cboDivision
            // 
            this.cboDivision.Location = new System.Drawing.Point(636, 36);
            this.cboDivision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDivision.Properties.NullText = "";
            this.cboDivision.Size = new System.Drawing.Size(331, 22);
            this.cboDivision.TabIndex = 81;
            // 
            // chkDivision
            // 
            this.chkDivision.AutoSize = true;
            this.chkDivision.Location = new System.Drawing.Point(549, 37);
            this.chkDivision.Name = "chkDivision";
            this.chkDivision.Size = new System.Drawing.Size(81, 21);
            this.chkDivision.TabIndex = 80;
            this.chkDivision.Text = "Division:";
            this.chkDivision.UseVisualStyleBackColor = true;
            // 
            // btnBusStyle
            // 
            this.btnBusStyle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBusStyle.ImageOptions.Image")));
            this.btnBusStyle.Location = new System.Drawing.Point(1128, 64);
            this.btnBusStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBusStyle.Name = "btnBusStyle";
            this.btnBusStyle.Size = new System.Drawing.Size(28, 26);
            this.btnBusStyle.TabIndex = 79;
            this.btnBusStyle.Click += new System.EventHandler(this.btnBusStyle_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(769, 66);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.DisplayFormat.FormatString = "f0";
            this.txtDescription.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescription.Size = new System.Drawing.Size(353, 22);
            this.txtDescription.TabIndex = 78;
            this.txtDescription.ToolTip = "Numero de Documento de Compra";
            // 
            // txtNameStyle
            // 
            this.txtNameStyle.Location = new System.Drawing.Point(636, 66);
            this.txtNameStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameStyle.Name = "txtNameStyle";
            this.txtNameStyle.Properties.DisplayFormat.FormatString = "f0";
            this.txtNameStyle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNameStyle.Size = new System.Drawing.Size(127, 22);
            this.txtNameStyle.TabIndex = 77;
            this.txtNameStyle.ToolTip = "Numero de Documento de Compra";
            // 
            // chkStyle
            // 
            this.chkStyle.AutoSize = true;
            this.chkStyle.Location = new System.Drawing.Point(549, 68);
            this.chkStyle.Name = "chkStyle";
            this.chkStyle.Size = new System.Drawing.Size(65, 21);
            this.chkStyle.TabIndex = 76;
            this.chkStyle.Text = "Style:";
            this.chkStyle.UseVisualStyleBackColor = true;
            this.chkStyle.CheckedChanged += new System.EventHandler(this.chkStyle_CheckedChanged);
            // 
            // txtNumberPO
            // 
            this.txtNumberPO.Location = new System.Drawing.Point(1027, 35);
            this.txtNumberPO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPO.Name = "txtNumberPO";
            this.txtNumberPO.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPO.Properties.MaxLength = 20;
            this.txtNumberPO.Size = new System.Drawing.Size(138, 22);
            this.txtNumberPO.TabIndex = 75;
            this.txtNumberPO.ToolTip = "Numero de Documento de Compra";
            // 
            // txtNumeroOI
            // 
            this.txtNumeroOI.Location = new System.Drawing.Point(1227, 36);
            this.txtNumeroOI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroOI.Name = "txtNumeroOI";
            this.txtNumeroOI.Properties.DisplayFormat.FormatString = "f0";
            this.txtNumeroOI.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumeroOI.Properties.MaxLength = 10;
            this.txtNumeroOI.Size = new System.Drawing.Size(127, 22);
            this.txtNumeroOI.TabIndex = 74;
            this.txtNumeroOI.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumeroOI
            // 
            this.chkNumeroOI.AutoSize = true;
            this.chkNumeroOI.Location = new System.Drawing.Point(1171, 37);
            this.chkNumeroOI.Name = "chkNumeroOI";
            this.chkNumeroOI.Size = new System.Drawing.Size(58, 21);
            this.chkNumeroOI.TabIndex = 73;
            this.chkNumeroOI.Text = "O/I :";
            this.chkNumeroOI.UseVisualStyleBackColor = true;
            // 
            // chkNumberPO
            // 
            this.chkNumberPO.AutoSize = true;
            this.chkNumberPO.Location = new System.Drawing.Point(973, 36);
            this.chkNumberPO.Name = "chkNumberPO";
            this.chkNumberPO.Size = new System.Drawing.Size(61, 21);
            this.chkNumberPO.TabIndex = 70;
            this.chkNumberPO.Text = "P.O.:";
            this.chkNumberPO.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deDateTo.Location = new System.Drawing.Point(288, 67);
            this.deDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDateTo.Size = new System.Drawing.Size(124, 22);
            this.deDateTo.TabIndex = 62;
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deDateFrom.Location = new System.Drawing.Point(128, 67);
            this.deDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deDateFrom.TabIndex = 60;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(21, 68);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(59, 21);
            this.chkDate.TabIndex = 36;
            this.chkDate.Text = "Date";
            this.chkDate.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(1360, 33);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcProgramProductionAudit
            // 
            this.gcProgramProductionAudit.ContextMenuStrip = this.mnuContextualPorgramProductionDetail;
            this.gcProgramProductionAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProgramProductionAudit.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionAudit.Location = new System.Drawing.Point(0, 0);
            this.gcProgramProductionAudit.MainView = this.gvProgramProductionAudit;
            this.gcProgramProductionAudit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProductionAudit.Name = "gcProgramProductionAudit";
            this.gcProgramProductionAudit.Size = new System.Drawing.Size(1514, 521);
            this.gcProgramProductionAudit.TabIndex = 67;
            this.gcProgramProductionAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProductionAudit});
            // 
            // mnuContextualPorgramProductionDetail
            // 
            this.mnuContextualPorgramProductionDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualPorgramProductionDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProgramProductionAudittoolStripMenuItem});
            this.mnuContextualPorgramProductionDetail.Name = "contextMenuStrip1";
            this.mnuContextualPorgramProductionDetail.Size = new System.Drawing.Size(172, 30);
            // 
            // mnuProgramProductionAudittoolStripMenuItem
            // 
            this.mnuProgramProductionAudittoolStripMenuItem.Image = global::ERP.Presentacion.Properties.Resources.Auditoria2_16x16;
            this.mnuProgramProductionAudittoolStripMenuItem.Name = "mnuProgramProductionAudittoolStripMenuItem";
            this.mnuProgramProductionAudittoolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.mnuProgramProductionAudittoolStripMenuItem.Text = "Control Audit";
            this.mnuProgramProductionAudittoolStripMenuItem.Click += new System.EventHandler(this.mnuProgramProductionAudittoolStripMenuItem_Click);
            // 
            // gvProgramProductionAudit
            // 
            this.gvProgramProductionAudit.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvProgramProductionAudit.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProgramProductionAudit.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProgramProductionAudit.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProgramProductionAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gcAuditDate,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn5,
            this.gcColumna5,
            this.gridColumn3,
            this.gridColumn8,
            this.gcXfDate,
            this.gridColumn6,
            this.gridColumn14,
            this.gridColumn2,
            this.gcFileBox,
            this.gcGarmentBox});
            this.gvProgramProductionAudit.GridControl = this.gcProgramProductionAudit;
            this.gvProgramProductionAudit.Name = "gvProgramProductionAudit";
            this.gvProgramProductionAudit.OptionsSelection.MultiSelect = true;
            this.gvProgramProductionAudit.OptionsView.AllowCellMerge = true;
            this.gvProgramProductionAudit.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProgramProductionAudit.OptionsView.ColumnAutoWidth = false;
            this.gvProgramProductionAudit.OptionsView.ShowGroupPanel = false;
            this.gvProgramProductionAudit.OptionsView.ShowViewCaption = true;
            this.gvProgramProductionAudit.ViewCaption = "LIST CONTROL O/I";
            this.gvProgramProductionAudit.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProgramProductionAudit_RowCellStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdProgramProductionAudit";
            this.gridColumn1.FieldName = "IdProgramProductionAudit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gcAuditDate
            // 
            this.gcAuditDate.Caption = "Date";
            this.gcAuditDate.DisplayFormat.FormatString = "d";
            this.gcAuditDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcAuditDate.FieldName = "AuditDate";
            this.gcAuditDate.Name = "gcAuditDate";
            this.gcAuditDate.OptionsColumn.AllowEdit = false;
            this.gcAuditDate.OptionsColumn.AllowFocus = false;
            this.gcAuditDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcAuditDate.Visible = true;
            this.gcAuditDate.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.Caption = "O/I";
            this.gridColumn12.FieldName = "NumeroOI";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 80;
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
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 250;
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
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "P.O.";
            this.gridColumn5.FieldName = "NumberPO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
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
            this.gcColumna5.Width = 80;
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
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 250;
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
            this.gcXfDate.VisibleIndex = 8;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.Navy;
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.Caption = "Send Date";
            this.gridColumn6.DisplayFormat.FormatString = "d";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "SendDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            this.gridColumn6.Width = 90;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn14.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn14.Caption = "Return Date";
            this.gridColumn14.DisplayFormat.FormatString = "d";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn14.FieldName = "ReturnDate";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 10;
            this.gridColumn14.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Comment";
            this.gridColumn2.FieldName = "Comment";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            this.gridColumn2.Width = 200;
            // 
            // gcFileBox
            // 
            this.gcFileBox.Caption = "N° File Box";
            this.gcFileBox.FieldName = "FileBox";
            this.gcFileBox.Name = "gcFileBox";
            this.gcFileBox.OptionsColumn.AllowEdit = false;
            this.gcFileBox.OptionsColumn.AllowFocus = false;
            this.gcFileBox.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcFileBox.Visible = true;
            this.gcFileBox.VisibleIndex = 12;
            this.gcFileBox.Width = 100;
            // 
            // gcGarmentBox
            // 
            this.gcGarmentBox.Caption = "N° Garment Box";
            this.gcGarmentBox.FieldName = "GarmentBox";
            this.gcGarmentBox.Name = "gcGarmentBox";
            this.gcGarmentBox.OptionsColumn.AllowEdit = false;
            this.gcGarmentBox.OptionsColumn.AllowFocus = false;
            this.gcGarmentBox.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcGarmentBox.Visible = true;
            this.gcGarmentBox.VisibleIndex = 13;
            this.gcGarmentBox.Width = 115;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Item";
            this.gridColumn3.FieldName = "Item";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 150;
            // 
            // frmConProductionProgramControlOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 653);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConProductionProgramControlOI";
            this.Text = "Consulting Production Program Control O/I";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConProductionProgramControlOI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroOI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProgramProductionAudit)).EndInit();
            this.mnuContextualPorgramProductionDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProductionAudit)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit deDateTo;
        private DevExpress.XtraEditors.DateEdit deDateFrom;
        private System.Windows.Forms.CheckBox chkDate;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private System.Windows.Forms.CheckBox chkClient;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcProgramProductionAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProductionAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcFileBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gcGarmentBox;
        private DevExpress.XtraGrid.Columns.GridColumn gcAuditDate;
        private DevExpress.XtraEditors.TextEdit txtNumeroOI;
        private System.Windows.Forms.CheckBox chkNumeroOI;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
        private System.Windows.Forms.CheckBox chkStyle;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtNameStyle;
        private DevExpress.XtraEditors.SimpleButton btnBusStyle;
        public DevExpress.XtraEditors.LookUpEdit cboDivision;
        private System.Windows.Forms.CheckBox chkDivision;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public System.Windows.Forms.ContextMenuStrip mnuContextualPorgramProductionDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuProgramProductionAudittoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}