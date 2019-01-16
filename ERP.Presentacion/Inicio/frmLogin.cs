using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using DevExpress.XtraEditors;
using ERP.Presentacion.Criptografia;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Inicio
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                
            }
        }

        private void cboUnidadMinera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnIngresar_Click(sender,e);
            }
        }

        #endregion

        #region "Metodos"

        private void CargarControles()
        {
            BSUtils.LoaderLook(cboEmpresa, new CompanyBL().ListaCombo(), "NameCompany", "IdCompany", true);
            txtUsuario.Text = ConfigurationManager.AppSettings.Get("Usuario");
            //txtContraseña.Text = ConfigurationManager.AppSettings.Get("Clave");

            if (txtContraseña.Text.Trim().Length > 0)
            {
                txtContraseña.Focus();
            }
            else
                txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboEmpresa.Text))
                {
                    XtraMessageBox.Show("Seleccione la empresa", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEmpresa.Focus();
                    return;
                }

                if (txtUsuario.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese el usuario.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Focus();
                    return;
                }

                if (txtContraseña.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese la contraseña.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtContraseña.Focus();
                    return;
                }

                

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(txtContraseña.Text.ToString());
                LoginBE objE_Usuario = new LoginBL().LogOnUser(txtUsuario.Text.ToString().Trim(), _password);
                if (objE_Usuario != null)
                {
                    
                    Parametros.intPerfilId = objE_Usuario.IdProfile;
                    Parametros.strNomPerfil = objE_Usuario.NameProfile;
                    Parametros.intEmpresaId = int.Parse(cboEmpresa.EditValue.ToString());
                    Parametros.intPersonaId = objE_Usuario.IdEmployee;
                    Parametros.strEmpresaNombre = cboEmpresa.Text;
                    Parametros.intUsuarioId = objE_Usuario.IdLogin;
                    Parametros.strUsuarioLogin = objE_Usuario.Login;
                    Parametros.strUsuarioNombres = objE_Usuario.FullName;

                    //GUARDAR EN EL APP.Config
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["Usuario"].Value = txtUsuario.Text.Trim();
                    //config.AppSettings.Settings["Clave"].Value = txtContraseña.Text.Trim();
                    config.Save(ConfigurationSaveMode.Modified);


                    //OBTENEMOS TODOS LOS PERMISOS DE LOS USUARIO LOGUEADOS
                    Parametros.pListaPermisoAcceso = new LoginAccessBL().SeleccionaPermisoAcceso(objE_Usuario.Login, objE_Usuario.IdProfile).ToList();

                    //TRAEMOS LA IMAGEN GENERAL DE LA EMPRESA SELECCIONADA
                    CompanyBE objE_Company = null;
                    objE_Company = new CompanyBL().Selecciona(Parametros.intEmpresaId);
                    if (objE_Company != null)
                    {
                        picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Company.Logo);
                        Parametros.strRutaLogo = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");
                        picImage.Image.Save(Parametros.strRutaLogo, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    

                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    XtraMessageBox.Show("Usuario / Clave incorrecta.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        #endregion

        
    }
}