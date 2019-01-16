using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class BankBL
    {
        public List<BankBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                BankDL Bank = new BankDL();
                return Bank.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public BankBE Selecciona(int IdBank)
        {
            try
            {
                BankDL Bank = new BankDL();
                BankBE objEmp = Bank.Selecciona(IdBank);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public BankBE SeleccionaDescripcion(int IdCompany, string NameBank)
        {
            try
            {
                BankDL Bank = new BankDL();
                BankBE objEmp = Bank.SeleccionaDescripcion(IdCompany, NameBank);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(BankBE pItem)
        {
            try
            {
                BankDL Bank = new BankDL();
                Bank.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(BankBE pItem)
        {
            try
            {
                BankDL Bank = new BankDL();
                Bank.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(BankBE pItem)
        {
            try
            {
                BankDL Bank = new BankDL();
                Bank.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
