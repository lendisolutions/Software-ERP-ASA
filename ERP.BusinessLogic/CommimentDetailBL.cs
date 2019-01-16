using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class CommimentDetailBL
    {
        public List<CommimentDetailBE> ListaTodosActivo(int Client)
        {
            try
            {
                CommimentDetailDL CommimentDetail = new CommimentDetailDL();
                return CommimentDetail.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CommimentDetailBE Selecciona(int IdCommimentDetail)
        {
            try
            {
                CommimentDetailDL CommimentDetail = new CommimentDetailDL();
                CommimentDetailBE objEmp = CommimentDetail.Selecciona(IdCommimentDetail);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(CommimentDetailBE pItem)
        {
            try
            {
                CommimentDetailDL CommimentDetail = new CommimentDetailDL();
                CommimentDetail.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CommimentDetailBE pItem)
        {
            try
            {
                CommimentDetailDL CommimentDetail = new CommimentDetailDL();
                CommimentDetail.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CommimentDetailBE pItem)
        {
            try
            {
                CommimentDetailDL CommimentDetail = new CommimentDetailDL();
                CommimentDetail.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
