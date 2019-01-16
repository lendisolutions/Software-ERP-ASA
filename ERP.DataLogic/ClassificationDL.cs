using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClassificationDL
    {
        public ClassificationDL() { }

        public void Inserta(ClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_Inserta");

            db.AddInParameter(dbCommand, "pIdClassification", DbType.Int32, pItem.IdClassification);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameClassification", DbType.String, pItem.NameClassification);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_Actualiza");

            db.AddInParameter(dbCommand, "pIdClassification", DbType.Int32, pItem.IdClassification);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameClassification", DbType.String, pItem.NameClassification);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClassificationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_Elimina");

            db.AddInParameter(dbCommand, "pIdClassification", DbType.Int32, pItem.IdClassification);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClassificationBE Selecciona(int IdClassification)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_Selecciona");
            db.AddInParameter(dbCommand, "pidClassification", DbType.Int32, IdClassification);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClassificationBE Classification = null;
            while (reader.Read())
            {
                Classification = new ClassificationBE();
                Classification.IdClassification = Int32.Parse(reader["idClassification"].ToString());
                Classification.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Classification.NameClassification = reader["NameClassification"].ToString();
                Classification.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Classification;
        }

        public ClassificationBE SeleccionaDescripcion(int IdCompany, string NameClassification)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameClassification", DbType.String, NameClassification);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClassificationBE Classification = null;
            while (reader.Read())
            {
                Classification = new ClassificationBE();
                Classification.IdClassification = Int32.Parse(reader["idClassification"].ToString());
                Classification.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Classification.NameClassification = reader["NameClassification"].ToString();
                Classification.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Classification;
        }

        public List<ClassificationBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Classification_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClassificationBE> Classificationlist = new List<ClassificationBE>();
            ClassificationBE Classification;
            while (reader.Read())
            {
                Classification = new ClassificationBE();
                Classification.IdClassification = Int32.Parse(reader["idClassification"].ToString());
                Classification.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Classification.NameClassification = reader["NameClassification"].ToString();
                Classification.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Classificationlist.Add(Classification);
            }
            reader.Close();
            reader.Dispose();
            return Classificationlist;
        }
    }
}
