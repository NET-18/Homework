using Generate.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Generate.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        return await MergingService.GetRandomCountOFObject();
    }

    [HttpGet("/count/{count:int}/friends/{friends:int}/tags/{tags:int}")]
    public async Task<ActionResult<IEnumerable<Person>>> GetByCount(int count, int friends, int tags)
    {
        return await MergingService.GetFixCountOFObject(count, tags, friends);
    }
}