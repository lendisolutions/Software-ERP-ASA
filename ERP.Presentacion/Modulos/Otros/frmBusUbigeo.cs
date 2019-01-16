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
    public partial class frmBusUbigeo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UbigeoBE> mLista = new List<UbigeoBE>();
        public UbigeoBE _Be { get; set; }

        #endregion

        #region "Eventos"

        public frmBusUbigeo()
        {
            InitializeComponent();
        }

        private void frmBusUbigeo_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvUbigeo_DoubleClick(object sender, EventArgs e)
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
            mLista = new UbigeoBL().Listado();
            gcUbigeo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUbigeo.DataSource = mLista.Where(obj =>
                                                   obj.NomDist.ToUpper().Contains(txtDescription.Text.ToUpper())).ToList();
        }

        private void Aceptar1()
        {
            _Be = (UbigeoBE)gvUbigeo.GetRow(gvUbigeo.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion

    }
}