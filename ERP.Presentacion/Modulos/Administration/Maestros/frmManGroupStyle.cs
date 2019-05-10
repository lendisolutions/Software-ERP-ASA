﻿using System;
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
    public partial class frmManGroupStyle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<GroupStyleBE> mLista = new List<GroupStyleBE>();

        #endregion

        #region "Eventos"

        public frmManGroupStyle()
        {
            InitializeComponent();
        }

        private void frmManGroupStyle_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManGroupStyleEdit objManGroupStyle = new frmManGroupStyleEdit();
                objManGroupStyle.lstGroupStyle = mLista;
                objManGroupStyle.pOperacion = frmManGroupStyleEdit.Operacion.Nuevo;
                objManGroupStyle.IdGroupStyle = 0;
                objManGroupStyle.StartPosition = FormStartPosition.CenterParent;
                objManGroupStyle.ShowDialog();
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
                        GroupStyleBE objE_GroupStyle = new GroupStyleBE();
                        objE_GroupStyle.IdGroupStyle = int.Parse(gvGroupStyle.GetFocusedRowCellValue("IdGroupStyle").ToString());
                        objE_GroupStyle.Login = Parametros.strUsuarioLogin;
                        objE_GroupStyle.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_GroupStyle.IdCompany = Parametros.intEmpresaId;

                        GroupStyleBL objBL_GroupStyle = new GroupStyleBL();
                        objBL_GroupStyle.Elimina(objE_GroupStyle);
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

            //    List<ReporteGroupStyleElementoBE> lstReporte = null;
            //    lstReporte = new ReporteGroupStyleElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptGroupStyleElemento = new RptVistaReportes();
            //            objRptGroupStyleElemento.VerRptGroupStyleElemento(lstReporte);
            //            objRptGroupStyleElemento.ShowDialog();
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

        private void gvGroupStyle_DoubleClick(object sender, EventArgs e)
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

        private void gvGroupStyle_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new GroupStyleBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcGroupStyle.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcGroupStyle.DataSource = mLista.Where(obj =>
                                                   obj.NameGroupStyle.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvGroupStyle.RowCount > 0)
            {
                GroupStyleBE objGroupStyle = new GroupStyleBE();
               
                objGroupStyle.IdGroupStyle = int.Parse(gvGroupStyle.GetFocusedRowCellValue("IdGroupStyle").ToString());

                frmManGroupStyleEdit objManGroupStyleEdit = new frmManGroupStyleEdit();
                objManGroupStyleEdit.pOperacion = frmManGroupStyleEdit.Operacion.Modificar;
                objManGroupStyleEdit.IdGroupStyle = objGroupStyle.IdGroupStyle;
                objManGroupStyleEdit.pGroupStyleBE = objGroupStyle;
                objManGroupStyleEdit.StartPosition = FormStartPosition.CenterParent;
                objManGroupStyleEdit.ShowDialog();

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

            if (gvGroupStyle.GetFocusedRowCellValue("IdGroupStyle").ToString() == "")
            {
                XtraMessageBox.Show("Select a work GroupStyle", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\GroupStyle.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<GroupStyleBE> lstGroupStyle = null;
                lstGroupStyle = new GroupStyleBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstGroupStyle.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstGroupStyle)
                    {
                        xlHoja.Cells[Row, 1] = item.IdGroupStyle;
                        xlHoja.Cells[Row, 2] = item.NameGroupStyle;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\GroupStyle.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\GroupStyle.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\GroupStyle.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
