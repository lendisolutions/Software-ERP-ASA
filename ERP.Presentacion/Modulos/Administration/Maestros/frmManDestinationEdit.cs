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
    public partial class frmManDestinationEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DestinationBE> lstDestination;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DestinationBE pDestinationBE { get; set; }

        
        int _IdDestination = 0;

        public int IdDestination
        {
            get { return _IdDestination; }
            set { _IdDestination = value; }
        }

        #endregion

        #region "Eventos"

        public frmManDestinationEdit()
        {
            InitializeComponent();
        }

        private void frmManDestinationEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Destination - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Destination - Update";
                DestinationBE objE_Destination = null;
                objE_Destination = new DestinationBL().Selecciona(IdDestination);
                if (objE_Destination != null)
                {
                    txtDescripcion.Text = objE_Destination.NameDestination.Trim();
                    txtNumberLineCertificate.EditValue = objE_Destination.NumberLineCertificate;
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
                    DestinationBL objBL_Destination = new DestinationBL();
                    DestinationBE objDestination = new DestinationBE();

                    objDestination.IdDestination = IdDestination;
                    objDestination.NameDestination = txtDescripcion.Text;
                    objDestination.NumberLineCertificate = Convert.ToInt32(txtNumberLineCertificate.Text);
                    objDestination.FlagState = true;
                    objDestination.Login = Parametros.strUsuarioLogin;
                    objDestination.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objDestination.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Destination.Inserta(objDestination);
                    else
                        objBL_Destination.Actualiza(objDestination);

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
                var Buscar = lstDestination.Where(oB => oB.NameDestination.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
