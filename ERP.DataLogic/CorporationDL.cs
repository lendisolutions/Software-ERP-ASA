using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class CorporationDL
    {
        public CorporationDL() { }

        public void Inserta(CorporationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_Inserta");

            db.AddInParameter(dbCommand, "pIdCorporation", DbType.Int32, pItem.IdCorporation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameCorporation", DbType.String, pItem.NameCorporation);
            db.AddInParameter(dbCommand, "pFrefixInvoice", DbType.String, pItem.FrefixInvoice);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CorporationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_Actualiza");

            db.AddInParameter(dbCommand, "pIdCorporation", DbType.Int32, pItem.IdCorporation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameCorporation", DbType.String, pItem.NameCorporation);
            db.AddInParameter(dbCommand, "pFrefixInvoice", DbType.String, pItem.FrefixInvoice);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CorporationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_Elimina");

            db.AddInParameter(dbCommand, "pIdCorporation", DbType.Int32, pItem.IdCorporation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public CorporationBE Selecciona(int IdCorporation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_Selecciona");
            db.AddInParameter(dbCommand, "pidCorporation", DbType.Int32, IdCorporation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CorporationBE Corporation = null;
            while (reader.Read())
            {
                Corporation = new CorporationBE();
                Corporation.IdCorporation = Int32.Parse(reader["idCorporation"].ToString());
                Corporation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Corporation.NameCorporation = reader["NameCorporation"].ToString();
                Corporation.FrefixInvoice = reader["FrefixInvoice"].ToString();
                Corporation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Corporation;
        }

        public CorporationBE SeleccionaDescripcion(int IdCompany, string NameCorporation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameCorporation", DbType.String, NameCorporation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CorporationBE Corporation = null;
            while (reader.Read())
            {
                Corporation = new CorporationBE();
                Corporation.IdCorporation = Int32.Parse(reader["idCorporation"].ToString());
                Corporation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Corporation.NameCorporation = reader["NameCorporation"].ToString();
                Corporation.FrefixInvoice = reader["FrefixInvoice"].ToString();
                Corporation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Corporation;
        }

        public List<CorporationBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Corporation_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CorporationBE> Corporationlist = new List<CorporationBE>();
            CorporationBE Corporation;
            while (reader.Read())
            {
                Corporation = new CorporationBE();
                Corporation.IdCorporation = Int32.Parse(reader["idCorporation"].ToString());
                Corporation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Corporation.NameCorporation = reader["NameCorporation"].ToString();
                Corporation.FrefixInvoice = reader["FrefixInvoice"].ToString();
                Corporation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Corporationlist.Add(Corporation);
            }
            reader.Close();
            reader.Dispose();
            return Corporationlist;
        }
    }
}
