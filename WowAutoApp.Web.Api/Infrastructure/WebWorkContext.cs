using IdentityModel;
using Microsoft.AspNetCore.Http;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Identity.Cache;
using WowAutoApp.Services.Identity.User;
using WowAutoApp.Core;
using System.Threading.Tasks;

namespace wowautoapp.Infrastructure
{
    /// <inheritdoc />
    /// <summary>
    /// Represents work context for web application
    /// </summary>
    public class WebWorkContext : IWorkContext
    {
        private ApplicationUser _cachedUser;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        /// <summary>
        /// Web Work Context constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userService"></param>
        public WebWorkContext(IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        /// <inheritdoc />
        /// <summary>
        /// Get it current user
        /// </summary>
        public ApplicationUser CurrentUser
        {
            get
            {
                var userName = _httpContextAccessor.HttpContext.User.FindFirst(JwtClaimTypes.Name)?.Value?.Trim();
                if (string.IsNullOrEmpty(userName))
                    return _cachedUser;

                _cachedUser = _userService.GetCurrentUser(userName);

                return _cachedUser;
            }
            set => _cachedUser = value;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Get request Client Id
        /// </summary>
        public string ClientId
        {
            get
            {
                _httpContextAccessor.HttpContext.Request.Headers.TryGetValue(JwtClaimTypes.ClientId, out var clientId);
                return clientId;
            }
        }
    }
}