using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class StatusPOBL
    {
        public List<StatusPOBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                return StatusPO.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public StatusPOBE Selecciona(int IdStatusPO)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                StatusPOBE objEmp = StatusPO.Selecciona(IdStatusPO);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StatusPOBE SeleccionaDescripcion(int IdCompany, string NameStatusPO)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                StatusPOBE objEmp = StatusPO.SeleccionaDescripcion(IdCompany, NameStatusPO);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(StatusPOBE pItem)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                StatusPO.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(StatusPOBE pItem)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                StatusPO.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(StatusPOBE pItem)
        {
            try
            {
                StatusPODL StatusPO = new StatusPODL();
                StatusPO.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
