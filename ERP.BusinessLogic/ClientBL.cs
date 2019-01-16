using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ClientBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                ClientDL Client = new ClientDL();
                return Client.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClientBE> ListaDescripcion(int IdCompany, string NameClient)
        {
            try
            {
                ClientDL Client = new ClientDL();
                return Client.ListaDescripcion(IdCompany, NameClient);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientBE Selecciona(int IdClient)
        {
            try
            {
                ClientDL Client = new ClientDL();
                ClientBE objEmp = Client.Selecciona(IdClient);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientBE SeleccionaDescripcion(int IdCompany, string NameClient)
        {
            try
            {
                ClientDL Client = new ClientDL();
                ClientBE objEmp = Client.SeleccionaDescripcion(IdCompany, NameClient);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ClientBE pItem, List<ClientAddressBE> pListaClientAddress, List<ClientContactBE> pListaClientContact, List<ClientDepartmentBE> pListaClientDepartment, List<ClientDocumentBE> pListaClientDocument, List<ClientGoalBE> pListaClientGoal, List<ClientBrandBE> pListaClientBrand)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClientDL Client = new ClientDL();
                    ClientAddressDL ClientAddress = new ClientAddressDL();
                    ClientContactDL ClientContact = new ClientContactDL();
                    ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                    ClientDocumentDL ClientDocument = new ClientDocumentDL();
                    ClientGoalDL ClientGoal = new ClientGoalDL();
                    ClientBrandDL ClientBrand = new ClientBrandDL();

                    int IdClient = 0;
                    IdClient = Client.Inserta(pItem);

                    foreach (var item in pListaClientAddress)
                    {
                        item.IdClient = IdClient;
                        ClientAddress.Inserta(item);
                    }

                    foreach (var item in pListaClientContact)
                    {
                        item.IdClient = IdClient;
                        ClientContact.Inserta(item);
                    }

                    foreach (var item in pListaClientDepartment)
                    {
                        item.IdClient = IdClient;
                        ClientDepartment.Inserta(item);
                    }

                    foreach (var item in pListaClientDocument)
                    {
                        item.IdClient = IdClient;
                        ClientDocument.Inserta(item);
                    }

                    foreach (var item in pListaClientGoal)
                    {
                        item.IdClient = IdClient;
                        ClientGoal.Inserta(item);
                    }

                    foreach (var item in pListaClientBrand)
                    {
                        item.IdClient = IdClient;
                        ClientBrand.Inserta(item);
                    }

                    ts.Complete();

                    return IdClient;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientBE pItem, List<ClientAddressBE> pListaClientAddress, List<ClientContactBE> pListaClientContact, List<ClientDepartmentBE> pListaClientDepartment, List<ClientDocumentBE> pListaClientDocument, List<ClientGoalBE> pListaClientGoal, List<ClientBrandBE> pListaClientBrand)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClientDL Client = new ClientDL();
                    ClientAddressDL ClientAddress = new ClientAddressDL();
                    ClientContactDL ClientContact = new ClientContactDL();
                    ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                    ClientDocumentDL ClientDocument = new ClientDocumentDL();
                    ClientGoalDL ClientGoal = new ClientGoalDL();
                    ClientBrandDL ClientBrand = new ClientBrandDL();

                    foreach (var item in pListaClientAddress)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientAddress.Inserta(item);
                        }
                        else
                        {

                            ClientAddress.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaClientContact)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientContact.Inserta(item);
                        }
                        else
                        {

                            ClientContact.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaClientDepartment)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientDepartment.Inserta(item);
                        }
                        else
                        {

                            ClientDepartment.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaClientDocument)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientDocument.Inserta(item);
                        }
                        else
                        {

                            ClientDocument.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaClientGoal)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientGoal.Inserta(item);
                        }
                        else
                        {

                            ClientGoal.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaClientBrand)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdClient = pItem.IdClient;
                            ClientBrand.Inserta(item);
                        }
                        else
                        {

                            ClientBrand.Actualiza(item);
                        }
                    }


                    Client.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClientDL Client = new ClientDL();
                    ClientAddressDL ClientAddress = new ClientAddressDL();
                    ClientContactDL ClientContact = new ClientContactDL();
                    ClientDepartmentDL ClientDepartment = new ClientDepartmentDL();
                    ClientDocumentDL ClientDocument = new ClientDocumentDL();
                    ClientGoalDL ClientGoal = new ClientGoalDL();
                    ClientBrandDL ClientBrand = new ClientBrandDL();

                    //Client SENSOR
                    List<ClientAddressBE> lstClientAddress = null;
                    lstClientAddress = new ClientAddressDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientAddress)
                    {
                        ClientAddress.Elimina(item);
                    }

                    //Client VERIFICACIÓN
                    List<ClientContactBE> lstClientContact = null;
                    lstClientContact = new ClientContactDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientContact)
                    {
                        ClientContact.Elimina(item);
                    }

                    //Client MOVIMIENTO
                    List<ClientDepartmentBE> lstClientDepartment = null;
                    lstClientDepartment = new ClientDepartmentDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientDepartment)
                    {
                        ClientDepartment.Elimina(item);
                    }

                    //Client DIAGNOSTICO
                    List<ClientDocumentBE> lstClientDocument = null;
                    lstClientDocument = new ClientDocumentDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientDocument)
                    {
                        ClientDocument.Elimina(item);
                    }

                    //CLIENT GOAL
                    List<ClientGoalBE> lstClientGoal = null;
                    lstClientGoal = new ClientGoalDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientGoal)
                    {
                        ClientGoal.Elimina(item);
                    }

                    //Client BRAND
                    List<ClientBrandBE> lstClientBrand = null;
                    lstClientBrand = new ClientBrandDL().ListaTodosActivo(pItem.IdClient);

                    foreach (var item in lstClientBrand)
                    {
                        ClientBrand.Elimina(item);
                    }

                    Client.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
