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
    public partial class frmManCurrencyEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CurrencyBE> lstCurrency;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CurrencyBE pCurrencyBE { get; set; }

        
        int _IdCurrency = 0;

        public int IdCurrency
        {
            get { return _IdCurrency; }
            set { _IdCurrency = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCurrencyEdit()
        {
            InitializeComponent();
        }

        private void frmManCurrencyEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Currency - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Currency - Update";
                CurrencyBE objE_Currency = null;
                objE_Currency = new CurrencyBL().Selecciona(IdCurrency);
                if (objE_Currency != null)
                {
                    txtAbbreviate.Text = objE_Currency.Abbreviate;
                    txtDescripcion.Text = objE_Currency.NameCurrency.Trim();
                }

            }

            txtAbbreviate.Select();
        }

        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CurrencyBL objBL_Currency = new CurrencyBL();
                    CurrencyBE objCurrency = new CurrencyBE();

                    objCurrency.IdCurrency = IdCurrency;
                    objCurrency.Abbreviate = txtAbbreviate.Text;
                    objCurrency.NameCurrency = txtDescripcion.Text;
                    objCurrency.FlagState = true;
                    objCurrency.Login = Parametros.strUsuarioLogin;
                    objCurrency.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objCurrency.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Currency.Inserta(objCurrency);
                    else
                        objBL_Currency.Actualiza(objCurrency);

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
                var Buscar = lstCurrency.Where(oB => oB.NameCurrency.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
