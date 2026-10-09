using MediatR;
using ShopManagementSystem.Application.Categories.Dtos;

namespace ShopManagementSystem.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<CategoryDto?>
{
    public Guid Id { get; } = id;
}
