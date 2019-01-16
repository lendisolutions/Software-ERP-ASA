using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ClientContactBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClientContact { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String FirtsName { get; set; }
        [DataMember]
        public String Company { get; set; }
        [DataMember]
        public String Occupation { get; set; }
        [DataMember]
        public Int32 IdCountry { get; set; }
        [DataMember]
        public String Phone1 { get; set; }
        [DataMember]
        public String Phone2 { get; set; }
        [DataMember]
        public String CelPhone { get; set; }
        [DataMember]
        public String Fax { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String InformationAdditional { get; set; }
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
        public String NameCountry { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }


        #endregion
    }
}
