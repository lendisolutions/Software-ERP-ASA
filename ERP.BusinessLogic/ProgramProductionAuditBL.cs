using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ProgramProductionAuditBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ProgramProductionAuditBE> ListaTodosActivo(int IdProgramProduction, int IdProgramProductionAudit)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaTodosActivo(IdProgramProduction, IdProgramProductionAudit);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaClient(int IdClient, int IdDivision)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaClient(IdClient, IdDivision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaCodigo(int IdProgramProductionAudit)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaCodigo(IdProgramProductionAudit);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaClientStyle(int IdClient, int IdStyle)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaClientStyle(IdClient, IdStyle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaClientDate(int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaClientDate(IdClient, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaClientNumberPO(int IdClient, string NumberPO)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaClientNumberPO(IdClient,NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionAuditBE> ListaClientNumeroOI(string NumeroOI)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.ListaClientNumeroOI(NumeroOI);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProgramProductionAuditBE Selecciona(int IdProgramProductionAudit)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                ProgramProductionAuditBE objEmp = ProgramProductionAudit.Selecciona(IdProgramProductionAudit);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProgramProductionAuditBE SeleccionaNumero(int IdProgramProduction, int IdStyle, string NumeroOI)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                ProgramProductionAuditBE objEmp = ProgramProductionAudit.SeleccionaNumero(IdProgramProduction,IdStyle, NumeroOI);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(string Periodo)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                return ProgramProductionAudit.SeleccionaBusquedaCount(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProgramProductionAuditBE pItem)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                ProgramProductionAudit.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<ProgramProductionAuditBE> pListaProgramProductionAudit)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();

                    foreach (var item in pListaProgramProductionAudit)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            ProgramProductionAudit.Inserta(item);
                        }
                        else
                        {
                            ProgramProductionAudit.Actualiza(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProgramProductionAuditBE pItem)
        {
            try
            {
                ProgramProductionAuditDL ProgramProductionAudit = new ProgramProductionAuditDL();
                ProgramProductionAudit.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
