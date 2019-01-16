using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class CommimentDL
    {
        public CommimentDL() { }

        public Int32 Inserta(CommimentBE pItem)
        {
            int intIdCommiment = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_Inserta");

            db.AddOutParameter(dbCommand, "pIdCommiment", DbType.Int32, pItem.IdCommiment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, pItem.NumberCommiment);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pCommimentDate", DbType.DateTime, pItem.CommimentDate);
            db.AddInParameter(dbCommand, "pContractShipDate", DbType.DateTime, pItem.ContractShipDate);
            db.AddInParameter(dbCommand, "pRevisionDate", DbType.DateTime, pItem.RevisionDate);
            db.AddInParameter(dbCommand, "pNumberRevision", DbType.String, pItem.NumberRevision);
            db.AddInParameter(dbCommand, "pIdOrigen", DbType.Int32, pItem.IdOrigen);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pFreightPaid", DbType.String, pItem.FreightPaid);
            db.AddInParameter(dbCommand, "pAddionational", DbType.String, pItem.Addionational);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdCommiment = (int)db.GetParameterValue(dbCommand, "pIdCommiment");

            return intIdCommiment;
        }

        public void Actualiza(CommimentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_Actualiza");

            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, pItem.IdCommiment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, pItem.NumberCommiment);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pCommimentDate", DbType.DateTime, pItem.CommimentDate);
            db.AddInParameter(dbCommand, "pContractShipDate", DbType.DateTime, pItem.ContractShipDate);
            db.AddInParameter(dbCommand, "pRevisionDate", DbType.DateTime, pItem.RevisionDate);
            db.AddInParameter(dbCommand, "pNumberRevision", DbType.String, pItem.NumberRevision);
            db.AddInParameter(dbCommand, "pIdOrigen", DbType.Int32, pItem.IdOrigen);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pFreightPaid", DbType.String, pItem.FreightPaid);
            db.AddInParameter(dbCommand, "pAddionational", DbType.String, pItem.Addionational);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaNumero(int IdCommiment, string NumberCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, IdCommiment);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, NumberCommiment);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CommimentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_Elimina");

            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, pItem.IdCommiment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public CommimentBE Selecciona(int IdCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_Selecciona");
            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, IdCommiment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CommimentBE Commiment = null;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Commiment;
        }

        public List<CommimentBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentBE> Commimentlist = new List<CommimentBE>();
            CommimentBE Commiment;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Commimentlist.Add(Commiment);
            }
            reader.Close();
            reader.Dispose();
            return Commimentlist;
        }

        
        public List<CommimentBE> ListaNumberCommiment(int IdCompany, string NumberCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ListaNumberCommiment");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNumberCommiment", DbType.String, NumberCommiment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentBE> Commimentlist = new List<CommimentBE>();
            CommimentBE Commiment;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Commimentlist.Add(Commiment);
            }
            reader.Close();
            reader.Dispose();
            return Commimentlist;
        }

        public List<CommimentBE> ListaClient(int IdCompany, int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ListaClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentBE> Commimentlist = new List<CommimentBE>();
            CommimentBE Commiment;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Commimentlist.Add(Commiment);
            }
            reader.Close();
            reader.Dispose();
            return Commimentlist;
        }

        public List<CommimentBE> ListaClientCommimentDate(int IdCompany, int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ListaClientDivisionCommimentDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentBE> Commimentlist = new List<CommimentBE>();
            CommimentBE Commiment;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Commimentlist.Add(Commiment);
            }
            reader.Close();
            reader.Dispose();
            return Commimentlist;
        }

        public List<CommimentBE> ListaClientContractShipDate(int IdCompany, int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Commiment_ClientContractShipDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentBE> Commimentlist = new List<CommimentBE>();
            CommimentBE Commiment;
            while (reader.Read())
            {
                Commiment = new CommimentBE();
                Commiment.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                Commiment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Commiment.NameCompany = reader["NameCompany"].ToString();
                Commiment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Commiment.NameClient = reader["NameClient"].ToString();
                Commiment.NumberCommiment = reader["NumberCommiment"].ToString();
                Commiment.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Commiment.NameVendor = reader["NameVendor"].ToString();
                Commiment.CommimentDate = DateTime.Parse(reader["CommimentDate"].ToString());
                Commiment.ContractShipDate = DateTime.Parse(reader["ContractShipDate"].ToString());
                Commiment.RevisionDate = DateTime.Parse(reader["RevisionDate"].ToString());
                Commiment.NumberRevision = reader["NumberRevision"].ToString();
                Commiment.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                Commiment.NameOrigen = reader["NameOrigen"].ToString();
                Commiment.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Commiment.NameDestination = reader["NameDestination"].ToString();
                Commiment.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Commiment.NameCurrency = reader["NameCurrency"].ToString();
                Commiment.FreightPaid = reader["FreightPaid"].ToString();
                Commiment.Addionational = reader["Addionational"].ToString();
                Commiment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Commimentlist.Add(Commiment);
            }
            reader.Close();
            reader.Dispose();
            return Commimentlist;
        }

    }
}
