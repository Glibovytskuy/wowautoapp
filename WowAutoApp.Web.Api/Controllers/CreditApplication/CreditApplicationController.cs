using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wowautoapp.Controllers.Abstract;
using WowAutoApp.Core;
using Profile = WowAutoApp.Core.Domain.Profile.Profile;
using WowAutoApp.Services.Profile;
using wowautoapp.ViewModels;
using wowautoapp.Utilities.Filters.ValidationFilters;

namespace wowautoapp.Controllers.CreditApplication
{
    [Route("api/[controller]")]
    [ApiController]
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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ValidationFilter]
        public async Task<IActionResult> UpdateAsync([FromBody] ProfileViewModel model)
        {
            //ToDo: need to implement current user
            //var profile = _profileService.GetProfileByUserId(CurrentUser.Id);

            //if (profile == null)
            //    return BadRequest("Profile not found");

            //try
            //{
            //    var mappedProfile = _mapper.Map<Profile>(model);
            //    mappedProfile.Id = profile.Id;

            //    _profileService.UpdateProfile(mappedProfile);
            //}
            //catch (Exception ex)
            //{
            //    return Ok("Bad Mapping proffile: " + ex.Message);
            //}

            /* ToDo: Need implement blob for correctly work
            var mappedVehicle = _mapper.Map<Vehicle>(model);
            mappedVehicle.OwnerLicenseId = userIdentity.Id;
            _vehicleService.AddVehicle(mappedVehicle);
            */

            return Ok();
        }
    }
}