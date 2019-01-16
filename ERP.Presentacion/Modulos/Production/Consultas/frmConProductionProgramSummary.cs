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
using DevExpress.XtraGrid.Columns;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Consultas
{
    public partial class frmConProductionProgramSummary : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        private List<ProgramProductionBE> mLista = new List<ProgramProductionBE>();


        #endregion

        #region "Eventos"

        public frmConProductionProgramSummary()
        {
            InitializeComponent();
        }

        private void frmConProductionProgramSummary_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);

            deRevenueDateFrom.DateTime = DateTime.Now;
            deRevenueDateTo.DateTime = DateTime.Now;
            deIndcDateFrom.DateTime = DateTime.Now;
            deIndcDateTo.DateTime = DateTime.Now;

            deRevenueDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deRevenueDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            deIndcDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIndcDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIndcDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIndcDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deIndcDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIndcDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIndcDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIndcDateTo.Properties.CharacterCasing = CharacterCasing.Upper;

            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProduction.Columns["XfDate"].DisplayFormat.FormatString = "MM/dd/yyyy";


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
                mLista = new ProgramProductionBL().ListaClientDivisionXfDateTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkDivision.Checked && chkIndcDate.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionIndcDateTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue), Convert.ToDateTime(deIndcDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deIndcDateTo.DateTime.ToShortDateString()));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkXfDate.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionXfDateTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0, Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkDivision.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboDivision.EditValue));
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkNumberPO.Checked)
            {
                mLista = new ProgramProductionBL().ListaNumberPOTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text);
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }

            if (chkClient.Checked && chkCommiment.Checked)
            {
                mLista = new ProgramProductionBL().ListaNumberCommimentTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), txtNumberCommiment.Text);
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }


            if (chkClient.Checked)
            {
                mLista = new ProgramProductionBL().ListaClientDivisionTotal(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0);
                gcProgramProduction.DataSource = mLista;
                Cursor = Cursors.Default;
                return;
            }
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ProductionProgramSummary.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                decimal decTotalUnits = 0;
                decimal decTotal = 0;

                xlHoja.Cells[4, 2] = cboClient.Text;

                for (int i = 0; i < gvProgramProduction.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = gvProgramProduction.GetRowCellValue(i, "NumberPO").ToString();
                    xlHoja.Cells[Row, 2] = gvProgramProduction.GetRowCellValue(i, "XfDate").ToString();
                    xlHoja.Cells[Row, 3] = gvProgramProduction.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 4] = gvProgramProduction.GetRowCellValue(i, "NameStyle").ToString();
                    xlHoja.Cells[Row, 5] = gvProgramProduction.GetRowCellValue(i, "Description").ToString();
                    xlHoja.Cells[Row, 6] = gvProgramProduction.GetRowCellValue(i, "TotalUnits").ToString();
                    decTotalUnits = decTotalUnits + decimal.Parse(gvProgramProduction.GetRowCellValue(i, "TotalUnits").ToString());
                    decTotal = decTotal + decimal.Parse(gvProgramProduction.GetRowCellValue(i, "TotalAmount").ToString());
                    xlHoja.Cells[Row, 7] = gvProgramProduction.GetRowCellValue(i, "TotalAmount").ToString();
                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }

                xlHoja.Cells[Row + 2, 5].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 5].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 5] = "TOTAL : ";

                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 6].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 6] = decTotalUnits;

                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Bold = true;
                xlHoja.Cells[Row + 2, 7].EntireRow.Font.Size = 12;
                xlHoja.Cells[Row + 2, 7] = decTotal;


                xlLibro.SaveAs("C:\\Excel\\ProductionProgramSummary.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\ProductionProgramSummary.xlsx");

                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\ProductionProgram.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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