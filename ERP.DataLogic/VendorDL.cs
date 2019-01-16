using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class VendorDL
    {
        public VendorDL() { }

        public Int32 Inserta(VendorBE pItem)
        {
            int intIdVendor = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vendor_Inserta");

            db.AddOutParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pFlagNational", DbType.Boolean, pItem.FlagNational);
            db.AddInParameter(dbCommand, "pFlagForeigner", DbType.Boolean, pItem.FlagForeigner);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pNameVendor", DbType.String, pItem.NameVendor);
            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pCode", DbType.String, pItem.Code);
            db.AddInParameter(dbCommand, "pCorporation", DbType.String, pItem.Corporation);
            db.AddInParameter(dbCommand, "pCapacity", DbType.Decimal, pItem.Capacity);
            db.AddInParameter(dbCommand, "pRepresentative", DbType.String, pItem.Representative);
            db.AddInParameter(dbCommand, "pNumberEmployees", DbType.Int32, pItem.NumberEmployees);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdVendor = (int)db.GetParameterValue(dbCommand, "pIdVendor");

            return intIdVendor;
        }

        public void Actualiza(VendorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vendor_Actualiza");

            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pFlagNational", DbType.Boolean, pItem.FlagNational);
            db.AddInParameter(dbCommand, "pFlagForeigner", DbType.Boolean, pItem.FlagForeigner);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pNameVendor", DbType.String, pItem.NameVendor);
            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pCode", DbType.String, pItem.Code);
            db.AddInParameter(dbCommand, "pCorporation", DbType.String, pItem.Corporation);
            db.AddInParameter(dbCommand, "pCapacity", DbType.Decimal, pItem.Capacity);
            db.AddInParameter(dbCommand, "pRepresentative", DbType.String, pItem.Representative);
            db.AddInParameter(dbCommand, "pNumberEmployees", DbType.Int32, pItem.NumberEmployees);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);


            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(VendorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vendor_Elimina");

            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public VendorBE Selecciona(int IdVendor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vendor_Selecciona");
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            VendorBE Vendor = null;
            while (reader.Read())
            {
                Vendor = new VendorBE();
                Vendor.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Vendor.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Vendor.FlagNational = Boolean.Parse(reader["FlagNational"].ToString());
                Vendor.FlagForeigner = Boolean.Parse(reader["FlagForeigner"].ToString());
                Vendor.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Vendor.NameVendor = reader["NameVendor"].ToString();
                Vendor.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Vendor.NameStatus = reader["NameStatus"].ToString();
                Vendor.Ruc = reader["Ruc"].ToString();
                Vendor.NameVendor = reader["NameVendor"].ToString();
                Vendor.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Vendor.NameEvaluation = reader["NameEvaluation"].ToString();
                Vendor.Code = reader["Code"].ToString();
                Vendor.Corporation = reader["Corporation"].ToString();
                Vendor.Capacity = Decimal.Parse(reader["Capacity"].ToString());
                Vendor.Representative = reader["Representative"].ToString();
                Vendor.NumberEmployees = Int32.Parse(reader["NumberEmployees"].ToString());
                Vendor.Situation = reader["Situation"].ToString();
                Vendor.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Vendor;
        }

        public List<VendorBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vendor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<VendorBE> Vendorlist = new List<VendorBE>();
            VendorBE Vendor;
            while (reader.Read())
            {
                Vendor = new VendorBE();
                Vendor.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                Vendor.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Vendor.FlagNational = Boolean.Parse(reader["FlagNational"].ToString());
                Vendor.FlagForeigner = Boolean.Parse(reader["FlagForeigner"].ToString());
                Vendor.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Vendor.NameVendor = reader["NameVendor"].ToString();
                Vendor.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Vendor.NameStatus = reader["NameStatus"].ToString();
                Vendor.Ruc = reader["Ruc"].ToString();
                Vendor.NameVendor = reader["NameVendor"].ToString();
                Vendor.IdEvaluation = Int32.Parse(reader["IdEvaluation"].ToString());
                Vendor.NameEvaluation = reader["NameEvaluation"].ToString();
                Vendor.Code = reader["Code"].ToString();
                Vendor.Corporation = reader["Corporation"].ToString();
                Vendor.Capacity = Decimal.Parse(reader["Capacity"].ToString());
                Vendor.Representative = reader["Representative"].ToString();
                Vendor.NumberEmployees = Int32.Parse(reader["NumberEmployees"].ToString());
                Vendor.Situation = reader["Situation"].ToString();
                Vendor.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Vendorlist.Add(Vendor);
            }
            reader.Close();
            reader.Dispose();
            return Vendorlist;
        }
    }
}
