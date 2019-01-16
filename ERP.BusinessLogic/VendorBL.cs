using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class VendorBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<VendorBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                VendorDL Vendor = new VendorDL();
                return Vendor.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public VendorBE Selecciona(int IdVendor)
        {
            try
            {
                VendorDL Vendor = new VendorDL();
                VendorBE objEmp = Vendor.Selecciona(IdVendor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public Int32 Inserta(VendorBE pItem, List<VendorAddressBE> pListaVendorAddress, List<VendorContactBE> pListaVendorContact, List<VendorClassificationBE> pListaVendorClassification)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VendorDL Vendor = new VendorDL();
                    VendorAddressDL VendorAddress = new VendorAddressDL();
                    VendorContactDL VendorContact = new VendorContactDL();
                    VendorClassificationDL VendorClassification = new VendorClassificationDL();
                    
                    int IdVendor = 0;
                    IdVendor = Vendor.Inserta(pItem);

                    foreach (var item in pListaVendorAddress)
                    {
                        item.IdVendor = IdVendor;
                        VendorAddress.Inserta(item);
                    }

                    foreach (var item in pListaVendorContact)
                    {
                        item.IdVendor = IdVendor;
                        VendorContact.Inserta(item);
                    }

                    foreach (var item in pListaVendorClassification)
                    {
                        item.IdVendor = IdVendor;
                        VendorClassification.Inserta(item);
                    }

                    
                    ts.Complete();

                    return IdVendor;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VendorBE pItem, List<VendorAddressBE> pListaVendorAddress, List<VendorContactBE> pListaVendorContact, List<VendorClassificationBE> pListaVendorClassification)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VendorDL Vendor = new VendorDL();
                    VendorAddressDL VendorAddress = new VendorAddressDL();
                    VendorContactDL VendorContact = new VendorContactDL();
                    VendorClassificationDL VendorClassification = new VendorClassificationDL();

                    foreach (var item in pListaVendorAddress)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdVendor = pItem.IdVendor;
                            VendorAddress.Inserta(item);
                        }
                        else
                        {

                            VendorAddress.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaVendorContact)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdVendor = pItem.IdVendor;
                            VendorContact.Inserta(item);
                        }
                        else
                        {

                            VendorContact.Actualiza(item);
                        }
                    }

                    foreach (var item in pListaVendorClassification)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdVendor = pItem.IdVendor;
                            VendorClassification.Inserta(item);
                        }
                        else
                        {

                            VendorClassification.Actualiza(item);
                        }
                    }

                    Vendor.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VendorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VendorDL Vendor = new VendorDL();
                    VendorAddressDL VendorAddress = new VendorAddressDL();
                    VendorContactDL VendorContact = new VendorContactDL();
                    VendorClassificationDL VendorClassification = new VendorClassificationDL();

                    List<VendorAddressBE> lstVendorAddress = null;
                    lstVendorAddress = new VendorAddressDL().ListaTodosActivo(pItem.IdVendor);

                    foreach (var item in lstVendorAddress)
                    {
                        VendorAddress.Elimina(item);
                    }

                    List<VendorContactBE> lstVendorContact = null;
                    lstVendorContact = new VendorContactDL().ListaTodosActivo(pItem.IdVendor);

                    foreach (var item in lstVendorContact)
                    {
                        VendorContact.Elimina(item);
                    }

                    List<VendorClassificationBE> lstVendorClassification = null;
                    lstVendorClassification = new VendorClassificationDL().ListaTodosActivo(pItem.IdVendor);

                    foreach (var item in lstVendorClassification)
                    {
                        VendorClassification.Elimina(item);
                    }

                    

                    Vendor.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
