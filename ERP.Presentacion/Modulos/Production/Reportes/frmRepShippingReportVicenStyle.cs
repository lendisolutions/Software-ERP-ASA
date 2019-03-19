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
    public partial class frmRepShippingReportVicenStyle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteProgramProductionBE> mLista = new List<ReporteProgramProductionBE>();
        private List<ReporteInspectionCertificateBE> mListaInspeccionCertificate = new List<ReporteInspectionCertificateBE>();

        int intIdStyle = 0;

        #endregion

        #region "Eventos"

        public frmRepShippingReportVicenStyle()
        {
            InitializeComponent();
        }

        private void frmRepShippingReportVicenStyle_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSeason, new SeasonBL().ListaTodosActivo(Parametros.intEmpresaId), "NameSeason", "IdSeason", true);
        }

        private void btnBusStyle_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmBusStyle frm = new frmBusStyle();
                frm.IdClient = 7; //VINCE
                frm.IdClientDepartment = 0;
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    intIdStyle = frm._Be.IdStyle;
                    txtNameStyle.Text = frm._Be.NameStyle;
                    txtDescription.Text = frm._Be.Description;
                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (intIdStyle == 0)
            {
                XtraMessageBox.Show("you must select a style.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\ShippingReportVinceStyle.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 80, 60);

            try
            {
                int Row = 7;
                int RowDetail = 8;
                int RowCertificate = 9;
                decimal decTotalPO = 0;
                decimal decTotalShip = 0;

                xlHoja.Cells[2, 1] = "SHIPPING REPORT VINCE STYLE # " + txtNameStyle.Text;
               

                mLista = new ReporteProgramProductionBL().ListadoShippingReportVinceStyleGeneral(Parametros.intEmpresaId, 7, intIdStyle, Convert.ToInt32(cboSeason.EditValue));

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
                        xlHoja.Cells[RowDetail, 9] = item.XXS;
                        xlHoja.Cells[RowDetail, 10] = item.XS;
                        xlHoja.Cells[RowDetail, 11] = item.S;
                        xlHoja.Cells[RowDetail, 12] = item.M;
                        xlHoja.Cells[RowDetail, 13] = item.L;
                        xlHoja.Cells[RowDetail, 14] = item.XL;
                        xlHoja.Cells[RowDetail, 15] = item.XXL;

                        Row = Row + 7;
                        RowDetail = RowDetail + 7;
                        decTotalPO = decTotalPO + item.XS + item.S + item.M + item.L + item.XL + item.XXL;
                    }
                }

                //INSPECTION CERTIFICATE

                mListaInspeccionCertificate = new ReporteInspectionCertificateBL().ListadoShippingReportVinceStyle(Parametros.intEmpresaId, 7, txtNameStyle.Text.Trim());

                if (mListaInspeccionCertificate.Count > 0)
                {
                    foreach (var item in mListaInspeccionCertificate)
                    {
                        xlHoja.Cells[RowCertificate, 9] = item.XXS;
                        xlHoja.Cells[RowCertificate, 10] = item.XS;
                        xlHoja.Cells[RowCertificate, 11] = item.S;
                        xlHoja.Cells[RowCertificate, 12] = item.M;
                        xlHoja.Cells[RowCertificate, 13] = item.L;
                        xlHoja.Cells[RowCertificate, 14] = item.XL;
                        xlHoja.Cells[RowCertificate, 15] = item.XXL;

                        RowCertificate = RowCertificate + 7;
                        decTotalShip = decTotalShip + item.XS + item.S + item.M + item.L + item.XL + item.XXL;
                    }
                }

                xlHoja.Cells[181, 8] = decTotalPO;
                xlHoja.Cells[182, 8] = decTotalShip;

                xlLibro.SaveAs("C:\\Excel\\ShippingReportVinceStyle.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\ShippingReportVinceStyle.xlsx");
                
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