using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace WowAutoApp.Services.Email.Smtp
{
    public class SmtpEmailService : IEmailService
    {
        private readonly IOptions<SmtpOptions> _smtpOptions;

        public SmtpEmailService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions;
        }

        public void Send(Core.Domain.Emails.Email email)
        {
            Send(email.Body, email.Subject, email.From, email.To);
        }

        public void Send(string body, string subject, string from, string to)
        {
            var message = GetMailMessage(body, subject, from, to);
            CreateSmtpClient().Send(message);
        }

        // TODO: Refactor: Consider creating some base MailMessage type and using it instead
        public async Task SendAsync(Core.Domain.Emails.Email email)
        {
            await SendAsync(email.Body, email.Subject, email.From, email.To);
        }

        public async Task SendAsync(string body, string subject, string from, string to)
        {
            var message = GetMailMessage(body, subject, from, to);

            //ToDo: Do not add await, it will prevent asynchronous method execution.
            //To avoid warning maybe we should make this method void
            Task.Run(async () =>
            {
                await CreateSmtpClient().SendMailAsync(message);
            });
        }

        private MailMessage GetMailMessage(string body, string subject, string from, string to)
        {
            return new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,

                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            };
        }

        private SmtpClient CreateSmtpClient()
        {
            var options = _smtpOptions.Value;
            return new SmtpClient(options.Host, options.Port)
            {
                Credentials = new NetworkCredential(options.UserName, options.Password),
                EnableSsl = options.EnableSsl
            };
        }
    }
}