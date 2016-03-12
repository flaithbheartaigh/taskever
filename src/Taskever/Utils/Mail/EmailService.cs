using System.Net.Mail;

using Abp.Configuration;
using Castle.Core.Logging;

namespace Taskever.Utils.Mail
{
    /// <summary>
    /// Implements <see cref="IEmailService"/> to send emails using current settings.
    /// </summary>
    public class EmailService : IEmailService
    {
        public ILogger Logger { get; set; }
        private ISettingManager settingManager;

        /// <summary>
        /// Creates a new instance of <see cref="EmailService"/>.
        /// </summary>
        public EmailService()
        {
            Logger = NullLogger.Instance;
        }

        public void SendEmail(MailMessage mail)
        {
            //try
            //{
                //TODO: Replacce Setting helper with provider details
                mail.From = new MailAddress(settingManager.GetSettingValue("Abp.Net.Mail.SenderAddress"), settingManager.GetSettingValue("Abp.Net.Mail.DisplayName"));
                using (var client = new SmtpClient(settingManager.GetSettingValue("Abp.Net.Mail.ServerAddress"), settingManager.GetSettingValue<int>("Abp.Net.Mail.ServerPort")))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(settingManager.GetSettingValue("Abp.Net.Mail.Username"), settingManager.GetSettingValue("Abp.Net.Mail.Password"));
                    client.Send(mail);
                }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Warn("Could not send email!", ex);
            //}
        }
    }
}