using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Categories.Dtos;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(
    ILogger<GetAllCategoriesQueryHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper
    ) :
    IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all categories");

        IEnumerable<Category> categories = await categoryRepository.GetAllAsync();

        IEnumerable<CategoryDto> categoriesDto =
            mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoriesDto;
    }
}
