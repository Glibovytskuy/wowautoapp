using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Email;
using WowAutoApp.Services.Identity.User;

namespace WowAutoApp.Services.Identity.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserService _userService;
        private readonly IEmailExtensionService _emailService;

        public RegistrationService(IUserService userService, IEmailExtensionService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        // TODO: Get rid of IdentityResult, introduce own IServiceResult
        public async Task<bool> RegisterAsync(ApplicationUser user, string password, string baseUrl)
        {
            user.FirstName = Regex.Replace(user.FirstName, @"\s+", " ").Trim();
            user.LastName = Regex.Replace(user.LastName, @"\s+", " ").Trim();

            var result = await _userService.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var token = new Email.Token.EmailToken
                {
                    Email = user.UserName,
                    Token = await _userService.GetEmailVerificationTokenAsync(user.UserName)
                };
                await _emailService.SendVerificationEmailAsync(token, baseUrl);
            }

            return result.Succeeded;
        }
    }
}