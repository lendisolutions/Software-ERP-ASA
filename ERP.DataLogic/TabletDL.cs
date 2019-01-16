using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TabletDL
    {
        public TabletDL() { }

        public void Inserta(TabletBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tablet_Inserta");

            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, pItem.IdTablet);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTablet", DbType.String, pItem.NameTablet);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TabletBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tablet_Actualiza");

            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, pItem.IdTablet);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTablet", DbType.String, pItem.NameTablet);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TabletBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tablet_Elimina");

            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, pItem.IdTablet);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TabletBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tablet_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TabletBE> Tabletlist = new List<TabletBE>();
            TabletBE Tablet;
            while (reader.Read())
            {
                Tablet = new TabletBE();
                Tablet.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Tablet.IdTablet = Int32.Parse(reader["idTablet"].ToString());
                Tablet.NameTablet = reader["NameTablet"].ToString();
                Tablet.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Tabletlist.Add(Tablet);
            }
            reader.Close();
            reader.Dispose();
            return Tabletlist;
        }
    }
}
