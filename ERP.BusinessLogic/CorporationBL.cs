using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class CorporationBL
    {
        public List<CorporationBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                return Corporation.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public CorporationBE Selecciona(int IdCorporation)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                CorporationBE objEmp = Corporation.Selecciona(IdCorporation);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CorporationBE SeleccionaDescripcion(int IdCompany, string NameCorporation)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                CorporationBE objEmp = Corporation.SeleccionaDescripcion(IdCompany, NameCorporation);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(CorporationBE pItem)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                Corporation.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CorporationBE pItem)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                Corporation.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CorporationBE pItem)
        {
            try
            {
                CorporationDL Corporation = new CorporationDL();
                Corporation.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
