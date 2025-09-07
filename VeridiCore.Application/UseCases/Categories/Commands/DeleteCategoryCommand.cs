using MediatR;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;