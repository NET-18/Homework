using System.Runtime.InteropServices.ComTypes;
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
            public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUsersAsync()
            {
                return await _mapper.ProjectTo<GetUserDto>(_context.Users).ToListAsync();
            }
    }
}