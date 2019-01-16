using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class InvoiceBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<InvoiceBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                return Invoice.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InvoiceBE> ListaClient(int IdCompany, int IdClient, int IdStatus)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                return Invoice.ListaClient(IdCompany, IdClient, IdStatus);
            }
            catch (Exception ex)
            { throw ex; }
        }

       
        public List<InvoiceBE> ListaClientDate(int IdCompany, int IdClient, int IdStatus, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                return Invoice.ListaClientDate(IdCompany, IdClient, IdStatus, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InvoiceBE> ListaNumberInvoice(int IdCompany, int IdClient, string NumberInvoice)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                return Invoice.ListaNumberInvoice(IdCompany, IdClient, NumberInvoice);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InvoiceBE Selecciona(int IdInvoice)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                InvoiceBE objEmp = Invoice.Selecciona(IdInvoice);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InvoiceBE SeleccionaNumberInvoice(string NumberInvoice)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                InvoiceBE objEmp = Invoice.SeleccionaNumberInvoice(NumberInvoice);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdCompany, int IdClient)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                return Invoice.SeleccionaBusquedaCount(IdCompany, IdClient);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(InvoiceBE pItem, List<InvoiceDetailBE> pListaInvoiceDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InvoiceDL Invoice = new InvoiceDL();
                    InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                    InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();

                    int IdInvoice = 0;
                    IdInvoice = Invoice.Inserta(pItem);

                    foreach (var item in pListaInvoiceDetail)
                    {
                        InspectionCertificate.ActualizaSituacion(item.IdInspectionCertificate, 15);

                        item.IdInvoice = IdInvoice;
                        InvoiceDetail.Inserta(item);
                    }

                    ts.Complete();

                    return IdInvoice;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InvoiceBE pItem, List<InvoiceDetailBE> pListaInvoiceDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InvoiceDL Invoice = new InvoiceDL();
                    InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();

                    foreach (var item in pListaInvoiceDetail)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdInvoice = pItem.IdInvoice;
                            InvoiceDetail.Inserta(item);
                        }
                        else
                        {

                            InvoiceDetail.Actualiza(item);
                        }
                    }


                    Invoice.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdInvoice, int IdStatus)
        {
            try
            {
                InvoiceDL Invoice = new InvoiceDL();
                Invoice.ActualizaSituacion(IdInvoice, IdStatus);

                //INSPECTION CERTIFICATE DETAIL
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                List<InvoiceDetailBE> lstInvoiceDetail = null;
                lstInvoiceDetail = new InvoiceDetailDL().ListaTodosActivo(IdInvoice);

                foreach (var item in lstInvoiceDetail)
                {
                    InspectionCertificate.ActualizaSituacion(item.IdInspectionCertificate, 14);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacionMasivo(List<InvoiceBE> pListaInvoice)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InvoiceDL objInvoice = new InvoiceDL();

                    foreach (InvoiceBE item in pListaInvoice)
                    {
                        objInvoice.ActualizaSituacion(item.IdInvoice, item.IdStatus);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(InvoiceBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InvoiceDL Invoice = new InvoiceDL();
                    InvoiceDetailDL InvoiceDetail = new InvoiceDetailDL();
                    InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();

                    //INSPECTION CERTIFICATE DETAIL
                    List<InvoiceDetailBE> lstInvoiceDetail = null;
                    lstInvoiceDetail = new InvoiceDetailDL().ListaTodosActivo(pItem.IdInvoice);

                    foreach (var item in lstInvoiceDetail)
                    {
                        InspectionCertificate.ActualizaSituacion(item.IdInspectionCertificate, 14);

                        InvoiceDetail.Elimina(item);
                    }

                    Invoice.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
