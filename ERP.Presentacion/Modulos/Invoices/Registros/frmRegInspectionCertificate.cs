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
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Invoices.Registros
{
    public partial class frmRegInspectionCertificate : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InspectionCertificateBE> mLista = new List<InspectionCertificateBE>();

        #endregion

        #region "Eventos"

        public frmRegInspectionCertificate()
        {
            InitializeComponent();
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            BSUtils.LoaderLook(cboStatus, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblInspectionCertificateSituation), "NameElementTablet", "IdElementTablet", true);

            deIssueDateFrom.DateTime = DateTime.Now;
            deIssueDateTo.DateTime = DateTime.Now;

            deIssueDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIssueDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIssueDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIssueDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deIssueDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIssueDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIssueDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIssueDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            gvInspectionCertificate.Columns["IssueDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvInspectionCertificate.Columns["IssueDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegInspectionCertificateEdit objManClient = new frmRegInspectionCertificateEdit();
                objManClient.lstInspectionCertificate = mLista;
                objManClient.pOperacion = frmRegInspectionCertificateEdit.Operacion.Nuevo;
                objManClient.IdInspectionCertificate = 0;
                objManClient.IdClient = Convert.ToInt32(cboClient.EditValue);
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
                    int intIdInspectionCertificate = int.Parse(gvInspectionCertificate.GetFocusedRowCellValue("IdInspectionCertificate").ToString());
                    int intIdStatus = int.Parse(gvInspectionCertificate.GetFocusedRowCellValue("IdStatus").ToString());

                    if (intIdStatus == Parametros.intICDeleted)
                    {
                        XtraMessageBox.Show("It can not be canceled.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        InspectionCertificateBL objBL_InspectionCertificate = new InspectionCertificateBL();
                        objBL_InspectionCertificate.ActualizaSituacion(intIdInspectionCertificate,  Parametros.intICDeleted);
                        XtraMessageBox.Show("The Inspection Certificate was canceled correctly.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                List<ReporteInspectionCertificateBE> lstReporteTemp = null;
                List<ReporteInspectionCertificateBE> lstReporte  = new List<ReporteInspectionCertificateBE>();

                int[] rows = gvInspectionCertificate.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    lstReporteTemp = new ReporteInspectionCertificateBL().Listado(int.Parse(gvInspectionCertificate.GetRowCellValue(rows[i], gvInspectionCertificate.Columns.ColumnByFieldName("IdInspectionCertificate")).ToString()));
                    foreach (var item in lstReporteTemp)
                    {
                        ReporteInspectionCertificateBE objE_Reporte = new ReporteInspectionCertificateBE();
                        objE_Reporte.NameCompany = item.NameCompany;
                        objE_Reporte.Logo = item.Logo;
                        objE_Reporte.NumberCertificate = item.NumberCertificate;
                        objE_Reporte.NumberPO = item.NumberPO;
                        objE_Reporte.NumberOI = item.NumberOI;
                        objE_Reporte.NameClient = item.NameClient;
                        objE_Reporte.Comment = item.Comment;
                        objE_Reporte.NameDivision = item.NameDivision;
                        objE_Reporte.BrandCertificate = item.BrandCertificate;
                        objE_Reporte.NameVendor = item.NameVendor;
                        objE_Reporte.PaymentTerm = item.PaymentTerm;
                        objE_Reporte.Cartons = item.Cartons;
                        objE_Reporte.IssueDate = item.IssueDate;
                        objE_Reporte.NameRepresentative = item.NameRepresentative;
                        objE_Reporte.DescriptionStyle = item.DescriptionStyle;
                        objE_Reporte.NumberInvoice = item.NumberInvoice;
                        objE_Reporte.IssueDateInvoice = item.IssueDateInvoice;
                        objE_Reporte.NameCurrency = item.NameCurrency;
                        objE_Reporte.Amount = item.Amount;
                        objE_Reporte.EtdDate = item.EtdDate;
                        objE_Reporte.NameTypeShipping = item.NameTypeShipping;
                        objE_Reporte.BoardingWay = item.BoardingWay;
                        objE_Reporte.NameStatus = item.NameStatus;
                        objE_Reporte.Style = item.Style;
                        lstReporte.Add(objE_Reporte);
                    }
                }

                

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptInspectionCertificate = new RptVistaReportes();
                        objRptInspectionCertificate.VerRptInspectionCertificate(lstReporte);
                        objRptInspectionCertificate.ShowDialog();
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

        private void gvInspectionCertificate_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvInspectionCertificate_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "NameStatus")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["NameStatus"]);
                        if (Situacion == "ACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "FINISHED")
                        {
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "DELETED")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            if (chkClient.Checked && chkStatus.Checked && chkIssueDate.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClientDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboStatus.EditValue), Convert.ToDateTime(deIssueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIssueDateTo.DateTime.ToShortDateString()));
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkStatus.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboStatus.EditValue));
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkIssueDate.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClientDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0, Convert.ToDateTime(deIssueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIssueDateTo.DateTime.ToShortDateString()));
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberCertificate.Checked)
            {
                mLista = new InspectionCertificateBL().ListaNumberCertificate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberCertificate.Text);
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberPO.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClientNumberPO(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text);
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberOI.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClientNumberOI(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberOI.Text);
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked)
            {
                mLista = new InspectionCertificateBL().ListaClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0);
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

        }

        public void InicializarModificar()
        {
            if (gvInspectionCertificate.RowCount > 0)
            {
                InspectionCertificateBE objInspectionCertificate = new InspectionCertificateBE();

                objInspectionCertificate.IdInspectionCertificate = int.Parse(gvInspectionCertificate.GetFocusedRowCellValue("IdInspectionCertificate").ToString());

                frmRegInspectionCertificateEdit objManInspectionCertificateEdit = new frmRegInspectionCertificateEdit();
                objManInspectionCertificateEdit.pOperacion = frmRegInspectionCertificateEdit.Operacion.Modificar;
                objManInspectionCertificateEdit.IdInspectionCertificate = objInspectionCertificate.IdInspectionCertificate;
                objManInspectionCertificateEdit.StartPosition = FormStartPosition.CenterParent;
                objManInspectionCertificateEdit.ShowDialog();

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

            if (gvInspectionCertificate.GetFocusedRowCellValue("IdInspectionCertificate").ToString() == "")
            {
                XtraMessageBox.Show("Select to Inspection Certificate", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\InspectionCertificate.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            string strNameStatus = "";
            decimal decComision = 0;
            int intPercent = 0;
            decimal decTotal = 0;
            decimal decTotalComision = 0;
            string strComision = "";

            ClientBE objE_Client = null;
            objE_Client = new ClientBL().Selecciona(Convert.ToInt32(cboClient.EditValue));
            if (objE_Client != null)
            {
                decComision = objE_Client.PercentComision1;
            }

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                xlHoja.Cells[4, 2] = cboClient.Text;

                int[] rows = gvInspectionCertificate.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    strNameStatus = "";
                    xlHoja.Cells[Row, 1] = gvInspectionCertificate.GetRowCellValue(rows[i], "NumberCertificate").ToString();
                    xlHoja.Cells[Row, 2] = BSUtils.GetDateFormat(DateTime.Parse(gvInspectionCertificate.GetRowCellValue(i, "IssueDate").ToString()));
                    xlHoja.Cells[Row, 3] = gvInspectionCertificate.GetRowCellValue(rows[i], "NumberPO").ToString();
                    xlHoja.Cells[Row, 4] = gvInspectionCertificate.GetRowCellValue(rows[i], "NumberOI").ToString();
                    xlHoja.Cells[Row, 5] = gvInspectionCertificate.GetRowCellValue(rows[i], "NumberInvoice").ToString();
                    xlHoja.Cells[Row, 6] = gvInspectionCertificate.GetRowCellValue(rows[i], "NameVendor").ToString();
                    xlHoja.Cells[Row, 7] = gvInspectionCertificate.GetRowCellValue(rows[i], "Amount").ToString();
                    xlHoja.Cells[Row, 8] = gvInspectionCertificate.GetRowCellValue(rows[i], "NameTypeShipping").ToString();
                    strNameStatus = gvInspectionCertificate.GetRowCellValue(rows[i], "NameStatus").ToString();
                    xlHoja.Cells[Row, 9] = strNameStatus;

                    if (strNameStatus == "ACTIVE" || strNameStatus == "FINISHED")
                    {
                        decTotal = decTotal + decimal.Parse(gvInspectionCertificate.GetRowCellValue(rows[i], "Amount").ToString());
                    }

                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }

                decTotalComision = decTotal * decComision;
                intPercent = Convert.ToInt32(decComision * 100);
                strComision = "COMMISSION " + intPercent.ToString() + " % US$ :";
               
                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 6] = "TOTAL US$ : ";
                xlHoja.Cells[Row + 3, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 3, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 3, 6] = strComision;
                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 7] = decTotal;
                xlHoja.Cells[Row + 3, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 3, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 3, 7] = decTotalComision;

                xlLibro.SaveAs("C:\\Excel\\InspectionCertificate.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\InspectionCertificate.xlsx");

                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\InspectionCertificate.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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