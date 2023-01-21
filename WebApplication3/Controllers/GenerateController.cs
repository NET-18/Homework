using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : Controller
    {
        private readonly GenerateSevices _someScopedService;
        private readonly ILogger<GenerateController> _logger;

        public GenerateController(ILogger<GenerateController> logger, GenerateSevices someScopedService)
        {
            _logger = logger;
            _someScopedService = someScopedService;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetRandom()
        {
            int friends = Random.Shared.Next(0, 10);
            int tags = Random.Shared.Next(2, 8);
            return await _someScopedService.GetRandomPerson(friends, tags);
        }

        [HttpGet("count/{count:int}/friends/{friends:int}/tags/{tags:int}/")]
        public async Task<ActionResult<List<Person>>> GetByData(int count, int friends, int tags)
        {
            var list = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                list.Add(await _someScopedService.GetRandomPerson(friends, tags));
            }
            var jsonResult = JsonConvert.SerializeObject(list);
            
            return JsonConvert.DeserializeObject<List<Person>>(jsonResult);
        }
    }
}
