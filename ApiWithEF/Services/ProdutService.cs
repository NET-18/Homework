using ApiWithEF.Dtos;
using ApiWithEF.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Services
{
    public class ProdutService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public ProdutService(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IQueryable> GetAllProductsOfOrder(int orderId)
        {
            var order = _context.Orders.Include(p => p.Products).FirstOrDefault(a => a.Id == orderId);
            if (order == null)
            {
                Console.WriteLine($"order #{0} not exist", orderId);
                IQueryable listOppLineData = Enumerable.Empty<GetProductDto>().AsQueryable();
                return listOppLineData;
            }

            var list = _mapper.ProjectTo<GetProductDto>(_context.Orders
                .Include(p => p.Products)
                .Where(a => a.Id == orderId)
                .Select(o => o.Products)
                );
            return list;
        }
    }
}
