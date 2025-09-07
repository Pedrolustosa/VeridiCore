using MediatR;
using VeridiCore.Application.DTOs;

namespace VeridiCore.Application.UseCases.Categories.Queries;

public record GetAllCategoriesByUserQuery(Guid UserId) : IRequest<IEnumerable<CategoryDto>>;