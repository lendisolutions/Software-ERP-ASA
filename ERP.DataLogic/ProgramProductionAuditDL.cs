using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ProgramProductionAuditDL
    {
        public ProgramProductionAuditDL() { }

        public void Inserta(ProgramProductionAuditBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_Inserta");

            db.AddInParameter(dbCommand, "pIdProgramProductionAudit", DbType.Int32, pItem.IdProgramProductionAudit);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pAuditDate", DbType.Date, pItem.AuditDate);
            db.AddInParameter(dbCommand, "pNumeroOI", DbType.String, pItem.NumeroOI);
            db.AddInParameter(dbCommand, "pSendDate", DbType.Date, pItem.SendDate);
            db.AddInParameter(dbCommand, "pReturnDate", DbType.Date, pItem.ReturnDate);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pFileBox", DbType.String, pItem.FileBox);
            db.AddInParameter(dbCommand, "pGarmentBox", DbType.String, pItem.GarmentBox);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProgramProductionAuditBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_Actualiza");

            db.AddInParameter(dbCommand, "pIdProgramProductionAudit", DbType.Int32, pItem.IdProgramProductionAudit);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pAuditDate", DbType.Date, pItem.AuditDate);
            db.AddInParameter(dbCommand, "pNumeroOI", DbType.String, pItem.NumeroOI);
            db.AddInParameter(dbCommand, "pSendDate", DbType.Date, pItem.SendDate);
            db.AddInParameter(dbCommand, "pReturnDate", DbType.Date, pItem.ReturnDate);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pFileBox", DbType.String, pItem.FileBox);
            db.AddInParameter(dbCommand, "pGarmentBox", DbType.String, pItem.GarmentBox);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProgramProductionAuditBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_Elimina");

            db.AddInParameter(dbCommand, "pIdProgramProductionAudit", DbType.Int32, pItem.IdProgramProductionAudit);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProgramProductionAuditBE Selecciona(int IdProgramProductionAudit)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_Selecciona");
            db.AddInParameter(dbCommand, "pidProgramProductionAudit", DbType.Int32, IdProgramProductionAudit);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProgramProductionAuditBE ProgramProductionAudit = null;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionAudit.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAudit;
        }

        public ProgramProductionAuditBE SeleccionaNumero(int IdProgramProduction, int IdStyle, string NumeroOI)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, IdStyle);
            db.AddInParameter(dbCommand, "pNumeroOI", DbType.String, NumeroOI);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProgramProductionAuditBE ProgramProductionAudit = null;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionAudit.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAudit;
        }

        public int SeleccionaBusquedaCount(string Periodo)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.String, Periodo);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<ProgramProductionAuditBE> ListaTodosActivo(int IdProgramProduction, int IdProgramProductionDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, IdProgramProductionDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionAudit.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAudit.TipoOper = 4; //CONSULTAR
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaCodigo(int IdProgramProductionAudit)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaCodigo");
            db.AddInParameter(dbCommand, "pIdProgramProductionAudit", DbType.Int32, IdProgramProductionAudit);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionAudit.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAudit.TipoOper = 4; //CONSULTAR
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaClient(int IdClient, int IdDivision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaClient");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdDivision", DbType.Int32, IdDivision);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.NameClient = reader["NameClient"].ToString();
                ProgramProductionAudit.NameVendor = reader["NameVendor"].ToString();
                ProgramProductionAudit.NameDestination = reader["NameDestination"].ToString();
                ProgramProductionAudit.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionAudit.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionAudit.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaClientDate(int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaClientDate");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.NameClient = reader["NameClient"].ToString();
                ProgramProductionAudit.NameVendor = reader["NameVendor"].ToString();
                ProgramProductionAudit.NameDestination = reader["NameDestination"].ToString();
                ProgramProductionAudit.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionAudit.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionAudit.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaClientNumberPO(int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaNumberPO");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.NameClient = reader["NameClient"].ToString();
                ProgramProductionAudit.NameVendor = reader["NameVendor"].ToString();
                ProgramProductionAudit.NameDestination = reader["NameDestination"].ToString();
                ProgramProductionAudit.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionAudit.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionAudit.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaClientStyle(int IdClient, int IdStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaClientStyle");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, IdStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.NameClient = reader["NameClient"].ToString();
                ProgramProductionAudit.NameVendor = reader["NameVendor"].ToString();
                ProgramProductionAudit.NameDestination = reader["NameDestination"].ToString();
                ProgramProductionAudit.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionAudit.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionAudit.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }

        public List<ProgramProductionAuditBE> ListaClientNumeroOI(string NumeroOI)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionAudit_ListaNumeroOI");
            db.AddInParameter(dbCommand, "pNumeroOI", DbType.String, NumeroOI);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionAuditBE> ProgramProductionAuditlist = new List<ProgramProductionAuditBE>();
            ProgramProductionAuditBE ProgramProductionAudit;
            while (reader.Read())
            {
                ProgramProductionAudit = new ProgramProductionAuditBE();
                ProgramProductionAudit.IdProgramProductionAudit = Int32.Parse(reader["idProgramProductionAudit"].ToString());
                ProgramProductionAudit.AuditDate = DateTime.Parse(reader["AuditDate"].ToString());
                ProgramProductionAudit.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionAudit.NameClient = reader["NameClient"].ToString();
                ProgramProductionAudit.NameVendor = reader["NameVendor"].ToString();
                ProgramProductionAudit.NameDestination = reader["NameDestination"].ToString();
                ProgramProductionAudit.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionAudit.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionAudit.Item = reader["Item"].ToString();
                ProgramProductionAudit.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionAudit.XfDate = DateTime.Parse(reader["XfDate"].ToString());
                ProgramProductionAudit.SendDate = reader.IsDBNull(reader.GetOrdinal("SendDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SendDate"));
                ProgramProductionAudit.ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                ProgramProductionAudit.Comment = reader["Comment"].ToString();
                ProgramProductionAudit.FileBox = reader["FileBox"].ToString();
                ProgramProductionAudit.GarmentBox = reader["GarmentBox"].ToString();
                ProgramProductionAudit.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionAuditlist.Add(ProgramProductionAudit);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionAuditlist;
        }
    }
}
