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
    public partial class frmManGroupStyleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<GroupStyleBE> lstGroupStyle;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public GroupStyleBE pGroupStyleBE { get; set; }

        
        int _IdGroupStyle = 0;

        public int IdGroupStyle
        {
            get { return _IdGroupStyle; }
            set { _IdGroupStyle = value; }
        }

        #endregion

        #region "Eventos"

        public frmManGroupStyleEdit()
        {
            InitializeComponent();
        }

        private void frmManGroupStyleEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "GroupStyle - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "GroupStyle - Update";
                GroupStyleBE objE_GroupStyle = null;
                objE_GroupStyle = new GroupStyleBL().Selecciona(IdGroupStyle);
                if (objE_GroupStyle != null)
                {
                    txtDescripcion.Text = objE_GroupStyle.NameGroupStyle.Trim();
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
                    GroupStyleBL objBL_GroupStyle = new GroupStyleBL();
                    GroupStyleBE objGroupStyle = new GroupStyleBE();

                    objGroupStyle.IdGroupStyle = IdGroupStyle;
                    objGroupStyle.NameGroupStyle = txtDescripcion.Text;
                    objGroupStyle.FlagState = true;
                    objGroupStyle.Login = Parametros.strUsuarioLogin;
                    objGroupStyle.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objGroupStyle.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_GroupStyle.Inserta(objGroupStyle);
                    else
                        objBL_GroupStyle.Actualiza(objGroupStyle);

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
                var Buscar = lstGroupStyle.Where(oB => oB.NameGroupStyle.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
