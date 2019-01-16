using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class UbigeoBE
    {
        #region "Atributos"
        [DataMember]
        public String IdDepartament { get; set; }
        [DataMember]
        public String IdProvincie { get; set; }
        [DataMember]
        public String IdDistrict { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String NomUbigeo { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }

        #endregion
    }
}
