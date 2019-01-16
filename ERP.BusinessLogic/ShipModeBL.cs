using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ShipModeBL
    {
        public List<ShipModeBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                return ShipMode.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public ShipModeBE Selecciona(int IdShipMode)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                ShipModeBE objEmp = ShipMode.Selecciona(IdShipMode);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ShipModeBE SeleccionaDescripcion(int IdCompany, string NameShipMode)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                ShipModeBE objEmp = ShipMode.SeleccionaDescripcion(IdCompany, NameShipMode);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ShipModeBE pItem)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                ShipMode.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ShipModeBE pItem)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                ShipMode.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ShipModeBE pItem)
        {
            try
            {
                ShipModeDL ShipMode = new ShipModeDL();
                ShipMode.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
