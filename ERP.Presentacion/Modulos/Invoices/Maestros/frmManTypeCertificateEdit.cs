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
    public partial class frmManTypeCertificateEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TypeCertificateBE> lstTypeCertificate;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TypeCertificateBE pTypeCertificateBE { get; set; }

        
        int _IdTypeCertificate = 0;

        public int IdTypeCertificate
        {
            get { return _IdTypeCertificate; }
            set { _IdTypeCertificate = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTypeCertificateEdit()
        {
            InitializeComponent();
        }

        private void frmManTypeCertificateEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TypeCertificate - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TypeCertificate - Update";
                TypeCertificateBE objE_TypeCertificate = null;
                objE_TypeCertificate = new TypeCertificateBL().Selecciona(IdTypeCertificate);
                if (objE_TypeCertificate != null)
                {
                    txtDescripcion.Text = objE_TypeCertificate.NameTypeCertificate.Trim();
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
                    TypeCertificateBL objBL_TypeCertificate = new TypeCertificateBL();
                    TypeCertificateBE objTypeCertificate = new TypeCertificateBE();

                    objTypeCertificate.IdTypeCertificate = IdTypeCertificate;
                    objTypeCertificate.NameTypeCertificate = txtDescripcion.Text;
                    objTypeCertificate.FlagState = true;
                    objTypeCertificate.Login = Parametros.strUsuarioLogin;
                    objTypeCertificate.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTypeCertificate.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TypeCertificate.Inserta(objTypeCertificate);
                    else
                        objBL_TypeCertificate.Actualiza(objTypeCertificate);

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
                var Buscar = lstTypeCertificate.Where(oB => oB.NameTypeCertificate.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
