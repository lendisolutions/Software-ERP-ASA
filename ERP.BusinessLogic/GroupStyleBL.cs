using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class GroupStyleBL
    {
        public List<GroupStyleBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                return GroupStyle.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public GroupStyleBE Selecciona(int IdGroupStyle)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                GroupStyleBE objEmp = GroupStyle.Selecciona(IdGroupStyle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public GroupStyleBE SeleccionaDescripcion(int IdCompany, string NameGroupStyle)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                GroupStyleBE objEmp = GroupStyle.SeleccionaDescripcion(IdCompany, NameGroupStyle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(GroupStyleBE pItem)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                GroupStyle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(GroupStyleBE pItem)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                GroupStyle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(GroupStyleBE pItem)
        {
            try
            {
                GroupStyleDL GroupStyle = new GroupStyleDL();
                GroupStyle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
