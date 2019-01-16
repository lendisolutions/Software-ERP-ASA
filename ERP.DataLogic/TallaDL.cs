using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class TallaDL
    {
        public TallaDL() { }

        public void Inserta(TallaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_Inserta");

            db.AddInParameter(dbCommand, "pIdTalla", DbType.Int32, pItem.IdTalla);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTalla", DbType.String, pItem.NameTalla);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TallaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_Actualiza");

            db.AddInParameter(dbCommand, "pIdTalla", DbType.Int32, pItem.IdTalla);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameTalla", DbType.String, pItem.NameTalla);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TallaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_Elimina");

            db.AddInParameter(dbCommand, "pIdTalla", DbType.Int32, pItem.IdTalla);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public TallaBE Selecciona(int IdTalla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_Selecciona");
            db.AddInParameter(dbCommand, "pidTalla", DbType.Int32, IdTalla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TallaBE Talla = null;
            while (reader.Read())
            {
                Talla = new TallaBE();
                Talla.IdTalla = Int32.Parse(reader["idTalla"].ToString());
                Talla.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Talla.NameTalla = reader["NameTalla"].ToString();
                Talla.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Talla;
        }

        public TallaBE SeleccionaDescripcion(int IdCompany, string NameTalla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameTalla", DbType.String, NameTalla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TallaBE Talla = null;
            while (reader.Read())
            {
                Talla = new TallaBE();
                Talla.IdTalla = Int32.Parse(reader["idTalla"].ToString());
                Talla.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Talla.NameTalla = reader["NameTalla"].ToString();
                Talla.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Talla;
        }

        public List<TallaBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talla_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TallaBE> Tallalist = new List<TallaBE>();
            TallaBE Talla;
            while (reader.Read())
            {
                Talla = new TallaBE();
                Talla.IdTalla = Int32.Parse(reader["idTalla"].ToString());
                Talla.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Talla.NameTalla = reader["NameTalla"].ToString();
                Talla.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Tallalist.Add(Talla);
            }
            reader.Close();
            reader.Dispose();
            return Tallalist;
        }
    }
}
