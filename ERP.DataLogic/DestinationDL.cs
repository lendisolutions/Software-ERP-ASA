using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class DestinationDL
    {
        public DestinationDL() { }

        public void Inserta(DestinationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_Inserta");

            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameDestination", DbType.String, pItem.NameDestination);
            db.AddInParameter(dbCommand, "pNumberLineCertificate", DbType.Int32, pItem.NumberLineCertificate);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(DestinationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_Actualiza");

            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNameDestination", DbType.String, pItem.NameDestination);
            db.AddInParameter(dbCommand, "pNumberLineCertificate", DbType.Int32, pItem.NumberLineCertificate);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(DestinationBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_Elimina");

            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public DestinationBE Selecciona(int IdDestination)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_Selecciona");
            db.AddInParameter(dbCommand, "pidDestination", DbType.Int32, IdDestination);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DestinationBE Destination = null;
            while (reader.Read())
            {
                Destination = new DestinationBE();
                Destination.IdDestination = Int32.Parse(reader["idDestination"].ToString());
                Destination.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Destination.NameDestination = reader["NameDestination"].ToString();
                Destination.NumberLineCertificate = Int32.Parse(reader["NumberLineCertificate"].ToString());
                Destination.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Destination;
        }

        public DestinationBE SeleccionaDescripcion(int IdCompany, string NameDestination)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNameDestination", DbType.String, NameDestination);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DestinationBE Destination = null;
            while (reader.Read())
            {
                Destination = new DestinationBE();
                Destination.IdDestination = Int32.Parse(reader["idDestination"].ToString());
                Destination.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Destination.NameDestination = reader["NameDestination"].ToString();
                Destination.NumberLineCertificate = Int32.Parse(reader["NumberLineCertificate"].ToString());
                Destination.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Destination;
        }

        public List<DestinationBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Destination_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DestinationBE> Destinationlist = new List<DestinationBE>();
            DestinationBE Destination;
            while (reader.Read())
            {
                Destination = new DestinationBE();
                Destination.IdDestination = Int32.Parse(reader["idDestination"].ToString());
                Destination.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Destination.NameDestination = reader["NameDestination"].ToString();
                Destination.NumberLineCertificate = Int32.Parse(reader["NumberLineCertificate"].ToString());
                Destination.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Destinationlist.Add(Destination);
            }
            reader.Close();
            reader.Dispose();
            return Destinationlist;
        }
    }
}
