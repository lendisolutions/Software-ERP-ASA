using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class InspectionCertificateDetailBL
    {
        public List<InspectionCertificateDetailBE> ListaTodosActivo(int IdInspectionCertificate)
        {
            try
            {
                InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();
                return InspectionCertificateDetail.ListaTodosActivo(IdInspectionCertificate);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InspectionCertificateDetailBE Selecciona(int IdInspectionCertificateDetail)
        {
            try
            {
                InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();
                InspectionCertificateDetailBE objEmp = InspectionCertificateDetail.Selecciona(IdInspectionCertificateDetail);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(InspectionCertificateDetailBE pItem)
        {
            try
            {
                InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();
                InspectionCertificateDetail.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InspectionCertificateDetailBE pItem)
        {
            try
            {
                InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();
                InspectionCertificateDetail.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InspectionCertificateDetailBE pItem)
        {
            try
            {
                InspectionCertificateDetailDL InspectionCertificateDetail = new InspectionCertificateDetailDL();
                InspectionCertificateDetail.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
