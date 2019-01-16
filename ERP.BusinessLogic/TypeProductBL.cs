using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TypeProductBL
    {
        public List<TypeProductBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                return TypeProduct.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TypeProductBE Selecciona(int IdTypeProduct)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                TypeProductBE objEmp = TypeProduct.Selecciona(IdTypeProduct);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TypeProductBE SeleccionaDescripcion(int IdCompany, string NameTypeProduct)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                TypeProductBE objEmp = TypeProduct.SeleccionaDescripcion(IdCompany, NameTypeProduct);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TypeProductBE pItem)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                TypeProduct.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TypeProductBE pItem)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                TypeProduct.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TypeProductBE pItem)
        {
            try
            {
                TypeProductDL TypeProduct = new TypeProductDL();
                TypeProduct.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
