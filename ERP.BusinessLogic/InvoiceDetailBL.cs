using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class InvoiceDetailBL
    {
        public List<InvoiceDetailBE> ListaTodosActivo(int IdInvoice)
        {
            try
            {
                InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                return InvoiceDetail.ListaTodosActivo(IdInvoice);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InvoiceDetailBE Selecciona(int IdInvoiceDetail)
        {
            try
            {
                InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                InvoiceDetailBE objEmp = InvoiceDetail.Selecciona(IdInvoiceDetail);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(InvoiceDetailBE pItem)
        {
            try
            {
                InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                InvoiceDetail.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InvoiceDetailBE pItem)
        {
            try
            {
                InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                InvoiceDetail.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InvoiceDetailBE pItem)
        {
            try
            {
                InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                InvoiceDetail.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
