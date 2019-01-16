using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ReporteInspectionCertificateBE
    {
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String NumberCertificate { get; set; }
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberOI { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public String BrandCertificate { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String PaymentTerm { get; set; }
        [DataMember]
        public Int32 Cartons { get; set; }
        [DataMember]
        public String IssueDate { get; set; }
        [DataMember]
        public String NameRepresentative { get; set; }
        [DataMember]
        public String DescriptionStyle { get; set; }
        [DataMember]
        public String NumberInvoice { get; set; }
        [DataMember]
        public String IssueDateInvoice { get; set; }
        [DataMember]
        public String NameCurrency { get; set; }
        [DataMember]
        public Decimal Amount { get; set; }
        [DataMember]
        public String EtdDate { get; set; }
        [DataMember]
        public String NameTypeShipping { get; set; }
        [DataMember]
        public String BoardingWay { get; set; }
        [DataMember]
        public String NameStatus { get; set; }
        [DataMember]
        public String Style { get; set; }
        [DataMember]
        public Int32 Pieces { get; set; }

    }
}
