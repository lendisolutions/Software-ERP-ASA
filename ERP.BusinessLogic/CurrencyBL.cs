using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class CurrencyBL
    {
        public List<CurrencyBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                return Currency.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CurrencyBE> ListaCombo(int IdCompany)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                return Currency.ListaCombo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public CurrencyBE Selecciona(int IdCurrency)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                CurrencyBE objEmp = Currency.Selecciona(IdCurrency);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CurrencyBE SeleccionaDescripcion(int IdCompany, string NameCurrency)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                CurrencyBE objEmp = Currency.SeleccionaDescripcion(IdCompany, NameCurrency);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(CurrencyBE pItem)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                Currency.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CurrencyBE pItem)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                Currency.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CurrencyBE pItem)
        {
            try
            {
                CurrencyDL Currency = new CurrencyDL();
                Currency.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
