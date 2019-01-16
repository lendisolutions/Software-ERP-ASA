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

namespace ERP.Presentacion.Modulos.Production.Consultas
{
    public partial class frmConProductionProgramExpired : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProgramProductionBE> mLista = new List<ProgramProductionBE>();

        #endregion

        #region "Eventos"

        public frmConProductionProgramExpired()
        {
            InitializeComponent();
            gcIndcDate.Caption = "INDC\nDate";
            gcTypeProduct.Caption = "Type\nProduct";
            gcDays.Caption = "Days\n To Beat";
        }

        private void frmConProductionProgramExpired_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            deRevenueDateFrom.DateTime = DateTime.Now;
            deRevenueDateTo.DateTime = DateTime.Now;

            deRevenueDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deRevenueDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProduction.Columns["IndcDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProduction.Columns["IndcDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                BSUtils.LoaderLook(cboDivision, new LoginClientDepartmentBL().ListaClientDivision(Parametros.intUsuarioId, Convert.ToInt32(cboClient.EditValue)), "NameDivision", "IdClientDepartment", true);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvProgramProduction_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle == View.FocusedRowHandle)
            {
                e.Appearance.Assign(View.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }

            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "Situation")
                {
                    string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situation"]);
                    if (Situacion == "TO BEAT")
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (Situacion == "BEATEN")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    
                }
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel("");
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            if (chkClient.Checked && chkDivision.Checked && chkXfDate.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionXfDateVencimiento(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;

            }

            if (chkClient.Checked && chkXfDate.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionXfDateVencimiento(Parametros.intEmpresaId, 0, Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;

            }

            if (chkClient.Checked && chkDivision.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivision(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberPO.Checked)
            {
                mLista = new ProgramProductionBL().ListaNumberPOVencimiento(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text);
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionVencimiento(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0);
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }
            
            
     
            Cursor = Cursors.Default;
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ProductionProgramExpired.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                xlHoja.Cells[4, 2] = cboClient.Text;

                for (int i = 0; i < gvProgramProduction.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = gvProgramProduction.GetRowCellValue(i, "NumberPO").ToString();
                    xlHoja.Cells[Row, 2] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProduction.GetRowCellValue(i, "XfDate").ToString()));
                    xlHoja.Cells[Row, 3] = gvProgramProduction.GetRowCellValue(i, "NameDivision").ToString();
                    xlHoja.Cells[Row, 4] = gvProgramProduction.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 5] = gvProgramProduction.GetRowCellValue(i, "NameStyle").ToString();
                    xlHoja.Cells[Row, 6] = gvProgramProduction.GetRowCellValue(i, "Description").ToString();
                    xlHoja.Cells[Row, 7] = gvProgramProduction.GetRowCellValue(i, "Item").ToString();
                    xlHoja.Cells[Row, 8] = gvProgramProduction.GetRowCellValue(i, "Detail").ToString();
                    xlHoja.Cells[Row, 9] = gvProgramProduction.GetRowCellValue(i, "Units").ToString();
                    xlHoja.Cells[Row, 10] = gvProgramProduction.GetRowCellValue(i, "Fob").ToString();
                    xlHoja.Cells[Row, 11] = gvProgramProduction.GetRowCellValue(i, "Total").ToString();
                    xlHoja.Cells[Row, 12] = gvProgramProduction.GetRowCellValue(i, "NumberCommiment").ToString();
                    xlHoja.Cells[Row, 13] = gvProgramProduction.GetRowCellValue(i, "Label").ToString();
                    xlHoja.Cells[Row, 14] = gvProgramProduction.GetRowCellValue(i, "NameDestination").ToString();
                    xlHoja.Cells[Row, 15] = gvProgramProduction.GetRowCellValue(i, "NameSeason").ToString();
                    xlHoja.Cells[Row, 16] = gvProgramProduction.GetRowCellValue(i, "NameTypeProduct").ToString();
                    xlHoja.Cells[Row, 17] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProduction.GetRowCellValue(i, "IndcDate").ToString()));
                    xlHoja.Cells[Row, 18] = gvProgramProduction.GetRowCellValue(i, "NameShipMode").ToString();
                    xlHoja.Cells[Row, 19] = gvProgramProduction.GetRowCellValue(i, "Days").ToString();
                    xlHoja.Cells[Row, 20] = gvProgramProduction.GetRowCellValue(i, "Situation").ToString();
                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }


                xlLibro.SaveAs("C:\\Excel\\ProductionProgramExpired.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\ProductionProgramExpired.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\ProductionProgramExpired.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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