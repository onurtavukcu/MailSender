using SmtpEmailSender.Models;

namespace SmtpEmailSender.SmtpSender
{
    public interface ISmtpMailSender
    {
        public Task Send(MailModel model, SmtpProvider provider);
    }
}
