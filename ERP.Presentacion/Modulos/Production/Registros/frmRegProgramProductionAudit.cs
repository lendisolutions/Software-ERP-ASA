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
    public partial class frmRegProgramProductionAudit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CProgramProductionAudit> mListaProgramProductionAuditOrigen = new List<CProgramProductionAudit>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdProgramProduction { get; set; }
        public int IdProgramProductionDetail { get; set; }
        public int IdStyle { get; set; }
        public int IdClient { get; set; }
        public string Item { get; set; }

        #endregion

        #region "Eventos"

        public frmRegProgramProductionAudit()
        {
            InitializeComponent();
        }

        private void frmRegProgramProductionAudit_Load(object sender, EventArgs e)
        {
            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            CargaProgramProductionAudit();

            if (mListaProgramProductionAuditOrigen.Count == 0)
                this.nuevoProgramAuditToolStripMenuItem_Click(sender, e);
        }

        private void nuevoProgramAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Numero = 0;
            string numeroOI = "";
            Numero = new ProgramProductionAuditBL().SeleccionaBusquedaCount(Parametros.intPeriodo.ToString().Substring(2,2));
            numeroOI = Numero.ToString() + "-" + Parametros.intPeriodo.ToString().Substring(2, 2);
            if (numeroOI.Length == 6)
            {
                numeroOI = "0" + numeroOI;
            }

            if (numeroOI.Length == 5)
            {
                numeroOI = "00" + numeroOI;
            }


            gvProgramProductionAudit.AddNewRow();
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "IdProgramProduction", IdProgramProduction);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "IdProgramProductionDetail", IdProgramProductionDetail);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "IdProgramProductionAudit", 0);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "IdStyle", IdStyle);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "Item", Item);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "AuditDate", DateTime.Now);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "NumeroOI", numeroOI);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "SendDate", null);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "ReturnDate", null);
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "Comment", "");
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "FileBox", "");
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "GarmentBox", "");
            gvProgramProductionAudit.SetRowCellValue(gvProgramProductionAudit.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

            gvProgramProductionAudit.FocusedColumn = gvProgramProductionAudit.Columns["NumeroOI"];
            gvProgramProductionAudit.ShowEditor();
        }

        private void eliminarProgramProductionAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdProgramProductionAudit = 0;
                if (gvProgramProductionAudit.GetFocusedRowCellValue("IdProgramProductionAudit") != null)
                    IdProgramProductionAudit = int.Parse(gvProgramProductionAudit.GetFocusedRowCellValue("IdProgramProductionAudit").ToString());
                ProgramProductionAuditBE objBE_ProgramProductionAudit = new ProgramProductionAuditBE();
                objBE_ProgramProductionAudit.IdProgramProductionAudit = IdProgramProductionAudit;
                objBE_ProgramProductionAudit.IdCompany = Parametros.intEmpresaId;
                objBE_ProgramProductionAudit.Login = Parametros.strUsuarioLogin;
                objBE_ProgramProductionAudit.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ProgramProductionAuditBL objBL_ProgramProductionAudit = new ProgramProductionAuditBL();
                objBL_ProgramProductionAudit.Elimina(objBE_ProgramProductionAudit);
                gvProgramProductionAudit.DeleteRow(gvProgramProductionAudit.FocusedRowHandle);
                gvProgramProductionAudit.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProgramProductionAuditBL objBL_ProgramProductionAudit = new ProgramProductionAuditBL();

                    //DETAIL
                    List<ProgramProductionAuditBE> lstProgramProductionAudit = new List<ProgramProductionAuditBE>();

                    foreach (var item in mListaProgramProductionAuditOrigen)
                    {
                        ProgramProductionAuditBE objE_ProgramProductionAudit = new ProgramProductionAuditBE();
                        objE_ProgramProductionAudit.IdCompany = Parametros.intEmpresaId;
                        objE_ProgramProductionAudit.IdProgramProduction = IdProgramProduction;
                        objE_ProgramProductionAudit.IdProgramProductionDetail = item.IdProgramProductionDetail;
                        objE_ProgramProductionAudit.IdProgramProductionAudit = item.IdProgramProductionAudit;
                        objE_ProgramProductionAudit.IdStyle = item.IdStyle;
                        objE_ProgramProductionAudit.AuditDate = item.AuditDate;
                        objE_ProgramProductionAudit.NumeroOI = item.NumeroOI;
                        objE_ProgramProductionAudit.SendDate = (item.SendDate == null) ? (DateTime?)null : item.SendDate;
                        objE_ProgramProductionAudit.ReturnDate = (item.ReturnDate == null) ? (DateTime?)null : item.ReturnDate;
                        objE_ProgramProductionAudit.Comment = item.Comment;
                        objE_ProgramProductionAudit.FileBox = item.FileBox;
                        objE_ProgramProductionAudit.GarmentBox = item.GarmentBox;
                        objE_ProgramProductionAudit.FlagState = true;
                        objE_ProgramProductionAudit.Login = Parametros.strUsuarioLogin;
                        objE_ProgramProductionAudit.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProgramProductionAudit.TipoOper = item.TipoOper;
                        lstProgramProductionAudit.Add(objE_ProgramProductionAudit);
                    }

                    objBL_ProgramProductionAudit.Actualiza(lstProgramProductionAudit);

                    Application.DoEvents();

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

            if (gvProgramProductionAudit.DataRowCount > 0)
            {
                for (int i = 0; i < gvProgramProductionAudit.DataRowCount; i++)
                {
                    if (gvProgramProductionAudit.GetRowCellValue(i, "NumeroOI").ToString() == "")
                    {
                        strMensaje = strMensaje + "- You must enter number O/I.\n";
                        flag = true;
                    }
                }

                string strNumeroOI = gvProgramProductionAudit.GetRowCellValue(0, "NumeroOI").ToString().Trim();
                int intTipoOper = int.Parse(gvProgramProductionAudit.GetRowCellValue(0, "TipoOper").ToString());
                ProgramProductionAuditBE objE_ProgramProductionAudit = null;
                if (IdClient == 8) //BI-BILLING
                    objE_ProgramProductionAudit = new ProgramProductionAuditBL().SeleccionaNumero(IdProgramProduction, IdStyle, strNumeroOI);
                else
                    objE_ProgramProductionAudit = new ProgramProductionAuditBL().SeleccionaNumero(IdProgramProduction, 0, strNumeroOI);

                if (objE_ProgramProductionAudit != null && intTipoOper == Convert.ToInt32(Operacion.Nuevo))
                {
                    strMensaje = strMensaje + "The number O/I already exists\n Please Verify.";
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

        private void CargaProgramProductionAudit()
        {
            List<ProgramProductionAuditBE> lstTmpProgramProductionAudit = null;
            lstTmpProgramProductionAudit = new ProgramProductionAuditBL().ListaTodosActivo(IdProgramProduction, IdProgramProductionDetail);

            foreach (ProgramProductionAuditBE item in lstTmpProgramProductionAudit)
            {

                CProgramProductionAudit objE_ProgramProductionAudit = new CProgramProductionAudit();
                objE_ProgramProductionAudit.IdCompany = item.IdCompany;
                objE_ProgramProductionAudit.IdProgramProduction = item.IdProgramProduction;
                objE_ProgramProductionAudit.IdProgramProductionDetail = item.IdProgramProductionDetail;
                objE_ProgramProductionAudit.IdProgramProductionAudit = item.IdProgramProductionAudit;
                objE_ProgramProductionAudit.IdStyle = item.IdStyle;
                objE_ProgramProductionAudit.Item = item.Item;
                objE_ProgramProductionAudit.AuditDate = item.AuditDate;
                objE_ProgramProductionAudit.NumeroOI = item.NumeroOI;
                objE_ProgramProductionAudit.SendDate = item.SendDate;
                objE_ProgramProductionAudit.ReturnDate = item.ReturnDate;
                objE_ProgramProductionAudit.Comment = item.Comment;
                objE_ProgramProductionAudit.FileBox = item.FileBox;
                objE_ProgramProductionAudit.GarmentBox = item.GarmentBox;
                objE_ProgramProductionAudit.TipoOper = item.TipoOper;
                mListaProgramProductionAuditOrigen.Add(objE_ProgramProductionAudit);

            }

            bsListadoProgramProductionAudit.DataSource = mListaProgramProductionAuditOrigen;
            gcProgramProductionAudit.DataSource = bsListadoProgramProductionAudit;
            gcProgramProductionAudit.RefreshDataSource();
                
        }


        #endregion

        public class CProgramProductionAudit
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdProgramProduction { get; set; }
            public Int32 IdProgramProductionDetail { get; set; }
            public Int32 IdProgramProductionAudit { get; set; }
            public Int32 IdStyle { get; set; }
            public String Item { get; set; }
            public DateTime AuditDate { get; set; }
            public String NumeroOI { get; set; }
            public DateTime? SendDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public String Comment { get; set; }
            public String FileBox { get; set; }
            public String GarmentBox { get; set; }
            public Int32 TipoOper { get; set; }

            public CProgramProductionAudit()
            {

            }
        }

        
    }
}