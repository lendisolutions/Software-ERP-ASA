using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class CompanyBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String EconomyActivity { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        
        #endregion
    }
}
