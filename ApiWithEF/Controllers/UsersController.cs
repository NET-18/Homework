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
            public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
            {
                return await _context.Users.ToListAsync();
            }
    }
}