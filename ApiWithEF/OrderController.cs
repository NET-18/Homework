using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly StoreDbContext _context;

        [HttpGet("AllProducts/orderid/{orderid}")]
        public ActionResult<IEnumerable<Product>> GetAllProductsOfOrder(int orderid)
        {
            var order = _context.Orders.Include(p => p.Products).FirstOrDefault(a => a.Id == orderid);
            if (order == null)
            {
                Console.WriteLine($"order #{0} not exist", orderid);
                return Ok(new List<Product>());
            }

            return Ok(order.Products.ToList());
        }

        [HttpPost("userid/{userid:int}")]
        public async Task<IActionResult> AddOrderAsync(int userid, int[] productsid)
        {
            var order = new Order
            {
                UserId = userid
            };

            var resultProducts = new List<Product>();
            var productsAdded = new List<Product>();

            foreach (var product in productsid)
            {
                productsAdded.Add(_context.Products.FirstOrDefault(p => p.Id == product));
            }
            resultProducts.AddRange(productsAdded);
            order.Products = resultProducts;
            await _context.AddAsync(order);

            // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
            // при успешном выполнении он должен записать одну строку
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 2);
        }
    }
}


