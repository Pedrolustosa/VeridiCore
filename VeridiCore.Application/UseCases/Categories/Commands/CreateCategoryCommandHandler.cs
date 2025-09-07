using MediatR;
using VeridiCore.Domain.Entities;
using VeridiCore.Domain.Interfaces.UnitOfWork;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(
            request.Name,
            request.Description,
            request.Type,
            request.UserId);

        await categoryRepository.AddAsync(category);
        await unitOfWork.CommitAsync(cancellationToken);

        return category.Id;
    }
}