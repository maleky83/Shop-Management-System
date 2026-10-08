using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Orders.Dtos;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Orders.Queries.GetOrderbyId;

internal class GetOrderbyIdQueryHandler(
        ILogger<GetOrderbyIdQueryHandler> logger,
        IOrderRepository orderRepository,
        IMapper mapper
    ) : IRequestHandler<GetOrderbyIdQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(
        GetOrderbyIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting order {request.OrderId} for user {request.UserId}");

        Order order = await orderRepository.GetByIdAsync(request.UserId, request.OrderId);

        OrderDto orderDto = mapper.Map<OrderDto>(order);

        return orderDto;
    }
}
