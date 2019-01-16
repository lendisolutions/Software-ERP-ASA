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
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegStyleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<StyleBE> lstStyle;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public StyleBE pStyleBE { get; set; }

        public Operacion pOperacion { get; set; }

        int _IdClient = 0;

        public int IdClient
        {
            get { return _IdClient; }
            set { _IdClient = value; }
        }

        int _IdStyle = 0;

        public int IdStyle
        {
            get { return _IdStyle; }
            set { _IdStyle = value; }
        }


        #endregion

        #region "Eventos"

        public frmRegStyleEdit()
        {
            InitializeComponent();
        }

        private void frmRegStyleEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new ClientBL().ListaTodosActivo(Parametros.intEmpresaId), "NameClient", "IdClient", true);
            cboClient.EditValue = IdClient;
            deRevenueDate.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboDivision, new ClientDepartmentBL().ListaTodosActivo(IdClient), "NameDivision", "IdClientDepartment", true);
            BSUtils.LoaderLook(cboMediaUnit, new MediaUnitBL().ListaTodosActivo(Parametros.intEmpresaId), "NameMediaUnit", "IdMediaUnit", true);
            cboMediaUnit.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Style - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Style - Update";

                StyleBE objE_Style = new StyleBE();

                objE_Style = new StyleBL().Selecciona(IdStyle);
                if (objE_Style != null)
                {
                    cboClient.EditValue = objE_Style.IdClient;
                    txtNameStyle.Text = objE_Style.NameStyle;
                    deRevenueDate.DateTime = objE_Style.RevenueDate;
                    txtDescription.Text = objE_Style.Description;
                    txtItem.Text = objE_Style.Item;
                    cboDivision.EditValue = objE_Style.IdClientDepartment;
                    cboMediaUnit.EditValue = objE_Style.IdMediaUnit;
                }


            }

            txtNameStyle.Focus();
        }

        private void txtNameStyle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deRevenueDate.Focus();
            }
        }

        private void deRevenueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtItem.Focus();
            }
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboDivision.Focus();
            }
        }

        private void cboDivision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboMediaUnit.Focus();
            }
        }

        private void cboMediaUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    StyleBL objBL_Style = new StyleBL();
                    StyleBE objStyle = new StyleBE();

                    objStyle.IdStyle = IdStyle;
                    objStyle.IdClient = IdClient;
                    objStyle.NameStyle = txtNameStyle.Text;
                    objStyle.RevenueDate = Convert.ToDateTime(deRevenueDate.EditValue);
                    objStyle.Description = txtDescription.Text;
                    objStyle.Item = txtItem.Text;
                    objStyle.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                    objStyle.IdMediaUnit = Convert.ToInt32(cboMediaUnit.EditValue);
                    objStyle.FlagState = true;
                    objStyle.Login = Parametros.strUsuarioLogin;
                    objStyle.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objStyle.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Style.Inserta(objStyle);
                    else
                        objBL_Style.Actualiza(objStyle);

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";
            if (txtNameStyle.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter Name Style.\n";
                flag = true;
            }

            if (txtDescription.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter description.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstStyle.Where(oB => oB.NameStyle.ToUpper() == txtDescription.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Name Style already exists.\n";
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