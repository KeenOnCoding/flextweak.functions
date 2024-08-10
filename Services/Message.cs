namespace FlexTweak.Functions
{
    using Microsoft.AspNetCore.Http;
    using MimeKit;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public Respon Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {

            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = JsonConvert.DeserializeObject<Respon>(content);
            Attachments = attachments;
        }
    }
    public class Respon
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email  { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
