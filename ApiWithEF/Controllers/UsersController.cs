using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public UsersController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("name/{name}/surname/{surname}")]
        public async Task<IActionResult> AddUserAsync(string name, string surname)
        {
            var user = new User
            {
                Name = name,
                Surname = surname
            };

            await _context.AddAsync(user);

            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}
