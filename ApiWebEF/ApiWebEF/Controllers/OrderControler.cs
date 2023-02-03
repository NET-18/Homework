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
    public class OrderController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public OrderController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("orderByUser/{userId:int}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByUserAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        [HttpPost("user/{userId:int}/products/{productId}")]
        public async Task<IActionResult> CreateOrderAsync(int userId, string productId)
        {
            string[] items = productId.Split(',');
            List<int> listInt = new List<int>();

            foreach (string i in items)
            {
                listInt.Add(int.Parse(i));
            }
            decimal totalPrice = 0;

            foreach (Product p in _context.Products)
            {
                foreach(int i in listInt)
                {
                    if (p.Id == i)
                    {
                        totalPrice += p.Price;
                    }
                }
            }
            var order = new Order
            {
                UserId= userId,
                TotalPrice = totalPrice,
            };

            await _context.Orders.AddAsync(order);

            // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
            // при успешном выполнении он должен записать одну строку
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }

    }
}
