namespace ERP.Presentacion.Modulos.Production.Registros
{
    partial class frmRegProductionProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegProductionProgram));
            this.tlbMenu = new ERP.Presentacion.ControlUser.UIToolBar();
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
            this.mnuContextualPorgramProduction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gvProgramProduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcXfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnits = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColumna6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTypeProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.mnuContextualPorgramProduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProduction)).BeginInit();
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
            this.tlbMenu.TabIndex = 29;
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
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcProgramProduction);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1451, 716);
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 30;
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
            this.deRevenueDateTo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deRevenueDateTo_MouseMove);
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
            this.deRevenueDateFrom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deRevenueDateFrom_MouseMove);
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
            this.gcProgramProduction.ContextMenuStrip = this.mnuContextualPorgramProduction;
            this.gcProgramProduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProgramProduction.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProduction.Location = new System.Drawing.Point(0, 0);
            this.gcProgramProduction.MainView = this.gvProgramProduction;
            this.gcProgramProduction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProgramProduction.Name = "gcProgramProduction";
            this.gcProgramProduction.Size = new System.Drawing.Size(1451, 608);
            this.gcProgramProduction.TabIndex = 66;
            this.gcProgramProduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProgramProduction});
            // 
            // mnuContextualPorgramProduction
            // 
            this.mnuContextualPorgramProduction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualPorgramProduction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCopyToolStripMenuItem,
            this.toolStripSeparator1});
            this.mnuContextualPorgramProduction.Name = "contextMenuStrip1";
            this.mnuContextualPorgramProduction.Size = new System.Drawing.Size(127, 36);
            // 
            // nuevoCopyToolStripMenuItem
            // 
            this.nuevoCopyToolStripMenuItem.Image = global::ERP.Presentacion.Properties.Resources.Copy_16x16;
            this.nuevoCopyToolStripMenuItem.Name = "nuevoCopyToolStripMenuItem";
            this.nuevoCopyToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.nuevoCopyToolStripMenuItem.Text = "Copiar";
            this.nuevoCopyToolStripMenuItem.Click += new System.EventHandler(this.nuevoCopyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
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
            this.gridColumn3,
            this.gridColumn5,
            this.gcXfDate,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn15,
            this.gridColumn14,
            this.gridColumn13,
            this.gcUnits,
            this.gcColumna6,
            this.gcTotal,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn9,
            this.gcTypeProduct,
            this.gcIndcDate,
            this.gridColumn7});
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
            this.gvProgramProduction.DoubleClick += new System.EventHandler(this.gvProgramProduction_DoubleClick);
            this.gvProgramProduction.Layout += new System.EventHandler(this.gvProgramProduction_Layout);
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
            this.gridColumn12.Width = 130;
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
            this.gridColumn6.Width = 170;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Dyelot";
            this.gridColumn15.FieldName = "Dyelot";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
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
            this.gridColumn14.Width = 90;
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
            this.gridColumn13.Width = 180;
            // 
            // gcUnits
            // 
            this.gcUnits.Caption = "Units";
            this.gcUnits.DisplayFormat.FormatString = "#,0";
            this.gcUnits.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcUnits.FieldName = "Units";
            this.gcUnits.Name = "gcUnits";
            this.gcUnits.OptionsColumn.AllowEdit = false;
            this.gcUnits.OptionsColumn.AllowFocus = false;
            this.gcUnits.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcUnits.Visible = true;
            this.gcUnits.VisibleIndex = 8;
            this.gcUnits.Width = 130;
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
            // gcTotal
            // 
            this.gcTotal.Caption = "Total";
            this.gcTotal.DisplayFormat.FormatString = "#,0.00";
            this.gcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal.FieldName = "Total";
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.OptionsColumn.AllowEdit = false;
            this.gcTotal.OptionsColumn.AllowFocus = false;
            this.gcTotal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gcTotal.Visible = true;
            this.gcTotal.VisibleIndex = 10;
            this.gcTotal.Width = 160;
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
            // frmRegProductionProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 746);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegProductionProgram";
            this.Text = "frmRegProductionProgram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegProductionProgram_FormClosing);
            this.Load += new System.EventHandler(this.frmRegProductionProgram_Load);
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
            this.mnuContextualPorgramProduction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProgramProduction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcProgramProduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgramProduction;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gcXfDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnits;
        private DevExpress.XtraGrid.Columns.GridColumn gcColumna6;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.CheckBox chkDivision;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        public DevExpress.XtraEditors.LookUpEdit cboDivision;
        private DevExpress.XtraEditors.DateEdit deRevenueDateTo;
        private DevExpress.XtraEditors.DateEdit deRevenueDateFrom;
        private System.Windows.Forms.CheckBox chkXfDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit deIndcDateTo;
        private DevExpress.XtraEditors.DateEdit deIndcDateFrom;
        private System.Windows.Forms.CheckBox chkIndcDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtNumberPO;
        private System.Windows.Forms.CheckBox chkNumberPO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndcDate;
        private DevExpress.XtraEditors.TextEdit txtNumberCommiment;
        private System.Windows.Forms.CheckBox chkCommiment;
        private DevExpress.XtraGrid.Columns.GridColumn gcTypeProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        public System.Windows.Forms.ContextMenuStrip mnuContextualPorgramProduction;
        private System.Windows.Forms.ToolStripMenuItem nuevoCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
    }
}