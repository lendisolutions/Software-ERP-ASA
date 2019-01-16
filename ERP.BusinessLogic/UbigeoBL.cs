using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class UbigeoBL
    {
        public List<UbigeoBE> SeleccionaDepartamento()
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDepartamento();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> SeleccionaProvincia(string IdDepartamento)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaProvincia(IdDepartamento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> SeleccionaDistrito(string IdDepartamento, string IdProvincia)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDistrito(IdDepartamento, IdProvincia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> Listado()
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UbigeoBE SeleccionaDescripcion(string DescUbigeo)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDescripcion(DescUbigeo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UbigeoBE SeleccionaDescripcionDistrito(string IdDepartamento, string IdProvincia, string DescUbigeo)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDescripcionDistrito(IdDepartamento, IdProvincia, DescUbigeo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
