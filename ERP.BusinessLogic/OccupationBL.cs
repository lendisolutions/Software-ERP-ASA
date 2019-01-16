using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class OccupationBL
    {
        public List<OccupationBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                return Occupation.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public OccupationBE Selecciona(int IdOccupation)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                OccupationBE objEmp = Occupation.Selecciona(IdOccupation);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public OccupationBE SeleccionaDescripcion(string Descripcion)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                OccupationBE objEmp = Occupation.SeleccionaDescripcion(Descripcion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(OccupationBE pItem)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                Occupation.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(OccupationBE pItem)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                Occupation.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(OccupationBE pItem)
        {
            try
            {
                OccupationDL Occupation = new OccupationDL();
                Occupation.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
