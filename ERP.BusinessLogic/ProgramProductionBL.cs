using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ProgramProductionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ProgramProductionBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaNumberPO(int IdCompany, int IdClient, string NumberPO)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaNumberPO(IdCompany, IdClient,NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaNumberCommiment(int IdCompany, int IdClient, string NumberCommiment)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaNumberCommiment(IdCompany, IdClient,NumberCommiment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivision(int IdCompany, int IdClient, int IdClientDepartment)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivision(IdCompany,IdClient,IdClientDepartment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDate(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionXfDate(IdCompany, IdClient, IdClientDepartment, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionIndcDate(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionIndcDate(IdCompany, IdClient, IdClientDepartment, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaNumberPOVencimiento(int IdCompany, int IdClient, string NumberPO)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaNumberPOVencimiento(IdCompany, IdClient, NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionVencimiento(int IdCompany, int IdClient, int IdClientDepartment)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionVencimiento(IdCompany, IdClient, IdClientDepartment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDateVencimiento(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionXfDateVencimiento(IdCompany, IdClient, IdClientDepartment, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionXfDateTotal(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionXfDateTotal(IdCompany, IdClient, IdClientDepartment, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionIndcDateTotal(int IdCompany, int IdClient, int IdClientDepartment, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionIndcDateTotal(IdCompany, IdClient, IdClientDepartment, DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaClientDivisionTotal(int IdCompany, int IdClient, int IdClientDepartment)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaClientDivisionTotal(IdCompany, IdClient, IdClientDepartment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaNumberPOTotal(int IdCompany, int IdClient, string NumberPO)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaNumberPOTotal(IdCompany, IdClient, NumberPO);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProgramProductionBE> ListaNumberCommimentTotal(int IdCompany, int IdClient, string NumberCommiment)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                return ProgramProduction.ListaNumberCommimentTotal(IdCompany, IdClient, NumberCommiment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProgramProductionBE Selecciona(int IdProgramProduction)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                ProgramProductionBE objEmp = ProgramProduction.Selecciona(IdProgramProduction);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ProgramProductionBE pItem, List<ProgramProductionDetailBE> pListaProgramProductionDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                    ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();

                    int IdProgramProduction = 0;
                    IdProgramProduction = ProgramProduction.Inserta(pItem);

                    foreach (var item in pListaProgramProductionDetail)
                    {
                        item.IdProgramProduction = IdProgramProduction;
                        ProgramProductionDetail.Inserta(item);
                    }

                    ts.Complete();

                    return IdProgramProduction;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProgramProductionBE pItem, List<ProgramProductionDetailBE> pListaProgramProductionDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                    ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();

                    foreach (var item in pListaProgramProductionDetail)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdProgramProduction = pItem.IdProgramProduction;
                            ProgramProductionDetail.Inserta(item);
                        }
                        else
                        {

                            ProgramProductionDetail.Actualiza(item);
                        }
                    }


                    ProgramProduction.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdProgramProduction, string NumberPP)
        {
            try
            {
                ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                ProgramProduction.ActualizaNumero(IdProgramProduction, NumberPP);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProgramProductionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProgramProductionDL ProgramProduction = new ProgramProductionDL();
                    ProgramProductionDetailDL ProgramProductionDetail = new ProgramProductionDetailDL();

                    //Client SENSOR
                    List<ProgramProductionDetailBE> lstProgramProductionDetail = null;
                    lstProgramProductionDetail = new ProgramProductionDetailDL().ListaTodosActivo(pItem.IdProgramProduction);

                    foreach (var item in lstProgramProductionDetail)
                    {
                        ProgramProductionDetail.Elimina(item);
                    }

                    ProgramProduction.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
