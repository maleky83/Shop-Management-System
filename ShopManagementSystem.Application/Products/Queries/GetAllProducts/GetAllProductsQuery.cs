using MediatR;
using ShopManagementSystem.Application.Products.Dtos;

namespace ShopManagementSystem.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}
