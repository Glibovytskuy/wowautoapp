using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Identity.User;

namespace WowAutoApp.Services.Identity.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserService _userService;

        // TODO: Investigate if it is possible to abstracted out userrManager and Application context should to interfaces
        public RegistrationService(IUserService userService)
        {
            _userService = userService;
        }

        // TODO: Get rid of IdentityResult, introduce own IServiceResult
        public async Task<bool> RegisterAsync(ApplicationUser user, string password, string baseUrl)
        {
            user.FirstName = Regex.Replace(user.FirstName, @"\s+", " ").Trim();
            user.LastName = Regex.Replace(user.LastName, @"\s+", " ").Trim();

            var result = await _userService.CreateAsync(user, password);
            return result.Succeeded;
        }
    }
}