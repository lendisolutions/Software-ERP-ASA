using System;
using System.Collections.Generic;
using System.Text;
using ERP.BusinessEntity;
using ERP.DataLogic;
using System.Data;
using System.Transactions;

namespace ERP.BusinessLogic
{
    public class ClientGoalBL
    {
        public List<ClientGoalBE> ListaTodosActivo(int Client)
        {
            try
            {
                ClientGoalDL ClientGoal = new ClientGoalDL();
                return ClientGoal.ListaTodosActivo(Client);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClientGoalBE Selecciona(int IdClientGoal)
        {
            try
            {
                ClientGoalDL ClientGoal = new ClientGoalDL();
                ClientGoalBE objEmp = ClientGoal.Selecciona(IdClientGoal);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ClientGoalBE pItem)
        {
            try
            {
                ClientGoalDL ClientGoal = new ClientGoalDL();
                ClientGoal.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClientGoalBE pItem)
        {
            try
            {
                ClientGoalDL ClientGoal = new ClientGoalDL();
                ClientGoal.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClientGoalBE pItem)
        {
            try
            {
                ClientGoalDL ClientGoal = new ClientGoalDL();
                ClientGoal.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
