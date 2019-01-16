using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class MediaUnitBL
    {
        public List<MediaUnitBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                return MediaUnit.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public MediaUnitBE Selecciona(int IdMediaUnit)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnitBE objEmp = MediaUnit.Selecciona(IdMediaUnit);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MediaUnitBE SeleccionaDescripcion(int IdCompany, string NameMediaUnit)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnitBE objEmp = MediaUnit.SeleccionaDescripcion(IdCompany, NameMediaUnit);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MediaUnitBE SeleccionaAbreviatura(int IdCompany, string Abbreviate)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnitBE objEmp = MediaUnit.SeleccionaAbreviatura(IdCompany, Abbreviate);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(MediaUnitBE pItem)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnit.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MediaUnitBE pItem)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnit.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MediaUnitBE pItem)
        {
            try
            {
                MediaUnitDL MediaUnit = new MediaUnitDL();
                MediaUnit.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
