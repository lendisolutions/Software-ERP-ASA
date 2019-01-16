using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class LoginClientDepartmentDL
    {
        public LoginClientDepartmentDL() { }

        public void Inserta(LoginClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_Inserta");

            db.AddInParameter(dbCommand, "pIdLoginClientDepartment", DbType.Int32, pItem.IdLoginClientDepartment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(LoginClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_Actualiza");

            db.AddInParameter(dbCommand, "pIdLoginClientDepartment", DbType.Int32, pItem.IdLoginClientDepartment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(LoginClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_Elimina");

            db.AddInParameter(dbCommand, "pIdLoginClientDepartment", DbType.Int32, pItem.IdLoginClientDepartment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);


            db.ExecuteNonQuery(dbCommand);
        }

        public List<LoginClientDepartmentBE> ListaEmpresaLogin(int IdCompany, int IdLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_ListaCompanyLogin");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginClientDepartmentBE> LoginClientDepartmentlist = new List<LoginClientDepartmentBE>();
            LoginClientDepartmentBE LoginClientDepartment;
            while (reader.Read())
            {
                LoginClientDepartment = new LoginClientDepartmentBE();
                LoginClientDepartment.IdLoginClientDepartment = Int32.Parse(reader["IdLoginClientDepartment"].ToString());
                LoginClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                LoginClientDepartment.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginClientDepartment.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                LoginClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginClientDepartment.TipoOper = 4;
                LoginClientDepartmentlist.Add(LoginClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return LoginClientDepartmentlist;
        }

        public List<LoginClientDepartmentBE> ListaEmpresaUnidadULogin(int IdCompany, int IdClientDepartment, int IdLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_ListaCompanyUnidadLogin");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginClientDepartmentBE> LoginClientDepartmentlist = new List<LoginClientDepartmentBE>();
            LoginClientDepartmentBE LoginClientDepartment;
            while (reader.Read())
            {
                LoginClientDepartment = new LoginClientDepartmentBE();
                LoginClientDepartment.IdLoginClientDepartment = Int32.Parse(reader["IdLoginClientDepartment"].ToString());
                LoginClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                LoginClientDepartment.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginClientDepartment.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                LoginClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginClientDepartment.TipoOper = 4;
                LoginClientDepartmentlist.Add(LoginClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return LoginClientDepartmentlist;
        }

        public List<LoginClientDepartmentBE> ListaLogin(int IdLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_ListaLogin");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginClientDepartmentBE> LoginClientDepartmentlist = new List<LoginClientDepartmentBE>();
            LoginClientDepartmentBE LoginClientDepartment;
            while (reader.Read())
            {
                LoginClientDepartment = new LoginClientDepartmentBE();
                LoginClientDepartment.IdLoginClientDepartment = Int32.Parse(reader["IdLoginClientDepartment"].ToString());
                LoginClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                LoginClientDepartment.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                LoginClientDepartment.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                LoginClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginClientDepartment.TipoOper = 4;
                LoginClientDepartmentlist.Add(LoginClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return LoginClientDepartmentlist;
        }

        public List<LoginClientDepartmentBE> ListaClient(int IdLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_ListaClient");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginClientDepartmentBE> LoginClientDepartmentlist = new List<LoginClientDepartmentBE>();
            LoginClientDepartmentBE LoginClientDepartment;
            while (reader.Read())
            {
                LoginClientDepartment = new LoginClientDepartmentBE();
                LoginClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                LoginClientDepartment.NameClient = reader["NameClient"].ToString();
                LoginClientDepartmentlist.Add(LoginClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return LoginClientDepartmentlist;
        }

        public List<LoginClientDepartmentBE> ListaClientDivision(int IdLogin, int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginClientDepartment_ListaClientDivision");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginClientDepartmentBE> LoginClientDepartmentlist = new List<LoginClientDepartmentBE>();
            LoginClientDepartmentBE LoginClientDepartment;
            while (reader.Read())
            {
                LoginClientDepartment = new LoginClientDepartmentBE();
                LoginClientDepartment.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                LoginClientDepartment.NameDivision = reader["NameDivision"].ToString();
                LoginClientDepartmentlist.Add(LoginClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return LoginClientDepartmentlist;
        }
    }
}
