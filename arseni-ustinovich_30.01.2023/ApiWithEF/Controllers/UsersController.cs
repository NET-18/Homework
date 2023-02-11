using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Xml.Linq;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetAllUserOrdersAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderProducts)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return Ok("User doens't exist!");
            }
  
            if (user.Orders.Count == 0)
            {
                return Ok("User doesn't have any orders!");
            }

            var productList = await _context.Products.ToListAsync();

            var ordersDto = new List<GetOrderDto>();

            foreach (var order in user.Orders)
            {
                var products = order.OrderProducts
                .Select(op =>
                    new GetOrderDto.NamedTuple(
                        op.ProductId,
                        productList.First(p => p.Id == op.ProductId).Name,
                        op.ProductCount))
                    .ToList();

                var orderDto = new GetOrderDto
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                    UserId = userId,
                    Products = new List<GetOrderDto.NamedTuple>(products)
                };

                ordersDto.Add(orderDto);
            }

            return Ok(ordersDto);   
        }
    }
}
