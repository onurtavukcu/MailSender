using System.Net.Mail;

namespace SmtpEmailSender.Models
{
    public class MailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public Attachment Attachment { get; set; }
    }
}
