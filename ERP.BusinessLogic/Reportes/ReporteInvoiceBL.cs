using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ReporteInvoiceBL
    {
        public List<ReporteInvoiceBE> Listado(int IdInvoice)
        {
            try
            {
                ReporteInvoiceDL Invoice = new ReporteInvoiceDL();

                List<ReporteInvoiceBE> lstReporteInvoice = new List<ReporteInvoiceBE>();

                foreach (var item in Invoice.Listado(IdInvoice))
                {
                    ReporteInvoiceBE objE_ReporteInvoice = new ReporteInvoiceBE();
                    objE_ReporteInvoice.NameCompany = item.NameCompany;
                    objE_ReporteInvoice.Logo = item.Logo;
                    objE_ReporteInvoice.IdClient = item.IdClient;
                    objE_ReporteInvoice.NumberInvoice = item.NumberInvoice;
                    objE_ReporteInvoice.NameClient = item.NameClient;
                    objE_ReporteInvoice.ConceptoImprime = item.ConceptoImprime;
                    objE_ReporteInvoice.IssueDate = item.IssueDate;
                    objE_ReporteInvoice.NameDestination = item.NameDestination;
                    objE_ReporteInvoice.BrandCertificate = item.BrandCertificate;
                    objE_ReporteInvoice.PercentComision = item.PercentComision;
                    objE_ReporteInvoice.ComisionImprime = item.ComisionImprime;
                    objE_ReporteInvoice.AddressClient = item.AddressClient;
                    objE_ReporteInvoice.Contac = item.Contac;
                    objE_ReporteInvoice.Occupation = item.Occupation;
                    objE_ReporteInvoice.NoteGeneral = item.NoteGeneral;
                    objE_ReporteInvoice.NameBank = item.NameBank;
                    objE_ReporteInvoice.NumberCtaCte = item.NumberCtaCte;
                    objE_ReporteInvoice.Swift = item.Swift;
                    objE_ReporteInvoice.CodeAba = item.CodeAba;
                    objE_ReporteInvoice.AddressBank = item.AddressBank;
                    objE_ReporteInvoice.Phone = item.Phone;
                    objE_ReporteInvoice.Representative = item.Representative;
                    objE_ReporteInvoice.NameCurrency = item.NameCurrency;
                    objE_ReporteInvoice.TotalAmount = item.TotalAmount;
                    objE_ReporteInvoice.TotalComision = item.TotalComision;
                    objE_ReporteInvoice.TotalPieces = item.TotalPieces;
                    objE_ReporteInvoice.ComisionLetter = item.ComisionLetter;
                    objE_ReporteInvoice.NameStatus = item.NameStatus;
                    objE_ReporteInvoice.IdInspectionCertificate = item.IdInspectionCertificate;
                    objE_ReporteInvoice.NumberInvoiceCertificate = item.NumberInvoiceCertificate;
                    objE_ReporteInvoice.IssueDateInvoice = item.IssueDateInvoice;
                    objE_ReporteInvoice.NameDivision = item.NameDivision;
                    objE_ReporteInvoice.Amount = item.Amount;
                    objE_ReporteInvoice.Comision = item.Amount;
                    objE_ReporteInvoice.Pieces = item.Pieces;

                    if (item.IdClient == 7) //SOLAMENTE PARA VINCE
                    {
                        string strCertificateVince = "CERTIFICATE# " + item.NumberCertificate + " - PO# ";
                        string strStyleVince = "STYLE# ";

                        List<InspectionCertificateDetailBE> lstInspectionCertificateDetail = null;
                        lstInspectionCertificateDetail = new InspectionCertificateDetailDL().ListaResumen(item.IdInspectionCertificate);

                        string strPOFinal = "";
                        string strCertificateFinal = "";

                        foreach (var itemIDC in lstInspectionCertificateDetail)
                        {
                            string strPO = "";
                            strPO = itemIDC.NumberPO.ToString().Substring(3,itemIDC.NumberPO.Length-3);
                            strPOFinal = strPOFinal + Convert.ToInt32(strPO).ToString() + "/";
                            strCertificateFinal = strCertificateFinal +  itemIDC.NameStyle + "/";
                        }

                        objE_ReporteInvoice.CertificateVince = strCertificateVince + strPOFinal.Remove(strPOFinal.Length - 1);
                        objE_ReporteInvoice.StyleVince = strStyleVince + strCertificateFinal.Remove(strCertificateFinal.Length - 1);
                    }

                    lstReporteInvoice.Add(objE_ReporteInvoice);
                }
           
                

                return lstReporteInvoice;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInvoiceBE> ListadoCommisionCover(int IdInvoice)
        {
            try
            {
                ReporteInvoiceDL Invoice = new ReporteInvoiceDL();
                return Invoice.ListadoCommisionCover(IdInvoice);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
