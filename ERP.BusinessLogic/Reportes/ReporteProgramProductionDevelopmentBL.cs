using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ReporteProgramProductionDevelopmentBL
    {
        public List<ReporteProgramProductionDevelopmentBE> Listado(int IdCompany, int IdClient, int IdSituation)
        {
            try
            {
                ReporteProgramProductionDevelopmentDL ProgramProduction = new ReporteProgramProductionDevelopmentDL();
                return ProgramProduction.Listado(IdCompany,IdClient,IdSituation);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
