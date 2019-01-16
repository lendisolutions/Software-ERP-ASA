using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ProgramProductionDevelopmentBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ProgramProductionDevelopmentBE> ListaTodosActivo(int IdProgramProduction, int IdProgramProductionDevelopment)
        {
            try
            {
                ProgramProductionDevelopmentDL ProgramProductionDevelopment = new ProgramProductionDevelopmentDL();
                return ProgramProductionDevelopment.ListaTodosActivo(IdProgramProduction, IdProgramProductionDevelopment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProgramProductionDevelopmentBE Selecciona(int IdProgramProductionDevelopment)
        {
            try
            {
                ProgramProductionDevelopmentDL ProgramProductionDevelopment = new ProgramProductionDevelopmentDL();
                ProgramProductionDevelopmentBE objEmp = ProgramProductionDevelopment.Selecciona(IdProgramProductionDevelopment);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ProgramProductionDevelopmentBE pItem)
        {
            try
            {
                ProgramProductionDevelopmentDL ProgramProductionDevelopment = new ProgramProductionDevelopmentDL();
                ProgramProductionDevelopment.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<ProgramProductionDevelopmentBE> pListaProgramProductionDevelopment)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProgramProductionDevelopmentDL ProgramProductionDevelopment = new ProgramProductionDevelopmentDL();

                    foreach (var item in pListaProgramProductionDevelopment)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            ProgramProductionDevelopment.Inserta(item);
                        }
                        else
                        {
                            ProgramProductionDevelopment.Actualiza(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProgramProductionDevelopmentBE pItem)
        {
            try
            {
                ProgramProductionDevelopmentDL ProgramProductionDevelopment = new ProgramProductionDevelopmentDL();
                ProgramProductionDevelopment.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
