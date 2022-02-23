using AutoMapper;
using IZCommerce.Application.Features.Orders.Commands.CreateOrder;
using IZCommerce.Application.Features.Orders.Queries.GetOrdersList;
using IZCommerce.Domain.Entities;

namespace IZCommerce.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, CreateOrderDto>();
            CreateMap<Order, OrderListViewModel>();
        }
    }
}
