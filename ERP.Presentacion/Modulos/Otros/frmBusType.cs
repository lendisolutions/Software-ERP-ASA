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
    public partial class frmBusType : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TypeBE> mLista = new List<TypeBE>();
        public TypeBE _Be { get; set; }

        #endregion

        #region "Eventos"

        public frmBusType()
        {
            InitializeComponent();
        }

        private void frmBusType_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvType_DoubleClick(object sender, EventArgs e)
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
            mLista = new TypeBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcType.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcType.DataSource = mLista.Where(obj =>
                                                   obj.NameType.ToUpper().Contains(txtDescription.Text.ToUpper())).ToList();
        }

        private void Aceptar1()
        {
            _Be = (TypeBE)gvType.GetRow(gvType.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion


    }
}