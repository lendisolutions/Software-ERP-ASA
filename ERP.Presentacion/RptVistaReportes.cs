using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using DevExpress.XtraBars;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Modulos.Production.Rpt;
using ERP.Presentacion.Modulos.Invoices.Rpt;

namespace ERP.Presentacion
{
    public partial class RptVistaReportes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region "Propiedades"
        
        #endregion

        #region Eventos

        public RptVistaReportes()
        {
            InitializeComponent();
        }

        private void RptVistaReportes_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Metodos

        public void VerRptProgramProduction(List<ReporteProgramProductionBE> lstReporte)
        {
            rptProgramProduction objReporte = new rptProgramProduction();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProgramProductionDate(List<ReporteProgramProductionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptProgramProductionDate objReporte = new rptProgramProductionDate();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProgramProductionDevelopment(List<ReporteProgramProductionDevelopmentBE> lstReporte)
        {
            rptProgramProductionDevelopment objReporte = new rptProgramProductionDevelopment();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspectionCertificate(List<ReporteInspectionCertificateBE> lstReporte)
        {
            rptInspectionCertificate objReporte = new rptInspectionCertificate();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInvoice(List<ReporteInvoiceBE> lstReporte)
        {
            rptInvoice objReporte = new rptInvoice();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInvoiceComisionCover(List<ReporteInvoiceBE> lstReporte)
        {
            rptInvoiceCommisionCover objReporte = new rptInvoiceCommisionCover();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        #endregion
    }
}