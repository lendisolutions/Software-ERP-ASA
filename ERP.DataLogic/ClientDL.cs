using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientDL
    {
        public ClientDL() { }

        public Int32 Inserta(ClientBE pItem)
        {
            int intIdClient = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_Inserta");

            db.AddOutParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameClient", DbType.String, pItem.NameClient);
            db.AddInParameter(dbCommand, "pIdCorporation", DbType.Int32, pItem.IdCorporation);
            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pCertificate", DbType.String, pItem.Certificate);
            db.AddInParameter(dbCommand, "pPercentComision1", DbType.Decimal, pItem.PercentComision1);
            db.AddInParameter(dbCommand, "pPercentComision2", DbType.Decimal, pItem.PercentComision2);
            db.AddInParameter(dbCommand, "pPercentComision3", DbType.Decimal, pItem.PercentComision3);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdClient = (int)db.GetParameterValue(dbCommand, "pIdClient");

            return intIdClient;
        }

        public void Actualiza(ClientBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_Actualiza");

            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameClient", DbType.String, pItem.NameClient);
            db.AddInParameter(dbCommand, "pIdCorporation", DbType.Int32, pItem.IdCorporation);
            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pCertificate", DbType.String, pItem.Certificate);
            db.AddInParameter(dbCommand, "pPercentComision1", DbType.Decimal, pItem.PercentComision1);
            db.AddInParameter(dbCommand, "pPercentComision2", DbType.Decimal, pItem.PercentComision2);
            db.AddInParameter(dbCommand, "pPercentComision3", DbType.Decimal, pItem.PercentComision3);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);


            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(ClientBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_Elimina");

            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public ClientBE Selecciona(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_Selecciona");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientBE Client = null;
            while (reader.Read())
            {
                Client = new ClientBE();
                Client.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Client.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Client.NameClient = reader["NameClient"].ToString();
                Client.IdCorporation = Int32.Parse(reader["IdCorporation"].ToString());
                Client.NameCorporation = reader["NameCorporation"].ToString();
                Client.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Client.NameEvaluation = reader["NameEvaluation"].ToString();
                Client.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Client.Certificate = reader["Certificate"].ToString();
                Client.PercentComision1 = Decimal.Parse(reader["PercentComision1"].ToString());
                Client.PercentComision2 = Decimal.Parse(reader["PercentComision2"].ToString());
                Client.PercentComision3 = Decimal.Parse(reader["PercentComision3"].ToString());
                Client.Comment = reader["Comment"].ToString();
                Client.Situation =  reader["Situation"].ToString();
                Client.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Client;
        }

        public ClientBE SeleccionaDescripcion(int IdCompany, string NameClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameClient", DbType.String, NameClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientBE Client = null;
            while (reader.Read())
            {
                Client = new ClientBE();
                Client.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Client.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Client.NameClient = reader["NameClient"].ToString();
                Client.IdCorporation = Int32.Parse(reader["IdCorporation"].ToString());
                Client.NameCorporation = reader["NameCorporation"].ToString();
                Client.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Client.NameEvaluation = reader["NameEvaluation"].ToString();
                Client.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Client.Certificate = reader["Certificate"].ToString();
                Client.PercentComision1 = Decimal.Parse(reader["PercentComision1"].ToString());
                Client.PercentComision2 = Decimal.Parse(reader["PercentComision2"].ToString());
                Client.PercentComision3 = Decimal.Parse(reader["PercentComision3"].ToString());
                Client.Comment = reader["Comment"].ToString();
                Client.Situation = reader["Situation"].ToString();
                Client.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Client;
        }

        public List<ClientBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientBE> Clientlist = new List<ClientBE>();
            ClientBE Client;
            while (reader.Read())
            {
                Client = new ClientBE();
                Client.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Client.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Client.NameClient = reader["NameClient"].ToString();
                Client.IdCorporation = Int32.Parse(reader["IdCorporation"].ToString());
                Client.NameCorporation = reader["NameCorporation"].ToString();
                Client.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Client.NameEvaluation = reader["NameEvaluation"].ToString();
                Client.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Client.Certificate = reader["Certificate"].ToString();
                Client.PercentComision1 = Decimal.Parse(reader["PercentComision1"].ToString());
                Client.PercentComision2 = Decimal.Parse(reader["PercentComision2"].ToString());
                Client.PercentComision3 = Decimal.Parse(reader["PercentComision3"].ToString());
                Client.Comment = reader["Comment"].ToString();
                Client.Situation = reader["Situation"].ToString();
                Client.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Clientlist.Add(Client);
            }
            reader.Close();
            reader.Dispose();
            return Clientlist;
        }

        public List<ClientBE> ListaDescripcion(int IdCompany, string NameCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Client_ListaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameCompany", DbType.String, NameCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientBE> Clientlist = new List<ClientBE>();
            ClientBE Client;
            while (reader.Read())
            {
                Client = new ClientBE();
                Client.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Client.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Client.NameClient = reader["NameClient"].ToString();
                Client.IdCorporation = Int32.Parse(reader["IdCorporation"].ToString());
                Client.NameCorporation = reader["NameCorporation"].ToString();
                Client.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Client.NameEvaluation = reader["NameEvaluation"].ToString();
                Client.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Client.Certificate = reader["Certificate"].ToString();
                Client.PercentComision1 = Decimal.Parse(reader["PercentComision1"].ToString());
                Client.PercentComision2 = Decimal.Parse(reader["PercentComision2"].ToString());
                Client.PercentComision3 = Decimal.Parse(reader["PercentComision3"].ToString());
                Client.Comment = reader["Comment"].ToString();
                Client.Situation = reader["Situation"].ToString();
                Client.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Clientlist.Add(Client);
            }
            reader.Close();
            reader.Dispose();
            return Clientlist;
        }

    }
}
