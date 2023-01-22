using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : Controller
    {
        private readonly GeneratePersonSevices _someScopedService;
        private readonly GenerateGuidService _guidService;
        private readonly GenerateBalanceService _balanceService;
        private readonly GeneratePersonNameService _personNameService;
        private readonly GenerateAgeService _ageService;
        private readonly GenerateEmailService _emailService;
        private readonly GeneratePhoneService _phoneService;
        private readonly GenerateAboutService _aboutService;
        private readonly GenerateTagsService _tagsService;
        private readonly GenerateFriendService _friendService;
        private readonly ILogger<GenerateController> _logger;

        public GenerateController(ILogger<GenerateController> logger, GeneratePersonSevices someScopedService, GenerateGuidService guidService, GenerateBalanceService balanceService, GeneratePersonNameService personNameService, GenerateAgeService ageService, GenerateEmailService emailService, GeneratePhoneService phoneService, GenerateAboutService aboutService, GenerateTagsService tagsService, GenerateFriendService friendService)
        {
            _logger = logger;
            _someScopedService = someScopedService;
            _guidService = guidService;
            _balanceService = balanceService;
            _personNameService = personNameService;
            _ageService = ageService;
            _emailService = emailService;
            _phoneService = phoneService;
            _aboutService = aboutService;
            _tagsService = tagsService;
            _friendService = friendService;
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
