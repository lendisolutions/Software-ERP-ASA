using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientGoalDL
    {
        public ClientGoalDL() { }

        public void Inserta(ClientGoalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientGoal_Inserta");

            db.AddInParameter(dbCommand, "pIdClientGoal", DbType.Int32, pItem.IdClientGoal);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pYear", DbType.Int32, pItem.Year);
            db.AddInParameter(dbCommand, "pMonth", DbType.Int32, pItem.Month);
            db.AddInParameter(dbCommand, "pGoal", DbType.Decimal, pItem.Goal);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientGoalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientGoal_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientGoal", DbType.Int32, pItem.IdClientGoal);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pYear", DbType.Int32, pItem.Year);
            db.AddInParameter(dbCommand, "pMonth", DbType.Int32, pItem.Month);
            db.AddInParameter(dbCommand, "pGoal", DbType.Decimal, pItem.Goal);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientGoalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientGoal_Elimina");

            db.AddInParameter(dbCommand, "pIdClientGoal", DbType.Int32, pItem.IdClientGoal);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientGoalBE Selecciona(int IdClientGoal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientGoal_Selecciona");
            db.AddInParameter(dbCommand, "pidClientGoal", DbType.Int32, IdClientGoal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientGoalBE ClientGoal = null;
            while (reader.Read())
            {
                ClientGoal = new ClientGoalBE();
                ClientGoal.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientGoal.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientGoal.IdClientGoal = Int32.Parse(reader["idClientGoal"].ToString());
                ClientGoal.Year = Int32.Parse(reader["Year"].ToString());
                ClientGoal.Month = Int32.Parse(reader["Month"].ToString());
                ClientGoal.Goal = Decimal.Parse(reader["Goal"].ToString());
                ClientGoal.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientGoal;
        }

        public List<ClientGoalBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientGoal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientGoalBE> ClientGoallist = new List<ClientGoalBE>();
            ClientGoalBE ClientGoal;
            while (reader.Read())
            {
                ClientGoal = new ClientGoalBE();
                ClientGoal.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientGoal.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientGoal.IdClientGoal = Int32.Parse(reader["idClientGoal"].ToString());
                ClientGoal.Year = Int32.Parse(reader["Year"].ToString());
                ClientGoal.Month = Int32.Parse(reader["Month"].ToString());
                ClientGoal.Goal = Decimal.Parse(reader["Goal"].ToString());
                ClientGoal.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientGoal.TipoOper = 4; //CONSULTAR
                ClientGoallist.Add(ClientGoal);
            }
            reader.Close();
            reader.Dispose();
            return ClientGoallist;
        }
    }
}
