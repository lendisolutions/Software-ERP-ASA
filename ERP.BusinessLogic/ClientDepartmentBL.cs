using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientDepartmentBL
    {
        public List<ClientDepartmentBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                return ClientDepartment.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClientDepartmentBE> ListaClient(int IdCompany)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                return ClientDepartment.ListaClient(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientDepartmentBE Selecciona(int IdClientDepartment)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                ClientDepartmentBE objEmp = ClientDepartment.Selecciona(IdClientDepartment);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientDepartmentBE SeleccionaDescripcion(int IdClient, string NameDivision)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                ClientDepartmentBE objEmp = ClientDepartment.SeleccionaDescripcion(IdClient, NameDivision);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClientDepartmentBE pItem)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                ClientDepartment.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientDepartmentBE pItem)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                ClientDepartment.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientDepartmentBE pItem)
        {
            try
            {
                ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                ClientDepartment.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
