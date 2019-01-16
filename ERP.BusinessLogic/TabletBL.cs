using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TabletBL
    {
        public List<TabletBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TabletDL Tablet = new TabletDL();
                return Tablet.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TabletBE pItem)
        {
            try
            {
                TabletDL Tablet = new TabletDL();
                Tablet.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TabletBE pItem)
        {
            try
            {
                TabletDL Tablet = new TabletDL();
                Tablet.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TabletBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TabletDL Tablet = new TabletDL();
                    ElementTabletDL ElementTablet = new ElementTabletDL();

                    List<ElementTabletBE> pListaElementTablet = null;
                    pListaElementTablet = new ElementTabletBL().ListaTodosActivo(pItem.IdCompany, pItem.IdTablet);

                    //Eliminar los elementos de la Tablet
                    foreach (var item in pListaElementTablet)
                    {
                        ElementTablet.Elimina(item);
                    }

                    Tablet.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
