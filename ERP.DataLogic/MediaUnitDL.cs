using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class MediaUnitDL
    {
        public MediaUnitDL() { }

        public void Inserta(MediaUnitBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_Inserta");

            db.AddInParameter(dbCommand, "pIdMediaUnit", DbType.Int32, pItem.IdMediaUnit);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameMediaUnit", DbType.String, pItem.NameMediaUnit);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(MediaUnitBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_Actualiza");

            db.AddInParameter(dbCommand, "pIdMediaUnit", DbType.Int32, pItem.IdMediaUnit);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameMediaUnit", DbType.String, pItem.NameMediaUnit);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(MediaUnitBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_Elimina");

            db.AddInParameter(dbCommand, "pIdMediaUnit", DbType.Int32, pItem.IdMediaUnit);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public MediaUnitBE Selecciona(int IdMediaUnit)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_Selecciona");
            db.AddInParameter(dbCommand, "pidMediaUnit", DbType.Int32, IdMediaUnit);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MediaUnitBE MediaUnit = null;
            while (reader.Read())
            {
                MediaUnit = new MediaUnitBE();
                MediaUnit.IdMediaUnit = Int32.Parse(reader["idMediaUnit"].ToString());
                MediaUnit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                MediaUnit.Abbreviate = reader["Abbreviate"].ToString();
                MediaUnit.NameMediaUnit = reader["NameMediaUnit"].ToString();
                MediaUnit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MediaUnit;
        }

        public MediaUnitBE SeleccionaDescripcion(int IdCompany, string NameMediaUnit)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameMediaUnit", DbType.String, NameMediaUnit);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MediaUnitBE MediaUnit = null;
            while (reader.Read())
            {
                MediaUnit = new MediaUnitBE();
                MediaUnit.IdMediaUnit = Int32.Parse(reader["idMediaUnit"].ToString());
                MediaUnit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                MediaUnit.Abbreviate = reader["Abbreviate"].ToString();
                MediaUnit.NameMediaUnit = reader["NameMediaUnit"].ToString();
                MediaUnit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MediaUnit;
        }

        public MediaUnitBE SeleccionaAbreviatura(int IdCompany, string Abbreviate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_SeleccionaAbreviatura");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, Abbreviate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MediaUnitBE MediaUnit = null;
            while (reader.Read())
            {
                MediaUnit = new MediaUnitBE();
                MediaUnit.IdMediaUnit = Int32.Parse(reader["idMediaUnit"].ToString());
                MediaUnit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                MediaUnit.Abbreviate = reader["Abbreviate"].ToString();
                MediaUnit.NameMediaUnit = reader["NameMediaUnit"].ToString();
                MediaUnit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MediaUnit;
        }

        public List<MediaUnitBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MediaUnit_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MediaUnitBE> MediaUnitlist = new List<MediaUnitBE>();
            MediaUnitBE MediaUnit;
            while (reader.Read())
            {
                MediaUnit = new MediaUnitBE();
                MediaUnit.IdMediaUnit = Int32.Parse(reader["idMediaUnit"].ToString());
                MediaUnit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                MediaUnit.Abbreviate = reader["Abbreviate"].ToString();
                MediaUnit.NameMediaUnit = reader["NameMediaUnit"].ToString();
                MediaUnit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                MediaUnitlist.Add(MediaUnit);
            }
            reader.Close();
            reader.Dispose();
            return MediaUnitlist;
        }
    }
}
