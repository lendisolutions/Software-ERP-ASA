using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ElementTabletDL
    {
        public ElementTabletDL() { }

        public Int32 Inserta(ElementTabletBE pItem)
        {
            Int32 intElementTablet = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ElementTablet_Inserta");

            db.AddOutParameter(dbCommand, "pIdElementTablet", DbType.Int32, pItem.IdElementTablet);
            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, pItem.IdTablet);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameElementTablet", DbType.String, pItem.NameElementTablet);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
            intElementTablet = (int)db.GetParameterValue(dbCommand, "pIdElementTablet");

            return intElementTablet;
        }

        public void Actualiza(ElementTabletBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ElementTablet_Actualiza");

            db.AddInParameter(dbCommand, "pIdElementTablet", DbType.Int32, pItem.IdElementTablet);
            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, pItem.IdTablet);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameElementTablet", DbType.String, pItem.NameElementTablet);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ElementTabletBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ElementTablet_Elimina");

            db.AddInParameter(dbCommand, "pIdElementTablet", DbType.Int32, pItem.IdElementTablet);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public ElementTabletBE SeleccionaDescripcion(int IdTablet, string NameElementTablet)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ElementTablet_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, IdTablet);
            db.AddInParameter(dbCommand, "pNameElementTablet", DbType.String, NameElementTablet);

            IDataReader reader = db.ExecuteReader(dbCommand);

            ElementTabletBE ElementTablet = null;
            while (reader.Read())
            {
                ElementTablet = new ElementTabletBE();
                ElementTablet.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ElementTablet.IdElementTablet = Int32.Parse(reader["idElementTablet"].ToString());
                ElementTablet.IdTablet = Int32.Parse(reader["IdTablet"].ToString());
                ElementTablet.NameTablet = reader["NameTablet"].ToString();
                ElementTablet.Abbreviate = reader["Abbreviate"].ToString();
                ElementTablet.NameElementTablet = reader["NameElementTablet"].ToString();
                ElementTablet.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            //ElementTabletlist.Insert(0, new ElementTabletBE() { IdElementTablet = 0, NameElementTablet = "TODOS" });
            return ElementTablet;
        }

        public List<ElementTabletBE> ListaTodosActivo(int IdCompany, int IdTablet)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ElementTablet_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdTablet", DbType.Int32, IdTablet);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ElementTabletBE> ElementTabletlist = new List<ElementTabletBE>();
            ElementTabletBE ElementTablet;
            while (reader.Read())
            {
                ElementTablet = new ElementTabletBE();
                ElementTablet.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ElementTablet.IdElementTablet = Int32.Parse(reader["idElementTablet"].ToString());
                ElementTablet.IdTablet = Int32.Parse(reader["IdTablet"].ToString());
                ElementTablet.NameTablet = reader["NameTablet"].ToString();
                ElementTablet.Abbreviate = reader["Abbreviate"].ToString();
                ElementTablet.NameElementTablet = reader["NameElementTablet"].ToString();
                ElementTablet.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ElementTabletlist.Add(ElementTablet);
            }
            reader.Close();
            reader.Dispose();
            //ElementTabletlist.Insert(0, new ElementTabletBE() { IdElementTablet = 0, NameElementTablet = "TODOS" });
            return ElementTabletlist;
        }
    }
}
