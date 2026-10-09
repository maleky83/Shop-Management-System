using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Categories.Dtos;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(
    ILogger<GetCategoryByIdQueryHandler> logger,
    IMapper mapper,
    ICategoryRepository categoryRepository
    ) : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Get category by id");

        Category? category = await categoryRepository.GetByIdAsync(request.Id);

        CategoryDto categoryDto = mapper.Map<CategoryDto>(category);

        return categoryDto;
    }
}
