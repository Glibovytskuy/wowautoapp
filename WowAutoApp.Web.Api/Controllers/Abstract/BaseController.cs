using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WowAutoApp.Core;
using WowAutoApp.Core.Domain;
using WowAutoApp.Services.Utilities;
using wowautoapp.Utilities.Filters;
using WowAutoApp.Services.Identity.Auth;
using System.Linq;
using WowAutoApp.Core.Infrastructure;

namespace wowautoapp.Controllers.Abstract
{
    /// <summary>
    /// Base controller
    /// </summary>
    [CurrentUserExist]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Application user
        /// </summary>
        public ApplicationUser CurrentUser;

        /// <summary>
        /// SPA Client
        /// </summary>
        public Client Client;

        /// <summary>
        /// Work context
        /// </summary>
        protected readonly IWorkContext WorkContext;

        /// <summary>
        /// API error messages.
        /// </summary>
        protected Error Error;

        /// <summary>
        /// Base controller constructor
        /// </summary>
        /// <param name="workContext"></param>
        protected BaseController(IWorkContext workContext)
        {
            WorkContext = workContext;
            CurrentUser = WorkContext.CurrentUser;

            var clientName = IdentityServerConfig.GetClients()
                .FirstOrDefault(c => c.ClientId == WorkContext.ClientId)?.ClientName;
            Client = new Client
            {
                Id = WorkContext.ClientId,
                Name = clientName,
                ClientUrl = WorkContext.RequestUrl
            };
        }

        /// <summary>
        /// Bad model state
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        protected BadRequestObjectResult Bad(ModelStateDictionary modelState)
        {
            return BadRequest(modelState);
        }

        /// <summary>
        /// Bad raquest object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        protected BadRequestObjectResult Bad(string name, string error)
        {
            ModelState.AddError(name, error);
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Bad identity result
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected BadRequestObjectResult Bad(IdentityResult result)
        {
            ModelState.AddErrors(result);
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Bad request error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected BadRequestObjectResult Bad(string error)
        {
            return Bad("BadRequest", error);
        }

        /// <summary>
        /// User name
        /// </summary>
        protected string UserName => CurrentUser?.UserName ?? string.Empty;
    }

    /// <summary>
    /// API error messages.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// User not exist in system
        /// </summary>
        public const string UserNotExistInSystem = "User doesn't exist in the system!";
    }
}