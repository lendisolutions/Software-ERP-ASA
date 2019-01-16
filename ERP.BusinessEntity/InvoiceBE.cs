using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class InvoiceBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInvoice { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NumberInvoice { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public Int32 IdDestination { get; set; }
        [DataMember]
        public Int32 IdClientBrand { get; set; }
        [DataMember]
        public Decimal PercentComision { get; set; }
        [DataMember]
        public String AddressClient { get; set; }
        [DataMember]
        public String Contac { get; set; }
        [DataMember]
        public String Occupation { get; set; }
        [DataMember]
        public String NoteGeneral { get; set; }
        [DataMember]
        public Int32 IdBank { get; set; }
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
        public Int32 IdCurrency { get; set; }
        [DataMember]
        public Decimal TotalAmount { get; set; }
        [DataMember]
        public Decimal TotalComision { get; set; }
        [DataMember]
        public Decimal TotalPieces { get; set; }
        [DataMember]
        public String ComisionLetter { get; set; }
        [DataMember]
        public Int32 IdStatus { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String BrandCertificate { get; set; }
        [DataMember]
        public String NameCurrency { get; set; }
        [DataMember]
        public String NameStatus { get; set; }
        #endregion
    }
}
