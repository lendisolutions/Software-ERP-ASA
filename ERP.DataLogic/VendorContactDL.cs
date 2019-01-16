using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class VendorContactDL
    {
        public VendorContactDL() { }

        public void Inserta(VendorContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorContact_Inserta");

            db.AddInParameter(dbCommand, "pIdVendorContact", DbType.Int32, pItem.IdVendorContact);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pFirstName", DbType.String, pItem.FirstName);
            db.AddInParameter(dbCommand, "pCompany", DbType.String, pItem.Company);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
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

        public void Actualiza(VendorContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorContact_Actualiza");

            db.AddInParameter(dbCommand, "pIdVendorContact", DbType.Int32, pItem.IdVendorContact);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pFirstName", DbType.String, pItem.FirstName);
            db.AddInParameter(dbCommand, "pCompany", DbType.String, pItem.Company);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
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

        public void Elimina(VendorContactBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorContact_Elimina");

            db.AddInParameter(dbCommand, "pIdVendorContact", DbType.Int32, pItem.IdVendorContact);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public VendorContactBE Selecciona(int IdVendorContact)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorContact_Selecciona");
            db.AddInParameter(dbCommand, "pidVendorContact", DbType.Int32, IdVendorContact);

            IDataReader reader = db.ExecuteReader(dbCommand);
            VendorContactBE VendorContact = null;
            while (reader.Read())
            {
                VendorContact = new VendorContactBE();
                VendorContact.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorContact.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorContact.IdVendorContact = Int32.Parse(reader["idVendorContact"].ToString());
                VendorContact.Name = reader["Name"].ToString();
                VendorContact.FirstName = reader["FirtsName"].ToString();
                VendorContact.Company = reader["Company"].ToString();
                VendorContact.Occupation = reader["Occupation"].ToString();
                VendorContact.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                VendorContact.NameDestination = reader["NameDestination"].ToString();
                VendorContact.Phone1 = reader["Phone1"].ToString();
                VendorContact.Phone2 = reader["Phone2"].ToString();
                VendorContact.CelPhone = reader["CelPhone"].ToString();
                VendorContact.Fax = reader["Fax"].ToString();
                VendorContact.Email = reader["Email"].ToString();
                VendorContact.InformationAdditional = reader["InformationAdditional"].ToString();
                VendorContact.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return VendorContact;
        }

        public List<VendorContactBE> ListaTodosActivo(int IdVendor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorContact_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<VendorContactBE> VendorContactlist = new List<VendorContactBE>();
            VendorContactBE VendorContact;
            while (reader.Read())
            {
                VendorContact = new VendorContactBE();
                VendorContact.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorContact.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorContact.IdVendorContact = Int32.Parse(reader["idVendorContact"].ToString());
                VendorContact.Name = reader["Name"].ToString();
                VendorContact.FirstName = reader["FirstName"].ToString();
                VendorContact.Company = reader["Company"].ToString();
                VendorContact.Occupation = reader["Occupation"].ToString();
                VendorContact.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                VendorContact.NameDestination = reader["NameDestination"].ToString();
                VendorContact.Phone1 = reader["Phone1"].ToString();
                VendorContact.Phone2 = reader["Phone2"].ToString();
                VendorContact.CelPhone = reader["CelPhone"].ToString();
                VendorContact.Fax = reader["Fax"].ToString();
                VendorContact.Email = reader["Email"].ToString();
                VendorContact.InformationAdditional = reader["InformationAdditional"].ToString();
                VendorContact.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                VendorContact.TipoOper = 4; //CONSULTAR
                VendorContactlist.Add(VendorContact);
            }
            reader.Close();
            reader.Dispose();
            return VendorContactlist;
        }
    }
}
