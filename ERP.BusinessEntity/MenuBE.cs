using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class MenuBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMenu { get; set; }
        [DataMember]
        public String MenuCode { get; set; }
        [DataMember]
        public Int32 IdMenuFather { get; set; }
        [DataMember]
        public String MenuDescription { get; set; }
        [DataMember]
        public String Picture { get; set; }
        [DataMember]
        public Boolean LargePicture { get; set; }
        [DataMember]
        public String Class { get; set; }
        [DataMember]
        public String Assembly { get; set; }
        [DataMember]
        public Int32 IdTypeMenu { get; set; }
        [DataMember]
        public String WindowLoadMode { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        #endregion
    }
}
