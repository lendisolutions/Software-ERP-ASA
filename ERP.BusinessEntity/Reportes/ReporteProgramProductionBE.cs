using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ReporteProgramProductionBE
    {
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String NumberPP { get; set; }
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String NameDivision { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String NameSeason { get; set; }
        
        [DataMember]
        public String NameTypeProduct { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberCommiment { get; set; }
        [DataMember]
        public String XfDate { get; set; }
        [DataMember]
        public String IndcDate { get; set; }
        [DataMember]
        public String NameShipMode { get; set; }
        [DataMember]
        public String Label { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String NumeroOI { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public String Detail { get; set; }
        [DataMember]
        public String Dyelot { get; set; }
        [DataMember]
        public Decimal Units { get; set; }
        [DataMember]
        public Decimal Fob { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal TotalUnits { get; set; }
        [DataMember]
        public Decimal TotalFob { get; set; }
        [DataMember]
        public Decimal XXS { get; set; }
        [DataMember]
        public Decimal XS { get; set; }
        [DataMember]
        public Decimal S { get; set; }
        [DataMember]
        public Decimal M { get; set; }
        [DataMember]
        public Decimal L { get; set; }
        [DataMember]
        public Decimal XL { get; set; }
        [DataMember]
        public Decimal XXL { get; set; }
    }
}
