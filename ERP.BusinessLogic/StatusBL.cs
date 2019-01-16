using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class StatusBL
    {
        public List<StatusBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                StatusDL Status = new StatusDL();
                return Status.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public StatusBE Selecciona(int IdStatus)
        {
            try
            {
                StatusDL Status = new StatusDL();
                StatusBE objEmp = Status.Selecciona(IdStatus);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StatusBE SeleccionaDescripcion(int IdCompany, string NameStatus)
        {
            try
            {
                StatusDL Status = new StatusDL();
                StatusBE objEmp = Status.SeleccionaDescripcion(IdCompany, NameStatus);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(StatusBE pItem)
        {
            try
            {
                StatusDL Status = new StatusDL();
                Status.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(StatusBE pItem)
        {
            try
            {
                StatusDL Status = new StatusDL();
                Status.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(StatusBE pItem)
        {
            try
            {
                StatusDL Status = new StatusDL();
                Status.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
