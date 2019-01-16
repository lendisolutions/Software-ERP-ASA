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

namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegVendor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<VendorBE> mLista = new List<VendorBE>();

        #endregion

        #region "Eventos"

        public frmRegVendor()
        {
            InitializeComponent();
        }

        private void frmRegVendor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            gvVendor.Columns["RevenueDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvVendor.Columns["RevenueDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            Cargar();
        }

        #endregion

        #region "Metodos"

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegVendorEdit objManVendor = new frmRegVendorEdit();
                objManVendor.lstVendor = mLista;
                objManVendor.pOperacion = frmRegVendorEdit.Operacion.Nuevo;
                objManVendor.IdVendor = 0;
                objManVendor.StartPosition = FormStartPosition.CenterParent;
                objManVendor.ShowDialog();
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
                        VendorBE objE_Vendor = new VendorBE();
                        objE_Vendor.IdVendor = int.Parse(gvVendor.GetFocusedRowCellValue("IdVendor").ToString());
                        objE_Vendor.Login = Parametros.strUsuarioLogin;
                        objE_Vendor.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Vendor.IdCompany = Parametros.intEmpresaId;

                        VendorBL objBL_Vendor = new VendorBL();
                        objBL_Vendor.Elimina(objE_Vendor);
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

            //    List<ReporteVendorElementoBE> lstReporte = null;
            //    lstReporte = new ReporteVendorElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptVendorElemento = new RptVistaReportes();
            //            objRptVendorElemento.VerRptVendorElemento(lstReporte);
            //            objRptVendorElemento.ShowDialog();
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

        private void gvVendor_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void gvVendor_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Status")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]);
                        if (Situacion == "ACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "INACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }

                    }
                    if (e.Column.FieldName == "Situation")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situation"]);
                        if (Situacion == "ACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "INACTIVE")
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

        private void Cargar()
        {
            mLista = new VendorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcVendor.DataSource = mLista;
        }


        private void CargarBusqueda()
        {
            gcVendor.DataSource = mLista.Where(obj =>
                                                   obj.NameVendor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvVendor.RowCount > 0)
            {
                VendorBE objVendor = new VendorBE();

                objVendor.IdVendor = int.Parse(gvVendor.GetFocusedRowCellValue("IdVendor").ToString());

                frmRegVendorEdit objManVendorEdit = new frmRegVendorEdit();
                objManVendorEdit.pOperacion = frmRegVendorEdit.Operacion.Modificar;
                objManVendorEdit.IdVendor = objVendor.IdVendor;
                objManVendorEdit.StartPosition = FormStartPosition.CenterParent;
                objManVendorEdit.ShowDialog();

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

            if (gvVendor.GetFocusedRowCellValue("IdVendor").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Vendor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Vendor.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<VendorBE> lstVendor = null;
                lstVendor = new VendorBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstVendor.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstVendor)
                    {
                        xlHoja.Cells[Row, 1] = item.IdVendor;
                        xlHoja.Cells[Row, 2] = item.Ruc;
                        xlHoja.Cells[Row, 3] = item.NameVendor;
                        xlHoja.Cells[Row, 4] = BSUtils.GetDateFormat(item.RevenueDate);
                        xlHoja.Cells[Row, 5] = item.Representative;
                        xlHoja.Cells[Row, 6] = item.Situation;
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Vendor.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Vendor.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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