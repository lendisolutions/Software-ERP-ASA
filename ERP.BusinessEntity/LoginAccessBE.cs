using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class LoginAccessBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdLogin { get; set; }
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

        //DATOS EXTERNOS

        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String Login { get; set; }
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
        public Int32 WindowLoadMode { get; set; }
        [DataMember]
        public String Machine { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
