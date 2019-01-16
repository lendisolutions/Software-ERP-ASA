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
    public partial class frmManCargo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<OccupationBE> mLista = new List<OccupationBE>();
        
        #endregion

        #region "Eventos"

        public frmManCargo()
        {
            InitializeComponent();
        }

        private void frmManCargo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCargoEdit objManCargo = new frmManCargoEdit();
                objManCargo.lstCargo = mLista;
                objManCargo.pOperacion = frmManCargoEdit.Operacion.Nuevo;
                objManCargo.IdOccupation = 0;
                objManCargo.StartPosition = FormStartPosition.CenterParent;
                objManCargo.ShowDialog();
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
                if (XtraMessageBox.Show("Be sure to delete the record??", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        OccupationBE objE_Cargo = new OccupationBE();
                        objE_Cargo.IdOccupation = int.Parse(gvCargo.GetFocusedRowCellValue("IdOccupation").ToString());
                        objE_Cargo.Login = Parametros.strUsuarioLogin;
                        objE_Cargo.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cargo.IdCompany = Parametros.intEmpresaId;

                        OccupationBL objBL_Cargo = new OccupationBL();
                        objBL_Cargo.Elimina(objE_Cargo);
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

            //    List<ReporteCargoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCargoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCargoElemento = new RptVistaReportes();
            //            objRptCargoElemento.VerRptCargoElemento(lstReporte);
            //            objRptCargoElemento.ShowDialog();
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

        private void gvCargo_DoubleClick(object sender, EventArgs e)
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new OccupationBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCargo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCargo.DataSource = mLista.Where(obj =>
                                                   obj.NameOccupation.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCargo.RowCount > 0)
            {
                OccupationBE objCargo = new OccupationBE();
                objCargo.IdOccupation = int.Parse(gvCargo.GetFocusedRowCellValue("IdOccupation").ToString());
                objCargo.NameOccupation = gvCargo.GetFocusedRowCellValue("NameOccupation").ToString();
                objCargo.FlagState = Convert.ToBoolean(gvCargo.GetFocusedRowCellValue("FlagState").ToString());

                frmManCargoEdit objManCargoEdit = new frmManCargoEdit();
                objManCargoEdit.pOperacion = frmManCargoEdit.Operacion.Modificar;
                objManCargoEdit.IdOccupation = objCargo.IdOccupation;
                objManCargoEdit.pOccupationBE = objCargo;
                objManCargoEdit.StartPosition = FormStartPosition.CenterParent;
                objManCargoEdit.ShowDialog();

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

            if (gvCargo.GetFocusedRowCellValue("IdOccupation").ToString() == "")
            {
                XtraMessageBox.Show("Select a occupation.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Occupation.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<OccupationBE> lstOccupation = null;
                lstOccupation = new OccupationBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstOccupation.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstOccupation)
                    {
                        xlHoja.Cells[Row, 1] = item.IdOccupation;
                        xlHoja.Cells[Row, 2] = item.NameOccupation;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Occupation.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Occupation.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Occupation.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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