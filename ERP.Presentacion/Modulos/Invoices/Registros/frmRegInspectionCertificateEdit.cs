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
    public partial class frmRegInspectionCertificateEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InspectionCertificateBE> lstInspectionCertificate;
        public List<CInspectionCertificateDetail> mListaInspectionCertificateDetailOrigen = new List<CInspectionCertificateDetail>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdInspectionCertificate = 0;

        public int IdInspectionCertificate
        {
            get { return _IdInspectionCertificate; }
            set { _IdInspectionCertificate = value; }
        }

        public int IdClient { get; set; }

        int intIdStatus = 0;

        List<string> lstNumberPO = new List<string>();
        List<string> lstNumberOI = new List<string>();

        #endregion

        #region "Eventos"

        public frmRegInspectionCertificateEdit()
        {
            InitializeComponent();
        }

        private void frmRegInspectionCertificateEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            cboClient.EditValue = IdClient;
            BSUtils.LoaderLook(cboVendor, new VendorBL().ListaTodosActivo(Parametros.intEmpresaId), "NameVendor", "IdVendor", true);
            BSUtils.LoaderLook(cboRepresentative, new EmployeeBL().ListaCombo(Parametros.intEmpresaId), "FullName", "IdEmployee", true);
            BSUtils.LoaderLook(cboCurrency, new CurrencyBL().ListaCombo(Parametros.intEmpresaId), "NameCurrency", "IdCurrency", true);
            BSUtils.LoaderLook(cboTypeShipping, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTypeShipping), "NameElementTablet", "IdElementTablet", true);

            deIssueDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIssueDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIssueDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIssueDate.Properties.CharacterCasing = CharacterCasing.Upper;

            deIssueDateInvoice.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIssueDateInvoice.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIssueDateInvoice.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIssueDateInvoice.Properties.CharacterCasing = CharacterCasing.Upper;

            deEtdDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deEtdDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deEtdDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deEtdDate.Properties.CharacterCasing = CharacterCasing.Upper;

            deIssueDate.DateTime = DateTime.Now;
            deIssueDateInvoice.DateTime = DateTime.Now;
            deEtdDate.DateTime = DateTime.Now;

            LlenarPaymentTerm();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inspection Certificate - New";
                intIdStatus = Parametros.intICActive;

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inspection Certificate - Update";

                InspectionCertificateBE objE_InspectionCertificate = null;
                objE_InspectionCertificate = new InspectionCertificateBL().Selecciona(IdInspectionCertificate);
                if (objE_InspectionCertificate != null)
                {
                    IdInspectionCertificate = objE_InspectionCertificate.IdInspectionCertificate;
                    txtNumberCertificate.Text = objE_InspectionCertificate.NumberCertificate;
                    cboClient.EditValue = objE_InspectionCertificate.IdClient;
                    cboDivision.EditValue = objE_InspectionCertificate.IdClientDepartment;
                    cboClientBrand.EditValue = objE_InspectionCertificate.IdClientBrand;
                    cboVendor.EditValue = objE_InspectionCertificate.IdVendor;
                    cboPaymentTerm.Text = objE_InspectionCertificate.PaymentTerm;
                    txtCartons.EditValue = objE_InspectionCertificate.Cartons;
                    deIssueDate.DateTime = objE_InspectionCertificate.IssueDate;
                    cboRepresentative.EditValue = objE_InspectionCertificate.IdRepresentative;
                    txtDescriptionStyle.Text = objE_InspectionCertificate.DescriptionStyle;
                    txtNumberInvoice.Text = objE_InspectionCertificate.NumberInvoice;
                    deIssueDateInvoice.DateTime = objE_InspectionCertificate.IssueDateInvoice;
                    cboCurrency.EditValue = objE_InspectionCertificate.IdCurrency;
                    txtAmount.EditValue = objE_InspectionCertificate.Amount;
                    deEtdDate.DateTime = objE_InspectionCertificate.EtdDate;
                    cboTypeShipping.EditValue = objE_InspectionCertificate.IdTypeShipping;
                    txtBoardingWay.Text = objE_InspectionCertificate.BoardingWay;
                    intIdStatus = objE_InspectionCertificate.IdStatus;
                }
            }

            CargaInspectionCertificateDetail();

            gvInspectionCertificateDetail.OptionsView.ShowFooter = true;
            gvInspectionCertificateDetail.Layout += new EventHandler(gvInspectionCertificateDetail_Layout);
            AttachSummary();

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "POOrder";
            item.ShowInGroupColumnFooter = gvInspectionCertificateDetail.Columns["POOrder"];
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            item.DisplayFormat = "TOTAL = {0:n0}";
            gvInspectionCertificateDetail.GroupSummary.Add(item);

            GridGroupSummaryItem ItemPieces = new GridGroupSummaryItem();
            ItemPieces.FieldName = "Pieces";
            ItemPieces.ShowInGroupColumnFooter = gvInspectionCertificateDetail.Columns["Pieces"];
            ItemPieces.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ItemPieces.DisplayFormat = "TOTAL = {0:n0}";
            gvInspectionCertificateDetail.GroupSummary.Add(ItemPieces);

            GridGroupSummaryItem ItemPercent = new GridGroupSummaryItem();
            ItemPercent.FieldName = "Percents";
            ItemPercent.ShowInGroupColumnFooter = gvInspectionCertificateDetail.Columns["Percents"];
            ItemPercent.SummaryType = DevExpress.Data.SummaryItemType.Average;
            ItemPercent.DisplayFormat = "PERCENT = {0:n0}";
            gvInspectionCertificateDetail.GroupSummary.Add(ItemPercent);

            GridGroupSummaryItem ItemAmountCertificate = new GridGroupSummaryItem();
            ItemAmountCertificate.FieldName = "AmountCertificate";
            ItemAmountCertificate.ShowInGroupColumnFooter = gvInspectionCertificateDetail.Columns["AmountCertificate"];
            ItemAmountCertificate.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ItemAmountCertificate.DisplayFormat = "TOTAL = {0:n2}";
            gvInspectionCertificateDetail.GroupSummary.Add(ItemAmountCertificate);


            gvInspectionCertificateDetail.ExpandAllGroups();
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                BSUtils.LoaderLook(cboDivision, new LoginClientDepartmentBL().ListaClientDivision(Parametros.intUsuarioId, Convert.ToInt32(cboClient.EditValue)), "NameDivision", "IdClientDepartment", true);
                BSUtils.LoaderLook(cboClientBrand, new ClientBrandBL().ListaCertificate(Convert.ToInt32(cboClient.EditValue)), "BrandCertificate", "IdClientBrand", true);

                if (pOperacion == Operacion.Nuevo)
                {
                    txtNumberCertificate.Text = CreateNumberCertificate(Convert.ToInt32(cboClient.EditValue));
                }
            }
        }

        private void gvInspectionCertificateDetail_Layout(object sender, EventArgs e)
        {
            AttachSummary();
        }

        private void eliminarInspectionCertificateDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < gvInspectionCertificateDetail.SelectedRowsCount; i++)
                {
                    int row = gvInspectionCertificateDetail.GetSelectedRows()[i];

                    InspectionCertificateDetailBE objBE_InspectionCertificateDetail = new InspectionCertificateDetailBE();
                    objBE_InspectionCertificateDetail.IdInspectionCertificateDetail = int.Parse(gvInspectionCertificateDetail.GetRowCellValue(row, "IdInspectionCertificateDetail").ToString());
                    objBE_InspectionCertificateDetail.IdCompany = Parametros.intEmpresaId;
                    objBE_InspectionCertificateDetail.Login = Parametros.strUsuarioLogin;
                    objBE_InspectionCertificateDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                    InspectionCertificateDetailBL objBL_InspectionCertificateDetail = new InspectionCertificateDetailBL();
                    objBL_InspectionCertificateDetail.Elimina(objBE_InspectionCertificateDetail);
                    gvInspectionCertificateDetail.DeleteRow(row);
                    gvInspectionCertificateDetail.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void exportexceltoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string _msg = "Se generó el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "InspectionCertificateDetail";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInspectionCertificateDetail.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void gvInspectionCertificateDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (mListaInspectionCertificateDetailOrigen.Count == 0)
            {
                return;
            }

            if (e.Column.Caption == "Shipment QTY")
            {
                int index = gvInspectionCertificateDetail.FocusedRowHandle;

                decimal decPOOrder = 0;
                decimal decPieces = 0;
                decimal decFob = 0;
                decimal decAmountCertificate = 0;
                int intPercent = 0;

                decPOOrder = decimal.Parse(gvInspectionCertificateDetail.GetRowCellValue(index, gvInspectionCertificateDetail.Columns["POOrder"]).ToString());
                decPieces = decimal.Parse(gvInspectionCertificateDetail.GetRowCellValue(index, gvInspectionCertificateDetail.Columns["Pieces"]).ToString());
                decFob = decimal.Parse(gvInspectionCertificateDetail.GetRowCellValue(index, gvInspectionCertificateDetail.Columns["Fob"]).ToString());
                decAmountCertificate = decPieces * decFob;
                intPercent = Convert.ToInt32((decPieces / decPOOrder) * 100);

                gvInspectionCertificateDetail.SetRowCellValue(index, "AmountCertificate", decAmountCertificate);
                gvInspectionCertificateDetail.SetRowCellValue(index, "Percents", intPercent);


            }
        }

        private void gvInspectionCertificateDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Percents")
                    {
                        int intPercents = int.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Percents"]).ToString());
                        if (intPercents >= 105 || intPercents <= 95)
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                        else
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumberPO_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    List<ProgramProductionDetailBE> lstProgramProductionDetail = null;
                    lstProgramProductionDetail = new ProgramProductionDetailBL().ListaNumberPO(Convert.ToInt32(cboClient.EditValue), txtNumberPO.Text.Trim());

                    foreach (var item in lstProgramProductionDetail)
                    {
                        CInspectionCertificateDetail objE_InspectionCertificateDetail = new CInspectionCertificateDetail();
                        objE_InspectionCertificateDetail.IdCompany = item.IdCompany;
                        objE_InspectionCertificateDetail.IdInspectionCertificate = 0;
                        objE_InspectionCertificateDetail.IdInspectionCertificateDetail = 0;
                        objE_InspectionCertificateDetail.IdProgramProductionDetail = item.IdProgramProductionDetail;
                        objE_InspectionCertificateDetail.NumberPO = item.NumberPO;
                        objE_InspectionCertificateDetail.NumberOI = item.NumeroOI;
                        objE_InspectionCertificateDetail.NameStyle = item.NameStyle;
                        objE_InspectionCertificateDetail.Description = item.Description;
                        objE_InspectionCertificateDetail.Dyelot = item.Dyelot;
                        objE_InspectionCertificateDetail.Item = item.Item;
                        objE_InspectionCertificateDetail.Color = item.Detail;
                        objE_InspectionCertificateDetail.POOrder = item.Units;
                        objE_InspectionCertificateDetail.Pieces = 0;
                        objE_InspectionCertificateDetail.Fob = item.Fob;
                        objE_InspectionCertificateDetail.AmountCertificate = 0;
                        objE_InspectionCertificateDetail.Percents = 0;
                        objE_InspectionCertificateDetail.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        mListaInspectionCertificateDetailOrigen.Add(objE_InspectionCertificateDetail);


                    }

                    bsListadoInspectionCertificateDetail.DataSource = mListaInspectionCertificateDetailOrigen;
                    gcInspectionCertificateDetail.DataSource = bsListadoInspectionCertificateDetail;
                    gcInspectionCertificateDetail.RefreshDataSource();

                    gvInspectionCertificateDetail.ExpandAllGroups();

                    AttachSummary();

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
                    InspectionCertificateBL objBL_InspectionCertificate = new InspectionCertificateBL();
                    InspectionCertificateBE objInspectionCertificate = new InspectionCertificateBE();

                    objInspectionCertificate.NumberCertificate = txtNumberCertificate.Text;
                    objInspectionCertificate.IdClient = Convert.ToInt32(cboClient.EditValue);
                    objInspectionCertificate.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                    objInspectionCertificate.IdClientBrand = Convert.ToInt32(cboClientBrand.EditValue);
                    objInspectionCertificate.IdVendor = Convert.ToInt32(cboVendor.EditValue);
                    objInspectionCertificate.PaymentTerm = cboPaymentTerm.Text;
                    objInspectionCertificate.Cartons = Convert.ToInt32(txtCartons.EditValue);
                    objInspectionCertificate.IssueDate = Convert.ToDateTime(deIssueDate.DateTime.ToShortDateString());
                    objInspectionCertificate.IdRepresentative = Convert.ToInt32(cboRepresentative.EditValue);
                    objInspectionCertificate.DescriptionStyle = txtDescriptionStyle.Text;
                    objInspectionCertificate.NumberInvoice = txtNumberInvoice.Text;
                    objInspectionCertificate.IssueDateInvoice = Convert.ToDateTime(deIssueDateInvoice.DateTime.ToShortDateString());
                    objInspectionCertificate.IdCurrency = Convert.ToInt32(cboCurrency.EditValue);
                    objInspectionCertificate.Amount = Convert.ToDecimal(txtAmount.EditValue);
                    objInspectionCertificate.EtdDate = Convert.ToDateTime(deEtdDate.DateTime.ToShortDateString());
                    objInspectionCertificate.IdTypeShipping = Convert.ToInt32(cboTypeShipping.EditValue);
                    objInspectionCertificate.BoardingWay = txtBoardingWay.Text;
                    objInspectionCertificate.IdStatus = intIdStatus;
                    objInspectionCertificate.FlagState = true;
                    objInspectionCertificate.Login = Parametros.strUsuarioLogin;
                    objInspectionCertificate.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objInspectionCertificate.IdCompany = Parametros.intEmpresaId;

                    //DETAIL
                    List<InspectionCertificateDetailBE> lstInspectionCertificateDetail = new List<InspectionCertificateDetailBE>();

                    foreach (var item in mListaInspectionCertificateDetailOrigen)
                    {
                        InspectionCertificateDetailBE objE_InspectionCertificateDetail = new InspectionCertificateDetailBE();
                        objE_InspectionCertificateDetail.IdCompany = Parametros.intEmpresaId;
                        objE_InspectionCertificateDetail.IdInspectionCertificate = IdInspectionCertificate;
                        objE_InspectionCertificateDetail.IdInspectionCertificateDetail = item.IdInspectionCertificateDetail;
                        objE_InspectionCertificateDetail.IdProgramProductionDetail = item.IdProgramProductionDetail;
                        objE_InspectionCertificateDetail.NumberPO = item.NumberPO;
                        objE_InspectionCertificateDetail.NumberOI = item.NumberOI;
                        objE_InspectionCertificateDetail.NameStyle = item.NameStyle;
                        objE_InspectionCertificateDetail.Description = item.Description;
                        objE_InspectionCertificateDetail.Dyelot = item.Dyelot;
                        objE_InspectionCertificateDetail.Item = item.Item;
                        objE_InspectionCertificateDetail.Color = item.Color;
                        objE_InspectionCertificateDetail.POOrder = item.POOrder;
                        objE_InspectionCertificateDetail.Pieces = item.Pieces;
                        objE_InspectionCertificateDetail.Fob = item.Fob;
                        objE_InspectionCertificateDetail.AmountCertificate = item.AmountCertificate;
                        objE_InspectionCertificateDetail.Percents = item.Percents;
                        objE_InspectionCertificateDetail.TipoOper = item.TipoOper;
                        objE_InspectionCertificateDetail.FlagState = true;
                        objE_InspectionCertificateDetail.Login = Parametros.strUsuarioLogin;
                        objE_InspectionCertificateDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InspectionCertificateDetail.TipoOper = item.TipoOper;
                        lstInspectionCertificateDetail.Add(objE_InspectionCertificateDetail);

                        //NUMBER PO
                        if (lstNumberPO.Count == 0)
                        {
                            lstNumberPO.Add(item.NumberPO);
                        }
                        else
                        {
                            int intIndex = 0;
                            intIndex = lstNumberPO.LastIndexOf(item.NumberPO);
                            if (intIndex < 0)
                            {
                                lstNumberPO.Add(item.NumberPO);
                            }

                        }

                        //NUMBER O/I
                        if (lstNumberOI.Count == 0)
                        {
                            lstNumberOI.Add(item.NumberOI);
                        }
                        else
                        {
                            int intIndex = 0;
                            intIndex = lstNumberOI.LastIndexOf(item.NumberOI);
                            if (intIndex < 0)
                            {
                                lstNumberOI.Add(item.NumberOI);
                            }

                        }

                    }

                    string strNumberPO = string.Join(",", lstNumberPO);
                    string strNumberOI = string.Join(",", lstNumberOI);

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objInspectionCertificate.NumberPO = strNumberPO;
                        objInspectionCertificate.NumberOI = strNumberOI;
                        objBL_InspectionCertificate.Inserta(objInspectionCertificate, lstInspectionCertificateDetail);
                        Application.DoEvents();
                    }
                    else
                    {
                        objInspectionCertificate.NumberPO = strNumberPO;
                        objInspectionCertificate.NumberOI = strNumberOI;
                        objInspectionCertificate.IdInspectionCertificate = IdInspectionCertificate;
                        objBL_InspectionCertificate.Actualiza(objInspectionCertificate, lstInspectionCertificateDetail);
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

        private string CreateNumberCertificate(int IdClient)
        {
            string strNumberCertificate = "";

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

                intNumero = new InspectionCertificateBL().SeleccionaBusquedaCount(Parametros.intEmpresaId,Convert.ToInt32(cboClient.EditValue));
                strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 5);

                strNumberCertificate = strAbrevClient + Parametros.intPeriodo.ToString().Substring(2, 2) + strNumero;

                Cursor = Cursors.Default;

                return strNumberCertificate;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                return strNumberCertificate;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";


            if (txtNumberCertificate.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the Number Certificate.\n";
                flag = true;
            }

            if (txtNumberInvoice.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the Number Invoice.\n";
                flag = true;
            }

            if (mListaInspectionCertificateDetailOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- You must enter list terms.\n";
                flag = true;
            }

            InspectionCertificateBE objE_InspectionCertificate = null;
            objE_InspectionCertificate = new InspectionCertificateBL().SeleccionaNumberInvoice(txtNumberInvoice.Text.Trim());
            if (objE_InspectionCertificate != null && pOperacion == Operacion.Nuevo)
            {
                strMensaje = strMensaje + "The Number Invoice already exists\n Please Verify.";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void LlenarPaymentTerm()
        {
            List<string> lstPaymentTerm = new List<string>();
            lstPaymentTerm.Add("WIRE TRANSFER");
            lstPaymentTerm.Add("LETTER OF CREDIT");

            cboPaymentTerm.Properties.DataSource = lstPaymentTerm;
            cboPaymentTerm.ItemIndex = 0;
        }

        private void AttachSummary()
        {
            GridColumn firstColumn = gvInspectionCertificateDetail.VisibleColumns.Count == 0 ? null : gvInspectionCertificateDetail.VisibleColumns[0];
            GridColumn SecondColumn = gvInspectionCertificateDetail.VisibleColumns.Count == 0 ? null : gvInspectionCertificateDetail.VisibleColumns[0];
            GridColumn ThreeColumn = gvInspectionCertificateDetail.VisibleColumns.Count == 0 ? null : gvInspectionCertificateDetail.VisibleColumns[0];

            if (gcPOOrder == firstColumn) return;
            if (gcPOOrder != null)
            {
                gcPOOrder.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcPOOrder.SummaryItem.DisplayFormat = "PIECES = {0:n0}";
            }

            if (gcPieces == SecondColumn) return;
            if (gcPieces != null)
            {
                gcPieces.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcPieces.SummaryItem.DisplayFormat = "PIECES = {0:n0}";
            }

            if (gcAmount == ThreeColumn) return;
            if (gcAmount != null)
            {
                gcAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcAmount.SummaryItem.DisplayFormat = "TOTAL = {0:n2}";
            }

        }

        private void CargaInspectionCertificateDetail()
        {
            List<InspectionCertificateDetailBE> lstTmpInspectionCertificateDetail = null;
            lstTmpInspectionCertificateDetail = new InspectionCertificateDetailBL().ListaTodosActivo(IdInspectionCertificate);

            foreach (InspectionCertificateDetailBE item in lstTmpInspectionCertificateDetail)
            {
                CInspectionCertificateDetail objE_InspectionCertificateDetail = new CInspectionCertificateDetail();
                objE_InspectionCertificateDetail.IdCompany = item.IdCompany;
                objE_InspectionCertificateDetail.IdInspectionCertificate = item.IdInspectionCertificate;
                objE_InspectionCertificateDetail.IdInspectionCertificateDetail = item.IdInspectionCertificateDetail;
                objE_InspectionCertificateDetail.IdProgramProductionDetail = item.IdProgramProductionDetail;
                objE_InspectionCertificateDetail.NumberPO = item.NumberPO;
                objE_InspectionCertificateDetail.NumberOI = item.NumberOI;
                objE_InspectionCertificateDetail.NameStyle = item.NameStyle;
                objE_InspectionCertificateDetail.Description = item.Description;
                objE_InspectionCertificateDetail.Dyelot = item.Dyelot;
                objE_InspectionCertificateDetail.Item = item.Item;
                objE_InspectionCertificateDetail.Color = item.Color;
                objE_InspectionCertificateDetail.POOrder = item.POOrder;
                objE_InspectionCertificateDetail.Pieces = item.Pieces;
                objE_InspectionCertificateDetail.Fob = item.Fob;
                objE_InspectionCertificateDetail.AmountCertificate = item.AmountCertificate;
                objE_InspectionCertificateDetail.Percents = item.Percents;
                objE_InspectionCertificateDetail.TipoOper = item.TipoOper;
                mListaInspectionCertificateDetailOrigen.Add(objE_InspectionCertificateDetail);
            }

            bsListadoInspectionCertificateDetail.DataSource = mListaInspectionCertificateDetailOrigen;
            gcInspectionCertificateDetail.DataSource = bsListadoInspectionCertificateDetail;
            gcInspectionCertificateDetail.RefreshDataSource();
        }

        #endregion

        public class CInspectionCertificateDetail
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdInspectionCertificate { get; set; }
            public Int32 IdInspectionCertificateDetail { get; set; }
            public Int32 IdProgramProductionDetail { get; set; }
            public String NumberPO { get; set; }
            public String NumberOI { get; set; }
            public String NameStyle { get; set; }
            public String Description { get; set; }
            public String Dyelot { get; set; }
            public String Item { get; set; }
            public String Color { get; set; }
            public Decimal POOrder { get; set; }
            public Decimal Pieces { get; set; }
            public Decimal Fob { get; set; }
            public Decimal AmountCertificate { get; set; }
            public Int32 Percents { get; set; }
            public Int32 TipoOper { get; set; }

            public CInspectionCertificateDetail()
            {

            }
        }

        
    }
}