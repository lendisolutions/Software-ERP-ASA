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
    public partial class frmRegInvoice : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InvoiceBE> mLista = new List<InvoiceBE>();

        #endregion

        #region "Eventos"

        public frmRegInvoice()
        {
            InitializeComponent();
        }

        private void frmRegInvoice_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            BSUtils.LoaderLook(cboStatus, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblInvoiceSituation), "NameElementTablet", "IdElementTablet", true);

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

            gvInvoice.Columns["IssueDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvInvoice.Columns["IssueDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegInvoiceEdit objManClient = new frmRegInvoiceEdit();
                objManClient.lstInvoice = mLista;
                objManClient.pOperacion = frmRegInvoiceEdit.Operacion.Nuevo;
                objManClient.IdInvoice = 0;
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
                    int intIdInvoice = int.Parse(gvInvoice.GetFocusedRowCellValue("IdInvoice").ToString());
                    int intIdStatus = int.Parse(gvInvoice.GetFocusedRowCellValue("IdStatus").ToString());

                    if (intIdStatus == Parametros.intIVNDeleted)
                    {
                        XtraMessageBox.Show("It can not be canceled.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        InvoiceBL objBL_Invoice = new InvoiceBL();
                        objBL_Invoice.ActualizaSituacion(intIdInvoice, Parametros.intIVNDeleted);
                        XtraMessageBox.Show("The invoice was canceled correctly.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                List<ReporteInvoiceBE> lstReporteTemp = null;
                List<ReporteInvoiceBE> lstReporte = new List<ReporteInvoiceBE>();

                int[] rows = gvInvoice.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    lstReporteTemp = new ReporteInvoiceBL().Listado(int.Parse(gvInvoice.GetRowCellValue(rows[i], gvInvoice.Columns.ColumnByFieldName("IdInvoice")).ToString()));
                    foreach (var item in lstReporteTemp)
                    {
                        ReporteInvoiceBE objE_Reporte = new ReporteInvoiceBE();
                        objE_Reporte.NameCompany = item.NameCompany;
                        objE_Reporte.Logo = item.Logo;
                        objE_Reporte.NumberInvoice = item.NumberInvoice;
                        objE_Reporte.NameClient = item.NameClient;
                        objE_Reporte.ConceptoImprime = item.ConceptoImprime;
                        objE_Reporte.IssueDate = item.IssueDate;
                        objE_Reporte.NameDestination = item.NameDestination;
                        objE_Reporte.BrandCertificate = item.BrandCertificate;
                        objE_Reporte.PercentComision = item.PercentComision;
                        objE_Reporte.ComisionImprime = item.ComisionImprime;
                        objE_Reporte.AddressClient = item.AddressClient;
                        objE_Reporte.Contac = item.Contac;
                        objE_Reporte.Occupation = item.Occupation;
                        objE_Reporte.NoteGeneral = item.NoteGeneral;
                        objE_Reporte.NameBank = item.NameBank;
                        objE_Reporte.NumberCtaCte = item.NumberCtaCte;
                        objE_Reporte.Swift = item.Swift;
                        objE_Reporte.CodeAba = item.CodeAba;
                        objE_Reporte.AddressBank = item.AddressBank;
                        objE_Reporte.Phone = item.Phone;
                        objE_Reporte.Representative = item.Representative;
                        objE_Reporte.NameCurrency = item.NameCurrency;
                        objE_Reporte.TotalAmount = item.TotalAmount;
                        objE_Reporte.TotalComision = item.TotalComision;
                        objE_Reporte.TotalPieces = item.TotalPieces;
                        objE_Reporte.ComisionLetter = item.ComisionLetter;
                        objE_Reporte.NameStatus = item.NameStatus;
                        objE_Reporte.NumberCertificate = item.NumberCertificate;
                        objE_Reporte.IssueCertificate = item.IssueCertificate;
                        objE_Reporte.NameVendor = item.NameVendor;
                        objE_Reporte.NumberInvoiceCertificate = item.NumberInvoiceCertificate;
                        objE_Reporte.IssueDateInvoice = item.IssueDateInvoice;
                        objE_Reporte.NameDivision = item.NameDivision;
                        objE_Reporte.Amount = item.Amount;
                        objE_Reporte.Comision = item.Comision;
                        objE_Reporte.Pieces = item.Pieces;
                        objE_Reporte.CertificateVince = item.CertificateVince;
                        objE_Reporte.StyleVince = item.StyleVince;
                        lstReporte.Add(objE_Reporte);
                    }
                }

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptInvoice = new RptVistaReportes();
                        objRptInvoice.VerRptInvoice(lstReporte);
                        objRptInvoice.ShowDialog();
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

        private void gvInvoice_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvInvoice_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteInvoiceBE> lstReporte = null;
                lstReporte = new ReporteInvoiceBL().ListadoCommisionCover(int.Parse(gvInvoice.GetFocusedRowCellValue("IdInvoice").ToString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptInvoice = new RptVistaReportes();
                        objRptInvoice.VerRptInvoiceComisionCover(lstReporte);
                        objRptInvoice.ShowDialog();
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            if (chkClient.Checked && chkStatus.Checked && chkIssueDate.Checked)
            {
                mLista = new InvoiceBL().ListaClientDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboStatus.EditValue), Convert.ToDateTime(deIssueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIssueDateTo.DateTime.ToShortDateString()));
                gcInvoice.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkStatus.Checked)
            {
                mLista = new InvoiceBL().ListaClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboStatus.EditValue));
                gcInvoice.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkIssueDate.Checked)
            {
                mLista = new InvoiceBL().ListaClientDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0, Convert.ToDateTime(deIssueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIssueDateTo.DateTime.ToShortDateString()));
                gcInvoice.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberInvoice.Checked)
            {
                mLista = new InvoiceBL().ListaNumberInvoice(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberInvoice.Text);
                gcInvoice.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked)
            {
                mLista = new InvoiceBL().ListaClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0);
                gcInvoice.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

        }

        public void InicializarModificar()
        {
            if (gvInvoice.RowCount > 0)
            {
                InvoiceBE objInvoice = new InvoiceBE();

                objInvoice.IdInvoice = int.Parse(gvInvoice.GetFocusedRowCellValue("IdInvoice").ToString());

                frmRegInvoiceEdit objManInvoiceEdit = new frmRegInvoiceEdit();
                objManInvoiceEdit.pOperacion = frmRegInvoiceEdit.Operacion.Modificar;
                objManInvoiceEdit.IdInvoice = objInvoice.IdInvoice;
                objManInvoiceEdit.StartPosition = FormStartPosition.CenterParent;
                objManInvoiceEdit.ShowDialog();

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

            if (gvInvoice.GetFocusedRowCellValue("IdInvoice").ToString() == "")
            {
                XtraMessageBox.Show("Select to Inspection Certificate", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Invoice.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            string strNameStatus = "";
            decimal decComision = 0;
            int intPercent = 0;
            decimal decTotalAmount = 0;
            decimal decTotalComision = 0;
            decimal decTotalPieces = 0;
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

                int[] rows = gvInvoice.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    strNameStatus = "";
                    xlHoja.Cells[Row, 1] = gvInvoice.GetRowCellValue(rows[i], "NumberInvoice").ToString();
                    xlHoja.Cells[Row, 2] = BSUtils.GetDateFormat(DateTime.Parse(gvInvoice.GetRowCellValue(i, "IssueDate").ToString()));
                    xlHoja.Cells[Row, 3] = gvInvoice.GetRowCellValue(rows[i], "NameClient").ToString();
                    xlHoja.Cells[Row, 4] = gvInvoice.GetRowCellValue(rows[i], "NameBank").ToString();
                    xlHoja.Cells[Row, 5] = gvInvoice.GetRowCellValue(rows[i], "NameCurrency").ToString();
                    xlHoja.Cells[Row, 6] = gvInvoice.GetRowCellValue(rows[i], "TotalAmount").ToString();
                    xlHoja.Cells[Row, 7] = gvInvoice.GetRowCellValue(rows[i], "TotalComision").ToString();
                    xlHoja.Cells[Row, 8] = gvInvoice.GetRowCellValue(rows[i], "TotalPieces").ToString();
                    strNameStatus = gvInvoice.GetRowCellValue(rows[i], "NameStatus").ToString();
                    xlHoja.Cells[Row, 9] = strNameStatus;

                    if (strNameStatus == "ACTIVE" || strNameStatus == "FINISHED")
                    {
                        decTotalAmount = decTotalAmount + decimal.Parse(gvInvoice.GetRowCellValue(rows[i], "TotalAmount").ToString());
                        decTotalComision = decTotalComision + decimal.Parse(gvInvoice.GetRowCellValue(rows[i], "TotalComision").ToString());
                        decTotalPieces = decTotalPieces + decimal.Parse(gvInvoice.GetRowCellValue(rows[i], "TotalPieces").ToString());
                    }

                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }

                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 6] = "TOTAL AMOUNT US$ : ";

                xlHoja.Cells[Row + 3, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 3, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 3, 6] = "TOTAL COMMISION US$ : ";

                xlHoja.Cells[Row + 4, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 4, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 4, 6] = "TOTAL PIECES : ";

                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 7] = decTotalAmount;

                xlHoja.Cells[Row + 3, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 3, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 3, 7] = decTotalComision;

                xlHoja.Cells[Row + 4, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 4, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 4, 7] = decTotalPieces;


                xlLibro.SaveAs("C:\\Excel\\Invoice.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\Invoice.xlsx");

                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Invoice.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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