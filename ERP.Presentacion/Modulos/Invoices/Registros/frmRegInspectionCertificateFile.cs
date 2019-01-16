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
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.Presentacion.Utils;
using ERP.Presentacion;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion.Modulos.Invoices.Registros
{
    public partial class frmRegInspectionCertificateFile : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InspectionCertificateBE> mLista = new List<InspectionCertificateBE>();

        #endregion

        #region "Eventos"

        public frmRegInspectionCertificateFile()
        {
            InitializeComponent();
        }

        private void frmRegInspectionCertificateFile_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendor, new VendorBL().ListaTodosActivo(Parametros.intEmpresaId), "NameVendor", "IdVendor", true);
        }

        private void gvInspectionCertificate_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "NameStatus")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["NameStatus"]);
                        if (Situacion == "ACTIVE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "FINISHED")
                        {
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "DELETED")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                InspectionCertificateBL objBL_InspectionCertificate = new InspectionCertificateBL();
                List<InspectionCertificateBE> lstInspectionCertificate = new List<InspectionCertificateBE>();

                int[] rows = gvInspectionCertificate.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    InspectionCertificateBE objE_InspectionCertificate = new InspectionCertificateBE();
                    objE_InspectionCertificate.IdInspectionCertificate = int.Parse(gvInspectionCertificate.GetRowCellValue(rows[i], gvInspectionCertificate.Columns.ColumnByFieldName("IdInspectionCertificate")).ToString());
                    objE_InspectionCertificate.IdStatus = Parametros.intICFinished;
                    lstInspectionCertificate.Add(objE_InspectionCertificate);
                }

                objBL_InspectionCertificate.ActualizaSituacionMasivo(lstInspectionCertificate);
                XtraMessageBox.Show("The certificates finished correctly.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                this.Close();



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

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            if (chkVendor.Checked)
            {
                if (txtNumberCertificateFrom.Text == "")
                {
                    XtraMessageBox.Show("Enter number certificate from.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }

                if (txtNumberCertificateTo.Text == "")
                {
                    XtraMessageBox.Show("Enter number certificate To.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }

                int intNumberCertificateFrom = 0;
                int intNumberCertificateTo = 0;

                intNumberCertificateFrom = Convert.ToInt32(strRight(txtNumberCertificateFrom.Text.Trim(), 6));
                intNumberCertificateTo = Convert.ToInt32(strRight(txtNumberCertificateTo.Text.Trim(), 6));

                if (intNumberCertificateFrom > intNumberCertificateTo)
                {
                    XtraMessageBox.Show("Verify number certificate to.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }

                mLista = new InspectionCertificateBL().ListaVendorStatus(Parametros.intEmpresaId, Convert.ToInt32(cboVendor.EditValue), Parametros.intICActive, intNumberCertificateFrom, intNumberCertificateTo);
                gcInspectionCertificate.DataSource = mLista;
                Cursor = Cursors.Default;
                
            }

            

        }

        public static string strRight(string strValue, int intLength)
        {
            string strRet = string.Empty;
            try
            {
                strRet = strValue.Substring(strValue.Length - intLength);
            }
            catch (Exception ex)
            {
                strRet = strValue;
            }
            return strRet;
        }



        #endregion

        
    }
}