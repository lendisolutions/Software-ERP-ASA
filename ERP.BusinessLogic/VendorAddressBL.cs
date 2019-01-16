using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class VendorAddressBL
    {
        public List<VendorAddressBE> ListaTodosActivo(int Vendor)
        {
            try
            {
                VendorAddressDL VendorAddress = new VendorAddressDL();
                return VendorAddress.ListaTodosActivo(Vendor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public VendorAddressBE Selecciona(int IdVendorAddress)
        {
            try
            {
                VendorAddressDL VendorAddress = new VendorAddressDL();
                VendorAddressBE objEmp = VendorAddress.Selecciona(IdVendorAddress);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(VendorAddressBE pItem)
        {
            try
            {
                VendorAddressDL VendorAddress = new VendorAddressDL();
                VendorAddress.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VendorAddressBE pItem)
        {
            try
            {
                VendorAddressDL VendorAddress = new VendorAddressDL();
                VendorAddress.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VendorAddressBE pItem)
        {
            try
            {
                VendorAddressDL VendorAddress = new VendorAddressDL();
                VendorAddress.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
