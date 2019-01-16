using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Otros
{
    public partial class frmBusStyle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StyleBE> mLista = new List<StyleBE>();
        public StyleBE _Be { get; set; }

        public int IdClient { get; set; }
        public int IdClientDepartment { get; set; }

        #endregion

        #region "Eventos"

        public frmBusStyle()
        {
            InitializeComponent();
        }

        private void frmBusStyle_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvStyle_DoubleClick(object sender, EventArgs e)
        {
            Aceptar1();
        }

        private void gvStyle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar1();
            }
            
        }

        private void txtDescription_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                Aceptar1();
            }
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new StyleBL().ListaTodosActivo(Parametros.intEmpresaId, IdClient, IdClientDepartment);
            gcStyle.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcStyle.DataSource = mLista.Where(obj => obj.NameStyle.ToUpper().Contains(txtDescription.Text.ToUpper()) || obj.Description.ToUpper().Contains(txtDescription.Text.ToUpper())).ToList();
            gvStyle.FocusedRowHandle = 0;

        }

        private void Aceptar1()
        {
            _Be = (StyleBE)gvStyle.GetRow(gvStyle.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }


        #endregion

        
    }
}