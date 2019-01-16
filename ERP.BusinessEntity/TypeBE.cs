using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class TypeBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdType { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String Abbreviate { get; set; }
        [DataMember]
        public String NameType { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }


        #endregion
    }
}
