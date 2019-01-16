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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.Presentacion.Modulos.Otros;

namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegVendorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<VendorBE> lstVendor;
        public List<CVendorAddress> mListaVendorAddressOrigen = new List<CVendorAddress>();
        public List<CVendorContact> mListaVendorContactOrigen = new List<CVendorContact>();
        public List<CVendorClassification> mListaVendorClassificationOrigen = new List<CVendorClassification>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdVendor = 0;

        public int IdVendor
        {
            get { return _IdVendor; }
            set { _IdVendor = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegVendorEdit()
        {
            InitializeComponent();
        }

        private void frmRegVendorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEvaluation, new EvaluationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameEvaluation", "IdEvaluation", true);
            cboEvaluation.EditValue = 0;
            BSUtils.LoaderLook(cboStatus, new StatusBL().ListaTodosActivo(Parametros.intEmpresaId), "NameStatus", "IdStatus", true);
            cboEvaluation.EditValue = 0;
            deRevenueDate.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Vendor - New";
                CargaVendorClassificationNuevo();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Vendor - Update";

                VendorBE objE_Vendor = null;
                objE_Vendor = new VendorBL().Selecciona(IdVendor);
                if (objE_Vendor != null)
                {
                    IdVendor = objE_Vendor.IdVendor;
                    txtNameVendor.Text = objE_Vendor.NameVendor;
                    txtRuc.Text = objE_Vendor.Ruc;
                    cboStatus.EditValue = objE_Vendor.IdStatus;
                    cboEvaluation.EditValue = objE_Vendor.IdEvaluation;
                    deRevenueDate.EditValue = objE_Vendor.RevenueDate;
                    if (objE_Vendor.FlagNational)
                        chkNational.Checked = true;
                    else
                        chkNational.Checked = false;
                    if (objE_Vendor.FlagForeigner)
                        chkForeigner.Checked = true;
                    else
                        chkForeigner.Checked = false;
                    txtVendorCode.Text = objE_Vendor.Code;
                    txtCorporation.EditValue = objE_Vendor.Corporation;
                    txtRepresentative.EditValue = objE_Vendor.Representative;
                    txtCapacity.EditValue = objE_Vendor.Capacity;
                    txtNumberEmployees.EditValue = objE_Vendor.NumberEmployees;
                    txtSituation.Text = objE_Vendor.Situation;

                    CargaVendorClassificationModificar();
                }
            }

            CargaVendorAddress();
            CargaVendorContact();

            txtNameVendor.Focus();

        }

        private void nuevoVendorAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvVendorAddress.AddNewRow();
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdVendor", 0);
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdVendorAddress", 0);
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdType", 0);
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "NameType", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Email", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "WebPage", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Address", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdUbigeo", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "NomUbigeo", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "City", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "State", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "IdCountry", 0);
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "NameCountry", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Phone1", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Phone2", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Fax", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "Reference", "");
                gvVendorAddress.SetRowCellValue(gvVendorAddress.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvVendorAddress.FocusedColumn = gvVendorAddress.Columns["NameType"];
                gvVendorAddress.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarVendorAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdVendorAddress = 0;
                if (gvVendorAddress.GetFocusedRowCellValue("IdVendorAddress") != null)
                    IdVendorAddress = int.Parse(gvVendorAddress.GetFocusedRowCellValue("IdVendorAddress").ToString());
                VendorAddressBE objBE_VendorAddress = new VendorAddressBE();
                objBE_VendorAddress.IdVendorAddress = IdVendorAddress;
                objBE_VendorAddress.IdCompany = Parametros.intEmpresaId;
                objBE_VendorAddress.Login = Parametros.strUsuarioLogin;
                objBE_VendorAddress.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                VendorAddressBL objBL_VendorAddress = new VendorAddressBL();
                objBL_VendorAddress.Elimina(objBE_VendorAddress);
                gvVendorAddress.DeleteRow(gvVendorAddress.FocusedRowHandle);
                gvVendorAddress.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusType frm = new frmBusType();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvVendorAddress.FocusedRowHandle;
                        gvVendorAddress.SetRowCellValue(index, "IdType", frm._Be.IdType);
                        gvVendorAddress.SetRowCellValue(index, "NameType", frm._Be.NameType);

                        gvVendorAddress.FocusedColumn = gvVendorAddress.Columns["Email"];
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void gcTxtNomUbigeo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusUbigeo frm = new frmBusUbigeo();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvVendorAddress.FocusedRowHandle;
                        gvVendorAddress.SetRowCellValue(index, "IdUbigeo", frm._Be.IdUbigeo);
                        gvVendorAddress.SetRowCellValue(index, "NomUbigeo", frm._Be.NomUbigeo);

                        gvVendorAddress.FocusedColumn = gvVendorAddress.Columns["City"];
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusDestination frm = new frmBusDestination();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvVendorAddress.FocusedRowHandle;
                        gvVendorAddress.SetRowCellValue(index, "IdCountry", frm._Be.IdDestination);
                        gvVendorAddress.SetRowCellValue(index, "NameCountry", frm._Be.NameDestination);

                        gvVendorAddress.FocusedColumn = gvVendorAddress.Columns["Phone1"];
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoVendorContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvVendorContact.AddNewRow();
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "IdVendor", 0);
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "IdVendorContact", 0);
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Name", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "FirtsName", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Company", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Occupation", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "IdDestination", 0);
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "NameDestination", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Phone1", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Phone2", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "CelPhone", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Fax", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "Email", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "InformationAdditional", "");
                gvVendorContact.SetRowCellValue(gvVendorContact.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvVendorContact.FocusedColumn = gvVendorContact.Columns["Name"];
                gvVendorContact.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarVendorContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdVendorContact = 0;
                if (gvVendorContact.GetFocusedRowCellValue("IdVendorContact") != null)
                    IdVendorContact = int.Parse(gvVendorContact.GetFocusedRowCellValue("IdVendorContact").ToString());
                VendorContactBE objBE_VendorContact = new VendorContactBE();
                objBE_VendorContact.IdVendorContact = IdVendorContact;
                objBE_VendorContact.IdCompany = Parametros.intEmpresaId;
                objBE_VendorContact.Login = Parametros.strUsuarioLogin;
                objBE_VendorContact.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                VendorContactBL objBL_VendorContact = new VendorContactBL();
                objBL_VendorContact.Elimina(objBE_VendorContact);
                gvVendorContact.DeleteRow(gvVendorContact.FocusedRowHandle);
                gvVendorContact.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountryContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusDestination frm = new frmBusDestination();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvVendorContact.FocusedRowHandle;
                        gvVendorContact.SetRowCellValue(index, "IdDestination", frm._Be.IdDestination);
                        gvVendorContact.SetRowCellValue(index, "NameDestination", frm._Be.NameDestination);

                        gvVendorContact.FocusedColumn = gvVendorContact.Columns["Phone1"];
                    }
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
                    VendorBE objVendor = new VendorBE();
                    VendorBL objBL_Vendor = new VendorBL();

                    objVendor.IdVendor = IdVendor;
                    objVendor.NameVendor = txtNameVendor.Text;
                    objVendor.FlagNational = (chkNational.Checked) ? true : false;
                    objVendor.FlagForeigner = (chkForeigner.Checked) ? true : false;
                    objVendor.RevenueDate = Convert.ToDateTime(deRevenueDate.DateTime.ToShortDateString());
                    objVendor.IdStatus = (int)cboStatus.EditValue;
                    objVendor.Ruc = txtRuc.Text;
                    objVendor.NameVendor = txtNameVendor.Text;
                    objVendor.IdEvaluation = (int)cboEvaluation.EditValue;
                    objVendor.Code = txtVendorCode.Text;
                    objVendor.Corporation = txtCorporation.Text;
                    objVendor.Capacity = Convert.ToDecimal(txtCapacity.EditValue);
                    objVendor.Representative = txtRepresentative.Text;
                    objVendor.NumberEmployees = Convert.ToInt32(txtNumberEmployees.EditValue);
                    objVendor.FlagState = true;
                    objVendor.Login = Parametros.strUsuarioLogin;
                    objVendor.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objVendor.IdCompany = Parametros.intEmpresaId;

                    //Vendor ADDRESS
                    List<VendorAddressBE> lstVendorAddress = new List<VendorAddressBE>();

                    foreach (var item in mListaVendorAddressOrigen)
                    {
                        VendorAddressBE objE_VendorAddress = new VendorAddressBE();
                        objE_VendorAddress.IdCompany = Parametros.intEmpresaId;
                        objE_VendorAddress.IdVendor = IdVendor;
                        objE_VendorAddress.IdVendorAddress = item.IdVendorAddress;
                        objE_VendorAddress.IdType = item.IdType;
                        objE_VendorAddress.Email = item.Email;
                        objE_VendorAddress.WebPage = item.WebPage;
                        objE_VendorAddress.Address = item.Address;
                        objE_VendorAddress.IdUbigeo = item.IdUbigeo;
                        objE_VendorAddress.City = item.City;
                        objE_VendorAddress.State = item.State;
                        objE_VendorAddress.IdCountry = item.IdCountry;
                        objE_VendorAddress.Phone1 = item.Phone1;
                        objE_VendorAddress.Phone2 = item.Phone2;
                        objE_VendorAddress.Fax = item.Fax;
                        objE_VendorAddress.Reference = item.Reference;
                        objE_VendorAddress.FlagState = true;
                        objE_VendorAddress.Login = Parametros.strUsuarioLogin;
                        objE_VendorAddress.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_VendorAddress.TipoOper = item.TipoOper;
                        lstVendorAddress.Add(objE_VendorAddress);
                    }

                    //Vendor CONTACT
                    List<VendorContactBE> lstVendorContact = new List<VendorContactBE>();

                    foreach (var item in mListaVendorContactOrigen)
                    {
                        VendorContactBE objE_VendorContact = new VendorContactBE();
                        objE_VendorContact.IdCompany = Parametros.intEmpresaId;
                        objE_VendorContact.IdVendor = IdVendor;
                        objE_VendorContact.IdVendorContact = item.IdVendorContact;
                        objE_VendorContact.Name = item.Name;
                        objE_VendorContact.FirstName = item.FirtsName;
                        objE_VendorContact.Company = item.Company;
                        objE_VendorContact.Occupation = item.Occupation;
                        objE_VendorContact.IdDestination = item.IdDestination;
                        objE_VendorContact.Phone1 = item.Phone1;
                        objE_VendorContact.Phone2 = item.Phone2;
                        objE_VendorContact.CelPhone = item.CelPhone;
                        objE_VendorContact.Fax = item.Fax;
                        objE_VendorContact.Email = item.Email;
                        objE_VendorContact.InformationAdditional = item.InformationAdditional;
                        objE_VendorContact.FlagState = true;
                        objE_VendorContact.Login = Parametros.strUsuarioLogin;
                        objE_VendorContact.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_VendorContact.TipoOper = item.TipoOper;
                        lstVendorContact.Add(objE_VendorContact);
                    }

                    //Vendor Classification
                    List<VendorClassificationBE> lstVendorClassification = new List<VendorClassificationBE>();

                    foreach (var item in mListaVendorClassificationOrigen)
                    {
                        VendorClassificationBE objE_VendorClassification = new VendorClassificationBE();
                        objE_VendorClassification.IdCompany = Parametros.intEmpresaId;
                        objE_VendorClassification.IdVendor = IdVendor;
                        objE_VendorClassification.IdVendorClassification = item.IdVendorClassification;
                        objE_VendorClassification.IdClassification = item.IdClassification;
                        objE_VendorClassification.NameClassification = item.NameClassification;
                        objE_VendorClassification.FlagActive = item.FlagActive;
                        objE_VendorClassification.FlagState = true;
                        objE_VendorClassification.Login = Parametros.strUsuarioLogin;
                        objE_VendorClassification.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_VendorClassification.TipoOper = item.TipoOper;
                        lstVendorClassification.Add(objE_VendorClassification);
                    }

                    
                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Vendor.Inserta(objVendor, lstVendorAddress, lstVendorContact, lstVendorClassification);
                        XtraMessageBox.Show("the vendor record was created.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_Vendor.Actualiza(objVendor, lstVendorAddress, lstVendorContact, lstVendorClassification);
                        XtraMessageBox.Show("the vendor record was updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CargaVendorAddress()
        {
            List<VendorAddressBE> lstTmpVendorAddress = null;
            lstTmpVendorAddress = new VendorAddressBL().ListaTodosActivo(IdVendor);

            foreach (VendorAddressBE item in lstTmpVendorAddress)
            {
                CVendorAddress objE_VendorAddress = new CVendorAddress();
                objE_VendorAddress.IdCompany = item.IdCompany;
                objE_VendorAddress.IdVendor = item.IdVendor;
                objE_VendorAddress.IdVendorAddress = item.IdVendorAddress;
                objE_VendorAddress.IdType = item.IdType;
                objE_VendorAddress.NameType = item.NameType;
                objE_VendorAddress.Email = item.Email;
                objE_VendorAddress.WebPage = item.WebPage;
                objE_VendorAddress.Address = item.Address;
                objE_VendorAddress.IdUbigeo = item.IdUbigeo;
                objE_VendorAddress.NomUbigeo = item.NomUbigeo;
                objE_VendorAddress.City = item.City;
                objE_VendorAddress.State = item.State;
                objE_VendorAddress.IdCountry = item.IdCountry;
                objE_VendorAddress.NameCountry = item.NameCountry;
                objE_VendorAddress.Phone1 = item.Phone1;
                objE_VendorAddress.Phone2 = item.Phone2;
                objE_VendorAddress.Fax = item.Fax;
                objE_VendorAddress.Reference = item.Reference;
                objE_VendorAddress.TipoOper = item.TipoOper;
                mListaVendorAddressOrigen.Add(objE_VendorAddress);
            }

            bsListadoVendorAddress.DataSource = mListaVendorAddressOrigen;
            gcVendorAddress.DataSource = bsListadoVendorAddress;
            gcVendorAddress.RefreshDataSource();
        }

        private void CargaVendorContact()
        {
            List<VendorContactBE> lstTmpVendorContact = null;
            lstTmpVendorContact = new VendorContactBL().ListaTodosActivo(IdVendor);

            foreach (VendorContactBE item in lstTmpVendorContact)
            {
                CVendorContact objE_VendorContact = new CVendorContact();
                objE_VendorContact.IdCompany = item.IdCompany;
                objE_VendorContact.IdVendor = item.IdVendor;
                objE_VendorContact.IdVendorContact = item.IdVendorContact;
                objE_VendorContact.Name = item.Name;
                objE_VendorContact.FirtsName = item.FirstName;
                objE_VendorContact.Company = item.Company;
                objE_VendorContact.Occupation = item.Occupation;
                objE_VendorContact.IdDestination = item.IdDestination;
                objE_VendorContact.NameDestination = item.NameDestination;
                objE_VendorContact.Phone1 = item.Phone1;
                objE_VendorContact.Phone2 = item.Phone2;
                objE_VendorContact.CelPhone = item.CelPhone;
                objE_VendorContact.Fax = item.Fax;
                objE_VendorContact.Email = item.Email;
                objE_VendorContact.InformationAdditional = item.InformationAdditional;
                objE_VendorContact.TipoOper = item.TipoOper;
                mListaVendorContactOrigen.Add(objE_VendorContact);
            }

            bsListadoVendorContact.DataSource = mListaVendorContactOrigen;
            gcVendorContact.DataSource = bsListadoVendorContact;
            gcVendorContact.RefreshDataSource();
        }

        private void CargaVendorClassificationNuevo()
        {
            List<ClassificationBE> lstClassification = null;
            lstClassification = new ClassificationBL().ListaTodosActivo(Parametros.intEmpresaId);

            foreach (ClassificationBE item in lstClassification)
            {
                CVendorClassification objE_VendorClassification = new CVendorClassification();
                objE_VendorClassification.IdCompany = item.IdCompany;
                objE_VendorClassification.IdVendor = 0;
                objE_VendorClassification.IdVendorClassification = 0;
                objE_VendorClassification.IdClassification = item.IdClassification;
                objE_VendorClassification.NameClassification = item.NameClassification;
                objE_VendorClassification.FlagActive = false;
                objE_VendorClassification.TipoOper = (int)Operacion.Consultar;
                mListaVendorClassificationOrigen.Add(objE_VendorClassification);
            }

            bsListadoVendorClassification.DataSource = mListaVendorClassificationOrigen;
            gcVendorClassification.DataSource = bsListadoVendorClassification;
            gcVendorClassification.RefreshDataSource();
        }

        private void CargaVendorClassificationModificar()
        {
            List<VendorClassificationBE> lstTmpVendorClassification = null;
            lstTmpVendorClassification = new VendorClassificationBL().ListaTodosActivo(IdVendor);

            foreach (VendorClassificationBE item in lstTmpVendorClassification)
            {
                CVendorClassification objE_VendorClassification = new CVendorClassification();
                objE_VendorClassification.IdCompany = item.IdCompany;
                objE_VendorClassification.IdVendor = item.IdVendor;
                objE_VendorClassification.IdVendorClassification = item.IdVendorClassification;
                objE_VendorClassification.IdClassification = item.IdClassification;
                objE_VendorClassification.NameClassification = item.NameClassification;
                objE_VendorClassification.FlagActive = item.FlagActive;
                objE_VendorClassification.TipoOper = item.TipoOper;
                mListaVendorClassificationOrigen.Add(objE_VendorClassification);
            }

            bsListadoVendorClassification.DataSource = mListaVendorClassificationOrigen;
            gcVendorClassification.DataSource = bsListadoVendorClassification;
            gcVendorClassification.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";

            if (txtNameVendor.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the vendors's name.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        public class CVendorAddress
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdVendor { get; set; }
            public Int32 IdVendorAddress { get; set; }
            public Int32 IdType { get; set; }
            public String NameType { get; set; }
            public String Email { get; set; }
            public String WebPage { get; set; }
            public String Address { get; set; }
            public String IdUbigeo { get; set; }
            public String NomUbigeo { get; set; }
            public String City { get; set; }
            public String State { get; set; }
            public Int32 IdCountry { get; set; }
            public String NameCountry { get; set; }
            public String Phone1 { get; set; }
            public String Phone2 { get; set; }
            public String Fax { get; set; }
            public String Reference { get; set; }
            public Int32 TipoOper { get; set; }

            public CVendorAddress()
            {

            }
        }

        public class CVendorContact
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdVendor { get; set; }
            public Int32 IdVendorContact { get; set; }
            public String Name { get; set; }
            public String FirtsName { get; set; }
            public String Company { get; set; }
            public String Occupation { get; set; }
            public Int32 IdDestination { get; set; }
            public String NameDestination { get; set; }
            public String Phone1 { get; set; }
            public String Phone2 { get; set; }
            public String CelPhone { get; set; }
            public String Fax { get; set; }
            public String Email { get; set; }
            public String InformationAdditional { get; set; }
            public Int32 TipoOper { get; set; }

            public CVendorContact()
            {

            }
        }

        public class CVendorClassification
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdVendor { get; set; }
            public Int32 IdVendorClassification { get; set; }
            public Int32 IdClassification { get; set; }
            public String NameClassification { get; set; }
            public Boolean FlagActive { get; set; }
            public Int32 TipoOper { get; set; }

            public CVendorClassification()
            {

            }
        }

        
    }
}