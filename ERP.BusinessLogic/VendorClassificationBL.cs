using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class VendorClassificationBL
    {
        public List<VendorClassificationBE> ListaTodosActivo(int Client)
        {
            try
            {
                VendorClassificationDL VendorClassification = new VendorClassificationDL();
                return VendorClassification.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public VendorClassificationBE Selecciona(int IdVendorClassification)
        {
            try
            {
                VendorClassificationDL VendorClassification = new VendorClassificationDL();
                VendorClassificationBE objEmp = VendorClassification.Selecciona(IdVendorClassification);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(VendorClassificationBE pItem)
        {
            try
            {
                VendorClassificationDL VendorClassification = new VendorClassificationDL();
                VendorClassification.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VendorClassificationBE pItem)
        {
            try
            {
                VendorClassificationDL VendorClassification = new VendorClassificationDL();
                VendorClassification.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VendorClassificationBE pItem)
        {
            try
            {
                VendorClassificationDL VendorClassification = new VendorClassificationDL();
                VendorClassification.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
