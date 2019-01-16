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
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP.BusinessEntity;
using ERP.BusinessLogic;
using ERP.Presentacion.Utils;
using ERP.Presentacion.Funciones;
using ERP.Presentacion.Modulos.Otros;


namespace ERP.Presentacion.Modulos.Administration.Registros
{
    public partial class frmRegClientEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClientBE> lstClient;
        public List<CClientAddress> mListaClientAddressOrigen = new List<CClientAddress>();
        public List<CClientContact> mListaClientContactOrigen = new List<CClientContact>();
        public List<CClientDepartment> mListaClientDepartmentOrigen = new List<CClientDepartment>();
        public List<CClientGoal> mListaClientGoalOrigen = new List<CClientGoal>();
        public List<CClientDocument> mListaClientDocumentOrigen = new List<CClientDocument>();
        public List<CClientBrand> mListaClientBrandOrigen = new List<CClientBrand>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdClient = 0;

        public int IdClient
        {
            get { return _IdClient; }
            set { _IdClient = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegClientEdit()
        {
            InitializeComponent();
        }

        private void frmRegClientEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCorporation, new CorporationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameCorporation", "IdCorporation", true);
            cboCorporation.EditValue = 0;
            BSUtils.LoaderLook(cboEvaluation, new EvaluationBL().ListaTodosActivo(Parametros.intEmpresaId), "NameEvaluation", "IdEvaluation", true);
            cboEvaluation.EditValue = 0;
            deRevenueDate.DateTime = DateTime.Now;

            deRevenueDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            deRevenueDate.Properties.Mask.EditMask = "MM/dd/yyyy";
            deRevenueDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            deRevenueDate.Properties.CharacterCasing = CharacterCasing.Upper;

            gvClientDocument.Columns["RegisterDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvClientDocument.Columns["RegisterDate"].DisplayFormat.FormatString = "MM/dd/yyyy";

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Client - New";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Client - Update";

                ClientBE objE_Client = null;
                objE_Client = new ClientBL().Selecciona(IdClient);
                if (objE_Client != null)
                {
                    IdClient = objE_Client.IdClient;
                    txtNameClient.Text = objE_Client.NameClient;
                    cboCorporation.EditValue = objE_Client.IdCorporation;
                    cboEvaluation.EditValue = objE_Client.IdEvaluation;
                    deRevenueDate.EditValue = objE_Client.RevenueDate;
                    txtCertificate.Text = objE_Client.Certificate;
                    txtPercentComision1.EditValue = objE_Client.PercentComision1;
                    txtPercentComision2.EditValue = objE_Client.PercentComision2;
                    txtPercentComision3.EditValue = objE_Client.PercentComision3;
                    txtComment.Text = objE_Client.Comment;
                    txtSituation.Text = objE_Client.Situation;
                }
            }

            CargaClientAddress();
            CargaClientContact();
            CargaClientDepartment();
            CargaClientGoal();
            CargaClientDocument();
            CargaClientBrand();

            txtNameClient.SelectAll();
        }

        private void nuevoClientAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (mListaClientAddressOrigen.Count > 0)
                    i = mListaClientAddressOrigen.Max(ob => Convert.ToInt32(ob.Sequence));

                gvClientAddress.AddNewRow();
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "IdClient", 0);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "IdClientAddress", 0);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Sequence", Convert.ToInt32(i) + 1);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "IdType", 0);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "NameType", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Destination", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "City", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "State", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "IdCountry", 0);
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "NameCountry", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Phone1", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Phone2", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Fax", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Email", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "WebPage", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "Reference", "");
                gvClientAddress.SetRowCellValue(gvClientAddress.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvClientAddress.FocusedColumn = gvClientAddress.Columns["NameType"];
                gvClientAddress.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarClientAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientAddress = 0;
                if (gvClientAddress.GetFocusedRowCellValue("IdClientAddress") != null)
                    IdClientAddress = int.Parse(gvClientAddress.GetFocusedRowCellValue("IdClientAddress").ToString());
                ClientAddressBE objBE_ClientAddress = new ClientAddressBE();
                objBE_ClientAddress.IdClientAddress = IdClientAddress;
                objBE_ClientAddress.IdCompany = Parametros.intEmpresaId;
                objBE_ClientAddress.Login = Parametros.strUsuarioLogin;
                objBE_ClientAddress.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientAddressBL objBL_ClientAddress = new ClientAddressBL();
                objBL_ClientAddress.Elimina(objBE_ClientAddress);
                gvClientAddress.DeleteRow(gvClientAddress.FocusedRowHandle);
                gvClientAddress.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusType frm = new frmBusType();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvClientAddress.FocusedRowHandle;
                        gvClientAddress.SetRowCellValue(index, "IdType", frm._Be.IdType);
                        gvClientAddress.SetRowCellValue(index, "NameType", frm._Be.NameType);

                        gvClientAddress.FocusedColumn = gvClientAddress.Columns["Destination"];
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusDestination frm = new frmBusDestination();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvClientAddress.FocusedRowHandle;
                        gvClientAddress.SetRowCellValue(index, "IdCountry", frm._Be.IdDestination);
                        gvClientAddress.SetRowCellValue(index, "NameCountry", frm._Be.NameDestination);

                        gvClientAddress.FocusedColumn = gvClientAddress.Columns["Phone1"];
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountry_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmBusDestination frm = new frmBusDestination();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    int index = gvClientAddress.FocusedRowHandle;
                    gvClientAddress.SetRowCellValue(index, "IdCountry", frm._Be.IdDestination);
                    gvClientAddress.SetRowCellValue(index, "NameCountry", frm._Be.NameDestination);

                    gvClientAddress.FocusedColumn = gvClientAddress.Columns["Phone1"];
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoClientContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvClientContact.AddNewRow();
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "IdClient", 0);
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "IdClientContact", 0);
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Name", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "FirtsName", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Company", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Occupation", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "IdCountry", 0);
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "NameCountry", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Phone1", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Phone2", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "CelPhone", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Fax", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "Email", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "InformationAdditional", "");
                gvClientContact.SetRowCellValue(gvClientContact.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvClientContact.FocusedColumn = gvClientContact.Columns["Name"];
                gvClientContact.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarClientContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientContact = 0;
                if (gvClientContact.GetFocusedRowCellValue("IdClientContact") != null)
                    IdClientContact = int.Parse(gvClientContact.GetFocusedRowCellValue("IdClientContact").ToString());
                ClientContactBE objBE_ClientContact = new ClientContactBE();
                objBE_ClientContact.IdClientContact = IdClientContact;
                objBE_ClientContact.IdCompany = Parametros.intEmpresaId;
                objBE_ClientContact.Login = Parametros.strUsuarioLogin;
                objBE_ClientContact.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientContactBL objBL_ClientContact = new ClientContactBL();
                objBL_ClientContact.Elimina(objBE_ClientContact);
                gvClientContact.DeleteRow(gvClientContact.FocusedRowHandle);
                gvClientContact.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountryContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusDestination frm = new frmBusDestination();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvClientContact.FocusedRowHandle;
                        gvClientContact.SetRowCellValue(index, "IdCountry", frm._Be.IdDestination);
                        gvClientContact.SetRowCellValue(index, "NameCountry", frm._Be.NameDestination);

                        gvClientContact.FocusedColumn = gvClientContact.Columns["Phone1"];
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCountryContact_Click(object sender, EventArgs e)
        {
            try
            {
               
                frmBusDestination frm = new frmBusDestination();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    int index = gvClientContact.FocusedRowHandle;
                    gvClientContact.SetRowCellValue(index, "IdCountry", frm._Be.IdDestination);
                    gvClientContact.SetRowCellValue(index, "NameCountry", frm._Be.NameDestination);

                    gvClientContact.FocusedColumn = gvClientContact.Columns["Phone1"];
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoClientDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (mListaClientDepartmentOrigen.Count > 0)
                    i = mListaClientDepartmentOrigen.Max(ob => Convert.ToInt32(ob.Code));

                gvClientDepartment.AddNewRow();
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "IdClient", 0);
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "IdClientDepartment", 0);
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "Code", FuncionBase.AgregarCaracter(Convert.ToInt32(i + 1).ToString(), "0", 3) );
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "NameDivision", "");
                gvClientDepartment.SetRowCellValue(gvClientDepartment.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvClientDepartment.FocusedColumn = gvClientDepartment.Columns["NameDivision"];
                gvClientDepartment.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarClientDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientDepartment = 0;
                if (gvClientDepartment.GetFocusedRowCellValue("IdClientDepartment") != null)
                    IdClientDepartment = int.Parse(gvClientDepartment.GetFocusedRowCellValue("IdClientDepartment").ToString());
                ClientDepartmentBE objBE_ClientDepartment = new ClientDepartmentBE();
                objBE_ClientDepartment.IdClientDepartment = IdClientDepartment;
                objBE_ClientDepartment.IdCompany = Parametros.intEmpresaId;
                objBE_ClientDepartment.Login = Parametros.strUsuarioLogin;
                objBE_ClientDepartment.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientDepartmentBL objBL_ClientDepartment = new ClientDepartmentBL();
                objBL_ClientDepartment.Elimina(objBE_ClientDepartment);
                gvClientDepartment.DeleteRow(gvClientDepartment.FocusedRowHandle);
                gvClientDepartment.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoClientGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvClientGoal.AddNewRow();
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "IdClient", 0);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "IdClientGoal", 0);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "Year", 0);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "Month", 0);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "Goal", 0);
            gvClientGoal.SetRowCellValue(gvClientGoal.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

            gvClientGoal.FocusedColumn = gvClientGoal.Columns["Year"];
            gvClientGoal.ShowEditor();
        }

        private void eliminarClientGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientGoal = 0;
                if (gvClientGoal.GetFocusedRowCellValue("IdClientGoal") != null)
                    IdClientGoal = int.Parse(gvClientGoal.GetFocusedRowCellValue("IdClientGoal").ToString());
                ClientGoalBE objBE_ClientGoal = new ClientGoalBE();
                objBE_ClientGoal.IdClientGoal = IdClientGoal;
                objBE_ClientGoal.IdCompany = Parametros.intEmpresaId;
                objBE_ClientGoal.Login = Parametros.strUsuarioLogin;
                objBE_ClientGoal.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientGoalBL objBL_ClientGoal = new ClientGoalBL();
                objBL_ClientGoal.Elimina(objBE_ClientGoal);
                gvClientGoal.DeleteRow(gvClientGoal.FocusedRowHandle);
                gvClientGoal.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoClientDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fStreamArchivo = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Pdf\\Vacio.pdf"));
                byte[] Archive = new byte[fStreamArchivo.Length];
                fStreamArchivo.Read(Archive, 0, (int)fStreamArchivo.Length);
                fStreamArchivo.Close();

                gvClientDocument.AddNewRow();
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "IdClient", 0);
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "IdClientDocument", 0);
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "RegisterDate", DateTime.Now);
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "TitleDocument", "");
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "NameDocument", "Vacio.pdf");
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "Archive", Archive);
                gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvClientDocument.FocusedColumn = gvClientDocument.Columns["TitleDocument"];
                gvClientDocument.ShowEditor();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaClientDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientDocument = 0;
                if (gvClientDocument.GetFocusedRowCellValue("IdClientDocument") != null)
                    IdClientDocument = int.Parse(gvClientDocument.GetFocusedRowCellValue("IdClientDocument").ToString());
                ClientDocumentBE objBE_ClientDocument = new ClientDocumentBE();
                objBE_ClientDocument.IdClientDocument = IdClientDocument;
                objBE_ClientDocument.IdCompany = Parametros.intEmpresaId;
                objBE_ClientDocument.Login = Parametros.strUsuarioLogin;
                objBE_ClientDocument.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientDocumentBL objBL_ClientDocument = new ClientDocumentBL();
                objBL_ClientDocument.Elimina(objBE_ClientDocument);
                gvClientDocument.DeleteRow(gvClientDocument.FocusedRowHandle);
                gvClientDocument.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtDocument_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.DefaultExt = ".pdf"; // Default file extension
                    dlg.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension 

                    // Show open file dialog box
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string strRuta = "";
                        string strNombreArchivo = "";

                        strRuta = dlg.FileName;
                        strNombreArchivo = Path.GetFileName(dlg.FileName);

                        FileStream fStreamArchive = File.OpenRead(strRuta);
                        byte[] Archive = new byte[fStreamArchive.Length];
                        fStreamArchive.Read(Archive, 0, (int)fStreamArchive.Length);
                        fStreamArchive.Close();

                       
                        gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "NameDocument", strNombreArchivo);
                        gvClientDocument.SetRowCellValue(gvClientDocument.FocusedRowHandle, "Archive", Archive);


                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtDocument_DoubleClick(object sender, EventArgs e)
        {
            if (gvClientDocument.RowCount > 0)
            {
                string sFilePath = "";
                byte[] Buffer;

                Buffer = (byte[])gvClientDocument.GetFocusedRowCellValue("Archive");

                sFilePath = Path.GetTempFileName();
                File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".pdf"));
                sFilePath = Path.ChangeExtension(sFilePath, ".pdf");
                File.WriteAllBytes(sFilePath, Buffer);

                ProcessStartInfo start = new ProcessStartInfo();
                // Enter in the command line arguments, everything you would enter after the executable name itself
                start.Arguments = sFilePath + " 1";
                // Enter the executable to run, including the complete path
                start.FileName = Path.Combine(Directory.GetCurrentDirectory(), "Pdf\\PdfiumViewer.Demo.exe");
                // Do you want to show a console window?
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = true;
                int exitCode;

                // Run the external process & wait for it to finish
                using (Process proc = Process.Start(start))
                {
                    proc.WaitForExit();

                    // Retrieve the app's exit code
                    exitCode = proc.ExitCode;
                }


            }
        }

        private void nuevoclientbrandtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                
                gvClientBrand.AddNewRow();
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "IdCompany", Parametros.intEmpresaId);
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "IdClient", 0);
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "IdClientBrand", 0);
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "BrandCertificate", "");
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "BrandFacturacion", "");
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "IdDestination", 0);
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "NameDestination", "");
                gvClientBrand.SetRowCellValue(gvClientBrand.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvClientBrand.FocusedColumn = gvClientBrand.Columns["BrandCertificate"];
                gvClientBrand.ShowEditor();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarclientbrandtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClientBrand = 0;
                if (gvClientBrand.GetFocusedRowCellValue("IdClientBrand") != null)
                    IdClientBrand = int.Parse(gvClientBrand.GetFocusedRowCellValue("IdClientBrand").ToString());
                ClientBrandBE objBE_ClientBrand = new ClientBrandBE();
                objBE_ClientBrand.IdClientBrand = IdClientBrand;
                objBE_ClientBrand.IdCompany = Parametros.intEmpresaId;
                objBE_ClientBrand.Login = Parametros.strUsuarioLogin;
                objBE_ClientBrand.Machine = WindowsIdentity.GetCurrent().Name.ToString();

                ClientBrandBL objBL_ClientBrand = new ClientBrandBL();
                objBL_ClientBrand.Elimina(objBE_ClientBrand);
                gvClientBrand.DeleteRow(gvClientBrand.FocusedRowHandle);
                gvClientBrand.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcDestinationBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusDestination frm = new frmBusDestination();
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        int index = gvClientBrand.FocusedRowHandle;
                        gvClientBrand.SetRowCellValue(index, "IdDestination", frm._Be.IdDestination);
                        gvClientBrand.SetRowCellValue(index, "NameDestination", frm._Be.NameDestination);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClientBE objClient = new ClientBE();
                    ClientBL objBL_Client = new ClientBL();

                    objClient.IdClient = IdClient;
                    objClient.NameClient = txtNameClient.Text;
                    objClient.IdCorporation = (int)cboCorporation.EditValue;
                    objClient.IdEvaluation = (int)cboEvaluation.EditValue;
                    objClient.RevenueDate = Convert.ToDateTime(deRevenueDate.DateTime.ToShortDateString());
                    objClient.Certificate = txtCertificate.Text;
                    objClient.PercentComision1 = Convert.ToDecimal(txtPercentComision1.EditValue);
                    objClient.PercentComision2 = Convert.ToDecimal(txtPercentComision2.EditValue);
                    objClient.PercentComision3 = Convert.ToDecimal(txtPercentComision3.EditValue);
                    objClient.Comment = txtComment.Text;
                    objClient.FlagState = true;
                    objClient.Login = Parametros.strUsuarioLogin;
                    objClient.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                    objClient.IdCompany = Parametros.intEmpresaId;

                    //CLIENT ADDRESS
                    List<ClientAddressBE> lstClientAddress = new List<ClientAddressBE>();

                    foreach (var item in mListaClientAddressOrigen)
                    {
                        ClientAddressBE objE_ClientAddress = new ClientAddressBE();
                        objE_ClientAddress.IdCompany = Parametros.intEmpresaId;
                        objE_ClientAddress.IdClient = IdClient;
                        objE_ClientAddress.IdClientAddress = item.IdClientAddress;
                        objE_ClientAddress.Sequence = item.Sequence;
                        objE_ClientAddress.IdType = item.IdType;
                        objE_ClientAddress.Destination = item.Destination;
                        objE_ClientAddress.City = item.City;
                        objE_ClientAddress.State = item.State;
                        objE_ClientAddress.IdCountry = item.IdCountry;
                        objE_ClientAddress.Phone1 = item.Phone1;
                        objE_ClientAddress.Phone2 = item.Phone2;
                        objE_ClientAddress.Fax = item.Fax;
                        objE_ClientAddress.Email = item.Email;
                        objE_ClientAddress.WebPage = item.WebPage;
                        objE_ClientAddress.Reference = item.Reference;
                        objE_ClientAddress.FlagState = true;
                        objE_ClientAddress.Login = Parametros.strUsuarioLogin;
                        objE_ClientAddress.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientAddress.TipoOper = item.TipoOper;
                        lstClientAddress.Add(objE_ClientAddress);
                    }

                    //CLIENT CONTACT
                    List<ClientContactBE> lstClientContact = new List<ClientContactBE>();

                    foreach (var item in mListaClientContactOrigen)
                    {
                        ClientContactBE objE_ClientContact = new ClientContactBE();
                        objE_ClientContact.IdCompany = Parametros.intEmpresaId;
                        objE_ClientContact.IdClient = IdClient;
                        objE_ClientContact.IdClientContact = item.IdClientContact;
                        objE_ClientContact.Name = item.Name;
                        objE_ClientContact.FirtsName = item.FirtsName;
                        objE_ClientContact.Company = item.Company;
                        objE_ClientContact.Occupation = item.Occupation;
                        objE_ClientContact.IdCountry = item.IdCountry;
                        objE_ClientContact.Phone1 = item.Phone1;
                        objE_ClientContact.Phone2 = item.Phone2;
                        objE_ClientContact.CelPhone = item.CelPhone;
                        objE_ClientContact.Fax = item.Fax;
                        objE_ClientContact.Email = item.Email;
                        objE_ClientContact.InformationAdditional = item.InformationAdditional;
                        objE_ClientContact.FlagState = true;
                        objE_ClientContact.Login = Parametros.strUsuarioLogin;
                        objE_ClientContact.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientContact.TipoOper = item.TipoOper;
                        lstClientContact.Add(objE_ClientContact);
                    }

                    //CLIENT DEPARTMENT
                    List<ClientDepartmentBE> lstClientDepartment = new List<ClientDepartmentBE>();

                    foreach (var item in mListaClientDepartmentOrigen)
                    {
                        ClientDepartmentBE objE_ClientDepartment = new ClientDepartmentBE();
                        objE_ClientDepartment.IdCompany = Parametros.intEmpresaId;
                        objE_ClientDepartment.IdClient = IdClient;
                        objE_ClientDepartment.IdClientDepartment = item.IdClientDepartment;
                        objE_ClientDepartment.Code = item.Code;
                        objE_ClientDepartment.NameDivision = item.NameDivision;
                        objE_ClientDepartment.FlagState = true;
                        objE_ClientDepartment.Login = Parametros.strUsuarioLogin;
                        objE_ClientDepartment.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientDepartment.TipoOper = item.TipoOper;
                        lstClientDepartment.Add(objE_ClientDepartment);
                    }

                    //CLIENT GOAL
                    List<ClientGoalBE> lstClientGoal = new List<ClientGoalBE>();

                    foreach (var item in mListaClientGoalOrigen)
                    {
                        ClientGoalBE objE_ClientGoal = new ClientGoalBE();
                        objE_ClientGoal.IdCompany = Parametros.intEmpresaId;
                        objE_ClientGoal.IdClient = IdClient;
                        objE_ClientGoal.IdClientGoal = item.IdClientGoal;
                        objE_ClientGoal.Year = item.Year;
                        objE_ClientGoal.Month = item.Month;
                        objE_ClientGoal.Goal = item.Goal;
                        objE_ClientGoal.FlagState = true;
                        objE_ClientGoal.Login = Parametros.strUsuarioLogin;
                        objE_ClientGoal.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientGoal.TipoOper = item.TipoOper;
                        lstClientGoal.Add(objE_ClientGoal);
                    }

                    //CLIENT DOCUMENT
                    List<ClientDocumentBE> lstClientDocument = new List<ClientDocumentBE>();

                    foreach (var item in mListaClientDocumentOrigen)
                    {
                        ClientDocumentBE objE_ClientDocument = new ClientDocumentBE();
                        objE_ClientDocument.IdCompany = Parametros.intEmpresaId;
                        objE_ClientDocument.IdClient = IdClient;
                        objE_ClientDocument.IdClientDocument = item.IdClientDocument;
                        objE_ClientDocument.RegisterDate = item.RegisterDate;
                        objE_ClientDocument.TitleDocument = item.TitleDocument;
                        objE_ClientDocument.NameDocument = item.NameDocument;
                        objE_ClientDocument.Archive = item.Archive;
                        objE_ClientDocument.FlagState = true;
                        objE_ClientDocument.Login = Parametros.strUsuarioLogin;
                        objE_ClientDocument.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientDocument.TipoOper = item.TipoOper;
                        lstClientDocument.Add(objE_ClientDocument);
                    }

                    //CLIENT BRAND
                    List<ClientBrandBE> lstClientBrand = new List<ClientBrandBE>();

                    foreach (var item in mListaClientBrandOrigen)
                    {
                        ClientBrandBE objE_ClientBrand = new ClientBrandBE();
                        objE_ClientBrand.IdCompany = Parametros.intEmpresaId;
                        objE_ClientBrand.IdClient = IdClient;
                        objE_ClientBrand.IdClientBrand = item.IdClientBrand;
                        objE_ClientBrand.BrandCertificate = item.BrandCertificate;
                        objE_ClientBrand.BrandFacturacion = item.BrandFacturacion;
                        objE_ClientBrand.IdDestination = item.IdDestination;
                        objE_ClientBrand.FlagState = true;
                        objE_ClientBrand.Login = Parametros.strUsuarioLogin;
                        objE_ClientBrand.Machine = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClientBrand.TipoOper = item.TipoOper;
                        lstClientBrand.Add(objE_ClientBrand);
                    }


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Client.Inserta(objClient, lstClientAddress, lstClientContact, lstClientDepartment, lstClientDocument, lstClientGoal, lstClientBrand);
                        XtraMessageBox.Show("the customer record was created.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_Client.Actualiza(objClient, lstClientAddress, lstClientContact, lstClientDepartment, lstClientDocument, lstClientGoal, lstClientBrand);
                        XtraMessageBox.Show("the customer record was updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
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

        private void CargaClientAddress()
        {
            List<ClientAddressBE> lstTmpClientAddress = null;
            lstTmpClientAddress = new ClientAddressBL().ListaTodosActivo(IdClient);

            foreach (ClientAddressBE item in lstTmpClientAddress)
            {
                CClientAddress objE_ClientAddress = new CClientAddress();
                objE_ClientAddress.IdCompany = item.IdCompany;
                objE_ClientAddress.IdClient = item.IdClient;
                objE_ClientAddress.IdClientAddress = item.IdClientAddress;
                objE_ClientAddress.Sequence = item.Sequence;
                objE_ClientAddress.IdType = item.IdType;
                objE_ClientAddress.NameType = item.NameType;
                objE_ClientAddress.Destination = item.Destination;
                objE_ClientAddress.City = item.City;
                objE_ClientAddress.State = item.State;
                objE_ClientAddress.IdCountry = item.IdCountry;
                objE_ClientAddress.NameCountry = item.NameCountry;
                objE_ClientAddress.Phone1 = item.Phone1;
                objE_ClientAddress.Phone2 = item.Phone2;
                objE_ClientAddress.Fax = item.Fax;
                objE_ClientAddress.Email = item.Email;
                objE_ClientAddress.WebPage = item.WebPage;
                objE_ClientAddress.Reference = item.Reference;
                objE_ClientAddress.TipoOper = item.TipoOper;
                mListaClientAddressOrigen.Add(objE_ClientAddress);
            }

            bsListadoClientAddress.DataSource = mListaClientAddressOrigen;
            gcClientAddress.DataSource = bsListadoClientAddress;
            gcClientAddress.RefreshDataSource();
        }

        private void CargaClientContact()
        {
            List<ClientContactBE> lstTmpClientContact = null;
            lstTmpClientContact = new ClientContactBL().ListaTodosActivo(IdClient);

            foreach (ClientContactBE item in lstTmpClientContact)
            {
                CClientContact objE_ClientContact = new CClientContact();
                objE_ClientContact.IdCompany = item.IdCompany;
                objE_ClientContact.IdClient = item.IdClient;
                objE_ClientContact.IdClientContact = item.IdClientContact;
                objE_ClientContact.Name = item.Name;
                objE_ClientContact.FirtsName = item.FirtsName;
                objE_ClientContact.Company = item.Company;
                objE_ClientContact.Occupation = item.Occupation;
                objE_ClientContact.IdCountry = item.IdCountry;
                objE_ClientContact.NameCountry = item.NameCountry;
                objE_ClientContact.Phone1 = item.Phone1;
                objE_ClientContact.Phone2 = item.Phone2;
                objE_ClientContact.CelPhone = item.CelPhone;
                objE_ClientContact.Fax = item.Fax;
                objE_ClientContact.Email = item.Email;
                objE_ClientContact.InformationAdditional = item.InformationAdditional;
                objE_ClientContact.TipoOper = item.TipoOper;
                mListaClientContactOrigen.Add(objE_ClientContact);
            }

            bsListadoClientContact.DataSource = mListaClientContactOrigen;
            gcClientContact.DataSource = bsListadoClientContact;
            gcClientContact.RefreshDataSource();
        }

        private void CargaClientDepartment()
        {
            List<ClientDepartmentBE> lstTmpClientDepartment = null;
            lstTmpClientDepartment = new ClientDepartmentBL().ListaTodosActivo(IdClient);

            foreach (ClientDepartmentBE item in lstTmpClientDepartment)
            {
                CClientDepartment objE_ClientDepartment = new CClientDepartment();
                objE_ClientDepartment.IdCompany = item.IdCompany;
                objE_ClientDepartment.IdClient = item.IdClient;
                objE_ClientDepartment.IdClientDepartment = item.IdClientDepartment;
                objE_ClientDepartment.Code = item.Code;
                objE_ClientDepartment.NameDivision = item.NameDivision;
                objE_ClientDepartment.TipoOper = item.TipoOper;
                mListaClientDepartmentOrigen.Add(objE_ClientDepartment);
            }

            bsListadoClientDepartment.DataSource = mListaClientDepartmentOrigen;
            gcClientDepartment.DataSource = bsListadoClientDepartment;
            gcClientDepartment.RefreshDataSource();
        }

        private void CargaClientGoal()
        {
            List<ClientGoalBE> lstTmpClientGoal = null;
            lstTmpClientGoal = new ClientGoalBL().ListaTodosActivo(IdClient);

            foreach (ClientGoalBE item in lstTmpClientGoal)
            {
                CClientGoal objE_ClientGoal = new CClientGoal();
                objE_ClientGoal.IdCompany = item.IdCompany;
                objE_ClientGoal.IdClient = item.IdClient;
                objE_ClientGoal.IdClientGoal = item.IdClientGoal;
                objE_ClientGoal.Year = item.Year;
                objE_ClientGoal.Month = item.Month;
                objE_ClientGoal.Goal = item.Goal;
                objE_ClientGoal.TipoOper = item.TipoOper;
                mListaClientGoalOrigen.Add(objE_ClientGoal);
            }

            bsListadoClientGoal.DataSource = mListaClientGoalOrigen;
            gcClientGoal.DataSource = bsListadoClientGoal;
            gcClientGoal.RefreshDataSource();
        }

        private void CargaClientDocument()
        {
            List<ClientDocumentBE> lstTmpClientDocument = null;
            lstTmpClientDocument = new ClientDocumentBL().ListaTodosActivo(IdClient);

            foreach (ClientDocumentBE item in lstTmpClientDocument)
            {
                CClientDocument objE_ClientDocument = new CClientDocument();
                objE_ClientDocument.IdCompany = item.IdCompany;
                objE_ClientDocument.IdClient = item.IdClient;
                objE_ClientDocument.IdClientDocument = item.IdClientDocument;
                objE_ClientDocument.RegisterDate = item.RegisterDate;
                objE_ClientDocument.TitleDocument = item.TitleDocument;
                objE_ClientDocument.NameDocument = item.NameDocument;
                objE_ClientDocument.Archive = item.Archive;
                objE_ClientDocument.TipoOper = item.TipoOper;
                mListaClientDocumentOrigen.Add(objE_ClientDocument);
            }

            bsListadoClientDocument.DataSource = mListaClientDocumentOrigen;
            gcClientDocument.DataSource = bsListadoClientDocument;
            gcClientDocument.RefreshDataSource();
        }

        private void CargaClientBrand()
        {
            List<ClientBrandBE> lstTmpClientBrand = null;
            lstTmpClientBrand = new ClientBrandBL().ListaTodosActivo(IdClient);

            foreach (ClientBrandBE item in lstTmpClientBrand)
            {
                CClientBrand objE_ClientBrand = new CClientBrand();
                objE_ClientBrand.IdCompany = item.IdCompany;
                objE_ClientBrand.IdClient = item.IdClient;
                objE_ClientBrand.IdClientBrand = item.IdClientBrand;
                objE_ClientBrand.BrandCertificate = item.BrandCertificate;
                objE_ClientBrand.BrandFacturacion = item.BrandFacturacion;
                objE_ClientBrand.IdDestination = item.IdDestination;
                objE_ClientBrand.NameDestination = item.NameDestination;
                objE_ClientBrand.TipoOper = item.TipoOper;
                mListaClientBrandOrigen.Add(objE_ClientBrand);
            }

            bsListadoClientBrand.DataSource = mListaClientBrandOrigen;
            gcClientBrand.DataSource = bsListadoClientBrand;
            gcClientBrand.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "Could not register:\n";

            if (txtNameClient.Text == "")
            {
                strMensaje = strMensaje + "- You must enter the customer's name.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        public class CClientAddress
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientAddress { get; set; }
            public Int32 Sequence { get; set; }
            public Int32 IdType { get; set; }
            public String NameType { get; set; }
            public String Destination { get; set; }
            public String City { get; set; }
            public String State { get; set; }
            public Int32 IdCountry { get; set; }
            public String NameCountry { get; set; }
            public String Phone1 { get; set; }
            public String Phone2 { get; set; }
            public String Fax { get; set; }
            public String Email { get; set; }
            public String WebPage { get; set; }
            public String Reference { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientAddress()
            {

            }
        }

        public class CClientContact
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientContact { get; set; }
            public String Name { get; set; }
            public String FirtsName { get; set; }
            public String Company { get; set; }
            public String Occupation { get; set; }
            public Int32 IdCountry { get; set; }
            public String NameCountry { get; set; }
            public String Phone1 { get; set; }
            public String Phone2 { get; set; }
            public String CelPhone { get; set; }
            public String Fax { get; set; }
            public String Email { get; set; }
            public String InformationAdditional { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientContact()
            {

            }
        }

        public class CClientDepartment
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientDepartment { get; set; }
            public String Code { get; set; }
            public String NameDivision { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientDepartment()
            {

            }
        }

        public class CClientGoal
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientGoal { get; set; }
            public Int32 Year { get; set; }
            public Int32 Month { get; set; }
            public Decimal Goal { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientGoal()
            {

            }
        }

        public class CClientDocument
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientDocument { get; set; }
            public DateTime RegisterDate { get; set; }
            public String TitleDocument { get; set; }
            public String NameDocument { get; set; }
            public byte[] Archive { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientDocument()
            {

            }
        }

        public class CClientBrand
        {
            public Int32 IdCompany { get; set; }
            public Int32 IdClient { get; set; }
            public Int32 IdClientBrand { get; set; }
            public String BrandCertificate { get; set; }
            public String BrandFacturacion { get; set; }
            public Int32 IdDestination { get; set; }
            public String NameDestination { get; set; }
            public Int32 TipoOper { get; set; }

            public CClientBrand()
            {

            }
        }

        
    }
}