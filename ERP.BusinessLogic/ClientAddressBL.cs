using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientAddressBL
    {
        public List<ClientAddressBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientAddressDL ClientAddress = new ClientAddressDL();
                return ClientAddress.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientAddressBE Selecciona(int IdClientAddress)
        {
            try
            {
                ClientAddressDL ClientAddress = new ClientAddressDL();
                ClientAddressBE objEmp = ClientAddress.Selecciona(IdClientAddress);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClientAddressBE pItem)
        {
            try
            {
                ClientAddressDL ClientAddress = new ClientAddressDL();
                ClientAddress.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientAddressBE pItem)
        {
            try
            {
                ClientAddressDL ClientAddress = new ClientAddressDL();
                ClientAddress.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientAddressBE pItem)
        {
            try
            {
                ClientAddressDL ClientAddress = new ClientAddressDL();
                ClientAddress.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
