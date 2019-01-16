using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class GroupStyleDL
    {
        public GroupStyleDL() { }

        public void Inserta(GroupStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_Inserta");

            db.AddInParameter(dbCommand, "pIdGroupStyle", DbType.Int32, pItem.IdGroupStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameGroupStyle", DbType.String, pItem.NameGroupStyle);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(GroupStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_Actualiza");

            db.AddInParameter(dbCommand, "pIdGroupStyle", DbType.Int32, pItem.IdGroupStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameGroupStyle", DbType.String, pItem.NameGroupStyle);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(GroupStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_Elimina");

            db.AddInParameter(dbCommand, "pIdGroupStyle", DbType.Int32, pItem.IdGroupStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public GroupStyleBE Selecciona(int IdGroupStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_Selecciona");
            db.AddInParameter(dbCommand, "pidGroupStyle", DbType.Int32, IdGroupStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            GroupStyleBE GroupStyle = null;
            while (reader.Read())
            {
                GroupStyle = new GroupStyleBE();
                GroupStyle.IdGroupStyle = Int32.Parse(reader["idGroupStyle"].ToString());
                GroupStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                GroupStyle.NameGroupStyle = reader["NameGroupStyle"].ToString();
                GroupStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return GroupStyle;
        }

        public GroupStyleBE SeleccionaDescripcion(int IdCompany, string NameGroupStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameGroupStyle", DbType.String, NameGroupStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            GroupStyleBE GroupStyle = null;
            while (reader.Read())
            {
                GroupStyle = new GroupStyleBE();
                GroupStyle.IdGroupStyle = Int32.Parse(reader["idGroupStyle"].ToString());
                GroupStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                GroupStyle.NameGroupStyle = reader["NameGroupStyle"].ToString();
                GroupStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return GroupStyle;
        }

        public List<GroupStyleBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GroupStyle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<GroupStyleBE> GroupStylelist = new List<GroupStyleBE>();
            GroupStyleBE GroupStyle;
            while (reader.Read())
            {
                GroupStyle = new GroupStyleBE();
                GroupStyle.IdGroupStyle = Int32.Parse(reader["idGroupStyle"].ToString());
                GroupStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                GroupStyle.NameGroupStyle = reader["NameGroupStyle"].ToString();
                GroupStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                GroupStylelist.Add(GroupStyle);
            }
            reader.Close();
            reader.Dispose();
            return GroupStylelist;
        }
    }
}
