using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Services.Identity.Registration
{
    public interface IRegistrationService
    {
        Task<bool> RegisterAsync(ApplicationUser user, string password, string baseUrl);
    }
}