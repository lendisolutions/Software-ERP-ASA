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

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManCargoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<OccupationBE> lstCargo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public OccupationBE pOccupationBE { get; set; }

        int _IdOccupation = 0;

        public int IdOccupation
        {
            get { return _IdOccupation; }
            set { _IdOccupation = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManCargoEdit()
        {
            InitializeComponent();
        }

        private void frmManCargoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Occupation - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Occupation - Update";
                txtDescripcion.Text = pOccupationBE.NameOccupation.Trim();

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
                    OccupationBL objBL_Cargo = new OccupationBL();
                    OccupationBE objCargo = new OccupationBE();
                    objCargo.IdOccupation = IdOccupation;
                    objCargo.NameOccupation = txtDescripcion.Text;
                    objCargo.FlagState = true;
                    objCargo.Login = Parametros.strUsuarioLogin;
                    objCargo.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objCargo.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cargo.Inserta(objCargo);
                    else
                        objBL_Cargo.Actualiza(objCargo);

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
                var Buscar = lstCargo.Where(oB => oB.NameOccupation.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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