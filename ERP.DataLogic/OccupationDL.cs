using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class OccupationDL
    {
        public void Inserta(OccupationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_Inserta");

            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameOccupation", DbType.String, pItem.NameOccupation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(OccupationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_Actualiza");

            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameOccupation", DbType.String, pItem.NameOccupation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(OccupationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_Elimina");

            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public OccupationBE Selecciona(int idOccupation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_Selecciona");
            db.AddInParameter(dbCommand, "pidOccupation", DbType.Int32, idOccupation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            OccupationBE Occupation = null;
            while (reader.Read())
            {
                Occupation = new OccupationBE();
                Occupation.IdOccupation = Int32.Parse(reader["idOccupation"].ToString());
                Occupation.NameOccupation = reader["NameOccupation"].ToString();
                Occupation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Occupation;
        }

        public OccupationBE SeleccionaDescripcion(string Descripcion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pNameOccupation", DbType.String, Descripcion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            OccupationBE Occupation = null;
            while (reader.Read())
            {
                Occupation = new OccupationBE();
                Occupation.IdOccupation = Int32.Parse(reader["idOccupation"].ToString());
                Occupation.NameOccupation = reader["NameOccupation"].ToString();
                Occupation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Occupation;
        }

        public List<OccupationBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Occupation_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<OccupationBE> Occupationlist = new List<OccupationBE>();
            OccupationBE Occupation;
            while (reader.Read())
            {
                Occupation = new OccupationBE();
                Occupation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Occupation.IdOccupation = Int32.Parse(reader["idOccupation"].ToString());
                Occupation.NameOccupation = reader["NameOccupation"].ToString();
                Occupation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Occupationlist.Add(Occupation);
            }
            reader.Close();
            reader.Dispose();
            return Occupationlist;
        }
    }
}
