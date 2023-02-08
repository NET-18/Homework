using ApiWithEF.Dtos;
using ApiWithEF.Models;
using AutoMapper;

namespace ApiWithEF.Common;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<User, GetUserDto>();
        CreateMap<Product, GetProductDto>();
        CreateMap<Order, GetOrderDto>();
    }
}