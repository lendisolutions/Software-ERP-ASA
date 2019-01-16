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
    public partial class frmManSeasonEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SeasonBE> lstSeason;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SeasonBE pSeasonBE { get; set; }

        
        int _IdSeason = 0;

        public int IdSeason
        {
            get { return _IdSeason; }
            set { _IdSeason = value; }
        }

        #endregion

        #region "Eventos"

        public frmManSeasonEdit()
        {
            InitializeComponent();
        }

        private void frmManSeasonEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Season - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Season - Update";
                SeasonBE objE_Season = null;
                objE_Season = new SeasonBL().Selecciona(IdSeason);
                if (objE_Season != null)
                {
                    txtDescripcion.Text = objE_Season.NameSeason.Trim();
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
                    SeasonBL objBL_Season = new SeasonBL();
                    SeasonBE objSeason = new SeasonBE();

                    objSeason.IdSeason = IdSeason;
                    objSeason.NameSeason = txtDescripcion.Text;
                    objSeason.FlagState = true;
                    objSeason.Login = Parametros.strUsuarioLogin;
                    objSeason.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objSeason.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Season.Inserta(objSeason);
                    else
                        objBL_Season.Actualiza(objSeason);

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
                var Buscar = lstSeason.Where(oB => oB.NameSeason.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
