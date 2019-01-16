using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ProfileBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProfileBE> ListaTodosActivo()
        {
            try
            {
                ProfileDL Profile = new ProfileDL();
                return Profile.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public ProfileBE Selecciona(int idProfile)
        {
            try
            {
                ProfileDL Profile = new ProfileDL();
                return Profile.Selecciona(idProfile);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProfileBE pItem, List<AccessBE> pListaAccess)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProfileDL objProfile = new ProfileDL();
                    AccessDL objAccess = new AccessDL();
                    Int32 intIdProfile = 0;

                    intIdProfile = objProfile.Inserta(pItem);
                    foreach (AccessBE item in pListaAccess)
                    {
                        if (item.TipOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdProfile = intIdProfile;
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objAccess.Inserta(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objAccess.Actualiza(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objAccess.Elimina(item);
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


        public void Actualiza(ProfileBE pItem, List<AccessBE> pListaAccess)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProfileDL objProfile = new ProfileDL();
                    AccessDL objAccess = new AccessDL();

                    objProfile.Actualiza(pItem);
                    foreach (AccessBE item in pListaAccess)
                    {
                        if (item.TipOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            item.IdProfile = pItem.IdProfile;
                            objAccess.Inserta(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objAccess.Actualiza(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Login = pItem.Login;
                            item.Machine = pItem.Machine;
                            item.IdCompany = pItem.IdCompany;
                            objAccess.Elimina(item);
                        }

                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }

        }

        public void Elimina(ProfileBE pItem)
        {
            try
            {
                ProfileDL Profile = new ProfileDL();
                Profile.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
