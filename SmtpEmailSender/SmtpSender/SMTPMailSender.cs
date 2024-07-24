using SmtpEmailSender.Controllers;
using SmtpEmailSender.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmtpEmailSender.SmtpSender
{
    public class SMTPMailSender : ISmtpMailSender
    {
        public async Task Send(MailModel model, SmtpProvider provider)
        {
            var clientUserName = provider.Username;
            var clientPassword = provider.Password;


            SmtpClient client = new SmtpClient
            {
                Host = provider.Host,
                Port = provider.Port,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(clientUserName, clientPassword),
                EnableSsl = true
            };

            //client.ClientCertificates.Add(certificate);

            MailMessage message = new MailMessage();

            var ToAddress = new MailAddress(model.To);

            message.From = new MailAddress(provider.FromMail);
            message.To.Add(ToAddress);

            message.Subject = model.Subject;
            message.IsBodyHtml = true;

            StringBuilder mailBody = new StringBuilder();

            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");

            message.Body = mailBody.ToString();

            //message.Attachments.Insert(0, model.Attachment);

            await client.SendMailAsync(message);

            return;
        }
    }
}