using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ReporteProgramProductionBL
    {
        public List<ReporteProgramProductionBE> Listado(int IdProgramProduction)
        {
            try
            {
                ReporteProgramProductionDL ProgramProduction = new ReporteProgramProductionDL();
                return ProgramProduction.Listado(IdProgramProduction);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteProgramProductionBE> ListadoFecha(int IdCompany, int IdClient, int IdVendor, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ReporteProgramProductionDL ProgramProduction = new ReporteProgramProductionDL();
                return ProgramProduction.ListadoFecha(IdCompany, IdClient, IdVendor, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProgramProductionBE> ListadoFechaOpenPO(int IdCompany, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ReporteProgramProductionDL ProgramProduction = new ReporteProgramProductionDL();
                return ProgramProduction.ListadoFechaOpenPO(IdCompany, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProgramProductionBE> ListadoClient(int IdCompany, int IdClient, int Periodo)
        {
            try
            {
                ReporteProgramProductionDL ProgramProduction = new ReporteProgramProductionDL();
                return ProgramProduction.ListadoClient(IdCompany, IdClient, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
