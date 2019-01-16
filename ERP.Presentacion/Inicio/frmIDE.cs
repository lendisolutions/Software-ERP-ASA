using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Criptografia;
using System.Security.Principal;
using ERP.Presentacion.Utils;
using System.Globalization;
using System.Threading;

namespace ERP.Presentacion.Inicio
{
    public partial class frmIDE : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        Ribbon _ribbon;

        public frmIDE()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
        }

        void _ribbon_RibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase)
        {
            try
            {
                Application.DoEvents();
                

                if (ensamblado == "")
                {
                    MessageBox.Show("Objeto no implementado en la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (modoCarga == "1")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "2")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "9")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void frmIDE_Load(object sender, EventArgs e)
        {
            //frmImage f = new frmImage();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();

            //comprobamos si se han pasado parámetros 
            if (Environment.GetCommandLineArgs().Length > 1)
            {
               
                //String[] parametros = Environment.GetCommandLineArgs();

                string srtUsuario = Environment.GetCommandLineArgs()[1];
                string srtClave = Environment.GetCommandLineArgs()[2];
                string srtNombre = Environment.GetCommandLineArgs()[3];
                string srtCodUnidadP = Environment.GetCommandLineArgs()[4];
                string srtCodCentroP = Environment.GetCommandLineArgs()[5];

                //srtUsuario = parametros[0].ToString();
                //srtClave = parametros[1].ToString();
                //srtNombre = parametros[2].ToString();
                //srtCodUnidadP = parametros[3].ToString();
                //srtCodCentroP = parametros[4].ToString();

                //for (int i = 0; i < parametros.Length; i++)
                //{
                //    MessageBox.Show("Parámetro " + parametros[i]);
                //}

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(srtClave);
                LoginBE objE_Usuario = new LoginBL().LogOnUser(srtUsuario.Trim(), _password);
                if (objE_Usuario != null)
                {
                    Parametros.intPerfilId = objE_Usuario.IdProfile;
                    Parametros.strNomPerfil = objE_Usuario.NameProfile;
                    Parametros.intEmpresaId = objE_Usuario.IdCompany;
                    Parametros.strEmpresaNombre = objE_Usuario.NameCompany;
                    Parametros.intUsuarioId = objE_Usuario.IdLogin;
                    Parametros.strUsuarioLogin = objE_Usuario.Login;
                    Parametros.strUsuarioNombres = objE_Usuario.FullName;

                    //Obtenemos todos los permisos del usuario logueado
                    Parametros.pListaPermisoAcceso = new LoginAccessBL().SeleccionaPermisoAcceso(objE_Usuario.Login, objE_Usuario.IdProfile).ToList();

                }
                
                //Aqui se carga los menus del usuario en el Control Ribbon
                _ribbon = new Ribbon(this.ribbon, new LoginAccessBL().SeleccionaUser(Parametros.intUsuarioId).ToList());
                _ribbon.Fill();
                _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);

                //Carga el Status Bar
                BarButtonItem stbButtonEmpresa = new DevExpress.XtraBars.BarButtonItem();
                stbButtonEmpresa.Caption = Parametros.strEmpresaNombre;

                BarButtonItem stbButtonUsuario = new DevExpress.XtraBars.BarButtonItem();
                stbButtonUsuario.Caption = "USUARIO : " + Parametros.strUsuarioNombres;
                stbButtonUsuario.Alignment = BarItemLinkAlignment.Right;

                ribbonStatusBar.ItemLinks.Add(stbButtonEmpresa);
                ribbonStatusBar.ItemLinks.Add(stbButtonUsuario);

                if (Parametros.intPerfilId == 3)
                {
                    Cursor = Cursors.WaitCursor;
                    XtraForm form = new XtraForm();
                    form = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("ERP.Presentacion.Modulos.IPERCBase.Registros.frmRegPlanilla");
                    form.MdiParent = this;
                    form.Text = "IPERC-Base";
                    form.Tag = "ERP.Presentacion.Modulos.IPERCBase.Registros.frmRegPlanilla";
                    form.Show();
                    Cursor = Cursors.Default;

                }
            }
            else
            {
                tmr_ProgramProductionDate.Enabled = true;
                tmr_ProgramProductionDate.Start();

                //Cargamos el Login
                Application.DoEvents();
                frmLogin fLogin = new frmLogin();
                fLogin.Owner = this;
                fLogin.ShowDialog();
                if (fLogin.DialogResult == DialogResult.Yes)
                {


                    //Aqui se carga los menus del usuario en el Control Ribbon
                    _ribbon = new Ribbon(this.ribbon, new LoginAccessBL().SeleccionaUser(Parametros.intUsuarioId).ToList());
                    _ribbon.Fill();
                    _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);

                    //Carga el Status Bar
                    BarButtonItem stbButtonEmpresa = new DevExpress.XtraBars.BarButtonItem();
                    stbButtonEmpresa.Caption = Parametros.strEmpresaNombre;

                    BarButtonItem stbButtonUsuario = new DevExpress.XtraBars.BarButtonItem();
                    stbButtonUsuario.Caption = "LOGIN : " + Parametros.strUsuarioNombres;
                    stbButtonUsuario.Alignment = BarItemLinkAlignment.Right;

                    ribbonStatusBar.ItemLinks.Add(stbButtonEmpresa);
                    ribbonStatusBar.ItemLinks.Add(stbButtonUsuario);

                    //-------------------------------------------------------------------------------------------------------------------------------
                    fLogin.Close();
                    fLogin.Dispose();

                }
                else
                { Application.Exit(); };
            } 
            
        }

        public bool FormCheched(string titulo)
        {
            bool valor = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == titulo)
                    valor = true;
                else
                    valor = false;
            }

            return valor;
        }

        private void frmIDE_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}