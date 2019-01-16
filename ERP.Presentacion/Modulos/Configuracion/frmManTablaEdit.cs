using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManTablaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TabletBE> lstTabla;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TabletBE pTabletBE { get; set; }

        int _IdTablet = 0;

        public int IdTablet
        {
            get { return _IdTablet; }
            set { _IdTablet = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTablaEdit()
        {
            InitializeComponent();
        }

        private void frmManTablaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tablet - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tablet - Update";
                txtDescripcion.Text = pTabletBE.NameTablet.Trim();

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
                    TabletBL objBL_Tabla = new TabletBL();
                    TabletBE objTabla = new TabletBE();
                    objTabla.IdTablet = IdTablet;
                    objTabla.NameTablet = txtDescripcion.Text;
                    objTabla.FlagState = true;
                    objTabla.Login = Parametros.strUsuarioLogin;
                    objTabla.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTabla.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tabla.Inserta(objTabla);
                    else
                        objBL_Tabla.Actualiza(objTabla);

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
            string strMensaje = "No se pudo registrar:\n";
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter description.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTabla.Where(oB => oB.NameTablet.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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