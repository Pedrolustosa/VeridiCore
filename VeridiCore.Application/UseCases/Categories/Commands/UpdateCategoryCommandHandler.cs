using MediatR;
using VeridiCore.Domain.Interfaces.UnitOfWork;
using VeridiCore.Domain.Interfaces.Repositories;

namespace VeridiCore.Application.UseCases.Categories.Commands;

public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return false;
        }

        category.Update(request.Name, request.Description);

        _categoryRepository.Update(category);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}