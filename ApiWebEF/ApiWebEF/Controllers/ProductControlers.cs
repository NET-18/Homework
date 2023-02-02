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
        [HttpGet("productsByOrder/{orderId:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByOrderAsync(int orderId)
        {
            return await _context.Products.Where(p => p.Orders.Any(o => o.Id == orderId)).ToListAsync();
        }
    }
}
