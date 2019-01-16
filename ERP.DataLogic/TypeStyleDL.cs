using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TypeStyleDL
    {
        public TypeStyleDL() { }

        public void Inserta(TypeStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_Inserta");

            db.AddInParameter(dbCommand, "pIdTypeStyle", DbType.Int32, pItem.IdTypeStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeStyle", DbType.String, pItem.NameTypeStyle);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TypeStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_Actualiza");

            db.AddInParameter(dbCommand, "pIdTypeStyle", DbType.Int32, pItem.IdTypeStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeStyle", DbType.String, pItem.NameTypeStyle);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TypeStyleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_Elimina");

            db.AddInParameter(dbCommand, "pIdTypeStyle", DbType.Int32, pItem.IdTypeStyle);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TypeStyleBE Selecciona(int IdTypeStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_Selecciona");
            db.AddInParameter(dbCommand, "pidTypeStyle", DbType.Int32, IdTypeStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeStyleBE TypeStyle = null;
            while (reader.Read())
            {
                TypeStyle = new TypeStyleBE();
                TypeStyle.IdTypeStyle = Int32.Parse(reader["idTypeStyle"].ToString());
                TypeStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeStyle.NameTypeStyle = reader["NameTypeStyle"].ToString();
                TypeStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeStyle;
        }

        public TypeStyleBE SeleccionaDescripcion(int IdCompany, string NameTypeStyle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeStyle", DbType.String, NameTypeStyle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeStyleBE TypeStyle = null;
            while (reader.Read())
            {
                TypeStyle = new TypeStyleBE();
                TypeStyle.IdTypeStyle = Int32.Parse(reader["idTypeStyle"].ToString());
                TypeStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeStyle.NameTypeStyle = reader["NameTypeStyle"].ToString();
                TypeStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeStyle;
        }

        public List<TypeStyleBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeStyle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TypeStyleBE> TypeStylelist = new List<TypeStyleBE>();
            TypeStyleBE TypeStyle;
            while (reader.Read())
            {
                TypeStyle = new TypeStyleBE();
                TypeStyle.IdTypeStyle = Int32.Parse(reader["idTypeStyle"].ToString());
                TypeStyle.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeStyle.NameTypeStyle = reader["NameTypeStyle"].ToString();
                TypeStyle.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                TypeStylelist.Add(TypeStyle);
            }
            reader.Close();
            reader.Dispose();
            return TypeStylelist;
        }
    }
}
