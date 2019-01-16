using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class AccessBL
    {
        public List<AccessBE> SeleccionaPerfil(int IdProfile)
        {
            try
            {
                AccessDL Access = new AccessDL();
                return Access.SeleccionaPerfil(IdProfile);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
