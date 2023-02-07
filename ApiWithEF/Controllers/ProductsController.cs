using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        [HttpGet("orderId/{orderId}")]
        public ActionResult<IEnumerable<Product>> GetAllProductsOfOrder(int orderId)
        {
            var order = _context.Orders.Include(p => p.Products).FirstOrDefault(a => a.Id == orderId);
            if (order == null)
            {
                Console.WriteLine($"order #{0} not exist", orderId);
                return Ok(new List<Product>());
            }

            return Ok(order.Products.ToList());
        }
    }
}
