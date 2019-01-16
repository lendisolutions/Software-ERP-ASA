using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TypeStyleBL
    {
        public List<TypeStyleBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                return TypeStyle.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TypeStyleBE Selecciona(int IdTypeStyle)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                TypeStyleBE objEmp = TypeStyle.Selecciona(IdTypeStyle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TypeStyleBE SeleccionaDescripcion(int IdCompany, string NameTypeStyle)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                TypeStyleBE objEmp = TypeStyle.SeleccionaDescripcion(IdCompany, NameTypeStyle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TypeStyleBE pItem)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                TypeStyle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TypeStyleBE pItem)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                TypeStyle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TypeStyleBE pItem)
        {
            try
            {
                TypeStyleDL TypeStyle = new TypeStyleDL();
                TypeStyle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
