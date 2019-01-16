using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class LoginDL
    {
        public LoginDL() { }

        public Int32 Inserta(LoginBE pItem)
        {
            Int32 intIdLogin = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_Inserta");

            db.AddOutParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pNameLogin", DbType.String, pItem.NameLogin);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, pItem.Password);
            db.AddInParameter(dbCommand, "pFlagMaster", DbType.Boolean, pItem.FlagMaster);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLoginCrea", DbType.String, pItem.LoginCrea);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdLogin = (int)db.GetParameterValue(dbCommand, "pIdLogin");

            return intIdLogin;
        }

        public void Actualiza(LoginBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_Actualiza");

            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pNameLogin", DbType.String, pItem.NameLogin);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, pItem.Password);
            db.AddInParameter(dbCommand, "pFlagMaster", DbType.Boolean, pItem.FlagMaster);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLoginCrea", DbType.String, pItem.LoginCrea);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);


        }

        public void Elimina(LoginBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_Elimina");

            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);


        }

        public LoginBE Selecciona(int idLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_Selecciona");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, idLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LoginBE Login = null;
            while (reader.Read())
            {
                Login = new LoginBE();
                Login.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                Login.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                Login.NameProfile = reader["NameProfile"].ToString();
                Login.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Login.NameCompany = reader["NameCompany"].ToString();
                Login.IdEmployee = Int32.Parse(reader["IdEmployee"].ToString());
                Login.Login = reader["Login"].ToString();
                Login.NameLogin = reader["NameLogin"].ToString();
                Login.Password = reader["password"].ToString();
                Login.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                Login.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Login;
        }

        public LoginBE SeleccionaLogin(string Login)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_SeleccionaLogin");
            db.AddInParameter(dbCommand, "pLogin", DbType.String, Login);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LoginBE LoginBE = null;
            while (reader.Read())
            {
                LoginBE = new LoginBE();
                LoginBE.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginBE.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginBE.NameProfile = reader["NameProfile"].ToString();
                LoginBE.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                LoginBE.NameCompany = reader["NameCompany"].ToString();
                LoginBE.IdEmployee = Int32.Parse(reader["IdEmployee"].ToString());
                LoginBE.Login = reader["Login"].ToString();
                LoginBE.NameLogin = reader["NameLogin"].ToString();
                LoginBE.Password = reader["password"].ToString();
                LoginBE.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                LoginBE.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return LoginBE;
        }

        public LoginBE LogOnUser(string Login, string Password)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_LogOn");
            db.AddInParameter(dbCommand, "pLogin", DbType.String, Login);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, Password);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LoginBE LoginBE = null;
            while (reader.Read())
            {
                LoginBE = new LoginBE();
                LoginBE.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginBE.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginBE.NameProfile = reader["NameProfile"].ToString();
                LoginBE.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                LoginBE.NameCompany = reader["NameCompany"].ToString();
                LoginBE.IdEmployee = Int32.Parse(reader["IdEmployee"].ToString());
                LoginBE.FullName = reader["FullName"].ToString();
                LoginBE.Login = reader["Login"].ToString();
                LoginBE.NameLogin = reader["NameLogin"].ToString();
                LoginBE.Password = reader["password"].ToString();
                LoginBE.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                LoginBE.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return LoginBE;
        }

        public List<LoginBE> SeleccionaEmpresa(int IdCompany, string NameLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_SeleccionaCompany");

            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameLogin", DbType.String, NameLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginBE> Loginlist = new List<LoginBE>();
            LoginBE Login;
            while (reader.Read())
            {
                Login = new LoginBE();
                Login.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                Login.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                Login.NameProfile = reader["nomperfil"].ToString();
                Login.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Login.NameCompany = reader["NameCompany"].ToString();
                Login.IdEmployee = Int32.Parse(reader["IdEmployee"].ToString());
                Login.Login = reader["Login"].ToString();
                Login.NameLogin = reader["NameLogin"].ToString();
                Login.Password = reader["password"].ToString();
                Login.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                Login.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Loginlist.Add(Login);
            }
            reader.Close();
            reader.Dispose();
            return Loginlist;
        }

        public List<LoginBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Login_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginBE> Loginlist = new List<LoginBE>();
            LoginBE Login;
            while (reader.Read())
            {
                Login = new LoginBE();
                Login.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                Login.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                Login.NameProfile = reader["NameProfile"].ToString();
                Login.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Login.IdEmployee = Int32.Parse(reader["IdEmployee"].ToString());
                Login.Login = reader["Login"].ToString();
                Login.NameLogin = reader["NameLogin"].ToString();
                Login.Password = reader["password"].ToString();
                Login.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                Login.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Loginlist.Add(Login);
            }
            reader.Close();
            reader.Dispose();
            return Loginlist;
        }
    }
}
