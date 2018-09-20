using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Folls.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        
        public HomeController(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }
        
        [Route("/{*url}")]
        public IActionResult Index(string url)
        {
            Console.WriteLine(url);
            var file = System.IO.File.OpenRead(Path.Combine(_hostingEnv.WebRootPath, "index.html"));

            return File(file, "text/html");
        }

        [Route("/__internal/healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok("Works");
        }
    }
}