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
    public partial class frmManEvaluationEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EvaluationBE> lstEvaluation;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public EvaluationBE pEvaluationBE { get; set; }

        
        int _IdEvaluation = 0;

        public int IdEvaluation
        {
            get { return _IdEvaluation; }
            set { _IdEvaluation = value; }
        }

        #endregion

        #region "Eventos"

        public frmManEvaluationEdit()
        {
            InitializeComponent();
        }

        private void frmManEvaluationEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Evaluation - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Evaluation - Update";
                EvaluationBE objE_Evaluation = null;
                objE_Evaluation = new EvaluationBL().Selecciona(IdEvaluation);
                if (objE_Evaluation != null)
                {
                    txtDescripcion.Text = objE_Evaluation.NameEvaluation.Trim();
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
                    EvaluationBL objBL_Evaluation = new EvaluationBL();
                    EvaluationBE objEvaluation = new EvaluationBE();

                    objEvaluation.IdEvaluation = IdEvaluation;
                    objEvaluation.NameEvaluation = txtDescripcion.Text;
                    objEvaluation.FlagState = true;
                    objEvaluation.Login = Parametros.strUsuarioLogin;
                    objEvaluation.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objEvaluation.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Evaluation.Inserta(objEvaluation);
                    else
                        objBL_Evaluation.Actualiza(objEvaluation);

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
                var Buscar = lstEvaluation.Where(oB => oB.NameEvaluation.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
