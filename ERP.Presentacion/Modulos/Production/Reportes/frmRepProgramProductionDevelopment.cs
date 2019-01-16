using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP.Presentacion.Modulos.Otros;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Production.Reportes
{
    public partial class frmRepProgramProductionDevelopment : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepProgramProductionDevelopment()
        {
            InitializeComponent();
        }

        private void frmRepProgramProductionDevelopment_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            BSUtils.LoaderLook(cboSituation, new ElementTabletBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblDevelopmentSituation), "NameElementTablet", "IdElementTablet", true);
            cboSituation.EditValue = Parametros.intDOPending;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteProgramProductionDevelopmentBE> lstReporte = null;
                lstReporte = new ReporteProgramProductionDevelopmentBL().Listado(Parametros.intEmpresaId,Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboSituation.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptEpp = new RptVistaReportes();
                        objRptEpp.VerRptProgramProductionDevelopment(lstReporte);
                        objRptEpp.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
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

        #endregion


    }
}