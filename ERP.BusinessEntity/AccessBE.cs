using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class AccessBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProfile { get; set; }
        [DataMember]
        public Int32 IdMenu { get; set; }
        [DataMember]
        public Boolean FlagRead { get; set; }
        [DataMember]
        public Boolean FlagAdd { get; set; }
        [DataMember]
        public Boolean FlagUpdate { get; set; }
        [DataMember]
        public Boolean FlagDelete { get; set; }
        [DataMember]
        public Boolean FlagPrint { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 TipOper { get; set; }
        #endregion
    }
}
