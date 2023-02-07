using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;


        public UsersController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllAsync()
        {
            return await _mapper.ProjectTo<GetUserDto>(
                _context.Users)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            await _context.AddAsync(user);

            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}
