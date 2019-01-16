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
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Registros
{
    public partial class frmRegCommiment : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CommimentBE> mLista = new List<CommimentBE>();

        #endregion

        #region "Eventos"

        public frmRegCommiment()
        {
            InitializeComponent();
            gcProducionProgram.Caption = "N° Commiment";
            gcCommimentDate.Caption = "Commiment\nDate";
            gcContractShipDate.Caption = "Contract Ship\nDate";
            gcRevisionDate.Caption = "Revision\nDate";
        }

        private void frmRegCommiment_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            deCommimentDateFrom.DateTime = DateTime.Now;
            deCommimentDateTo.DateTime = DateTime.Now;
            deContractShipDateFrom.DateTime = DateTime.Now;
            deContractShipDateTo.DateTime = DateTime.Now;
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegCommimentEdit objManClient = new frmRegCommimentEdit();
                objManClient.lstCommiment = mLista;
                objManClient.pOperacion = frmRegCommimentEdit.Operacion.Nuevo;
                objManClient.IdCommiment = 0;
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
                    if (!ValidarIngreso())
                    {
                        CommimentBE objE_Commiment = new CommimentBE();
                        objE_Commiment.IdCommiment = int.Parse(gvCommiment.GetFocusedRowCellValue("IdCommiment").ToString());
                        objE_Commiment.Login = Parametros.strUsuarioLogin;
                        objE_Commiment.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Commiment.IdCompany = Parametros.intEmpresaId;

                        CommimentBL objBL_Commiment = new CommimentBL();
                        objBL_Commiment.Elimina(objE_Commiment);
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

            //    List<ReporteClientElementoBE> lstReporte = null;
            //    lstReporte = new ReporteClientElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptClientElemento = new RptVistaReportes();
            //            objRptClientElemento.VerRptClientElemento(lstReporte);
            //            objRptClientElemento.ShowDialog();
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

        private void gvCommiment_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvCommiment_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            if (chkClient.Checked && chkCommimentDate.Checked)
            {
                mLista = new CommimentBL().ListaClientCommimentDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToDateTime(deCommimentDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deCommimentDateTo.DateTime.ToShortDateString()));
            }

            if (chkClient.Checked && chkContractShipDate.Checked)
            {
                mLista = new CommimentBL().ListaClientContractShipDate(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue),  Convert.ToDateTime(deContractShipDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deContractShipDateTo.DateTime.ToShortDateString()));
            }

            if (chkClient.Checked)
            {
                mLista = new CommimentBL().ListaClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue));
            }

            if (chkCommiment.Checked)
            {
                mLista = new CommimentBL().ListaNumberCommiment(Parametros.intEmpresaId, txtNumberCommiment.Text);
            }

            gcCommiment.DataSource = mLista;

            Cursor = Cursors.Default;
        }

        public void InicializarModificar()
        {
            if (gvCommiment.RowCount > 0)
            {
                CommimentBE objCommiment = new CommimentBE();

                objCommiment.IdCommiment = int.Parse(gvCommiment.GetFocusedRowCellValue("IdCommiment").ToString());

                frmRegCommimentEdit objManCommimentEdit = new frmRegCommimentEdit();
                objManCommimentEdit.pOperacion = frmRegCommimentEdit.Operacion.Modificar;
                objManCommimentEdit.IdCommiment = objCommiment.IdCommiment;
                objManCommimentEdit.StartPosition = FormStartPosition.CenterParent;
                objManCommimentEdit.ShowDialog();

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

            if (gvCommiment.GetFocusedRowCellValue("IdCommiment").ToString() == "")
            {
                XtraMessageBox.Show("Select to Commiment", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Commiment.xlsx");
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

                for (int i = 0; i < gvCommiment.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = gvCommiment.GetRowCellValue(i, "NumberCommiment").ToString();
                    xlHoja.Cells[Row, 2] = gvCommiment.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 3] = gvCommiment.GetRowCellValue(i, "CommimentDate").ToString().Substring(0, 10);
                    xlHoja.Cells[Row, 4] = gvCommiment.GetRowCellValue(i, "ContractShipDate").ToString().Substring(0, 10); 
                    xlHoja.Cells[Row, 5] = gvCommiment.GetRowCellValue(i, "RevisionDate").ToString().Substring(0, 10);
                    xlHoja.Cells[Row, 6] = gvCommiment.GetRowCellValue(i, "NameOrigen").ToString();
                    xlHoja.Cells[Row, 7] = gvCommiment.GetRowCellValue(i, "NameDestination").ToString();
                    xlHoja.Cells[Row, 8] = gvCommiment.GetRowCellValue(i, "NameCurrency").ToString();
                    xlHoja.Cells[Row, 9] = gvCommiment.GetRowCellValue(i, "FreightPaid").ToString();
                    xlHoja.Cells[Row, 10] = gvCommiment.GetRowCellValue(i, "Addionational").ToString();
                   
                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }


                xlLibro.SaveAs("C:\\Excel\\Commiment.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Commiment.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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