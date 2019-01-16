using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientBrandDL
    {
        public ClientBrandDL() { }

        public void Inserta(ClientBrandBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_Inserta");

            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pBrandCertificate", DbType.String, pItem.BrandCertificate);
            db.AddInParameter(dbCommand, "pBrandFacturacion", DbType.String, pItem.BrandFacturacion);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientBrandBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pBrandCertificate", DbType.String, pItem.BrandCertificate);
            db.AddInParameter(dbCommand, "pBrandFacturacion", DbType.String, pItem.BrandFacturacion);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientBrandBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_Elimina");

            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientBrandBE Selecciona(int IdClientBrand)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_Selecciona");
            db.AddInParameter(dbCommand, "pidClientBrand", DbType.Int32, IdClientBrand);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientBrandBE ClientBrand = null;
            while (reader.Read())
            {
                ClientBrand = new ClientBrandBE();
                ClientBrand.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientBrand.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientBrand.IdClientBrand = Int32.Parse(reader["idClientBrand"].ToString());
                ClientBrand.BrandCertificate = reader["BrandCertificate"].ToString();
                ClientBrand.BrandFacturacion = reader["BrandFacturacion"].ToString();
                ClientBrand.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ClientBrand.NameDestination = reader["NameDestination"].ToString();
                ClientBrand.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientBrand;
        }

        public List<ClientBrandBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientBrandBE> ClientBrandlist = new List<ClientBrandBE>();
            ClientBrandBE ClientBrand;
            while (reader.Read())
            {
                ClientBrand = new ClientBrandBE();
                ClientBrand.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientBrand.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientBrand.IdClientBrand = Int32.Parse(reader["idClientBrand"].ToString());
                ClientBrand.BrandCertificate = reader["BrandCertificate"].ToString();
                ClientBrand.BrandFacturacion = reader["BrandFacturacion"].ToString();
                ClientBrand.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                ClientBrand.NameDestination = reader["NameDestination"].ToString();
                ClientBrand.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientBrand.TipoOper = 4; //CONSULTAR
                ClientBrandlist.Add(ClientBrand);
            }
            reader.Close();
            reader.Dispose();
            return ClientBrandlist;
        }

        public List<ClientBrandBE> ListaCertificate(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_ListaCertificate");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientBrandBE> ClientBrandlist = new List<ClientBrandBE>();
            ClientBrandBE ClientBrand;
            while (reader.Read())
            {
                ClientBrand = new ClientBrandBE();
                ClientBrand.IdClientBrand = Int32.Parse(reader["idClientBrand"].ToString());
                ClientBrand.BrandCertificate = reader["BrandCertificate"].ToString();
                ClientBrandlist.Add(ClientBrand);
            }
            reader.Close();
            reader.Dispose();
            return ClientBrandlist;
        }

        public List<ClientBrandBE> ListaFacturacion(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientBrand_ListaFacturacion");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientBrandBE> ClientBrandlist = new List<ClientBrandBE>();
            ClientBrandBE ClientBrand;
            while (reader.Read())
            {
                ClientBrand = new ClientBrandBE();
                ClientBrand.IdClientBrand = Int32.Parse(reader["idClientBrand"].ToString());
                ClientBrand.BrandFacturacion = reader["BrandFacturacion"].ToString();
                ClientBrandlist.Add(ClientBrand);
            }
            reader.Close();
            reader.Dispose();
            return ClientBrandlist;
        }
    }
}
