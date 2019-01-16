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
    public partial class frmManTallaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TallaBE> lstTalla;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TallaBE pTallaBE { get; set; }

        
        int _IdTalla = 0;

        public int IdTalla
        {
            get { return _IdTalla; }
            set { _IdTalla = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTallaEdit()
        {
            InitializeComponent();
        }

        private void frmManTallaEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Talla - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Talla - Update";
                TallaBE objE_Talla = null;
                objE_Talla = new TallaBL().Selecciona(IdTalla);
                if (objE_Talla != null)
                {
                    txtDescripcion.Text = objE_Talla.NameTalla.Trim();
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
                    TallaBL objBL_Talla = new TallaBL();
                    TallaBE objTalla = new TallaBE();

                    objTalla.IdTalla = IdTalla;
                    objTalla.NameTalla = txtDescripcion.Text;
                    objTalla.FlagState = true;
                    objTalla.Login = Parametros.strUsuarioLogin;
                    objTalla.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTalla.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Talla.Inserta(objTalla);
                    else
                        objBL_Talla.Actualiza(objTalla);

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
                var Buscar = lstTalla.Where(oB => oB.NameTalla.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
