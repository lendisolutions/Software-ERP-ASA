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

namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegClient : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ClientBE> mLista = new List<ClientBE>();

        #endregion

        #region "Metodos"

        public frmRegClient()
        {
            InitializeComponent();
        }

        private void frmRegClient_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegClientEdit objManClient = new frmRegClientEdit();
                objManClient.lstClient = mLista;
                objManClient.pOperacion = frmRegClientEdit.Operacion.Nuevo;
                objManClient.IdClient = 0;
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
                if (XtraMessageBox.Show("Be sure to delete the record.?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ClientBE objE_Client = new ClientBE();
                        objE_Client.IdClient = int.Parse(gvClient.GetFocusedRowCellValue("IdClient").ToString());
                        objE_Client.Login = Parametros.strUsuarioLogin;
                        objE_Client.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Client.IdCompany = Parametros.intEmpresaId;

                        ClientBL objBL_Client = new ClientBL();
                        objBL_Client.Elimina(objE_Client);
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

        private void gvClient_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void gvClient_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
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

        #endregion

        #region "Eventos"

        private void Cargar()
        {
            mLista = new ClientBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcClient.DataSource = mLista;
        }


        private void CargarBusqueda()
        {
            gcClient.DataSource = mLista.Where(obj =>
                                                   obj.NameClient.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvClient.RowCount > 0)
            {
                ClientBE objClient = new ClientBE();

                objClient.IdClient = int.Parse(gvClient.GetFocusedRowCellValue("IdClient").ToString());

                frmRegClientEdit objManClientEdit = new frmRegClientEdit();
                objManClientEdit.pOperacion = frmRegClientEdit.Operacion.Modificar;
                objManClientEdit.IdClient = objClient.IdClient;
                objManClientEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientEdit.ShowDialog();

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

            if (gvClient.GetFocusedRowCellValue("IdClient").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Client", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Client.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<ClientBE> lstClient = null;
                lstClient = new ClientBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstClient.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstClient)
                    {
                        xlHoja.Cells[Row, 1] = item.IdClient;
                        xlHoja.Cells[Row, 2] = item.NameClient;
                        xlHoja.Cells[Row, 3] = BSUtils.GetDateFormat(item.RevenueDate);
                        xlHoja.Cells[Row, 4] = item.Certificate;
                        xlHoja.Cells[Row, 5] = item.Situation;
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Client.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Client.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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