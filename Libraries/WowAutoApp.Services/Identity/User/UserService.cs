using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WowAutoApp.Core.Consts;
using WowAutoApp.Core.Domain;
using WowAutoApp.Core.Domain.TableFilter;
using WowAutoApp.Core.Events;
using WowAutoApp.Core.Infrastructure.Pagination;
using WowAutoApp.Core.Repo;
using WowAutoApp.Services.Profile;

namespace WowAutoApp.Services.Identity.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        private readonly IProfileService _profileService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> applicationUserRepository,
            IProfileService profileService,
            IEventPublisher eventPublisher,
            IMapper mapper)
        {
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
            _profileService = profileService;
            _eventPublisher = eventPublisher;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IList<ApplicationUser>> GetUsersAsync(IEnumerable<string> userIds)
        {
            return await _userManager.Users
                .Where(x => userIds.Contains(x.Id))
                .Include(x => x.Profile)
                .ToListAsync();
        }

        public async Task<IList<ApplicationUser>> GetAllUsersWithProfileAsync(List<string> usersIds)
        {
            var users = await _userManager
                                .Users
                                .Where(x => usersIds.Contains(x.Id))
                                .Include(x => x.Profile)
                                .ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _userManager.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(m => m.Email == email);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userName, string oldPassword, string newPassword)
        {
            var user = await GetByUserNameAsync(userName);
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return changePasswordResult;
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            var userList = await _userManager.Users.ToListAsync();
            return userList;
        }

        public async Task<List<ApplicationUser>> GetAllAsyncBy(List<string> userIds)
        {
            var userList = await _userManager
                                    .Users
                                    .Where(x => userIds.Contains(x.Id))
                                    .Include(x => x.Profile)
                                    .OrderBy(x => x.FirstName)
                                    .ThenBy(x => x.LastName)
                                    .ToListAsync();
            return userList;
        }

        public async Task<string> GetAuthenticatorKeyAsync(string userName)
        {
            var user = await GetByUserNameAsync(userName);
            var token = await _userManager.GetAuthenticatorKeyAsync(user);

            return token;
        }

        public Task<string> GetAuthenticatorKeyAsync(ApplicationUser user)
        {
            return _userManager.GetAuthenticatorKeyAsync(user);
        }

        public async Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user)
        {
            return await _userManager.ResetAuthenticatorKeyAsync(user);
        }

        public async Task<ApplicationUser> GetByUserNameAsync(string userName)
        {
            return await _userManager.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<ApplicationUser> GetCurrentUserAsync(string userName)
        {
            return await _applicationUserRepository
                .TableNoTracking
                .Where(u => u.UserName == userName)
                .Select(user => new ApplicationUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Profile = new Core.Domain.Profile.Profile
                    {
                        Id = user.Profile.Id
                    }
                }).FirstOrDefaultAsync();
        }

        public ApplicationUser GetCurrentUser(string userName)
        {
            return _applicationUserRepository
                .TableNoTracking
                .Where(u => u.UserName == userName)
                .Select(user => new ApplicationUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Profile = new Core.Domain.Profile.Profile
                    {
                        Id = user.Profile.Id
                    }
                }).FirstOrDefault();
        }

        public async Task<ApplicationUser> GetByProfileIdAsync(int profileId)
        {
            return
                await _userManager.Users
                    .Include(u => u.Profile)
                    .FirstOrDefaultAsync(u => u.Profile.Id == profileId);
        }

        public async Task<string> GetEmailVerificationTokenAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(token);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public async Task<string> GetPasswordResetTokenAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }

        public async Task<IdentityResult> UpdateAsync(string userName, ApplicationUser applicationUser)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            _mapper.Map(applicationUser, user);

            var result = await _userManager.UpdateAsync(user);
            _eventPublisher.EntityUpdated(new ApplicationUser());
            return result;
        }

        public async Task<IdentityResult> VerifyEmailAsync(string userName, string token)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            var base64EncodedBytes = System.Convert.FromBase64String(token);
            token = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }

        public Task<int> CountRecoveryCodesAsync(ApplicationUser user)
        {
            return _userManager.CountRecoveryCodesAsync(user);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public string GetAuthenticationProvider()
        {
            return _userManager.Options.Tokens.AuthenticatorTokenProvider;
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            return _userManager.SetTwoFactorEnabledAsync(user, enabled);
        }

        public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number)
        {
            return _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userName, string token, string newPassword)
        {
            var user = await GetByUserNameAsync(userName);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result;
        }

        public async Task<PagedListResult<ApplicationUser>> GetAllFilteredUsersAsync(TableFilter tableFilter)
        {
            var sequence = _applicationUserRepository.Table.Include(x => x.Profile);

            return await _applicationUserRepository.SearchBySquenceAsync(AddFilter(tableFilter), sequence);
        }

        private SearchQuery<ApplicationUser> AddFilter(TableFilter tableFilter)
        {
            var query = _applicationUserRepository.GenerateQuery(tableFilter);
            var searchWord = tableFilter.Search.Value.ToUpper();

            query.AddFilter(x => !x.IsRemoved &&
                    ((x.FirstName + " " + x.LastName).ToUpper().Contains(searchWord)
                    || x.Email.ToUpper().Contains(searchWord)
                    || x.UserName.ToUpper().Contains(searchWord)
                    || x.PhoneNumber.Contains(searchWord)));

            return query;
        }
    }
}