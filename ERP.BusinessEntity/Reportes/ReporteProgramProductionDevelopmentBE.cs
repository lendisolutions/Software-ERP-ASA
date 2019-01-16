using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ReporteProgramProductionDevelopmentBE
    {
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public String XfDate { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public String Detail { get; set; }
        [DataMember]
        public Decimal Units { get; set; }
        [DataMember]
        public Decimal Fob { get; set; }
        [DataMember]
        public String DevDate { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public String Situation { get; set; }
    }
}
