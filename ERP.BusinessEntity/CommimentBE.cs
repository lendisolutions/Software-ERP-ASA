using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class CommimentBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCommiment { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public String NumberCommiment { get; set; }
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public DateTime CommimentDate { get; set; }
        [DataMember]
        public DateTime ContractShipDate { get; set; }
        [DataMember]
        public DateTime RevisionDate { get; set; }
        [DataMember]
        public String NumberRevision { get; set; }
        [DataMember]
        public Int32 IdOrigen { get; set; }
        [DataMember]
        public Int32 IdDestination { get; set; }
        [DataMember]
        public Int32 IdCurrency { get; set; }
        [DataMember]
        public String FreightPaid { get; set; }
        [DataMember]
        public String Addionational { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NameOrigen { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String NameCurrency { get; set; }
        #endregion
    }
}
