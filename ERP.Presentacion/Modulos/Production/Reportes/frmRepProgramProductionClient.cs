using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Reportes
{
    public partial class frmRepProgramProductionClient : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepProgramProductionClient()
        {
            InitializeComponent();
        }

        private void frmRepProgramProductionClient_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            ExportarExcel("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ProductionProgramClient.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<ReporteProgramProductionBE> lstReporteProgramProduction = null;
                lstReporteProgramProduction = new ReporteProgramProductionBL().ListadoClient(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue),Convert.ToInt32(txtPeriodo.EditValue));
                if (lstReporteProgramProduction.Count > 0)
                {
                    string strTitulo = "";
                    strTitulo = "SUMMARY PROG PROD " + cboClient.Text.ToString() + " " + txtPeriodo.Text.ToString();

                    xlHoja.Cells[2, 1] = strTitulo;

                    decimal decComision = 0;
                    ClientBE objE_Client = null;
                    objE_Client = new ClientBL().Selecciona(Convert.ToInt32(cboClient.EditValue));
                    if (objE_Client != null)
                    {
                        decComision = objE_Client.PercentComision1;
                    }

                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstReporteProgramProduction)
                    {
                        xlHoja.Cells[Row, 2] = item.TotalUnits;
                        xlHoja.Cells[Row, 3] = item.TotalFob;
                        xlHoja.Cells[Row, 4] = decComision;

                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\ProductionProgramClient.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\ProductionProgramClient.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Classification.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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