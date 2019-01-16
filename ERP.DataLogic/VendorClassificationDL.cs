using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class VendorClassificationDL
    {
        public VendorClassificationDL() { }

        public void Inserta(VendorClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorClassification_Inserta");

            db.AddInParameter(dbCommand, "pIdVendorClassification", DbType.Int32, pItem.IdVendorClassification);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdClassification", DbType.Int32, pItem.IdClassification);
            db.AddInParameter(dbCommand, "pFlagActive", DbType.Boolean, pItem.FlagActive);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(VendorClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorClassification_Actualiza");

            db.AddInParameter(dbCommand, "pIdVendorClassification", DbType.Int32, pItem.IdVendorClassification);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pIdClassification", DbType.Int32, pItem.IdClassification);
            db.AddInParameter(dbCommand, "pFlagActive", DbType.Boolean, pItem.FlagActive);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(VendorClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorClassification_Elimina");

            db.AddInParameter(dbCommand, "pIdVendorClassification", DbType.Int32, pItem.IdVendorClassification);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public VendorClassificationBE Selecciona(int IdVendorClassification)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorClassification_Selecciona");
            db.AddInParameter(dbCommand, "pidVendorClassification", DbType.Int32, IdVendorClassification);

            IDataReader reader = db.ExecuteReader(dbCommand);
            VendorClassificationBE VendorClassification = null;
            while (reader.Read())
            {
                VendorClassification = new VendorClassificationBE();
                VendorClassification.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorClassification.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorClassification.IdVendorClassification = Int32.Parse(reader["idVendorClassification"].ToString());
                VendorClassification.IdClassification = Int32.Parse(reader["IdClassification"].ToString());
                VendorClassification.NameClassification = reader["NameClassification"].ToString();
                VendorClassification.FlagActive = Boolean.Parse(reader["FlagActive"].ToString());
                VendorClassification.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return VendorClassification;
        }

        public List<VendorClassificationBE> ListaTodosActivo(int IdVendor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VendorClassification_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<VendorClassificationBE> VendorClassificationlist = new List<VendorClassificationBE>();
            VendorClassificationBE VendorClassification;
            while (reader.Read())
            {
                VendorClassification = new VendorClassificationBE();
                VendorClassification.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                VendorClassification.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                VendorClassification.IdVendorClassification = Int32.Parse(reader["idVendorClassification"].ToString());
                VendorClassification.IdClassification = Int32.Parse(reader["IdClassification"].ToString());
                VendorClassification.NameClassification = reader["NameClassification"].ToString();
                VendorClassification.FlagActive = Boolean.Parse(reader["FlagActive"].ToString());
                VendorClassification.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                VendorClassification.TipoOper = 4; //CONSULTAR
                VendorClassificationlist.Add(VendorClassification);
            }
            reader.Close();
            reader.Dispose();
            return VendorClassificationlist;
        }
    }
}
