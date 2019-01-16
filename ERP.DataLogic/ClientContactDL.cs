using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientContactDL
    {
        public ClientContactDL() { }

        public void Inserta(ClientContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientContact_Inserta");

            db.AddInParameter(dbCommand, "pIdClientContact", DbType.Int32, pItem.IdClientContact);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pFirtsName", DbType.String, pItem.FirtsName);
            db.AddInParameter(dbCommand, "pCompany", DbType.String, pItem.Company);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pCelPhone", DbType.String, pItem.CelPhone);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pInformationAdditional", DbType.String, pItem.InformationAdditional);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientContact_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientContact", DbType.Int32, pItem.IdClientContact);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pFirtsName", DbType.String, pItem.FirtsName);
            db.AddInParameter(dbCommand, "pCompany", DbType.String, pItem.Company);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pCelPhone", DbType.String, pItem.CelPhone);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pInformationAdditional", DbType.String, pItem.InformationAdditional);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientContact_Elimina");

            db.AddInParameter(dbCommand, "pIdClientContact", DbType.Int32, pItem.IdClientContact);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientContactBE Selecciona(int IdClientContact)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientContact_Selecciona");
            db.AddInParameter(dbCommand, "pidClientContact", DbType.Int32, IdClientContact);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientContactBE ClientContact = null;
            while (reader.Read())
            {
                ClientContact = new ClientContactBE();
                ClientContact.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientContact.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientContact.IdClientContact = Int32.Parse(reader["idClientContact"].ToString());
                ClientContact.Name = reader["Name"].ToString();
                ClientContact.FirtsName = reader["FirtsName"].ToString();
                ClientContact.Company = reader["Company"].ToString();
                ClientContact.Occupation = reader["Occupation"].ToString();
                ClientContact.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                ClientContact.NameCountry = reader["NameCountry"].ToString();
                ClientContact.Phone1 = reader["Phone1"].ToString();
                ClientContact.Phone2 = reader["Phone2"].ToString();
                ClientContact.CelPhone = reader["CelPhone"].ToString();
                ClientContact.Fax = reader["Fax"].ToString();
                ClientContact.Email = reader["Email"].ToString();
                ClientContact.InformationAdditional = reader["InformationAdditional"].ToString();
                ClientContact.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientContact;
        }

        public List<ClientContactBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientContact_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientContactBE> ClientContactlist = new List<ClientContactBE>();
            ClientContactBE ClientContact;
            while (reader.Read())
            {
                ClientContact = new ClientContactBE();
                ClientContact.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientContact.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientContact.IdClientContact = Int32.Parse(reader["idClientContact"].ToString());
                ClientContact.Name = reader["Name"].ToString();
                ClientContact.FirtsName = reader["FirtsName"].ToString();
                ClientContact.Company = reader["Company"].ToString();
                ClientContact.Occupation = reader["Occupation"].ToString();
                ClientContact.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                ClientContact.NameCountry = reader["NameCountry"].ToString();
                ClientContact.Phone1 = reader["Phone1"].ToString();
                ClientContact.Phone2 = reader["Phone2"].ToString();
                ClientContact.CelPhone = reader["CelPhone"].ToString();
                ClientContact.Fax = reader["Fax"].ToString();
                ClientContact.Email = reader["Email"].ToString();
                ClientContact.InformationAdditional = reader["InformationAdditional"].ToString();
                ClientContact.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientContact.TipoOper = 4; //CONSULTAR
                ClientContactlist.Add(ClientContact);
            }
            reader.Close();
            reader.Dispose();
            return ClientContactlist;
        }
    }
}
