using ApiWithEF.Dtos;
using ApiWithEF.Models;
using AutoMapper;

namespace ApiWithEF.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<User, GetUserDto>();
        }
    }
}
