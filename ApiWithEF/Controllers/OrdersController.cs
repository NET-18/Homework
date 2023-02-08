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
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetAllAsync()
        {
            return await _mapper.ProjectTo<GetOrderDto>(_context.Orders).ToListAsync();
        }
        
        [HttpGet("userId/{userId:int}")]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetAllOrdersByUserAsync(int userId)
        {
            return await _mapper.ProjectTo<GetOrderDto>(_context.Orders.Where(o => o.UserId == userId)).ToListAsync();
        }

        [HttpPost("userId/{userId:int}/")]
        public async Task<IActionResult> AddOrderAsync(int userId, int[] productsId)
        {
            var products = await _context.Products.Where(p => productsId.Contains(p.Id)).ToListAsync();

            var totalPrice = products.Sum(product => product.Price);

            var order = new Order()
            {
                UserId = userId,
                TotalPrice = totalPrice,
                Products = products
            };

            await _context.AddAsync(order);

            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}