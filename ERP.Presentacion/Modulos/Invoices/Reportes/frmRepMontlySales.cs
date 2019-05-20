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
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Invoices.Reportes
{
    public partial class frmRepMontlySales : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepMontlySales()
        {
            InitializeComponent();
        }

        private void frmRepMontlySales_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = DateTime.Now.Month;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportarExcel("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ENERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "FEBRERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "MARZO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "ABRIL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "MAYO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "JUNIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "JULIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "AGOSTO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "SEPTIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "OCTUBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "NOVIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "DICIEMBRE";
            dt.Rows.Add(dr);

            return dt;
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\MonthlySalesReport.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

            try
            {
                xlHoja.Cells[4, 2] = cboMes.Text + " " + txtPeriodo.EditValue.ToString();

                //DILLARDS

                int RowA = 11;

                List<ReporteInvoiceBE> lstInvoiceDillars = null;
                lstInvoiceDillars = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 18, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceDillars)
                {
                    xlHoja.Cells[RowA, 1] = item.IssueDate;
                    xlHoja.Cells[RowA, 2] = item.NameClient;
                    xlHoja.Cells[RowA, 3] = item.Contac;
                    xlHoja.Cells[RowA, 4] = item.NameDestination;
                    xlHoja.Cells[RowA, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowA, 6] = item.TotalAmount;
                    xlHoja.Cells[RowA, 8] = item.TotalComision;
                    xlHoja.Cells[RowA, 9] = item.TotalPieces;

                    RowA = RowA + 1;
                   
                }

                //TEA LIVING INC

                int RowB = 24;

                List<ReporteInvoiceBE> lstInvoiceTeaLiving = null;
                lstInvoiceTeaLiving = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 60, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceTeaLiving)
                {
                    xlHoja.Cells[RowB, 1] = item.IssueDate;
                    xlHoja.Cells[RowB, 2] = item.NameClient;
                    xlHoja.Cells[RowB, 3] = item.Contac;
                    xlHoja.Cells[RowB, 4] = item.NameDestination;
                    xlHoja.Cells[RowB, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowB, 6] = item.TotalAmount;
                    xlHoja.Cells[RowB, 8] = item.TotalComision;
                    xlHoja.Cells[RowB, 9] = item.TotalPieces;

                    RowB = RowB + 1;

                }

                //BI - BILLING

                int RowC = 37;

                List<ReporteInvoiceBE> lstInvoiceBiBilling = null;
                lstInvoiceBiBilling = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 8, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceBiBilling)
                {
                    xlHoja.Cells[RowC, 1] = item.IssueDate;
                    xlHoja.Cells[RowC, 2] = item.NameClient;
                    xlHoja.Cells[RowC, 3] = item.Contac;
                    xlHoja.Cells[RowC, 4] = item.NameDestination;
                    xlHoja.Cells[RowC, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowC, 6] = item.TotalAmount;
                    xlHoja.Cells[RowC, 8] = item.TotalComision;
                    xlHoja.Cells[RowC, 9] = item.TotalPieces;

                    RowC = RowC + 1;

                }

                //URBAN OUTFITTERS, INC

                int RowD = 61;

                List<ReporteInvoiceBE> lstInvoiceUrban = null;
                lstInvoiceUrban = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 65, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceUrban)
                {
                    xlHoja.Cells[RowD, 1] = item.IssueDate;
                    xlHoja.Cells[RowD, 2] = item.NameClient;
                    xlHoja.Cells[RowD, 3] = item.Contac;
                    xlHoja.Cells[RowD, 4] = item.NameDestination;
                    xlHoja.Cells[RowD, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowD, 6] = item.TotalAmount;
                    xlHoja.Cells[RowD, 8] = item.TotalComision;
                    xlHoja.Cells[RowD, 9] = item.TotalPieces;

                    RowD = RowD + 1;

                }

                //VINCE

                int RowE = 90;

                List<ReporteInvoiceBE> lstInvoiceVince = null;
                lstInvoiceVince = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 7, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceVince)
                {
                    xlHoja.Cells[RowE, 1] = item.IssueDate;
                    xlHoja.Cells[RowE, 2] = item.NameClient;
                    xlHoja.Cells[RowE, 3] = item.Contac;
                    xlHoja.Cells[RowE, 4] = item.NameDestination;
                    xlHoja.Cells[RowE, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowE, 6] = item.TotalAmount;
                    xlHoja.Cells[RowE, 8] = item.TotalComision;
                    xlHoja.Cells[RowE, 9] = item.TotalPieces;

                    RowE = RowE + 1;

                }

                //ROBERTA ROLLER RABBIT LLC

                int RowF = 134;

                List<ReporteInvoiceBE> lstInvoiceRoberta = null;
                lstInvoiceRoberta = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 53, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceRoberta)
                {
                    xlHoja.Cells[RowF, 1] = item.IssueDate;
                    xlHoja.Cells[RowF, 2] = item.NameClient;
                    xlHoja.Cells[RowF, 3] = item.Contac;
                    xlHoja.Cells[RowF, 4] = item.NameDestination;
                    xlHoja.Cells[RowF, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowF, 6] = item.TotalAmount;
                    xlHoja.Cells[RowF, 8] = item.TotalComision;
                    xlHoja.Cells[RowF, 9] = item.TotalPieces;

                    RowF = RowF + 1;

                }

                //OPE SRL

                int RowG = 180;

                List<ReporteInvoiceBE> lstInvoiceOPE = null;
                lstInvoiceOPE = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 44, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceOPE)
                {
                    xlHoja.Cells[RowG, 1] = item.IssueDate;
                    xlHoja.Cells[RowG, 2] = item.NameClient;
                    xlHoja.Cells[RowG, 3] = item.Contac;
                    xlHoja.Cells[RowG, 4] = item.NameDestination;
                    xlHoja.Cells[RowG, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowG, 6] = item.TotalAmount;
                    xlHoja.Cells[RowG, 8] = item.TotalComision;
                    xlHoja.Cells[RowG, 9] = item.TotalPieces;

                    RowG = RowG + 1;

                }

                //MOTT & BOW

                int RowH = 193;

                List<ReporteInvoiceBE> lstInvoiceMott = null;
                lstInvoiceMott = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 76, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceMott)
                {
                    xlHoja.Cells[RowH, 1] = item.IssueDate;
                    xlHoja.Cells[RowH, 2] = item.NameClient;
                    xlHoja.Cells[RowH, 3] = item.Contac;
                    xlHoja.Cells[RowH, 4] = item.NameDestination;
                    xlHoja.Cells[RowH, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowH, 6] = item.TotalAmount;
                    xlHoja.Cells[RowH, 8] = item.TotalComision;
                    xlHoja.Cells[RowH, 9] = item.TotalPieces;

                    RowH = RowH + 1;

                }

                //KATE SPADE & COMPANY

                int RowI = 206;

                List<ReporteInvoiceBE> lstInvoiceKate = null;
                lstInvoiceKate = new ReporteInvoiceBL().ListadoMontlySales(Parametros.intEmpresaId, 32, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                foreach (var item in lstInvoiceKate)
                {
                    xlHoja.Cells[RowI, 1] = item.IssueDate;
                    xlHoja.Cells[RowI, 2] = item.NameClient;
                    xlHoja.Cells[RowI, 3] = item.Contac;
                    xlHoja.Cells[RowI, 4] = item.NameDestination;
                    xlHoja.Cells[RowI, 5] = item.NumberInvoice;
                    xlHoja.Cells[RowI, 6] = item.TotalAmount;
                    xlHoja.Cells[RowI, 8] = item.TotalComision;
                    xlHoja.Cells[RowI, 9] = item.TotalPieces;

                    RowI = RowI + 1;

                }

                xlLibro.SaveAs("C:\\Excel\\MonthlySalesReport.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                BSUtils.OpenExcel("C:\\Excel\\MonthlySalesReport.xlsx");

                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Invoice.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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