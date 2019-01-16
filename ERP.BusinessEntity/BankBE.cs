using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class BankBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdBank { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String Swift { get; set; }
        [DataMember]
        public String NameBank { get; set; }
        [DataMember]
        public Int32 IdCurrency { get; set; }
        [DataMember]
        public String NumberCtaCte { get; set; }
        [DataMember]
        public String CodeAba { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String Contac { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCurrency { get; set; }
        #endregion
    }
}
