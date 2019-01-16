using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class CurrencyDL
    {
        public CurrencyDL() { }

        public void Inserta(CurrencyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_Inserta");

            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameCurrency", DbType.String, pItem.NameCurrency);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CurrencyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_Actualiza");

            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameCurrency", DbType.String, pItem.NameCurrency);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CurrencyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_Elimina");

            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public CurrencyBE Selecciona(int IdCurrency)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_Selecciona");
            db.AddInParameter(dbCommand, "pidCurrency", DbType.Int32, IdCurrency);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CurrencyBE Currency = null;
            while (reader.Read())
            {
                Currency = new CurrencyBE();
                Currency.IdCurrency = Int32.Parse(reader["idCurrency"].ToString());
                Currency.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Currency.Abbreviate = reader["Abbreviate"].ToString();
                Currency.NameCurrency = reader["NameCurrency"].ToString();
                Currency.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Currency;
        }

        public CurrencyBE SeleccionaDescripcion(int IdCompany, string NameCurrency)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameCurrency", DbType.String, NameCurrency);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CurrencyBE Currency = null;
            while (reader.Read())
            {
                Currency = new CurrencyBE();
                Currency.IdCurrency = Int32.Parse(reader["idCurrency"].ToString());
                Currency.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Currency.Abbreviate = reader["Abbreviate"].ToString();
                Currency.NameCurrency = reader["NameCurrency"].ToString();
                Currency.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Currency;
        }

        public List<CurrencyBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CurrencyBE> Currencylist = new List<CurrencyBE>();
            CurrencyBE Currency;
            while (reader.Read())
            {
                Currency = new CurrencyBE();
                Currency.IdCurrency = Int32.Parse(reader["idCurrency"].ToString());
                Currency.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Currency.Abbreviate = reader["Abbreviate"].ToString();
                Currency.NameCurrency = reader["NameCurrency"].ToString();
                Currency.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Currencylist.Add(Currency);
            }
            reader.Close();
            reader.Dispose();
            return Currencylist;
        }

        public List<CurrencyBE> ListaCombo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Currency_ListaCombo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CurrencyBE> Currencylist = new List<CurrencyBE>();
            CurrencyBE Currency;
            while (reader.Read())
            {
                Currency = new CurrencyBE();
                Currency.IdCurrency = Int32.Parse(reader["idCurrency"].ToString());
                Currency.NameCurrency = reader["NameCurrency"].ToString();
                Currencylist.Add(Currency);
            }
            reader.Close();
            reader.Dispose();
            return Currencylist;
        }
    }
}
