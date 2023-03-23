using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetAllAsync()
        {
            return await _mapper.ProjectTo<GetProductDto>(_context.Products)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _context.AddAsync(product);

            // SaveChanges возвращает количество изменённых строк, т.к. под капотом это обычный insert
            // при успешном выполнении он должен записать одну строку
            var linesCount = await _context.SaveChangesAsync();

            return Ok(linesCount == 1);
        }

        [HttpGet("orderId/{orderId}")]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetAllProductsOfOrder(int orderId)
        {
            var order = _context.Orders.Include(p => p.Products).FirstOrDefault(a => a.Id == orderId);
            if (order == null)
            {
                Console.WriteLine($"order #{0} not exist", orderId);
                return NotFound();
            }

            return Ok(_mapper.ProjectTo<GetProductDto>(_context.Orders
                .Include(p => p.Products)
                .Where(a => a.Id == orderId)
                .Select(o => o.Products)
                ));           
        }
    }
}
