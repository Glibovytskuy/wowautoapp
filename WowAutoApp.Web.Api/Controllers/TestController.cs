using Microsoft.AspNetCore.Mvc;

namespace wowautoapp.Controllers
{
    /// <summary>
    /// test
    /// </summary>
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public string Get()
        {
            return "Sucsess";
        }
    }
}