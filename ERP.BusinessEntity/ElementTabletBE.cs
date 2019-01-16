using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ElementTabletBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdElementTablet { get; set; }
        [DataMember]
        public Int32 IdTablet { get; set; }
        [DataMember]
        public String NameTablet { get; set; }
        [DataMember]
        public String Abbreviate { get; set; }
        [DataMember]
        public String NameElementTablet { get; set; }
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
