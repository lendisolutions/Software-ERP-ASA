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
using ERP.BusinessLogic;
using ERP.BusinessEntity;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManPerfilEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<AccessBE> pListaAccess = new List<AccessBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ProfileBE pPerfilBE { get; set; }

        bool find = false;

        int _IdProfile = 0;

        public int IdProfile
        {
            get { return _IdProfile; }
            set { _IdProfile = value; }
        }

        int menuID = 0;
        
        #endregion

        #region "Eventos"

        public frmManPerfilEdit()
        {
            InitializeComponent();
        }

        private void frmManPerfilEdit_Load(object sender, EventArgs e)
        {
            PopulateMenu(0, new MenuBL().ListaTodosActivo(), null);

            AccessByPerfilID(IdProfile);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Profile - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Profile - New";
                txtDescripcion.Text = pPerfilBE.NameProfile.Trim();
                chkEstado.Checked = pPerfilBE.FlagState;
            }

            txtDescripcion.Select();
            chkEstado.Checked = true;
        }

        private void btnGrabar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProfileBL objBL_Perfil = new ProfileBL();

                    ProfileBE objPerfil = new ProfileBE();
                    objPerfil.IdProfile = IdProfile;
                    objPerfil.NameProfile = txtDescripcion.Text;
                    objPerfil.FlagState = chkEstado.Checked;
                    objPerfil.Login = Parametros.strUsuarioLogin;
                    objPerfil.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objPerfil.IdCompany = Parametros.intEmpresaId;
                   
                    if (pOperacion == Operacion.Nuevo)
                        objBL_Perfil.Inserta(objPerfil, pListaAccess);
                    else
                        objBL_Perfil.Actualiza(objPerfil, pListaAccess);

                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
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

                    //insertar en el datatable solo las ventanas que es el ultimo nivel
                    if (e.Node.Checked == true)
                    {
                        if (objectString[1] == "4")
                        {
                            //AGREGAR EL FLAG AQUI .....
                            if (find == false)
                                AddMenu(Convert.ToInt32(objectString[0]));
                        }
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

                if (pListaAccess.Count > 0)
                {
                    AccessBE Access = pListaAccess.Find(delegate(AccessBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    if (Access != null)
                    {
                        //Mostrar datos en los checkbox
                        this.chkAllowRead.Checked = Access.FlagRead;
                        this.chkAllowWrite.Checked = Access.FlagAdd; ;
                        this.chkAllowUpdate.Checked = Access.FlagUpdate; ;
                        this.chkAllowDelete.Checked = Access.FlagDelete;
                        this.chkAllowPrint.Checked = Access.FlagPrint; ;
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

        private void chkAllowRead_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                AccessBE Access = pListaAccess.Find(delegate(AccessBE _Acc)
                {
                    if (_Acc.IdMenu == menuID)
                    {
                        return true;
                    }
                    return false;
                });

                if (Access != null)
                {
                    CheckBox obj = new CheckBox();
                    obj = (CheckBox)sender;

                    AccessBE AccessMenu = pListaAccess.Find(delegate(AccessBE _Acc)
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
                            if (IdProfile == 0)
                            {
                                if (AccessMenu != null)
                                {
                                    AccessMenu.FlagRead = chkAllowRead.Checked;
                                }
                            }
                            else
                            {
                                AccessMenu.FlagRead = chkAllowRead.Checked;

                                if (AccessMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccessMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowWrite":
                            if (IdProfile == 0)
                            {
                                if (AccessMenu != null)
                                {
                                    AccessMenu.FlagAdd = chkAllowWrite.Checked;
                                }
                            }
                            else
                            {
                                AccessMenu.FlagAdd = chkAllowWrite.Checked;

                                if (AccessMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccessMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowUpdate":
                            if (IdProfile == 0)
                            {
                                if (AccessMenu != null)
                                {
                                    AccessMenu.FlagUpdate = chkAllowUpdate.Checked;
                                }
                            }
                            else
                            {
                                AccessMenu.FlagUpdate = chkAllowUpdate.Checked;

                                if (AccessMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccessMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowDelete":
                            if (IdProfile == 0)
                            {
                                if (AccessMenu != null)
                                {
                                    AccessMenu.FlagDelete = chkAllowDelete.Checked;
                                }
                            }
                            else
                            {
                                AccessMenu.FlagDelete = chkAllowDelete.Checked;

                                if (AccessMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccessMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowPrint":
                            if (IdProfile == 0)
                            {
                                if (AccessMenu != null)
                                {
                                    AccessMenu.FlagPrint = chkAllowPrint.Checked;
                                }
                            }
                            else
                            {
                                AccessMenu.FlagPrint = chkAllowPrint.Checked;

                                if (AccessMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccessMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
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
            //verificar que no exista
            AccessBE Accesso = pListaAccess.Find(delegate(AccessBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });

            if (Accesso == null)
            {
                AccessBE Access = null;
                Access = new AccessBE();
                Access.IdProfile = IdProfile;
                Access.IdMenu = IdMenu;
                Access.FlagRead = true;
                Access.FlagAdd = true;
                Access.FlagUpdate = true;
                Access.FlagDelete = true;
                Access.FlagPrint = true;
                Access.FlagState = true;
                Access.TipOper = Convert.ToInt32(Operacion.Nuevo);
                pListaAccess.Add(Access);
            }
            else
            {
                if (IdProfile != 0)
                {
                    if (Accesso.TipOper != Convert.ToInt32(Operacion.Eliminar))
                    {
                        if (Accesso.TipOper == Convert.ToInt32(Operacion.Modificar))
                        { Accesso.TipOper = Convert.ToInt32(Operacion.Nuevo); }
                        if (Accesso.TipOper == Convert.ToInt32(Operacion.Consultar))
                        { Accesso.TipOper = Convert.ToInt32(Operacion.Nuevo); }
                    }
                }
            }
        }


        void RemoveMenu(int IdMenu)
        {
            //Borrar en bloque
            AccessBE Access = pListaAccess.Find(delegate(AccessBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });
            if (Access != null)
            {
                if (Access.TipOper == Convert.ToInt32(Operacion.Nuevo))
                { Access.TipOper = Convert.ToInt32(Operacion.Consultar); }
                if (Access.TipOper == Convert.ToInt32(Operacion.Modificar) || Access.TipOper == Convert.ToInt32(Operacion.Consultar))
                    Access.TipOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        void AccessByPerfilID(int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAccess = new AccessBL().SeleccionaPerfil(perfilID).ToList();

                foreach (AccessBE item in pListaAccess)
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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (txtDescripcion.Text.ToString() == "")
            {
                XtraMessageBox.Show("Enter the Profile description", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}