using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TypeDesignBL
    {
        public List<TypeDesignBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                return TypeDesign.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TypeDesignBE Selecciona(int IdTypeDesign)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                TypeDesignBE objEmp = TypeDesign.Selecciona(IdTypeDesign);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TypeDesignBE SeleccionaDescripcion(int IdCompany, string NameTypeDesign)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                TypeDesignBE objEmp = TypeDesign.SeleccionaDescripcion(IdCompany, NameTypeDesign);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TypeDesignBE pItem)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                TypeDesign.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TypeDesignBE pItem)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                TypeDesign.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TypeDesignBE pItem)
        {
            try
            {
                TypeDesignDL TypeDesign = new TypeDesignDL();
                TypeDesign.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
