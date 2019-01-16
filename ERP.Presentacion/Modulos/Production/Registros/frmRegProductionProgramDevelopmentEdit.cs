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
    public partial class frmRegProductionProgramDevelopmentEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CProgramProductionDevelopment> mListaProgramProductionDevelopmentOrigen = new List<CProgramProductionDevelopment>();

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

        #endregion

        #region "Eventos"

        public frmRegProductionProgramDevelopmentEdit()
        {
            InitializeComponent();
        }

        private void frmRegProductionProgramDevelopmentEdit_Load(object sender, EventArgs e)
        {
            gvProgramProductionDevelopment.Columns["DevDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvProgramProductionDevelopment.Columns["DevDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            CargaProgramProductionDevelopment();
        }

        private void nuevoProgramProductionDevelopmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvProgramProductionDevelopment.AddNewRow();
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "IdProgramProduction", IdProgramProduction);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "IdProgramProductionDetail", IdProgramProductionDetail);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "IdProgramProductionDevelopment", 0);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "DevDate", DateTime.Now);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "Comment", "");
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "IdSituation", Parametros.intDOPending);
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "Situation", "PENDING");
            gvProgramProductionDevelopment.SetRowCellValue(gvProgramProductionDevelopment.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

            gvProgramProductionDevelopment.FocusedColumn = gvProgramProductionDevelopment.Columns["Comment"];
            gvProgramProductionDevelopment.ShowEditor();
        }

        private void eliminarProgramProductionDevelopmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdProgramProductionDevelopment = 0;
                if (gvProgramProductionDevelopment.GetFocusedRowCellValue("IdProgramProductionDevelopment") != null)
                    IdProgramProductionDevelopment = int.Parse(gvProgramProductionDevelopment.GetFocusedRowCellValue("IdProgramProductionDevelopment").ToString());
                ProgramProductionDevelopmentBE objBE_ProgramProductionDevelopment = new ProgramProductionDevelopmentBE();
                objBE_ProgramProductionDevelopment.IdProgramProductionDevelopment = IdProgramProductionDevelopment;
                objBE_ProgramProductionDevelopment.IdCompany = Parametros.intEmpresaId;
                objBE_ProgramProductionDevelopment.Login = Parametros.strUsuarioLogin;
                objBE_ProgramProductionDevelopment.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ProgramProductionDevelopmentBL objBL_ProgramProductionDevelopment = new ProgramProductionDevelopmentBL();
                objBL_ProgramProductionDevelopment.Elimina(objBE_ProgramProductionDevelopment);
                gvProgramProductionDevelopment.DeleteRow(gvProgramProductionDevelopment.FocusedRowHandle);
                gvProgramProductionDevelopment.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gcTxtSituation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cursor = Cursors.WaitCursor;
                    frmBusElementTable frm = new frmBusElementTable();
                    frm.Text = "Find Situation";
                    frm.IdTablet = Parametros.intTblDevelopmentSituation;
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvProgramProductionDevelopment.FocusedRowHandle;

                        gvProgramProductionDevelopment.SetRowCellValue(index, "IdSituation", frm._Be.IdElementTablet);
                        gvProgramProductionDevelopment.SetRowCellValue(index, "Situation", frm._Be.NameElementTablet);
                        
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

        private void gvProgramProductionDevelopment_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "Situation")
                {
                    string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situation"]);
                    if (Situacion == "CLOSED")
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (Situacion == "PENDING")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }

                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProgramProductionDevelopmentBL objBL_ProgramProductionDevelopment = new ProgramProductionDevelopmentBL();
                    

                    //DETAIL
                    List<ProgramProductionDevelopmentBE> lstProgramProductionDevelopment = new List<ProgramProductionDevelopmentBE>();

                    foreach (var item in mListaProgramProductionDevelopmentOrigen)
                    {
                        ProgramProductionDevelopmentBE objE_ProgramProductionDevelopment = new ProgramProductionDevelopmentBE();
                        objE_ProgramProductionDevelopment.IdCompany = Parametros.intEmpresaId;
                        objE_ProgramProductionDevelopment.IdProgramProduction = IdProgramProduction;
                        objE_ProgramProductionDevelopment.IdProgramProductionDetail = item.IdProgramProductionDetail;
                        objE_ProgramProductionDevelopment.IdProgramProductionDevelopment = item.IdProgramProductionDevelopment;
                        objE_ProgramProductionDevelopment.DevDate = item.DevDate;
                        objE_ProgramProductionDevelopment.Comment= item.Comment;
                        objE_ProgramProductionDevelopment.IdSituation = item.IdSituation;
                        objE_ProgramProductionDevelopment.FlagState = true;
                        objE_ProgramProductionDevelopment.Login = Parametros.strUsuarioLogin;
                        objE_ProgramProductionDevelopment.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProgramProductionDevelopment.TipoOper = item.TipoOper;
                        lstProgramProductionDevelopment.Add(objE_ProgramProductionDevelopment);
                    }

                    objBL_ProgramProductionDevelopment.Actualiza(lstProgramProductionDevelopment);

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

            if (gvProgramProductionDevelopment.DataRowCount > 0)
            {
                for (int i = 0; i < gvProgramProductionDevelopment.DataRowCount; i++)
                {
                    if (gvProgramProductionDevelopment.GetRowCellValue(i, "Comment").ToString() == "")
                    {
                        strMensaje = strMensaje + "- You must enter comment.\n";
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

        private void CargaProgramProductionDevelopment()
        {
            List<ProgramProductionDevelopmentBE> lstTmpProgramProductionDevelopment = null;
            lstTmpProgramProductionDevelopment = new ProgramProductionDevelopmentBL().ListaTodosActivo(IdProgramProduction,IdProgramProductionDetail);

            foreach (ProgramProductionDevelopmentBE item in lstTmpProgramProductionDevelopment)
            {

                CProgramProductionDevelopment objE_ProgramProductionDevelopment = new CProgramProductionDevelopment();
                objE_ProgramProductionDevelopment.IdCompany = item.IdCompany;
                objE_ProgramProductionDevelopment.IdProgramProduction = item.IdProgramProduction;
                objE_ProgramProductionDevelopment.IdProgramProductionDetail = item.IdProgramProductionDetail;
                objE_ProgramProductionDevelopment.IdProgramProductionDevelopment = item.IdProgramProductionDevelopment;
                objE_ProgramProductionDevelopment.DevDate = item.DevDate;
                objE_ProgramProductionDevelopment.Comment = item.Comment;
                objE_ProgramProductionDevelopment.IdSituation = item.IdSituation;
                objE_ProgramProductionDevelopment.Situation = item.Situation;
                objE_ProgramProductionDevelopment.TipoOper = item.TipoOper;
                mListaProgramProductionDevelopmentOrigen.Add(objE_ProgramProductionDevelopment);

                
            }

            bsListadoProgramProductionDevelopment.DataSource = mListaProgramProductionDevelopmentOrigen;
            gcProgramProductionDevelopment.DataSource = bsListadoProgramProductionDevelopment;
            gcProgramProductionDevelopment.RefreshDataSource();
        }


        #endregion

        public class CProgramProductionDevelopment
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdProgramProduction { get; set; }
            public Int32 IdProgramProductionDetail { get; set; }
            public Int32 IdProgramProductionDevelopment { get; set; }
            public DateTime DevDate { get; set; }
            public String Comment { get; set; }
            public Int32 IdSituation { get; set; }
            public String Situation { get; set; }
            public Int32 TipoOper { get; set; }

            public CProgramProductionDevelopment()
            {

            }
        }

        
    }
}