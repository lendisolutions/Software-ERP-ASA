using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class ProgramProductionDevelopmentBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProgramProductionDevelopment { get; set; }
        [DataMember]
        public Int32 IdProgramProduction { get; set; }
        [DataMember]
        public Int32 IdProgramProductionDetail { get; set; }
        [DataMember]
        public DateTime DevDate { get; set; }
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
        public Int32 IdCompany { get; set; }
        [DataMember]
        public String Situation { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
