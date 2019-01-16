using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class InspectionCertificateDetailDL
    {
        public InspectionCertificateDetailDL() { }

        public void Inserta(InspectionCertificateDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_Inserta");

            db.AddInParameter(dbCommand, "pIdInspectionCertificateDetail", DbType.Int32, pItem.IdInspectionCertificateDetail);
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberOI", DbType.String, pItem.NumberOI);
            db.AddInParameter(dbCommand, "pNameStyle", DbType.String, pItem.NameStyle);
            db.AddInParameter(dbCommand, "pDescription", DbType.String, pItem.Description);
            db.AddInParameter(dbCommand, "pDyelot", DbType.String, pItem.Dyelot);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pColor", DbType.String, pItem.Color);
            db.AddInParameter(dbCommand, "pPOOrder", DbType.Decimal, pItem.POOrder);
            db.AddInParameter(dbCommand, "pPieces", DbType.Decimal, pItem.Pieces);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pAmountCertificate", DbType.Decimal, pItem.AmountCertificate);
            db.AddInParameter(dbCommand, "pPercents", DbType.Int32, pItem.Percents);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(InspectionCertificateDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_Actualiza");

            db.AddInParameter(dbCommand, "pIdInspectionCertificateDetail", DbType.Int32, pItem.IdInspectionCertificateDetail);
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdProgramProductionDetail", DbType.Int32, pItem.IdProgramProductionDetail);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberOI", DbType.String, pItem.NumberOI);
            db.AddInParameter(dbCommand, "pNameStyle", DbType.String, pItem.NameStyle);
            db.AddInParameter(dbCommand, "pDescription", DbType.String, pItem.Description);
            db.AddInParameter(dbCommand, "pDyelot", DbType.String, pItem.Dyelot);
            db.AddInParameter(dbCommand, "pItem", DbType.String, pItem.Item);
            db.AddInParameter(dbCommand, "pColor", DbType.String, pItem.Color);
            db.AddInParameter(dbCommand, "pPOOrder", DbType.Decimal, pItem.POOrder);
            db.AddInParameter(dbCommand, "pPieces", DbType.Decimal, pItem.Pieces);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pAmountCertificate", DbType.Decimal, pItem.AmountCertificate);
            db.AddInParameter(dbCommand, "pPercents", DbType.Int32, pItem.Percents);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InspectionCertificateDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_Elimina");

            db.AddInParameter(dbCommand, "pIdInspectionCertificateDetail", DbType.Int32, pItem.IdInspectionCertificateDetail);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public InspectionCertificateDetailBE Selecciona(int IdInspectionCertificateDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_Selecciona");
            db.AddInParameter(dbCommand, "pidInspectionCertificateDetail", DbType.Int32, IdInspectionCertificateDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspectionCertificateDetailBE InspectionCertificateDetail = null;
            while (reader.Read())
            {
                InspectionCertificateDetail = new InspectionCertificateDetailBE();
                InspectionCertificateDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificateDetail.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificateDetail.IdInspectionCertificateDetail = Int32.Parse(reader["idInspectionCertificateDetail"].ToString());
                InspectionCertificateDetail.IdProgramProductionDetail = Int32.Parse(reader["IdProgramProductionDetail"].ToString());
                InspectionCertificateDetail.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificateDetail.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificateDetail.NameStyle = reader["NameStyle"].ToString();
                InspectionCertificateDetail.Description = reader["Description"].ToString();
                InspectionCertificateDetail.Dyelot = reader["Dyelot"].ToString();
                InspectionCertificateDetail.Item = reader["Item"].ToString();
                InspectionCertificateDetail.Color = reader["Color"].ToString();
                InspectionCertificateDetail.POOrder = Decimal.Parse(reader["POOrder"].ToString());
                InspectionCertificateDetail.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                InspectionCertificateDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                InspectionCertificateDetail.AmountCertificate = Decimal.Parse(reader["AmountCertificate"].ToString());
                InspectionCertificateDetail.Percents = Int32.Parse(reader["Percents"].ToString());
                InspectionCertificateDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificateDetail;
        }

        public List<InspectionCertificateDetailBE> ListaTodosActivo(int IdInspectionCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateDetailBE> InspectionCertificateDetaillist = new List<InspectionCertificateDetailBE>();
            InspectionCertificateDetailBE InspectionCertificateDetail;
            while (reader.Read())
            {
                InspectionCertificateDetail = new InspectionCertificateDetailBE();
                InspectionCertificateDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificateDetail.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificateDetail.IdInspectionCertificateDetail = Int32.Parse(reader["idInspectionCertificateDetail"].ToString());
                InspectionCertificateDetail.IdProgramProductionDetail = Int32.Parse(reader["IdProgramProductionDetail"].ToString());
                InspectionCertificateDetail.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificateDetail.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificateDetail.NameStyle = reader["NameStyle"].ToString();
                InspectionCertificateDetail.Description = reader["Description"].ToString();
                InspectionCertificateDetail.Dyelot = reader["Dyelot"].ToString();
                InspectionCertificateDetail.Item = reader["Item"].ToString();
                InspectionCertificateDetail.Color = reader["Color"].ToString();
                InspectionCertificateDetail.POOrder = Decimal.Parse(reader["POOrder"].ToString());
                InspectionCertificateDetail.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                InspectionCertificateDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                InspectionCertificateDetail.AmountCertificate = Decimal.Parse(reader["AmountCertificate"].ToString());
                InspectionCertificateDetail.Percents = Int32.Parse(reader["Percents"].ToString());
                InspectionCertificateDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificateDetail.TipoOper = 4; //CONSULTAR
                InspectionCertificateDetaillist.Add(InspectionCertificateDetail);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificateDetaillist;
        }

        public List<InspectionCertificateDetailBE> ListaResumen(int IdInspectionCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificateDetail_ListaResumen");
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateDetailBE> InspectionCertificateDetaillist = new List<InspectionCertificateDetailBE>();
            InspectionCertificateDetailBE InspectionCertificateDetail;
            while (reader.Read())
            {
                InspectionCertificateDetail = new InspectionCertificateDetailBE();
                InspectionCertificateDetail.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificateDetail.NameStyle = reader["NameStyle"].ToString();
                InspectionCertificateDetaillist.Add(InspectionCertificateDetail);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificateDetaillist;
        }
    }
}
