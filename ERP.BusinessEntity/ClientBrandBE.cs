using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ClientBrandBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClientBrand { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public String BrandCertificate { get; set; }
        [DataMember]
        public String BrandFacturacion { get; set; }
        [DataMember]
        public Int32 IdDestination { get; set; }
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
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String NameDestination { get; set; }

        #endregion
    }
}
