using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly StoreDbContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
