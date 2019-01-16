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

namespace ERP.Presentacion.Modulos.Invoices.Maestros
{
    public partial class frmManTypeCertificate : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TypeCertificateBE> mLista = new List<TypeCertificateBE>();

        #endregion

        #region "Eventos"

        public frmManTypeCertificate()
        {
            InitializeComponent();
        }

        private void frmManTypeCertificate_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTypeCertificateEdit objManTypeCertificate = new frmManTypeCertificateEdit();
                objManTypeCertificate.lstTypeCertificate = mLista;
                objManTypeCertificate.pOperacion = frmManTypeCertificateEdit.Operacion.Nuevo;
                objManTypeCertificate.IdTypeCertificate = 0;
                objManTypeCertificate.StartPosition = FormStartPosition.CenterParent;
                objManTypeCertificate.ShowDialog();
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
                        TypeCertificateBE objE_TypeCertificate = new TypeCertificateBE();
                        objE_TypeCertificate.IdTypeCertificate = int.Parse(gvTypeCertificate.GetFocusedRowCellValue("IdTypeCertificate").ToString());
                        objE_TypeCertificate.Login = Parametros.strUsuarioLogin;
                        objE_TypeCertificate.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TypeCertificate.IdCompany = Parametros.intEmpresaId;

                        TypeCertificateBL objBL_TypeCertificate = new TypeCertificateBL();
                        objBL_TypeCertificate.Elimina(objE_TypeCertificate);
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

            //    List<ReporteTypeCertificateElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTypeCertificateElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTypeCertificateElemento = new RptVistaReportes();
            //            objRptTypeCertificateElemento.VerRptTypeCertificateElemento(lstReporte);
            //            objRptTypeCertificateElemento.ShowDialog();
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

        private void gvTypeCertificate_DoubleClick(object sender, EventArgs e)
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

        private void gvTypeCertificate_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new TypeCertificateBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTypeCertificate.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTypeCertificate.DataSource = mLista.Where(obj =>
                                                   obj.NameTypeCertificate.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTypeCertificate.RowCount > 0)
            {
                TypeCertificateBE objTypeCertificate = new TypeCertificateBE();
               
                objTypeCertificate.IdTypeCertificate = int.Parse(gvTypeCertificate.GetFocusedRowCellValue("IdTypeCertificate").ToString());

                frmManTypeCertificateEdit objManTypeCertificateEdit = new frmManTypeCertificateEdit();
                objManTypeCertificateEdit.pOperacion = frmManTypeCertificateEdit.Operacion.Modificar;
                objManTypeCertificateEdit.IdTypeCertificate = objTypeCertificate.IdTypeCertificate;
                objManTypeCertificateEdit.pTypeCertificateBE = objTypeCertificate;
                objManTypeCertificateEdit.StartPosition = FormStartPosition.CenterParent;
                objManTypeCertificateEdit.ShowDialog();

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

            if (gvTypeCertificate.GetFocusedRowCellValue("IdTypeCertificate").ToString() == "")
            {
                XtraMessageBox.Show("Select a work TypeCertificate", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\TypeCertificate.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<TypeCertificateBE> lstTypeCertificate = null;
                lstTypeCertificate = new TypeCertificateBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstTypeCertificate.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstTypeCertificate)
                    {
                        xlHoja.Cells[Row, 1] = item.IdTypeCertificate;
                        xlHoja.Cells[Row, 2] = item.NameTypeCertificate;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\TypeCertificate.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\TypeCertificate.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
