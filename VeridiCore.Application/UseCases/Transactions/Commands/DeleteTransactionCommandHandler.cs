using MediatR;
using VeridiCore.Domain.Interfaces.Repositories;
using VeridiCore.Domain.Interfaces.UnitOfWork;

namespace VeridiCore.Application.UseCases.Transactions.Commands;

public class DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetByIdAsync(request.Id);

        if (transaction is null || transaction.UserId != request.UserId)
        {
            return false;
        }

        transaction.Deactivate();
        _transactionRepository.Update(transaction);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}