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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.BusinessLogic;
using ERP.BusinessEntity;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        public List<CompanyBE> lstEmpresa;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCompany = 0;

        public int IdCompany
        {
            get { return _IdCompany; }
            set { _IdCompany = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmManEmpresaEdit_Load(object sender, EventArgs e)
        {
            

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Company - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Company Update";

                CompanyBE objE_Empresa = new CompanyBE();

                objE_Empresa = new CompanyBL().Selecciona(IdCompany);

                IdCompany = objE_Empresa.IdCompany;
                txtRuc.Text = objE_Empresa.Ruc;
                txtRazonSocial.Text = objE_Empresa.NameCompany;
                txtDireccion.Text = objE_Empresa.Address;
                txtTelefono.Text = objE_Empresa.Phone;
                txtActividadEconomica.Text = objE_Empresa.EconomyActivity;
                
                if (objE_Empresa.Logo != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Empresa.Logo);
                }
                else
                { this.picImage.Image = ERP.Presentacion.Properties.Resources.noImage; }
            }

            txtRuc.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ERP.Presentacion.Properties.Resources.noImage;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CompanyBL objBL_Empresa = new CompanyBL();
                    CompanyBE objE_Empresa = new CompanyBE();

                    objE_Empresa.IdCompany = IdCompany;
                    objE_Empresa.Ruc = txtRuc.Text;
                    objE_Empresa.NameCompany = txtRazonSocial.Text;
                    objE_Empresa.Address = txtDireccion.Text;
                    objE_Empresa.Phone = txtTelefono.Text;
                    objE_Empresa.EconomyActivity = txtActividadEconomica.Text;
                    objE_Empresa.Logo = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Empresa.FlagState = true;
                    objE_Empresa.Login = Parametros.strUsuarioLogin;
                    objE_Empresa.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Empresa.Inserta(objE_Empresa);
                    else
                        objBL_Empresa.Actualiza(objE_Empresa);

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

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtActividadEconomica.Focus();
            }
        }

        private void txtActividadEconomica_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txtRuc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter to RUC.\n";
                flag = true;
            }

            if (txtRazonSocial.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter name company.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstEmpresa.Where(oB => oB.Ruc.ToUpper() == txtRuc.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Ruc already exists.\n";
                    flag = true;
                }

                var BuscarRazonSocial = lstEmpresa.Where(oB => oB.NameCompany.ToUpper() == txtRazonSocial.Text.ToUpper()).ToList();
                if (BuscarRazonSocial.Count > 0)
                {
                    strMensaje = strMensaje + "- Name company already exists.\n";
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