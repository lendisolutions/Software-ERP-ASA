using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class AccessDL
    {
        public AccessDL() { }

        public void Inserta(AccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Access_Inserta");

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

        public void Actualiza(AccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Access_Actualiza");

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

        public void Elimina(AccessBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Access_Elimina");

            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AccessBE> SeleccionaPerfil(int IdProfile)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Access_SeleccionaProfile");
            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, IdProfile);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccessBE> Accesslist = new List<AccessBE>();
            AccessBE Access;
            while (reader.Read())
            {
                Access = new AccessBE();
                Access.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                Access.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                Access.FlagRead = Boolean.Parse(reader["flagRead"].ToString());
                Access.FlagAdd = Boolean.Parse(reader["flagAdd"].ToString());
                Access.FlagUpdate = Boolean.Parse(reader["flagUpdate"].ToString());
                Access.FlagDelete = Boolean.Parse(reader["flagDelete"].ToString());
                Access.FlagPrint = Boolean.Parse(reader["flagPrint"].ToString());
                Access.FlagState = Boolean.Parse(reader["flagState"].ToString());
                Access.TipOper = 4;
                Accesslist.Add(Access);
            }
            reader.Close();
            reader.Dispose();
            return Accesslist;
        }

        public List<AccessBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Access_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccessBE> Accesslist = new List<AccessBE>();
            AccessBE Access;
            while (reader.Read())
            {
                Access = new AccessBE();
                Access.IdProfile = Int32.Parse(reader["IdProfile"].ToString());
                Access.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                Access.FlagRead = Boolean.Parse(reader["flagRead"].ToString());
                Access.FlagAdd = Boolean.Parse(reader["flagAdd"].ToString());
                Access.FlagUpdate = Boolean.Parse(reader["flagUpdate"].ToString());
                Access.FlagDelete = Boolean.Parse(reader["flagDelete"].ToString());
                Access.FlagPrint = Boolean.Parse(reader["flagPrint"].ToString());
                Access.FlagState = Boolean.Parse(reader["flagState"].ToString());
                Accesslist.Add(Access);
            }
            reader.Close();
            reader.Dispose();
            return Accesslist;
        }
    }
}
