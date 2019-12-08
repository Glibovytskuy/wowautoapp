using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WowAutoApp.Core.Domain.Emails;
using WowAutoApp.Services.Email.Token;

namespace WowAutoApp.Services.Email
{
    public class EmailExtensionService : IEmailExtensionService
    {
        private readonly IEmailService _emailService;
        private readonly EmailExtensionOptions _options;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public EmailExtensionService(IEmailService emailService, IOptions<EmailExtensionOptions> options, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _emailService = emailService;
            _options = options.Value;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task SendVerificationEmailAsync(EmailToken token, string baseUrl)
        {
            string email = token.Email;
            token.BaseUrl = baseUrl;

            //ToDo: Need to implement icon
            //token.IconUrl = _options.IconUrl;

            //ToDo: Need to implement options
            _options.From = "@gmail.com";

            var body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Email/EmailVerification.cshtml", token);
            await _emailService.SendAsync(body, "WowAutoApp (Verify Email)", "WowAutoApp" + _options.From, email);
        }
    }
}