namespace ERP.Presentacion.Modulos.Invoices.Registros
{
    partial class frmRegInspectionCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInspectionCertificate));
            this.tlbMenu = new ERP.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNumberOI = new DevExpress.XtraEditors.TextEdit();
            this.chkNumberOI = new System.Windows.Forms.CheckBox();
            this.txtNumberPO = new DevExpress.XtraEditors.TextEdit();
            this.chkNumberPO = new System.Windows.Forms.CheckBox();
            this.txtNumberCertificate = new DevExpress.XtraEditors.TextEdit();
            this.chkNumberCertificate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deIssueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deIssueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkIssueDate = new System.Windows.Forms.CheckBox();
            this.cboStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcInspectionCertificate = new DevExpress.XtraGrid.GridControl();
            this.gvInspectionCertificate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspectionCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionCertificate)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1451, 30);
            this.tlbMenu.TabIndex = 30;
            this.tlbMenu.NewClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ERP.Presentacion.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ERP.Presentacion.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcInspectionCertificate);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1451, 716);
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 31;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtNumberOI);
            this.groupControl1.Controls.Add(this.chkNumberOI);
            this.groupControl1.Controls.Add(this.txtNumberPO);
            this.groupControl1.Controls.Add(this.chkNumberPO);
            this.groupControl1.Controls.Add(this.txtNumberCertificate);
            this.groupControl1.Controls.Add(this.chkNumberCertificate);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.deIssueDateTo);
            this.groupControl1.Controls.Add(this.deIssueDateFrom);
            this.groupControl1.Controls.Add(this.chkIssueDate);
            this.groupControl1.Controls.Add(this.cboStatus);
            this.groupControl1.Controls.Add(this.chkStatus);
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
            // txtNumberOI
            // 
            this.txtNumberOI.Location = new System.Drawing.Point(1026, 66);
            this.txtNumberOI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberOI.Name = "txtNumberOI";
            this.txtNumberOI.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberOI.Properties.Mask.EditMask = "f0";
            this.txtNumberOI.Properties.MaxLength = 20;
            this.txtNumberOI.Size = new System.Drawing.Size(184, 22);
            this.txtNumberOI.TabIndex = 76;
            this.txtNumberOI.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumberOI
            // 
            this.chkNumberOI.AutoSize = true;
            this.chkNumberOI.Location = new System.Drawing.Point(923, 67);
            this.chkNumberOI.Name = "chkNumberOI";
            this.chkNumberOI.Size = new System.Drawing.Size(54, 21);
            this.chkNumberOI.TabIndex = 75;
            this.chkNumberOI.Text = "O/I:";
            this.chkNumberOI.UseVisualStyleBackColor = true;
            // 
            // txtNumberPO
            // 
            this.txtNumberPO.Location = new System.Drawing.Point(627, 66);
            this.txtNumberPO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPO.Name = "txtNumberPO";
            this.txtNumberPO.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPO.Properties.Mask.EditMask = "f0";
            this.txtNumberPO.Properties.MaxLength = 20;
            this.txtNumberPO.Size = new System.Drawing.Size(184, 22);
            this.txtNumberPO.TabIndex = 74;
            this.txtNumberPO.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumberPO
            // 
            this.chkNumberPO.AutoSize = true;
            this.chkNumberPO.Location = new System.Drawing.Point(547, 67);
            this.chkNumberPO.Name = "chkNumberPO";
            this.chkNumberPO.Size = new System.Drawing.Size(61, 21);
            this.chkNumberPO.TabIndex = 73;
            this.chkNumberPO.Text = "P.O.:";
            this.chkNumberPO.UseVisualStyleBackColor = true;
            // 
            // txtNumberCertificate
            // 
            this.txtNumberCertificate.Location = new System.Drawing.Point(1026, 35);
            this.txtNumberCertificate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberCertificate.Name = "txtNumberCertificate";
            this.txtNumberCertificate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCertificate.Properties.Mask.EditMask = "f0";
            this.txtNumberCertificate.Properties.MaxLength = 20;
            this.txtNumberCertificate.Size = new System.Drawing.Size(184, 22);
            this.txtNumberCertificate.TabIndex = 72;
            this.txtNumberCertificate.ToolTip = "Numero de Documento de Compra";
            // 
            // chkNumberCertificate
            // 
            this.chkNumberCertificate.AutoSize = true;
            this.chkNumberCertificate.Location = new System.Drawing.Point(922, 37);
            this.chkNumberCertificate.Name = "chkNumberCertificate";
            this.chkNumberCertificate.Size = new System.Drawing.Size(95, 21);
            this.chkNumberCertificate.TabIndex = 70;
            this.chkNumberCertificate.Text = "Certificate:";
            this.chkNumberCertificate.UseVisualStyleBackColor = true;
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
            // deIssueDateTo
            // 
            this.deIssueDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deIssueDateTo.Location = new System.Drawing.Point(336, 66);
            this.deIssueDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deIssueDateTo.Name = "deIssueDateTo";
            this.deIssueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIssueDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIssueDateTo.Size = new System.Drawing.Size(124, 22);
            this.deIssueDateTo.TabIndex = 62;
            // 
            // deIssueDateFrom
            // 
            this.deIssueDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deIssueDateFrom.Location = new System.Drawing.Point(176, 66);
            this.deIssueDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deIssueDateFrom.Name = "deIssueDateFrom";
            this.deIssueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deIssueDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deIssueDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deIssueDateFrom.TabIndex = 60;
            // 
            // chkIssueDate
            // 
            this.chkIssueDate.AutoSize = true;
            this.chkIssueDate.Location = new System.Drawing.Point(22, 67);
            this.chkIssueDate.Name = "chkIssueDate";
            this.chkIssueDate.Size = new System.Drawing.Size(99, 21);
            this.chkIssueDate.TabIndex = 36;
            this.chkIssueDate.Text = "Issue Date:";
            this.chkIssueDate.UseVisualStyleBackColor = true;
            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(627, 36);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Size = new System.Drawing.Size(279, 22);
            this.cboStatus.TabIndex = 35;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(547, 37);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(74, 21);
            this.chkStatus.TabIndex = 34;
            this.chkStatus.Text = "Status:";
            this.chkStatus.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(1216, 48);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcInspectionCertificate
            // 
            this.gcInspectionCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInspectionCertificate.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspectionCertificate.Location = new System.Drawing.Point(0, 0);
            this.gcInspectionCertificate.MainView = this.gvInspectionCertificate;
            this.gcInspectionCertificate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspectionCertificate.Name = "gcInspectionCertificate";
            this.gcInspectionCertificate.Size = new System.Drawing.Size(1451, 608);
            this.gcInspectionCertificate.TabIndex = 66;
            this.gcInspectionCertificate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInspectionCertificate});
            // 
            // gvInspectionCertificate
            // 
            this.gvInspectionCertificate.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvInspectionCertificate.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvInspectionCertificate.Appearance.ViewCaption.Options.UseFont = true;
            this.gvInspectionCertificate.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvInspectionCertificate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gcXfDate,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn6,
            this.gcColumna6,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn1});
            this.gvInspectionCertificate.GridControl = this.gcInspectionCertificate;
            this.gvInspectionCertificate.Name = "gvInspectionCertificate";
            this.gvInspectionCertificate.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gvInspectionCertificate.OptionsSelection.MultiSelect = true;
            this.gvInspectionCertificate.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvInspectionCertificate.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvInspectionCertificate.OptionsView.ColumnAutoWidth = false;
            this.gvInspectionCertificate.OptionsView.ShowGroupPanel = false;
            this.gvInspectionCertificate.OptionsView.ShowViewCaption = true;
            this.gvInspectionCertificate.ViewCaption = "LIST INSPECTION CERTIFICATE";
            this.gvInspectionCertificate.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvInspectionCertificate_RowCellStyle);
            this.gvInspectionCertificate.DoubleClick += new System.EventHandler(this.gvInspectionCertificate_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdInspectionCertificate";
            this.gridColumn3.FieldName = "IdInspectionCertificate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.DarkViolet;
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "Certificate";
            this.gridColumn5.FieldName = "NumberCertificate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 120;
            // 
            // gcXfDate
            // 
            this.gcXfDate.Caption = "Issue Date";
            this.gcXfDate.DisplayFormat.FormatString = "d";
            this.gcXfDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcXfDate.FieldName = "IssueDate";
            this.gcXfDate.Name = "gcXfDate";
            this.gcXfDate.OptionsColumn.AllowEdit = false;
            this.gcXfDate.OptionsColumn.AllowFocus = false;
            this.gcXfDate.Visible = true;
            this.gcXfDate.VisibleIndex = 2;
            this.gcXfDate.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "P.O";
            this.gridColumn11.FieldName = "NumberPO";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 300;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "O/I";
            this.gridColumn8.FieldName = "NumberOI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vendor";
            this.gridColumn4.FieldName = "NameVendor";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Invoice";
            this.gridColumn6.FieldName = "NumberInvoice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 150;
            // 
            // gcColumna6
            // 
            this.gcColumna6.Caption = "Amount";
            this.gcColumna6.DisplayFormat.FormatString = "#,0.00";
            this.gcColumna6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcColumna6.FieldName = "Amount";
            this.gcColumna6.Name = "gcColumna6";
            this.gcColumna6.OptionsColumn.AllowEdit = false;
            this.gcColumna6.OptionsColumn.AllowFocus = false;
            this.gcColumna6.Visible = true;
            this.gcColumna6.VisibleIndex = 7;
            this.gcColumna6.Width = 120;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Type Shipping";
            this.gridColumn7.FieldName = "NameTypeShipping";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdStatus";
            this.gridColumn2.FieldName = "IdStatus";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Status";
            this.gridColumn1.FieldName = "NameStatus";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 90;
            // 
            // frmRegInspectionCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 746);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegInspectionCertificate";
            this.Text = "frmRegInspectionCertificate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCertificate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deIssueDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspectionCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionCertificate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNumberCertificate;
        private System.Windows.Forms.CheckBox chkNumberCertificate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deIssueDateTo;
        private DevExpress.XtraEditors.DateEdit deIssueDateFrom;
        private System.Windows.Forms.CheckBox chkIssueDate;
        public DevExpress.XtraEditors.LookUpEdit cboStatus;
        private System.Windows.Forms.CheckBox chkStatus;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private System.Windows.Forms.CheckBox chkClient;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcInspectionCertificate;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInspectionCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtNumberOI;
        private System.Windows.Forms.CheckBox chkNumberOI;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
        private System.Windows.Forms.CheckBox chkNumberPO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}