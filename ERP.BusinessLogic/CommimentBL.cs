using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class CommimentBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<CommimentBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                return Commiment.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CommimentBE> ListaNumberCommiment(int IdCompany, string NumberCommiment)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                return Commiment.ListaNumberCommiment(IdCompany, NumberCommiment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CommimentBE> ListaClient(int IdCompany, int IdClient)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                return Commiment.ListaClient(IdCompany, IdClient);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CommimentBE> ListaClientCommimentDate(int IdCompany, int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                return Commiment.ListaClientCommimentDate(IdCompany, IdClient,DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CommimentBE> ListaClientContractShipDate(int IdCompany, int IdClient, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                return Commiment.ListaClientContractShipDate(IdCompany, IdClient,  DateFrom, DateTo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CommimentBE Selecciona(int IdCommiment)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                CommimentBE objEmp = Commiment.Selecciona(IdCommiment);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(CommimentBE pItem, List<CommimentDetailBE> pListaCommimentDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CommimentDL Commiment = new CommimentDL();
                    CommimentDetailDL CommimentDetail = new CommimentDetailDL();

                    int IdCommiment = 0;
                    IdCommiment = Commiment.Inserta(pItem);

                    foreach (var item in pListaCommimentDetail)
                    {
                        item.IdCommiment = IdCommiment;
                        CommimentDetail.Inserta(item);
                    }

                    ts.Complete();

                    return IdCommiment;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CommimentBE pItem, List<CommimentDetailBE> pListaCommimentDetail)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CommimentDL Commiment = new CommimentDL();
                    CommimentDetailDL CommimentDetail = new CommimentDetailDL();

                    foreach (var item in pListaCommimentDetail)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdCommiment = pItem.IdCommiment;
                            CommimentDetail.Inserta(item);
                        }
                        else
                        {

                            CommimentDetail.Actualiza(item);
                        }
                    }


                    Commiment.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdCommiment, string NumberPP)
        {
            try
            {
                CommimentDL Commiment = new CommimentDL();
                Commiment.ActualizaNumero(IdCommiment, NumberPP);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CommimentBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CommimentDL Commiment = new CommimentDL();
                    CommimentDetailDL CommimentDetail = new CommimentDetailDL();

                    //Client SENSOR
                    List<CommimentDetailBE> lstCommimentDetail = null;
                    lstCommimentDetail = new CommimentDetailDL().ListaTodosActivo(pItem.IdCommiment);

                    foreach (var item in lstCommimentDetail)
                    {
                        CommimentDetail.Elimina(item);
                    }

                    Commiment.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
