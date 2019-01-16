using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class StatusDL
    {
        public StatusDL() { }

        public void Inserta(StatusBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_Inserta");

            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameStatus", DbType.String, pItem.NameStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(StatusBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_Actualiza");

            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameStatus", DbType.String, pItem.NameStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(StatusBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_Elimina");

            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public StatusBE Selecciona(int IdStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_Selecciona");
            db.AddInParameter(dbCommand, "pidStatus", DbType.Int32, IdStatus);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StatusBE Status = null;
            while (reader.Read())
            {
                Status = new StatusBE();
                Status.IdStatus = Int32.Parse(reader["idStatus"].ToString());
                Status.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Status.NameStatus = reader["NameStatus"].ToString();
                Status.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Status;
        }

        public StatusBE SeleccionaDescripcion(int IdCompany, string NameStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameStatus", DbType.String, NameStatus);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StatusBE Status = null;
            while (reader.Read())
            {
                Status = new StatusBE();
                Status.IdStatus = Int32.Parse(reader["idStatus"].ToString());
                Status.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Status.NameStatus = reader["NameStatus"].ToString();
                Status.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Status;
        }

        public List<StatusBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Status_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StatusBE> Statuslist = new List<StatusBE>();
            StatusBE Status;
            while (reader.Read())
            {
                Status = new StatusBE();
                Status.IdStatus = Int32.Parse(reader["idStatus"].ToString());
                Status.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Status.NameStatus = reader["NameStatus"].ToString();
                Status.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Statuslist.Add(Status);
            }
            reader.Close();
            reader.Dispose();
            return Statuslist;
        }
    }
}
