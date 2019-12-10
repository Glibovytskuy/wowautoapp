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

namespace wowautoapp.Controllers.Buisness
{
    [Route("api/[controller]")]
    public class BuisnessController : BaseController
    {
        public BuisnessController(IWorkContext workContext)
            : base(workContext)
        {

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

            return Ok();
        }
    }
}