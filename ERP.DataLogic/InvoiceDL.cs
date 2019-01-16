using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class InvoiceDL
    {
        public InvoiceDL() { }

        public Int32 Inserta(InvoiceBE pItem)
        {
            int intIdInvoice = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_Inserta");

            db.AddOutParameter(dbCommand, "pIdInvoice", DbType.Int32, pItem.IdInvoice);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, pItem.NumberInvoice);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIssueDate", DbType.DateTime, pItem.IssueDate);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pPercentComision", DbType.Decimal, pItem.PercentComision);
            db.AddInParameter(dbCommand, "pAddressClient", DbType.String, pItem.AddressClient);
            db.AddInParameter(dbCommand, "pContac", DbType.String, pItem.Contac);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pNoteGeneral", DbType.String, pItem.NoteGeneral);
            db.AddInParameter(dbCommand, "pIdBank", DbType.Int32, pItem.IdBank);
            db.AddInParameter(dbCommand, "pNameBank", DbType.String, pItem.NameBank);
            db.AddInParameter(dbCommand, "pNumberCtaCte", DbType.String, pItem.NumberCtaCte);
            db.AddInParameter(dbCommand, "pSwift", DbType.String, pItem.Swift);
            db.AddInParameter(dbCommand, "pCodeAba", DbType.String, pItem.CodeAba);
            db.AddInParameter(dbCommand, "pAddressBank", DbType.String, pItem.AddressBank);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pRepresentative", DbType.String, pItem.Representative);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pTotalAmount", DbType.Decimal, pItem.TotalAmount);
            db.AddInParameter(dbCommand, "pTotalComision", DbType.Decimal, pItem.TotalComision);
            db.AddInParameter(dbCommand, "pTotalPieces", DbType.Decimal, pItem.TotalPieces);
            db.AddInParameter(dbCommand, "pComisionLetter", DbType.String, pItem.ComisionLetter);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);

            intIdInvoice = (int)db.GetParameterValue(dbCommand, "pIdInvoice");

            return intIdInvoice;
        }

        public void Actualiza(InvoiceBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_Actualiza");

            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, pItem.IdInvoice);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, pItem.NumberInvoice);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, pItem.IdClient);
            db.AddInParameter(dbCommand, "pIssueDate", DbType.DateTime, pItem.IssueDate);
            db.AddInParameter(dbCommand, "pIdDestination", DbType.Int32, pItem.IdDestination);
            db.AddInParameter(dbCommand, "pIdClientBrand", DbType.Int32, pItem.IdClientBrand);
            db.AddInParameter(dbCommand, "pPercentComision", DbType.Decimal, pItem.PercentComision);
            db.AddInParameter(dbCommand, "pAddressClient", DbType.String, pItem.AddressClient);
            db.AddInParameter(dbCommand, "pContac", DbType.String, pItem.Contac);
            db.AddInParameter(dbCommand, "pOccupation", DbType.String, pItem.Occupation);
            db.AddInParameter(dbCommand, "pNoteGeneral", DbType.String, pItem.NoteGeneral);
            db.AddInParameter(dbCommand, "pIdBank", DbType.Int32, pItem.IdBank);
            db.AddInParameter(dbCommand, "pNameBank", DbType.String, pItem.NameBank);
            db.AddInParameter(dbCommand, "pNumberCtaCte", DbType.String, pItem.NumberCtaCte);
            db.AddInParameter(dbCommand, "pSwift", DbType.String, pItem.Swift);
            db.AddInParameter(dbCommand, "pCodeAba", DbType.String, pItem.CodeAba);
            db.AddInParameter(dbCommand, "pAddressBank", DbType.String, pItem.AddressBank);
            db.AddInParameter(dbCommand, "pPhone", DbType.String, pItem.Phone);
            db.AddInParameter(dbCommand, "pRepresentative", DbType.String, pItem.Representative);
            db.AddInParameter(dbCommand, "pIdCurrency", DbType.Int32, pItem.IdCurrency);
            db.AddInParameter(dbCommand, "pTotalAmount", DbType.Decimal, pItem.TotalAmount);
            db.AddInParameter(dbCommand, "pTotalComision", DbType.Decimal, pItem.TotalComision);
            db.AddInParameter(dbCommand, "pTotalPieces", DbType.Decimal, pItem.TotalPieces);
            db.AddInParameter(dbCommand, "pComisionLetter", DbType.String, pItem.ComisionLetter);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, pItem.IdStatus);
            db.AddInParameter(dbCommand, "pFlagState", DbType.Boolean, pItem.FlagState);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSituacion(int IdInvoice, int IdStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdInvoice, string NumberPP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);
            db.AddInParameter(dbCommand, "pNumberPP", DbType.String, NumberPP);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InvoiceBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_Elimina");

            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, pItem.IdInvoice);
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, pItem.IdCompany);
            db.AddInParameter(dbCommand, "pLogin", DbType.String, pItem.Login);
            db.AddInParameter(dbCommand, "pMachine", DbType.String, pItem.Machine);

            db.ExecuteNonQuery(dbCommand);
        }

        public InvoiceBE Selecciona(int IdInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_Selecciona");
            db.AddInParameter(dbCommand, "pIdInvoice", DbType.Int32, IdInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InvoiceBE Invoice = null;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.Occupation = reader["Occupation"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Invoice;
        }

        public InvoiceBE SeleccionaNumberInvoice(string NumberInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_SeleccionaNumberInvoice");
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, NumberInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InvoiceBE Invoice = null;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.Occupation = reader["Occupation"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Invoice;
        }

        public int SeleccionaBusquedaCount(int IdCompany, int IdClient)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<InvoiceBE> ListaTodosActivo(int IdCompany)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InvoiceBE> Invoicelist = new List<InvoiceBE>();
            InvoiceBE Invoice;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.Occupation = reader["Occupation"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Invoicelist.Add(Invoice);
            }
            reader.Close();
            reader.Dispose();
            return Invoicelist;
        }

        public List<InvoiceBE> ListaClient(int IdCompany, int IdClient, int IdStatus)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ListaClient");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InvoiceBE> Invoicelist = new List<InvoiceBE>();
            InvoiceBE Invoice;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.Occupation = reader["Occupation"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Invoicelist.Add(Invoice);
            }
            reader.Close();
            reader.Dispose();
            return Invoicelist;
        }

        public List<InvoiceBE> ListaClientDate(int IdCompany, int IdClient, int IdStatus, DateTime DateFrom, DateTime DateTo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ListaClientDate");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pIdStatus", DbType.Int32, IdStatus);
            db.AddInParameter(dbCommand, "pDateFrom", DbType.DateTime, DateFrom);
            db.AddInParameter(dbCommand, "pDateTo", DbType.DateTime, DateTo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InvoiceBE> Invoicelist = new List<InvoiceBE>();
            InvoiceBE Invoice;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.Occupation = reader["Occupation"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Invoicelist.Add(Invoice);
            }
            reader.Close();
            reader.Dispose();
            return Invoicelist;
        }

        public List<InvoiceBE> ListaNumberInvoice(int IdCompany, int IdClient, string NumberInvoice)
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Invoice_ListaNumberInvoice");
            db.AddInParameter(dbCommand, "pIdCompany", DbType.Int32, IdCompany);
            db.AddInParameter(dbCommand, "pIdClient", DbType.Int32, IdClient);
            db.AddInParameter(dbCommand, "pNumberInvoice", DbType.String, NumberInvoice);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InvoiceBE> Invoicelist = new List<InvoiceBE>();
            InvoiceBE Invoice;
            while (reader.Read())
            {
                Invoice = new InvoiceBE();
                Invoice.IdInvoice = Int32.Parse(reader["IdInvoice"].ToString());
                Invoice.IdCompany = Int32.Parse(reader["IdCompany"].ToString());
                Invoice.NameCompany = reader["NameCompany"].ToString();
                Invoice.NumberInvoice = reader["NumberInvoice"].ToString();
                Invoice.IdClient = Int32.Parse(reader["IdClient"].ToString());
                Invoice.NameClient = reader["NameClient"].ToString();
                Invoice.IssueDate = DateTime.Parse(reader["IssueDate"].ToString());
                Invoice.IdDestination = Int32.Parse(reader["IdDestination"].ToString());
                Invoice.NameDestination = reader["NameDestination"].ToString();
                Invoice.IdClientBrand = Int32.Parse(reader["IdClientBrand"].ToString());
                Invoice.BrandCertificate = reader["BrandCertificate"].ToString();
                Invoice.PercentComision = Decimal.Parse(reader["PercentComision"].ToString());
                Invoice.AddressClient = reader["AddressClient"].ToString();
                Invoice.Contac = reader["Contac"].ToString();
                Invoice.NoteGeneral = reader["NoteGeneral"].ToString();
                Invoice.IdBank = Int32.Parse(reader["IdBank"].ToString());
                Invoice.NameBank = reader["NameBank"].ToString();
                Invoice.NumberCtaCte = reader["NumberCtaCte"].ToString();
                Invoice.Swift = reader["Swift"].ToString();
                Invoice.CodeAba = reader["CodeAba"].ToString();
                Invoice.AddressBank = reader["AddressBank"].ToString();
                Invoice.Phone = reader["Phone"].ToString();
                Invoice.Representative = reader["Representative"].ToString();
                Invoice.IdCurrency = Int32.Parse(reader["IdCurrency"].ToString());
                Invoice.NameCurrency = reader["NameCurrency"].ToString();
                Invoice.TotalAmount = Decimal.Parse(reader["TotalAmount"].ToString());
                Invoice.TotalComision = Decimal.Parse(reader["TotalComision"].ToString());
                Invoice.TotalPieces = Decimal.Parse(reader["TotalPieces"].ToString());
                Invoice.ComisionLetter = reader["ComisionLetter"].ToString();
                Invoice.IdStatus = Int32.Parse(reader["IdStatus"].ToString());
                Invoice.NameStatus = reader["NameStatus"].ToString();
                Invoice.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                Invoicelist.Add(Invoice);
            }
            reader.Close();
            reader.Dispose();
            return Invoicelist;
        }

        
    }
}
