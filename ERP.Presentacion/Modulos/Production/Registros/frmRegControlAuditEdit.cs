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
    public partial class frmRegControlAuditEdit : DevExpress.XtraEditors.XtraForm
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

        public int IdProgramProductionAudit { get; set; }

        #endregion

        #region "Eventos"

        public frmRegControlAuditEdit()
        {
            InitializeComponent();
        }

        private void frmRegControlAuditEdit_Load(object sender, EventArgs e)
        {
            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["AuditDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["SendDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionAudit.Columns["ReturnDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            CargaProgramProductionAudit();
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
                        objE_ProgramProductionAudit.IdProgramProduction = item.IdProgramProduction;
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
            lstTmpProgramProductionAudit = new ProgramProductionAuditBL().ListaCodigo(IdProgramProductionAudit);

            foreach (ProgramProductionAuditBE item in lstTmpProgramProductionAudit)
            {

                CProgramProductionAudit objE_ProgramProductionAudit = new CProgramProductionAudit();
                objE_ProgramProductionAudit.IdCompany = item.IdCompany;
                objE_ProgramProductionAudit.IdProgramProduction = item.IdProgramProduction;
                objE_ProgramProductionAudit.IdProgramProductionDetail = item.IdProgramProductionDetail;
                objE_ProgramProductionAudit.IdProgramProductionAudit = item.IdProgramProductionAudit;
                objE_ProgramProductionAudit.IdStyle = item.IdStyle;
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