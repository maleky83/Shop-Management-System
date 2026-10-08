using AutoMapper;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Application.Orders.Dtos;

internal class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(
            dest => dest.OrderId,
            opt => opt.MapFrom(src => src.Id));
    }
}
