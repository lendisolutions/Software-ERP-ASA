using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ShipModeDL
    {
        public ShipModeDL() { }

        public void Inserta(ShipModeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_Inserta");

            db.AddInParameter(dbCommand, "pIdShipMode", DbType.Int32, pItem.IdShipMode);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameShipMode", DbType.String, pItem.NameShipMode);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ShipModeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_Actualiza");

            db.AddInParameter(dbCommand, "pIdShipMode", DbType.Int32, pItem.IdShipMode);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameShipMode", DbType.String, pItem.NameShipMode);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ShipModeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_Elimina");

            db.AddInParameter(dbCommand, "pIdShipMode", DbType.Int32, pItem.IdShipMode);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public ShipModeBE Selecciona(int IdShipMode)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_Selecciona");
            db.AddInParameter(dbCommand, "pidShipMode", DbType.Int32, IdShipMode);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ShipModeBE ShipMode = null;
            while (reader.Read())
            {
                ShipMode = new ShipModeBE();
                ShipMode.IdShipMode = Int32.Parse(reader["idShipMode"].ToString());
                ShipMode.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ShipMode.NameShipMode = reader["NameShipMode"].ToString();
                ShipMode.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ShipMode;
        }

        public ShipModeBE SeleccionaDescripcion(int IdCompany, string NameShipMode)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameShipMode", DbType.String, NameShipMode);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ShipModeBE ShipMode = null;
            while (reader.Read())
            {
                ShipMode = new ShipModeBE();
                ShipMode.IdShipMode = Int32.Parse(reader["idShipMode"].ToString());
                ShipMode.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ShipMode.NameShipMode = reader["NameShipMode"].ToString();
                ShipMode.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ShipMode;
        }

        public List<ShipModeBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ShipMode_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ShipModeBE> ShipModelist = new List<ShipModeBE>();
            ShipModeBE ShipMode;
            while (reader.Read())
            {
                ShipMode = new ShipModeBE();
                ShipMode.IdShipMode = Int32.Parse(reader["idShipMode"].ToString());
                ShipMode.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                ShipMode.NameShipMode = reader["NameShipMode"].ToString();
                ShipMode.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                ShipModelist.Add(ShipMode);
            }
            reader.Close();
            reader.Dispose();
            return ShipModelist;
        }
    }
}
