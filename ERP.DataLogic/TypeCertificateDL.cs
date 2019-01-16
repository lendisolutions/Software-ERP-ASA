using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TypeCertificateDL
    {
        public TypeCertificateDL() { }

        public void Inserta(TypeCertificateBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_Inserta");

            db.AddInParameter(dbCommand, "pIdTypeCertificate", DbType.Int32, pItem.IdTypeCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeCertificate", DbType.String, pItem.NameTypeCertificate);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TypeCertificateBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_Actualiza");

            db.AddInParameter(dbCommand, "pIdTypeCertificate", DbType.Int32, pItem.IdTypeCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeCertificate", DbType.String, pItem.NameTypeCertificate);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TypeCertificateBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_Elimina");

            db.AddInParameter(dbCommand, "pIdTypeCertificate", DbType.Int32, pItem.IdTypeCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TypeCertificateBE Selecciona(int IdTypeCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_Selecciona");
            db.AddInParameter(dbCommand, "pidTypeCertificate", DbType.Int32, IdTypeCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeCertificateBE TypeCertificate = null;
            while (reader.Read())
            {
                TypeCertificate = new TypeCertificateBE();
                TypeCertificate.IdTypeCertificate = Int32.Parse(reader["idTypeCertificate"].ToString());
                TypeCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeCertificate.NameTypeCertificate = reader["NameTypeCertificate"].ToString();
                TypeCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeCertificate;
        }

        public TypeCertificateBE SeleccionaDescripcion(int IdCompany, string NameTypeCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameTypeCertificate", DbType.String, NameTypeCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TypeCertificateBE TypeCertificate = null;
            while (reader.Read())
            {
                TypeCertificate = new TypeCertificateBE();
                TypeCertificate.IdTypeCertificate = Int32.Parse(reader["idTypeCertificate"].ToString());
                TypeCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeCertificate.NameTypeCertificate = reader["NameTypeCertificate"].ToString();
                TypeCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TypeCertificate;
        }

        public List<TypeCertificateBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TypeCertificate_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TypeCertificateBE> TypeCertificatelist = new List<TypeCertificateBE>();
            TypeCertificateBE TypeCertificate;
            while (reader.Read())
            {
                TypeCertificate = new TypeCertificateBE();
                TypeCertificate.IdTypeCertificate = Int32.Parse(reader["idTypeCertificate"].ToString());
                TypeCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                TypeCertificate.NameTypeCertificate = reader["NameTypeCertificate"].ToString();
                TypeCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                TypeCertificatelist.Add(TypeCertificate);
            }
            reader.Close();
            reader.Dispose();
            return TypeCertificatelist;
        }
    }
}
