using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class StyleBL
    {
        public List<StyleBE> ListaTodosActivo(int IdCompany, int IdClient, int IdClientDepartment)
        {
            try
            {
                StyleDL Style = new StyleDL();
                return Style.ListaTodosActivo(IdCompany, IdClient, IdClientDepartment);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StyleBE Selecciona(int IdStyle)
        {
            try
            {
                StyleDL Style = new StyleDL();
                StyleBE objEmp = Style.Selecciona(IdStyle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(StyleBE pItem)
        {
            try
            {
                StyleDL Style = new StyleDL();
                Style.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMasivo(List<StyleBE> pListaStyle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    StyleDL objStyle = new StyleDL();

                    foreach (StyleBE item in pListaStyle)
                    {
                        objStyle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(StyleBE pItem)
        {
            try
            {
                StyleDL Style = new StyleDL();
                Style.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(StyleBE pItem)
        {
            try
            {
                StyleDL Style = new StyleDL();
                Style.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
