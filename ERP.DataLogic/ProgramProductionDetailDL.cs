using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ProgramProductionDetailDL
    {
        public ProgramProductionDetailDL() { }

        public void Inserta(ProgramProductionDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_Inserta");

            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pDyelot", DbType.String, pItem.Dyelot);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pDetail", DbType.String, pItem.Detail);
            db.AddInParameter(dbCommand, "pUnits", DbType.Decimal, pItem.Units);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProgramProductionDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_Actualiza");

            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, pItem.IdProgramProduction);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pDyelot", DbType.String, pItem.Dyelot);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pDetail", DbType.String, pItem.Detail);
            db.AddInParameter(dbCommand, "pUnits", DbType.Decimal, pItem.Units);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProgramProductionDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_Elimina");

            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProgramProductionDetailBE Selecciona(int IdProgramProductionDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_Selecciona");
            db.AddInParameter(dbCommand, "pidProgramProductionDetail", DbType.Int32, IdProgramProductionDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProgramProductionDetailBE ProgramProductionDetail = null;
            while (reader.Read())
            {
                ProgramProductionDetail = new ProgramProductionDetailBE();
                ProgramProductionDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionDetail.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionDetail.IdProgramProductionDetail = Int32.Parse(reader["idProgramProductionDetail"].ToString());
                ProgramProductionDetail.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProductionDetail.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionDetail.Description = reader["Description"].ToString();
                ProgramProductionDetail.Dyelot = reader["Dyelot"].ToString();
                ProgramProductionDetail.Item = reader["Item"].ToString();
                ProgramProductionDetail.Detail = reader["Detail"].ToString();
                ProgramProductionDetail.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProductionDetail.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProductionDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionDetail;
        }

        public List<ProgramProductionDetailBE> ListaTodosActivo(int IdProgramProduction)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProgramProduction", DbType.Int32, IdProgramProduction);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionDetailBE> ProgramProductionDetaillist = new List<ProgramProductionDetailBE>();
            ProgramProductionDetailBE ProgramProductionDetail;
            while (reader.Read())
            {
                ProgramProductionDetail = new ProgramProductionDetailBE();
                ProgramProductionDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ProgramProductionDetail.IdProgramProduction = Int32.Parse(reader["IdProgramProduction"].ToString());
                ProgramProductionDetail.IdProgramProductionDetail = Int32.Parse(reader["idProgramProductionDetail"].ToString());
                ProgramProductionDetail.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                ProgramProductionDetail.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionDetail.Description = reader["Description"].ToString();
                ProgramProductionDetail.Dyelot = reader["Dyelot"].ToString();
                ProgramProductionDetail.Item = reader["Item"].ToString();
                ProgramProductionDetail.Detail = reader["Detail"].ToString();
                ProgramProductionDetail.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProductionDetail.Total = Decimal.Parse(reader["Total"].ToString());
                ProgramProductionDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ProgramProductionDetail.TipoOper = 4; //CONSULTAR
                ProgramProductionDetaillist.Add(ProgramProductionDetail);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionDetaillist;
        }

        public List<ProgramProductionDetailBE> ListaNumberPO(int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProgramProductionDetail_ListaNumberPO");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProgramProductionDetailBE> ProgramProductionDetaillist = new List<ProgramProductionDetailBE>();
            ProgramProductionDetailBE ProgramProductionDetail;
            while (reader.Read())
            {
                ProgramProductionDetail = new ProgramProductionDetailBE();
                ProgramProductionDetail.IdProgramProductionDetail = Int32.Parse(reader["IdProgramProductionDetail"].ToString());
                ProgramProductionDetail.NumberPO = reader["NumberPO"].ToString();
                ProgramProductionDetail.NumeroOI = reader["NumeroOI"].ToString();
                ProgramProductionDetail.NameStyle = reader["NameStyle"].ToString();
                ProgramProductionDetail.Description = reader["Description"].ToString();
                ProgramProductionDetail.Dyelot = reader["Dyelot"].ToString();
                ProgramProductionDetail.Item = reader["Item"].ToString();
                ProgramProductionDetail.Detail = reader["Detail"].ToString();
                ProgramProductionDetail.Units = Decimal.Parse(reader["Units"].ToString());
                ProgramProductionDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                ProgramProductionDetaillist.Add(ProgramProductionDetail);
            }
            reader.Close();
            reader.Dispose();
            return ProgramProductionDetaillist;
        }
    }
}
