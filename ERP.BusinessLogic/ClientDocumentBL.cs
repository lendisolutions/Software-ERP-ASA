using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientDocumentBL
    {
        public List<ClientDocumentBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientDocumentDL ClientDocument = new ClientDocumentDL();
                return ClientDocument.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientDocumentBE Selecciona(int IdClientDocument)
        {
            try
            {
                ClientDocumentDL ClientDocument = new ClientDocumentDL();
                ClientDocumentBE objEmp = ClientDocument.Selecciona(IdClientDocument);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClientDocumentBE pItem)
        {
            try
            {
                ClientDocumentDL ClientDocument = new ClientDocumentDL();
                ClientDocument.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientDocumentBE pItem)
        {
            try
            {
                ClientDocumentDL ClientDocument = new ClientDocumentDL();
                ClientDocument.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientDocumentBE pItem)
        {
            try
            {
                ClientDocumentDL ClientDocument = new ClientDocumentDL();
                ClientDocument.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
