namespace ERP.Presentacion.Modulos.Production.Registros
{
    partial class frmRegCommiment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCommiment));
            this.tlbMenu = new ERP.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNumberCommiment = new DevExpress.XtraEditors.TextEdit();
            this.chkCommiment = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deContractShipDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deContractShipDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkContractShipDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deCommimentDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deCommimentDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.chkCommimentDate = new System.Windows.Forms.CheckBox();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcCommiment = new DevExpress.XtraGrid.GridControl();
            this.gvCommiment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducionProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCommimentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContractShipDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRevisionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTypeProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCommiment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCommiment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommiment)).BeginInit();
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
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcCommiment);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1451, 716);
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 31;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtNumberCommiment);
            this.groupControl1.Controls.Add(this.chkCommiment);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.deContractShipDateTo);
            this.groupControl1.Controls.Add(this.deContractShipDateFrom);
            this.groupControl1.Controls.Add(this.chkContractShipDate);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.deCommimentDateTo);
            this.groupControl1.Controls.Add(this.deCommimentDateFrom);
            this.groupControl1.Controls.Add(this.chkCommimentDate);
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
            this.txtNumberCommiment.Location = new System.Drawing.Point(659, 67);
            this.txtNumberCommiment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberCommiment.Name = "txtNumberCommiment";
            this.txtNumberCommiment.Properties.DisplayFormat.FormatString = "f0";
            this.txtNumberCommiment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumberCommiment.Properties.Mask.EditMask = "f0";
            this.txtNumberCommiment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumberCommiment.Properties.MaxLength = 10;
            this.txtNumberCommiment.Size = new System.Drawing.Size(184, 22);
            this.txtNumberCommiment.TabIndex = 74;
            this.txtNumberCommiment.ToolTip = "Numero de Documento de Compra";
            // 
            // chkCommiment
            // 
            this.chkCommiment.AutoSize = true;
            this.chkCommiment.Location = new System.Drawing.Point(547, 67);
            this.chkCommiment.Name = "chkCommiment";
            this.chkCommiment.Size = new System.Drawing.Size(110, 21);
            this.chkCommiment.TabIndex = 73;
            this.chkCommiment.Text = "Commiment:";
            this.chkCommiment.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "From";
            // 
            // deContractShipDateTo
            // 
            this.deContractShipDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deContractShipDateTo.Location = new System.Drawing.Point(377, 66);
            this.deContractShipDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deContractShipDateTo.Name = "deContractShipDateTo";
            this.deContractShipDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deContractShipDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deContractShipDateTo.Size = new System.Drawing.Size(124, 22);
            this.deContractShipDateTo.TabIndex = 67;
            // 
            // deContractShipDateFrom
            // 
            this.deContractShipDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deContractShipDateFrom.Location = new System.Drawing.Point(217, 66);
            this.deContractShipDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deContractShipDateFrom.Name = "deContractShipDateFrom";
            this.deContractShipDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deContractShipDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deContractShipDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deContractShipDateFrom.TabIndex = 66;
            // 
            // chkContractShipDate
            // 
            this.chkContractShipDate.AutoSize = true;
            this.chkContractShipDate.Location = new System.Drawing.Point(22, 68);
            this.chkContractShipDate.Name = "chkContractShipDate";
            this.chkContractShipDate.Size = new System.Drawing.Size(147, 21);
            this.chkContractShipDate.TabIndex = 65;
            this.chkContractShipDate.Text = "Contract Ship Date";
            this.chkContractShipDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(860, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "From";
            // 
            // deCommimentDateTo
            // 
            this.deCommimentDateTo.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deCommimentDateTo.Location = new System.Drawing.Point(890, 36);
            this.deCommimentDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deCommimentDateTo.Name = "deCommimentDateTo";
            this.deCommimentDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCommimentDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCommimentDateTo.Size = new System.Drawing.Size(124, 22);
            this.deCommimentDateTo.TabIndex = 62;
            // 
            // deCommimentDateFrom
            // 
            this.deCommimentDateFrom.EditValue = new System.DateTime(2017, 11, 13, 0, 0, 0, 0);
            this.deCommimentDateFrom.Location = new System.Drawing.Point(730, 36);
            this.deCommimentDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deCommimentDateFrom.Name = "deCommimentDateFrom";
            this.deCommimentDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCommimentDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCommimentDateFrom.Size = new System.Drawing.Size(124, 22);
            this.deCommimentDateFrom.TabIndex = 60;
            // 
            // chkCommimentDate
            // 
            this.chkCommimentDate.AutoSize = true;
            this.chkCommimentDate.Location = new System.Drawing.Point(547, 37);
            this.chkCommimentDate.Name = "chkCommimentDate";
            this.chkCommimentDate.Size = new System.Drawing.Size(138, 21);
            this.chkCommimentDate.TabIndex = 36;
            this.chkCommimentDate.Text = "Commiment Date";
            this.chkCommimentDate.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(1033, 62);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 26);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Find";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcCommiment
            // 
            this.gcCommiment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCommiment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcCommiment.Location = new System.Drawing.Point(0, 0);
            this.gcCommiment.MainView = this.gvCommiment;
            this.gcCommiment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcCommiment.Name = "gcCommiment";
            this.gcCommiment.Size = new System.Drawing.Size(1451, 608);
            this.gcCommiment.TabIndex = 66;
            this.gcCommiment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCommiment});
            // 
            // gvCommiment
            // 
            this.gvCommiment.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvCommiment.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvCommiment.Appearance.ViewCaption.Options.UseFont = true;
            this.gvCommiment.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvCommiment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gcProducionProgram,
            this.gridColumn11,
            this.gcCommimentDate,
            this.gcContractShipDate,
            this.gcRevisionDate,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn10,
            this.gcTypeProduct,
            this.gridColumn5,
            this.gridColumn2});
            this.gvCommiment.GridControl = this.gcCommiment;
            this.gvCommiment.Name = "gvCommiment";
            this.gvCommiment.OptionsSelection.MultiSelect = true;
            this.gvCommiment.OptionsView.AllowCellMerge = true;
            this.gvCommiment.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvCommiment.OptionsView.ColumnAutoWidth = false;
            this.gvCommiment.OptionsView.ShowGroupPanel = false;
            this.gvCommiment.OptionsView.ShowViewCaption = true;
            this.gvCommiment.ViewCaption = "LIST COMMIMENT\'S";
            this.gvCommiment.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvCommiment_RowCellStyle);
            this.gvCommiment.DoubleClick += new System.EventHandler(this.gvCommiment_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdCommiment";
            this.gridColumn3.FieldName = "IdCommiment";
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
            this.gcProducionProgram.Caption = "N° Commiment";
            this.gcProducionProgram.FieldName = "NumberCommiment";
            this.gcProducionProgram.Name = "gcProducionProgram";
            this.gcProducionProgram.OptionsColumn.AllowEdit = false;
            this.gcProducionProgram.OptionsColumn.AllowFocus = false;
            this.gcProducionProgram.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gcProducionProgram.Visible = true;
            this.gcProducionProgram.VisibleIndex = 0;
            this.gcProducionProgram.Width = 100;
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
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 250;
            // 
            // gcCommimentDate
            // 
            this.gcCommimentDate.Caption = "Commiment Date";
            this.gcCommimentDate.FieldName = "CommimentDate";
            this.gcCommimentDate.Name = "gcCommimentDate";
            this.gcCommimentDate.OptionsColumn.AllowEdit = false;
            this.gcCommimentDate.OptionsColumn.AllowFocus = false;
            this.gcCommimentDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcCommimentDate.Visible = true;
            this.gcCommimentDate.VisibleIndex = 2;
            this.gcCommimentDate.Width = 90;
            // 
            // gcContractShipDate
            // 
            this.gcContractShipDate.Caption = "Contract Ship Date";
            this.gcContractShipDate.FieldName = "ContractShipDate";
            this.gcContractShipDate.Name = "gcContractShipDate";
            this.gcContractShipDate.OptionsColumn.AllowEdit = false;
            this.gcContractShipDate.OptionsColumn.AllowFocus = false;
            this.gcContractShipDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcContractShipDate.Visible = true;
            this.gcContractShipDate.VisibleIndex = 3;
            this.gcContractShipDate.Width = 90;
            // 
            // gcRevisionDate
            // 
            this.gcRevisionDate.Caption = "Revision Date";
            this.gcRevisionDate.FieldName = "RevisionDate";
            this.gcRevisionDate.Name = "gcRevisionDate";
            this.gcRevisionDate.OptionsColumn.AllowEdit = false;
            this.gcRevisionDate.OptionsColumn.AllowFocus = false;
            this.gcRevisionDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcRevisionDate.Visible = true;
            this.gcRevisionDate.VisibleIndex = 4;
            this.gcRevisionDate.Width = 90;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "N° Revision";
            this.gridColumn8.FieldName = "NumberRevision";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Origin";
            this.gridColumn6.FieldName = "NameOrigen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 150;
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
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 150;
            // 
            // gcTypeProduct
            // 
            this.gcTypeProduct.Caption = "Currency";
            this.gcTypeProduct.FieldName = "NameCurrency";
            this.gcTypeProduct.Name = "gcTypeProduct";
            this.gcTypeProduct.OptionsColumn.AllowEdit = false;
            this.gcTypeProduct.OptionsColumn.AllowFocus = false;
            this.gcTypeProduct.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcTypeProduct.Visible = true;
            this.gcTypeProduct.VisibleIndex = 8;
            this.gcTypeProduct.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Freight Paid";
            this.gridColumn5.FieldName = "FreightPaid";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Addionational";
            this.gridColumn2.FieldName = "Addionational";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            this.gridColumn2.Width = 300;
            // 
            // frmRegCommiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 746);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegCommiment";
            this.Text = "frmRegCommiment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegCommiment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberCommiment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractShipDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCommimentDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCommiment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommiment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNumberCommiment;
        private System.Windows.Forms.CheckBox chkCommiment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit deContractShipDateTo;
        private DevExpress.XtraEditors.DateEdit deContractShipDateFrom;
        private System.Windows.Forms.CheckBox chkContractShipDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deCommimentDateTo;
        private DevExpress.XtraEditors.DateEdit deCommimentDateFrom;
        private System.Windows.Forms.CheckBox chkCommimentDate;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private System.Windows.Forms.CheckBox chkClient;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcCommiment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCommiment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gcProducionProgram;
        private DevExpress.XtraGrid.Columns.GridColumn gcCommimentDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gcRevisionDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcTypeProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcContractShipDate;
    }
}