using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ReporteInspectionCertificateDL
    {
        public List<ReporteInspectionCertificateBE> Listado(int IdInspectionCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspectionCertificate");
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspectionCertificateBE> ReporteInspectionCertificatelist = new List<ReporteInspectionCertificateBE>();
            ReporteInspectionCertificateBE ReporteInspectionCertificate;
            while (reader.Read())
            {
                string strComment = "";
                string strCommentBrand = "";
                string strCommentCarton = "";
                string strCommentFinal = "";

                strComment = reader["Comment"].ToString();
                strCommentBrand = strComment.Replace("{BRAND}", reader["BrandCertificate"].ToString());
                strCommentCarton = strCommentBrand.Replace("{CARTONS}", reader["Cartons"].ToString());
                strCommentFinal = strCommentCarton.Replace("{POSS}", reader["NumberPO"].ToString());

                ReporteInspectionCertificate = new ReporteInspectionCertificateBE();
                ReporteInspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                ReporteInspectionCertificate.Logo = (byte[])reader["Logo"];
                ReporteInspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                ReporteInspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                ReporteInspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                ReporteInspectionCertificate.NameClient = reader["NameClient"].ToString();
                ReporteInspectionCertificate.Comment = strCommentFinal;
                ReporteInspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                ReporteInspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                ReporteInspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                ReporteInspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                ReporteInspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                ReporteInspectionCertificate.IssueDate = reader["IssueDate"].ToString();
                ReporteInspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                ReporteInspectionCertificate.DescriptionStyle = "" + reader["Cartons"].ToString() +  " CARTONS SALID TO CONTAIN " + reader["Pieces"].ToString() + " PCS, " + reader["DescriptionStyle"].ToString();
                ReporteInspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                ReporteInspectionCertificate.IssueDateInvoice = reader["IssueDateInvoice"].ToString();
                ReporteInspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                ReporteInspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                ReporteInspectionCertificate.EtdDate = reader["EtdDate"].ToString();
                ReporteInspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                ReporteInspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                ReporteInspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                ReporteInspectionCertificate.Style = reader["Style"].ToString();
                ReporteInspectionCertificate.Pieces = Int32.Parse(reader["Pieces"].ToString());
                ReporteInspectionCertificatelist.Add(ReporteInspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspectionCertificatelist;
        }
    }
}
