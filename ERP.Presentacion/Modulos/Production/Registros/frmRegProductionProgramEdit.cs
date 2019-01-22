using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Modulos.Production.Rpt;
using CrystalDecisions.Shared;

namespace ERP.Presentacion.Modulos.Production.Registros
{
    public partial class frmRegProductionProgramEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProgramProductionBE> lstProgramProduction;
        public List<CProgramProductionDetail> mListaProgramProductionDetailOrigen = new List<CProgramProductionDetail>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdProgramProduction = 0;

        public int IdProgramProduction
        {
            get { return _IdProgramProduction; }
            set { _IdProgramProduction = value; }
        }

        public int IdClient { get; set; }
        public int IdDivision { get; set; }
        public int IdStyle { get; set; }
        public string NameStyle { get; set; }
        public string Description { get; set; }

        public Boolean bCopy = false;

        #endregion

        #region "Eventos"

        public frmRegProductionProgramEdit()
        {
            InitializeComponent();
        }

        private void frmRegProductionProgramEdit_Load(object sender, EventArgs e)
        {
            if (IdClient != 7) //VINCE
                gvProgramProductionDetail.Columns["Dyelot"].Visible = false;


            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            cboClient.EditValue = IdClient;
            BSUtils.LoaderLook(cboVendor, new VendorBL().ListaTodosActivo(Parametros.intEmpresaId), "NameVendor", "IdVendor", true);
            BSUtils.LoaderLook(cboDestination, new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameDestination", "IdDestination", true);
            cboDestination.EditValue = 1;
            BSUtils.LoaderLook(cboSeason, new SeasonBL().ListaTodosActivo(Parametros.intEmpresaId), "NameSeason", "IdSeason", true);
            BSUtils.LoaderLook(cboTypeProduct, new TypeProductBL().ListaTodosActivo(Parametros.intEmpresaId), "NameTypeProduct", "IdTypeProduct", true);
            BSUtils.LoaderLook(cboShipMode, new ShipModeBL().ListaTodosActivo(Parametros.intEmpresaId), "NameShipMode", "IdShipMode", true);

            deXfDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deXfDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deXfDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deXfDate.Properties.CharacterCasing = CharacterCasing.Upper;

            deIndcDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deIndcDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deIndcDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deIndcDate.Properties.CharacterCasing = CharacterCasing.Upper;

            deXfDate.DateTime = DateTime.Now;
            deIndcDate.DateTime = DateTime.Now;

            

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Production Program - New";

                if (bCopy)
                {
                    ProgramProductionBE objE_ProgramProduction = null;
                    objE_ProgramProduction = new ProgramProductionBL().Selecciona(IdProgramProduction);
                    if (objE_ProgramProduction != null)
                    {
                        cboClient.EditValue = objE_ProgramProduction.IdClient;
                        cboDivision.EditValue = objE_ProgramProduction.IdClientDepartment;
                        cboVendor.EditValue = objE_ProgramProduction.IdVendor;
                        cboDestination.EditValue = objE_ProgramProduction.IdDestination;
                        cboSeason.EditValue = objE_ProgramProduction.IdSeason;
                        IdStyle = objE_ProgramProduction.IdStyle;
                        cboTypeProduct.EditValue = objE_ProgramProduction.IdTypeProduct;
                        txtNumberPO.Text = objE_ProgramProduction.NumberPO;
                        txtNumberCommiment.Text = objE_ProgramProduction.NumberCommiment;
                        deXfDate.EditValue = objE_ProgramProduction.XfDate;
                        deIndcDate.EditValue = objE_ProgramProduction.IndcDate;
                        cboShipMode.EditValue = objE_ProgramProduction.IdShipMode;
                        txtLabel.Text = objE_ProgramProduction.Label;
                        txtAddionational.Text = objE_ProgramProduction.Addionational;
                    }
                }

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Production Program - Update";

                ProgramProductionBE objE_ProgramProduction = null;
                objE_ProgramProduction = new ProgramProductionBL().Selecciona(IdProgramProduction);
                if (objE_ProgramProduction != null)
                {
                    IdProgramProduction = objE_ProgramProduction.IdProgramProduction;
                    txtNumero.Text = objE_ProgramProduction.NumberPP;
                    cboClient.EditValue = objE_ProgramProduction.IdClient;
                    cboDivision.EditValue = objE_ProgramProduction.IdClientDepartment;
                    cboVendor.EditValue = objE_ProgramProduction.IdVendor;
                    cboDestination.EditValue = objE_ProgramProduction.IdDestination;
                    cboSeason.EditValue = objE_ProgramProduction.IdSeason;
                    IdStyle = objE_ProgramProduction.IdStyle;
                    cboTypeProduct.EditValue = objE_ProgramProduction.IdTypeProduct;
                    txtNumberPO.Text = objE_ProgramProduction.NumberPO;
                    txtNumberCommiment.Text = objE_ProgramProduction.NumberCommiment;
                    deXfDate.EditValue = objE_ProgramProduction.XfDate;
                    deIndcDate.EditValue = objE_ProgramProduction.IndcDate;
                    cboShipMode.EditValue = objE_ProgramProduction.IdShipMode;
                    txtLabel.Text = objE_ProgramProduction.Label;
                    txtAddionational.Text = objE_ProgramProduction.Addionational;
                }
            }

            CargaProgramProductionDetail();

            if (mListaProgramProductionDetailOrigen.Count == 0)
                this.nuevoProgramProductionDetailToolStripMenuItem_Click(sender,e);
        }

        private void cboClient_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClient.EditValue != null)
            {
                BSUtils.LoaderLook(cboDivision, new LoginClientDepartmentBL().ListaClientDivision(Parametros.intUsuarioId, Convert.ToInt32(cboClient.EditValue)), "NameDivision", "IdClientDepartment", true);
                cboDivision.EditValue = IdDivision;
            }
        }

        private void nuevoProgramProductionDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaProgramProductionDetailOrigen.Count > 0)
            {
                gvProgramProductionDetail.AddNewRow();
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProduction", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProductionDetail", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdStyle", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].IdStyle);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "NameStyle", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].NameStyle);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Description", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Description);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Dyelot", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Dyelot);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Item", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Item);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Detail", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Detail);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Units", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Units);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Fob", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Fob);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Total", mListaProgramProductionDetailOrigen[mListaProgramProductionDetailOrigen.Count - 2].Total);
                
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Item"];
                gvProgramProductionDetail.ShowEditor();
            }
            else
            {
                gvProgramProductionDetail.AddNewRow();
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProduction", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProductionDetail", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdStyle", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "NameStyle", "");
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Description", "");
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Dyelot", "REG");
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Item", "");
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Detail", "");
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Units", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Fob", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Total", 0);
                gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["NameStyle"];
                gvProgramProductionDetail.ShowEditor();
            }
            
        }

        private void eliminarProgramProductionDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Be sure to delete the record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdProgramProductionDetail = 0;
                    if (gvProgramProductionDetail.GetFocusedRowCellValue("IdProgramProductionDetail") != null)
                        IdProgramProductionDetail = int.Parse(gvProgramProductionDetail.GetFocusedRowCellValue("IdProgramProductionDetail").ToString());
                    ProgramProductionDetailBE objBE_ProgramProductionDetail = new ProgramProductionDetailBE();
                    objBE_ProgramProductionDetail.IdProgramProductionDetail = IdProgramProductionDetail;
                    objBE_ProgramProductionDetail.IdCompany = Parametros.intEmpresaId;
                    objBE_ProgramProductionDetail.Login = Parametros.strUsuarioLogin;
                    objBE_ProgramProductionDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                    ProgramProductionDetailBL objBL_ProgramProductionDetail = new ProgramProductionDetailBL();
                    objBL_ProgramProductionDetail.Elimina(objBE_ProgramProductionDetail);
                    gvProgramProductionDetail.DeleteRow(gvProgramProductionDetail.FocusedRowHandle);
                    gvProgramProductionDetail.RefreshData();
                }
                    

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtNameStyle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cursor = Cursors.WaitCursor;
                    frmBusStyle frm = new frmBusStyle();
                    frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                    frm.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvProgramProductionDetail.FocusedRowHandle;

                        IdStyle = frm._Be.IdStyle;
                        NameStyle = frm._Be.NameStyle;
                        Description = frm._Be.Description;

                        gvProgramProductionDetail.SetRowCellValue(index, "IdStyle", IdStyle);
                        gvProgramProductionDetail.SetRowCellValue(index, "NameStyle", NameStyle);
                        gvProgramProductionDetail.SetRowCellValue(index, "Description", Description);

                        gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Item"];
                    }

                    Cursor = Cursors.Default;
                }
  
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtNameStyle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmBusStyle frm = new frmBusStyle();
                frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                frm.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    int index = gvProgramProductionDetail.FocusedRowHandle;

                    IdStyle = frm._Be.IdStyle;
                    NameStyle = frm._Be.NameStyle;
                    Description = frm._Be.Description;

                    gvProgramProductionDetail.SetRowCellValue(index, "IdStyle", IdStyle);
                    gvProgramProductionDetail.SetRowCellValue(index, "NameStyle", NameStyle);
                    gvProgramProductionDetail.SetRowCellValue(index, "Description", Description);

                    gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Item"];
                }

                Cursor = Cursors.Default;
                
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtNameStyle_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmBusStyle frm = new frmBusStyle();
                frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                frm.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    int index = gvProgramProductionDetail.FocusedRowHandle;

                    IdStyle = frm._Be.IdStyle;
                    NameStyle = frm._Be.NameStyle;
                    Description = frm._Be.Description;

                    gvProgramProductionDetail.SetRowCellValue(index, "IdStyle", IdStyle);
                    gvProgramProductionDetail.SetRowCellValue(index, "NameStyle", NameStyle);
                    gvProgramProductionDetail.SetRowCellValue(index, "Description", Description);

                    gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Item"];
                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvProgramProductionDetail_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "Style")
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    frmBusStyle frm = new frmBusStyle();
                    frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                    frm.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvProgramProductionDetail.FocusedRowHandle;

                        IdStyle = frm._Be.IdStyle;
                        NameStyle = frm._Be.NameStyle;
                        Description = frm._Be.Description;

                        gvProgramProductionDetail.SetRowCellValue(index, "IdStyle", IdStyle);
                        gvProgramProductionDetail.SetRowCellValue(index, "NameStyle", NameStyle);
                        gvProgramProductionDetail.SetRowCellValue(index, "Description", Description);

                        gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Item"];
                    }

                    Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void gvProgramProductionDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (mListaProgramProductionDetailOrigen.Count == 0)
            {
                return;
            }

            if (e.Column.Caption == "Units")
            {
                int index = gvProgramProductionDetail.FocusedRowHandle;

                decimal decUnits = 0;
                decimal decFob = 0;
                decimal decTotal = 0;

                decUnits = decimal.Parse(gvProgramProductionDetail.GetRowCellValue(index, gvProgramProductionDetail.Columns["Units"]).ToString());
                decFob = decimal.Parse(gvProgramProductionDetail.GetRowCellValue(index, gvProgramProductionDetail.Columns["Fob"]).ToString());
                decTotal = decUnits * decFob;

                gvProgramProductionDetail.SetRowCellValue(index, "Total", decTotal);
                
            }

            if (e.Column.Caption == "Fob")
            {
                int index = gvProgramProductionDetail.FocusedRowHandle;

                decimal decUnits = 0;
                decimal decFob = 0;
                decimal decTotal = 0;

                decUnits = decimal.Parse(gvProgramProductionDetail.GetRowCellValue(index, gvProgramProductionDetail.Columns["Units"]).ToString());
                decFob = decimal.Parse(gvProgramProductionDetail.GetRowCellValue(index, gvProgramProductionDetail.Columns["Fob"]).ToString());
                decTotal = decUnits * decFob;

                gvProgramProductionDetail.SetRowCellValue(index, "Total", decTotal);

            }
        }

        private void gcTxtItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Detail"];   
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtDetail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Units"];
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtUnits_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["Fob"];
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuProgramProductionDevelopmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaProgramProductionDetailOrigen.Count > 0)
            {
                frmRegProductionProgramDevelopmentEdit frm = new frmRegProductionProgramDevelopmentEdit();
                frm.IdProgramProduction = IdProgramProduction;
                frm.IdProgramProductionDetail = int.Parse(gvProgramProductionDetail.GetFocusedRowCellValue("IdProgramProductionDetail").ToString());
                frm.ShowDialog();
            }
        }

        private void mnuProgramProductionAudittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaProgramProductionDetailOrigen.Count > 0)
            {
                frmRegProgramProductionAudit frm = new frmRegProgramProductionAudit();
                frm.IdProgramProduction = IdProgramProduction;
                frm.IdProgramProductionDetail = int.Parse(gvProgramProductionDetail.GetFocusedRowCellValue("IdProgramProductionDetail").ToString());
                frm.IdStyle = int.Parse(gvProgramProductionDetail.GetFocusedRowCellValue("IdStyle").ToString());
                frm.Item = gvProgramProductionDetail.GetFocusedRowCellValue("Item").ToString();
                frm.IdClient = IdClient;
                frm.ShowDialog();
            }
        }

        private void deXfDate_MouseMove(object sender, MouseEventArgs e)
        {
            deXfDate.SelectAll();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProgramProductionBL objBL_ProgramProduction = new ProgramProductionBL();
                    ProgramProductionBE objProgramProduction = new ProgramProductionBE();
                    
                    objProgramProduction.NumberPP = txtNumero.Text;
                    objProgramProduction.IdClient = Convert.ToInt32(cboClient.EditValue);
                    objProgramProduction.IdClientDepartment = Convert.ToInt32(cboDivision.EditValue);
                    objProgramProduction.IdVendor = Convert.ToInt32(cboVendor.EditValue);
                    objProgramProduction.IdDestination = Convert.ToInt32(cboDestination.EditValue);
                    objProgramProduction.IdSeason = Convert.ToInt32(cboSeason.EditValue);
                    objProgramProduction.IdStyle = IdStyle;
                    objProgramProduction.IdTypeProduct = Convert.ToInt32(cboTypeProduct.EditValue);
                    objProgramProduction.NumberPO = txtNumberPO.Text;
                    objProgramProduction.NumberCommiment = txtNumberCommiment.Text;
                    objProgramProduction.XfDate = Convert.ToDateTime(deXfDate.DateTime.ToShortDateString());
                    objProgramProduction.IndcDate = Convert.ToDateTime(deIndcDate.DateTime.ToShortDateString());
                    objProgramProduction.IdShipMode = Convert.ToInt32(cboShipMode.EditValue);
                    objProgramProduction.Label = txtLabel.Text;
                    objProgramProduction.Addionational = txtAddionational.Text;
                    objProgramProduction.FlagState = true;
                    objProgramProduction.Login = Parametros.strUsuarioLogin;
                    objProgramProduction.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objProgramProduction.IdCompany = Parametros.intEmpresaId;

                    //DETAIL
                    List<ProgramProductionDetailBE> lstProgramProductionDetail = new List<ProgramProductionDetailBE>();

                    foreach (var item in mListaProgramProductionDetailOrigen)
                    {
                        ProgramProductionDetailBE objE_ProgramProductionDetail = new ProgramProductionDetailBE();
                        objE_ProgramProductionDetail.IdCompany = Parametros.intEmpresaId;
                        objE_ProgramProductionDetail.IdProgramProduction = IdProgramProduction;
                        objE_ProgramProductionDetail.IdProgramProductionDetail = item.IdProgramProductionDetail;
                        objE_ProgramProductionDetail.IdStyle = item.IdStyle;
                        objE_ProgramProductionDetail.Dyelot = item.Dyelot;
                        objE_ProgramProductionDetail.Item = item.Item;
                        objE_ProgramProductionDetail.Detail = item.Detail;
                        objE_ProgramProductionDetail.Units = item.Units;
                        objE_ProgramProductionDetail.Fob = item.Fob;
                        objE_ProgramProductionDetail.Total = item.Total;
                        objE_ProgramProductionDetail.FlagState = true;
                        objE_ProgramProductionDetail.Login = Parametros.strUsuarioLogin;
                        objE_ProgramProductionDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProgramProductionDetail.TipoOper = item.TipoOper;
                        lstProgramProductionDetail.Add(objE_ProgramProductionDetail);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {

                        
                        var Buscar = lstProgramProduction.Where(oB => oB.NumberPO.ToUpper() == txtNumberPO.Text.ToUpper() && oB.IdVendor == Convert.ToInt32(cboVendor.EditValue) && oB.IdClientDepartment == Convert.ToInt32(cboDivision.EditValue)).ToList();
                        if (Buscar.Count > 0)
                        {
                            if (XtraMessageBox.Show("the Number #PO already exists.\n The record can be duplicated, do you want to continue?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                objProgramProduction.IdProgramProduction = 0;
                                int intNumero = 0;
                                string strNumero = "";
                                intNumero = objBL_ProgramProduction.Inserta(objProgramProduction, lstProgramProductionDetail);
                                strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 10);
                                txtNumero.Text = strNumero;

                                //ActualizaNumero
                                ProgramProductionBL objBProgramProduction = new ProgramProductionBL();
                                objBProgramProduction.ActualizaNumero(intNumero, txtNumero.Text);

                                Application.DoEvents();
                            }
                                
                        }
                        else
                        {
                            objProgramProduction.IdProgramProduction = 0;
                            int intNumero = 0;
                            string strNumero = "";
                            intNumero = objBL_ProgramProduction.Inserta(objProgramProduction, lstProgramProductionDetail);
                            strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 10);
                            txtNumero.Text = strNumero;

                            //ActualizaNumero
                            ProgramProductionBL objBProgramProduction = new ProgramProductionBL();
                            objBProgramProduction.ActualizaNumero(intNumero, txtNumero.Text);

                            Application.DoEvents();
                        }
                       

                       
                    }
                    else
                    {
                        objProgramProduction.IdProgramProduction = IdProgramProduction;
                        objBL_ProgramProduction.Actualiza(objProgramProduction, lstProgramProductionDetail);
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

        private void frmRegProductionProgramEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mListaProgramProductionDetailOrigen.Count == 0)
            {
                XtraMessageBox.Show("You must enter list terms.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }


        #endregion

        #region "Metodos"

        private void CargaProgramProductionDetail()
        {
            List<ProgramProductionDetailBE> lstTmpProgramProductionDetail = null;
            lstTmpProgramProductionDetail = new ProgramProductionDetailBL().ListaTodosActivo(IdProgramProduction);

            foreach (ProgramProductionDetailBE item in lstTmpProgramProductionDetail)
            {
                if (bCopy)
                {
                    if (Convert.ToInt32(cboClient.EditValue) == 8 ) //BI-BILLING
                    {
                        gvProgramProductionDetail.AddNewRow();
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProduction", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdProgramProductionDetail", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "IdStyle", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "NameStyle", "");
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Description", "");
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Dyelot", "REG");
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Item", "");
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Detail", "");
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Units", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Fob", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "Total", 0);
                        gvProgramProductionDetail.SetRowCellValue(gvProgramProductionDetail.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                        gvProgramProductionDetail.FocusedColumn = gvProgramProductionDetail.Columns["NameStyle"];
                        gvProgramProductionDetail.ShowEditor();
                    }
                    else
                    {
                        CProgramProductionDetail objE_ProgramProductionDetail = new CProgramProductionDetail();
                        objE_ProgramProductionDetail.IdCompany = item.IdCompany;
                        objE_ProgramProductionDetail.IdProgramProduction = 0;
                        objE_ProgramProductionDetail.IdProgramProductionDetail = 0;
                        objE_ProgramProductionDetail.IdStyle = item.IdStyle;
                        objE_ProgramProductionDetail.NameStyle = item.NameStyle;
                        objE_ProgramProductionDetail.Description = item.Description;
                        objE_ProgramProductionDetail.Dyelot = item.Dyelot;
                        objE_ProgramProductionDetail.Item = item.Item;
                        objE_ProgramProductionDetail.Detail = item.Detail;
                        objE_ProgramProductionDetail.Units = item.Units;
                        objE_ProgramProductionDetail.Fob = item.Fob;
                        objE_ProgramProductionDetail.Total = item.Total;
                        objE_ProgramProductionDetail.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        mListaProgramProductionDetailOrigen.Add(objE_ProgramProductionDetail);
                    }
                    
                }
                else
                {
                    CProgramProductionDetail objE_ProgramProductionDetail = new CProgramProductionDetail();
                    objE_ProgramProductionDetail.IdCompany = item.IdCompany;
                    objE_ProgramProductionDetail.IdProgramProduction = item.IdProgramProduction;
                    objE_ProgramProductionDetail.IdProgramProductionDetail = item.IdProgramProductionDetail;
                    objE_ProgramProductionDetail.IdStyle = item.IdStyle;
                    objE_ProgramProductionDetail.NameStyle = item.NameStyle;
                    objE_ProgramProductionDetail.Description = item.Description;
                    objE_ProgramProductionDetail.Dyelot = item.Dyelot;
                    objE_ProgramProductionDetail.Item = item.Item;
                    objE_ProgramProductionDetail.Detail = item.Detail;
                    objE_ProgramProductionDetail.Units = item.Units;
                    objE_ProgramProductionDetail.Fob = item.Fob;
                    objE_ProgramProductionDetail.Total = item.Total;
                    objE_ProgramProductionDetail.TipoOper = item.TipoOper;
                    mListaProgramProductionDetailOrigen.Add(objE_ProgramProductionDetail);
                }
                
            }

            bsListadoProgramProductionDetail.DataSource = mListaProgramProductionDetailOrigen;
            gcProgramProductionDetail.DataSource = bsListadoProgramProductionDetail;
            gcProgramProductionDetail.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";

            
            if (txtNumberPO.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the Number PO.\n";
                flag = true;
            }

            if (mListaProgramProductionDetailOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- You must enter list terms.\n";
                flag = true;
            }

            if (gvProgramProductionDetail.DataRowCount > 0)
            {
                for (int i = 0; i < gvProgramProductionDetail.DataRowCount; i++)
                {
                    if (int.Parse(gvProgramProductionDetail.GetRowCellValue(i, "IdStyle").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- You must enter list styles.\n";
                        flag = true;
                    }
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

        public class CProgramProductionDetail
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdProgramProduction { get; set; }
            public Int32 IdProgramProductionDetail { get; set; }
            public Int32 IdStyle { get; set; }
            public String NameStyle { get; set; }
            public String Description { get; set; }
            public String Dyelot { get; set; }
            public String Item { get; set; }
            public String Detail { get; set; }
            public Decimal Units { get; set; }
            public Decimal Fob { get; set; }
            public Decimal Total { get; set; }
           
            public Int32 TipoOper { get; set; }

            public CProgramProductionDetail()
            {

            }
        }

        
    }
}