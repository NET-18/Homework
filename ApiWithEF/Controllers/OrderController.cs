using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return Ok(_mapper.ProjectTo<GetOrderDto>(_context.Orders
                    .Where(o => o.UserId == userId)));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(AddOrderDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var order = new Order();
                order =_mapper.Map<Order>(dto);
                var resultProducts = new List<OrderProduct>();

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                foreach (var product in dto.ProductsId)
                {
                    resultProducts.Add(new()
                    {
                        ProductId = product,
                        OrderId = order.Id
                    });
                }

                await _context.AddRangeAsync(resultProducts);

                order.TotalPrice = await _context.Products
                    .Where(p => dto.ProductsId.Contains(p.Id))
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


