using MediatR;
using VeridiCore.Application.DTOs;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Categories.Queries;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return null;
        }

        return new CategoryDto(
            category.Id,
            category.Name,
            category.Description,
            category.Type.ToString());
    }
}