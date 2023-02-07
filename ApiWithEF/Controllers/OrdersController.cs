using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;


        public OrdersController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetAllUserOrdersAsync(int userid)
        {
            return await _mapper.ProjectTo<GetOrderDto>(
                _context.Orders
                .Where(o => o.UserId == userid))
                .ToListAsync();
        }

        [HttpPost()]
        public async Task<ActionResult> AddOrdersAsync(AddOrderDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var order = _mapper.Map<Order>(dto);

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                var orderProducts = new List<OrderProduct>();
                foreach (var productId in dto.ProductsId)
                {
                    orderProducts.Add(new()
                    {
                        ProductId = productId,
                        OrderId = order.Id
                    });
                }

                await _context.AddRangeAsync(orderProducts);

                order.TotalPrice = await _context.Products
                    .Where(p => dto.ProductsId.Contains(p.Id))
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
    }
}
