using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class TallaBL
    {
        public List<TallaBE> ListaTodosActivo(int IdCompany)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                return Talla.ListaTodosActivo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TallaBE Selecciona(int IdTalla)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                TallaBE objEmp = Talla.Selecciona(IdTalla);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TallaBE SeleccionaDescripcion(int IdCompany, string NameTalla)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                TallaBE objEmp = Talla.SeleccionaDescripcion(IdCompany, NameTalla);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TallaBE pItem)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                Talla.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TallaBE pItem)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                Talla.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TallaBE pItem)
        {
            try
            {
                TallaDL Talla = new TallaDL();
                Talla.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
