using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet("orderId/{orderId:int}/products")]
        public async Task<ActionResult<IEnumerable<GetOrderProductDto>>> GetAllOrderProductsAsync(int orderId)
        {
            var order = await _context.Orders.Include(p => p.Products).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return Ok("Order doesn't exist");
            }

            var products = order.Products;

            if (products.Count == 0)
            {
                return Ok("Order doesn't exist");
            }

            var orderProducts = new List<GetOrderProductDto>();

            foreach (var product in products) 
            {
                var orderProduct = new GetOrderProductDto {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Count = order.OrderProducts.First(op => op.ProductId == product.Id).ProductCount, 
                };
                
                orderProduct.TotalProductPrice = orderProduct.Count * orderProduct.Price;
                
                orderProducts.Add(orderProduct);
            }

            return Ok(orderProducts);
        }

        [HttpPost("create/")]
        public async Task<IActionResult> AddOrderAsync(AddOrderDto dto)
        {
            var userId = dto.UserId;
            var productIds = dto.productIds;
            
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return Ok("User doesn't exist");
            }

            var products = _context.Products
                .AsEnumerable()
                .Where(p => productIds.Contains(p.Id))
                .Select(p => new Tuple<Product, int>(p, productIds.Count(id => id == p.Id)))
                .ToList();

            if (products == null)
            {
                return Ok("Products doesn't exist or incorrect");
            }

            var totalPrice = products.Select(p => p.Item1.Price * p.Item2).Sum();

            var order = new Order
            {
                TotalPrice = totalPrice,
                UserId = userId,
                Products = new List<Product>(products.Select(p => p.Item1).ToList()),
            };

            await _context.AddAsync(order);

            foreach (var orderProduct in order.OrderProducts)
            {
                orderProduct.ProductCount = products.Where(p => p.Item1.Id == orderProduct.ProductId).Select(p => p.Item2).First();
            }

            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
