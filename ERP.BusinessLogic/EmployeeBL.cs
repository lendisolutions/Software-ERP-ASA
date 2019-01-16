using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class EmployeeBL
    {
        public List<EmployeeBE> ListaTodosActivo(int IdEmpresa,  int IdArea)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                return Employee.ListaTodosActivo(IdEmpresa, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmployeeBE> ListaCargo(string Cargo)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                return Employee.ListaCargo(Cargo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmployeeBE> ListaCombo(int IdCompany)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                return Employee.ListaCombo(IdCompany);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmployeeBE Selecciona(int IdEmpresa, int IdArea, int IdEmployee)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                EmployeeBE objEmp = Employee.Selecciona(IdEmpresa, IdArea, IdEmployee);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmployeeBE SeleccionaDescripcion(int IdEmpresa, int IdArea, string DescEmployee)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                EmployeeBE objEmp = Employee.SeleccionaDescripcion(IdEmpresa, IdArea, DescEmployee);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmployeeBE SeleccionaNumeroDocumento(string Dni)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                EmployeeBE objEmp = Employee.SeleccionaNumeroDocumento(Dni);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmployeeBE> SeleccionaBusqueda(int IdEmpresa, int IdSituacion, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                return Employee.SeleccionaBusqueda(IdEmpresa, IdSituacion, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdSituacion, string pFiltro)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                return Employee.SeleccionaBusquedaCount(IdEmpresa, IdSituacion, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EmployeeBE pItem)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                Employee.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMasivo(List<EmployeeBE> pListaEmployee)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EmployeeDL objEmployee = new EmployeeDL();

                    foreach (EmployeeBE item in pListaEmployee)
                    {
                        objEmployee.InsertaMasivo(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(EmployeeBE pItem)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                Employee.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EmployeeBE pItem)
        {
            try
            {
                EmployeeDL Employee = new EmployeeDL();
                Employee.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
