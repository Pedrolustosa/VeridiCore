using MediatR;
using VeridiCore.Domain.Interfaces.UnitOfWork;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return false;
        }

        category.Deactivate();

        _categoryRepository.Delete(category);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}