using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ReporteInvoiceDL
    {
        public List<ReporteInvoiceBE> Listado(int IdInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInvoice");
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInvoiceBE> ReporteInvoicelist = new List<ReporteInvoiceBE>();
            ReporteInvoiceBE ReporteInvoice;
            while (reader.Read())
            {
                ReporteInvoice = new ReporteInvoiceBE();
                ReporteInvoice.NameCompany = reader["NameCompany"].ToString();
                ReporteInvoice.Logo = (byte[])reader["Logo"];
                ReporteInvoice.IdClient = Int32.Parse( reader["IdClient"].ToString());
                ReporteInvoice.NumberInvoice = reader["NumberInvoice"].ToString();
                ReporteInvoice.NameClient = reader["NameClient"].ToString();
                ReporteInvoice.ConceptoImprime = reader["ConceptoImprime"].ToString();
                DateTime deIssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                ReporteInvoice.IssueDate = deIssueDate.ToString("MM/dd/yyyy");
                ReporteInvoice.NameDestination = reader["NameDestination"].ToString();
                ReporteInvoice.BrandCertificate = reader["BrandCertificate"].ToString();
                ReporteInvoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                ReporteInvoice.ComisionImprime = reader["ComisionImprime"].ToString();
                ReporteInvoice.AddressClient = reader["AddressClient"].ToString();
                ReporteInvoice.Contac = reader["Contac"].ToString();
                ReporteInvoice.Occupation = reader["Occupation"].ToString();
                ReporteInvoice.NoteGeneral = reader["NoteGeneral"].ToString();
                ReporteInvoice.NameBank = reader["NameBank"].ToString();
                ReporteInvoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                ReporteInvoice.Swift = reader["Swift"].ToString();
                ReporteInvoice.CodeAba = reader["CodeAba"].ToString();
                ReporteInvoice.AddressBank = reader["AddressBank"].ToString();
                ReporteInvoice.Phone = reader["Phone"].ToString();
                ReporteInvoice.Representative = reader["Representative"].ToString();
                ReporteInvoice.NameCurrency = reader["NameCurrency"].ToString();
                ReporteInvoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ReporteInvoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                ReporteInvoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                ReporteInvoice.ComisionLetter = reader["ComisionLetter"].ToString();
                ReporteInvoice.NameStatus = reader["NameStatus"].ToString();
                ReporteInvoice.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                ReporteInvoice.NumberCertificate = reader["NumberCertificate"].ToString();
                ReporteInvoice.NumberInvoiceCertificate = reader["NumberInvoiceCertificate"].ToString();
                DateTime deIssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                ReporteInvoice.IssueDateInvoice = deIssueDateInvoice.ToString("MM/dd/yyyy");
                ReporteInvoice.NameDivision = reader["NameDivision"].ToString();
                ReporteInvoice.Amount = Decimal.Parse(reader["Amount"].ToString());
                ReporteInvoice.Comision = Decimal.Parse(reader["Comision"].ToString());
                ReporteInvoice.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                ReporteInvoicelist.Add(ReporteInvoice);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInvoicelist;
        }

        public List<ReporteInvoiceBE> ListadoCommisionCover(int IdInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInvoiceCommisionCover");
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInvoiceBE> ReporteInvoicelist = new List<ReporteInvoiceBE>();
            ReporteInvoiceBE ReporteInvoice;
            while (reader.Read())
            {
                ReporteInvoice = new ReporteInvoiceBE();
                ReporteInvoice.NameCompany = reader["NameCompany"].ToString();
                ReporteInvoice.Logo = (byte[])reader["Logo"];
                ReporteInvoice.NumberInvoice = reader["NumberInvoice"].ToString();
                ReporteInvoice.NameClient = reader["NameClient"].ToString();
                ReporteInvoice.BrandCertificate = reader["BrandCertificate"].ToString();
                ReporteInvoice.NameDestination = reader["NameDestination"].ToString();
                ReporteInvoice.NameVendor = reader["NameVendor"].ToString();
                ReporteInvoice.NumberCertificate = reader["NumberCertificate"].ToString();
                DateTime deIssueCertificate = DateTime.Parse(reader["IssueCertificate"].ToString());
                ReporteInvoice.IssueCertificate = deIssueCertificate.ToString("MM/dd/yyyy");
                ReporteInvoice.NumberInvoiceCertificate = reader["NumberInvoiceCertificate"].ToString();
                DateTime deIssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                ReporteInvoice.IssueDateInvoice = deIssueDateInvoice.ToString("MM/dd/yyyy");
                ReporteInvoice.Amount = Decimal.Parse(reader["Amount"].ToString());
                ReporteInvoice.Comision = Decimal.Parse(reader["Comision"].ToString());
                ReporteInvoice.NameDivision = reader["NameDivision"].ToString();
                ReporteInvoice.NumberPO = reader["NumberPO"].ToString();
                ReporteInvoice.NumberOI = reader["NumberOI"].ToString();
                ReporteInvoice.NameStyle = reader["NameStyle"].ToString();
                ReporteInvoice.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                ReporteInvoice.AmountDetail = Decimal.Parse(reader["AmountDetail"].ToString());
                ReporteInvoice.ComisionDetail = Decimal.Parse(reader["ComisionDetail"].ToString());
                ReporteInvoicelist.Add(ReporteInvoice);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInvoicelist;
        }

        public List<ReporteInvoiceBE> ListadoMontlySales(int IdCompany, int IdClient, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInvoiceMontlySales");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInvoiceBE> ReporteInvoicelist = new List<ReporteInvoiceBE>();
            ReporteInvoiceBE ReporteInvoice;
            while (reader.Read())
            {
                ReporteInvoice = new ReporteInvoiceBE();
                ReporteInvoice.NameCompany = reader["NameCompany"].ToString();
                ReporteInvoice.NumberInvoice = reader["NumberInvoice"].ToString();
                DateTime deIssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                ReporteInvoice.IssueDate = deIssueDate.ToString("MM/dd/yyyy");
                ReporteInvoice.NameClient = reader["NameClient"].ToString();
                ReporteInvoice.NameDestination = reader["NameDestination"].ToString();
                ReporteInvoice.Contac = reader["Contac"].ToString();
                ReporteInvoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                ReporteInvoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                ReporteInvoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                ReporteInvoicelist.Add(ReporteInvoice);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInvoicelist;
        }
    }
}
