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
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Reportes
{
    public partial class frmRepShippingReportVicenPO : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteProgramProductionBE> mLista = new List<ReporteProgramProductionBE>();
        private List<ReporteInspectionCertificateBE> mListaInspeccionCertificate = new List<ReporteInspectionCertificateBE>();

        #endregion

        #region "Eventos"

        public frmRepShippingReportVicenPO()
        {
            InitializeComponent();
        }

        private void frmRepShippingReportVicenPO_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtNumberPO.Text == "")
            {
                XtraMessageBox.Show("you must enter number #PO.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ShippingReportVincePO.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

            try
            {
                int Row = 7;
                int RowDetail = 8;
                int RowCertificate = 9;
                decimal decTotalPO = 0;
                decimal decTotalShip = 0;

                xlHoja.Cells[2, 1] = "SHIPPING REPORT VINCE PO # " + txtNumberPO.Text;


                mLista = new ReporteProgramProductionBL().ListadoShippingReportVincePOGeneral(Parametros.intEmpresaId, 7, txtNumberPO.Text);

                if (mLista.Count > 0)
                {
                    xlHoja.Cells[4, 2] = mLista[0].NameVendor;

                    foreach (var item in mLista)
                    {
                        xlHoja.Cells[Row, 1] = item.NameStyle;
                        xlHoja.Cells[Row, 2] = item.Description;
                        xlHoja.Cells[Row, 4] = item.Detail;
                        xlHoja.Cells[Row, 5] = item.NumberPO + "\\" + item.Dyelot;
                        xlHoja.Cells[Row, 6] = item.NameDestination;
                        xlHoja.Cells[RowDetail, 9] = item.XS;
                        xlHoja.Cells[RowDetail, 10] = item.S;
                        xlHoja.Cells[RowDetail, 11] = item.M;
                        xlHoja.Cells[RowDetail, 12] = item.L;
                        xlHoja.Cells[RowDetail, 13] = item.XL;
                        xlHoja.Cells[RowDetail, 14] = item.XXL;
                        Row = Row + 7;
                        RowDetail = RowDetail + 7;
                        decTotalPO = decTotalPO + item.XS + item.S + item.M + item.L + item.XL + item.XXL;
                    }
                }

                //INSPECTION CERTIFICATE

                mListaInspeccionCertificate = new ReporteInspectionCertificateBL().ListadoShippingReportVincePO(Parametros.intEmpresaId, 7, txtNumberPO.Text.Trim());

                if (mListaInspeccionCertificate.Count > 0)
                {
                    foreach (var item in mListaInspeccionCertificate)
                    {
                        xlHoja.Cells[RowCertificate, 9] = item.XS;
                        xlHoja.Cells[RowCertificate, 10] = item.S;
                        xlHoja.Cells[RowCertificate, 11] = item.M;
                        xlHoja.Cells[RowCertificate, 12] = item.L;
                        xlHoja.Cells[RowCertificate, 13] = item.XL;
                        xlHoja.Cells[RowCertificate, 14] = item.XXL;

                        RowCertificate = RowCertificate + 7;
                        decTotalShip = decTotalShip + item.XS + item.S + item.M + item.L + item.XL + item.XXL;
                    }
                }

                xlHoja.Cells[77, 8] = decTotalPO;
                xlHoja.Cells[78, 8] = decTotalShip;

                xlLibro.SaveAs("C:\\Excel\\ShippingReportVincePO.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\ShippingReportVincePO.xlsx");

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