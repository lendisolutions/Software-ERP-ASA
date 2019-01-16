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
    public partial class frmManMediaUnit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MediaUnitBE> mLista = new List<MediaUnitBE>();

        #endregion

        #region "Eventos"

        public frmManMediaUnit()
        {
            InitializeComponent();
        }

        private void frmManMediaUnit_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMediaUnitEdit objManMediaUnit = new frmManMediaUnitEdit();
                objManMediaUnit.lstMediaUnit = mLista;
                objManMediaUnit.pOperacion = frmManMediaUnitEdit.Operacion.Nuevo;
                objManMediaUnit.IdMediaUnit = 0;
                objManMediaUnit.StartPosition = FormStartPosition.CenterParent;
                objManMediaUnit.ShowDialog();
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
                        MediaUnitBE objE_MediaUnit = new MediaUnitBE();
                        objE_MediaUnit.IdMediaUnit = int.Parse(gvMediaUnit.GetFocusedRowCellValue("IdMediaUnit").ToString());
                        objE_MediaUnit.Login = Parametros.strUsuarioLogin;
                        objE_MediaUnit.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MediaUnit.IdCompany = Parametros.intEmpresaId;

                        MediaUnitBL objBL_MediaUnit = new MediaUnitBL();
                        objBL_MediaUnit.Elimina(objE_MediaUnit);
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

            //    List<ReporteMediaUnitElementoBE> lstReporte = null;
            //    lstReporte = new ReporteMediaUnitElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMediaUnitElemento = new RptVistaReportes();
            //            objRptMediaUnitElemento.VerRptMediaUnitElemento(lstReporte);
            //            objRptMediaUnitElemento.ShowDialog();
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

        private void gvMediaUnit_DoubleClick(object sender, EventArgs e)
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

        private void gvMediaUnit_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new MediaUnitBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMediaUnit.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMediaUnit.DataSource = mLista.Where(obj =>
                                                   obj.NameMediaUnit.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMediaUnit.RowCount > 0)
            {
                MediaUnitBE objMediaUnit = new MediaUnitBE();
               
                objMediaUnit.IdMediaUnit = int.Parse(gvMediaUnit.GetFocusedRowCellValue("IdMediaUnit").ToString());

                frmManMediaUnitEdit objManMediaUnitEdit = new frmManMediaUnitEdit();
                objManMediaUnitEdit.pOperacion = frmManMediaUnitEdit.Operacion.Modificar;
                objManMediaUnitEdit.IdMediaUnit = objMediaUnit.IdMediaUnit;
                objManMediaUnitEdit.pMediaUnitBE = objMediaUnit;
                objManMediaUnitEdit.StartPosition = FormStartPosition.CenterParent;
                objManMediaUnitEdit.ShowDialog();

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

            if (gvMediaUnit.GetFocusedRowCellValue("IdMediaUnit").ToString() == "")
            {
                XtraMessageBox.Show("Select a work MediaUnit", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\MediaUnit.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<MediaUnitBE> lstMediaUnit = null;
                lstMediaUnit = new MediaUnitBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstMediaUnit.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstMediaUnit)
                    {
                        xlHoja.Cells[Row, 1] = item.IdMediaUnit;
                        xlHoja.Cells[Row, 2] = item.Abbreviate;
                        xlHoja.Cells[Row, 3] = item.NameMediaUnit;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\MediaUnit.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\MediaUnit.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\MediaUnit.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
