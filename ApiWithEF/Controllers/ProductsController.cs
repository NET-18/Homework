using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ProductsController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        [HttpGet("orders/{userId:int}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByUserAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
        
        [HttpGet("products/{orderId:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByOrderAsync(int orderId)
        {
            return await _context.Products.Where(p => p.Orders.Any(o => o.Id == orderId)).ToListAsync();
        }

        [HttpPost("userId/{userId:int}/")]
        public async Task<IActionResult> AddOrderAsync(int userId, int[] productsId)
        {
            var totalPrice = 0.0m;
            for (var i = 0; i < productsId.Length; i++)
            {
                totalPrice += _context.Products.FirstOrDefault(p => p.Id == productsId[i]).Price;
            }
            
            var order = new Order()
            {
                UserId = userId,
                TotalPrice = totalPrice
            };

            await _context.AddAsync(order);
            
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }

        [HttpPost("name/{name}/price/{price}")]
        public async Task<IActionResult> AddProductAsync(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            await _context.AddAsync(product);

            // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
            // при успешном выполнении он должен записать одну строку
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}
