using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class InspectionCertificateDetailBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInspectionCertificateDetail { get; set; }
        [DataMember]
        public Int32 IdInspectionCertificate { get; set; }
        [DataMember]
        public Int32 IdProgramProductionDetail { get; set; }
        [DataMember]
        public String NumberPO { get; set; }
        [DataMember]
        public String NumberOI { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Dyelot { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public String Color { get; set; }
        [DataMember]
        public Decimal POOrder { get; set; }
        [DataMember]
        public Decimal Pieces { get; set; }
        [DataMember]
        public Decimal Fob { get; set; }
        [DataMember]
        public Decimal AmountCertificate { get; set; }
        [DataMember]
        public Int32 Percents { get; set; }
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
