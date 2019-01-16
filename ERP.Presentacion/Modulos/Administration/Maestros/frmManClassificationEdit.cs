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
    public partial class frmManClassificationEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClassificationBE> lstClassification;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ClassificationBE pClassificationBE { get; set; }

        
        int _IdClassification = 0;

        public int IdClassification
        {
            get { return _IdClassification; }
            set { _IdClassification = value; }
        }

        #endregion

        #region "Eventos"

        public frmManClassificationEdit()
        {
            InitializeComponent();
        }

        private void frmManClassificationEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Classification - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Classification - Update";
                ClassificationBE objE_Classification = null;
                objE_Classification = new ClassificationBL().Selecciona(IdClassification);
                if (objE_Classification != null)
                {
                    txtDescripcion.Text = objE_Classification.NameClassification.Trim();
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
                    ClassificationBL objBL_Classification = new ClassificationBL();
                    ClassificationBE objClassification = new ClassificationBE();

                    objClassification.IdClassification = IdClassification;
                    objClassification.NameClassification = txtDescripcion.Text;
                    objClassification.FlagState = true;
                    objClassification.Login = Parametros.strUsuarioLogin;
                    objClassification.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objClassification.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Classification.Inserta(objClassification);
                    else
                        objBL_Classification.Actualiza(objClassification);

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
                var Buscar = lstClassification.Where(oB => oB.NameClassification.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
