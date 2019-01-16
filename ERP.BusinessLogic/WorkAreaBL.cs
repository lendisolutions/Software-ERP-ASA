using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class WorkAreaBL
    {
        public List<WorkAreaBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                return WorkArea.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public WorkAreaBE Selecciona(int IdCompany, int IdWorkArea)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                WorkAreaBE objEmp = WorkArea.Selecciona(IdCompany,IdWorkArea);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public WorkAreaBE SeleccionaDescripcion(int IdCompany, string NameWorkArea)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                WorkAreaBE objEmp = WorkArea.SeleccionaDescripcion(IdCompany, NameWorkArea);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(WorkAreaBE pItem)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                WorkArea.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(WorkAreaBE pItem)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                WorkArea.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(WorkAreaBE pItem)
        {
            try
            {
                WorkAreaDL WorkArea = new WorkAreaDL();
                WorkArea.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
