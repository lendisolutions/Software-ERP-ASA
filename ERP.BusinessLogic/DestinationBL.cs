using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class DestinationBL
    {
        public List<DestinationBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                return Destination.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public DestinationBE Selecciona(int IdDestination)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                DestinationBE objEmp = Destination.Selecciona(IdDestination);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DestinationBE SeleccionaDescripcion(int IdCompany, string NameDestination)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                DestinationBE objEmp = Destination.SeleccionaDescripcion(IdCompany, NameDestination);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(DestinationBE pItem)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                Destination.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DestinationBE pItem)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                Destination.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DestinationBE pItem)
        {
            try
            {
                DestinationDL Destination = new DestinationDL();
                Destination.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
