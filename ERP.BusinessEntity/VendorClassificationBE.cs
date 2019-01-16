using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class VendorClassificationBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdVendorClassification { get; set; }
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public Int32 IdClassification { get; set; }
        [DataMember]
        public Boolean FlagActive { get; set; }
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
        public String NameClassification { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
