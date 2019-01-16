using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class LoginClientDepartmentBL
    {
        public List<LoginClientDepartmentBE> ListaEmpresaLogin(int IdCompany, int IdLogin)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                return LoginClientDepartment.ListaEmpresaLogin(IdCompany, IdLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginClientDepartmentBE> ListaClient(int IdLogin)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                return LoginClientDepartment.ListaClient(IdLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginClientDepartmentBE> ListaClientDivision(int IdLogin, int IdClient)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                return LoginClientDepartment.ListaClientDivision(IdLogin,IdClient);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginClientDepartmentBE> ListaLogin(int IdLogin)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                return LoginClientDepartment.ListaLogin(IdLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LoginClientDepartmentBE> ListaEmpresaUnidadULogin(int IdCompany, int IdClientDepartment, int IdLogin)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                return LoginClientDepartment.ListaEmpresaUnidadULogin(IdCompany, IdClientDepartment, IdLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(LoginClientDepartmentBE pItem)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                LoginClientDepartment.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(LoginClientDepartmentBE pItem)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                LoginClientDepartment.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(LoginClientDepartmentBE pItem)
        {
            try
            {
                LoginClientDepartmentDL LoginClientDepartment = new LoginClientDepartmentDL();
                LoginClientDepartment.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
