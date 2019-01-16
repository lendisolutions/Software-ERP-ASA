using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class InspectionCertificateBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<InspectionCertificateBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaClient(int IdCompany, int IdClient, int IdStatus)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaClient(IdCompany, IdClient, IdStatus);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaClientNumberPO(int IdCompany, int IdClient, string NumberPO)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaClientNumberPO(IdCompany, IdClient, NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaClientNumberOI(int IdCompany, int IdClient, string NumberOI)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaClientNumberOI(IdCompany, IdClient, NumberOI);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaClientDate(int IdCompany, int IdClient, int IdStatus, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaClientDate(IdCompany, IdClient, IdStatus, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaNumberCertificate(int IdCompany, int IdClient, string NumberCertificate)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaNumberCertificate(IdCompany, IdClient, NumberCertificate);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaVendorStatus(int IdCompany, int IdVendor, int IdStatus, int NumberIni, int NumberFin)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaVendorStatus(IdCompany, IdVendor, IdStatus, NumberIni, NumberFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspectionCertificateBE> ListaInvoiceDetail(int IdCompany, string NumberCertificate)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.ListaInvoiceDetail(IdCompany, NumberCertificate);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InspectionCertificateBE Selecciona(int IdInspectionCertificate)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                InspectionCertificateBE objEmp = InspectionCertificate.Selecciona(IdInspectionCertificate);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InspectionCertificateBE SeleccionaNumberInvoice(string NumberInvoice)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                InspectionCertificateBE objEmp = InspectionCertificate.SeleccionaNumberInvoice(NumberInvoice);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdCompany, int IdClient)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                return InspectionCertificate.SeleccionaBusquedaCount(IdCompany,IdClient);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(InspectionCertificateBE pItem, List<InspectionCertificateDetailBE> pListaInspectionCertificateDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                    InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();

                    int IdInspectionCertificate = 0;
                    IdInspectionCertificate = InspectionCertificate.Inserta(pItem);

                    foreach (var item in pListaInspectionCertificateDetail)
                    {
                        item.IdInspectionCertificate = IdInspectionCertificate;
                        InspectionCertificateDetail.Inserta(item);
                    }

                    ts.Complete();

                    return IdInspectionCertificate;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InspectionCertificateBE pItem, List<InspectionCertificateDetailBE> pListaInspectionCertificateDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                    InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();

                    foreach (var item in pListaInspectionCertificateDetail)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdInspectionCertificate = pItem.IdInspectionCertificate;
                            InspectionCertificateDetail.Inserta(item);
                        }
                        else
                        {

                            InspectionCertificateDetail.Actualiza(item);
                        }
                    }


                    InspectionCertificate.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdInspectionCertificate, int IdStatus)
        {
            try
            {
                InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                InspectionCertificate.ActualizaSituacion(IdInspectionCertificate, IdStatus);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacionMasivo(List<InspectionCertificateBE> pListaInspectionCertificate)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspectionCertificateDL objInspectionCertificate = new InspectionCertificateDL();

                    foreach (InspectionCertificateBE item in pListaInspectionCertificate)
                    {
                        objInspectionCertificate.ActualizaSituacion(item.IdInspectionCertificate, item.IdStatus);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(InspectionCertificateBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspectionCertificateDL InspectionCertificate = new InspectionCertificateDL();
                    InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();

                    //INSPECTION CERTIFICATE DETAIL
                    List<InspectionCertificateDetailBE> lstInspectionCertificateDetail = null;
                    lstInspectionCertificateDetail = new InspectionCertificateDetailDL().ListaTodosActivo(pItem.IdInspectionCertificate);

                    foreach (var item in lstInspectionCertificateDetail)
                    {
                        InspectionCertificateDetail.Elimina(item);
                    }

                    InspectionCertificate.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
