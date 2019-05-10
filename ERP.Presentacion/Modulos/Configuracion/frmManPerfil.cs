using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManPerfil : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<ProfileBE> mLista = new List<ProfileBE>();
        
        #endregion

        #region "Eventos"

        public frmManPerfil()
        {
            InitializeComponent();
        }

        private void frmManPerfil_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            ConfigurarGrilla();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPerfilEdit objManPerfil = new frmManPerfilEdit();
                objManPerfil.pOperacion = frmManPerfilEdit.Operacion.Nuevo;
                objManPerfil.IdProfile = 0;
                objManPerfil.StartPosition = FormStartPosition.CenterParent;
                objManPerfil.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Be sure to delete the record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ProfileBE objE_Perfil = new ProfileBE();
                        objE_Perfil.IdProfile = int.Parse(gvPerfil.GetFocusedRowCellValue("IdProfile").ToString());
                        objE_Perfil.Login = Parametros.strUsuarioLogin;
                        objE_Perfil.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Perfil.IdCompany = Parametros.intEmpresaId;

                        ProfileBL objBL_Perfil = new ProfileBL();
                        objBL_Perfil.Elimina(objE_Perfil);
                        XtraMessageBox.Show("The record was successfully deleted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {

        }

        private void tlbMenu_ExportClick()
        {
            ExportarExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPerfil_DoubleClick(object sender, System.EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProfileBL().ListaTodosActivo().ToList();
            gcPerfil.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPerfil.DataSource = mLista.Where(obj =>
                                                   obj.NameProfile.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void ConfigurarGrilla()
        {
            gvPerfil.OptionsBehavior.Editable = false;
            gvPerfil.OptionsCustomization.AllowColumnMoving = false;
            gvPerfil.OptionsCustomization.AllowGroup = false;
            gvPerfil.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvPerfil.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvPerfil.OptionsView.ShowGroupPanel = false;
            gvPerfil.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            DevExpress.XtraGrid.Columns.GridColumn gcIdPerfil = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagEstado = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdPerfil.Caption = "IdProfile";
            gcIdPerfil.FieldName = "IdProfile";
            gcIdPerfil.Name = "gcIdPerfil";
            gcIdPerfil.Visible = false;

            gcDescripcion.Caption = "Profile";
            gcDescripcion.FieldName = "NameProfile";
            gcDescripcion.Name = "gcDescripcion";
            gcDescripcion.Visible = true;
            gcDescripcion.VisibleIndex = 0;
            gcDescripcion.Width = 300;

            gcFlagEstado.Caption = "Estado";
            gcFlagEstado.FieldName = "FlagState";
            gcFlagEstado.Name = "gcFlagEstado";
            gcFlagEstado.Visible = true;
            gcFlagEstado.VisibleIndex = 2;
            gcFlagEstado.Width = 66;

            gvPerfil.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {             
                    gcIdPerfil,
                    gcDescripcion,
                    gcFlagEstado});

            gvPerfil.DoubleClick += new System.EventHandler(this.gvPerfil_DoubleClick);
        }

        public void InicializarModificar()
        {
            if (gvPerfil.RowCount > 0)
            {
                ProfileBE objPerfil = new ProfileBE();
                objPerfil.IdProfile = int.Parse(gvPerfil.GetFocusedRowCellValue("IdProfile").ToString());
                objPerfil.NameProfile = gvPerfil.GetFocusedRowCellValue("NameProfile").ToString();
                objPerfil.FlagState = Convert.ToBoolean(gvPerfil.GetFocusedRowCellValue("FlagState").ToString());

                frmManPerfilEdit objManPerfilEdit = new frmManPerfilEdit();
                objManPerfilEdit.pOperacion = frmManPerfilEdit.Operacion.Modificar;
                objManPerfilEdit.IdProfile = objPerfil.IdProfile;
                objManPerfilEdit.pPerfilBE = objPerfil;
                objManPerfilEdit.StartPosition = FormStartPosition.CenterParent;
                objManPerfilEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("Could not edit");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPerfil.GetFocusedRowCellValue("IdProfile").ToString() == "")
            {
                XtraMessageBox.Show("Select a Profile", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void ExportarExcel(string filename)
        {

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Excel\\Profile.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<ProfileBE> lstProfile = null;
                lstProfile = new ProfileBL().ListaTodosActivo();
                if (lstProfile.Count > 0)
                {
                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 1, 100, 60);

                    foreach (var item in lstProfile)
                    {
                        xlHoja.Cells[Row, 1] = item.IdProfile;
                        xlHoja.Cells[Row, 2] = item.NameProfile;
                       
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("C:\\Excel\\Profile.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                BSUtils.OpenExcel("C:\\Excel\\Profile.xlsx");
                //XtraMessageBox.Show("It was imported correctly \n The file was generated C:\\Excel\\Profile.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

    }
}