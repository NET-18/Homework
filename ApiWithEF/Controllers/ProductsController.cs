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

        [HttpPost("userid/{userid:int}")]
        public async Task<IActionResult> AddOrderAsync(int userid, int[] productsid)
        {
            var order = new Order
            {
                UserId = userid
            };
            order.Products = new List<Product>();
            foreach (var product in productsid)
            {
                order.Products.Add(_context.Products.FirstOrDefault(p => p.Id == product));
            }
            
            await _context.AddAsync(order);

            // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
            // при успешном выполнении он должен записать одну строку
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }
    }
}
