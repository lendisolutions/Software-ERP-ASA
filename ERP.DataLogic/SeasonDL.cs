using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class SeasonDL
    {
        public SeasonDL() { }

        public void Inserta(SeasonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_Inserta");

            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, pItem.IdSeason);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameSeason", DbType.String, pItem.NameSeason);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SeasonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_Actualiza");

            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, pItem.IdSeason);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameSeason", DbType.String, pItem.NameSeason);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SeasonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_Elimina");

            db.AddInParameter(dbCommand, "pIdSeason", DbType.Int32, pItem.IdSeason);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public SeasonBE Selecciona(int IdSeason)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_Selecciona");
            db.AddInParameter(dbCommand, "pidSeason", DbType.Int32, IdSeason);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeasonBE Season = null;
            while (reader.Read())
            {
                Season = new SeasonBE();
                Season.IdSeason = Int32.Parse(reader["idSeason"].ToString());
                Season.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Season.NameSeason = reader["NameSeason"].ToString();
                Season.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Season;
        }

        public SeasonBE SeleccionaDescripcion(int IdCompany, string NameSeason)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameSeason", DbType.String, NameSeason);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeasonBE Season = null;
            while (reader.Read())
            {
                Season = new SeasonBE();
                Season.IdSeason = Int32.Parse(reader["idSeason"].ToString());
                Season.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Season.NameSeason = reader["NameSeason"].ToString();
                Season.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Season;
        }

        public List<SeasonBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Season_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeasonBE> Seasonlist = new List<SeasonBE>();
            SeasonBE Season;
            while (reader.Read())
            {
                Season = new SeasonBE();
                Season.IdSeason = Int32.Parse(reader["idSeason"].ToString());
                Season.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Season.NameSeason = reader["NameSeason"].ToString();
                Season.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Seasonlist.Add(Season);
            }
            reader.Close();
            reader.Dispose();
            return Seasonlist;
        }
    }
}
