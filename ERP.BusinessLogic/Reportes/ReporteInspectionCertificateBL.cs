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
    }
}
