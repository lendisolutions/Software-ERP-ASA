using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class CommimentDetailDL
    {
        public CommimentDetailDL() { }

        public void Inserta(CommimentDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CommimentDetail_Inserta");

            db.AddInParameter(dbCommand, "pIdCommimentDetail", DbType.Int32, pItem.IdCommimentDetail);
            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, pItem.IdCommiment);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pQuantity", DbType.Decimal, pItem.Quantity);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CommimentDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CommimentDetail_Actualiza");

            db.AddInParameter(dbCommand, "pIdCommimentDetail", DbType.Int32, pItem.IdCommimentDetail);
            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, pItem.IdCommiment);
            db.AddInParameter(dbCommand, "pIdStyle", DbType.Int32, pItem.IdStyle);
            db.AddInParameter(dbCommand, "pQuantity", DbType.Decimal, pItem.Quantity);
            db.AddInParameter(dbCommand, "pFob", DbType.Decimal, pItem.Fob);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CommimentDetailBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CommimentDetail_Elimina");

            db.AddInParameter(dbCommand, "pIdCommimentDetail", DbType.Int32, pItem.IdCommimentDetail);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public CommimentDetailBE Selecciona(int IdCommimentDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CommimentDetail_Selecciona");
            db.AddInParameter(dbCommand, "pidCommimentDetail", DbType.Int32, IdCommimentDetail);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CommimentDetailBE CommimentDetail = null;
            while (reader.Read())
            {
                CommimentDetail = new CommimentDetailBE();
                CommimentDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                CommimentDetail.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                CommimentDetail.IdCommimentDetail = Int32.Parse(reader["idCommimentDetail"].ToString());
                CommimentDetail.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                CommimentDetail.NameStyle = reader["NameStyle"].ToString();
                CommimentDetail.Description = reader["Description"].ToString();
                CommimentDetail.Quantity = Decimal.Parse(reader["Quantity"].ToString());
                CommimentDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                CommimentDetail.Total = Decimal.Parse(reader["Total"].ToString());
                CommimentDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CommimentDetail;
        }

        public List<CommimentDetailBE> ListaTodosActivo(int IdCommiment)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CommimentDetail_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCommiment", DbType.Int32, IdCommiment);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CommimentDetailBE> CommimentDetaillist = new List<CommimentDetailBE>();
            CommimentDetailBE CommimentDetail;
            while (reader.Read())
            {
                CommimentDetail = new CommimentDetailBE();
                CommimentDetail.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                CommimentDetail.IdCommiment = Int32.Parse(reader["IdCommiment"].ToString());
                CommimentDetail.IdCommimentDetail = Int32.Parse(reader["idCommimentDetail"].ToString());
                CommimentDetail.IdStyle = Int32.Parse(reader["IdStyle"].ToString());
                CommimentDetail.NameStyle = reader["NameStyle"].ToString();
                CommimentDetail.Description = reader["Description"].ToString();
                CommimentDetail.Quantity = Decimal.Parse(reader["Quantity"].ToString());
                CommimentDetail.Fob = Decimal.Parse(reader["Fob"].ToString());
                CommimentDetail.Total = Decimal.Parse(reader["Total"].ToString());
                CommimentDetail.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                CommimentDetail.TipoOper = 4; //CONSULTAR
                CommimentDetaillist.Add(CommimentDetail);
            }
            reader.Close();
            reader.Dispose();
            return CommimentDetaillist;
        }
    }
}
