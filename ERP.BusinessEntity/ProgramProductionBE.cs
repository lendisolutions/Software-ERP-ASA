using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ProgramProductionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProgramProduction { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NumberPP { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public Int32 IdClientDepartment { get; set; }
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public Int32 IdDestination { get; set; }
        [DataMember]
        public Int32 IdSeason { get; set; }
        [DataMember]
        public Int32 IdTypeProduct { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberCommiment { get; set; }
        [DataMember]
        public DateTime XfDate { get; set; }
        [DataMember]
        public DateTime IndcDate { get; set; }
        [DataMember]
        public Int32 IdShipMode { get; set; }
        [DataMember]
        public String Label { get; set; }
        [DataMember]
        public String Addionational { get; set; }
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
        public String NameVendor { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String NameSeason { get; set; }
        [DataMember]
        public Int32 IdStyle { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public String NameTypeProduct { get; set; }
        [DataMember]
        public String NameShipMode { get; set; }
        [DataMember]
        public String Dyelot { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public String Detail { get; set; }
        [DataMember]
        public Decimal Units { get; set; }
        [DataMember]
        public Decimal Fob { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Int32 Days { get; set; }
        [DataMember]
        public String Situation { get; set; }
        [DataMember]
        public Decimal TotalUnits { get; set; }
        [DataMember]
        public Decimal TotalAmount { get; set; }

        #endregion
    }
}
