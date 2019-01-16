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

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManTabla : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TabletBE> mLista = new List<TabletBE>();
        
        #endregion

        #region "Eventos"

        public frmManTabla()
        {
            InitializeComponent();
        }

        private void frmManTabla_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTablaEdit objManTabla = new frmManTablaEdit();
                objManTabla.lstTabla = mLista;
                objManTabla.pOperacion = frmManTablaEdit.Operacion.Nuevo;
                objManTabla.IdTablet = 0;
                objManTabla.StartPosition = FormStartPosition.CenterParent;
                objManTabla.ShowDialog();
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
                        TabletBE objE_Tabla = new TabletBE();
                        objE_Tabla.IdTablet = int.Parse(gvTabla.GetFocusedRowCellValue("IdTablet").ToString());
                        objE_Tabla.Login = Parametros.strUsuarioLogin;
                        objE_Tabla.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Tabla.IdCompany = Parametros.intEmpresaId;

                        TabletBL objBL_Tabla = new TabletBL();
                        objBL_Tabla.Elimina(objE_Tabla);
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

                //List<ReporteTablaElementoBE> lstReporte = null;
                //lstReporte = new ReporteTablaElementoBL().Listado();

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptTablaElemento = new RptVistaReportes();
                //        objRptTablaElemento.VerRptTablaElemento(lstReporte);
                //        objRptTablaElemento.ShowDialog();
                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
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

        private void gvTabla_DoubleClick(object sender, EventArgs e)
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

        private void elementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTabla.RowCount > 0)
            {
                int IdTablet = int.Parse(gvTabla.GetFocusedRowCellValue("IdTablet").ToString());

                frmManTablaElemento objManTablaElemento = new frmManTablaElemento();
                objManTablaElemento.IdTablet = IdTablet;
                objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
                objManTablaElemento.ShowDialog();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TabletBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTabla.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTabla.DataSource = mLista.Where(obj =>
                                                   obj.NameTablet.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTabla.RowCount > 0)
            {
                TabletBE objTabla = new TabletBE();
                objTabla.IdTablet = int.Parse(gvTabla.GetFocusedRowCellValue("IdTablet").ToString());
                objTabla.NameTablet = gvTabla.GetFocusedRowCellValue("NameTablet").ToString();
                objTabla.FlagState = Convert.ToBoolean(gvTabla.GetFocusedRowCellValue("FlagState").ToString());

                frmManTablaEdit objManTablaEdit = new frmManTablaEdit();
                objManTablaEdit.pOperacion = frmManTablaEdit.Operacion.Modificar;
                objManTablaEdit.IdTablet = objTabla.IdTablet;
                objManTablaEdit.pTabletBE = objTabla;
                objManTablaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTablaEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("Edit");
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

            if (gvTabla.GetFocusedRowCellValue("IdTablet").ToString() == "")
            {
                XtraMessageBox.Show("Select a Tablet", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Tablet.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<TabletBE> lstTablet = null;
                lstTablet = new TabletBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstTablet.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstTablet)
                    {
                        xlHoja.Cells[Row, 1] = item.IdTablet;
                        xlHoja.Cells[Row, 2] = item.NameTablet;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Tablet.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Tablet.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Tablet.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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