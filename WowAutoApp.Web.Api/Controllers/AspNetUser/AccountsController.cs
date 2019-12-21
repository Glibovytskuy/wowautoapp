using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wowautoapp.Controllers.Abstract;
using wowautoapp.Utilities.Filters.ValidationFilters;
using wowautoapp.ViewModels.AspNetUser;
using WowAutoApp.Core;
using WowAutoApp.Core.Consts;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Email.Token;
using WowAutoApp.Services.Identity.Auth;
using WowAutoApp.Services.Identity.Registration;
using WowAutoApp.Services.Identity.User;
using WowAutoApp.Services.Profile;
using WowAutoApp.Services;
using Profile = WowAutoApp.Core.Domain.Profile.Profile;
using WowAutoApp.Services.Email;
using wowautoapp.ViewModels;
using System.Linq;

namespace wowautoapp.Controllers.AspNetUser
{
    /// <summary>
    /// Accounts API Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IRegistrationService _registrationService;
        private readonly IProfileService _profileService;
        private readonly IVehicleService _vehicleService;
        private readonly IEmailExtensionService _emailService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        #endregion

        public AccountsController(IWorkContext workContext,
            IMapper mapper,
            IAuthService authService,
            IUserService userService,
            IRegistrationService registrationService,
            IProfileService profileService,
            IVehicleService vehicleService,
            IEmailExtensionService emailService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            ) : base(workContext)
        {
            _mapper = mapper;
            _authService = authService;
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _registrationService = registrationService;
            _profileService = profileService;
            _vehicleService = vehicleService;
            _emailService = emailService;
        }

        /// <summary>
        /// Send verification email.
        /// </summary>
        /// <returns>returns 204 (No content) </returns>
        [HttpGet("send-confirmation-email")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> SendVerificationEmailAsync(string callbackUrl)
        {
            var token = new EmailToken
            {
                Email = UserName,
                Token = await _userService.GetEmailVerificationTokenAsync(UserName)
            };
            await _emailService.SendVerificationEmailAsync(token, callbackUrl);

            return NoContent();
        }

        /// <summary>
        /// The create API allows to create a Profile item based on provided JSON object.
        /// </summary>
        /// <param name="model">Registration view model</param>
        /// <returns>Returns a 200 response if item added. Can return 400 if model state is
        /// not valid</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
       // [ValidationFilter]
        public async Task<IActionResult> CreateAsync([FromBody] RegistrationViewModel model)
        {
            var userIdentity = _mapper.Map<ApplicationUser>(model);

            var result = await _registrationService.RegisterAsync(userIdentity, model.Password, model.CallbackUrl);
            if (!result.Succeeded)
                return Bad(result.Errors.FirstOrDefault().Description);

            var mappedProfile = _mapper.Map<Profile>(model);
            mappedProfile.ApplicationUserId = userIdentity.Id;
            _profileService.AddProfile(mappedProfile);

            /* ToDo: Need implement blob for correctly work
            var mappedVehicle = _mapper.Map<Vehicle>(model);
            mappedVehicle.OwnerLicenseId = userIdentity.Id;
            _vehicleService.AddVehicle(mappedVehicle);
            */


            //ToDo: Need to implement send email verify user and for admin all data without pass

            //add role 
            await _userManager.AddToRoleAsync(userIdentity, Consts.UserRoleKey);

            var jwt = await _authService.GetJwtAsync(model.Email, ClientId);
            return Ok(jwt);
        }

        /// <summary>
        /// The send API allows to send a User email for change password.
        /// </summary>
        /// <param name="model">Forgot password view model</param>
        /// <returns>Returns a 204 response if item send. Can return 400 if model state is
        /// not valid</returns>
        [AllowAnonymous]
        [HttpPost("restore-password")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ValidationFilter]
        public async Task<IActionResult> SendPasswordRestoreEmailAsync([FromBody] ForgotPasswordViewModel model)
        {
            var user = await _userService.GetByUserNameAsync(model.Email);
            if (user == null || !user.EmailConfirmed)
                // Don't reveal that the user does not exist or is not confirmed
                return NoContent();

            var token = new EmailToken
            {
                Email = model.Email,
                Token = await _userService.GetPasswordResetTokenAsync(model.Email)
            };

            //await _emailExtensionService.SendPasswordResetEmailAsync(token, model.CallbackUrl);

            return NoContent();
        }

        /// <summary>
        /// The change password API allows to update password item based on provided JSON object.
        /// </summary>
        /// <param name="model">Change password view model</param>
        /// <returns>
        ///  Returns a 204 response if password are updated. Can return 400 if the
        ///  model is't valid.
        /// </returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ValidationFilter]
        public async Task<IActionResult> UpdateAsync([FromBody] ChangePasswordViewModel model)
        {
            if (model.OldPassword.Equals(model.NewPassword))
            {
                //ToDo: Need implement resourses
                return Bad("New and current password must be different");
            }

            var changePasswordResult = await _userService.ChangePasswordAsync(CurrentUser.UserName, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                return Bad("");
            }

            return NoContent();
        }

        /// <summary>
        /// The update API allows to update a token item based on provided JSON object.
        /// To support partial updates, use HTTP PATCH.
        /// </summary>
        /// <returns>The response is 200 (Status - Ok).</returns>
        [HttpGet("refresh-token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RefreshAsync()
        {
            if (string.IsNullOrEmpty(CurrentUser.UserName))
                return NotFound();

            var token = await _authService.GetJwtAsync(CurrentUser.UserName, ClientId);
            return Ok(token);
        }
    }
}