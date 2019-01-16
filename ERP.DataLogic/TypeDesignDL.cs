using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TypeDesignDL
    {
        public TypeDesignDL() { }

        public void Inserta(TypeDesignBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_Inserta");

            db.AddInParameter(dbCommand, "pIdTypeDesign", DbType.Int32, pItem.IdTypeDesign);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeDesign", DbType.String, pItem.NameTypeDesign);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TypeDesignBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_Actualiza");

            db.AddInParameter(dbCommand, "pIdTypeDesign", DbType.Int32, pItem.IdTypeDesign);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeDesign", DbType.String, pItem.NameTypeDesign);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TypeDesignBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_Elimina");

            db.AddInParameter(dbCommand, "pIdTypeDesign", DbType.Int32, pItem.IdTypeDesign);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TypeDesignBE Selecciona(int IdTypeDesign)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_Selecciona");
            db.AddInParameter(dbCommand, "pidTypeDesign", DbType.Int32, IdTypeDesign);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeDesignBE TypeDesign = null;
            while (reader.Read())
            {
                TypeDesign = new TypeDesignBE();
                TypeDesign.IdTypeDesign = Int32.Parse(reader["idTypeDesign"].ToString());
                TypeDesign.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeDesign.NameTypeDesign = reader["NameTypeDesign"].ToString();
                TypeDesign.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeDesign;
        }

        public TypeDesignBE SeleccionaDescripcion(int IdCompany, string NameTypeDesign)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeDesign", DbType.String, NameTypeDesign);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeDesignBE TypeDesign = null;
            while (reader.Read())
            {
                TypeDesign = new TypeDesignBE();
                TypeDesign.IdTypeDesign = Int32.Parse(reader["idTypeDesign"].ToString());
                TypeDesign.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeDesign.NameTypeDesign = reader["NameTypeDesign"].ToString();
                TypeDesign.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeDesign;
        }

        public List<TypeDesignBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeDesign_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TypeDesignBE> TypeDesignlist = new List<TypeDesignBE>();
            TypeDesignBE TypeDesign;
            while (reader.Read())
            {
                TypeDesign = new TypeDesignBE();
                TypeDesign.IdTypeDesign = Int32.Parse(reader["idTypeDesign"].ToString());
                TypeDesign.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeDesign.NameTypeDesign = reader["NameTypeDesign"].ToString();
                TypeDesign.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                TypeDesignlist.Add(TypeDesign);
            }
            reader.Close();
            reader.Dispose();
            return TypeDesignlist;
        }
    }
}
