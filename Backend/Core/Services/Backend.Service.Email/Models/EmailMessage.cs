using MimeKit;

namespace Backend.Service.Email.Models
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public MimeEntity Body { get; set; }
        public string Title { get; set; }
    }
}
