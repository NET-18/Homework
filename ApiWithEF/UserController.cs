using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly StoreDbContext _context;

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("AllOrders/userid/{userid}")]
        public ActionResult<IEnumerable<Order>> GetAllOrdersOfUser(int userid)
        {
            var user = _context.Users.Include(o => o.Orders).FirstOrDefault(a => a.Id == userid);
            if (user == null)
            {
                Console.WriteLine($"user#{0} not exist", userid);
                return Ok(new List<Order>());
            }

            return Ok(user.Orders.ToList());
        }

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
    }
}
