using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler(
    ILogger<CreateOrderCommandHandler> logger,
    IValidator<CreateOrderCommand> validator,
    IOrderRepository orderRepository
    ) : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        logger.LogInformation($"Creating order for user {request.UserId}");

        Guid id = await orderRepository.CreateAsync(request.UserId);
        return id;
    }
}
