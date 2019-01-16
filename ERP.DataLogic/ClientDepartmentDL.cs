using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ClientDepartmentDL
    {
        public ClientDepartmentDL() { }

        public void Inserta(ClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_Inserta");

            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pCode", DbType.String, pItem.Code);
            db.AddInParameter(dbCommand, "pNameDivision", DbType.String, pItem.NameDivision);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_Actualiza");

            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pCode", DbType.String, pItem.Code);
            db.AddInParameter(dbCommand, "pNameDivision", DbType.String, pItem.NameDivision);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClientDepartmentBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_Elimina");

            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClientDepartmentBE Selecciona(int IdClientDepartment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_Selecciona");
            db.AddInParameter(dbCommand, "pidClientDepartment", DbType.Int32, IdClientDepartment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientDepartmentBE ClientDepartment = null;
            while (reader.Read())
            {
                ClientDepartment = new ClientDepartmentBE();
                ClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDepartment.IdClientDepartment = Int32.Parse(reader["idClientDepartment"].ToString());
                ClientDepartment.Code = reader["Code"].ToString();
                ClientDepartment.NameDivision = reader["NameDivision"].ToString();
                ClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientDepartment;
        }

        public ClientDepartmentBE SeleccionaDescripcion(int IdClient, string NameDivision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pidClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNameDivision", DbType.String, NameDivision);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClientDepartmentBE ClientDepartment = null;
            while (reader.Read())
            {
                ClientDepartment = new ClientDepartmentBE();
                ClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDepartment.IdClientDepartment = Int32.Parse(reader["idClientDepartment"].ToString());
                ClientDepartment.Code = reader["Code"].ToString();
                ClientDepartment.NameDivision = reader["NameDivision"].ToString();
                ClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClientDepartment;
        }

        public List<ClientDepartmentBE> ListaTodosActivo(int IdClient)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientDepartmentBE> ClientDepartmentlist = new List<ClientDepartmentBE>();
            ClientDepartmentBE ClientDepartment;
            while (reader.Read())
            {
                ClientDepartment = new ClientDepartmentBE();
                ClientDepartment.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDepartment.IdClientDepartment = Int32.Parse(reader["idClientDepartment"].ToString());
                ClientDepartment.Code = reader["Code"].ToString();
                ClientDepartment.NameDivision = reader["NameDivision"].ToString();
                ClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientDepartment.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ClientDepartment.TipoOper = 4; //CONSULTAR
                ClientDepartmentlist.Add(ClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return ClientDepartmentlist;
        }

        public List<ClientDepartmentBE> ListaClient(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientDepartment_ListaClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClientDepartmentBE> ClientDepartmentlist = new List<ClientDepartmentBE>();
            ClientDepartmentBE ClientDepartment;
            while (reader.Read())
            {
                ClientDepartment = new ClientDepartmentBE();
                ClientDepartment.IdClient = Int32.Parse(reader["IdClient"].ToString());
                ClientDepartment.NameClient = reader["NameClient"].ToString();
                ClientDepartmentlist.Add(ClientDepartment);
            }
            reader.Close();
            reader.Dispose();
            return ClientDepartmentlist;
        }
    }
}
