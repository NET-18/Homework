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

        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllUserOrdersAsync(int userid)
        {
            return await _context.Orders
                .Where(o => o.UserId == userid)
                .ToListAsync();
        }

        [HttpPost("{userId}/{productIds}")]
        public async Task<ActionResult> AddOrdersAsync (int userId, int[] productIds)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var order = new Order
                {
                    UserId = userId,
                };

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                var orderProducts = new List<OrderProduct>();
                foreach (var productId in productIds)
                {
                    orderProducts.Add(new()
                    {
                        ProductId = productId,
                        OrderId = order.Id
                    });
                }

                await _context.AddRangeAsync(orderProducts);

                order.TotalPrice = await _context.Products
                    .Where(p => productIds.Contains(p.Id))
                    .Select(p => p.Price)
                    .SumAsync();

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500);
            }
        }

        [HttpPost("totalprice/{totalprice}/userid/{userid}")]
        public async Task<IActionResult> AddOrderAsync(decimal totalprice, int userid)
        {
            var order = new Order
            {
                TotalPrice = totalprice,
                UserId = userid
            };

            await _context.AddAsync(order);

            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}
