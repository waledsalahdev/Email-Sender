namespace Email_Sender.Services
{
    public interface IMailservice
    {
        Task SendEmailAsync(List<string> mailto, string subject,string message);

    }
}
