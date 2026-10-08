using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Orders.Dtos;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Orders.Queries.GetAllOrders;

internal class GetAllOrdersQueryHandler(
    IOrderRepository orderRepository,
    IMapper mapper,
    ILogger<GetAllOrdersQueryHandler> logger
    ) :
    IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(
        GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting order user {request.UserId}");

        IEnumerable<Order> orders = await orderRepository.GetAllAsync(request.UserId);

        IEnumerable<OrderDto> orderDtos = orders
            .OrderByDescending(o => o.CreatedAt)
            .Select(o => mapper.Map<OrderDto>(o)).ToList();

        return orderDtos;
    }
}
