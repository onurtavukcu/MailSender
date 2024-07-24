namespace SmtpEmailSender.Models
{
    public class SmtpProvider
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string FromMail { get; set; }
        public string FromMailName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}