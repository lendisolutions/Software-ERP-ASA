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
    public partial class frmManPhaseEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PhaseBE> lstPhase;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PhaseBE pPhaseBE { get; set; }

        
        int _IdPhase = 0;

        public int IdPhase
        {
            get { return _IdPhase; }
            set { _IdPhase = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPhaseEdit()
        {
            InitializeComponent();
        }

        private void frmManPhaseEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Phase - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Phase - Update";
                PhaseBE objE_Phase = null;
                objE_Phase = new PhaseBL().Selecciona(IdPhase);
                if (objE_Phase != null)
                {
                    txtDescripcion.Text = objE_Phase.NamePhase.Trim();
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
                    PhaseBL objBL_Phase = new PhaseBL();
                    PhaseBE objPhase = new PhaseBE();

                    objPhase.IdPhase = IdPhase;
                    objPhase.NamePhase = txtDescripcion.Text;
                    objPhase.FlagState = true;
                    objPhase.Login = Parametros.strUsuarioLogin;
                    objPhase.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objPhase.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Phase.Inserta(objPhase);
                    else
                        objBL_Phase.Actualiza(objPhase);

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
                var Buscar = lstPhase.Where(oB => oB.NamePhase.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
