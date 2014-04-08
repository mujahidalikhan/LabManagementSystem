using System;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using LMIS.DBController;

namespace LMIS.Admin
{
    internal class Helper
    {

        private static readonly DbController objEngageController = new DbController();
        public Helper()
        {

        }

        public static void PrintWebControl(Control ctrl, string template)
        {
            PrintWebControl(ctrl, string.Empty, template);
        }

        public static void PrintWebControl(Control ctrl, string Script, string template)
        {
            string strHTML;
            using (var stringWrite = new StringWriter())
            {
                var htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                var webControl = ctrl as WebControl;
                if (webControl != null)
                {
                    var w = new Unit(100, UnitType.Percentage);
                    webControl.Width = w;
                }
                var pg = new Page {EnableEventValidation = false};
                if (Script != string.Empty)
                {
                    pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
                }
                var frm = new HtmlForm();
                pg.Controls.Add(frm);
                frm.Attributes.Add("runat", "server");
                frm.Controls.Add(ctrl);
                pg.DesignerInitialize();
                pg.RenderControl(htmlWrite);
                strHTML = template + stringWrite.ToString();
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }



        public static void EmailWebControl(Control ctrl, string emailToAddress, string emailTemplate)
        {
            EmailWebControl(ctrl, string.Empty, emailToAddress, emailTemplate);
        }

        public static void EmailWebControl(Control ctrl, string Script, String emailToAddress, string emailTemplate)
        {
            string strHTML;
            using (var stringWrite = new StringWriter())
            {
                var htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                if (ctrl is WebControl)
                {
                    var w = new Unit(100, UnitType.Percentage);
                    ((WebControl)ctrl).Width = w;
                }
                var pg = new Page { EnableEventValidation = false };
                if (Script != string.Empty)
                {
                    pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
                }
                var frm = new HtmlForm();
                pg.Controls.Add(frm);
                frm.Attributes.Add("runat", "server");
                frm.Controls.Add(ctrl);
                pg.DesignerInitialize();
                pg.RenderControl(htmlWrite);
                strHTML = stringWrite.ToString();
            }
            emailTemplate += strHTML;
            var objSmtpSetting = objEngageController.GetSmtpSetting();
            try
            {
                using (var mail = new System.Net.Mail.MailMessage())
                {
                    using (var smtpServer = new System.Net.Mail.SmtpClient(objSmtpSetting.ServerAddress))
                    {
                        mail.From = new System.Net.Mail.MailAddress(objSmtpSetting.FromEmail);
                        mail.To.Add(emailToAddress);
                        mail.IsBodyHtml = true;
                        mail.Subject = "E-Card LMIS ";
                        mail.Body = strHTML;
                        smtpServer.Port = objSmtpSetting.ServerPort;
                        smtpServer.Credentials = new System.Net.NetworkCredential(objSmtpSetting.UserName,objSmtpSetting.Password);
                        smtpServer.EnableSsl = true;
                        smtpServer.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {


                try
                {
                    System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/smtpserver",
                         objSmtpSetting.ServerAddress);
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/smtpserverport",
                         objSmtpSetting.ServerPort.ToString());
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/sendusing",
                         "2");
                    //sendusing: cdoSendUsingPort, value 2, for sending the message using 
                    //the network.

                    //smtpauthenticate: Specifies the mechanism used when authenticating 
                    //to an SMTP 
                    //service over the network. Possible values are:
                    //- cdoAnonymous, value 0. Do not authenticate.
                    //- cdoBasic, value 1. Use basic clear-text authentication. 
                    //When using this option you have to provide the user name and password 
                    //through the sendusername and sendpassword fields.
                    //- cdoNTLM, value 2. The current process security context is used to 
                    // authenticate with the service.
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                    //Use 0 for anonymous
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/sendusername",
                         objSmtpSetting.FromEmail);
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/sendpassword",
                         objSmtpSetting.Password);
                    myMail.Fields.Add
                        ("http://schemas.microsoft.com/cdo/configuration/smtpusessl",
                         "true");
                    myMail.From = objSmtpSetting.FromEmail;
                    myMail.To = emailToAddress;
                    myMail.Subject = "E-Card LMIS ";
                    myMail.BodyFormat = MailFormat.Html;
                    myMail.Body = emailTemplate;


                    System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
                    System.Web.Mail.SmtpMail.Send(myMail);

                }
                catch (Exception exc)
                {

                }
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("E Card send successfuly");
            HttpContext.Current.Response.Write("<script>window.close();</script>");
            HttpContext.Current.Response.End();
        }
    }
}