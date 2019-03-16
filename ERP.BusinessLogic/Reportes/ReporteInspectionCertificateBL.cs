using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ReporteInspectionCertificateBL
    {
        public List<ReporteInspectionCertificateBE> Listado(int IdInspectionCertificate)
        {
            try
            {
                ReporteInspectionCertificateDL InspectionCertificate = new ReporteInspectionCertificateDL();
                return InspectionCertificate.Listado(IdInspectionCertificate);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspectionCertificateBE> ListadoShippingReportVinceStyle(int IdCompany, int IdClient, string NameStyle)
        {
            try
            {
                ReporteInspectionCertificateDL InspectionCertificate = new ReporteInspectionCertificateDL();
                return InspectionCertificate.ListadoShippingReportVinceStyle(IdCompany,IdClient,NameStyle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspectionCertificateBE> ListadoShippingReportVincePO(int IdCompany, int IdClient, string NumberPO)
        {
            try
            {
                ReporteInspectionCertificateDL InspectionCertificate = new ReporteInspectionCertificateDL();
                return InspectionCertificate.ListadoShippingReportVincePO(IdCompany, IdClient, NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
