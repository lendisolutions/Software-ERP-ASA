using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Modulos.Production.Registros;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Consultas
{
    public partial class frmConProductionProgramControlOI : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProgramProductionAuditBE> mLista = new List<ProgramProductionAuditBE>();
        int intIdStyle = 0;

        #endregion

        #region "Eventos"

        public frmConProductionProgramControlOI()
        {
            InitializeComponent();
        }

        private void frmConProductionProgramControlOI_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            deDateFrom.DateTime = DateTime.Now;
            deDateTo.DateTime = DateTime.Now;

            deDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["XfDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["XfDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
           
            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                BSUtils.LoaderLook(cboDivision, new LoginClientDepartmentBL().ListaClientDivision(Parametros.intUsuarioId, Convert.ToInt32(cboClient.EditValue)), "NameDivision", "IdClientDepartment", true);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel("");
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusStyle_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmBusStyle frm = new frmBusStyle();
                frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                frm.IdClientDepartment = 0;
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    intIdStyle = frm._Be.IdStyle;
                    txtNameStyle.Text = frm._Be.NameStyle;
                    txtDescription.Text = frm._Be.Description;  
                }

                Cursor = Cursors.Default;
               
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStyle.Checked == false)
            {
                intIdStyle = 0;
                txtNameStyle.Text = "";
                txtDescription.Text = "";
            }
        }

        private void gvProgramProductionAudit_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        private void mnuProgramProductionAudittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                frmRegControlAuditEdit frm = new frmRegControlAuditEdit();
                frm.IdProgramProductionAudit = int.Parse(gvProgramProductionAudit.GetFocusedRowCellValue("IdProgramProductionAudit").ToString());
                frm.ShowDialog();
                Cargar();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            if (!chkClient.Checked && !chkDivision.Checked && !chkDate.Checked && !chkNumberPO.Checked && !chkNumeroOI.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClient(0,0);
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkDivision.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClient(Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue));
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkDate.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClientDate(Convert.ToInt32(cboClient.EditValue), Convert.ToDateTime(deDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deDateTo.DateTime.ToShortDateString()));
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberPO.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClientNumberPO(Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text);
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkStyle.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClientStyle(Convert.ToInt32(cboClient.EditValue), intIdStyle);
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }


            if (chkClient.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClient(Convert.ToInt32(cboClient.EditValue),0);
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            
            if (chkNumeroOI.Checked)
            {
                mLista = new ProgramProductionAuditBL().ListaClientNumeroOI(txtNumeroOI.Text);
                gcProgramProductionAudit.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }



        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ProductionProgramAudit.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                xlHoja.Cells[4, 2] = cboClient.Text;

              
                for (int i = 0; i < gvProgramProductionAudit.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProductionAudit.GetRowCellValue(i, "AuditDate").ToString()));
                    xlHoja.Cells[Row, 2] = gvProgramProductionAudit.GetRowCellValue(i, "NumeroOI").ToString();
                    xlHoja.Cells[Row, 3] = gvProgramProductionAudit.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 4] = gvProgramProductionAudit.GetRowCellValue(i, "NameDestination").ToString();
                    xlHoja.Cells[Row, 5] = gvProgramProductionAudit.GetRowCellValue(i, "NumberPO").ToString();
                    xlHoja.Cells[Row, 6] = gvProgramProductionAudit.GetRowCellValue(i, "Units").ToString();
                    xlHoja.Cells[Row, 7] = gvProgramProductionAudit.GetRowCellValue(i, "Item").ToString();
                    xlHoja.Cells[Row, 8] = gvProgramProductionAudit.GetRowCellValue(i, "NameStyle").ToString();
                    xlHoja.Cells[Row, 9] = gvProgramProductionAudit.GetRowCellValue(i, "XfDate").ToString().Substring(0, 10);
                    if (gvProgramProductionAudit.GetRowCellValue(i, "SendDate") != null)
                        xlHoja.Cells[Row, 10] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProductionAudit.GetRowCellValue(i, "SendDate").ToString()));
                    else
                        xlHoja.Cells[Row, 10] = "";

                    if (gvProgramProductionAudit.GetRowCellValue(i, "ReturnDate") != null)
                        xlHoja.Cells[Row, 11] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProductionAudit.GetRowCellValue(i, "ReturnDate").ToString()));
                    else
                        xlHoja.Cells[Row, 11] = "";
                    xlHoja.Cells[Row, 12] = gvProgramProductionAudit.GetRowCellValue(i, "Comment").ToString();
                    xlHoja.Cells[Row, 13] = gvProgramProductionAudit.GetRowCellValue(i, "FileBox").ToString();
                    xlHoja.Cells[Row, 14] = gvProgramProductionAudit.GetRowCellValue(i, "GarmentBox").ToString();
                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }


                xlLibro.SaveAs("C:\\Excel\\ProductionProgramAudit.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\ProductionProgramAudit.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\ProductionProgramExpired.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }






        #endregion

        
    }
}