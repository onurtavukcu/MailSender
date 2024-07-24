using Microsoft.Exchange.WebServices.Data;
using SmtpEmailSender.Models;
using System.Net;

namespace SmtpEmailSender.SmtpSender
{
    public class ActiveSyncMailSender : IActiveSyncMailSender
    {
        public async System.Threading.Tasks.Task Send(MailModel model, ActiveSyncProvider provider)
        {
            try
            {
                var activeSyncProvider = new ActiveSyncProvider
                {
                    Domain = provider.Domain,
                    FromMail = provider.FromMail,
                    Password = provider.Password,
                    ServiceUrl = provider.ServiceUrl,
                    Username = provider.Username
                };

                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

                service.Credentials =
                            new NetworkCredential
                            (
                                activeSyncProvider.Username,
                                activeSyncProvider.Password,
                                activeSyncProvider.Domain
                            );

                service.Url = new Uri(activeSyncProvider.ServiceUrl);


                EmailMessage mailMessage = new EmailMessage(service);

                mailMessage.ToRecipients.Add(model.To);

                mailMessage.From = new EmailAddress(activeSyncProvider.FromMail);

                mailMessage.Subject = model.Subject;

                mailMessage.Body = model.Body;

                mailMessage.Send();

                await System.Threading.Tasks.Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
