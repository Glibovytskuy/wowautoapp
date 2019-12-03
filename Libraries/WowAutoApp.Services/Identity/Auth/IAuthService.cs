using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Services.Identity.Auth
{
    public interface IAuthService
    {
        Task<string> GetJwtAsync(string username, string clientId);
        Task<ApplicationUser> GetByUserNameAsync(string username);
        Task<bool> VerifyTwoFactorTokenAsync(string username, string authenticatorCode);
        Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(string username, string code);
    }
}