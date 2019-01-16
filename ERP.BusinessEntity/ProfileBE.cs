using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ProfileBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProfile { get; set; }
        [DataMember]
        public String NameProfile { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        #endregion
    }
}
