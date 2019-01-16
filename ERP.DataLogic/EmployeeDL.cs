using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class EmployeeDL
    {
        public EmployeeDL() { }

        public void Inserta(EmployeeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_Inserta");

            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pDocumentNumber", DbType.String, pItem.DocumentNumber);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pLastName", DbType.String, pItem.LastName);
            db.AddInParameter(dbCommand, "pFullName", DbType.String, pItem.FullName);
            db.AddInParameter(dbCommand, "pIdGender", DbType.Int32, pItem.IdGender);
            db.AddInParameter(dbCommand, "pIdCivilStatus", DbType.Int32, pItem.IdCivilStatus);
            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pEssalud", DbType.String, pItem.Essalud);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagSctr", DbType.Boolean, pItem.FlagSctr);
            db.AddInParameter(dbCommand, "pLicense", DbType.String, pItem.License);
            db.AddInParameter(dbCommand, "pBithDate", DbType.DateTime, pItem.BithDate);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pCelPhone1", DbType.String, pItem.CelPhone1);
            db.AddInParameter(dbCommand, "pCelPhone2", DbType.String, pItem.CelPhone2);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pPhoto", DbType.Binary, pItem.Photo);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, pItem.IdSituation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void InsertaMasivo(EmployeeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_InsertaMasivo");

            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pDocumentNumber", DbType.String, pItem.DocumentNumber);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pLastName", DbType.String, pItem.LastName);
            db.AddInParameter(dbCommand, "pFullName", DbType.String, pItem.FullName);
            db.AddInParameter(dbCommand, "pIdGender", DbType.Int32, pItem.IdGender);
            db.AddInParameter(dbCommand, "pIdCivilStatus", DbType.Int32, pItem.IdCivilStatus);
            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pEssalud", DbType.String, pItem.Essalud);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagSctr", DbType.Boolean, pItem.FlagSctr);
            db.AddInParameter(dbCommand, "pLicense", DbType.String, pItem.License);
            db.AddInParameter(dbCommand, "pBithDate", DbType.DateTime, pItem.BithDate);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pCelPhone1", DbType.String, pItem.CelPhone1);
            db.AddInParameter(dbCommand, "pCelPhone2", DbType.String, pItem.CelPhone2);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, pItem.IdSituation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(EmployeeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_Actualiza");

            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, pItem.IdWorkArea);
            db.AddInParameter(dbCommand, "pDocumentNumber", DbType.String, pItem.DocumentNumber);
            db.AddInParameter(dbCommand, "pName", DbType.String, pItem.Name);
            db.AddInParameter(dbCommand, "pLastName", DbType.String, pItem.LastName);
            db.AddInParameter(dbCommand, "pFullName", DbType.String, pItem.FullName);
            db.AddInParameter(dbCommand, "pIdGender", DbType.Int32, pItem.IdGender);
            db.AddInParameter(dbCommand, "pIdCivilStatus", DbType.Int32, pItem.IdCivilStatus);
            db.AddInParameter(dbCommand, "pIdOccupation", DbType.Int32, pItem.IdOccupation);
            db.AddInParameter(dbCommand, "pEssalud", DbType.String, pItem.Essalud);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagSctr", DbType.Boolean, pItem.FlagSctr);
            db.AddInParameter(dbCommand, "pLicense", DbType.String, pItem.License);
            db.AddInParameter(dbCommand, "pBithDate", DbType.DateTime, pItem.BithDate);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pAddress", DbType.String, pItem.Address);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pCelPhone1", DbType.String, pItem.CelPhone1);
            db.AddInParameter(dbCommand, "pCelPhone2", DbType.String, pItem.CelPhone2);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pPhoto", DbType.Binary, pItem.Photo);
            db.AddInParameter(dbCommand, "pComment", DbType.String, pItem.Comment);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, pItem.IdSituation);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(EmployeeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_Elimina");

            db.AddInParameter(dbCommand, "pIdEmployee", DbType.Int32, pItem.IdEmployee);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

        }

        public EmployeeBE Selecciona(int IdCompany, int IdWorkArea, int IdEmployee)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_Selecciona");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, IdWorkArea);
            db.AddInParameter(dbCommand, "pidEmployee", DbType.Int32, IdEmployee);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmployeeBE Employee = null;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Employee.IdWorkArea = Int32.Parse(reader["IdWorkArea"].ToString());
                Employee.NameWorkArea = reader["NameWorkArea"].ToString();
                Employee.DocumentNumber = reader["DocumentNumber"].ToString();
                Employee.Name = reader["Name"].ToString();
                Employee.LastName = reader["LastName"].ToString();
                Employee.FullName = reader["FullName"].ToString();
                Employee.IdGender = Int32.Parse(reader["IdGender"].ToString());
                Employee.NameGender = reader["NameGender"].ToString();
                Employee.IdOccupation = Int32.Parse(reader["IdOccupation"].ToString());
                Employee.NameOccupation = reader["NameOccupation"].ToString();
                Employee.Essalud = reader["Essalud"].ToString();
                Employee.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Employee.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Employee.License = reader["License"].ToString();
                Employee.IdCivilStatus = Int32.Parse(reader["IdCivilStatus"].ToString());
                Employee.NameStateCivil = reader["NameStateCivil"].ToString();
                Employee.BithDate = DateTime.Parse(reader["BithDate"].ToString());
                Employee.IdUbigeo = reader["IdUbigeo"].ToString();
                Employee.NomDpto = reader["NomDpto"].ToString();
                Employee.NomProv = reader["NomProv"].ToString();
                Employee.NomDist = reader["NomDist"].ToString();
                Employee.Address = reader["Address"].ToString();
                Employee.Phone = reader["Phone"].ToString();
                Employee.CelPhone1 = reader["CelPhone1"].ToString();
                Employee.CelPhone2 = reader["CelPhone2"].ToString();
                Employee.Email = reader["Email"].ToString();
                Employee.Photo = (byte[])reader["Photo"];
                Employee.Comment = reader["Comment"].ToString();
                Employee.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                Employee.NameSituation = reader["NameSituation"].ToString();
                Employee.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Employee;
        }

        public EmployeeBE SeleccionaDescripcion(int IdCompany, int IdWorkArea, string DescEmployee)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, IdWorkArea);
            db.AddInParameter(dbCommand, "pDescEmployee", DbType.String, DescEmployee);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmployeeBE Employee = null;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Employee.IdWorkArea = Int32.Parse(reader["IdWorkArea"].ToString());
                Employee.NameWorkArea = reader["NameWorkArea"].ToString();
                Employee.DocumentNumber = reader["DocumentNumber"].ToString();
                Employee.Name = reader["Name"].ToString();
                Employee.LastName = reader["LastName"].ToString();
                Employee.FullName = reader["FullName"].ToString();
                Employee.IdGender = Int32.Parse(reader["IdGender"].ToString());
                Employee.NameGender = reader["NameGender"].ToString();
                Employee.IdOccupation = Int32.Parse(reader["IdOccupation"].ToString());
                Employee.NameOccupation = reader["NameOccupation"].ToString();
                Employee.Essalud = reader["Essalud"].ToString();
                Employee.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Employee.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Employee.License = reader["License"].ToString();
                Employee.IdCivilStatus = Int32.Parse(reader["IdCivilStatus"].ToString());
                Employee.NameStateCivil = reader["NameStateCivil"].ToString();
                Employee.BithDate = DateTime.Parse(reader["BithDate"].ToString());
                Employee.IdUbigeo = reader["IdUbigeo"].ToString();
                Employee.NomDpto = reader["NomDpto"].ToString();
                Employee.NomProv = reader["NomProv"].ToString();
                Employee.NomDist = reader["NomDist"].ToString();
                Employee.Address = reader["Address"].ToString();
                Employee.Phone = reader["Phone"].ToString();
                Employee.CelPhone1 = reader["CelPhone1"].ToString();
                Employee.CelPhone2 = reader["CelPhone2"].ToString();
                Employee.Email = reader["Email"].ToString();
                Employee.Photo = (byte[])reader["Photo"];
                Employee.Comment = reader["Comment"].ToString();
                Employee.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                Employee.NameSituation = reader["NameSituation"].ToString();
                Employee.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Employee;
        }

        public List<EmployeeBE> ListaTodosActivo(int IdCompany, int IdWorkArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdWorkArea", DbType.Int32, IdWorkArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmployeeBE> Employeelist = new List<EmployeeBE>();
            EmployeeBE Employee;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Employee.IdWorkArea = Int32.Parse(reader["IdWorkArea"].ToString());
                Employee.NameWorkArea = reader["NameWorkArea"].ToString();
                Employee.DocumentNumber = reader["DocumentNumber"].ToString();
                Employee.Name = reader["Name"].ToString();
                Employee.LastName = reader["LastName"].ToString();
                Employee.FullName = reader["FullName"].ToString();
                Employee.IdGender = Int32.Parse(reader["IdGender"].ToString());
                Employee.NameGender = reader["NameGender"].ToString();
                Employee.IdOccupation = Int32.Parse(reader["IdOccupation"].ToString());
                Employee.NameOccupation = reader["NameOccupation"].ToString();
                Employee.Essalud = reader["Essalud"].ToString();
                Employee.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Employee.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Employee.License = reader["License"].ToString();
                Employee.IdCivilStatus = Int32.Parse(reader["IdCivilStatus"].ToString());
                Employee.NameStateCivil = reader["NameStateCivil"].ToString();
                Employee.BithDate = DateTime.Parse(reader["BithDate"].ToString());
                Employee.IdUbigeo = reader["IdUbigeo"].ToString();
                Employee.NomDpto = reader["NomDpto"].ToString();
                Employee.NomProv = reader["NomProv"].ToString();
                Employee.NomDist = reader["NomDist"].ToString();
                Employee.Address = reader["Address"].ToString();
                Employee.Phone = reader["Phone"].ToString();
                Employee.CelPhone1 = reader["CelPhone1"].ToString();
                Employee.CelPhone2 = reader["CelPhone2"].ToString();
                Employee.Email = reader["Email"].ToString();
                //Employee.Photo = (byte[])reader["Photo"];
                Employee.Comment = reader["Comment"].ToString();
                Employee.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                Employee.NameSituation = reader["NameSituation"].ToString();
                Employee.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Employeelist.Add(Employee);
            }
            reader.Close();
            reader.Dispose();
            return Employeelist;
        }

        public List<EmployeeBE> SeleccionaBusqueda(int IdCompany, int IdSituation, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, IdSituation);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmployeeBE> Employeelist = new List<EmployeeBE>();
            EmployeeBE Employee;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Employee.NameCompany = reader["NameCompany"].ToString();
                Employee.IdWorkArea = Int32.Parse(reader["IdWorkArea"].ToString());
                Employee.NameWorkArea = reader["NameWorkArea"].ToString();
                Employee.DocumentNumber = reader["DocumentNumber"].ToString();
                Employee.FullName = reader["FullName"].ToString();
                Employee.NameOccupation = reader["NameOccupation"].ToString();
                Employee.IdUbigeo = reader["IdUbigeo"].ToString();
                Employee.NomDpto = reader["NomDpto"].ToString();
                Employee.NomProv = reader["NomProv"].ToString();
                Employee.NomDist = reader["NomDist"].ToString();
                Employee.Email = reader["Email"].ToString();
                Employee.NameSituation = reader["NameSituation"].ToString();
                Employeelist.Add(Employee);
            }
            reader.Close();
            reader.Dispose();
            return Employeelist;
        }

        public int SeleccionaBusquedaCount(int IdCompany, int IdSituation, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdSituation", DbType.Int32, IdSituation);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public EmployeeBE SeleccionaNumeroDocumento(string DocumentNumber)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pDocumentNumber", DbType.String, DocumentNumber);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmployeeBE Employee = null;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Employee.IdWorkArea = Int32.Parse(reader["IdWorkArea"].ToString());
                Employee.NameWorkArea = reader["NameWorkArea"].ToString();
                Employee.DocumentNumber = reader["DocumentNumber"].ToString();
                Employee.Name = reader["Name"].ToString();
                Employee.LastName = reader["LastName"].ToString();
                Employee.FullName = reader["FullName"].ToString();
                Employee.IdGender = Int32.Parse(reader["IdGender"].ToString());
                Employee.NameGender = reader["NameGender"].ToString();
                Employee.IdOccupation = Int32.Parse(reader["IdOccupation"].ToString());
                Employee.NameOccupation = reader["NameOccupation"].ToString();
                Employee.Essalud = reader["Essalud"].ToString();
                Employee.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Employee.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Employee.License = reader["License"].ToString();
                Employee.IdCivilStatus = Int32.Parse(reader["IdCivilStatus"].ToString());
                Employee.NameStateCivil = reader["NameStateCivil"].ToString();
                Employee.BithDate = DateTime.Parse(reader["BithDate"].ToString());
                Employee.IdUbigeo = reader["IdUbigeo"].ToString();
                Employee.NomDpto = reader["NomDpto"].ToString();
                Employee.NomProv = reader["NomProv"].ToString();
                Employee.NomDist = reader["NomDist"].ToString();
                Employee.Address = reader["Address"].ToString();
                Employee.Phone = reader["Phone"].ToString();
                Employee.CelPhone1 = reader["CelPhone1"].ToString();
                Employee.CelPhone2 = reader["CelPhone2"].ToString();
                Employee.Email = reader["Email"].ToString();
                Employee.Photo = (byte[])reader["Photo"];
                Employee.Comment = reader["Comment"].ToString();
                Employee.IdSituation = Int32.Parse(reader["IdSituation"].ToString());
                Employee.NameSituation = reader["NameSituation"].ToString();
                Employee.FlagState = Boolean.Parse(reader["FlagState"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Employee;
        }

        public List<EmployeeBE> ListaCargo(string Cargo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_ListaCargo");
            db.AddInParameter(dbCommand, "pCargo", DbType.String, Cargo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmployeeBE> Employeelist = new List<EmployeeBE>();
            EmployeeBE Employee;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.FullName = reader["FullName"].ToString();
                Employeelist.Add(Employee);
            }
            reader.Close();
            reader.Dispose();
            return Employeelist;
        }

        public List<EmployeeBE> ListaCombo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Employee_ListaCombo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmployeeBE> Employeelist = new List<EmployeeBE>();
            EmployeeBE Employee;
            while (reader.Read())
            {
                Employee = new EmployeeBE();
                Employee.IdEmployee = Int32.Parse(reader["idEmployee"].ToString());
                Employee.FullName = reader["FullName"].ToString();
                Employeelist.Add(Employee);
            }
            reader.Close();
            reader.Dispose();
            return Employeelist;
        }
    }
}
