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

        [HttpGet("products/orderid/{orderid}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsOfOrder(int orderid)
        {
            var order = await _context.Orders
                .Include(p => p.Products)
                .FirstOrDefaultAsync(a => a.Id == orderid);
            if (order == null)
            {
                Console.WriteLine($"order #{0} not exist", orderid);
                return NotFound();
            }

            return Ok(order.Products.ToList());
        }

        [HttpGet("userid/{userId}")]
        public ActionResult<IEnumerable<Order>> GetAllOrdersOfUser(int userId)
        {
            var user = _context.Users.Include(o => o.Orders).FirstOrDefault(a => a.Id == userId);
            if (user == null)
            {
                Console.WriteLine($"user#{0} not exist", userId);
                return NotFound();
            }

            return Ok(user.Orders.ToList());
        }

        [HttpPost("userId/{userid:int}")]
        public async Task<IActionResult> AddOrderAsync(int userId, int[] productsId)
        {
            using var transaction =_context.Database.BeginTransaction();
            try
            {
                var order = new Order
                {
                    UserId = userId
                };

                var resultProducts = new List<OrderProduct>();

                foreach (var product in productsId)
                {
                    resultProducts.Add(new()
                    {
                        ProductId = product,
                        OrderId = order.Id
                    });
                }

                await _context.AddRangeAsync(resultProducts);

                order.TotalPrice = await _context.Products
                    .Where(p => productsId.Contains(p.Id))
                    .Select(p => p.Price)
                    .SumAsync();

                await transaction.CommitAsync();

                var linesCount = await _context.SaveChangesAsync();

                return Ok(linesCount >= 1);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500);
            }
        }
    }
}


