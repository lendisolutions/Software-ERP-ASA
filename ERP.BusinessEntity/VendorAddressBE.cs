using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class VendorAddressBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdVendorAddress { get; set; }
        [DataMember]
        public Int32 IdVendor { get; set; }
        [DataMember]
        public Int32 IdType { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String WebPage { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String State { get; set; }
        [DataMember]
        public Int32 IdCountry { get; set; }
        [DataMember]
        public String Phone1 { get; set; }
        [DataMember]
        public String Phone2 { get; set; }
        [DataMember]
        public String Fax { get; set; }
        [DataMember]
        public String Reference { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String NameType { get; set; }
        [DataMember]
        public String NomUbigeo { get; set; }
        [DataMember]
        public String NameCountry { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
