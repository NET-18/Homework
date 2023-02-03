using ApiWebEF.Models;
using ApiWebEF.Persistanse;
using ApiWebEF.Models;
using ApiWebEF.Persistanse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public UserController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
