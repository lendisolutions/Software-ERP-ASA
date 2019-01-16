using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Modulos.Production.Rpt;
using CrystalDecisions.Shared;
using DevExpress.XtraGrid;

namespace ERP.Presentacion.Modulos.Invoices.Registros
{
    public partial class frmRegInvoiceEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InvoiceBE> lstInvoice;
        public List<CInvoiceDetail> mListaInvoiceDetailOrigen = new List<CInvoiceDetail>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdInvoice = 0;

        public int IdInvoice
        {
            get { return _IdInvoice; }
            set { _IdInvoice = value; }
        }

        public int IdClient { get; set; }

        int intIdStatus = 0;

        #endregion

        #region "Eventos"

        public frmRegInvoiceEdit()
        {
            InitializeComponent();
        }

        private void frmRegInvoiceEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            cboClient.EditValue = IdClient;

            deIssueDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIssueDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIssueDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIssueDate.Properties.CharacterCasing = CharacterCasing.Upper;

            BSUtils.LoaderLook(cboDestination, new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameDestination", "IdDestination", true);
            cboDestination.EditValue = 1;
            BSUtils.LoaderLook(cboCurrency, new CurrencyBL().ListaCombo(Parametros.intEmpresaId), "NameCurrency", "IdCurrency", true);
            BSUtils.LoaderLook(cboBank, new BankBL().ListaTodosActivo(Parametros.intEmpresaId), "NameBank", "IdBank", true);

            gvInvoiceDetail.Columns["IssueCertificate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvInvoiceDetail.Columns["IssueCertificate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvInvoiceDetail.Columns["IssueDateInvoice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvInvoiceDetail.Columns["IssueDateInvoice"].DisplayFormat.FormatString = "MM/dd/yyyy";

            deIssueDate.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Invoice - New";
                intIdStatus = Parametros.intIVNActive;

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Invoice - Update";

                InvoiceBE objE_Invoice = null;
                objE_Invoice = new InvoiceBL().Selecciona(IdInvoice);
                if (objE_Invoice != null)
                {
                    IdInvoice = objE_Invoice.IdInvoice;
                    txtNumberInvoice.Text = objE_Invoice.NumberInvoice;
                    cboClient.EditValue = objE_Invoice.IdClient;
                    deIssueDate.DateTime = objE_Invoice.IssueDate;
                    cboDestination.EditValue = objE_Invoice.IdDestination;
                    cboClientBrand.EditValue = objE_Invoice.IdClientBrand;
                    txtPercentComision.EditValue = objE_Invoice.PercentComision;
                    txtAddress.Text = objE_Invoice.AddressClient;
                    txtContact.Text = objE_Invoice.Contac;
                    txtOccupation.Text = objE_Invoice.Occupation;
                    txtNotesGeneral.Text = objE_Invoice.NoteGeneral;
                    cboBank.EditValue = objE_Invoice.IdBank;
                    txtNumberCtaCte.Text = objE_Invoice.NumberCtaCte;
                    txtSwift.Text = objE_Invoice.Swift;
                    txtCodeAba.Text = objE_Invoice.CodeAba;
                    txtAddressBank.Text = objE_Invoice.AddressBank;
                    txtPhone.Text = objE_Invoice.Phone;
                    txtRepresentative.Text = objE_Invoice.Representative;
                    cboCurrency.EditValue = objE_Invoice.IdCurrency;
                    txtTotalAmount.EditValue = objE_Invoice.TotalAmount;
                    txtTotalComision.EditValue = objE_Invoice.TotalComision;
                    txtTotalPieces.EditValue = objE_Invoice.TotalPieces;
                    intIdStatus = objE_Invoice.IdStatus;
                }
            }

            CargaInvoiceDetail();
            CalculaTotales();
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                BSUtils.LoaderLook(cboClientBrand, new ClientBrandBL().ListaCertificate(Convert.ToInt32(cboClient.EditValue)), "BrandCertificate", "IdClientBrand", true);

                if (pOperacion == Operacion.Nuevo)
                {
                    txtNumberInvoice.Text = CreateNumberInvoice(Convert.ToInt32(cboClient.EditValue));
                }

                ClientBE objE_Client = null;
                objE_Client = new ClientBL().Selecciona(Convert.ToInt32(cboClient.EditValue));
                if (objE_Client != null)
                {
                    txtPercentComision.EditValue = objE_Client.PercentComision1;
                }

                List<ClientAddressBE> lstClientAddress = null;
                lstClientAddress = new ClientAddressBL().ListaTodosActivo(Convert.ToInt32(cboClient.EditValue));
                if(lstClientAddress.Count > 0)
                {
                    
                    txtAddress.Text = lstClientAddress[0].Destination;
                }

                List<ClientContactBE> lstClientContact = null;
                lstClientContact = new ClientContactBL().ListaTodosActivo(Convert.ToInt32(cboClient.EditValue));
                if (lstClientContact.Count > 0)
                {
                    txtContact.Text = lstClientContact[0].Name + " " + lstClientContact[0].FirtsName;
                    txtOccupation.Text = lstClientContact[0].Occupation;
                }
            }
        }

        private void cboBank_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBank.EditValue != null)
            {
                BankBE objE_Bank = null;
                objE_Bank = new BankBL().Selecciona(Convert.ToInt32(cboBank.EditValue));
                if (objE_Bank != null)
                {
                    txtNumberCtaCte.Text = objE_Bank.NumberCtaCte;
                    txtSwift.Text = objE_Bank.Swift;
                    txtCodeAba.Text = objE_Bank.CodeAba;
                    txtAddressBank.Text = objE_Bank.Address;
                    txtPhone.Text = objE_Bank.Phone;
                    txtRepresentative.Text = objE_Bank.Contac;
                }
            }
        }

        private void eliminarInvoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvInvoiceDetail.SelectedRowsCount; i++)
                {
                    int row = gvInvoiceDetail.GetSelectedRows()[i];

                    InvoiceDetailBE objBE_InvoiceDetail = new InvoiceDetailBE();
                    objBE_InvoiceDetail.IdInvoiceDetail = int.Parse(gvInvoiceDetail.GetRowCellValue(row, "IdInvoiceDetail").ToString());
                    objBE_InvoiceDetail.IdCompany = Parametros.intEmpresaId;
                    objBE_InvoiceDetail.Login = Parametros.strUsuarioLogin;
                    objBE_InvoiceDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                    InvoiceDetailBL objBL_InvoiceDetail = new InvoiceDetailBL();
                    objBL_InvoiceDetail.Elimina(objBE_InvoiceDetail);
                    gvInvoiceDetail.DeleteRow(row);
                    gvInvoiceDetail.RefreshData();
                }

                CalculaTotales();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNumberCertificate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    List<InspectionCertificateBE> lstInspectionCertificate = null;
                    lstInspectionCertificate = new InspectionCertificateBL().ListaInvoiceDetail(Parametros.intEmpresaId, txtNumberCertificate.Text.Trim());

                    foreach (var item in lstInspectionCertificate)
                    {
                        CInvoiceDetail objE_InvoiceDetail = new CInvoiceDetail();
                        objE_InvoiceDetail.IdCompany = item.IdCompany;
                        objE_InvoiceDetail.IdInvoice = 0;
                        objE_InvoiceDetail.IdInvoiceDetail = 0;
                        objE_InvoiceDetail.IdInspectionCertificate = item.IdInspectionCertificate;
                        objE_InvoiceDetail.NumberCertificate = item.NumberCertificate;
                        objE_InvoiceDetail.IssueCertificate = item.IssueDate;
                        objE_InvoiceDetail.NameVendor = item.NameVendor;
                        objE_InvoiceDetail.NumberInvoiceCertificate = item.NumberInvoice;
                        objE_InvoiceDetail.IssueDateInvoice = item.IssueDateInvoice;
                        objE_InvoiceDetail.NameDivision = item.NameDivision;
                        objE_InvoiceDetail.Amount = item.AmountCertificate;
                        objE_InvoiceDetail.Comision = item.Comision;
                        objE_InvoiceDetail.Pieces = item.Pieces;
                        objE_InvoiceDetail.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        mListaInvoiceDetailOrigen.Add(objE_InvoiceDetail);

                    }

                    bsListadoInvoiceDetail.DataSource = mListaInvoiceDetailOrigen;
                    gcInvoiceDetail.DataSource = bsListadoInvoiceDetail;
                    gcInvoiceDetail.RefreshDataSource();

                    CalculaTotales();

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCertificate frm = new frmBusCertificate();
                frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                frm.ShowDialog();
                if (frm.mListaCertificate.Count > 0)
                {
                    foreach (string strCertificate in frm.mListaCertificate)
                    {
                        List<InspectionCertificateBE> lstInspectionCertificate = null;
                        lstInspectionCertificate = new InspectionCertificateBL().ListaInvoiceDetail(Parametros.intEmpresaId, strCertificate);

                        foreach (var item in lstInspectionCertificate)
                        {
                            CInvoiceDetail objE_InvoiceDetail = new CInvoiceDetail();
                            objE_InvoiceDetail.IdCompany = item.IdCompany;
                            objE_InvoiceDetail.IdInvoice = 0;
                            objE_InvoiceDetail.IdInvoiceDetail = 0;
                            objE_InvoiceDetail.IdInspectionCertificate = item.IdInspectionCertificate;
                            objE_InvoiceDetail.NumberCertificate = item.NumberCertificate;
                            objE_InvoiceDetail.IssueCertificate = item.IssueDate;
                            objE_InvoiceDetail.NameVendor = item.NameVendor;
                            objE_InvoiceDetail.NumberInvoiceCertificate = item.NumberInvoice;
                            objE_InvoiceDetail.IssueDateInvoice = item.IssueDateInvoice;
                            objE_InvoiceDetail.NameDivision = item.NameDivision;
                            objE_InvoiceDetail.Amount = item.AmountCertificate;
                            objE_InvoiceDetail.Comision = item.Comision;
                            objE_InvoiceDetail.Pieces = item.Pieces;
                            objE_InvoiceDetail.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                            mListaInvoiceDetailOrigen.Add(objE_InvoiceDetail);

                        }
                    }

                    bsListadoInvoiceDetail.DataSource = mListaInvoiceDetailOrigen;
                    gcInvoiceDetail.DataSource = bsListadoInvoiceDetail;
                    gcInvoiceDetail.RefreshDataSource();

                    CalculaTotales();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InvoiceBL objBL_Invoice = new InvoiceBL();
                    InvoiceBE objInvoice = new InvoiceBE();

                    objInvoice.NumberInvoice = txtNumberInvoice.Text;
                    objInvoice.IdClient = Convert.ToInt32(cboClient.EditValue);
                    objInvoice.IssueDate = Convert.ToDateTime(deIssueDate.DateTime.ToShortDateString());
                    objInvoice.IdDestination = Convert.ToInt32(cboDestination.EditValue);
                    objInvoice.IdClientBrand = Convert.ToInt32(cboClientBrand.EditValue);
                    objInvoice.PercentComision = Convert.ToDecimal(txtPercentComision.EditValue);
                    objInvoice.AddressClient = txtAddress.Text;
                    objInvoice.Contac = txtContact.Text;
                    objInvoice.Occupation = txtOccupation.Text;
                    objInvoice.NoteGeneral = txtNotesGeneral.Text;
                    objInvoice.IdBank = Convert.ToInt32(cboBank.EditValue);
                    objInvoice.NameBank = cboBank.Text;
                    objInvoice.NumberCtaCte = txtNumberCtaCte.Text;
                    objInvoice.Swift = txtSwift.Text;
                    objInvoice.CodeAba = txtCodeAba.Text;
                    objInvoice.AddressBank = txtAddressBank.Text;
                    objInvoice.Phone = txtPhone.Text;
                    objInvoice.Representative = txtRepresentative.Text;
                    objInvoice.IdCurrency = Convert.ToInt32(cboCurrency.EditValue);
                    objInvoice.TotalAmount = Convert.ToDecimal(txtTotalAmount.EditValue);
                    objInvoice.TotalComision = Convert.ToDecimal(txtTotalComision.EditValue);
                    objInvoice.TotalPieces = Convert.ToDecimal(txtTotalPieces.EditValue);
                    objInvoice.IdStatus = intIdStatus;
                    objInvoice.FlagState = true;
                    objInvoice.Login = Parametros.strUsuarioLogin;
                    objInvoice.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objInvoice.IdCompany = Parametros.intEmpresaId;

                    //DETAIL
                    List<InvoiceDetailBE> lstInvoiceDetail = new List<InvoiceDetailBE>();

                    foreach (var item in mListaInvoiceDetailOrigen)
                    {
                        InvoiceDetailBE objE_InvoiceDetail = new InvoiceDetailBE();
                        objE_InvoiceDetail.IdCompany = Parametros.intEmpresaId;
                        objE_InvoiceDetail.IdInvoice = IdInvoice;
                        objE_InvoiceDetail.IdInvoiceDetail = item.IdInvoiceDetail;
                        objE_InvoiceDetail.IdInspectionCertificate = item.IdInspectionCertificate;
                        objE_InvoiceDetail.NumberCertificate = item.NumberCertificate;
                        objE_InvoiceDetail.IssueCertificate = item.IssueCertificate;
                        objE_InvoiceDetail.NameVendor = item.NameVendor;
                        objE_InvoiceDetail.NumberInvoiceCertificate = item.NumberInvoiceCertificate;
                        objE_InvoiceDetail.IssueDateInvoice = item.IssueDateInvoice;
                        objE_InvoiceDetail.NameDivision = item.NameDivision;
                        objE_InvoiceDetail.Amount = item.Amount;
                        objE_InvoiceDetail.Comision = item.Comision;
                        objE_InvoiceDetail.Pieces = item.Pieces;
                        objE_InvoiceDetail.TipoOper = item.TipoOper;
                        objE_InvoiceDetail.FlagState = true;
                        objE_InvoiceDetail.Login = Parametros.strUsuarioLogin;
                        objE_InvoiceDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InvoiceDetail.TipoOper = item.TipoOper;
                        lstInvoiceDetail.Add(objE_InvoiceDetail);
                    }

                    int tam_var = txtTotalComision.Text.Length;
                    String strDecimal = txtTotalComision.Text.Substring((tam_var - 2), 2);
                    decimal decNumero = Math.Truncate(Convert.ToDecimal(txtTotalComision.EditValue));

                    String strComisionLetter = IntegerToWords(Convert.ToInt32(decNumero)) + " AND " + strDecimal + "/100" + " US$";

                    objInvoice.ComisionLetter = strComisionLetter.ToUpper();


                    if (pOperacion == Operacion.Nuevo)
                    {

                       
                        objBL_Invoice.Inserta(objInvoice, lstInvoiceDetail);
                        Application.DoEvents();
                    }
                    else
                    {
                        objInvoice.IdInvoice = IdInvoice;
                        objBL_Invoice.Actualiza(objInvoice, lstInvoiceDetail);
                    }


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";


            if (txtNumberInvoice.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the Number Invoice.\n";
                flag = true;
            }

            if (mListaInvoiceDetailOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- You must enter list terms.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private string CreateNumberInvoice(int IdClient)
        {
            string strNumberInvoice = "";

            try
            {
                Cursor = Cursors.WaitCursor;

                string strAbrevClient = "";
                int intNumero = 0;
                string strNumero = "";

                ClientBE objE_Client = null;
                objE_Client = new ClientBL().Selecciona(IdClient);
                if (objE_Client != null)
                {
                    strAbrevClient = objE_Client.Certificate;
                }

                intNumero = new InvoiceBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue));
                strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 5);

                strNumberInvoice = strAbrevClient + Parametros.intPeriodo.ToString().Substring(2, 2) + strNumero;

                Cursor = Cursors.Default;

                return strNumberInvoice;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                return strNumberInvoice;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string IntegerToWords(long inputNum)
        {
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;

            string retval = "";
            string x = "";
            string[] ones ={
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten",
                "eleven",
                "twelve",
                "thirteen",
                "fourteen",
                "fifteen",
                "sixteen",
                "seventeen",
                "eighteen",
                "nineteen"
              };
            string[] tens ={
                "zero",
                "ten",
                "twenty",
                "thirty",
                "forty",
                "fifty",
                "sixty",
                "seventy",
                "eighty",
                "ninety"
              };
            string[] thou ={
                "",
                "thousand",
                "million",
                "billion",
                "trillion",
                "quadrillion",
                "quintillion"
              };

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }

            if (inputNum == 0)
                return ("zero");

            string s = inputNum.ToString();

            while (s.Length > 0)
            {
                // Get the three rightmost characters
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits
                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;
                dig1 = threeDigits / 100;
                dig2 = lasttwo / 10;
                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    retval = thou[level] + " " + retval;
                    retval = retval.Trim();
                }

                // check that the last two digits is not a zero
                if (lasttwo > 0)
                {
                    if (lasttwo < 20) // if less than 20, use "ones" only
                        retval = ones[lasttwo] + " " + retval;
                    else // otherwise, use both "tens" and "ones" array
                        retval = tens[dig2] + " " + ones[dig3] + " " + retval;
                }

                // if a hundreds part is there, translate it
                if (dig1 > 0)
                    retval = ones[dig1] + " hundred " + retval;

                s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                level++;
            }

            while (retval.IndexOf("  ") > 0)
                retval = retval.Replace("  ", " ");

            retval = retval.Trim();

            if (isNegative)
                retval = "negative " + retval;

            return (retval);
        }

        public void CalculaTotales()
        {
            if (mListaInvoiceDetailOrigen.Count > 0)
            {
                decimal decTotalAmount = 0;
                decimal decTotalComision = 0;
                decimal decTotalPieces = 0;

                foreach (var item in mListaInvoiceDetailOrigen)
                {
                    decTotalAmount = decTotalAmount + item.Amount;
                    decTotalComision = decTotalComision + item.Comision;
                    decTotalPieces = decTotalPieces + item.Pieces;
                }

                txtTotalAmount.EditValue = decTotalAmount;
                txtTotalComision.EditValue = decTotalComision;
                txtTotalPieces.EditValue = decTotalPieces;
            }
            else
            {
                txtTotalAmount.Text = "0.00";
                txtTotalComision.Text = "0.00";
                txtTotalPieces.Text = "0";
            }

            
        }

        private void CargaInvoiceDetail()
        {
            List<InvoiceDetailBE> lstTmpInvoiceDetail = null;
            lstTmpInvoiceDetail = new InvoiceDetailBL().ListaTodosActivo(IdInvoice);

            foreach (InvoiceDetailBE item in lstTmpInvoiceDetail)
            {
                CInvoiceDetail objE_InvoiceDetail = new CInvoiceDetail();
                objE_InvoiceDetail.IdCompany = item.IdCompany;
                objE_InvoiceDetail.IdInvoice = item.IdInvoice;
                objE_InvoiceDetail.IdInvoiceDetail = item.IdInvoiceDetail;
                objE_InvoiceDetail.IdInspectionCertificate = item.IdInspectionCertificate;
                objE_InvoiceDetail.NumberCertificate = item.NumberCertificate;
                objE_InvoiceDetail.IssueCertificate = item.IssueCertificate;
                objE_InvoiceDetail.NameVendor = item.NameVendor;
                objE_InvoiceDetail.NumberInvoiceCertificate = item.NumberInvoiceCertificate;
                objE_InvoiceDetail.IssueDateInvoice = item.IssueDateInvoice;
                objE_InvoiceDetail.NameDivision = item.NameDivision;
                objE_InvoiceDetail.Amount = item.Amount;
                objE_InvoiceDetail.Comision = item.Comision;
                objE_InvoiceDetail.Pieces = item.Pieces;
                objE_InvoiceDetail.TipoOper = item.TipoOper;
                mListaInvoiceDetailOrigen.Add(objE_InvoiceDetail);
            }

            bsListadoInvoiceDetail.DataSource = mListaInvoiceDetailOrigen;
            gcInvoiceDetail.DataSource = bsListadoInvoiceDetail;
            gcInvoiceDetail.RefreshDataSource();
        }

        #endregion

        public class CInvoiceDetail
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdInvoice { get; set; }
            public Int32 IdInvoiceDetail { get; set; }
            public Int32 IdInspectionCertificate { get; set; }
            public String NumberCertificate { get; set; }
            public DateTime IssueCertificate { get; set; }
            public String NameVendor { get; set; }
            public String NumberInvoiceCertificate { get; set; }
            public DateTime IssueDateInvoice { get; set; }
            public String NameDivision { get; set; }
            public Decimal Amount { get; set; }
            public Decimal Comision { get; set; }
            public Decimal Pieces { get; set; }
            public Int32 TipoOper { get; set; }

            public CInvoiceDetail()
            {

            }
        }

        
    }
}