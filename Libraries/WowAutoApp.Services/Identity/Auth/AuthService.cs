using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Services.Identity.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IdentityServerOptions _options;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _principalFactory;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IRefreshTokenService refreshTokenService,
            IUserClaimsPrincipalFactory<ApplicationUser> principalFactory,
            IdentityServerOptions options)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _principalFactory = principalFactory;
            _options = options;
        }

        public async Task<ApplicationUser> GetByUserNameAsync(string username)
        {
            return await _userManager.Users
                .Where(x => x.Email.Equals(username))
                .Include(x => x.Profile)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> VerifyTwoFactorTokenAsync(string username, string authenticatorCode)
        {
            var user = await GetByUserNameAsync(username);
            return await _userManager.VerifyTwoFactorTokenAsync(user,
                _userManager.Options.Tokens.AuthenticatorTokenProvider, authenticatorCode);
        }

        public async Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(string username, string code)
        {
            var user = await GetByUserNameAsync(username);
            return await _userManager.RedeemTwoFactorRecoveryCodeAsync(user, code);
        }

        public async Task<string> GetJwtAsync(string username, string clientId)
        {
            var request = new TokenCreationRequest();
            string tokenValue;

            try
            {
                var user = await _userManager.FindByNameAsync(username);
                var claimsPrincipal = await _principalFactory.CreateAsync(user);
                var identityUser = new IdentityServerUser(user.Id)
                {
                    DisplayName = username,
                    AuthenticationTime = DateTime.UtcNow,
                    IdentityProvider = IdentityServerConstants.LocalIdentityProvider,
                    AdditionalClaims = claimsPrincipal.Claims.ToArray()
                };
                var client = IdentityServerConfig.GetClients()
                    .FirstOrDefault(c => c.ClientId == clientId);

                request.Subject = identityUser.CreatePrincipal();
                request.IncludeAllIdentityClaims = true;
                request.ValidatedRequest = new ValidatedRequest { Subject = request.Subject };
                request.ValidatedRequest.SetClient(client);
                request.ValidatedRequest.Options = _options;
                request.ValidatedRequest.ClientClaims = identityUser.AdditionalClaims;
                request.Resources = new Resources(IdentityServerConfig.GetIdentityResources(),
                    IdentityServerConfig.GetApiResources());

                var tokenObj = await _tokenService.CreateAccessTokenAsync(request);
                var accessToken = await _tokenService.CreateSecurityTokenAsync(tokenObj);
                tokenObj.Type = "refresh_token";
                var refreshToken =
                    await _refreshTokenService.CreateRefreshTokenAsync(request.Subject, tokenObj, client);

                tokenValue = "{\"access_token\": \"" + accessToken + "\", \"refresh_token\" : \"" + refreshToken +
                             "\", \"expires_in\": \"" + client?.AccessTokenLifetime + "\"}";
            }
            catch (Exception)
            {
                tokenValue = null;
            }

            return tokenValue;
        }
    }
}