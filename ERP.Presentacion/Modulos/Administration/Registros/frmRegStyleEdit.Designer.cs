namespace ERP.Presentacion.Modulos.Administration.Registros
{
    partial class frmRegStyleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegStyleEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboMediaUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deRevenueDate = new DevExpress.XtraEditors.DateEdit();
            this.txtNameStyle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboClient = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtItem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMediaUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(463, 247);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(370, 247);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "Save";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtItem);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.cboMediaUnit);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboDivision);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtDescription);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.lblAño);
            this.grdDatos.Controls.Add(this.deRevenueDate);
            this.grdDatos.Controls.Add(this.txtNameStyle);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboClient);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(562, 239);
            this.grdDatos.TabIndex = 12;
            this.grdDatos.Text = "Datos";
            // 
            // cboMediaUnit
            // 
            this.cboMediaUnit.Location = new System.Drawing.Point(105, 211);
            this.cboMediaUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMediaUnit.Name = "cboMediaUnit";
            this.cboMediaUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMediaUnit.Properties.NullText = "";
            this.cboMediaUnit.Size = new System.Drawing.Size(445, 22);
            this.cboMediaUnit.TabIndex = 26;
            this.cboMediaUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMediaUnit_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 214);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 16);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Units:";
            // 
            // cboDivision
            // 
            this.cboDivision.Location = new System.Drawing.Point(105, 179);
            this.cboDivision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDivision.Properties.NullText = "";
            this.cboDivision.Size = new System.Drawing.Size(445, 22);
            this.cboDivision.TabIndex = 24;
            this.cboDivision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDivision_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 182);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 16);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Division:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 119);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Properties.MaxLength = 100;
            this.txtDescription.Size = new System.Drawing.Size(445, 22);
            this.txtDescription.TabIndex = 22;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 122);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Description:";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(12, 92);
            this.lblAño.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(84, 16);
            this.lblAño.TabIndex = 19;
            this.lblAño.Text = "Revenue Date:";
            // 
            // deRevenueDate
            // 
            this.deRevenueDate.EditValue = null;
            this.deRevenueDate.Location = new System.Drawing.Point(105, 89);
            this.deRevenueDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deRevenueDate.Name = "deRevenueDate";
            this.deRevenueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deRevenueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deRevenueDate.Size = new System.Drawing.Size(117, 22);
            this.deRevenueDate.TabIndex = 20;
            this.deRevenueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deRevenueDate_KeyPress);
            // 
            // txtNameStyle
            // 
            this.txtNameStyle.Location = new System.Drawing.Point(105, 59);
            this.txtNameStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameStyle.Name = "txtNameStyle";
            this.txtNameStyle.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameStyle.Properties.MaxLength = 50;
            this.txtNameStyle.Size = new System.Drawing.Size(445, 22);
            this.txtNameStyle.TabIndex = 9;
            this.txtNameStyle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameStyle_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 62);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Style:";
            // 
            // cboClient
            // 
            this.cboClient.Location = new System.Drawing.Point(105, 29);
            this.cboClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboClient.Name = "cboClient";
            this.cboClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClient.Properties.NullText = "";
            this.cboClient.Size = new System.Drawing.Size(445, 22);
            this.cboClient.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 32);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Client:";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(105, 149);
            this.txtItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtItem.Name = "txtItem";
            this.txtItem.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItem.Properties.MaxLength = 100;
            this.txtItem.Size = new System.Drawing.Size(445, 22);
            this.txtItem.TabIndex = 28;
            this.txtItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItem_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 152);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(31, 16);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "Item:";
            // 
            // frmRegStyleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 283);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegStyleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegStyleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMediaUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deRevenueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.LookUpEdit cboClient;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNameStyle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deRevenueDate;
        public DevExpress.XtraEditors.LookUpEdit cboMediaUnit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboDivision;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtItem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}