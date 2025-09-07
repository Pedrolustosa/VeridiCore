using MediatR;
using VeridiCore.Application.DTOs;

namespace VeridiCore.Application.UseCases.Categories.Queries;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;