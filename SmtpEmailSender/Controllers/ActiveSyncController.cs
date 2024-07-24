using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmtpEmailSender.Models;
using SmtpEmailSender.SmtpSender;

namespace SmtpEmailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActiveSyncController : Controller
    {
        public ActiveSyncProvider _provider;
        public IActiveSyncMailSender _mailSender;

        public ActiveSyncController(IOptions<ActiveSyncProvider> provider, IActiveSyncMailSender mailSender)
        {
            _provider = provider.Value;
            _mailSender = mailSender;
        }


        [HttpPost(Name = "ActiveSyncMailSender")]
        public async void Get([FromBody] MailModel model)
        {
            await _mailSender.Send(model, _provider);
            return;
        }
    }
}
