using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ERP.BusinessEntity
{
    [DataContract]
    public class StyleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdStyle { get; set; }
        [DataMember]
        public Int32 IdCompany { get; set; }
        [DataMember]
        public Int32 IdClient { get; set; }
        [DataMember]
        public String NameStyle { get; set; }
        [DataMember]
        public DateTime RevenueDate { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Item { get; set; }
        [DataMember]
        public Int32 IdClientDepartment { get; set; }
        [DataMember]
        public Int32 IdMediaUnit { get; set; }
        [DataMember]
        public Boolean FlagState { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Machine { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String NameClient { get; set; }
        [DataMember]
        public String MameDivision { get; set; }
        [DataMember]
        public String NameMediaUnit { get; set; }
        [DataMember]
        public String Situation { get; set; }
        #endregion
    }
}
