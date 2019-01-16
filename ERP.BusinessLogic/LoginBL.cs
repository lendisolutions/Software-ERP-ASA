using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;


namespace ERP.BusinessLogic
{
    public class LoginBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<LoginBE> SeleccionaEmpresa(int IdCompany, string Descripcion)
        {
            try
            {
                LoginDL Login = new LoginDL();
                return Login.SeleccionaEmpresa(IdCompany, Descripcion);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<LoginBE> ListaTodosActivo()
        {
            try
            {
                LoginDL Login = new LoginDL();
                return Login.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public LoginBE Selecciona(int idLogin)
        {
            try
            {
                LoginDL Login = new LoginDL();
                return Login.Selecciona(idLogin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public LoginBE LogOnUser(string Login, string Password)
        {
            try
            {
                LoginDL objLogin = new LoginDL();
                LoginBE objUsuBE = objLogin.LogOnUser(Login, Password);
                return objUsuBE;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public LoginBE SeleccionaLogin(string Login)
        {
            try
            {
                LoginDL objLogin = new LoginDL();
                return objLogin.SeleccionaLogin(Login);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(LoginBE pItem, List<LoginAccessBE> pListaAcceso, List<LoginClientDepartmentBE> pListaClientDepartment)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    LoginDL objLogin = new LoginDL();
                    LoginAccessDL objLoginAccess = new LoginAccessDL();
                    LoginClientDepartmentDL objLoginClientDepartment = new LoginClientDepartmentDL();

                    Int32 intIdLogin = 0;

                    intIdLogin = objLogin.Inserta(pItem);
                    foreach (LoginAccessBE item in pListaAcceso)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdLogin = intIdLogin;
                            item.IdProfile = pItem.IdProfile;
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Elimina(item);
                        }

                    }

                    foreach (LoginClientDepartmentBE item in pListaClientDepartment)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdLogin = intIdLogin;
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Elimina(item);
                        }

                    }


                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(LoginBE pItem, List<LoginAccessBE> pListaAcceso, List<LoginClientDepartmentBE> pListaClientDepartment)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    LoginDL objLogin = new LoginDL();
                    LoginAccessDL objLoginAccess = new LoginAccessDL();
                    LoginClientDepartmentDL objLoginClientDepartment = new LoginClientDepartmentDL();

                    objLogin.Actualiza(pItem);
                    foreach (LoginAccessBE item in pListaAcceso)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdLogin = pItem.IdLogin;
                            item.IdProfile = pItem.IdProfile;
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginAccess.Elimina(item);
                        }

                    }

                    foreach (LoginClientDepartmentBE item in pListaClientDepartment)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdLogin = pItem.IdLogin;
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objLoginClientDepartment.Elimina(item);
                        }

                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(LoginBE pItem)
        {
            try
            {
                LoginDL Login = new LoginDL();
                Login.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
