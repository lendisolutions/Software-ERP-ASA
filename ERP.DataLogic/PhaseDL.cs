using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class PhaseDL
    {
        public PhaseDL() { }

        public void Inserta(PhaseBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_Inserta");

            db.AddInParameter(dbCommand, "pIdPhase", DbType.Int32, pItem.IdPhase);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNamePhase", DbType.String, pItem.NamePhase);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PhaseBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_Actualiza");

            db.AddInParameter(dbCommand, "pIdPhase", DbType.Int32, pItem.IdPhase);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNamePhase", DbType.String, pItem.NamePhase);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PhaseBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_Elimina");

            db.AddInParameter(dbCommand, "pIdPhase", DbType.Int32, pItem.IdPhase);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public PhaseBE Selecciona(int IdPhase)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_Selecciona");
            db.AddInParameter(dbCommand, "pidPhase", DbType.Int32, IdPhase);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PhaseBE Phase = null;
            while (reader.Read())
            {
                Phase = new PhaseBE();
                Phase.IdPhase = Int32.Parse(reader["idPhase"].ToString());
                Phase.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Phase.NamePhase = reader["NamePhase"].ToString();
                Phase.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Phase;
        }

        public PhaseBE SeleccionaDescripcion(int IdCompany, string NamePhase)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNamePhase", DbType.String, NamePhase);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PhaseBE Phase = null;
            while (reader.Read())
            {
                Phase = new PhaseBE();
                Phase.IdPhase = Int32.Parse(reader["idPhase"].ToString());
                Phase.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Phase.NamePhase = reader["NamePhase"].ToString();
                Phase.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Phase;
        }

        public List<PhaseBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Phase_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PhaseBE> Phaselist = new List<PhaseBE>();
            PhaseBE Phase;
            while (reader.Read())
            {
                Phase = new PhaseBE();
                Phase.IdPhase = Int32.Parse(reader["idPhase"].ToString());
                Phase.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Phase.NamePhase = reader["NamePhase"].ToString();
                Phase.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Phaselist.Add(Phase);
            }
            reader.Close();
            reader.Dispose();
            return Phaselist;
        }
    }
}
