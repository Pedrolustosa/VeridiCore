using MediatR;
using VeridiCore.Application.DTOs;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Categories.Queries;

public class GetAllCategoriesByUserQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesByUserQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesByUserQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllByUserAsync(request.UserId);

        return categories.Select(c => new CategoryDto(
            c.Id,
            c.Name,
            c.Description,
            c.Type.ToString()
        ));
    }
}