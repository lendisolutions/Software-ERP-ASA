using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TypeDL
    {
        public TypeDL() { }

        public void Inserta(TypeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_Inserta");

            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameType", DbType.String, pItem.NameType);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TypeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_Actualiza");

            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pAbbreviate", DbType.String, pItem.Abbreviate);
            db.AddInParameter(dbCommand, "pNameType", DbType.String, pItem.NameType);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TypeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_Elimina");

            db.AddInParameter(dbCommand, "pIdType", DbType.Int32, pItem.IdType);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TypeBE Selecciona(int IdType)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_Selecciona");
            db.AddInParameter(dbCommand, "pidType", DbType.Int32, IdType);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeBE Type = null;
            while (reader.Read())
            {
                Type = new TypeBE();
                Type.IdType = Int32.Parse(reader["idType"].ToString());
                Type.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Type.Abbreviate = reader["Abbreviate"].ToString();
                Type.NameType = reader["NameType"].ToString();
                Type.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Type;
        }

        public TypeBE SeleccionaDescripcion(int IdCompany, string NameType)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameType", DbType.String, NameType);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeBE Type = null;
            while (reader.Read())
            {
                Type = new TypeBE();
                Type.IdType = Int32.Parse(reader["idType"].ToString());
                Type.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Type.Abbreviate = reader["Abbreviate"].ToString();
                Type.NameType = reader["NameType"].ToString();
                Type.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Type;
        }

        public List<TypeBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Type_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TypeBE> Typelist = new List<TypeBE>();
            TypeBE Type;
            while (reader.Read())
            {
                Type = new TypeBE();
                Type.IdType = Int32.Parse(reader["idType"].ToString());
                Type.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Type.Abbreviate = reader["Abbreviate"].ToString();
                Type.NameType = reader["NameType"].ToString();
                Type.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Typelist.Add(Type);
            }
            reader.Close();
            reader.Dispose();
            return Typelist;
        }
    }
}
