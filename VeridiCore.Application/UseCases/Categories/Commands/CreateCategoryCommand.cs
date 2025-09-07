using MediatR;
using VeridiCore.Domain.Enums;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public record CreateCategoryCommand(
    string Name,
    string? Description,
    CategoryType Type,
    Guid UserId
) : IRequest<Guid>;