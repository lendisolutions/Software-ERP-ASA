using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;


namespace ERP.BusinessLogic
{
    public class ClientBrandBL
    {
        public List<ClientBrandBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                return ClientBrand.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClientBrandBE> ListaCertificate(int Client)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                return ClientBrand.ListaCertificate(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClientBrandBE> ListaFacturacion(int Client)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                return ClientBrand.ListaFacturacion(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientBrandBE Selecciona(int IdClientBrand)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                ClientBrandBE objEmp = ClientBrand.Selecciona(IdClientBrand);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClientBrandBE pItem)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                ClientBrand.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientBrandBE pItem)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                ClientBrand.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientBrandBE pItem)
        {
            try
            {
                ClientBrandDL ClientBrand = new ClientBrandDL();
                ClientBrand.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
