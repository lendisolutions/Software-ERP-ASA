using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class InvoiceDetailBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInvoiceDetail { get; set; }
        [DataMember]
        public Int32 IdInvoice { get; set; }
        [DataMember]
        public Int32 IdInspectionCertificate { get; set; }
        [DataMember]
        public String NumberCertificate { get; set; }
        [DataMember]
        public DateTime IssueCertificate { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NumberInvoiceCertificate { get; set; }
        [DataMember]
        public DateTime IssueDateInvoice { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public Decimal Amount { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
        [DataMember]
        public Decimal Pieces { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        #endregion
    }
}
