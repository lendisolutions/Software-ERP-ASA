﻿using System;
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
    public partial class frmManTypeDesignEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TypeDesignBE> lstTypeDesign;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TypeDesignBE pTypeDesignBE { get; set; }

        
        int _IdTypeDesign = 0;

        public int IdTypeDesign
        {
            get { return _IdTypeDesign; }
            set { _IdTypeDesign = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTypeDesignEdit()
        {
            InitializeComponent();
        }

        private void frmManTypeDesignEdit_Load(object sender, EventArgs e)
        {
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TypeDesign - New";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TypeDesign - Update";
                TypeDesignBE objE_TypeDesign = null;
                objE_TypeDesign = new TypeDesignBL().Selecciona(IdTypeDesign);
                if (objE_TypeDesign != null)
                {
                    txtDescripcion.Text = objE_TypeDesign.NameTypeDesign.Trim();
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
                    TypeDesignBL objBL_TypeDesign = new TypeDesignBL();
                    TypeDesignBE objTypeDesign = new TypeDesignBE();

                    objTypeDesign.IdTypeDesign = IdTypeDesign;
                    objTypeDesign.NameTypeDesign = txtDescripcion.Text;
                    objTypeDesign.FlagState = true;
                    objTypeDesign.Login = Parametros.strUsuarioLogin;
                    objTypeDesign.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objTypeDesign.IdCompany = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TypeDesign.Inserta(objTypeDesign);
                    else
                        objBL_TypeDesign.Actualiza(objTypeDesign);

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
                var Buscar = lstTypeDesign.Where(oB => oB.NameTypeDesign.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
