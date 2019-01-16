using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ReporteInvoiceBE
    {
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        public Int32 IdClient { get; set; }
        [DataMember]
        public String NumberInvoice { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String ConceptoImprime { get; set; }
        [DataMember]
        public String IssueDate { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String BrandCertificate { get; set; }
        [DataMember]
        public Decimal PercentComision { get; set; }
        [DataMember]
        public String AddressClient { get; set; }
        [DataMember]
        public String ComisionImprime { get; set; }
        [DataMember]
        public String Contac { get; set; }
        [DataMember]
        public String Occupation { get; set; }
        [DataMember]
        public String NoteGeneral { get; set; }
        [DataMember]
        public String NameBank { get; set; }
        [DataMember]
        public String NumberCtaCte { get; set; }
        [DataMember]
        public String Swift { get; set; }
        [DataMember]
        public String CodeAba { get; set; }
        [DataMember]
        public String AddressBank { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String Representative { get; set; }
        [DataMember]
        public String NameCurrency { get; set; }
        [DataMember]
        public Decimal TotalAmount { get; set; }
        [DataMember]
        public Decimal TotalComision { get; set; }
        [DataMember]
        public Decimal TotalPieces { get; set; }
        [DataMember]
        public String ComisionLetter { get; set; }
        [DataMember]
        public String NameStatus { get; set; }
        [DataMember]
        public Int32 IdInspectionCertificate { get; set; }
        [DataMember]
        public String NumberCertificate { get; set; }
        [DataMember]
        public String IssueCertificate { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NumberInvoiceCertificate { get; set; }
        [DataMember]
        public String IssueDateInvoice { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public Decimal Amount { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
        [DataMember]
        public Decimal Pieces { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberOI { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public Decimal AmountDetail { get; set; }
        [DataMember]
        public Decimal ComisionDetail { get; set; }
        [DataMember]
        public String CertificateVince { get; set; }
        [DataMember]
        public String StyleVince { get; set; }

    }
}
