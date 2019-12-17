using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wowautoapp.Controllers.Abstract;
using WowAutoApp.Core;
using wowautoapp.Utilities.Filters.ValidationFilters;
using wowautoapp.ViewModels;
using AutoMapper;
using WowAutoApp.Core.Domain;

namespace wowautoapp.Controllers.Buisness
{
    [Route("api/[controller]")]
    public class BuisnessController : BaseController
    {
        #region Fields
        private readonly IMapper _mapper;

        #endregion

        public BuisnessController(IWorkContext workContext,
             IMapper mapper
            ) : base(workContext)
        {
            _mapper = mapper;

        }

        /// <summary>
        /// The create API allows to create a Buisness item based on provided JSON object.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ValidationFilter]
        public async Task<IActionResult> CreateAsync(RegistrationBuisnessViewModel model)
        {
            var bankAddressViewModel = _mapper.Map<Address>(model);
            var bankViewModel = _mapper.Map<Bank>(model);
            var buisnessViewModel = _mapper.Map<WowAutoApp.Core.Domain.Buisness>(model);


            return Ok();
        }
    }
}