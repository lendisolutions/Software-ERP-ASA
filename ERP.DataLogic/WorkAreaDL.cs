using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class WorkAreaDL
    {
        public WorkAreaDL() { }

        public void Inserta(WorkAreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_Inserta");

            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameWorkArea", DbType.String, pItem.NameWorkArea);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(WorkAreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_Actualiza");

            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameWorkArea", DbType.String, pItem.NameWorkArea);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(WorkAreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_Elimina");

            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public WorkAreaBE Selecciona(int IdCompany, int IdWorkArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_Selecciona");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pidWorkArea", DbType.Int32, IdWorkArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            WorkAreaBE WorkArea = null;
            while (reader.Read())
            {
                WorkArea = new WorkAreaBE();
                WorkArea.IdWorkArea = Int32.Parse(reader["idWorkArea"].ToString());
                WorkArea.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                WorkArea.NameWorkArea = reader["NameWorkArea"].ToString();
                WorkArea.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return WorkArea;
        }

        public WorkAreaBE SeleccionaDescripcion(int IdCompany, string NameWorkArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameWorkArea", DbType.String, NameWorkArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            WorkAreaBE WorkArea = null;
            while (reader.Read())
            {
                WorkArea = new WorkAreaBE();
                WorkArea.IdWorkArea = Int32.Parse(reader["idWorkArea"].ToString());
                WorkArea.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                WorkArea.NameWorkArea = reader["NameWorkArea"].ToString();
                WorkArea.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return WorkArea;
        }

        public List<WorkAreaBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_WorkArea_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<WorkAreaBE> WorkArealist = new List<WorkAreaBE>();
            WorkAreaBE WorkArea;
            while (reader.Read())
            {
                WorkArea = new WorkAreaBE();
                WorkArea.IdWorkArea = Int32.Parse(reader["idWorkArea"].ToString());
                WorkArea.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                WorkArea.NameWorkArea = reader["NameWorkArea"].ToString();
                WorkArea.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                WorkArealist.Add(WorkArea);
            }
            reader.Close();
            reader.Dispose();
            return WorkArealist;
        }
    }
}
