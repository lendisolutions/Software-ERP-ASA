using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class CompanyDL
    {
        public CompanyDL() { }

        public void Inserta(CompanyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_Inserta");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pNameCompany", DbType.String, pItem.NameCompany);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pEconomyActivity", DbType.String, pItem.EconomyActivity);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CompanyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_Actualiza");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pNameCompany", DbType.String, pItem.NameCompany);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pEconomyActivity", DbType.String, pItem.EconomyActivity);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CompanyBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_Elimina");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public CompanyBE Selecciona(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_Selecciona");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CompanyBE Company = null;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.Ruc = reader["Ruc"].ToString();
                Company.NameCompany = reader["NameCompany"].ToString();
                Company.Address = reader["Address"].ToString();
                Company.Phone = reader["Phone"].ToString();
                Company.EconomyActivity = reader["EconomyActivity"].ToString();
                Company.Logo = (byte[])reader["Logo"];
                Company.FlagState = Boolean.Parse(reader["flagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Company;
        }

        public List<CompanyBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_Selecciona");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CompanyBE> Companylist = new List<CompanyBE>();
            CompanyBE Company;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.Ruc = reader["Ruc"].ToString();
                Company.NameCompany = reader["NameCompany"].ToString();
                Company.Address = reader["Address"].ToString();
                Company.Phone = reader["Phone"].ToString();
                Company.EconomyActivity = reader["EconomyActivity"].ToString();
                Company.FlagState = Boolean.Parse(reader["flagState"].ToString());
                Companylist.Add(Company);
            }
            reader.Close();
            reader.Dispose();
            return Companylist;
        }

        public List<CompanyBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CompanyBE> Companylist = new List<CompanyBE>();
            CompanyBE Company;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.Ruc = reader["Ruc"].ToString();
                Company.NameCompany = reader["NameCompany"].ToString();
                Company.Address = reader["Address"].ToString();
                Company.Phone = reader["Phone"].ToString();
                Company.EconomyActivity = reader["EconomyActivity"].ToString();
                Company.FlagState = Boolean.Parse(reader["flagState"].ToString());
                Companylist.Add(Company);
            }
            reader.Close();
            reader.Dispose();
            return Companylist;
        }

        public List<CompanyBE> ListaCombo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_ListaCombo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CompanyBE> Companylist = new List<CompanyBE>();
            CompanyBE Company;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.NameCompany = reader["NameCompany"].ToString();
                Companylist.Add(Company);
            }
            reader.Close();
            reader.Dispose();
            return Companylist;
        }

        public CompanyBE SeleccionaDescripcion(string NameCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_SeleccionaDescripcion");

            db.AddInParameter(dbCommand, "pNameCompany", DbType.Int32, NameCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CompanyBE Company = null;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.Ruc = reader["Ruc"].ToString();
                Company.NameCompany = reader["NameCompany"].ToString();
                Company.Address = reader["Address"].ToString();
                Company.Phone = reader["Phone"].ToString();
                Company.EconomyActivity = reader["EconomyActivity"].ToString();
                Company.FlagState = Boolean.Parse(reader["flagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Company;
        }

        public CompanyBE SeleccionaRuc(string Ruc)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Company_SeleccionaRuc");

            db.AddInParameter(dbCommand, "pRuc", DbType.String, Ruc);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CompanyBE Company = null;
            while (reader.Read())
            {
                Company = new CompanyBE();
                Company.IdCompany = Int32.Parse(reader["idCompany"].ToString());
                Company.Ruc = reader["Ruc"].ToString();
                Company.NameCompany = reader["NameCompany"].ToString();
                Company.Address = reader["Address"].ToString();
                Company.Phone = reader["Phone"].ToString();
                Company.EconomyActivity = reader["EconomyActivity"].ToString();
                Company.FlagState = Boolean.Parse(reader["flagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Company;
        }
    }
}
