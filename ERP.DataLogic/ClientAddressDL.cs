using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientAddressDL
    {
        public ClientAddressDL() { }

        public void Inserta(ClientAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientAddress_Inserta");

            db.AddInParameter(dbCommand, "pIdClientAddress", DbType.Int32, pItem.IdClientAddress);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pSequence", DbType.Int32, pItem.Sequence);
            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pDestination", DbType.String, pItem.Destination);
            db.AddInParameter(dbCommand, "pCity", DbType.String, pItem.City);
            db.AddInParameter(dbCommand, "pState", DbType.String, pItem.State);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pWebPage", DbType.String, pItem.WebPage);
            db.AddInParameter(dbCommand, "pReference", DbType.String, pItem.Reference);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientAddress_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientAddress", DbType.Int32, pItem.IdClientAddress);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pSequence", DbType.Int32, pItem.Sequence);
            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pDestination", DbType.String, pItem.Destination);
            db.AddInParameter(dbCommand, "pCity", DbType.String, pItem.City);
            db.AddInParameter(dbCommand, "pState", DbType.String, pItem.State);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pWebPage", DbType.String, pItem.WebPage);
            db.AddInParameter(dbCommand, "pReference", DbType.String, pItem.Reference);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientAddress_Elimina");

            db.AddInParameter(dbCommand, "pIdClientAddress", DbType.Int32, pItem.IdClientAddress);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientAddressBE Selecciona(int IdClientAddress)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientAddress_Selecciona");
            db.AddInParameter(dbCommand, "pidClientAddress", DbType.Int32, IdClientAddress);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientAddressBE ClientAddress = null;
            while (reader.Read())
            {
                ClientAddress = new ClientAddressBE();
                ClientAddress.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientAddress.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientAddress.IdClientAddress = Int32.Parse(reader["idClientAddress"].ToString());
                ClientAddress.Sequence = Int32.Parse(reader["Sequence"].ToString());
                ClientAddress.IdType = Int32.Parse(reader["IdType"].ToString());
                ClientAddress.NameType = reader["NameType"].ToString();
                ClientAddress.Destination = reader["Destination"].ToString();
                ClientAddress.City = reader["City"].ToString();
                ClientAddress.State = reader["State"].ToString();
                ClientAddress.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                ClientAddress.NameCountry = reader["NameCountry"].ToString();
                ClientAddress.Phone1 = reader["Phone1"].ToString();
                ClientAddress.Phone2 = reader["Phone2"].ToString();
                ClientAddress.Fax = reader["Fax"].ToString();
                ClientAddress.Email = reader["Email"].ToString();
                ClientAddress.WebPage = reader["WebPage"].ToString();
                ClientAddress.Reference = reader["Reference"].ToString();
                ClientAddress.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientAddress;
        }

        public List<ClientAddressBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientAddress_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientAddressBE> ClientAddresslist = new List<ClientAddressBE>();
            ClientAddressBE ClientAddress;
            while (reader.Read())
            {
                ClientAddress = new ClientAddressBE();
                ClientAddress.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientAddress.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientAddress.IdClientAddress = Int32.Parse(reader["idClientAddress"].ToString());
                ClientAddress.Sequence = Int32.Parse(reader["Sequence"].ToString());
                ClientAddress.IdType = Int32.Parse(reader["IdType"].ToString());
                ClientAddress.NameType = reader["NameType"].ToString();
                ClientAddress.Destination = reader["Destination"].ToString();
                ClientAddress.City = reader["City"].ToString();
                ClientAddress.State = reader["State"].ToString();
                ClientAddress.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                ClientAddress.NameCountry = reader["NameCountry"].ToString();
                ClientAddress.Phone1 = reader["Phone1"].ToString();
                ClientAddress.Phone2 = reader["Phone2"].ToString();
                ClientAddress.Fax = reader["Fax"].ToString();
                ClientAddress.Email = reader["Email"].ToString();
                ClientAddress.WebPage = reader["WebPage"].ToString();
                ClientAddress.Reference = reader["Reference"].ToString();
                ClientAddress.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientAddress.TipoOper = 4; //CONSULTAR
                ClientAddresslist.Add(ClientAddress);
            }
            reader.Close();
            reader.Dispose();
            return ClientAddresslist;
        }
    }
}
