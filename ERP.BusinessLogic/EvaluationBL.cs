using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class EvaluationBL
    {
        public List<EvaluationBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                return Evaluation.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public EvaluationBE Selecciona(int IdEvaluation)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                EvaluationBE objEmp = Evaluation.Selecciona(IdEvaluation);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EvaluationBE SeleccionaDescripcion(int IdCompany, string NameEvaluation)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                EvaluationBE objEmp = Evaluation.SeleccionaDescripcion(IdCompany, NameEvaluation);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(EvaluationBE pItem)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                Evaluation.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EvaluationBE pItem)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                Evaluation.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EvaluationBE pItem)
        {
            try
            {
                EvaluationDL Evaluation = new EvaluationDL();
                Evaluation.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
