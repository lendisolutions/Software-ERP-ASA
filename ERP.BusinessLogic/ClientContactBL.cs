using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientContactBL
    {
        public List<ClientContactBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientContactDL ClientContact = new ClientContactDL();
                return ClientContact.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientContactBE Selecciona(int IdClientContact)
        {
            try
            {
                ClientContactDL ClientContact = new ClientContactDL();
                ClientContactBE objEmp = ClientContact.Selecciona(IdClientContact);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClientContactBE pItem)
        {
            try
            {
                ClientContactDL ClientContact = new ClientContactDL();
                ClientContact.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientContactBE pItem)
        {
            try
            {
                ClientContactDL ClientContact = new ClientContactDL();
                ClientContact.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientContactBE pItem)
        {
            try
            {
                ClientContactDL ClientContact = new ClientContactDL();
                ClientContact.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
