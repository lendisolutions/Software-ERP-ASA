using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
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
using ERP.Presentacion.Funciones;
using ERP.Presentacion.Utils;

namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegStyle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StyleBE> mLista = new List<StyleBE>();

        int IdCompany = 0;
        int IdClient = 0;

        string strFleExcel = "";

        #endregion

        #region "Eventos"

        public frmRegStyle()
        {
            InitializeComponent();
        }

        private void frmRegStyle_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdCompany == 0)
                {
                    XtraMessageBox.Show("Select a company.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdClient == 0)
                {
                    XtraMessageBox.Show("Select client.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmRegStyleEdit objRegStyle = new frmRegStyleEdit();
                objRegStyle.lstStyle = mLista;
                objRegStyle.pOperacion = frmRegStyleEdit.Operacion.Nuevo;
                objRegStyle.IdClient = IdClient;
                objRegStyle.IdStyle = 0;
                objRegStyle.StartPosition = FormStartPosition.CenterParent;
                objRegStyle.ShowDialog();
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
                        for (int i = 0; i < gvStyle.SelectedRowsCount; i++)
                        {
                            int row = gvStyle.GetSelectedRows()[i];

                            StyleBE objE_Style = new StyleBE();
                            objE_Style.IdStyle = int.Parse(gvStyle.GetRowCellValue(row,"IdStyle").ToString());
                            objE_Style.Login = Parametros.strUsuarioLogin;
                            objE_Style.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Style.IdCompany = Parametros.intEmpresaId;

                            StyleBL objBL_Area = new StyleBL();
                            objBL_Area.Elimina(objE_Style);
                            
                            
                        }


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

            //    List<ReporteStyleBE> lstReporte = null;
            //    lstReporte = new ReporteStyleBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptStyle = new RptVistaReportes();
            //            objRptStyle.VerRptStyle(lstReporte);
            //            objRptStyle.ShowDialog();
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

        private void gvStyle_DoubleClick(object sender, EventArgs e)
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
                    break;
                case "ARE":
                    IdClient = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }

            Cursor = Cursors.Default;

        }

        private void gvStyle_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

                List<LoginClientDepartmentBE> lstClient = null;
                lstClient = new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId);
                foreach (var itemclient in lstClient)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemclient.NameClient;
                    nuevoNodoChild.Tag = "ARE" + itemclient.IdClient.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.SelectedNode = tvwDatos.Nodes[0];
            tvwDatos.Select();

            tvwDatos.ExpandAll();

            
        }

        private void Cargar()
        {
            mLista = new StyleBL().ListaTodosActivo(IdCompany, IdClient,0);
            gcStyle.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcStyle.DataSource = mLista.Where(obj => obj.NameStyle.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.Description.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvStyle.RowCount > 0)
            {
                StyleBE objStyle = new StyleBE();
                objStyle.IdCompany = int.Parse(gvStyle.GetFocusedRowCellValue("IdCompany").ToString());
                objStyle.IdClient = int.Parse(gvStyle.GetFocusedRowCellValue("IdClient").ToString());
                objStyle.IdStyle = int.Parse(gvStyle.GetFocusedRowCellValue("IdStyle").ToString());

                frmRegStyleEdit objRegStyleEdit = new frmRegStyleEdit();
                objRegStyleEdit.pOperacion = frmRegStyleEdit.Operacion.Modificar;


                objRegStyleEdit.IdClient = objStyle.IdClient;
                objRegStyleEdit.IdStyle = objStyle.IdStyle;
                objRegStyleEdit.pStyleBE = objStyle;
                objRegStyleEdit.StartPosition = FormStartPosition.CenterParent;
                objRegStyleEdit.ShowDialog();

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

            if (gvStyle.GetFocusedRowCellValue("IdStyle").ToString() == "")
            {
                XtraMessageBox.Show("Select a Style.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Style.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<StyleBE> lstStyle = null;
                lstStyle = new StyleBL().ListaTodosActivo(Parametros.intEmpresaId, IdClient,0);
                if (lstStyle.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

                    foreach (var item in lstStyle)
                    {
                        xlHoja.Cells[Row, 1] = item.IdStyle;
                        xlHoja.Cells[Row, 2] = item.NameClient;
                        xlHoja.Cells[Row, 3] = item.NameStyle;
                        xlHoja.Cells[Row, 4] = item.Description;
                        xlHoja.Cells[Row, 5] = BSUtils.GetDateFormat(item.RevenueDate);
                        xlHoja.Cells[Row, 6] = item.MameDivision;
                        xlHoja.Cells[Row, 7] = item.NameMediaUnit;
                        xlHoja.Cells[Row, 8] = item.Situation;
                        
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Style.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Style.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            strFleExcel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xls;*.xlsx";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFleExcel = objOpenFileDialog.FileName;
                ImportarExcel();
            }
        }

        private void ImportarExcel()
        {
            if (strFleExcel == "")
            {
                return;
            }

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(strFleExcel, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];
            int Secuencia = 2;
            int _row = 2;
            int _totRow = 2;

            try
            {

                List<StyleBE> lstStyle = new List<StyleBE>();

                while (FuncionBase.IsNumeric((string)xlHoja.get_Range("A" + _row, Missing.Value).Text.ToString().Trim()))
                {
                    //Declaracion de variables

                    int IdCompany = 0;
                    int intIdClient = 0;
                    string strNameClient = "";
                    string strNameStyle = "";
                    DateTime RevenueDate = new DateTime(2010, 1, 1);
                    string strDescription = "";
                    int intIdClientDepartment = 0;
                    string strNameDivision = "";
                    int IdMediaUnit = 0;
                    string strAbbreviate = "";

                    strNameClient = (string)xlHoja.get_Range("B" + _row, Missing.Value).Text.ToString().Trim();
                    ClientBE objE_Client = null;
                    objE_Client = new ClientBL().SeleccionaDescripcion(Parametros.intEmpresaId,strNameClient);
                    if (objE_Client != null)
                    {
                        intIdClient = objE_Client.IdClient;
                        strNameStyle = (string)xlHoja.get_Range("C" + _row, Missing.Value).Text.ToString().Trim();
                        RevenueDate = Convert.ToDateTime(xlHoja.get_Range("D" + _row, Missing.Value).Text.ToString().Trim());
                        strDescription = (string)xlHoja.get_Range("E" + _row, Missing.Value).Text.ToString().Trim();
                        strNameDivision = (string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim();
                        ClientDepartmentBE objE_ClientDepartment = null;
                        objE_ClientDepartment = new ClientDepartmentBL().SeleccionaDescripcion(intIdClient, strNameDivision);
                        if (objE_ClientDepartment != null)
                        {
                            intIdClientDepartment = objE_ClientDepartment.IdClientDepartment;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Division: " + strNameDivision, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xlLibro.Close(false, Missing.Value, Missing.Value);
                            xlApp.Quit();
                            this.Dispose();
                            this.Close();
                        }

                        strAbbreviate = (string)xlHoja.get_Range("G" + _row, Missing.Value).Text.ToString().Trim();

                        MediaUnitBE objE_MediaUnit = null;
                        objE_MediaUnit = new MediaUnitBL().SeleccionaAbreviatura(Parametros.intEmpresaId, strAbbreviate);
                        if (objE_MediaUnit != null)
                        {
                            IdMediaUnit = objE_MediaUnit.IdMediaUnit;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Media Unit: " + strAbbreviate, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xlLibro.Close(false, Missing.Value, Missing.Value);
                            xlApp.Quit();
                            this.Dispose();
                            this.Close();
                        }

                        StyleBE objE_Style = new StyleBE();
                        objE_Style.IdStyle = 0;
                        objE_Style.IdCompany = Parametros.intEmpresaId;
                        objE_Style.IdClient = intIdClient;
                        objE_Style.NameStyle = strNameStyle;
                        objE_Style.RevenueDate = RevenueDate;
                        objE_Style.Description = strDescription;
                        objE_Style.IdClientDepartment = intIdClientDepartment;
                        objE_Style.IdMediaUnit = IdMediaUnit;
                        objE_Style.FlagState = true;
                        objE_Style.Login = Parametros.strUsuarioLogin;
                        objE_Style.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                        lstStyle.Add(objE_Style);

                    }

                    Application.DoEvents();
                    _row++;
                    Secuencia++;

                }

                StyleBL objBL_Style = new StyleBL();
                objBL_Style.InsertaMasivo(lstStyle);
                XtraMessageBox.Show("Los Datos se guardaron conrrectamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                this.Close();
            }
            catch (Exception ex)
            {

                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "\n N° Secuencia : " + Secuencia.ToString(), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

    }
}