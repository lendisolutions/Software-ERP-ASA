using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class UbigeoDL
    {
        public UbigeoDL() { }

        public List<UbigeoBE> SeleccionaDepartamento()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Departamentos");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDepartament = reader["IdDepartament"].ToString();
                Ubigeo.NomDpto = reader["NomDpto"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public List<UbigeoBE> SeleccionaProvincia(string IdDepartament)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Provincias");
            db.AddInParameter(dbCommand, "@pIdDepartament", DbType.String, IdDepartament);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdProvincie = reader["IdProvincie"].ToString();
                Ubigeo.NomProv = reader["NomProv"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public List<UbigeoBE> SeleccionaDistrito(string IdDepartament, string IdProvincie)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Distritos");
            db.AddInParameter(dbCommand, "@pIdDepartament", DbType.String, IdDepartament);
            db.AddInParameter(dbCommand, "@pIdProvincie", DbType.String, IdProvincie);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDistrict = reader["IdDistrict"].ToString();
                Ubigeo.NomDist = reader["NomDist"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public UbigeoBE SeleccionaDescripcion(string DescUbigeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Descripcion");
            db.AddInParameter(dbCommand, "@pDescUbigeo", DbType.String, DescUbigeo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UbigeoBE Ubigeo = null;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdUbigeo = reader["IdUbigeo"].ToString();

            }
            reader.Close();
            reader.Dispose();
            return Ubigeo;
        }

        public UbigeoBE SeleccionaDescripcionDistrito(string IdDepartament, string IdProvincie, string DescUbigeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_DescripcionDistrito");
            db.AddInParameter(dbCommand, "@pIdDepartament", DbType.String, IdDepartament);
            db.AddInParameter(dbCommand, "@pIdProvincie", DbType.String, IdProvincie);
            db.AddInParameter(dbCommand, "@pDescUbigeo", DbType.String, DescUbigeo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UbigeoBE Ubigeo = null;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDistrict = reader["IdDistrict"].ToString();
                Ubigeo.NomDist = reader["NomDist"].ToString();

            }
            reader.Close();
            reader.Dispose();
            return Ubigeo;
        }

        public List<UbigeoBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubigeo_Lista");
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdUbigeo = reader["IdUbigeo"].ToString();
                Ubigeo.NomDist = reader["NomDist"].ToString();
                Ubigeo.NomUbigeo = reader["NomUbigeo"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }
    }
}
