using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class VendorAddressDL
    {
        public VendorAddressDL() { }

        public void Inserta(VendorAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorAddress_Inserta");

            db.AddInParameter(dbCommand, "pIdVendorAddress", DbType.Int32, pItem.IdVendorAddress);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pWebPage", DbType.String, pItem.WebPage);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pCity", DbType.String, pItem.City);
            db.AddInParameter(dbCommand, "pState", DbType.String, pItem.State);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pReference", DbType.String, pItem.Reference);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(VendorAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorAddress_Actualiza");

            db.AddInParameter(dbCommand, "pIdVendorAddress", DbType.Int32, pItem.IdVendorAddress);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pWebPage", DbType.String, pItem.WebPage);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pCity", DbType.String, pItem.City);
            db.AddInParameter(dbCommand, "pState", DbType.String, pItem.State);
            db.AddInParameter(dbCommand, "pIdCountry", DbType.Int32, pItem.IdCountry);
            db.AddInParameter(dbCommand, "pPhone1", DbType.String, pItem.Phone1);
            db.AddInParameter(dbCommand, "pPhone2", DbType.String, pItem.Phone2);
            db.AddInParameter(dbCommand, "pFax", DbType.String, pItem.Fax);
            db.AddInParameter(dbCommand, "pReference", DbType.String, pItem.Reference);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(VendorAddressBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorAddress_Elimina");

            db.AddInParameter(dbCommand, "pIdVendorAddress", DbType.Int32, pItem.IdVendorAddress);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public VendorAddressBE Selecciona(int IdVendorAddress)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorAddress_Selecciona");
            db.AddInParameter(dbCommand, "pidVendorAddress", DbType.Int32, IdVendorAddress);

            IDataReader reader = db.ExecuteReader(dbCommand);
            VendorAddressBE VendorAddress = null;
            while (reader.Read())
            {
                VendorAddress = new VendorAddressBE();
                VendorAddress.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorAddress.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorAddress.IdVendorAddress = Int32.Parse(reader["idVendorAddress"].ToString());
                VendorAddress.IdType = Int32.Parse(reader["IdType"].ToString());
                VendorAddress.NameType = reader["NameType"].ToString();
                VendorAddress.Email = reader["Email"].ToString();
                VendorAddress.WebPage = reader["WebPage"].ToString();
                VendorAddress.Address = reader["Address"].ToString();
                VendorAddress.IdUbigeo = reader["IdUbigeo"].ToString();
                VendorAddress.NomUbigeo = reader["NomUbigeo"].ToString();
                VendorAddress.City = reader["City"].ToString();
                VendorAddress.State = reader["State"].ToString();
                VendorAddress.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                VendorAddress.NameCountry = reader["NameCountry"].ToString();
                VendorAddress.Phone1 = reader["Phone1"].ToString();
                VendorAddress.Phone2 = reader["Phone2"].ToString();
                VendorAddress.Fax = reader["Fax"].ToString();
                VendorAddress.Reference = reader["Reference"].ToString();
                VendorAddress.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return VendorAddress;
        }

        public List<VendorAddressBE> ListaTodosActivo(int IdVendor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorAddress_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<VendorAddressBE> VendorAddresslist = new List<VendorAddressBE>();
            VendorAddressBE VendorAddress;
            while (reader.Read())
            {
                VendorAddress = new VendorAddressBE();
                VendorAddress.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorAddress.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorAddress.IdVendorAddress = Int32.Parse(reader["idVendorAddress"].ToString());
                VendorAddress.IdType = Int32.Parse(reader["IdType"].ToString());
                VendorAddress.NameType = reader["NameType"].ToString();
                VendorAddress.Email = reader["Email"].ToString();
                VendorAddress.WebPage = reader["WebPage"].ToString();
                VendorAddress.Address = reader["Address"].ToString();
                VendorAddress.IdUbigeo = reader["IdUbigeo"].ToString();
                VendorAddress.NomUbigeo = reader["NomUbigeo"].ToString();
                VendorAddress.City = reader["City"].ToString();
                VendorAddress.State = reader["State"].ToString();
                VendorAddress.IdCountry = Int32.Parse(reader["IdCountry"].ToString());
                VendorAddress.NameCountry = reader["NameCountry"].ToString();
                VendorAddress.Phone1 = reader["Phone1"].ToString();
                VendorAddress.Phone2 = reader["Phone2"].ToString();
                VendorAddress.Fax = reader["Fax"].ToString();
                VendorAddress.Reference = reader["Reference"].ToString();
                VendorAddress.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                VendorAddress.TipoOper = 4; //CONSULTAR
                VendorAddresslist.Add(VendorAddress);
            }
            reader.Close();
            reader.Dispose();
            return VendorAddresslist;
        }
    }
}
