using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class LoginBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdLogin { get; set; }
        [DataMember]
        public Int32 IdProfile { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 IdEmployee { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String NameLogin { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public Boolean FlagMaster { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String LoginCrea { get; set; }
        [DataMember]
        public String NameProfile { get; set; }
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String FullName { get; set; }
        #endregion
    }
}
