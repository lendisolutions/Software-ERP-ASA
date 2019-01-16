using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class SeasonBL
    {
        public List<SeasonBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                return Season.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public SeasonBE Selecciona(int IdSeason)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                SeasonBE objEmp = Season.Selecciona(IdSeason);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeasonBE SeleccionaDescripcion(int IdCompany, string NameSeason)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                SeasonBE objEmp = Season.SeleccionaDescripcion(IdCompany, NameSeason);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(SeasonBE pItem)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                Season.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SeasonBE pItem)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                Season.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SeasonBE pItem)
        {
            try
            {
                SeasonDL Season = new SeasonDL();
                Season.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
