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

namespace ERP.Presentacion.Modulos.Production.Registros
{
    public partial class frmRegCommimentEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CommimentBE> lstCommiment;
        public List<CCommimentDetail> mListaCommimentDetailOrigen = new List<CCommimentDetail>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCommiment = 0;

        public int IdCommiment
        {
            get { return _IdCommiment; }
            set { _IdCommiment = value; }
        }

        public int IdClient { get; set; }

        #endregion

        #region "Eventos"

        public frmRegCommimentEdit()
        {
            InitializeComponent();
        }

        private void frmRegCommimentEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            cboClient.EditValue = IdClient;
            BSUtils.LoaderLook(cboVendor, new VendorBL().ListaTodosActivo(Parametros.intEmpresaId), "NameVendor", "IdVendor", true);
            BSUtils.LoaderLook(cboOrigin, new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameDestination", "IdDestination", true);
            BSUtils.LoaderLook(cboDestination, new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameDestination", "IdDestination", true);
            BSUtils.LoaderLook(cboCurrency, new CurrencyBL().ListaTodosActivo(Parametros.intEmpresaId), "NameCurrency", "IdCurrency", true);

            deCommimentDate.DateTime = DateTime.Now;
            deContractShipDate.DateTime = DateTime.Now;
            deRevisionDate.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Commiment - New";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Commiment - Update";

                CommimentBE objE_Commiment = null;
                objE_Commiment = new CommimentBL().Selecciona(IdCommiment);
                if (objE_Commiment != null)
                {
                    IdCommiment = objE_Commiment.IdCommiment;
                    txtNumero.Text = objE_Commiment.NumberCommiment;
                    cboClient.EditValue = objE_Commiment.IdClient;
                    cboVendor.EditValue = objE_Commiment.IdVendor;
                    deCommimentDate.EditValue = objE_Commiment.CommimentDate;
                    deContractShipDate.EditValue = objE_Commiment.ContractShipDate;
                    deRevisionDate.EditValue = objE_Commiment.RevisionDate;
                    txtNumberRevision.Text = objE_Commiment.NumberRevision;
                    cboOrigin.EditValue = objE_Commiment.IdOrigen;
                    cboDestination.EditValue = objE_Commiment.IdDestination;
                    cboCurrency.EditValue = objE_Commiment.IdCurrency;
                    txtFreightPaid.Text = objE_Commiment.FreightPaid;
                    txtAddionational.Text = objE_Commiment.Addionational;
                }
            }

            CargaCommimentDetail();
        }

        private void nuevoCommimentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvCommimentDetail.AddNewRow();
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "IdCommiment", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "IdCommimentDetail", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "IdStyle", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "NameStyle", "");
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "Description", "");
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "Quantity", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "Fob", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "Total", 0);
            gvCommimentDetail.SetRowCellValue(gvCommimentDetail.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

            gvCommimentDetail.FocusedColumn = gvCommimentDetail.Columns["NameStyle"];
            gvCommimentDetail.ShowEditor();
        }

        private void eliminarCommimentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCommimentDetail = 0;
                if (gvCommimentDetail.GetFocusedRowCellValue("IdCommimentDetail") != null)
                    IdCommimentDetail = int.Parse(gvCommimentDetail.GetFocusedRowCellValue("IdCommimentDetail").ToString());
                CommimentDetailBE objBE_CommimentDetail = new CommimentDetailBE();
                objBE_CommimentDetail.IdCommimentDetail = IdCommimentDetail;
                objBE_CommimentDetail.IdCompany = Parametros.intEmpresaId;
                objBE_CommimentDetail.Login = Parametros.strUsuarioLogin;
                objBE_CommimentDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                CommimentDetailBL objBL_CommimentDetail = new CommimentDetailBL();
                objBL_CommimentDetail.Elimina(objBE_CommimentDetail);
                gvCommimentDetail.DeleteRow(gvCommimentDetail.FocusedRowHandle);
                gvCommimentDetail.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gxTxtNameStyle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmBusStyle frm = new frmBusStyle();
                frm.IdClient = Convert.ToInt32(cboClient.EditValue);
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    int index = gvCommimentDetail.FocusedRowHandle;
                    gvCommimentDetail.SetRowCellValue(index, "IdStyle", frm._Be.IdStyle);
                    gvCommimentDetail.SetRowCellValue(index, "NameStyle", frm._Be.NameStyle);
                    gvCommimentDetail.SetRowCellValue(index, "Description", frm._Be.Description);

                    gvCommimentDetail.FocusedColumn = gvCommimentDetail.Columns["Quantity"];
                }
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvCommimentDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (mListaCommimentDetailOrigen.Count == 0)
            {
                return;
            }

            if (e.Column.Caption == "Quantity")
            {
                int index = gvCommimentDetail.FocusedRowHandle;

                decimal decQuantity = 0;
                decimal decFob = 0;
                decimal decTotal = 0;

                decQuantity = decimal.Parse(gvCommimentDetail.GetRowCellValue(index, gvCommimentDetail.Columns["Quantity"]).ToString());
                decFob = decimal.Parse(gvCommimentDetail.GetRowCellValue(index, gvCommimentDetail.Columns["Fob"]).ToString());
                decTotal = decQuantity * decFob;

                gvCommimentDetail.SetRowCellValue(index, "Total", decTotal);

            }

            if (e.Column.Caption == "Fob")
            {
                int index = gvCommimentDetail.FocusedRowHandle;

                decimal decQuantity = 0;
                decimal decFob = 0;
                decimal decTotal = 0;

                decQuantity = decimal.Parse(gvCommimentDetail.GetRowCellValue(index, gvCommimentDetail.Columns["Quantity"]).ToString());
                decFob = decimal.Parse(gvCommimentDetail.GetRowCellValue(index, gvCommimentDetail.Columns["Fob"]).ToString());
                decTotal = decQuantity * decFob;

                gvCommimentDetail.SetRowCellValue(index, "Total", decTotal);

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CommimentBL objBL_Commiment = new CommimentBL();
                    CommimentBE objCommiment = new CommimentBE();

                    objCommiment.IdCommiment = IdCommiment;
                    objCommiment.NumberCommiment = txtNumero.Text;
                    objCommiment.IdClient = Convert.ToInt32(cboClient.EditValue);
                    objCommiment.IdVendor = Convert.ToInt32(cboVendor.EditValue);
                    objCommiment.CommimentDate = Convert.ToDateTime(deCommimentDate.DateTime.ToShortDateString());
                    objCommiment.ContractShipDate = Convert.ToDateTime(deContractShipDate.DateTime.ToShortDateString());
                    objCommiment.RevisionDate = Convert.ToDateTime(deRevisionDate.DateTime.ToShortDateString());
                    objCommiment.NumberRevision = txtNumberRevision.Text;
                    objCommiment.IdOrigen = Convert.ToInt32(cboOrigin.EditValue);
                    objCommiment.IdDestination = Convert.ToInt32(cboDestination.EditValue);
                    objCommiment.IdCurrency = Convert.ToInt32(cboCurrency.EditValue);
                    objCommiment.FreightPaid = txtFreightPaid.Text;
                    objCommiment.Addionational = txtAddionational.Text;
                    objCommiment.FlagState = true;
                    objCommiment.Login = Parametros.strUsuarioLogin;
                    objCommiment.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objCommiment.IdCompany = Parametros.intEmpresaId;

                    //DETAIL
                    List<CommimentDetailBE> lstCommimentDetail = new List<CommimentDetailBE>();

                    foreach (var item in mListaCommimentDetailOrigen)
                    {
                        CommimentDetailBE objE_CommimentDetail = new CommimentDetailBE();
                        objE_CommimentDetail.IdCompany = Parametros.intEmpresaId;
                        objE_CommimentDetail.IdCommiment = IdCommiment;
                        objE_CommimentDetail.IdCommimentDetail = item.IdCommimentDetail;
                        objE_CommimentDetail.IdStyle = item.IdStyle;
                        objE_CommimentDetail.Quantity = item.Quantity;
                        objE_CommimentDetail.Fob = item.Fob;
                        objE_CommimentDetail.Total = item.Total;
                        objE_CommimentDetail.FlagState = true;
                        objE_CommimentDetail.Login = Parametros.strUsuarioLogin;
                        objE_CommimentDetail.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CommimentDetail.TipoOper = item.TipoOper;
                        lstCommimentDetail.Add(objE_CommimentDetail);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_Commiment.Inserta(objCommiment, lstCommimentDetail);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 10);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        CommimentBL objBCommiment = new CommimentBL();
                        objBCommiment.ActualizaNumero(intNumero, txtNumero.Text);
                    }

                    else
                        objBL_Commiment.Actualiza(objCommiment, lstCommimentDetail);

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

        private void CargaCommimentDetail()
        {
            List<CommimentDetailBE> lstTmpCommimentDetail = null;
            lstTmpCommimentDetail = new CommimentDetailBL().ListaTodosActivo(IdCommiment);

            foreach (CommimentDetailBE item in lstTmpCommimentDetail)
            {
                CCommimentDetail objE_CommimentDetail = new CCommimentDetail();
                objE_CommimentDetail.IdCompany = item.IdCompany;
                objE_CommimentDetail.IdCommiment = item.IdCommiment;
                objE_CommimentDetail.IdCommimentDetail = item.IdCommimentDetail;
                objE_CommimentDetail.IdStyle = item.IdStyle;
                objE_CommimentDetail.NameStyle = item.NameStyle;
                objE_CommimentDetail.Description = item.Description;
                objE_CommimentDetail.Quantity = item.Quantity;
                objE_CommimentDetail.Fob = item.Fob;
                objE_CommimentDetail.Total = item.Total;
                objE_CommimentDetail.TipoOper = item.TipoOper;
                mListaCommimentDetailOrigen.Add(objE_CommimentDetail);
            }

            bsListadoCommimentDetail.DataSource = mListaCommimentDetailOrigen;
            gcCommimentDetail.DataSource = bsListadoCommimentDetail;
            gcCommimentDetail.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";

            
            if (mListaCommimentDetailOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- You must enter commiment detail.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        public class CCommimentDetail
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdCommiment { get; set; }
            public Int32 IdCommimentDetail { get; set; }
            public Int32 IdStyle { get; set; }
            public String NameStyle { get; set; }
            public String Description { get; set; }
            public Decimal Quantity { get; set; }
            public Decimal Fob { get; set; }
            public Decimal Total { get; set; }
            public Int32 TipoOper { get; set; }

            public CCommimentDetail()
            {

            }
        }

        
    }
}