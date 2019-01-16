using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class EmployeeBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEmployee { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 IdWorkArea { get; set; }
        [DataMember]
        public String DocumentNumber { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String FullName { get; set; }
        [DataMember]
        public Int32 IdGender { get; set; }
        [DataMember]
        public Int32 IdCivilStatus { get; set; }
        [DataMember]
        public Int32 IdOccupation { get; set; }
        [DataMember]
        public String Essalud { get; set; }
        [DataMember]
        public Boolean FlagEps { get; set; }
        [DataMember]
        public Boolean FlagSctr { get; set; }
        [DataMember]
        public String License { get; set; }
        [DataMember]
        public DateTime BithDate { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String CelPhone1 { get; set; }
        [DataMember]
        public String CelPhone2 { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public String Comment { get; set; }
        [DataMember]
        public Int32 IdSituation { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameCompany { get; set; }
        [DataMember]
        public String NameWorkArea { get; set; }
        [DataMember]
        public String NameGender { get; set; }
        [DataMember]
        public String NameOccupation { get; set; }
        [DataMember]
        public String NameStateCivil { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String NameSituation { get; set; }

        #endregion
    }
}
