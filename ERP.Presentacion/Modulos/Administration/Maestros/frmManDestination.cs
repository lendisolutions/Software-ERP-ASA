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
    public partial class frmManDestination : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DestinationBE> mLista = new List<DestinationBE>();

        #endregion

        #region "Eventos"

        public frmManDestination()
        {
            InitializeComponent();
        }

        private void frmManDestination_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDestinationEdit objManDestination = new frmManDestinationEdit();
                objManDestination.lstDestination = mLista;
                objManDestination.pOperacion = frmManDestinationEdit.Operacion.Nuevo;
                objManDestination.IdDestination = 0;
                objManDestination.StartPosition = FormStartPosition.CenterParent;
                objManDestination.ShowDialog();
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
                        DestinationBE objE_Destination = new DestinationBE();
                        objE_Destination.IdDestination = int.Parse(gvDestination.GetFocusedRowCellValue("IdDestination").ToString());
                        objE_Destination.Login = Parametros.strUsuarioLogin;
                        objE_Destination.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Destination.IdCompany = Parametros.intEmpresaId;

                        DestinationBL objBL_Destination = new DestinationBL();
                        objBL_Destination.Elimina(objE_Destination);
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

            //    List<ReporteDestinationElementoBE> lstReporte = null;
            //    lstReporte = new ReporteDestinationElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDestinationElemento = new RptVistaReportes();
            //            objRptDestinationElemento.VerRptDestinationElemento(lstReporte);
            //            objRptDestinationElemento.ShowDialog();
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

        private void gvDestination_DoubleClick(object sender, EventArgs e)
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

        private void gvDestination_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //GridView view = (GridView)sender;
            //if (e.RowHandle == view.FocusedRowHandle)
            //{
            //    e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            //}
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDestination.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDestination.DataSource = mLista.Where(obj =>
                                                   obj.NameDestination.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDestination.RowCount > 0)
            {
                DestinationBE objDestination = new DestinationBE();
               
                objDestination.IdDestination = int.Parse(gvDestination.GetFocusedRowCellValue("IdDestination").ToString());

                frmManDestinationEdit objManDestinationEdit = new frmManDestinationEdit();
                objManDestinationEdit.pOperacion = frmManDestinationEdit.Operacion.Modificar;
                objManDestinationEdit.IdDestination = objDestination.IdDestination;
                objManDestinationEdit.pDestinationBE = objDestination;
                objManDestinationEdit.StartPosition = FormStartPosition.CenterParent;
                objManDestinationEdit.ShowDialog();

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

            if (gvDestination.GetFocusedRowCellValue("IdDestination").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Destination", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Destination.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<DestinationBE> lstDestination = null;
                lstDestination = new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstDestination.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstDestination)
                    {
                        xlHoja.Cells[Row, 1] = item.IdDestination;
                        xlHoja.Cells[Row, 2] = item.NameDestination;
                        xlHoja.Cells[Row, 3] = item.NumberLineCertificate;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Destination.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Destination.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Destination.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
