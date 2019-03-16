using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ReporteProgramProductionDL
    {
        public List<ReporteProgramProductionBE> Listado(int IdProgramProduction)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProduction");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionBE> ReporteProgramProductionlist = new List<ReporteProgramProductionBE>();
            ReporteProgramProductionBE ReporteProgramProduction;
            while (reader.Read())
            {
                ReporteProgramProduction = new ReporteProgramProductionBE();
                ReporteProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ReporteProgramProduction.Logo = (byte[])reader["Logo"];
                ReporteProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ReporteProgramProduction.NameClient = reader["NameClient"].ToString();
                ReporteProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ReporteProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ReporteProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ReporteProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ReporteProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ReporteProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ReporteProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ReporteProgramProduction.XfDate = reader["XfDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.IndcDate = reader["IndcDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ReporteProgramProduction.Label = reader["Label"].ToString();
                ReporteProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ReporteProgramProduction.Description = reader["Description"].ToString();
                ReporteProgramProduction.Item = reader["Item"].ToString();
                ReporteProgramProduction.Detail = reader["Detail"].ToString();
                ReporteProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ReporteProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ReporteProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteProgramProductionlist.Add(ReporteProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionlist;
        }

        public List<ReporteProgramProductionBE> ListadoFecha(int IdCompany, int IdClient, int IdVendor, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProductionDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionBE> ReporteProgramProductionlist = new List<ReporteProgramProductionBE>();
            ReporteProgramProductionBE ReporteProgramProduction;
            while (reader.Read())
            {
                ReporteProgramProduction = new ReporteProgramProductionBE();
                ReporteProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ReporteProgramProduction.Logo = (byte[])reader["Logo"];
                ReporteProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ReporteProgramProduction.NameClient = reader["NameClient"].ToString();
                ReporteProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ReporteProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ReporteProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ReporteProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ReporteProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ReporteProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ReporteProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ReporteProgramProduction.XfDate = reader["XfDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.IndcDate = reader["IndcDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ReporteProgramProduction.Label = reader["Label"].ToString();
                ReporteProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ReporteProgramProduction.Description = reader["Description"].ToString();
                ReporteProgramProduction.Item = reader["Item"].ToString();
                ReporteProgramProduction.Detail = reader["Detail"].ToString();
                ReporteProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ReporteProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ReporteProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteProgramProductionlist.Add(ReporteProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionlist;
        }

        public List<ReporteProgramProductionBE> ListadoFechaOpenPO(int IdCompany, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProductionDateOpenPO");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionBE> ReporteProgramProductionlist = new List<ReporteProgramProductionBE>();
            ReporteProgramProductionBE ReporteProgramProduction;
            while (reader.Read())
            {
                ReporteProgramProduction = new ReporteProgramProductionBE();
                ReporteProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ReporteProgramProduction.Logo = (byte[])reader["Logo"];
                ReporteProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ReporteProgramProduction.NameClient = reader["NameClient"].ToString();
                ReporteProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ReporteProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ReporteProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ReporteProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ReporteProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ReporteProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ReporteProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ReporteProgramProduction.XfDate = reader["XfDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.IndcDate = reader["IndcDate"].ToString().Substring(0, 10);
                ReporteProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ReporteProgramProduction.Label = reader["Label"].ToString();
                ReporteProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ReporteProgramProduction.Description = reader["Description"].ToString();
                ReporteProgramProduction.Item = reader["Item"].ToString();
                ReporteProgramProduction.Detail = reader["Detail"].ToString();
                ReporteProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ReporteProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ReporteProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteProgramProductionlist.Add(ReporteProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionlist;
        }

        public List<ReporteProgramProductionBE> ListadoClient(int IdCompany, int IdClient, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProductionClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionBE> ReporteProgramProductionlist = new List<ReporteProgramProductionBE>();
            ReporteProgramProductionBE ReporteProgramProduction;
            while (reader.Read())
            {
                ReporteProgramProduction = new ReporteProgramProductionBE();
                ReporteProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ReporteProgramProduction.TotalFob = Decimal.Parse(reader["TotalFob"].ToString());
                ReporteProgramProductionlist.Add(ReporteProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionlist;
        }

        public List<ReporteProgramProductionBE> ListadoShippingReportVinceStyleGeneral(int IdCompany, int IdClient, int IdStyle, int IdSeason)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProgramProductionClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, IdStyle);
            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, IdSeason);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProgramProductionBE> ReporteProgramProductionlist = new List<ReporteProgramProductionBE>();
            ReporteProgramProductionBE ReporteProgramProduction;
            while (reader.Read())
            {
                ReporteProgramProduction = new ReporteProgramProductionBE();
                ReporteProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ReporteProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ReporteProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ReporteProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ReporteProgramProduction.Description = reader["Description"].ToString();
                ReporteProgramProduction.Detail = reader["Detail"].ToString();
                ReporteProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ReporteProgramProduction.XS = Int32.Parse(reader["XS"].ToString());
                ReporteProgramProduction.S = Int32.Parse(reader["S"].ToString());
                ReporteProgramProduction.M = Int32.Parse(reader["M"].ToString());
                ReporteProgramProduction.L = Int32.Parse(reader["L"].ToString());
                ReporteProgramProduction.XL = Int32.Parse(reader["XL"].ToString());
                ReporteProgramProduction.XXL = Int32.Parse(reader["XXL"].ToString());
                ReporteProgramProductionlist.Add(ReporteProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ReporteProgramProductionlist;
        }
    }
}
