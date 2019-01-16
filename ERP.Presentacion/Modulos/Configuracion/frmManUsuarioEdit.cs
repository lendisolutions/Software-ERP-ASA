using System.ComponentModel;
using System;
using System.Collections.Generic;
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
using ERP.Presentacion.Criptografia;
using ERP.Presentacion.Modulos.Otros;
using ERP.BusinessLogic;
using ERP.BusinessEntity;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManUsuarioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        List<LoginAccessBE> pListaAccesoUsuario = new List<LoginAccessBE>();
        List<LoginClientDepartmentBE> pListaLoginClientDepartment = new List<LoginClientDepartmentBE>();
        List<AccessBE> pListaAcceso = new List<AccessBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public LoginBE pLoginBE { get; set; }

        bool find = false;

        int _IdProfile = 0;

        public int IdProfile
        {
            get { return _IdProfile; }
            set { _IdProfile = value; }
        }

        int _IdLogin = 0;

        public int IdLogin
        {
            get { return _IdLogin; }
            set { _IdLogin = value; }
        }

        int menuID = 0;

        int intIdEmployee = 0;
        
        #endregion

        #region "Eventos"

        public frmManUsuarioEdit()
        {
            InitializeComponent();
        }

        private void frmManUsuariosEdit_Load(object sender, EventArgs e)
        {
            PopulateMenu(0, new MenuBL().ListaTodosActivo(), null);
            CargarClientDepartment();


            BSUtils.LoaderLook(cboEmpresa, new CompanyBL().ListaTodosActivo(0), "NameCompany", "IdCompany", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboPerfil, new ProfileBL().ListaTodosActivo(), "NameProfile", "IdProfile", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Login - New";
                txtPersona.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Login - Update";

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                
                txtUsuario.Text = pLoginBE.Login;
                intIdEmployee = pLoginBE.IdEmployee;
                txtPersona.Text = pLoginBE.NameLogin;
                txtPassword.Text = objCrypto.DescifrarCadena(pLoginBE.Password);
                cboEmpresa.EditValue = pLoginBE.IdCompany;
                cboPerfil.EditValue = pLoginBE.IdProfile;
                chkMaster.EditValue = pLoginBE.FlagMaster;
                chkEstado.EditValue = pLoginBE.FlagState;
                
            }

            chkEstado.Checked = true;

            AccessByUserPerfilID(IdLogin, IdProfile);
            AccessByLoginDepartment(IdLogin);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = Parametros.Key;
                    objCrypto.IV = Parametros.IV;
                    string Password = "";
                    Password = objCrypto.CifrarCadena(this.txtPassword.Text.Trim());

                    LoginBL objBL_Login = new LoginBL();
                    LoginBE objLogin = new LoginBE();
                   
                    objLogin.IdCompany = int.Parse(cboEmpresa.EditValue.ToString());
                    objLogin.IdProfile = int.Parse(cboPerfil.EditValue.ToString());
                    objLogin.IdEmployee = intIdEmployee;
                    objLogin.NameLogin = txtPersona.Text.Trim();
                    objLogin.Login = txtUsuario.Text.Trim();
                    objLogin.Password = Password;
                    objLogin.FlagMaster = chkMaster.Checked;
                    objLogin.FlagState = chkEstado.Checked;
                    objLogin.LoginCrea = Parametros.strUsuarioLogin;
                    objLogin.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objLogin.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Login.Inserta(objLogin, pListaAccesoUsuario, pListaLoginClientDepartment);
                    }
                    else if (pOperacion == Operacion.Modificar)
                    {
                        objLogin.IdLogin = pLoginBE.IdLogin;
                        objBL_Login.Actualiza(objLogin, pListaAccesoUsuario, pListaLoginClientDepartment);

                    }

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

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;

                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        //private void CheckNotNodes(TreeNodeCollection col, Boolean check)
        //{
        //    foreach (TreeNode tN in col)
        //    {
        //        if (tN.Checked == check)
        //        {
        //            if (tN.Parent == null)
        //            {
        //                tN.Parent.Checked = false;
        //            }
        //            this.CheckNotNodes(tN.Nodes, check);
        //        }

                
        //    }
        //}

        private void CheckNodes(TreeNodeCollection col, int menuID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ';' });

                if (Convert.ToInt32(objectString[0]) == menuID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, menuID);
            }
        }

        private void CheckNodes(TreeNodeCollection col, string IdClientDepartment)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ',' });
                if (objectString[0].ToString() == IdClientDepartment)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }

                this.CheckNodes(tN.Nodes, IdClientDepartment);
            }
        }

        private void trwMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                //Para marcar y desmarcar todos los nodos            
                foreach (TreeNode oNodo in e.Node.Nodes)
                {
                    string[] objectString = oNodo.Tag.ToString().Split(new char[] { ';' });
                    //AGREGAR EL FLAG AQUI .....
                    if (find == false)
                        oNodo.Checked = e.Node.Checked;

                    //insertar en la lista solo las ventanas que es el ultimo nivel
                    if (e.Node.Checked == true)
                    {
                        //if (objectString[1] == "4")
                        //{
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //}
                    }
                    if (e.Node.Checked == false)
                    {
                        RemoveMenu(Convert.ToInt32(objectString[0]));
                    }
                }

                if (e.Node.Parent != null)
                {
                    string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                    //e.Node.Parent.Checked=true;
                    if (!e.Node.Checked == true)
                    {
                        //Desmarco
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Regular);
                        RemoveMenu(Convert.ToInt32(objectString[0]));

                    }
                    else
                    {
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Bold);
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //Marco
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trwMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                this.lblMenu.Text = e.Node.Text;
                menuID = Convert.ToInt32(objectString[0]);

                if (pListaAccesoUsuario.Count > 0)
                {
                    LoginAccessBE Acceso = pListaAccesoUsuario.Find(delegate(LoginAccessBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    if (Acceso != null)
                    {
                        //Mostrar datos en los checkbox
                        this.chkAllowRead.Checked = Acceso.FlagRead;
                        this.chkAllowWrite.Checked = Acceso.FlagAdd; ;
                        this.chkAllowUpdate.Checked = Acceso.FlagUpdate;
                        this.chkAllowDelete.Checked = Acceso.FlagDelete;
                        this.chkAllowPrint.Checked = Acceso.FlagPrint;
                    }
                    else
                    {
                        this.chkAllowRead.Checked = false;
                        this.chkAllowWrite.Checked = false;
                        this.chkAllowUpdate.Checked = false;
                        this.chkAllowDelete.Checked = false;
                        this.chkAllowPrint.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAllowRead_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoginAccessBE Acceso = pListaAccesoUsuario.Find(delegate(LoginAccessBE _Acc)
                {
                    if (_Acc.IdMenu == menuID)
                    {
                        return true;
                    }
                    return false;
                });

                if (Acceso != null)
                {
                    CheckBox obj = new CheckBox();
                    obj = (CheckBox)sender;

                    LoginAccessBE AccesoMenu = pListaAccesoUsuario.Find(delegate(LoginAccessBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    switch (obj.Name)
                    {
                        case "chkAllowRead":
                            if (IdLogin == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagRead = chkAllowRead.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagRead = chkAllowRead.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowWrite":
                            if (IdLogin == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagAdd = chkAllowWrite.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagAdd = chkAllowWrite.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowUpdate":
                            if (IdLogin == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagUpdate = chkAllowUpdate.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagUpdate = chkAllowUpdate.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowDelete":
                            if (IdLogin == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagDelete = chkAllowDelete.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagDelete = chkAllowDelete.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowPrint":
                            if (IdLogin == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagPrint = chkAllowPrint.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagPrint = chkAllowPrint.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPerfil_EditValueChanged(object sender, EventArgs e)
        {
            AccessByPerfilID(int.Parse(cboPerfil.GetColumnValue("IdProfile").ToString()));
        }

        private void tvwClientDepartment_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Para marcar y desmarcar todos los nodos            
            foreach (TreeNode oNodo in e.Node.Nodes)
            {
                string[] objectString = oNodo.Tag.ToString().Split(new char[] { ',' });

                if (find == false)
                    oNodo.Checked = e.Node.Checked;

                //insertar en el datatable solo las ventanas que es el ultimo nivel
                if (e.Node.Checked == true)
                {
                    if (find == false)
                    {

                        AgregarClientDepartment(oNodo.Parent.Tag.ToString(), objectString[0]);
                    }

                }
                if (e.Node.Checked == false)
                {
                    EliminarClientDepartment(oNodo.Parent.Tag.ToString(), objectString[0]);
                }
            }

            if (e.Node.Parent != null)
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });

                if (!e.Node.Checked == true)
                {
                    //Desmarco
                    e.Node.Parent.NodeFont = new Font(this.tvwClientDepartment.Font, FontStyle.Regular);
                    EliminarClientDepartment(e.Node.Parent.Tag.ToString(), objectString[0]);
                }
                else
                {
                    e.Node.Parent.NodeFont = new Font(this.tvwClientDepartment.Font, FontStyle.Bold);
                    if (find == false)
                        AgregarClientDepartment(e.Node.Parent.Tag.ToString(), objectString[0]);
                }
            }
        }

        #endregion

        #region "Metodos"

        public void PopulateMenu(int HijoID, List<MenuBE> pMenuAccess, TreeNode nodeParent)
        {
            try
            {
                var ListMenuHijos =
                    from p in pMenuAccess
                    where p.IdMenuFather == HijoID
                    select p;

                foreach (var HijoMenu in ListMenuHijos)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = HijoMenu.MenuDescription;
                    switch (HijoMenu.IdTypeMenu)
                    {
                        case 0:
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                            break;
                        default:
                            newNode.ImageIndex = 1;
                            newNode.SelectedImageIndex = 1;
                            break;
                    }

                    newNode.Tag = HijoMenu.IdMenu.ToString() + ";" + HijoMenu.IdTypeMenu.ToString();
                    if (nodeParent == null)
                    {
                        this.trwMenu.Nodes.Add(newNode);
                    }
                    else
                    {
                        nodeParent.Nodes.Add(newNode);
                    }
                    PopulateMenu(HijoMenu.IdMenu, pMenuAccess, newNode);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AddMenu(int IdMenu)
        {
            var Buscar = pListaAccesoUsuario.Where(oB => oB.IdMenu == IdMenu).ToList();
            if (Buscar.Count > 0)
            {

            }
            else
            {
                LoginAccessBE accesousuario = null;
                accesousuario = new LoginAccessBE();
                accesousuario.IdLogin = IdLogin;
                accesousuario.IdProfile = IdProfile;
                accesousuario.IdMenu = IdMenu;
                accesousuario.FlagRead = true;
                accesousuario.FlagAdd = true;
                accesousuario.FlagUpdate = true;
                accesousuario.FlagDelete = true;
                accesousuario.FlagPrint = true;
                accesousuario.FlagState = true;
                accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                pListaAccesoUsuario.Add(accesousuario);
            }
                
        }

        void RemoveMenu(int IdMenu)
        {
            //Borrar en bloque
            LoginAccessBE Acceso = pListaAccesoUsuario.Find(delegate(LoginAccessBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipoOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipoOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipoOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        void AccessByPerfilID(int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAcceso = new AccessBL().SeleccionaPerfil(perfilID);

                foreach (AccessBE item in pListaAcceso)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;

                //Llenamos la Lista de AccesoUsuario de acuerdo al perfil

                foreach (AccessBE item in pListaAcceso)
                {
                    LoginAccessBE accesousuario = null;
                    accesousuario = new LoginAccessBE();
                    accesousuario.IdLogin = IdLogin;
                    accesousuario.IdProfile = IdProfile;
                    accesousuario.IdMenu = item.IdMenu;
                    accesousuario.FlagRead = item.FlagRead;
                    accesousuario.FlagAdd = item.FlagAdd;
                    accesousuario.FlagUpdate = item.FlagUpdate;
                    accesousuario.FlagDelete = item.FlagDelete;
                    accesousuario.FlagPrint = item.FlagPrint;
                    accesousuario.FlagState = item.FlagState;
                    accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    pListaAccesoUsuario.Add(accesousuario);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AccessByUserPerfilID(int UserID, int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAccesoUsuario = new LoginAccessBL().SeleccionaUserPerfil(UserID, perfilID);

                foreach (LoginAccessBE item in pListaAccesoUsuario)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AccessByLoginDepartment(int IdUser)
        {
            try
            {
                CheckAllNodes(this.tvwClientDepartment.Nodes, false);

                pListaLoginClientDepartment = new LoginClientDepartmentBL().ListaLogin(IdUser);

                foreach (LoginClientDepartmentBE item in pListaLoginClientDepartment)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.tvwClientDepartment.Nodes, item.IdClientDepartment.ToString());

                    //if (pOperacion == Operacion.Modificar)
                    //    CheckNotNodes(this.tvwUnidadNegocio.Nodes, false);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AgregarClientDepartment(string IdClient, string IdClientDepartment)
        {
            var Buscar = pListaLoginClientDepartment.Where(oB => oB.IdClient.ToString() == IdClient && oB.IdClientDepartment.ToString() == IdClientDepartment).ToList();
            if (Buscar.Count > 0)
            {

            }
            else
            {
                LoginClientDepartmentBE loginclientdepartment = null;
                loginclientdepartment = new LoginClientDepartmentBE();
                loginclientdepartment.IdLoginClientDepartment = 0;
                loginclientdepartment.IdCompany = Convert.ToInt32(cboEmpresa.EditValue);
                loginclientdepartment.IdLogin = IdLogin;
                loginclientdepartment.IdClientDepartment = Convert.ToInt32(IdClientDepartment);
                loginclientdepartment.FlagState = true;
                loginclientdepartment.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                pListaLoginClientDepartment.Add(loginclientdepartment);
            }

        }

        void EliminarClientDepartment(string IdClient, string IdClientDepartment)
        {
            //Borrar en bloque
            LoginClientDepartmentBE Acceso = pListaLoginClientDepartment.Find(delegate (LoginClientDepartmentBE _Acc)
            {
                if (_Acc.IdClient.ToString() == IdClient && _Acc.IdClientDepartment.ToString() == IdClientDepartment)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipoOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipoOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipoOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }


        private bool ValidarIngreso()
        {
            bool flag = false;

            if (intIdEmployee == 0)
            {
                XtraMessageBox.Show("Select a Employee.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmpresa.Select();
                flag = true;
            }

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                XtraMessageBox.Show("Select a Company.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmpresa.Select();
                flag = true;
            }

            if (string.IsNullOrEmpty(cboPerfil.Text))
            {
                XtraMessageBox.Show("Select a Profile.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPerfil.Select();
                flag = true;
            }

            if (txtPersona.Text.ToString() == "")
            {
                XtraMessageBox.Show("Select a description.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPersona.Select();
                flag = true;
            }

            if (txtUsuario.Text.ToString() == "")
            {
                XtraMessageBox.Show("Enter Login.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Select();
                flag = true;
            }

            if (txtPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Enter Password.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarClientDepartment()
        {
            tvwClientDepartment.Nodes.Clear();

            List<ClientDepartmentBE> lstClientDepartment = null;
            lstClientDepartment = new ClientDepartmentBL().ListaClient(Parametros.intEmpresaId);
            foreach (var item in lstClientDepartment)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.NameClient;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = item.IdClient.ToString();
                tvwClientDepartment.Nodes.Add(nuevoNodo);

                List<ClientDepartmentBE> lstClientDepartmentName = null;
                lstClientDepartmentName = new ClientDepartmentBL().ListaTodosActivo(item.IdClient);
                foreach (var itemunidad in lstClientDepartmentName)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemunidad.NameDivision;
                    nuevoNodoChild.Tag = itemunidad.IdClientDepartment.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwClientDepartment.ExpandAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pEmployeeBE != null)
                {
                    intIdEmployee = frm.pEmployeeBE.IdEmployee;
                    txtPersona.Text = frm.pEmployeeBE.FullName;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        
    }
}