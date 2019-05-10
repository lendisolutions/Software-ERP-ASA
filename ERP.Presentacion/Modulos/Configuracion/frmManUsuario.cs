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
    public partial class frmManUsuario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<LoginBE> mLista = new List<LoginBE>();

        #endregion

        #region "Eventos"

        public frmManUsuario()
        {
            InitializeComponent();
        }

        private void frmManUsuarios_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManUsuarioEdit objManUsuario = new frmManUsuarioEdit();
                objManUsuario.pOperacion = frmManUsuarioEdit.Operacion.Nuevo;
                objManUsuario.IdLogin = 0;
                objManUsuario.StartPosition = FormStartPosition.CenterParent;
                objManUsuario.ShowDialog();
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
                        LoginBE objE_Usuario = new LoginBE();
                        objE_Usuario.IdLogin = int.Parse(gvUsuario.GetFocusedRowCellValue("IdLogin").ToString());
                        objE_Usuario.Login = Parametros.strUsuarioLogin;
                        objE_Usuario.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Usuario.IdCompany = Parametros.intEmpresaId;

                        LoginBL objBL_Usuario = new LoginBL();
                        objBL_Usuario.Elimina(objE_Usuario);
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

            //    List<ReporteAccesoLoginBE> lstReporte = null;
            //    lstReporte = new ReporteAccesoLoginBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAccesoUsuario = new RptVistaReportes();
            //            objRptAccesoUsuario.VerRptAccesoUsuario(lstReporte);
            //            objRptAccesoUsuario.ShowDialog();
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

        private void gvUSuario_DoubleClick(object sender, EventArgs e)
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
            mLista =  new LoginBL().ListaTodosActivo();
            gcUsuario.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUsuario.DataSource = mLista.Where(obj =>
                                                   obj.Login.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.Login.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvUsuario.RowCount > 0)
            {
                LoginBE objUsuario = new LoginBE();
                objUsuario.IdLogin = int.Parse(gvUsuario.GetFocusedRowCellValue("IdLogin").ToString());
                objUsuario.IdCompany = int.Parse(gvUsuario.GetFocusedRowCellValue("IdCompany").ToString());
                objUsuario.IdProfile = int.Parse(gvUsuario.GetFocusedRowCellValue("IdProfile").ToString());
                objUsuario.NameLogin = gvUsuario.GetFocusedRowCellValue("NameLogin").ToString();
                objUsuario.IdEmployee = int.Parse(gvUsuario.GetFocusedRowCellValue("IdEmployee").ToString());
                objUsuario.Login = gvUsuario.GetFocusedRowCellValue("Login").ToString();
                objUsuario.Password = gvUsuario.GetFocusedRowCellValue("Password").ToString();
                objUsuario.FlagMaster = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagMaster").ToString());
                objUsuario.FlagState = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagState").ToString());

                frmManUsuarioEdit objManUsuarioEdit = new frmManUsuarioEdit();
                objManUsuarioEdit.pOperacion = frmManUsuarioEdit.Operacion.Modificar;
                objManUsuarioEdit.IdLogin = objUsuario.IdLogin;
                objManUsuarioEdit.IdProfile = objUsuario.IdProfile;
                objManUsuarioEdit.pLoginBE = objUsuario;
                objManUsuarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManUsuarioEdit.ShowDialog();

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

            if (gvUsuario.GetFocusedRowCellValue("IdLogin").ToString() == "")
            {
                XtraMessageBox.Show("Select a Login", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Login.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<LoginBE> lstLogin = null;
                lstLogin = new LoginBL().ListaTodosActivo();
                if (lstLogin.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstLogin)
                    {
                        xlHoja.Cells[Row, 1] = item.IdLogin;
                        xlHoja.Cells[Row, 2] = item.NameProfile;
                        xlHoja.Cells[Row, 3] = item.Login;
                        xlHoja.Cells[Row, 4] = item.NameLogin;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Login.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Login.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Login.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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