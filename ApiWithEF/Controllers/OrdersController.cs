using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public OrdersController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        
        [HttpGet("/userId/{userId:int}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByUserAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        [HttpPost("/userId/{userId:int}/")]
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