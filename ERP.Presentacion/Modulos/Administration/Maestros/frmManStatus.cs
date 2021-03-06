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
    public partial class frmManStatus : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StatusBE> mLista = new List<StatusBE>();

        #endregion

        #region "Eventos"

        public frmManStatus()
        {
            InitializeComponent();
        }

        private void frmManStatus_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManStatusEdit objManStatus = new frmManStatusEdit();
                objManStatus.lstStatus = mLista;
                objManStatus.pOperacion = frmManStatusEdit.Operacion.Nuevo;
                objManStatus.IdStatus = 0;
                objManStatus.StartPosition = FormStartPosition.CenterParent;
                objManStatus.ShowDialog();
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
                        StatusBE objE_Status = new StatusBE();
                        objE_Status.IdStatus = int.Parse(gvStatus.GetFocusedRowCellValue("IdStatus").ToString());
                        objE_Status.Login = Parametros.strUsuarioLogin;
                        objE_Status.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Status.IdCompany = Parametros.intEmpresaId;

                        StatusBL objBL_Status = new StatusBL();
                        objBL_Status.Elimina(objE_Status);
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

            //    List<ReporteStatusElementoBE> lstReporte = null;
            //    lstReporte = new ReporteStatusElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptStatusElemento = new RptVistaReportes();
            //            objRptStatusElemento.VerRptStatusElemento(lstReporte);
            //            objRptStatusElemento.ShowDialog();
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

        private void gvStatus_DoubleClick(object sender, EventArgs e)
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

        private void gvStatus_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new StatusBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcStatus.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcStatus.DataSource = mLista.Where(obj =>
                                                   obj.NameStatus.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvStatus.RowCount > 0)
            {
                StatusBE objStatus = new StatusBE();
               
                objStatus.IdStatus = int.Parse(gvStatus.GetFocusedRowCellValue("IdStatus").ToString());

                frmManStatusEdit objManStatusEdit = new frmManStatusEdit();
                objManStatusEdit.pOperacion = frmManStatusEdit.Operacion.Modificar;
                objManStatusEdit.IdStatus = objStatus.IdStatus;
                objManStatusEdit.pStatusBE = objStatus;
                objManStatusEdit.StartPosition = FormStartPosition.CenterParent;
                objManStatusEdit.ShowDialog();

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

            if (gvStatus.GetFocusedRowCellValue("IdStatus").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Status", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Status.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<StatusBE> lstStatus = null;
                lstStatus = new StatusBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstStatus.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstStatus)
                    {
                        xlHoja.Cells[Row, 1] = item.IdStatus;
                        xlHoja.Cells[Row, 2] = item.NameStatus;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Status.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Status.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Status.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
