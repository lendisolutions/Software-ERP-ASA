using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class InspectionCertificateBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInspectionCertificate { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NumberCertificate { get; set; }
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberOI { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public Int32 IdClientDepartment { get; set; }
        [DataMember]
        public Int32 IdClientBrand { get; set; }
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public String PaymentTerm { get; set; }
        [DataMember]
        public Int32 Cartons { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public Int32 IdRepresentative { get; set; }
        [DataMember]
        public String DescriptionStyle { get; set; }
        [DataMember]
        public String NumberInvoice { get; set; }
        [DataMember]
        public DateTime IssueDateInvoice { get; set; }
        [DataMember]
        public Int32 IdCurrency { get; set; }
        [DataMember]
        public Decimal Amount { get; set; }
        [DataMember]
        public DateTime EtdDate { get; set; }
        [DataMember]
        public Int32 IdTypeShipping { get; set; }
        [DataMember]
        public String BoardingWay { get; set; }
        [DataMember]
        public Int32 IdStatus { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public String BrandCertificate { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NameRepresentative { get; set; }
        [DataMember]
        public String NameCurrency { get; set; }
        [DataMember]
        public String NameTypeShipping { get; set; }
        [DataMember]
        public String NameStatus { get; set; }
        [DataMember]
        public Decimal AmountCertificate { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
        [DataMember]
        public Decimal Pieces { get; set; }


        #endregion
    }
}
