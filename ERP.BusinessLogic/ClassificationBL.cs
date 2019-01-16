using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClassificationBL
    {
        public List<ClassificationBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                return Classification.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public ClassificationBE Selecciona(int IdClassification)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                ClassificationBE objEmp = Classification.Selecciona(IdClassification);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClassificationBE SeleccionaDescripcion(int IdCompany, string NameClassification)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                ClassificationBE objEmp = Classification.SeleccionaDescripcion(IdCompany, NameClassification);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClassificationBE pItem)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                Classification.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClassificationBE pItem)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                Classification.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClassificationBE pItem)
        {
            try
            {
                ClassificationDL Classification = new ClassificationDL();
                Classification.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
