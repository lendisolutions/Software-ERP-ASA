using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class InvoiceDetailDL
    {
        public InvoiceDetailDL() { }

        public void Inserta(InvoiceDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InvoiceDetail_Inserta");

            db.AddInParameter(dbCommand, "pIdInvoiceDetail", DbType.Int32, pItem.IdInvoiceDetail);
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, pItem.IdInvoice);
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, pItem.NumberCertificate);
            db.AddInParameter(dbCommand, "pIssueCertificate", DbType.DateTime, pItem.IssueCertificate);
            db.AddInParameter(dbCommand, "pNameVendor", DbType.String, pItem.NameVendor);
            db.AddInParameter(dbCommand, "pNumberInvoiceCertificate", DbType.String, pItem.NumberInvoiceCertificate);
            db.AddInParameter(dbCommand, "pIssueDateInvoice", DbType.DateTime, pItem.IssueDateInvoice);
            db.AddInParameter(dbCommand, "pNameDivision", DbType.String, pItem.NameDivision);
            db.AddInParameter(dbCommand, "pAmount", DbType.Decimal, pItem.Amount);
            db.AddInParameter(dbCommand, "pComision", DbType.Decimal, pItem.Comision);
            db.AddInParameter(dbCommand, "pPieces", DbType.Decimal, pItem.Pieces);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(InvoiceDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InvoiceDetail_Actualiza");

            db.AddInParameter(dbCommand, "pIdInvoiceDetail", DbType.Int32, pItem.IdInvoiceDetail);
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, pItem.IdInvoice);
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, pItem.NumberCertificate);
            db.AddInParameter(dbCommand, "pIssueCertificate", DbType.DateTime, pItem.IssueCertificate);
            db.AddInParameter(dbCommand, "pNameVendor", DbType.String, pItem.NameVendor);
            db.AddInParameter(dbCommand, "pNumberInvoiceCertificate", DbType.String, pItem.NumberInvoiceCertificate);
            db.AddInParameter(dbCommand, "pIssueDateInvoice", DbType.DateTime, pItem.IssueDateInvoice);
            db.AddInParameter(dbCommand, "pNameDivision", DbType.String, pItem.NameDivision);
            db.AddInParameter(dbCommand, "pAmount", DbType.Decimal, pItem.Amount);
            db.AddInParameter(dbCommand, "pComision", DbType.Decimal, pItem.Comision);
            db.AddInParameter(dbCommand, "pPieces", DbType.Decimal, pItem.Pieces);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InvoiceDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InvoiceDetail_Elimina");

            db.AddInParameter(dbCommand, "pIdInvoiceDetail", DbType.Int32, pItem.IdInvoiceDetail);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public InvoiceDetailBE Selecciona(int IdInvoiceDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InvoiceDetail_Selecciona");
            db.AddInParameter(dbCommand, "pidInvoiceDetail", DbType.Int32, IdInvoiceDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InvoiceDetailBE InvoiceDetail = null;
            while (reader.Read())
            {
                InvoiceDetail = new InvoiceDetailBE();
                InvoiceDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InvoiceDetail.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                InvoiceDetail.IdInvoiceDetail = Int32.Parse(reader["idInvoiceDetail"].ToString());
                InvoiceDetail.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InvoiceDetail.NumberCertificate = reader["NumberCertificate"].ToString();
                InvoiceDetail.IssueCertificate = DateTime.Parse(reader["IssueCertificate"].ToString());
                InvoiceDetail.NameVendor = reader["NameVendor"].ToString();
                InvoiceDetail.NumberInvoiceCertificate = reader["NumberInvoiceCertificate"].ToString();
                InvoiceDetail.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InvoiceDetail.NameDivision = reader["NameDivision"].ToString();
                InvoiceDetail.Amount = Decimal.Parse(reader["Amount"].ToString());
                InvoiceDetail.Comision = Decimal.Parse(reader["Comision"].ToString());
                InvoiceDetail.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                InvoiceDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InvoiceDetail;
        }

        public List<InvoiceDetailBE> ListaTodosActivo(int IdInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InvoiceDetail_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InvoiceDetailBE> InvoiceDetaillist = new List<InvoiceDetailBE>();
            InvoiceDetailBE InvoiceDetail;
            while (reader.Read())
            {
                InvoiceDetail = new InvoiceDetailBE();
                InvoiceDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InvoiceDetail.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                InvoiceDetail.IdInvoiceDetail = Int32.Parse(reader["idInvoiceDetail"].ToString());
                InvoiceDetail.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InvoiceDetail.NumberCertificate = reader["NumberCertificate"].ToString();
                InvoiceDetail.IssueCertificate = DateTime.Parse(reader["IssueCertificate"].ToString());
                InvoiceDetail.NameVendor = reader["NameVendor"].ToString();
                InvoiceDetail.NumberInvoiceCertificate = reader["NumberInvoiceCertificate"].ToString();
                InvoiceDetail.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InvoiceDetail.NameDivision = reader["NameDivision"].ToString();
                InvoiceDetail.Amount = Decimal.Parse(reader["Amount"].ToString());
                InvoiceDetail.Comision = Decimal.Parse(reader["Comision"].ToString());
                InvoiceDetail.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                InvoiceDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InvoiceDetail.TipoOper = 4; //CONSULTAR
                InvoiceDetaillist.Add(InvoiceDetail);
            }
            reader.Close();
            reader.Dispose();
            return InvoiceDetaillist;
        }
    }
}
