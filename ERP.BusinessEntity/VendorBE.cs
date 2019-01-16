using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class VendorBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Boolean FlagNational { get; set; }
        [DataMember]
        public Boolean FlagForeigner { get; set; }
        [DataMember]
        public DateTime RevenueDate { get; set; }
        [DataMember]
        public Int32 IdStatus { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public Int32 IdEvaluation { get; set; }
        [DataMember]
        public String Code { get; set; }
        [DataMember]
        public String Corporation { get; set; }
        [DataMember]
        public Decimal Capacity { get; set; }
        [DataMember]
        public String Representative { get; set; }
        [DataMember]
        public Int32 NumberEmployees { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameStatus { get; set; }
        [DataMember]
        public String NameEvaluation { get; set; }
        [DataMember]
        public String Situation { get; set; }
        #endregion
    }
}
