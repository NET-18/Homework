using Generate.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Generate.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateController : ControllerBase
{
    private MergingService _mergingService;
    
    GenerateController(MergingService mergingService)
    {
        _mergingService = mergingService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        return await _mergingService.GetRandomCountOFObject();
    }

    [HttpGet("/count/{count:int}/friends/{friends:int}/tags/{tags:int}")]
    public async Task<ActionResult<IEnumerable<Person>>> GetByCount(int count, int friends, int tags)
    {
        return await _mergingService.GetFixCountOFObject(count, tags, friends);
    }
}