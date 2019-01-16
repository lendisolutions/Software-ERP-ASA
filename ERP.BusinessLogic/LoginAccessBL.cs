using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class LoginAccessBL
    {
        public List<LoginAccessBE> SeleccionaCriterioVarios(int IdLogin, int IdProfile)
        {
            try
            {
                LoginAccessDL LoginAccess = new LoginAccessDL();
                return LoginAccess.SeleccionaCriterioVarios(IdLogin, IdProfile);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginAccessBE> SeleccionaUserPerfil(int IdLogin, int IdProfile)
        {
            try
            {
                LoginAccessDL LoginAccess = new LoginAccessDL();
                return LoginAccess.SeleccionaUserPerfil(IdLogin, IdProfile);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginAccessBE> SeleccionaUser(int IdLogin)
        {
            try
            {
                LoginAccessDL LoginAccess = new LoginAccessDL();
                return LoginAccess.SeleccionaUser(IdLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginAccessBE> SeleccionaPermisoAcceso(string Usuario, int IdProfile)
        {
            try
            {
                LoginAccessDL LoginAccess = new LoginAccessDL();
                return LoginAccess.SeleccionaPermisoAcceso(Usuario, IdProfile);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginAccessBE> ListaTodosActivo()
        {
            try
            {
                LoginAccessDL LoginAccess = new LoginAccessDL();
                return LoginAccess.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
