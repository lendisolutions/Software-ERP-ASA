using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ProgramProductionDevelopmentDL
    {
        public ProgramProductionDevelopmentDL() { }

        public void Inserta(ProgramProductionDevelopmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDevelopment_Inserta");

            db.AddInParameter(dbCommand, "pIdProgramProductionDevelopment", DbType.Int32, pItem.IdProgramProductionDevelopment);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pDevDate", DbType.Date, pItem.DevDate);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, pItem.IdSituation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProgramProductionDevelopmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDevelopment_Actualiza");

            db.AddInParameter(dbCommand, "pIdProgramProductionDevelopment", DbType.Int32, pItem.IdProgramProductionDevelopment);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pDevDate", DbType.Date, pItem.DevDate);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, pItem.IdSituation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProgramProductionDevelopmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDevelopment_Elimina");

            db.AddInParameter(dbCommand, "pIdProgramProductionDevelopment", DbType.Int32, pItem.IdProgramProductionDevelopment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProgramProductionDevelopmentBE Selecciona(int IdProgramProductionDevelopment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDevelopment_Selecciona");
            db.AddInParameter(dbCommand, "pidProgramProductionDevelopment", DbType.Int32, IdProgramProductionDevelopment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProgramProductionDevelopmentBE ProgramProductionDevelopment = null;
            while (reader.Read())
            {
                ProgramProductionDevelopment = new ProgramProductionDevelopmentBE();
                ProgramProductionDevelopment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionDevelopment.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionDevelopment.IdProgramProductionDevelopment = Int32.Parse(reader["idProgramProductionDevelopment"].ToString());
                ProgramProductionDevelopment.DevDate = DateTime.Parse(reader["DevDate"].ToString());
                ProgramProductionDevelopment.Comment = reader["Comment"].ToString();
                ProgramProductionDevelopment.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                ProgramProductionDevelopment.Situation = reader["Situation"].ToString();
                ProgramProductionDevelopment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionDevelopment;
        }

        public List<ProgramProductionDevelopmentBE> ListaTodosActivo(int IdProgramProduction, int IdProgramProductionDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDevelopment_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, IdProgramProductionDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionDevelopmentBE> ProgramProductionDevelopmentlist = new List<ProgramProductionDevelopmentBE>();
            ProgramProductionDevelopmentBE ProgramProductionDevelopment;
            while (reader.Read())
            {
                ProgramProductionDevelopment = new ProgramProductionDevelopmentBE();
                ProgramProductionDevelopment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionDevelopment.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionDevelopment.IdProgramProductionDevelopment = Int32.Parse(reader["idProgramProductionDevelopment"].ToString());
                ProgramProductionDevelopment.DevDate = DateTime.Parse(reader["DevDate"].ToString());
                ProgramProductionDevelopment.Comment = reader["Comment"].ToString();
                ProgramProductionDevelopment.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                ProgramProductionDevelopment.Situation = reader["Situation"].ToString();
                ProgramProductionDevelopment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionDevelopment.TipoOper = 4; //CONSULTAR
                ProgramProductionDevelopmentlist.Add(ProgramProductionDevelopment);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionDevelopmentlist;
        }
    }
}
