using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class EvaluationDL
    {
        public EvaluationDL() { }

        public void Inserta(EvaluationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_Inserta");

            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameEvaluation", DbType.String, pItem.NameEvaluation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(EvaluationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_Actualiza");

            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameEvaluation", DbType.String, pItem.NameEvaluation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(EvaluationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_Elimina");

            db.AddInParameter(dbCommand, "pIdEvaluation", DbType.Int32, pItem.IdEvaluation);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public EvaluationBE Selecciona(int IdEvaluation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_Selecciona");
            db.AddInParameter(dbCommand, "pidEvaluation", DbType.Int32, IdEvaluation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EvaluationBE Evaluation = null;
            while (reader.Read())
            {
                Evaluation = new EvaluationBE();
                Evaluation.IdEvaluation = Int32.Parse(reader["idEvaluation"].ToString());
                Evaluation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Evaluation.NameEvaluation = reader["NameEvaluation"].ToString();
                Evaluation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Evaluation;
        }

        public EvaluationBE SeleccionaDescripcion(int IdCompany, string NameEvaluation)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameEvaluation", DbType.String, NameEvaluation);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EvaluationBE Evaluation = null;
            while (reader.Read())
            {
                Evaluation = new EvaluationBE();
                Evaluation.IdEvaluation = Int32.Parse(reader["idEvaluation"].ToString());
                Evaluation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Evaluation.NameEvaluation = reader["NameEvaluation"].ToString();
                Evaluation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Evaluation;
        }

        public List<EvaluationBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Evaluation_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EvaluationBE> Evaluationlist = new List<EvaluationBE>();
            EvaluationBE Evaluation;
            while (reader.Read())
            {
                Evaluation = new EvaluationBE();
                Evaluation.IdEvaluation = Int32.Parse(reader["idEvaluation"].ToString());
                Evaluation.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Evaluation.NameEvaluation = reader["NameEvaluation"].ToString();
                Evaluation.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Evaluationlist.Add(Evaluation);
            }
            reader.Close();
            reader.Dispose();
            return Evaluationlist;
        }
    }
}
