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
using ERP.Presentacion.Funciones;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EmployeeBE> mLista = new List<EmployeeBE>();

        int IdCompany = 0;
        int IdWorkArea = 0;

        #endregion

        #region "Eventos"

        public frmManPersona()
        {
            InitializeComponent();
        }

        private void frmManPersona_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdCompany==0)
                {
                    XtraMessageBox.Show("Select a company.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdWorkArea == 0)
                {
                    XtraMessageBox.Show("Select work area.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmManPersonaEdit objManPersona = new frmManPersonaEdit();
                objManPersona.lstPersona = mLista;
                objManPersona.pOperacion = frmManPersonaEdit.Operacion.Nuevo;
                objManPersona.IdWorkArea = IdWorkArea;
                objManPersona.IdEmployee = 0;
                objManPersona.StartPosition = FormStartPosition.CenterParent;
                objManPersona.ShowDialog();
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
                        EmployeeBE objE_Persona = new EmployeeBE();
                        objE_Persona.IdEmployee = int.Parse(gvPersona.GetFocusedRowCellValue("IdEmployee").ToString());
                        objE_Persona.Login = Parametros.strUsuarioLogin;
                        objE_Persona.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Persona.IdCompany = Parametros.intEmpresaId;

                        EmployeeBL objBL_Area = new EmployeeBL();
                        objBL_Area.Elimina(objE_Persona);
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

            //    List<ReporteEmployeeBE> lstReporte = null;
            //    lstReporte = new ReporteEmployeeBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPersona = new RptVistaReportes();
            //            objRptPersona.VerRptPersona(lstReporte);
            //            objRptPersona.ShowDialog();
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

        private void gvPersona_DoubleClick(object sender, EventArgs e)
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

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            Cursor = Cursors.WaitCursor;

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    IdCompany = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    IdWorkArea = 0;
                    Cargar();
                    break;
                case "ARE":
                    IdWorkArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }

            Cursor = Cursors.Default;

        }

        private void gvPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "NameSituation")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["NameSituation"]);
                        if (Situacion == "ACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "CEASED")
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

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<CompanyBE> lstEmpresa = null;
            lstEmpresa = new CompanyBL().ListaTodosActivo(0);
            foreach (var item in lstEmpresa)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.NameCompany;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = "EMP" + item.IdCompany.ToString();
                tvwDatos.Nodes.Add(nuevoNodo);

                List<WorkAreaBE> lstWorkArea = null;
                lstWorkArea = new WorkAreaBL().ListaTodosActivo(item.IdCompany);
                foreach (var itemarea in lstWorkArea)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 2;
                    nuevoNodoChild.SelectedImageIndex = 2;
                    nuevoNodoChild.Text = itemarea.NameWorkArea;
                    nuevoNodoChild.Tag = "ARE" + itemarea.IdWorkArea.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        
        
        private void Cargar()
        {
            mLista = new EmployeeBL().ListaTodosActivo(IdCompany,IdWorkArea);
            gcPersona.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPersona.DataSource = mLista.Where(obj =>
                                                   obj.FullName.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPersona.RowCount > 0)
            {
                EmployeeBE objEmployee = new EmployeeBE();
                objEmployee.IdCompany = int.Parse(gvPersona.GetFocusedRowCellValue("IdCompany").ToString());
                objEmployee.IdWorkArea = int.Parse(gvPersona.GetFocusedRowCellValue("IdWorkArea").ToString());
                objEmployee.IdEmployee = int.Parse(gvPersona.GetFocusedRowCellValue("IdEmployee").ToString());

                frmManPersonaEdit objManPersonaEdit = new frmManPersonaEdit();
                objManPersonaEdit.pOperacion = frmManPersonaEdit.Operacion.Modificar;

               
                objManPersonaEdit.IdWorkArea = objEmployee.IdWorkArea;
                objManPersonaEdit.IdEmployee = objEmployee.IdEmployee;
                objManPersonaEdit.pEmployeeBE = objEmployee;
                objManPersonaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPersonaEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("Edist");
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

            if (gvPersona.GetFocusedRowCellValue("IdEmployee").ToString() == "")
            {
                XtraMessageBox.Show("Select a employee.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Employee.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<EmployeeBE> lstEmployee = null;
                lstEmployee = new EmployeeBL().ListaTodosActivo(Parametros.intEmpresaId,0);
                if (lstEmployee.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstEmployee)
                    {
                        xlHoja.Cells[Row, 1] = item.IdEmployee;
                        xlHoja.Cells[Row, 2] = item.DocumentNumber;
                        xlHoja.Cells[Row, 3] = item.NameGender;
                        xlHoja.Cells[Row, 4] = item.NameStateCivil;
                        xlHoja.Cells[Row, 5] = item.FullName;
                        xlHoja.Cells[Row, 6] = BSUtils.GetDateFormat(item.BithDate);
                        xlHoja.Cells[Row, 7] = item.NameWorkArea;
                        xlHoja.Cells[Row, 8] = item.NameOccupation;
                        xlHoja.Cells[Row, 9] = item.Address;
                        xlHoja.Cells[Row, 10] = item.NomDist;
                        xlHoja.Cells[Row, 11] = item.Phone;
                        xlHoja.Cells[Row, 12] = item.CelPhone1;
                        xlHoja.Cells[Row, 13] = item.Email;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Employee.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Employee.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Employee.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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