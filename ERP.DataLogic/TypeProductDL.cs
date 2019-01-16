using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TypeProductDL
    {
        public TypeProductDL() { }

        public void Inserta(TypeProductBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_Inserta");

            db.AddInParameter(dbCommand, "pIdTypeProduct", DbType.Int32, pItem.IdTypeProduct);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeProduct", DbType.String, pItem.NameTypeProduct);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TypeProductBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_Actualiza");

            db.AddInParameter(dbCommand, "pIdTypeProduct", DbType.Int32, pItem.IdTypeProduct);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeProduct", DbType.String, pItem.NameTypeProduct);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TypeProductBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_Elimina");

            db.AddInParameter(dbCommand, "pIdTypeProduct", DbType.Int32, pItem.IdTypeProduct);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TypeProductBE Selecciona(int IdTypeProduct)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_Selecciona");
            db.AddInParameter(dbCommand, "pidTypeProduct", DbType.Int32, IdTypeProduct);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeProductBE TypeProduct = null;
            while (reader.Read())
            {
                TypeProduct = new TypeProductBE();
                TypeProduct.IdTypeProduct = Int32.Parse(reader["idTypeProduct"].ToString());
                TypeProduct.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeProduct.NameTypeProduct = reader["NameTypeProduct"].ToString();
                TypeProduct.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeProduct;
        }

        public TypeProductBE SeleccionaDescripcion(int IdCompany, string NameTypeProduct)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeProduct", DbType.String, NameTypeProduct);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeProductBE TypeProduct = null;
            while (reader.Read())
            {
                TypeProduct = new TypeProductBE();
                TypeProduct.IdTypeProduct = Int32.Parse(reader["idTypeProduct"].ToString());
                TypeProduct.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeProduct.NameTypeProduct = reader["NameTypeProduct"].ToString();
                TypeProduct.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeProduct;
        }

        public List<TypeProductBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeProduct_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TypeProductBE> TypeProductlist = new List<TypeProductBE>();
            TypeProductBE TypeProduct;
            while (reader.Read())
            {
                TypeProduct = new TypeProductBE();
                TypeProduct.IdTypeProduct = Int32.Parse(reader["idTypeProduct"].ToString());
                TypeProduct.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeProduct.NameTypeProduct = reader["NameTypeProduct"].ToString();
                TypeProduct.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                TypeProductlist.Add(TypeProduct);
            }
            reader.Close();
            reader.Dispose();
            return TypeProductlist;
        }
    }
}
