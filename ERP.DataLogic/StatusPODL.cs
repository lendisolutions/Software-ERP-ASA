using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class StatusPODL
    {
        public StatusPODL() { }

        public void Inserta(StatusPOBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_Inserta");

            db.AddInParameter(dbCommand, "pIdStatusPO", DbType.Int32, pItem.IdStatusPO);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameStatusPO", DbType.String, pItem.NameStatusPO);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(StatusPOBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_Actualiza");

            db.AddInParameter(dbCommand, "pIdStatusPO", DbType.Int32, pItem.IdStatusPO);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameStatusPO", DbType.String, pItem.NameStatusPO);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(StatusPOBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_Elimina");

            db.AddInParameter(dbCommand, "pIdStatusPO", DbType.Int32, pItem.IdStatusPO);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public StatusPOBE Selecciona(int IdStatusPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_Selecciona");
            db.AddInParameter(dbCommand, "pidStatusPO", DbType.Int32, IdStatusPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StatusPOBE StatusPO = null;
            while (reader.Read())
            {
                StatusPO = new StatusPOBE();
                StatusPO.IdStatusPO = Int32.Parse(reader["idStatusPO"].ToString());
                StatusPO.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                StatusPO.NameStatusPO = reader["NameStatusPO"].ToString();
                StatusPO.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return StatusPO;
        }

        public StatusPOBE SeleccionaDescripcion(int IdCompany, string NameStatusPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameStatusPO", DbType.String, NameStatusPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StatusPOBE StatusPO = null;
            while (reader.Read())
            {
                StatusPO = new StatusPOBE();
                StatusPO.IdStatusPO = Int32.Parse(reader["idStatusPO"].ToString());
                StatusPO.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                StatusPO.NameStatusPO = reader["NameStatusPO"].ToString();
                StatusPO.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return StatusPO;
        }

        public List<StatusPOBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusPO_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StatusPOBE> StatusPOlist = new List<StatusPOBE>();
            StatusPOBE StatusPO;
            while (reader.Read())
            {
                StatusPO = new StatusPOBE();
                StatusPO.IdStatusPO = Int32.Parse(reader["idStatusPO"].ToString());
                StatusPO.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                StatusPO.NameStatusPO = reader["NameStatusPO"].ToString();
                StatusPO.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                StatusPOlist.Add(StatusPO);
            }
            reader.Close();
            reader.Dispose();
            return StatusPOlist;
        }
    }
}
