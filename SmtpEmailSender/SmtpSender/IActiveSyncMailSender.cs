using SmtpEmailSender.Models;

namespace SmtpEmailSender.SmtpSender
{
    public interface IActiveSyncMailSender
    {
        public Task Send(MailModel model, ActiveSyncProvider provider);
    }
}
