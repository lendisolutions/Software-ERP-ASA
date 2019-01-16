using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class ProfileDL
    {
        public ProfileDL() { }

        public Int32 Inserta(ProfileBE pItem)
        {
            Int32 intIdProfile = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Profile_Inserta");

            db.AddOutParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pNameProfile", DbType.String, pItem.NameProfile);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);

            intIdProfile = (int)db.GetParameterValue(dbCommand, "pIdProfile");

            return intIdProfile;
        }

        public void Actualiza(ProfileBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Profile_Actualiza");

            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pNameProfile", DbType.String, pItem.NameProfile);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProfileBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Profile_Elimina");

            db.AddInParameter(dbCommand, "pIdProfile", DbType.Int32, pItem.IdProfile);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProfileBE Selecciona(int idProfile)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Profile_Selecciona");
            db.AddInParameter(dbCommand, "pidProfile", DbType.Int32, idProfile);
            IDataReader reader = db.ExecuteReader(dbCommand);
            ProfileBE Profile = null;
            while (reader.Read())
            {
                Profile = new ProfileBE();
                Profile.IdProfile = Int32.Parse(reader["idProfile"].ToString());
                Profile.NameProfile = reader["NameProfile"].ToString();
                Profile.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Profile;
        }

        public List<ProfileBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Profile_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProfileBE> Profilelist = new List<ProfileBE>();
            ProfileBE Profile;
            while (reader.Read())
            {
                Profile = new ProfileBE();
                Profile.IdProfile = Int32.Parse(reader["idProfile"].ToString());
                Profile.NameProfile = reader["NameProfile"].ToString();
                Profile.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Profilelist.Add(Profile);
            }
            reader.Close();
            reader.Dispose();
            return Profilelist;
        }
    }
}
