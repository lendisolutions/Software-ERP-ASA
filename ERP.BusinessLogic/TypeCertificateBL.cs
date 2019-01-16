using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TypeCertificateBL
    {
        public List<TypeCertificateBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                return TypeCertificate.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TypeCertificateBE Selecciona(int IdTypeCertificate)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                TypeCertificateBE objEmp = TypeCertificate.Selecciona(IdTypeCertificate);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TypeCertificateBE SeleccionaDescripcion(int IdCompany, string NameTypeCertificate)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                TypeCertificateBE objEmp = TypeCertificate.SeleccionaDescripcion(IdCompany, NameTypeCertificate);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TypeCertificateBE pItem)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                TypeCertificate.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TypeCertificateBE pItem)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                TypeCertificate.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TypeCertificateBE pItem)
        {
            try
            {
                TypeCertificateDL TypeCertificate = new TypeCertificateDL();
                TypeCertificate.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
