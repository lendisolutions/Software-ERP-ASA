using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TypeBL
    {
        public List<TypeBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TypeDL Type = new TypeDL();
                return Type.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TypeBE Selecciona(int IdType)
        {
            try
            {
                TypeDL Type = new TypeDL();
                TypeBE objEmp = Type.Selecciona(IdType);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TypeBE SeleccionaDescripcion(int IdCompany, string NameType)
        {
            try
            {
                TypeDL Type = new TypeDL();
                TypeBE objEmp = Type.SeleccionaDescripcion(IdCompany, NameType);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TypeBE pItem)
        {
            try
            {
                TypeDL Type = new TypeDL();
                Type.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TypeBE pItem)
        {
            try
            {
                TypeDL Type = new TypeDL();
                Type.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TypeBE pItem)
        {
            try
            {
                TypeDL Type = new TypeDL();
                Type.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
