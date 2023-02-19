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
    public class UserController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public UserController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUsersAsync()
        {
            return await _mapper.ProjectTo<GetUserDto>(_context.Users)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserDto dto)
        {
            try
            {
                var user = new User();
                user = _mapper.Map<User>(dto);

                await _context.AddAsync(user);

                // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
                // при успешном выполнении он должен записать одну строку
                var linesCount = await _context.SaveChangesAsync();

                return Ok(linesCount == 1);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
