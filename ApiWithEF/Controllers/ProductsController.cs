﻿using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await _mapper.ProjectTo<GetProductDto>(
                _context.Products)
                .ToListAsync();
        }

        [HttpGet("products/{orderId:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByOrderAsync(int orderId)
        {
            var order = _context.Orders
                .Include(p => p.Products)
                .FirstOrDefault(a => a.Id == orderId);

            return Ok(order.Products.ToList());

            //return await _context.OrderProducts
            //    .GroupBy(p => p.OrderId)
            //    .ToListAsync();
            //return await _context.Products
            //    .Where(p => p.Orders
            //    .Any(o => o.Id == orderId))
            //    .ToListAsync();
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
    }
}
