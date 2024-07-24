using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmtpEmailSender.Models;
using SmtpEmailSender.SmtpSender;

namespace SmtpEmailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmtpMailSenderController : ControllerBase
    {
        public SmtpProvider _provider { get; set; }
        public ISmtpMailSender _mailSender { get; set; }
        public SmtpMailSenderController(IOptions<SmtpProvider> provider, ISmtpMailSender mailSender)
        {
            _provider = provider.Value;
            _mailSender = mailSender;
        }

        [HttpPost(Name = "Send")]
        public async void Get([FromBody] MailModel model)
        {
            await _mailSender.Send(model, _provider);

            return ;
        }
    }
}
