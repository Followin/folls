using System;
using System.Threading.Tasks;
using Folls.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Folls.UI.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly IMongoDatabase database;

        public HomeController(IOptions<Config> configOptions)
        {
            Console.WriteLine($"The connection string is {configOptions.Value.ConnectionString}");
            var client = new MongoClient(configOptions.Value.ConnectionString);
            database = client.GetDatabase(configOptions.Value.Database);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notes = database.GetCollection<Note>("note");
            var allNotes = await notes.Find(_ => true).ToListAsync();
            
            return Ok(allNotes);
        }
    }
}