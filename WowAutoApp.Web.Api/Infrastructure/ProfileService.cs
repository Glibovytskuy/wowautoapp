using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using WowAutoApp.Core.Consts;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Identity.User;

namespace wowautoapp.Infrastructure
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly IUserService _userService;
        private readonly WowAutoApp.Services.Profile.IProfileService _profileService;

        public ProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IUserService userService,
            WowAutoApp.Services.Profile.IProfileService profileService)
        {
            _userService = userService;
            _claimsFactory = claimsFactory;
            _profileService = profileService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userService.GetByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            var profile = _profileService.GetProfileByUserIdAsync(user.Id);
            if (profile != null)
            {
                claims.Add(new Claim(JwtClaims.ProfileId, profile.Id.ToString()));
                claims.Add(new Claim(JwtClaims.AvatarUrl, _profileService.GetPictureUrlByProfileId(profile.Id)));
            }

            if (user.FirstName != null)
                claims.Add(new Claim(JwtClaims.FirstName, user.FirstName));

            if (user.LastName != null)
                claims.Add(new Claim(JwtClaims.LastName, user.LastName));

            claims.Add(new Claim(JwtClaims.IsEmailVerified, user.EmailConfirmed.ToString()));
            claims.Add(new Claim(JwtClaims.TwoFactorEnabled, user.TwoFactorEnabled.ToString()));

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userService.GetByIdAsync(sub);

            context.IsActive = user != null && user.IsActive;
        }
    }
}