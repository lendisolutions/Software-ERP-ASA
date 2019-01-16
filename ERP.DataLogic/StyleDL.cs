using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class StyleDL
    {
        public StyleDL() { }

        public void Inserta(StyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Style_Inserta");

            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pNameStyle", DbType.String, pItem.NameStyle);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pDescription", DbType.String, pItem.Description);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdMediaUnit", DbType.Int32, pItem.IdMediaUnit);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(StyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Style_Actualiza");

            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pNameStyle", DbType.String, pItem.NameStyle);
            db.AddInParameter(dbCommand, "pRevenueDate", DbType.DateTime, pItem.RevenueDate);
            db.AddInParameter(dbCommand, "pDescription", DbType.String, pItem.Description);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdMediaUnit", DbType.Int32, pItem.IdMediaUnit);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(StyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Style_Elimina");

            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public StyleBE Selecciona(int IdStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Style_Selecciona");
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, IdStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StyleBE Style = null;
            while (reader.Read())
            {
                Style = new StyleBE();
                Style.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                Style.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Style.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Style.NameClient = reader["NameClient"].ToString();
                Style.NameStyle = reader["NameStyle"].ToString();
                Style.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Style.Description = reader["Description"].ToString();
                Style.Item = reader["Item"].ToString();
                Style.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                Style.MameDivision = reader["NameDivision"].ToString();
                Style.IdMediaUnit = Int32.Parse(reader["IdMediaUnit"].ToString());
                Style.NameMediaUnit = reader["NameMediaUnit"].ToString();
                Style.Situation = reader["Situation"].ToString();
                Style.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Style;
        }

        
        public List<StyleBE> ListaTodosActivo(int IdCompany, int IdClient, int IdClientDepartment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Style_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, IdClientDepartment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StyleBE> Stylelist = new List<StyleBE>();
            StyleBE Style;
            while (reader.Read())
            {
                Style = new StyleBE();
                Style.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                Style.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Style.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Style.NameClient = reader["NameClient"].ToString();
                Style.NameStyle = reader["NameStyle"].ToString();
                Style.RevenueDate = DateTime.Parse(reader["RevenueDate"].ToString());
                Style.Description = reader["Description"].ToString();
                Style.Item = reader["Item"].ToString();
                Style.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                Style.MameDivision = reader["NameDivision"].ToString();
                Style.IdMediaUnit = Int32.Parse(reader["IdMediaUnit"].ToString());
                Style.NameMediaUnit = reader["NameMediaUnit"].ToString();
                Style.Situation = reader["Situation"].ToString();
                Style.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Stylelist.Add(Style);
            }
            reader.Close();
            reader.Dispose();
            return Stylelist;
        }
    }
}
