using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class CompanyBL
    {
        public List<CompanyBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                return Company.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CompanyBE> SeleccionaTodos()
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                List<CompanyBE> lista = Company.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CompanyBE> ListaCombo()
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                List<CompanyBE> lista = Company.ListaCombo();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CompanyBE Selecciona(int IdCompany)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                CompanyBE objEmp = Company.Selecciona(IdCompany);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CompanyBE SeleccionaDescripcion(string RazonSocial)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                CompanyBE objEmp = Company.SeleccionaDescripcion(RazonSocial);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CompanyBE SeleccionaRuc(string Ruc)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                CompanyBE objEmp = Company.SeleccionaRuc(Ruc);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void Inserta(CompanyBE pItem)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                Company.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CompanyBE pItem)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                Company.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CompanyBE pItem)
        {
            try
            {
                CompanyDL Company = new CompanyDL();
                Company.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
