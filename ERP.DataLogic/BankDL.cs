using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class BankDL
    {
        public BankDL() { }

        public void Inserta(BankBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_Inserta");

            db.AddInParameter(dbCommand, "pIdBank", DbType.Int32, pItem.IdBank);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pSwift", DbType.String, pItem.Swift);
            db.AddInParameter(dbCommand, "pNameBank", DbType.String, pItem.NameBank);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pNumberCtaCte", DbType.String, pItem.NumberCtaCte);
            db.AddInParameter(dbCommand, "pCodeAba", DbType.String, pItem.CodeAba);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pContac", DbType.String, pItem.Contac);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(BankBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_Actualiza");

            db.AddInParameter(dbCommand, "pIdBank", DbType.Int32, pItem.IdBank);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pSwift", DbType.String, pItem.Swift);
            db.AddInParameter(dbCommand, "pNameBank", DbType.String, pItem.NameBank);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pNumberCtaCte", DbType.String, pItem.NumberCtaCte);
            db.AddInParameter(dbCommand, "pCodeAba", DbType.String, pItem.CodeAba);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pContac", DbType.String, pItem.Contac);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(BankBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_Elimina");

            db.AddInParameter(dbCommand, "pIdBank", DbType.Int32, pItem.IdBank);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public BankBE Selecciona(int IdBank)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_Selecciona");
            db.AddInParameter(dbCommand, "pidBank", DbType.Int32, IdBank);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BankBE Bank = null;
            while (reader.Read())
            {
                Bank = new BankBE();
                Bank.IdBank = Int32.Parse(reader["idBank"].ToString());
                Bank.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Bank.Swift = reader["Swift"].ToString();
                Bank.NameBank = reader["NameBank"].ToString();
                Bank.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Bank.NameCurrency = reader["NameCurrency"].ToString();
                Bank.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Bank.CodeAba = reader["CodeAba"].ToString();
                Bank.Address = reader["Address"].ToString();
                Bank.Phone = reader["Phone"].ToString();
                Bank.Contac = reader["Contac"].ToString();
                Bank.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Bank;
        }

        public BankBE SeleccionaDescripcion(int IdCompany, string NameBank)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameBank", DbType.String, NameBank);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BankBE Bank = null;
            while (reader.Read())
            {
                Bank = new BankBE();
                Bank.IdBank = Int32.Parse(reader["idBank"].ToString());
                Bank.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Bank.Swift = reader["Swift"].ToString();
                Bank.NameBank = reader["NameBank"].ToString();
                Bank.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Bank.NameCurrency = reader["NameCurrency"].ToString();
                Bank.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Bank.CodeAba = reader["CodeAba"].ToString();
                Bank.Address = reader["Address"].ToString();
                Bank.Phone = reader["Phone"].ToString();
                Bank.Contac = reader["Contac"].ToString();
                Bank.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Bank;
        }

        public List<BankBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bank_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BankBE> Banklist = new List<BankBE>();
            BankBE Bank;
            while (reader.Read())
            {
                Bank = new BankBE();
                Bank.IdBank = Int32.Parse(reader["idBank"].ToString());
                Bank.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Bank.Swift = reader["Swift"].ToString();
                Bank.NameBank = reader["NameBank"].ToString();
                Bank.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Bank.NameCurrency = reader["NameCurrency"].ToString();
                Bank.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Bank.CodeAba = reader["CodeAba"].ToString();
                Bank.Address = reader["Address"].ToString();
                Bank.Phone = reader["Phone"].ToString();
                Bank.Contac = reader["Contac"].ToString();
                Bank.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Banklist.Add(Bank);
            }
            reader.Close();
            reader.Dispose();
            return Banklist;
        }
    }
}
