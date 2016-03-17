using System.Net.Mail;

using Abp.Configuration;
using Castle.Core.Logging;
using Abp.Dependency;
using Abp;
using Abp.Domain.Services;

namespace Taskever.Utils.Mail
{
    /// <summary>
    /// Implements <see cref="IEmailService"/> to send emails using current settings.
    /// </summary>
    public class EmailService : DomainService, IEmailService
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailService"/>.
        /// </summary>
        public EmailService()
        {
            // Logger = NullLogger.Instance;
            Logger.Debug("Created Email Service..");
        }

        public void SendEmail(MailMessage mail)
        {
            //try
            //{
                //TODO: Replacce Setting helper with provider details
                mail.From = new MailAddress(SettingManager.GetSettingValue("Abp.Net.Mail.SenderAddress"), SettingManager.GetSettingValue("Abp.Net.Mail.DisplayName"));
                using (var client = new SmtpClient(SettingManager.GetSettingValue("Abp.Net.Mail.ServerAddress"), SettingManager.GetSettingValue<int>("Abp.Net.Mail.ServerPort")))
                {
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential(SettingManager.GetSettingValue("Abp.Net.Mail.Username"), SettingManager.GetSettingValue("Abp.Net.Mail.Password"));
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