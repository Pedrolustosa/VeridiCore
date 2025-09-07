using MediatR;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Domain.Interfaces.UnitOfWork;

namespace VeridiCore.Application.UseCases.Transactions.Commands;

public class UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTransactionCommand, bool>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetByIdAsync(request.Id);

        if (transaction is null || transaction.UserId != request.UserId)
        {
            return false;
        }

        transaction.Update(request.Title, request.Amount, request.PaidOrReceivedAt, request.CategoryId);

        _transactionRepository.Update(transaction);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}