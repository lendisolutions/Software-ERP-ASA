using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ProgramProductionDetailBL
    {
        public List<ProgramProductionDetailBE> ListaTodosActivo(int IdProgramProduction)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                return ProgramProductionDetail.ListaTodosActivo(IdProgramProduction);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionDetailBE> ListaNumberPO(int IdClient, string NumberPO)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                return ProgramProductionDetail.ListaNumberPO(IdClient,NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProgramProductionDetailBE Selecciona(int IdProgramProductionDetail)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                ProgramProductionDetailBE objEmp = ProgramProductionDetail.Selecciona(IdProgramProductionDetail);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ProgramProductionDetailBE pItem)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                ProgramProductionDetail.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProgramProductionDetailBE pItem)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                ProgramProductionDetail.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProgramProductionDetailBE pItem)
        {
            try
            {
                ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();
                ProgramProductionDetail.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
