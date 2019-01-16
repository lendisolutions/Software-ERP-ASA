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
    public partial class frmManTypeStyle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TypeStyleBE> mLista = new List<TypeStyleBE>();

        #endregion

        #region "Eventos"

        public frmManTypeStyle()
        {
            InitializeComponent();
        }

        private void frmManTypeStyle_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTypeStyleEdit objManTypeStyle = new frmManTypeStyleEdit();
                objManTypeStyle.lstTypeStyle = mLista;
                objManTypeStyle.pOperacion = frmManTypeStyleEdit.Operacion.Nuevo;
                objManTypeStyle.IdTypeStyle = 0;
                objManTypeStyle.StartPosition = FormStartPosition.CenterParent;
                objManTypeStyle.ShowDialog();
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
                        TypeStyleBE objE_TypeStyle = new TypeStyleBE();
                        objE_TypeStyle.IdTypeStyle = int.Parse(gvTypeStyle.GetFocusedRowCellValue("IdTypeStyle").ToString());
                        objE_TypeStyle.Login = Parametros.strUsuarioLogin;
                        objE_TypeStyle.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TypeStyle.IdCompany = Parametros.intEmpresaId;

                        TypeStyleBL objBL_TypeStyle = new TypeStyleBL();
                        objBL_TypeStyle.Elimina(objE_TypeStyle);
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

            //    List<ReporteTypeStyleElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTypeStyleElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTypeStyleElemento = new RptVistaReportes();
            //            objRptTypeStyleElemento.VerRptTypeStyleElemento(lstReporte);
            //            objRptTypeStyleElemento.ShowDialog();
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

        private void gvTypeStyle_DoubleClick(object sender, EventArgs e)
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

        private void gvTypeStyle_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new TypeStyleBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTypeStyle.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTypeStyle.DataSource = mLista.Where(obj =>
                                                   obj.NameTypeStyle.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTypeStyle.RowCount > 0)
            {
                TypeStyleBE objTypeStyle = new TypeStyleBE();
               
                objTypeStyle.IdTypeStyle = int.Parse(gvTypeStyle.GetFocusedRowCellValue("IdTypeStyle").ToString());

                frmManTypeStyleEdit objManTypeStyleEdit = new frmManTypeStyleEdit();
                objManTypeStyleEdit.pOperacion = frmManTypeStyleEdit.Operacion.Modificar;
                objManTypeStyleEdit.IdTypeStyle = objTypeStyle.IdTypeStyle;
                objManTypeStyleEdit.pTypeStyleBE = objTypeStyle;
                objManTypeStyleEdit.StartPosition = FormStartPosition.CenterParent;
                objManTypeStyleEdit.ShowDialog();

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

            if (gvTypeStyle.GetFocusedRowCellValue("IdTypeStyle").ToString() == "")
            {
                XtraMessageBox.Show("Select a work TypeStyle", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\TypeStyle.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<TypeStyleBE> lstTypeStyle = null;
                lstTypeStyle = new TypeStyleBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstTypeStyle.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstTypeStyle)
                    {
                        xlHoja.Cells[Row, 1] = item.IdTypeStyle;
                        xlHoja.Cells[Row, 2] = item.NameTypeStyle;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\TypeStyle.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\TypeStyle.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\TypeStyle.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
