


namespace FlexTweak.Functions
{
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
