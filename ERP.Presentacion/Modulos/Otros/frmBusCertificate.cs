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

namespace ERP.Presentacion.Modulos.Otros
{
    public partial class frmBusCertificate : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public int IdClient { get; set; }

        private List<InspectionCertificateBE> mLista = new List<InspectionCertificateBE>();
        public List<String> mListaCertificate = new List<String>();

        #endregion

        #region "Eventos"

        public frmBusCertificate()
        {
            InitializeComponent();
        }

        private void frmBusCertificate_Load(object sender, EventArgs e)
        {
            gvInspectionCertificate.Columns["IssueDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvInspectionCertificate.Columns["IssueDate"].DisplayFormat.FormatString = "MM/dd/yyyy";
            Cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    int[] rows = gvInspectionCertificate.GetSelectedRows();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        mListaCertificate.Add(gvInspectionCertificate.GetRowCellValue(rows[i], gvInspectionCertificate.Columns.ColumnByFieldName("NumberCertificate")).ToString());
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            mLista = new InspectionCertificateBL().ListaClient(Parametros.intEmpresaId, IdClient, Parametros.intICActive);
            gcInspectionCertificate.DataSource = mLista;

            Cursor = Cursors.Default;

        }


        #endregion

        
    }
}