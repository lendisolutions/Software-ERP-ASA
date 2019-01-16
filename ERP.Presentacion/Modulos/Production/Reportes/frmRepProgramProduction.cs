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
    public partial class frmRepProgramProduction : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepProgramProduction()
        {
            InitializeComponent();
        }

        private void frmRepProgramProduction_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClient, new LoginClientDepartmentBL().ListaClient(Parametros.intUsuarioId), "NameClient", "IdClient", true);
            BSUtils.LoaderLook(cboVendor, new VendorBL().ListaTodosActivo(Parametros.intEmpresaId), "NameVendor", "IdVendor", true);
            deDateFrom.DateTime = DateTime.Now;
            deDateTo.DateTime = DateTime.Now;

            deDateFrom.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deDateFrom.Properties.Mask.EditMask = "MM/dd/yyyy";
            deDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            deDateFrom.Properties.CharacterCasing = CharacterCasing.Upper;

            deDateTo.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deDateTo.Properties.Mask.EditMask = "MM/dd/yyyy";
            deDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            deDateTo.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        
        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteProgramProductionBE> lstReporte = null;

                if (chkClient.Checked && chkVendor.Checked)
                {
                    lstReporte = new ReporteProgramProductionBL().ListadoFecha(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), Convert.ToInt32(cboVendor.EditValue), Convert.ToDateTime(deDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deDateTo.DateTime.ToShortDateString()));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptEpp = new RptVistaReportes();
                            objRptEpp.VerRptProgramProductionDate(lstReporte, deDateFrom.DateTime.ToShortDateString(), deDateTo.DateTime.ToShortDateString());
                            objRptEpp.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Cursor = Cursors.Default;

                    return;
                }

                if (chkClient.Checked)
                {
                    lstReporte = new ReporteProgramProductionBL().ListadoFecha(Parametros.intEmpresaId, Convert.ToInt32(cboClient.EditValue), 0, Convert.ToDateTime(deDateFrom.DateTime.ToShortDateString()), Convert.ToDateTime(deDateTo.DateTime.ToShortDateString()));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptEpp = new RptVistaReportes();
                            objRptEpp.VerRptProgramProductionDate(lstReporte, deDateFrom.DateTime.ToShortDateString(), deDateTo.DateTime.ToShortDateString());
                            objRptEpp.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Cursor = Cursors.Default;

                    return;
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

        

        #endregion


    }
}