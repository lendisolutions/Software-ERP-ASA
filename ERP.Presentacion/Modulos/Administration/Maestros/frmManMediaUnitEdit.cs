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
    public partial class frmManMediaUnitEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MediaUnitBE> lstMediaUnit;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public MediaUnitBE pMediaUnitBE { get; set; }

        
        int _IdMediaUnit = 0;

        public int IdMediaUnit
        {
            get { return _IdMediaUnit; }
            set { _IdMediaUnit = value; }
        }

        #endregion

        #region "Eventos"

        public frmManMediaUnitEdit()
        {
            InitializeComponent();
        }

        private void frmManMediaUnitEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "MediaUnit - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "MediaUnit - Update";
                MediaUnitBE objE_MediaUnit = null;
                objE_MediaUnit = new MediaUnitBL().Selecciona(IdMediaUnit);
                if (objE_MediaUnit != null)
                {
                    txtAbbreviate.Text = objE_MediaUnit.Abbreviate;
                    txtDescripcion.Text = objE_MediaUnit.NameMediaUnit.Trim();
                }

            }

            txtAbbreviate.Select();
        }

        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MediaUnitBL objBL_MediaUnit = new MediaUnitBL();
                    MediaUnitBE objMediaUnit = new MediaUnitBE();

                    objMediaUnit.IdMediaUnit = IdMediaUnit;
                    objMediaUnit.Abbreviate = txtAbbreviate.Text;
                    objMediaUnit.NameMediaUnit = txtDescripcion.Text;
                    objMediaUnit.FlagState = true;
                    objMediaUnit.Login = Parametros.strUsuarioLogin;
                    objMediaUnit.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objMediaUnit.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MediaUnit.Inserta(objMediaUnit);
                    else
                        objBL_MediaUnit.Actualiza(objMediaUnit);

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
                var Buscar = lstMediaUnit.Where(oB => oB.NameMediaUnit.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
