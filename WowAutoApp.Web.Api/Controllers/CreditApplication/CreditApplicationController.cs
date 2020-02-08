using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wowautoapp.Controllers.Abstract;
using WowAutoApp.Core;
using WowAutoApp.Services.Profile;
using wowautoapp.ViewModels;
using wowautoapp.Utilities.Filters.ValidationFilters;
using System;
using Castle.Core.Internal;

namespace wowautoapp.Controllers.CreditApplication
{
    /// <summary>
    /// Credit Application API Controller
    /// </summary>
    [Route("api/[controller]")]
    public class CreditApplicationController : BaseController
    {
        #region Fields
        private readonly IMapper _mapper;

        private readonly IProfileService _profileService;

        #endregion

        public CreditApplicationController(IWorkContext workContext,
            IProfileService profileService,
             IMapper mapper) : base(workContext)
        {
            _mapper = mapper;
            _profileService = profileService;
        }

        /// <summary>
        /// Get profile data part for credit application.
        /// </summary>
        /// <returns>returns 204 (No content) </returns>
        [HttpGet]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetProfileData()
        {
            if (CurrentUser is null && CurrentUser.Id.IsNullOrEmpty())
                return BadRequest("User is null");

            var profile = await _profileService.GetProfileByUserIdAsync(CurrentUser.Id);

            if (profile is null)
                return NoContent();

            profile.ApplicationUserId = null;

            return Ok(profile);
        }

        /// <summary>
        /// Update Credit application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ValidationFilter]
        public async Task<IActionResult> UpdateAsync([FromBody] ProfileViewModel model)
        {
            if (CurrentUser is null)
                return BadRequest("User is null");

            var profile = await _profileService.GetProfileByUserIdAsync(CurrentUser.Id);

            if (profile == null)
                return BadRequest("Profile not found");

            try
            {
                var mappedProfile = _mapper.Map(model, profile);
                _profileService.UpdateProfile(mappedProfile);
            }
            catch (Exception ex)
            {
                return Ok("Bad Mapping proffile: " + ex.Message);
            }

            /* ToDo: Need implement blob for correctly work
            var mappedVehicle = _mapper.Map<Vehicle>(model);
            mappedVehicle.OwnerLicenseId = userIdentity.Id;
            _vehicleService.AddVehicle(mappedVehicle);
            */

            return Ok();
        }
    }
}