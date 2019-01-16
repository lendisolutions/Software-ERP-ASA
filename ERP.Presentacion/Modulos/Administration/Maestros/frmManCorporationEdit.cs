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

namespace ERP.Presentacion.Modulos.Administration.Maestros
{
    public partial class frmManCorporationEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CorporationBE> lstCorporation;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CorporationBE pCorporationBE { get; set; }

        
        int _IdCorporation = 0;

        public int IdCorporation
        {
            get { return _IdCorporation; }
            set { _IdCorporation = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCorporationEdit()
        {
            InitializeComponent();
        }

        private void frmManCorporationEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Corporation - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Corporation - Update";
                CorporationBE objE_Corporation = null;
                objE_Corporation = new CorporationBL().Selecciona(IdCorporation);
                if (objE_Corporation != null)
                {
                    txtDescripcion.Text = objE_Corporation.NameCorporation.Trim();
                    txtPrefix.Text = objE_Corporation.FrefixInvoice;
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
                    CorporationBL objBL_Corporation = new CorporationBL();
                    CorporationBE objCorporation = new CorporationBE();

                    objCorporation.IdCorporation = IdCorporation;
                    objCorporation.NameCorporation = txtDescripcion.Text;
                    objCorporation.FrefixInvoice = txtPrefix.Text;
                    objCorporation.FlagState = true;
                    objCorporation.Login = Parametros.strUsuarioLogin;
                    objCorporation.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objCorporation.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Corporation.Inserta(objCorporation);
                    else
                        objBL_Corporation.Actualiza(objCorporation);

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
                var Buscar = lstCorporation.Where(oB => oB.NameCorporation.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
