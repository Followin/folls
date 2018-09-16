using System;
using System.Threading.Tasks;
using Folls.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Folls.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoDatabase _database;

        public HomeController(IOptions<Config> configOptions)
        {
            Console.WriteLine(configOptions.Value.ConnectionString);
            var client = new MongoClient(configOptions.Value.ConnectionString);

            _database = client.GetDatabase(configOptions.Value.Database);
        }
        
        [HttpGet, Route("api/notes")]
        public async Task<IActionResult> Get()
        {
            var notes = _database.GetCollection<Note>("note");
            var allNotes = await notes.Find(_ => true).ToListAsync();
            
            return Ok(allNotes);
        }
        
        [Route("__internal/healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok("Works");
        }
    }
}