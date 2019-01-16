using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ElementTabletBL
    {
        public List<ElementTabletBE> ListaTodosActivo(int IdCompany, int IdTablet)
        {
            try
            {
                ElementTabletDL ElementTablet = new ElementTabletDL();
                return ElementTablet.ListaTodosActivo(IdCompany, IdTablet);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ElementTabletBE SeleccionaDescripcion(int IdTablet, string DescElementTablet)
        {
            try
            {
                ElementTabletDL ElementTablet = new ElementTabletDL();
                ElementTabletBE objEmp = ElementTablet.SeleccionaDescripcion(IdTablet, DescElementTablet);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ElementTabletBE pItem)
        {
            try
            {
                ElementTabletDL ElementTablet = new ElementTabletDL();
                return ElementTablet.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ElementTabletBE pItem)
        {
            try
            {
                ElementTabletDL ElementTablet = new ElementTabletDL();
                ElementTablet.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ElementTabletBE pItem)
        {
            try
            {
                ElementTabletDL ElementTablet = new ElementTabletDL();
                ElementTablet.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
