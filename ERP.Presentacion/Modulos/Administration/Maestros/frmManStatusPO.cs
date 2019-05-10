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
using ERP.Presentacion.Utils;

namespace ERP.Presentacion.Modulos.Administration.Maestros
{
    public partial class frmManStatusPO : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StatusPOBE> mLista = new List<StatusPOBE>();

        #endregion

        #region "Eventos"

        public frmManStatusPO()
        {
            InitializeComponent();
        }

        private void frmManStatusPO_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManStatusPOEdit objManStatusPO = new frmManStatusPOEdit();
                objManStatusPO.lstStatusPO = mLista;
                objManStatusPO.pOperacion = frmManStatusPOEdit.Operacion.Nuevo;
                objManStatusPO.IdStatusPO = 0;
                objManStatusPO.StartPosition = FormStartPosition.CenterParent;
                objManStatusPO.ShowDialog();
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
                        StatusPOBE objE_StatusPO = new StatusPOBE();
                        objE_StatusPO.IdStatusPO = int.Parse(gvStatusPO.GetFocusedRowCellValue("IdStatusPO").ToString());
                        objE_StatusPO.Login = Parametros.strUsuarioLogin;
                        objE_StatusPO.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_StatusPO.IdCompany = Parametros.intEmpresaId;

                        StatusPOBL objBL_StatusPO = new StatusPOBL();
                        objBL_StatusPO.Elimina(objE_StatusPO);
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

            //    List<ReporteStatusPOElementoBE> lstReporte = null;
            //    lstReporte = new ReporteStatusPOElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptStatusPOElemento = new RptVistaReportes();
            //            objRptStatusPOElemento.VerRptStatusPOElemento(lstReporte);
            //            objRptStatusPOElemento.ShowDialog();
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

        private void gvStatusPO_DoubleClick(object sender, EventArgs e)
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

        private void gvStatusPO_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new StatusPOBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcStatusPO.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcStatusPO.DataSource = mLista.Where(obj =>
                                                   obj.NameStatusPO.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvStatusPO.RowCount > 0)
            {
                StatusPOBE objStatusPO = new StatusPOBE();
               
                objStatusPO.IdStatusPO = int.Parse(gvStatusPO.GetFocusedRowCellValue("IdStatusPO").ToString());

                frmManStatusPOEdit objManStatusPOEdit = new frmManStatusPOEdit();
                objManStatusPOEdit.pOperacion = frmManStatusPOEdit.Operacion.Modificar;
                objManStatusPOEdit.IdStatusPO = objStatusPO.IdStatusPO;
                objManStatusPOEdit.pStatusPOBE = objStatusPO;
                objManStatusPOEdit.StartPosition = FormStartPosition.CenterParent;
                objManStatusPOEdit.ShowDialog();

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

            if (gvStatusPO.GetFocusedRowCellValue("IdStatusPO").ToString() == "")
            {
                XtraMessageBox.Show("Select a work StatusPO", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\StatusPO.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<StatusPOBE> lstStatusPO = null;
                lstStatusPO = new StatusPOBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstStatusPO.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstStatusPO)
                    {
                        xlHoja.Cells[Row, 1] = item.IdStatusPO;
                        xlHoja.Cells[Row, 2] = item.NameStatusPO;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\StatusPO.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\StatusPO.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\StatusPO.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
