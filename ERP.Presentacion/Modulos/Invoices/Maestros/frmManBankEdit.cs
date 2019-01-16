using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;

namespace ERP.Presentacion.Modulos.Invoices.Maestros
{
    public partial class frmManBankEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<BankBE> lstBank;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public BankBE pBankBE { get; set; }

        
        int _IdBank = 0;

        public int IdBank
        {
            get { return _IdBank; }
            set { _IdBank = value; }
        }

        #endregion

        #region "Eventos"

        public frmManBankEdit()
        {
            InitializeComponent();
        }

        private void frmManBankEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboCurrency, new CurrencyBL().ListaCombo(Parametros.intEmpresaId), "NameCurrency", "IdCurrency", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Bank - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Bank - Update";
                BankBE objE_Bank = null;
                objE_Bank = new BankBL().Selecciona(IdBank);
                if (objE_Bank != null)
                {
                    txtSwift.Text = objE_Bank.Swift;
                    txtDescripcion.Text = objE_Bank.NameBank.Trim();
                    cboCurrency.EditValue = objE_Bank.IdCurrency;
                    txtNumberCtaCte.Text = objE_Bank.NumberCtaCte;
                    txtCodeAba.Text = objE_Bank.CodeAba;
                    txtAddress.Text = objE_Bank.Address;
                    txtPhone.Text = objE_Bank.Phone;
                    txtContact.Text = objE_Bank.Contac;
                }

            }

            txtDescripcion.Select();
        }

        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    BankBL objBL_Bank = new BankBL();
                    BankBE objBank = new BankBE();

                    objBank.IdBank = IdBank;
                    objBank.Swift = txtSwift.Text;
                    objBank.NameBank = txtDescripcion.Text;
                    objBank.IdCurrency = Convert.ToInt32(cboCurrency.EditValue);
                    objBank.NumberCtaCte = txtNumberCtaCte.Text;
                    objBank.CodeAba = txtCodeAba.Text;
                    objBank.Address = txtAddress.Text;
                    objBank.Phone = txtPhone.Text;
                    objBank.Contac = txtContact.Text;
                    objBank.FlagState = true;
                    objBank.Login = Parametros.strUsuarioLogin;
                    objBank.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objBank.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Bank.Inserta(objBank);
                    else
                        objBL_Bank.Actualiza(objBank);

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

        private void cboUnidadMinera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter description.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstBank.Where(oB => oB.NameBank.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Description already exists.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        
        
        
    }
}
