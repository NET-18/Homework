using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Services
{
    public class OrderService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddOrderAsync(AddOrderDto dto)
        {
            var order = new Order();
            order = _mapper.Map<Order>(dto);
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

            var linesCount = await _context.SaveChangesAsync();

            return linesCount;

        }
    }
}
