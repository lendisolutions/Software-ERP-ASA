using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace ERP.Presentacion.Utils
{
    public  class BSUtils
    {
        public static void LoaderLook(LookUpEdit Control, object DataSource, string FieldDisplay, string FieldValue, bool DefaulValue)
        {
            var _with1 = Control;
            _with1.Properties.DataSource = DataSource;
            _with1.Properties.Columns.Clear();
            _with1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(FieldDisplay, 200, "Descripción"));
            _with1.Properties.DisplayMember = FieldDisplay;
            _with1.Properties.ValueMember = FieldValue;
            if (DefaulValue)
                _with1.ItemIndex = 0;
            else
                _with1.EditValue = null;

        }

        public static void EmailSend(string MailTo, string Titulo, string Mensaje, string ArchivoEnvio1, string ArchivoEnvio2, string ArchivoEnvio3, string ArchivoEnvio4)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress("info_asatextile@asatextile.com", "Software de Gestión Textil "); //Quien Envia

            String[] AMailto = MailTo.Split(';');
            foreach (String strMail in AMailto)
            {
                mail.To.Add(strMail);  //Mail de la persona a enviar
            }

            mail.Body = Mensaje;
            mail.IsBodyHtml = false;
            mail.Priority = System.Net.Mail.MailPriority.High;  //Esto deberia evitar que los mails vayan al folder Junk-Email.            
            mail.Subject = Titulo;

            MailAddress copy1 = new MailAddress("jose_briones@asatextile.com");
            mail.CC.Add(copy1);

            //MailAddress copy2 = new MailAddress("zmonteverde@crosland.com.pe");
            //mail.CC.Add(copy2);

            if (ArchivoEnvio1.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio1);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio2.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio2);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio3.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio3);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio4.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio4);
                mail.Attachments.Add(attachment);
            }

            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("mail.asatextile.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info_asatextile@asatextile.com", "4s4t3xt1l3");
            smtpClient.Credentials = basicAuthenticationInfo;
            smtpClient.EnableSsl = false;

            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object s
                   , X509Certificate certificate
                   , X509Chain chai
                   , SslPolicyErrors sslPolicyErrors)
               { return true; };

            smtpClient.Send(mail);

            mail.Dispose();
            smtpClient.Dispose();
        }

        public static void OpenExcel(string file)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = file;
            Process.Start(startInfo);
        }

        public static string GetDateFormat(DateTime deDate)
        {
            String strDateFormat = "";
            strDateFormat = deDate.ToString("MM/dd/yyyy");


            return strDateFormat;
        }
    }
}
