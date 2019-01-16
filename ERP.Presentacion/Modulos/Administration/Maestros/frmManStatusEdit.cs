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
    public partial class frmManStatusEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<StatusBE> lstStatus;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public StatusBE pStatusBE { get; set; }

        
        int _IdStatus = 0;

        public int IdStatus
        {
            get { return _IdStatus; }
            set { _IdStatus = value; }
        }

        #endregion

        #region "Eventos"

        public frmManStatusEdit()
        {
            InitializeComponent();
        }

        private void frmManStatusEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Status - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Status - Update";
                StatusBE objE_Status = null;
                objE_Status = new StatusBL().Selecciona(IdStatus);
                if (objE_Status != null)
                {
                    txtDescripcion.Text = objE_Status.NameStatus.Trim();
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
                    StatusBL objBL_Status = new StatusBL();
                    StatusBE objStatus = new StatusBE();

                    objStatus.IdStatus = IdStatus;
                    objStatus.NameStatus = txtDescripcion.Text;
                    objStatus.FlagState = true;
                    objStatus.Login = Parametros.strUsuarioLogin;
                    objStatus.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objStatus.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Status.Inserta(objStatus);
                    else
                        objBL_Status.Actualiza(objStatus);

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
                var Buscar = lstStatus.Where(oB => oB.NameStatus.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
