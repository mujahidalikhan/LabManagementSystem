using System;
using LMIS.DBController;
using LMIS.DBModel;
namespace LMIS.Admin
{
    public partial class UpdateSmtpSetting : System.Web.UI.Page
    {


        static readonly DbController objDbController = new DbController();
        private SmtpSetting objSmtpSetting;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSmtpSetting = objDbController.GetSmtpSetting();
                serverAddress.Text = objSmtpSetting.ServerAddress;
                serverPort.Text = objSmtpSetting.ServerPort.ToString();
                userName.Text = objSmtpSetting.UserName;
                userPasswrod.Text = objSmtpSetting.Password;
                fromName.Text = objSmtpSetting.FromName;
                fromEmail.Text = objSmtpSetting.FromEmail;
            }
        }

      
        protected void btnUpdateSmtpSetting_Click(object sender, EventArgs e)
        {
            objDbController.UpdateSmtpSettings(serverAddress.Text, Int32.Parse(serverPort.Text), userName.Text,
                                               userPasswrod.Text, fromName.Text, fromEmail.Text, EnableSSL.Checked);
        }
    }
}