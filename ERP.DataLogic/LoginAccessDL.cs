using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class LoginAccessDL
    {
        public LoginAccessDL() { }

        public void Inserta(LoginAccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_Inserta");

            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagRead", DbType.Boolean, pItem.FlagRead);
            db.AddInParameter(dbCommand, "pFlagAdd", DbType.Boolean, pItem.FlagAdd);
            db.AddInParameter(dbCommand, "pFlagUpdate", DbType.Boolean, pItem.FlagUpdate);
            db.AddInParameter(dbCommand, "pFlagDelete", DbType.Boolean, pItem.FlagDelete);
            db.AddInParameter(dbCommand, "pFlagPrint", DbType.Boolean, pItem.FlagPrint);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(LoginAccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_Actualiza");

            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagRead", DbType.Boolean, pItem.FlagRead);
            db.AddInParameter(dbCommand, "pFlagAdd", DbType.Boolean, pItem.FlagAdd);
            db.AddInParameter(dbCommand, "pFlagUpdate", DbType.Boolean, pItem.FlagUpdate);
            db.AddInParameter(dbCommand, "pFlagDelete", DbType.Boolean, pItem.FlagDelete);
            db.AddInParameter(dbCommand, "pFlagPrint", DbType.Boolean, pItem.FlagPrint);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(LoginAccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_Elimina");

            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, pItem.IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<LoginAccessBE> SeleccionaCriterioVarios(int IdLogin, int IdProfile)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_SeleccionaUserPerfil");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, IdProfile);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginAccessBE> LoginAccesslist = new List<LoginAccessBE>();
            LoginAccessBE LoginAccess;
            while (reader.Read())
            {
                LoginAccess = new LoginAccessBE();
                LoginAccess.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginAccess.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginAccess.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                LoginAccess.FlagRead = Boolean.Parse(reader["FlagRead"].ToString());
                LoginAccess.FlagAdd = Boolean.Parse(reader["FlagAdd"].ToString());
                LoginAccess.FlagUpdate = Boolean.Parse(reader["FlagUpdate"].ToString());
                LoginAccess.FlagDelete = Boolean.Parse(reader["FlagDelete"].ToString());
                LoginAccess.FlagPrint = Boolean.Parse(reader["FlagPrint"].ToString());
                LoginAccess.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginAccesslist.Add(LoginAccess);
            }
            reader.Close();
            reader.Dispose();
            return LoginAccesslist;
        }

        public List<LoginAccessBE> SeleccionaUser(int IdLogin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_SeleccionaLogin");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginAccessBE> LoginAccesslist = new List<LoginAccessBE>();
            LoginAccessBE LoginAccess;
            while (reader.Read())
            {
                LoginAccess = new LoginAccessBE();
                LoginAccess.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginAccess.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginAccess.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                LoginAccess.MenuCode = reader["MenuCode"].ToString();
                LoginAccess.IdMenuFather = Int32.Parse(reader["IdMenuFather"].ToString());
                LoginAccess.MenuDescription = reader["MenuDescription"].ToString();
                LoginAccess.Picture = reader["Picture"].ToString();
                LoginAccess.LargePicture = Boolean.Parse(reader["LargePicture"].ToString());
                LoginAccess.Class = reader["Class"].ToString();
                LoginAccess.Assembly = reader["Assembly"].ToString();
                LoginAccess.IdTypeMenu = Int32.Parse(reader["IdTypeMenu"].ToString());
                LoginAccess.WindowLoadMode = Byte.Parse(reader["WindowLoadMode"].ToString());
                LoginAccesslist.Add(LoginAccess);
            }
            reader.Close();
            reader.Dispose();
            return LoginAccesslist;
        }

        public List<LoginAccessBE> SeleccionaPermisoAcceso(string Login, int IdProfile)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_SeleccionaPermisoAcceso");
            db.AddInParameter(dbCommand, "pLogin", DbType.String, Login);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, IdProfile);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginAccessBE> LoginAccesslist = new List<LoginAccessBE>();
            LoginAccessBE LoginAccess;
            while (reader.Read())
            {
                LoginAccess = new LoginAccessBE();
                LoginAccess.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginAccess.Login = reader["Login"].ToString();
                LoginAccess.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginAccess.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                LoginAccess.Class = reader["Class"].ToString();
                LoginAccess.Assembly = reader["Assembly"].ToString();
                LoginAccess.FlagRead = Boolean.Parse(reader["FlagRead"].ToString());
                LoginAccess.FlagAdd = Boolean.Parse(reader["FlagAdd"].ToString());
                LoginAccess.FlagUpdate = Boolean.Parse(reader["FlagUpdate"].ToString());
                LoginAccess.FlagDelete = Boolean.Parse(reader["FlagDelete"].ToString());
                LoginAccess.FlagPrint = Boolean.Parse(reader["FlagPrint"].ToString());
                LoginAccess.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginAccesslist.Add(LoginAccess);
            }
            reader.Close();
            reader.Dispose();
            return LoginAccesslist;
        }

        public List<LoginAccessBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginAccessBE> LoginAccesslist = new List<LoginAccessBE>();
            LoginAccessBE LoginAccess;
            while (reader.Read())
            {
                LoginAccess = new LoginAccessBE();
                LoginAccess.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginAccess.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginAccess.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                LoginAccess.FlagRead = Boolean.Parse(reader["FlagRead"].ToString());
                LoginAccess.FlagAdd = Boolean.Parse(reader["FlagAdd"].ToString());
                LoginAccess.FlagUpdate = Boolean.Parse(reader["FlagUpdate"].ToString());
                LoginAccess.FlagDelete = Boolean.Parse(reader["FlagDelete"].ToString());
                LoginAccess.FlagPrint = Boolean.Parse(reader["FlagPrint"].ToString());
                LoginAccess.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginAccesslist.Add(LoginAccess);
            }
            reader.Close();
            reader.Dispose();
            return LoginAccesslist;
        }

        public List<LoginAccessBE> SeleccionaUserPerfil(int IdLogin, int IdProfile)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LoginAccess_SeleccionaLoginProfile");
            db.AddInParameter(dbCommand, "pIdLogin", DbType.Int32, IdLogin);
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, IdProfile);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LoginAccessBE> LoginAccesslist = new List<LoginAccessBE>();
            LoginAccessBE LoginAccess;
            while (reader.Read())
            {
                LoginAccess = new LoginAccessBE();
                LoginAccess.IdLogin = Int32.Parse(reader["IdLogin"].ToString());
                LoginAccess.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                LoginAccess.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                LoginAccess.FlagRead = Boolean.Parse(reader["FlagRead"].ToString());
                LoginAccess.FlagAdd = Boolean.Parse(reader["FlagAdd"].ToString());
                LoginAccess.FlagUpdate = Boolean.Parse(reader["FlagUpdate"].ToString());
                LoginAccess.FlagDelete = Boolean.Parse(reader["FlagDelete"].ToString());
                LoginAccess.FlagPrint = Boolean.Parse(reader["FlagPrint"].ToString());
                LoginAccess.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                LoginAccess.TipoOper = 4;
                LoginAccesslist.Add(LoginAccess);
            }
            reader.Close();
            reader.Dispose();
            return LoginAccesslist;
        }
    }
}
