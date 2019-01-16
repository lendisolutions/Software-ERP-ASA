using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class PhaseBL
    {
        public List<PhaseBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                return Phase.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PhaseBE Selecciona(int IdPhase)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                PhaseBE objEmp = Phase.Selecciona(IdPhase);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PhaseBE SeleccionaDescripcion(int IdCompany, string NamePhase)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                PhaseBE objEmp = Phase.SeleccionaDescripcion(IdCompany, NamePhase);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(PhaseBE pItem)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                Phase.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PhaseBE pItem)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                Phase.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PhaseBE pItem)
        {
            try
            {
                PhaseDL Phase = new PhaseDL();
                Phase.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
