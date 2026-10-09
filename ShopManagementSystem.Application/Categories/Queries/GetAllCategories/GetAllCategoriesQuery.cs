using MediatR;
using ShopManagementSystem.Application.Categories.Dtos;

namespace ShopManagementSystem.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
