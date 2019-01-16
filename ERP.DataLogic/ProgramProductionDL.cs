using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ProgramProductionDL
    {
        public ProgramProductionDL() { }

        public Int32 Inserta(ProgramProductionBE pItem)
        {
            int intIdProgramProduction = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_Inserta");

            db.AddOutParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberPP", DbType.String, pItem.NumberPP);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, pItem.IdSeason);
            db.AddInParameter(dbCommand, "pIdTypeProduct", DbType.Int32, pItem.IdTypeProduct);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, pItem.NumberCommiment);
            db.AddInParameter(dbCommand, "pXfDate", DbType.DateTime, pItem.XfDate);
            db.AddInParameter(dbCommand, "pIndcDate", DbType.DateTime, pItem.IndcDate);
            db.AddInParameter(dbCommand, "pIdShipMode", DbType.Int32, pItem.IdShipMode);
            db.AddInParameter(dbCommand, "pLabel", DbType.String, pItem.Label);
            db.AddInParameter(dbCommand, "pAddionational", DbType.String, pItem.Addionational);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdProgramProduction = (int)db.GetParameterValue(dbCommand, "pIdProgramProduction");

            return intIdProgramProduction;
        }

        public void Actualiza(ProgramProductionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_Actualiza");

            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberPP", DbType.String, pItem.NumberPP);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, pItem.IdSeason);
            db.AddInParameter(dbCommand, "pIdTypeProduct", DbType.Int32, pItem.IdTypeProduct);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, pItem.NumberCommiment);
            db.AddInParameter(dbCommand, "pXfDate", DbType.DateTime, pItem.XfDate);
            db.AddInParameter(dbCommand, "pIndcDate", DbType.DateTime, pItem.IndcDate);
            db.AddInParameter(dbCommand, "pIdShipMode", DbType.Int32, pItem.IdShipMode);
            db.AddInParameter(dbCommand, "pLabel", DbType.String, pItem.Label);
            db.AddInParameter(dbCommand, "pAddionational", DbType.String, pItem.Addionational);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaNumero(int IdProgramProduction, string NumberPP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);
            db.AddInParameter(dbCommand, "pNumberPP", DbType.String, NumberPP);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProgramProductionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_Elimina");

            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public ProgramProductionBE Selecciona(int IdProgramProduction)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_Selecciona");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProgramProductionBE ProgramProduction = null;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return ProgramProduction;
        }

        public List<ProgramProductionBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaNumberPO(int IdCompany, int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaNumberPO");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaNumberCommiment(int IdCompany, int IdClient, string NumberCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaNumberCommiment");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, NumberCommiment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivision(int IdCompany, int IdClient, int IdClientDepartment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivision");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDate(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionXfDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionIndcDate(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionIndcDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionVencimiento(int IdCompany, int IdClient, int IdClientDepartment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionVencimiento");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.Days = Int32.Parse(reader["Days"].ToString());
                ProgramProduction.Situation = reader["Situation"].ToString();
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }


        public List<ProgramProductionBE> ListaNumberPOVencimiento(int IdCompany, int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaNumberPOVencimiento");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Item"].ToString();
                ProgramProduction.Detail = reader["Detail"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.Days = Int32.Parse(reader["Days"].ToString());
                ProgramProduction.Situation = reader["Situation"].ToString();
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDateVencimiento(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientXfDateVencimiento");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProduction.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProduction.NameCompany = reader["NameCompany"].ToString();
                ProgramProduction.NumberPP = reader["NumberPP"].ToString();
                ProgramProduction.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ProgramProduction.NameClient = reader["NameClient"].ToString();
                ProgramProduction.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                ProgramProduction.NameDivision = reader["NameDivision"].ToString();
                ProgramProduction.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ProgramProduction.NameDestination = reader["NameDestination"].ToString();
                ProgramProduction.IdSeason = Int32.Parse(reader["IdSeason"].ToString());
                ProgramProduction.NameSeason = reader["NameSeason"].ToString();
                ProgramProduction.IdTypeProduct = Int32.Parse(reader["IdTypeProduct"].ToString());
                ProgramProduction.NameTypeProduct = reader["NameTypeProduct"].ToString();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.NumberCommiment = reader["NumberCommiment"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.IndcDate = DateTime.Parse(reader["IndcDate"].ToString());
                ProgramProduction.IdShipMode = Int32.Parse(reader["IdShipMode"].ToString());
                ProgramProduction.NameShipMode = reader["NameShipMode"].ToString();
                ProgramProduction.Label = reader["Label"].ToString();
                ProgramProduction.Addionational = reader["Addionational"].ToString();
                ProgramProduction.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.Dyelot = reader["Dyelot"].ToString();
                ProgramProduction.Item = reader["Description"].ToString();
                ProgramProduction.Detail = reader["Item"].ToString();
                ProgramProduction.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProduction.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProduction.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProduction.Days = Int32.Parse(reader["Days"].ToString());
                ProgramProduction.Situation = reader["Situation"].ToString();
                ProgramProduction.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDateTotal(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionXfDateTotal");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ProgramProduction.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionIndcDateTotal(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionIndcDateTotal");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ProgramProduction.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaClientDivisionTotal(int IdCompany, int IdClient, int IdClientDepartment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaClientDivisionTotal");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ProgramProduction.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaNumberPOTotal(int IdCompany, int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaNumberPOTotal");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ProgramProduction.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }

        public List<ProgramProductionBE> ListaNumberCommimentTotal(int IdCompany, int IdClient, string NumberCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProduction_ListaNumberCommimentTotal");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, NumberCommiment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionBE> ProgramProductionlist = new List<ProgramProductionBE>();
            ProgramProductionBE ProgramProduction;
            while (reader.Read())
            {
                ProgramProduction = new ProgramProductionBE();
                ProgramProduction.NumberPO = reader["NumberPO"].ToString();
                ProgramProduction.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProduction.NameVendor = reader["NameVendor"].ToString();
                ProgramProduction.NameStyle = reader["NameStyle"].ToString();
                ProgramProduction.Description = reader["Description"].ToString();
                ProgramProduction.TotalUnits = Decimal.Parse(reader["TotalUnits"].ToString());
                ProgramProduction.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ProgramProductionlist.Add(ProgramProduction);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionlist;
        }
    }
}
