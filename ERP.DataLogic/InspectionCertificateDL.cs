using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class InspectionCertificateDL
    {
        public InspectionCertificateDL() { }

        public Int32 Inserta(InspectionCertificateBE pItem)
        {
            int intIdInspectionCertificate = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_Inserta");

            db.AddOutParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, pItem.NumberCertificate);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberOI", DbType.String, pItem.NumberOI);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pPaymentTerm", DbType.String, pItem.PaymentTerm);
            db.AddInParameter(dbCommand, "pCartons", DbType.Int32, pItem.Cartons);
            db.AddInParameter(dbCommand, "pIssueDate", DbType.DateTime, pItem.IssueDate);
            db.AddInParameter(dbCommand, "pIdRepresentative", DbType.Int32, pItem.IdRepresentative);
            db.AddInParameter(dbCommand, "pDescriptionStyle", DbType.String, pItem.DescriptionStyle);
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, pItem.NumberInvoice);
            db.AddInParameter(dbCommand, "pIssueDateInvoice", DbType.DateTime, pItem.IssueDateInvoice);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pAmount", DbType.Decimal, pItem.Amount);
            db.AddInParameter(dbCommand, "pEtdDate", DbType.DateTime, pItem.EtdDate);
            db.AddInParameter(dbCommand, "pIdTypeShipping", DbType.Int32, pItem.IdTypeShipping);
            db.AddInParameter(dbCommand, "pBoardingWay", DbType.String, pItem.BoardingWay);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdInspectionCertificate = (int)db.GetParameterValue(dbCommand, "pIdInspectionCertificate");

            return intIdInspectionCertificate;
        }

        public void Actualiza(InspectionCertificateBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_Actualiza");

            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, pItem.NumberCertificate);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, pItem.NumberPO);
            db.AddInParameter(dbCommand, "pNumberOI", DbType.String, pItem.NumberOI);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIdClientDepartment", DbType.Int32, pItem.IdClientDepartment);
            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, pItem.IdVendor);
            db.AddInParameter(dbCommand, "pPaymentTerm", DbType.String, pItem.PaymentTerm);
            db.AddInParameter(dbCommand, "pCartons", DbType.Int32, pItem.Cartons);
            db.AddInParameter(dbCommand, "pIssueDate", DbType.DateTime, pItem.IssueDate);
            db.AddInParameter(dbCommand, "pIdRepresentative", DbType.Int32, pItem.IdRepresentative);
            db.AddInParameter(dbCommand, "pDescriptionStyle", DbType.String, pItem.DescriptionStyle);
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, pItem.NumberInvoice);
            db.AddInParameter(dbCommand, "pIssueDateInvoice", DbType.DateTime, pItem.IssueDateInvoice);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pAmount", DbType.Decimal, pItem.Amount);
            db.AddInParameter(dbCommand, "pEtdDate", DbType.DateTime, pItem.EtdDate);
            db.AddInParameter(dbCommand, "pIdTypeShipping", DbType.Int32, pItem.IdTypeShipping);
            db.AddInParameter(dbCommand, "pBoardingWay", DbType.String, pItem.BoardingWay);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSituacion(int IdInspectionCertificate, int IdStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdInspectionCertificate, string NumberPP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pNumberPP", DbType.String, NumberPP);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InspectionCertificateBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_Elimina");

            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, pItem.IdInspectionCertificate);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public InspectionCertificateBE Selecciona(int IdInspectionCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_Selecciona");
            db.AddInParameter(dbCommand, "pIdInspectionCertificate", DbType.Int32, IdInspectionCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspectionCertificateBE InspectionCertificate = null;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificate;
        }

        public InspectionCertificateBE SeleccionaNumberInvoice(string NumberInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_SeleccionaNumberInvoice");
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, NumberInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspectionCertificateBE InspectionCertificate = null;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificate;
        }

        public int SeleccionaBusquedaCount(int IdCompany, int IdClient)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<InspectionCertificateBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaClient(int IdCompany, int IdClient, int IdStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaClientNumberPO(int IdCompany, int IdClient, string NumberPO)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaClientNumberPO");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberPO", DbType.String, NumberPO);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaClientNumberOI(int IdCompany, int IdClient, string NumberOI)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaClientNumberOI");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberOI", DbType.String, NumberOI);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaClientDate(int IdCompany, int IdClient, int IdStatus, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaClientDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaNumberCertificate(int IdCompany, int IdClient, string NumberCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaNumberCertificate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, NumberCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaVendorStatus(int IdCompany, int IdVendor, int IdStatus, int NumberIni, int NumberFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaVendorStatus");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdVendor", DbType.Int32, IdVendor);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);
            db.AddInParameter(dbCommand, "pNumberIni", DbType.Int32, NumberIni);
            db.AddInParameter(dbCommand, "pNumberFin", DbType.Int32, NumberFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                InspectionCertificate.NameCompany = reader["NameCompany"].ToString();
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.NumberPO = reader["NumberPO"].ToString();
                InspectionCertificate.NumberOI = reader["NumberOI"].ToString();
                InspectionCertificate.IdClient = Int32.Parse(reader["IdClient"].ToString());
                InspectionCertificate.NameClient = reader["NameClient"].ToString();
                InspectionCertificate.IdClientDepartment = Int32.Parse(reader["IdClientDepartment"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                InspectionCertificate.BrandCertificate = reader["BrandCertificate"].ToString();
                InspectionCertificate.IdVendor = Int32.Parse(reader["IdVendor"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.PaymentTerm = reader["PaymentTerm"].ToString();
                InspectionCertificate.Cartons = Int32.Parse(reader["Cartons"].ToString());
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.IdRepresentative = Int32.Parse(reader["IdRepresentative"].ToString());
                InspectionCertificate.NameRepresentative = reader["NameRepresentative"].ToString();
                InspectionCertificate.DescriptionStyle = reader["DescriptionStyle"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                InspectionCertificate.NameCurrency = reader["NameCurrency"].ToString();
                InspectionCertificate.Amount = Decimal.Parse(reader["Amount"].ToString());
                InspectionCertificate.EtdDate = DateTime.Parse(reader["EtdDate"].ToString());
                InspectionCertificate.IdTypeShipping = Int32.Parse(reader["IdTypeShipping"].ToString());
                InspectionCertificate.NameTypeShipping = reader["NameTypeShipping"].ToString();
                InspectionCertificate.BoardingWay = reader["BoardingWay"].ToString();
                InspectionCertificate.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                InspectionCertificate.NameStatus = reader["NameStatus"].ToString();
                InspectionCertificate.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }

        public List<InspectionCertificateBE> ListaInvoiceDetail(int IdCompany, string NumberCertificate)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspectionCertificate_ListaInvoiceDetail");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pNumberCertificate", DbType.String, NumberCertificate);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspectionCertificateBE> InspectionCertificatelist = new List<InspectionCertificateBE>();
            InspectionCertificateBE InspectionCertificate;
            while (reader.Read())
            {
                InspectionCertificate = new InspectionCertificateBE();
                InspectionCertificate.IdInspectionCertificate = Int32.Parse(reader["IdInspectionCertificate"].ToString());
                InspectionCertificate.NumberCertificate = reader["NumberCertificate"].ToString();
                InspectionCertificate.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                InspectionCertificate.NameVendor = reader["NameVendor"].ToString();
                InspectionCertificate.NumberInvoice = reader["NumberInvoice"].ToString();
                InspectionCertificate.IssueDateInvoice = DateTime.Parse(reader["IssueDateInvoice"].ToString());
                InspectionCertificate.NameDivision = reader["NameDivision"].ToString();
                InspectionCertificate.AmountCertificate = Decimal.Parse(reader["AmountCertificate"].ToString());
                InspectionCertificate.Comision = Decimal.Parse(reader["Comision"].ToString());
                InspectionCertificate.Pieces = Decimal.Parse(reader["Pieces"].ToString());
                InspectionCertificatelist.Add(InspectionCertificate);
            }
            reader.Close();
            reader.Dispose();
            return InspectionCertificatelist;
        }
    }
}
