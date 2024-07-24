namespace SmtpEmailSender.Models
{
    public class ActiveSyncProvider
    {
        public string Domain { get; set; }
        public string ServiceUrl { get; set; }
        public string FromMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
