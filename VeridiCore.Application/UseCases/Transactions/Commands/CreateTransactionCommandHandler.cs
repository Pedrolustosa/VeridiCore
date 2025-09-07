using MediatR;
using VeridiCore.Domain.Entities;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Domain.Interfaces.UnitOfWork;

namespace VeridiCore.Application.UseCases.Transactions.Commands;

public class CreateTransactionCommandHandler(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null || category.UserId != request.UserId)
        {
            throw new ApplicationException("Category not found or does not belong to the user.");
        }

        var transaction = Transaction.Create(
            request.Title,
            request.Amount,
            request.Type,
            request.PaidOrReceivedAt,
            request.CategoryId,
            request.UserId);

        await _transactionRepository.AddAsync(transaction);
        await _unitOfWork.CommitAsync(cancellationToken);

        return transaction.Id;
    }
}