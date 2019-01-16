using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ClientBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public Int32 IdCorporation { get; set; }
        [DataMember]
        public Int32 IdEvaluation { get; set; }
        [DataMember]
        public DateTime RevenueDate { get; set; }
        [DataMember]
        public String Certificate { get; set; }
        [DataMember]
        public Decimal PercentComision1 { get; set; }
        [DataMember]
        public Decimal PercentComision2 { get; set; }
        [DataMember]
        public Decimal PercentComision3 { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCorporation { get; set; }
        [DataMember]
        public String NameEvaluation { get; set; }
        [DataMember]
        public String Situation { get; set; }
        #endregion
    }
}
