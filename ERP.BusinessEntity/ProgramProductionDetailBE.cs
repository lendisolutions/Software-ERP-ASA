using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ProgramProductionDetailBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProgramProductionDetail { get; set; }
        [DataMember]
        public Int32 IdProgramProduction { get; set; }
        [DataMember]
        public Int32 IdStyle { get; set; }
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
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NumeroOI { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
