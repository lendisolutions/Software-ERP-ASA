using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Configuracion
{
    public partial class frmManTablaElemento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ElementTabletBE> mLista = new List<ElementTabletBE>();

        public int IdTablet { get; set; }
        
        #endregion

        #region "Eventos"

        public frmManTablaElemento()
        {
            InitializeComponent();
        }

        private void frmManTablaElemento_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManTablaElementoEdit objManTablaElemento = new frmManTablaElementoEdit();
                objManTablaElemento.lstTablaElemento = mLista;
                objManTablaElemento.pOperacion = frmManTablaElementoEdit.Operacion.Nuevo;
                objManTablaElemento.IdTablet = IdTablet;
                objManTablaElemento.IdElementTablet = 0;
                objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
                objManTablaElemento.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Be sure to delete the record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ElementTabletBE objE_TablaElemento = new ElementTabletBE();
                        objE_TablaElemento.IdElementTablet = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdElementTablet").ToString());
                        objE_TablaElemento.Login = Parametros.strUsuarioLogin;
                        objE_TablaElemento.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TablaElemento.IdCompany = Parametros.intEmpresaId;

                        ElementTabletBL objBL_TablaElemento = new ElementTabletBL();
                        objBL_TablaElemento.Elimina(objE_TablaElemento);
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

        private void gvTablaElemento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, IdTablet);
            gcTablaElemento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTablaElemento.DataSource = mLista.Where(obj =>
                                                   obj.NameElementTablet.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTablaElemento.RowCount > 0)
            {
                ElementTabletBE objTablaElemento = new ElementTabletBE();
                objTablaElemento.IdTablet = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdTablet").ToString());
                objTablaElemento.IdElementTablet = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdElementTablet").ToString());
                objTablaElemento.NameTablet = gvTablaElemento.GetFocusedRowCellValue("NameTablet").ToString();
                objTablaElemento.Abbreviate = gvTablaElemento.GetFocusedRowCellValue("Abbreviate").ToString();
                objTablaElemento.NameElementTablet = gvTablaElemento.GetFocusedRowCellValue("NameElementTablet").ToString();
                objTablaElemento.FlagState = Convert.ToBoolean(gvTablaElemento.GetFocusedRowCellValue("FlagState").ToString());

                frmManTablaElementoEdit objManTablaEdit = new frmManTablaElementoEdit();
                objManTablaEdit.pOperacion = frmManTablaElementoEdit.Operacion.Modificar;
                objManTablaEdit.IdTablet = objTablaElemento.IdTablet;
                objManTablaEdit.IdElementTablet = objTablaElemento.IdElementTablet;
                objManTablaEdit.pElementTabletBE = objTablaElemento;
                objManTablaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTablaEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("Edit");
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

            if (gvTablaElemento.GetFocusedRowCellValue("IdElementTablet").ToString() == "")
            {
                XtraMessageBox.Show("Select a element.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}