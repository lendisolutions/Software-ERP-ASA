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
    public partial class frmBusDestination : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DestinationBE> mLista = new List<DestinationBE>();
        public DestinationBE _Be { get; set; }

        #endregion

        #region "Eventos"

        public frmBusDestination()
        {
            InitializeComponent();
        }

        private void frmBusDestination_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvDestination_DoubleClick(object sender, EventArgs e)
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
            mLista = new DestinationBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDestination.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDestination.DataSource = mLista.Where(obj =>
                                                   obj.NameDestination.ToUpper().Contains(txtDescription.Text.ToUpper())).ToList();
        }

        private void Aceptar1()
        {
            _Be = (DestinationBE)gvDestination.GetRow(gvDestination.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion


    }
}