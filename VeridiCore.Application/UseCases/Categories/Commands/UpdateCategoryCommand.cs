using MediatR;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string? Description
) : IRequest<bool>;