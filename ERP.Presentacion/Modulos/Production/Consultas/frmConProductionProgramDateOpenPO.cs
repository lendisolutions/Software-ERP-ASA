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
    public partial class frmConProductionProgramDateOpenPO : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteProgramProductionBE> mLista = new List<ReporteProgramProductionBE>();

        #endregion

        #region "Eventos"

        public frmConProductionProgramDateOpenPO()
        {
            InitializeComponent();
        }

        private void frmConProductionProgramDateOpenPO_Load(object sender, EventArgs e)
        {
            deRevenueDateFrom.DateTime =  DateTime.Now.AddDays(-7);
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

        #region "metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            mLista = new ReporteProgramProductionBL().ListadoFechaOpenPO(Parametros.intEmpresaId, Convert.ToDateTime(deRevenueDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deRevenueDateTo.DateTime.ToShortDateString()));
            gcProgramProduction.DataSource = mLista;

            Cursor = Cursors.Default;

        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ASAOpenPOReport.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

            try
            {
                int Row = 7;
                int Secuencia = 1;

                xlHoja.Cells[4, 2] = deRevenueDateFrom.DateTime.ToShortDateString();
                xlHoja.Cells[4, 4] = deRevenueDateTo.DateTime.ToShortDateString();

                for (int i = 0; i < gvProgramProduction.DataRowCount; i++)
                {
                    xlHoja.Cells[Row, 1] = gvProgramProduction.GetRowCellValue(i, "NameClient").ToString();
                    xlHoja.Cells[Row, 3] = gvProgramProduction.GetRowCellValue(i, "NameVendor").ToString();
                    xlHoja.Cells[Row, 4] = gvProgramProduction.GetRowCellValue(i, "NameDivision").ToString();
                    xlHoja.Cells[Row, 5] = gvProgramProduction.GetRowCellValue(i, "NameStyle").ToString();
                    xlHoja.Cells[Row, 6] = gvProgramProduction.GetRowCellValue(i, "Description").ToString();
                    xlHoja.Cells[Row, 7] = gvProgramProduction.GetRowCellValue(i, "Units").ToString();
                    xlHoja.Cells[Row, 8] = BSUtils.GetDateFormat(DateTime.Parse(gvProgramProduction.GetRowCellValue(i, "XfDate").ToString()));

                    Row = Row + 1;
                    Secuencia = Secuencia + 1;
                }


                xlLibro.SaveAs("C:\\Excel\\ASAOpenPOReport.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\ASAOpenPOReport.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\ASA Open PO Report.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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