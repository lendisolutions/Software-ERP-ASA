using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;


namespace ERP.BusinessLogic
{
    public class VendorContactBL
    {
        public List<VendorContactBE> ListaTodosActivo(int Vendor)
        {
            try
            {
                VendorContactDL VendorContact = new VendorContactDL();
                return VendorContact.ListaTodosActivo(Vendor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public VendorContactBE Selecciona(int IdVendorContact)
        {
            try
            {
                VendorContactDL VendorContact = new VendorContactDL();
                VendorContactBE objEmp = VendorContact.Selecciona(IdVendorContact);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(VendorContactBE pItem)
        {
            try
            {
                VendorContactDL VendorContact = new VendorContactDL();
                VendorContact.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VendorContactBE pItem)
        {
            try
            {
                VendorContactDL VendorContact = new VendorContactDL();
                VendorContact.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VendorContactBE pItem)
        {
            try
            {
                VendorContactDL VendorContact = new VendorContactDL();
                VendorContact.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
