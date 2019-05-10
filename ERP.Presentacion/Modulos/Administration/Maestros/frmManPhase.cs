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
    public partial class frmManPhase : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PhaseBE> mLista = new List<PhaseBE>();

        #endregion

        #region "Eventos"

        public frmManPhase()
        {
            InitializeComponent();
        }

        private void frmManPhase_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPhaseEdit objManPhase = new frmManPhaseEdit();
                objManPhase.lstPhase = mLista;
                objManPhase.pOperacion = frmManPhaseEdit.Operacion.Nuevo;
                objManPhase.IdPhase = 0;
                objManPhase.StartPosition = FormStartPosition.CenterParent;
                objManPhase.ShowDialog();
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
                        PhaseBE objE_Phase = new PhaseBE();
                        objE_Phase.IdPhase = int.Parse(gvPhase.GetFocusedRowCellValue("IdPhase").ToString());
                        objE_Phase.Login = Parametros.strUsuarioLogin;
                        objE_Phase.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Phase.IdCompany = Parametros.intEmpresaId;

                        PhaseBL objBL_Phase = new PhaseBL();
                        objBL_Phase.Elimina(objE_Phase);
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

            //    List<ReportePhaseElementoBE> lstReporte = null;
            //    lstReporte = new ReportePhaseElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPhaseElemento = new RptVistaReportes();
            //            objRptPhaseElemento.VerRptPhaseElemento(lstReporte);
            //            objRptPhaseElemento.ShowDialog();
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

        private void gvPhase_DoubleClick(object sender, EventArgs e)
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

        private void gvPhase_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new PhaseBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcPhase.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPhase.DataSource = mLista.Where(obj =>
                                                   obj.NamePhase.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPhase.RowCount > 0)
            {
                PhaseBE objPhase = new PhaseBE();
               
                objPhase.IdPhase = int.Parse(gvPhase.GetFocusedRowCellValue("IdPhase").ToString());

                frmManPhaseEdit objManPhaseEdit = new frmManPhaseEdit();
                objManPhaseEdit.pOperacion = frmManPhaseEdit.Operacion.Modificar;
                objManPhaseEdit.IdPhase = objPhase.IdPhase;
                objManPhaseEdit.pPhaseBE = objPhase;
                objManPhaseEdit.StartPosition = FormStartPosition.CenterParent;
                objManPhaseEdit.ShowDialog();

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

            if (gvPhase.GetFocusedRowCellValue("IdPhase").ToString() == "")
            {
                XtraMessageBox.Show("Select a work Phase", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Phase.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<PhaseBE> lstPhase = null;
                lstPhase = new PhaseBL().ListaTodosActivo(Parametros.intEmpresaId);
                if (lstPhase.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstPhase)
                    {
                        xlHoja.Cells[Row, 1] = item.IdPhase;
                        xlHoja.Cells[Row, 2] = item.NamePhase;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Phase.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Phase.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Phase.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
