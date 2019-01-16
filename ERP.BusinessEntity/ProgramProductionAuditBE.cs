using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ProgramProductionAuditBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProgramProductionAudit { get; set; }
        [DataMember]
        public Int32 IdProgramProduction { get; set; }
        [DataMember]
        public Int32 IdProgramProductionDetail { get; set; }
        [DataMember]
        public Int32 IdStyle { get; set; }
        [DataMember]
        public DateTime AuditDate { get; set; }
        [DataMember]
        public String NumeroOI { get; set; }
        [DataMember]
        public DateTime? SendDate { get; set; }
        [DataMember]
        public DateTime? ReturnDate { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public String FileBox { get; set; }
        [DataMember]
        public String GarmentBox { get; set; }
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
        public String NameClient { get; set; }
        [DataMember]
        public String NameVendor { get; set; }
        [DataMember]
        public String NameDestination { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public Decimal Units { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public DateTime XfDate { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion

    }
}
