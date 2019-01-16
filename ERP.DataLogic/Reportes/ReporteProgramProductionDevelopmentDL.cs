using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ReporteProgramProductionDevelopmentDL
    {
        public List<ReporteProgramProductionDevelopmentBE> Listado(int IdCompany, int IdClient, int IdSituation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProductionDevelopment");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, IdSituation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionDevelopmentBE> ReporteProgramProductionDevelopmentlist = new List<ReporteProgramProductionDevelopmentBE>();
            ReporteProgramProductionDevelopmentBE ReporteProgramProductionDevelopment;
            while (reader.Read())
            {
                ReporteProgramProductionDevelopment = new ReporteProgramProductionDevelopmentBE();
                ReporteProgramProductionDevelopment.NameCompany = reader["NameCompany"].ToString();
                ReporteProgramProductionDevelopment.Logo = (byte[])reader["Logo"];
                ReporteProgramProductionDevelopment.NameClient = reader["NameClient"].ToString();
                ReporteProgramProductionDevelopment.XfDate = reader["XfDate"].ToString().Substring(0, 10);
                ReporteProgramProductionDevelopment.NumberPO = reader["NumberPO"].ToString();
                ReporteProgramProductionDevelopment.NameStyle = reader["NameStyle"].ToString();
                ReporteProgramProductionDevelopment.Description = reader["Description"].ToString();
                ReporteProgramProductionDevelopment.Item = reader["Item"].ToString();
                ReporteProgramProductionDevelopment.Detail = reader["Detail"].ToString();
                ReporteProgramProductionDevelopment.Units = Decimal.Parse(reader["Units"].ToString());
                ReporteProgramProductionDevelopment.Fob = Decimal.Parse(reader["Fob"].ToString());
                ReporteProgramProductionDevelopment.DevDate = reader["DevDate"].ToString().Substring(0, 10);
                ReporteProgramProductionDevelopment.Comment = reader["Comment"].ToString();
                ReporteProgramProductionDevelopment.Situation = reader["Situation"].ToString();
                ReporteProgramProductionDevelopmentlist.Add(ReporteProgramProductionDevelopment);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionDevelopmentlist;
        }
    }
}
