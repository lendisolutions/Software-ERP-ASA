using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ClientGoalBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClientGoal { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public Int32 Year { get; set; }
        [DataMember]
        public Int32 Month { get; set; }
        [DataMember]
        public Decimal Goal { get; set; }
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

        #endregion
    }
}
