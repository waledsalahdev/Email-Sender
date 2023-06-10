using Email_Sender.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Email_Sender.Services
{
    public class MailService : IMailservice
    {
        private readonly MailSettings _mailsettings;

        public MailService(IOptions<MailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }

        public async Task SendEmailAsync(List<string> mailto, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailsettings.DisplayName, _mailsettings.Mail));
            foreach (var to in mailto)
            {
                email.To.Add(MailboxAddress.Parse(to));

            }
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };
            using var smtp = new SmtpClient();
            smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailsettings.Mail, _mailsettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}
