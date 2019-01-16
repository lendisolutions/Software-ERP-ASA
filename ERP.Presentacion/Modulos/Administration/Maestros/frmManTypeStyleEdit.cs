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
    public partial class frmManTypeStyleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TypeStyleBE> lstTypeStyle;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TypeStyleBE pTypeStyleBE { get; set; }

        
        int _IdTypeStyle = 0;

        public int IdTypeStyle
        {
            get { return _IdTypeStyle; }
            set { _IdTypeStyle = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTypeStyleEdit()
        {
            InitializeComponent();
        }

        private void frmManTypeStyleEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TypeStyle - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TypeStyle - Update";
                TypeStyleBE objE_TypeStyle = null;
                objE_TypeStyle = new TypeStyleBL().Selecciona(IdTypeStyle);
                if (objE_TypeStyle != null)
                {
                    txtDescripcion.Text = objE_TypeStyle.NameTypeStyle.Trim();
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
                    TypeStyleBL objBL_TypeStyle = new TypeStyleBL();
                    TypeStyleBE objTypeStyle = new TypeStyleBE();

                    objTypeStyle.IdTypeStyle = IdTypeStyle;
                    objTypeStyle.NameTypeStyle = txtDescripcion.Text;
                    objTypeStyle.FlagState = true;
                    objTypeStyle.Login = Parametros.strUsuarioLogin;
                    objTypeStyle.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTypeStyle.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TypeStyle.Inserta(objTypeStyle);
                    else
                        objBL_TypeStyle.Actualiza(objTypeStyle);

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
                var Buscar = lstTypeStyle.Where(oB => oB.NameTypeStyle.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
