using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Domain.TableFilter;
using WowAutoApp.Core.Infrastructure.Pagination;

namespace WowAutoApp.Services.Identity.User
{
    public interface IUserService
    {
        Task<PagedListResult<ApplicationUser>> GetAllFilteredUsersAsync(TableFilter tableFilter);
        Task<List<ApplicationUser>> GetAllAsync();
        Task<List<ApplicationUser>> GetAllAsyncBy(List<string> userIds);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetByUserNameAsync(string userName);
        Task<ApplicationUser> GetCurrentUserAsync(string userName);
        Task<ApplicationUser> GetByProfileIdAsync(int profileId);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<IList<ApplicationUser>> GetUsersAsync(IEnumerable<string> userIds);
        Task<IList<ApplicationUser>> GetAllUsersWithProfileAsync(List<string> usersIds);

        // TODO: Consider creating own ServiceResult and use it instead of IdentityResult
        Task<IdentityResult> ChangePasswordAsync(string userName, string oldPassword, string newPassword);
        Task<string> GetEmailVerificationTokenAsync(string userName);
        Task<string> GetPasswordResetTokenAsync(string userName);
        Task<string> GetAuthenticatorKeyAsync(string userName);
        Task<string> GetAuthenticatorKeyAsync(ApplicationUser user);

        Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user);
        Task<int> CountRecoveryCodesAsync(ApplicationUser user);
        Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token);
        string GetAuthenticationProvider();
        Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool allow);
        Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number);

        Task<IdentityResult> UpdateAsync(string userName, ApplicationUser applicationUser);
        Task<IdentityResult> VerifyEmailAsync(string userName, string token);
        Task<IdentityResult> ResetPasswordAsync(string userName, string token, string newPassword);
    }
}