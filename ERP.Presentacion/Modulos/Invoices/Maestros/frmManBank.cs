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
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Invoices.Maestros
{
    public partial class frmManBank : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BankBE> mLista = new List<BankBE>();

        #endregion

        #region "Eventos"

        public frmManBank()
        {
            InitializeComponent();
        }

        private void frmManBank_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManBankEdit objManBank = new frmManBankEdit();
                objManBank.lstBank = mLista;
                objManBank.pOperacion = frmManBankEdit.Operacion.Nuevo;
                objManBank.IdBank = 0;
                objManBank.StartPosition = FormStartPosition.CenterParent;
                objManBank.ShowDialog();
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
                        BankBE objE_Bank = new BankBE();
                        objE_Bank.IdBank = int.Parse(gvBank.GetFocusedRowCellValue("IdBank").ToString());
                        objE_Bank.Login = Parametros.strUsuarioLogin;
                        objE_Bank.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Bank.IdCompany = Parametros.intEmpresaId;

                        BankBL objBL_Bank = new BankBL();
                        objBL_Bank.Elimina(objE_Bank);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteBankElementoBE> lstReporte = null;
            //    lstReporte = new ReporteBankElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptBankElemento = new RptVistaReportes();
            //            objRptBankElemento.VerRptBankElemento(lstReporte);
            //            objRptBankElemento.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            ExportarExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBank_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void gvBank_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new BankBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcBank.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcBank.DataSource = mLista.Where(obj =>
                                                   obj.NameBank.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvBank.RowCount > 0)
            {
                BankBE objBank = new BankBE();
               
                objBank.IdBank = int.Parse(gvBank.GetFocusedRowCellValue("IdBank").ToString());

                frmManBankEdit objManBankEdit = new frmManBankEdit();
                objManBankEdit.pOperacion = frmManBankEdit.Operacion.Modificar;
                objManBankEdit.IdBank = objBank.IdBank;
                objManBankEdit.pBankBE = objBank;
                objManBankEdit.StartPosition = FormStartPosition.CenterParent;
                objManBankEdit.ShowDialog();

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

            if (gvBank.GetFocusedRowCellValue("IdBank").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Bank", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Bank.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<BankBE> lstBank = null;
                lstBank = new BankBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstBank.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstBank)
                    {
                        xlHoja.Cells[Row, 1] = item.IdBank;
                        xlHoja.Cells[Row, 2] = item.Swift;
                        xlHoja.Cells[Row, 3] = item.NameBank;
                        xlHoja.Cells[Row, 4] = item.NameCurrency;
                        xlHoja.Cells[Row, 5] = item.NumberCtaCte;
                        xlHoja.Cells[Row, 6] = item.CodeAba;
                        xlHoja.Cells[Row, 7] = item.Address;
                        xlHoja.Cells[Row, 8] = item.Phone;
                        xlHoja.Cells[Row, 9] = item.Contac;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Bank.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Bank.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
