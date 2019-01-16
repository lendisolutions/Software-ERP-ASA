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
using DevExpress.XtraGrid.Columns;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;


namespace ERP.Presentacion.Modulos.Production.Registros
{
    public partial class frmRegProductionProgram : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProgramProductionBE> mLista = new List<ProgramProductionBE>();

        #endregion

        #region "Eventos"

        public frmRegProductionProgram()
        {
            InitializeComponent();
            gcIndcDate.Caption = "IDNC\nDate";
            gcTypeProduct.Caption = "Type\nProduct";
        }

        private void frmRegProductionProgram_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);

            deRevenueDateFrom.DateTime = DateTime.Now;
            deRevenueDateTo.DateTime = DateTime.Now;
            deIndcDateFrom.DateTime = DateTime.Now;
            deIndcDateTo.DateTime = DateTime.Now;

            deRevenueDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deRevenueDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            deIndcDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIndcDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIndcDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIndcDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deIndcDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIndcDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIndcDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIndcDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProduction.Columns["IndcDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProduction.Columns["IndcDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProduction.OptionsView.ShowFooter = true;
            gvProgramProduction.Layout += new EventHandler(gvProgramProduction_Layout);
            AttachSummary();
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                if (Convert.ToInt32(cboClient.EditValue) == 7) //VINCE
                {
                    gvProgramProduction.Columns["Dyelot"].VisibleIndex = 6;
                    gvProgramProduction.Columns["Dyelot"].Visible = true;
                }
                else
                {
                    gvProgramProduction.Columns["Dyelot"].VisibleIndex = 6;
                    gvProgramProduction.Columns["Dyelot"].Visible = false;
                }


                BSUtils.LoaderLook(cboDivision, new LoginClientDepartmentBL().ListaClientDivision(Parametros.intUsuarioId,Convert.ToInt32(cboClient.EditValue)), "NameDivision", "IdClientDepartment", true);
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegProductionProgramEdit objManClient = new frmRegProductionProgramEdit();
                objManClient.lstProgramProduction = mLista;
                objManClient.pOperacion = frmRegProductionProgramEdit.Operacion.Nuevo;
                objManClient.IdProgramProduction = 0;
                objManClient.bCopy = false;
                objManClient.IdClient = Convert.ToInt32(cboClient.EditValue);
                objManClient.IdDivision = Convert.ToInt32(cboDivision.EditValue);
                objManClient.StartPosition = FormStartPosition.CenterParent;
                objManClient.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Be sure to delete the record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ProgramProductionBE objE_ProgramProduction = new ProgramProductionBE();
                        objE_ProgramProduction.IdProgramProduction = int.Parse(gvProgramProduction.GetFocusedRowCellValue("IdProgramProduction").ToString());
                        objE_ProgramProduction.Login = Parametros.strUsuarioLogin;
                        objE_ProgramProduction.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProgramProduction.IdCompany = Parametros.intEmpresaId;

                        ProgramProductionBL objBL_ProgramProduction = new ProgramProductionBL();
                        objBL_ProgramProduction.Elimina(objE_ProgramProduction);
                        XtraMessageBox.Show("The record was successfully deleted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteProgramProductionBE> lstReporte = null;
                lstReporte = new ReporteProgramProductionBL().Listado(int.Parse(gvProgramProduction.GetFocusedRowCellValue("IdProgramProduction").ToString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProgramProduction = new RptVistaReportes();
                        objRptProgramProduction.VerRptProgramProduction(lstReporte);
                        objRptProgramProduction.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            ExportarExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProgramProduction_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvProgramProduction_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvProgramProduction.RowCount > 0)
            {
                ProgramProductionBE objProgramProduction = new ProgramProductionBE();

                objProgramProduction.IdProgramProduction = int.Parse(gvProgramProduction.GetFocusedRowCellValue("IdProgramProduction").ToString());

                frmRegProductionProgramEdit objManProgramProductionEdit = new frmRegProductionProgramEdit();
                objManProgramProductionEdit.pOperacion = frmRegProductionProgramEdit.Operacion.Nuevo;
                objManProgramProductionEdit.lstProgramProduction = mLista;
                objManProgramProductionEdit.bCopy = true;
                objManProgramProductionEdit.IdProgramProduction = objProgramProduction.IdProgramProduction;
                objManProgramProductionEdit.StartPosition = FormStartPosition.CenterParent;
                objManProgramProductionEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void gvProgramProduction_Layout(object sender, EventArgs e)
        {
            AttachSummary();
        }

        private void deRevenueDateFrom_MouseMove(object sender, MouseEventArgs e)
        {
            deRevenueDateFrom.SelectAll();
        }

        private void deRevenueDateTo_MouseMove(object sender, MouseEventArgs e)
        {
            deRevenueDateTo.SelectAll();
        }

        private void frmRegProductionProgram_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (chkClient.Checked && chkDivision.Checked && chkXfDate.Checked)
                {
                    mLista = new ProgramProductionBL().ListaClientDivisionXfDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkClient.Checked && chkDivision.Checked && chkIndcDate.Checked)
                {
                    mLista = new ProgramProductionBL().ListaClientDivisionIndcDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deIndcDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIndcDateTo.DateTime.ToShortDateString()));
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkClient.Checked && chkXfDate.Checked)
                {
                    mLista = new ProgramProductionBL().ListaClientDivisionXfDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0, Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkClient.Checked && chkDivision.Checked)
                {
                    mLista = new ProgramProductionBL().ListaClientDivision(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue));
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkClient.Checked && chkNumberPO.Checked)
                {
                    mLista = new ProgramProductionBL().ListaNumberPO(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text);
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkClient.Checked && chkCommiment.Checked)
                {
                    mLista = new ProgramProductionBL().ListaNumberCommiment(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberCommiment.Text);
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }


                if (chkClient.Checked)
                {
                    mLista = new ProgramProductionBL().ListaClientDivision(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0);
                    gcProgramProduction.DataSource = mLista;
                    Cursor = Cursors.Default;
                    return;
                }

                AttachSummary();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InicializarModificar()
        {
            if (gvProgramProduction.RowCount > 0)
            {
                ProgramProductionBE objProgramProduction = new ProgramProductionBE();

                objProgramProduction.IdProgramProduction = int.Parse(gvProgramProduction.GetFocusedRowCellValue("IdProgramProduction").ToString());

                frmRegProductionProgramEdit objManProgramProductionEdit = new frmRegProductionProgramEdit();
                objManProgramProductionEdit.pOperacion = frmRegProductionProgramEdit.Operacion.Modificar;
                objManProgramProductionEdit.bCopy = false;
                objManProgramProductionEdit.IdProgramProduction = objProgramProduction.IdProgramProduction;
                objManProgramProductionEdit.IdClient = Convert.ToInt32(cboClient.EditValue);
                objManProgramProductionEdit.IdDivision = Convert.ToInt32(cboDivision.EditValue);
                objManProgramProductionEdit.StartPosition = FormStartPosition.CenterParent;
                objManProgramProductionEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvProgramProduction.GetFocusedRowCellValue("IdProgramProduction").ToString() == "")
            {
                XtraMessageBox.Show("Select to Program Production", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void AttachSummary()
        {
            GridColumn firstColumn = gvProgramProduction.VisibleColumns.Count == 0 ? null : gvProgramProduction.VisibleColumns[0];
            GridColumn SecondColumn = gvProgramProduction.VisibleColumns.Count == 0 ? null : gvProgramProduction.VisibleColumns[0];

            if (gcUnits == firstColumn) return;
            if (gcUnits != null)
            {
                gcUnits.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcUnits.SummaryItem.DisplayFormat = "TOTAL = {0:n0}";
            }

            if (gcTotal == SecondColumn) return;
            if (gcTotal != null)
            {
                gcTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcTotal.SummaryItem.DisplayFormat = "TOTAL = {0:n2}";
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (keyData == Keys.F5) btnBuscar.PerformClick();
           

            

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ProductionProgram.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                decimal decTotalUnits = 0;
                decimal decTotal = 0;

                xlHoja.Cells[4, 2] = cboClient.Text;

                for (int i = 0; i < gvProgramProduction.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = gvProgramProduction.GetRowCellValue(i, "NumberPO").ToString();
                    xlHoja.Cells[Row, 2] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProduction.GetRowCellValue(i, "XfDate").ToString()));
                    xlHoja.Cells[Row, 3] = gvProgramProduction.GetRowCellValue(i, "NameDivision").ToString();
                    xlHoja.Cells[Row, 4] = gvProgramProduction.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 5] = gvProgramProduction.GetRowCellValue(i, "NameStyle").ToString();
                    xlHoja.Cells[Row, 6] = gvProgramProduction.GetRowCellValue(i, "Description").ToString();
                    xlHoja.Cells[Row, 7] = gvProgramProduction.GetRowCellValue(i, "Item").ToString();
                    xlHoja.Cells[Row, 8] = gvProgramProduction.GetRowCellValue(i, "Detail").ToString();
                    xlHoja.Cells[Row, 9] = gvProgramProduction.GetRowCellValue(i, "Units").ToString();
                    decTotalUnits = decTotalUnits + decimal.Parse(gvProgramProduction.GetRowCellValue(i, "Units").ToString());
                    xlHoja.Cells[Row, 10] = gvProgramProduction.GetRowCellValue(i, "Fob").ToString();
                    decTotal = decTotal + decimal.Parse(gvProgramProduction.GetRowCellValue(i, "Total").ToString());
                    xlHoja.Cells[Row, 11] = gvProgramProduction.GetRowCellValue(i, "Total").ToString();
                    xlHoja.Cells[Row, 12] = gvProgramProduction.GetRowCellValue(i, "NumberCommiment").ToString();
                    xlHoja.Cells[Row, 13] = gvProgramProduction.GetRowCellValue(i, "Label").ToString();
                    xlHoja.Cells[Row, 14] = gvProgramProduction.GetRowCellValue(i, "NameDestination").ToString();
                    xlHoja.Cells[Row, 15] = gvProgramProduction.GetRowCellValue(i, "NameSeason").ToString();
                    xlHoja.Cells[Row, 16] = gvProgramProduction.GetRowCellValue(i, "NameTypeProduct").ToString();
                    xlHoja.Cells[Row, 17] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProduction.GetRowCellValue(i, "IndcDate").ToString()));
                    xlHoja.Cells[Row, 18] = gvProgramProduction.GetRowCellValue(i, "NameShipMode").ToString();
                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }

                xlHoja.Cells[Row + 2, 8].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 8].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 8] = "TOTAL : ";

                xlHoja.Cells[Row + 2, 9].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 9].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 9] = decTotalUnits;

                xlHoja.Cells[Row + 2, 11].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 11].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 11] = decTotal;


                xlLibro.SaveAs("C:\\Excel\\ProductionProgram.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\ProductionProgram.xlsx");

                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\ProductionProgram.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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