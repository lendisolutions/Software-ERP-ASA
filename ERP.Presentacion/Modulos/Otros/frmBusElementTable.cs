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
    public partial class frmBusElementTable : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ElementTabletBE> mLista = new List<ElementTabletBE>();
        public ElementTabletBE _Be { get; set; }

        public int IdTablet { get; set; }

        #endregion

        #region "Eventos"

        public frmBusElementTable()
        {
            InitializeComponent();
        }

        private void frmBusElementTable_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvElementTablet_DoubleClick(object sender, EventArgs e)
        {
            Aceptar1();
        }

        private void txtDescription_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }


        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, IdTablet);
            gcElementTablet.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcElementTablet.DataSource = mLista.Where(obj =>
                                                   obj.NameElementTablet.ToUpper().Contains(txtDescription.Text.ToUpper())).ToList();
        }

        private void Aceptar1()
        {
            _Be = (ElementTabletBE)gvElementTablet.GetRow(gvElementTablet.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion


    }
}