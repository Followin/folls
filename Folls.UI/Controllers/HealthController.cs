using Microsoft.AspNetCore.Mvc;

namespace Folls.UI.Controllers
{
    [Route("health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It works!");
        }
    }
}