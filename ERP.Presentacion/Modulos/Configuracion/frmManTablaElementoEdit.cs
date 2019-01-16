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

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManTablaElementoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ElementTabletBE> lstTablaElemento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ElementTabletBE pElementTabletBE { get; set; }

        int _IdTablet = 0;

        public int IdTablet
        {
            get { return _IdTablet; }
            set { _IdTablet = value; }
        }

        int _IdElementTablet = 0;

        public int IdElementTablet
        {
            get { return _IdElementTablet; }
            set { _IdElementTablet = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTablaElementoEdit()
        {
            InitializeComponent();
        }

        private void frmManTablaElementoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTabla, new TabletBL().ListaTodosActivo(Parametros.intEmpresaId), "NameTablet", "IdTablet", true);
            cboTabla.EditValue = IdTablet;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Element Tablet - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Element Tablet - Update";
                txtAbreviatura.Text = pElementTabletBE.Abbreviate;
                txtDescripcion.Text = pElementTabletBE.NameElementTablet;
            }

            txtAbreviatura.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ElementTabletBL objBL_TablaElemento = new ElementTabletBL();

                    ElementTabletBE objTablaElemento = new ElementTabletBE();
                    objTablaElemento.IdTablet = IdTablet;
                    objTablaElemento.IdElementTablet = IdElementTablet;
                    objTablaElemento.Abbreviate = txtAbreviatura.Text;
                    objTablaElemento.NameElementTablet = txtDescripcion.Text;
                    objTablaElemento.FlagState = true;
                    objTablaElemento.Login = Parametros.strUsuarioLogin;
                    objTablaElemento.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTablaElemento.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TablaElemento.Inserta(objTablaElemento);
                    else
                        objBL_TablaElemento.Actualiza(objTablaElemento);

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

        private void txtAbreviatura_KeyPress(object sender, KeyPressEventArgs e)
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
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboTabla.Text))
            {
                strMensaje = strMensaje + "- Select a tablet. \n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter description. \n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTablaElemento.Where(oB => oB.NameElementTablet.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Description already exists. \n";
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