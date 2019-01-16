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

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManPersonaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EmployeeBE> lstPersona;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public EmployeeBE pEmployeeBE { get; set; }

        public Operacion pOperacion { get; set; }

        

        int _IdWorkArea = 0;

        public int IdWorkArea
        {
            get { return _IdWorkArea; }
            set { _IdWorkArea = value; }
        }

        int _IdEmployee = 0;

        public int IdEmployee
        {
            get { return _IdEmployee; }
            set { _IdEmployee = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPersonaEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSexo, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblGender), "NameElementTablet", "IdElementTablet", true);
            BSUtils.LoaderLook(cboEstadoCivil, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCivilStatus), "NameElementTablet", "IdElementTablet", true);
            BSUtils.LoaderLook(cboCargo, new OccupationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameOccupation", "IdOccupation", true);
            BSUtils.LoaderLook(cboArea, new WorkAreaBL().ListaTodosActivo(Parametros.intEmpresaId), "NameWorkArea", "IdWorkArea", true);
            cboArea.EditValue = IdWorkArea;
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartament", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;
            BSUtils.LoaderLook(cboSituacion, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblEmployeeSituation), "NameElementTablet", "IdElementTablet", true);

            deFechaNac.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Employee - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Employee - Update";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                EmployeeBE objE_Persona = new EmployeeBE();

                objE_Persona = new EmployeeBL().Selecciona(0,0,IdEmployee);
                if (objE_Persona != null)
                {
                    txtDni.EditValue = objE_Persona.DocumentNumber;
                    cboSexo.EditValue = objE_Persona.IdGender;
                    cboEstadoCivil.EditValue = objE_Persona.IdCivilStatus;
                    txtApellidos.EditValue = objE_Persona.LastName;
                    txtNombres.EditValue = objE_Persona.Name;
                    txtEssalud.EditValue = objE_Persona.Essalud;
                    txtBrevete.EditValue = objE_Persona.License;
                    deFechaNac.EditValue = objE_Persona.BithDate;
                    chkEPS.Checked = objE_Persona.FlagEps;
                    chkSCTR.Checked = objE_Persona.FlagSctr;
                    cboCargo.EditValue = objE_Persona.IdOccupation;

                    if (objE_Persona.IdUbigeo.Trim() != "")
                        IdDepartamento = objE_Persona.IdUbigeo.Substring(0, 2);
                    cboDepartamento.EditValue = IdDepartamento;
                    if (objE_Persona.IdUbigeo.Trim() != "")
                        IdProvincia = objE_Persona.IdUbigeo.Substring(2, 2);
                    cboProvincia.EditValue = IdProvincia;
                    if (objE_Persona.IdUbigeo.Trim() != "")
                        IdDistrito = objE_Persona.IdUbigeo.Substring(4, 2);
                    cboDistrito.EditValue = IdDistrito;

                    txtDireccion.EditValue = objE_Persona.Address;
                    txtTelefono.EditValue = objE_Persona.Phone;
                    txtCelular1.EditValue = objE_Persona.CelPhone1;
                    txtCelular2.EditValue = objE_Persona.CelPhone2;
                    txtEmail.EditValue = objE_Persona.Email;

                    if (objE_Persona.Photo != null)
                    {
                        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Persona.Photo);
                    }
                    else
                    { this.picImage.Image = ERP.Presentacion.Properties.Resources.noImage; }
                    txtObservacion.EditValue = objE_Persona.Comment;
                    cboArea.EditValue = objE_Persona.IdWorkArea;
                    cboSituacion.EditValue = objE_Persona.IdSituation;
                }
                
               
            }

            txtDni.Select();

        }

        
        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincie", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrict", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName),640,500);
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
                    EmployeeBL objBL_Persona = new EmployeeBL();
                    EmployeeBE objE_Persona = new EmployeeBE();

                    
                    objE_Persona.IdEmployee = IdEmployee;
                    objE_Persona.IdWorkArea = Convert.ToInt32(cboArea.EditValue);
                    objE_Persona.DocumentNumber = txtDni.Text;
                    objE_Persona.Name = txtNombres.Text;
                    objE_Persona.LastName = txtApellidos.Text;
                    objE_Persona.FullName = txtApellidos.Text + " " + txtNombres.Text;
                    objE_Persona.IdGender = Convert.ToInt32(cboSexo.EditValue);
                    objE_Persona.IdOccupation = Convert.ToInt32(cboCargo.EditValue);
                    objE_Persona.Essalud = txtEssalud.Text;
                    if (chkEPS.Checked)
                        objE_Persona.FlagEps = true;
                    else
                        objE_Persona.FlagEps = false;
                    if (chkSCTR.Checked)
                        objE_Persona.FlagSctr = true;
                    else
                        objE_Persona.FlagSctr = false;
                   
                    objE_Persona.License = txtBrevete.Text;
                    objE_Persona.IdCivilStatus = Convert.ToInt32(cboEstadoCivil.EditValue);
                    objE_Persona.BithDate = Convert.ToDateTime(deFechaNac.EditValue);
                    objE_Persona.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_Persona.Address = txtDireccion.Text;
                    objE_Persona.Phone = txtTelefono.Text;
                    objE_Persona.CelPhone1 = txtCelular1.Text;
                    objE_Persona.CelPhone2 = txtCelular2.Text;
                    objE_Persona.Email = txtEmail.Text;
                    objE_Persona.Photo = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Persona.Comment = txtObservacion.Text;
                    objE_Persona.IdSituation = Convert.ToInt32(cboSituacion.EditValue);
                    objE_Persona.FlagState = true; //true;
                    objE_Persona.Login = Parametros.strUsuarioLogin;
                    objE_Persona.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Persona.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Persona.Inserta(objE_Persona);
                    else
                        objBL_Persona.Actualiza(objE_Persona);

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

            if (txtDni.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter document number.\n";
                flag = true;
            }

            if (txtNombres.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter name.\n";
                flag = true;
            }

            if (txtApellidos.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Enter lastname.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPersona.Where(oB => oB.DocumentNumber.ToUpper() == txtDni.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Document number already exists.\n";
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