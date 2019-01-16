using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientDocumentDL
    {
        public ClientDocumentDL() { }

        public void Inserta(ClientDocumentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDocument_Inserta");

            db.AddInParameter(dbCommand, "pIdClientDocument", DbType.Int32, pItem.IdClientDocument);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pRegisterDate", DbType.DateTime, pItem.RegisterDate);
            db.AddInParameter(dbCommand, "pTitleDocument", DbType.String, pItem.TitleDocument);
            db.AddInParameter(dbCommand, "pNameDocument", DbType.String, pItem.NameDocument);
            db.AddInParameter(dbCommand, "pArchive", DbType.Binary, pItem.Archive);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientDocumentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDocument_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientDocument", DbType.Int32, pItem.IdClientDocument);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pRegisterDate", DbType.DateTime, pItem.RegisterDate);
            db.AddInParameter(dbCommand, "pTitleDocument", DbType.String, pItem.TitleDocument);
            db.AddInParameter(dbCommand, "pNameDocument", DbType.String, pItem.NameDocument);
            db.AddInParameter(dbCommand, "pArchive", DbType.Binary, pItem.Archive);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientDocumentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDocument_Elimina");

            db.AddInParameter(dbCommand, "pIdClientDocument", DbType.Int32, pItem.IdClientDocument);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientDocumentBE Selecciona(int IdClientDocument)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDocument_Selecciona");
            db.AddInParameter(dbCommand, "pidClientDocument", DbType.Int32, IdClientDocument);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientDocumentBE ClientDocument = null;
            while (reader.Read())
            {
                ClientDocument = new ClientDocumentBE();
                ClientDocument.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientDocument.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDocument.IdClientDocument = Int32.Parse(reader["idClientDocument"].ToString());
                ClientDocument.RegisterDate = DateTime.Parse(reader["RegisterDate"].ToString());
                ClientDocument.TitleDocument = reader["TitleDocument"].ToString();
                ClientDocument.NameDocument = reader["NameDocument"].ToString();
                ClientDocument.Archive = (byte[])reader["Archive"];
                ClientDocument.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientDocument;
        }

        public List<ClientDocumentBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDocument_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientDocumentBE> ClientDocumentlist = new List<ClientDocumentBE>();
            ClientDocumentBE ClientDocument;
            while (reader.Read())
            {
                ClientDocument = new ClientDocumentBE();
                ClientDocument.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientDocument.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDocument.IdClientDocument = Int32.Parse(reader["idClientDocument"].ToString());
                ClientDocument.RegisterDate = DateTime.Parse(reader["RegisterDate"].ToString());
                ClientDocument.TitleDocument = reader["TitleDocument"].ToString();
                ClientDocument.NameDocument = reader["NameDocument"].ToString();
                ClientDocument.Archive = (byte[])reader["Archive"];
                ClientDocument.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientDocument.TipoOper = 4; //CONSULTAR
                ClientDocumentlist.Add(ClientDocument);
            }
            reader.Close();
            reader.Dispose();
            return ClientDocumentlist;
        }
    }
}
